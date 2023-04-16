using TPH.LIS.Common;

namespace TPH.Lab.Middleware.LISConnect.DataAccesses
{
    using BusinessService.Services;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.Data.SqlClient;
    using System.Data;
    using Data.Configuration;
    using Helpers.Enum;
    using HISConnect.Services;
    using HISConnect.Models;
    using System.Collections.Generic;
    using LIS.Patient.Services;
    using LIS.Patient.Model;
    using LIS.TestResult.Services;
    using LIS.Common.Extensions;
    using Data.HIS.Models;
    using Data.HIS.HISDataCommon;
    using BusinessService.Models;
    using WriteLog;
    using System.Diagnostics;
    using TPH.Lab.Middleware.LISConnect.Models;
    using TPH.LIS.Data;
    using TPH.LIS.DigitalSignature.Models;
    using DevExpress.Office.Utils;

    public class ConnectHISDataAccess : IConnectHISDataAccess
    {
        private readonly IGetHISService _iGetHisService = new GetHISService();
        private readonly IPatientInformationService _iBenhNhanInfo = new PatientInformationService();
        private readonly ITestResultService _itestResult = new TestResultService();
        void ThrowNewException(string message)
        {
            LogService.RecordLogFile(message);
            throw new Exception(message);
        }

        private string InsertBenhNhan(BenhNhanInfoForHIS info, bool updateGet
            , HisConnection hisConnect, List<HisFunctionConfig> hisFunction, bool useHISBarcode)
        {
            try
            {
                string mess = string.Empty;
                //var insert = new InsertPatientFromHISBase();

                var lstMappingData = HISMappingService.GetInstance().GetMappingData(HisMappingCategory.All, (int)hisConnect.HisID);

                var mappingCheck = new HISMapping { HisProviderID = (int)hisConnect.HisID };

                if (!string.IsNullOrEmpty(info.Bacsicd))
                {
                    mappingCheck.CategoryID = (int)HisMappingCategory.NhanVien;
                    mappingCheck.HISID = info.Bacsicd;
                    mappingCheck.ItemName = info.Tenbacsichidinh;

                    info.Bacsicd = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                    //NhanVienService.GetInstance().SyncNhanVien(info.Bacsicd, info.Tenbscd).MaNhanVien;
                    //info.Bacsicd = HISMappingService.GetInstance().CheckMappingAndSync(mappingCheck, true).LISID;
                }

                if (!string.IsNullOrEmpty(info.Madonvi))
                {
                    mappingCheck.CategoryID = (int)HisMappingCategory.KhoaPhong;
                    mappingCheck.HISID = info.Madonvi;
                    mappingCheck.ItemName = info.Tendonvi;
                    info.Madonvi = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                }

                if (!string.IsNullOrEmpty(info.Makhoahienthoi))
                {
                    mappingCheck.CategoryID = (int)HisMappingCategory.KhoaPhong;
                    mappingCheck.HISID = info.Makhoahienthoi;
                    mappingCheck.ItemName = info.Tenkhoahienthoi;
                    info.Makhoahienthoi = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                }

                if (!string.IsNullOrEmpty(info.Doituongdichvu))
                {
                    mappingCheck.CategoryID = (int)HisMappingCategory.DoiTuong;
                    mappingCheck.HISID = info.Doituongdichvu;
                    mappingCheck.ItemName = info.Tendoituongdichvu;

                    info.Doituongdichvu = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                }
                if (!string.IsNullOrEmpty(info.Masinhly))
                {
                    mappingCheck.CategoryID = (int)HisMappingCategory.SinhLy;
                    mappingCheck.HISID = info.Masinhly;
                    mappingCheck.ItemName = info.Tensinhly;

                    info.Masinhly = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                }
                if (!string.IsNullOrEmpty(info.Madonvihopdong))
                {
                    mappingCheck.CategoryID = (int)HisMappingCategory.CongTyHopDong;
                    mappingCheck.HISID = info.Madonvihopdong;
                    mappingCheck.ItemName = info.Tendonvihopdong;

                    info.Madonvihopdong = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                }
                if (_iBenhNhanInfo.Insert_BenhNhan_TiepNhan(info, false))
                {
                    if (info.ChiDinh.Where(x => x.IDLoaiXetNghiem.Equals((int)TestType.EnumTestType.ChiDinhTruyenMau)).Any())
                        _iBenhNhanInfo.Insert_BenhNhan_TuMau(info, false);
                    if (info.ChiDinh.Where(x => x.IDLoaiXetNghiem.Equals((int)TestType.EnumTestType.TienSan) || x.IDLoaiXetNghiem.Equals((int)TestType.EnumTestType.SLSS)).Any())
                    {
                        var objSangLoc = new BENHNHAN_MAUSANGLOC() { Matiepnhan = info.Matiepnhan };
                        objSangLoc.Tiensan = info.ChiDinh.Where(x => x.IDLoaiXetNghiem.Equals((int)TestType.EnumTestType.TienSan)).Any();
                        objSangLoc.Sosinh = info.ChiDinh.Where(x => x.IDLoaiXetNghiem.Equals((int)TestType.EnumTestType.SLSS)).Any();
                        if (objSangLoc.Sosinh)
                        {
                            var ten = info.Tenbn.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            objSangLoc.Hotenme = info.Tenbn.Replace(ten[ten.Length - 1], "").Trim();
                            objSangLoc.Tenme = ten[ten.Length - 1];
                            //objSangLoc.Noiguimau = info.Madonvi; //-> Sẽ mặc định khi sửa thông tin
                            objSangLoc.Diachi = info.Diachi;
                            objSangLoc.Dienthoaididong = info.Sdt;
                            objSangLoc.Namsinhme = info.Tuoi;
                            var diachiSplt = info.Diachi.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            //if(diachiSplt.Length>1)
                            //{
                            //    objSangLoc.Matinh = diachiSplt[diachiSplt.Length - 1];
                            //}
                        }
                        if (info.Sinhnhat == null || info.Sinhnhat == DateTime.MinValue)
                            objSangLoc.Ngaysinh = DateTime.Parse("01-01-" + info.Tuoi + "");
                        else
                            objSangLoc.Ngaysinh = (DateTime)info.Sinhnhat;
                        _iBenhNhanInfo.Insert_ThongTinSLSoSinh(objSangLoc);
                    }
                    var chiDinhGPB = info.ChiDinh.Where(x => x.IDLoaiXetNghiem.Equals((int)TestType.EnumTestType.GPB));

                    if (chiDinhGPB.Any())
                    {
                        _iBenhNhanInfo.InsUpdDelAnaPathPatient(info, "I");
                    }
                    if (_iBenhNhanInfo.Insert_BenhNhan_CLS_XetNghiem(info.Matiepnhan))
                        InsertChiDinh(info, ref mess, updateGet, hisConnect, hisFunction);
                }

                if (!string.IsNullOrEmpty(mess))
                {
                    LogService.RecordLogFile(mess);
                    LIS.Common.Controls.CustomMessageBox.MSG_Information_OK(mess);
                }
                return info.Matiepnhan;
            }
            catch (Exception ex)
            {
                ThrowNewException(string.Format("Có lỗi xảy ra khi tiếp nhận bệnh nhân từ HIS, chi tiết: {0}", ex.Message));
                return string.Empty;
            }
        }
        public int SoLuongMau(string matiepnhan, int theoNhom)
        {
            return _itestResult.SoLuongMau(matiepnhan, theoNhom);
        }
        private bool InsertChiDinh(BenhNhanInfoForHIS info, ref string mess, bool updateGet, HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            string logStep = string.Empty;
            var insert = 0;
            try
            {
                var mappingCheck = new HISMapping();
                mappingCheck.HisProviderID = (int)hisConnect.HisID;

                /// logStep = Environment.NewLine + "get Connect db";
                var conn = SqlDbConfigurationBase.GetConnection();
                var sb = new StringBuilder();
                var notmapping = string.Empty;
                var hisInfoparaInfoList = new List<HisParaGetList>();

                bool allowRefreshMapping = true;
                var allow = false;

                // logStep += Environment.NewLine + "Start loop";
                var chidinhHisInfo = new List<ChiDinhHISInfo>();
                var chiDinhLis = new List<XetNghiemHISInfo>();
                var previousBSHis = string.Empty;
                var previousBSLis = string.Empty;
                var previousKhoaHis = string.Empty;
                var previousKhoaLis = string.Empty;
                foreach (var item in info.ChiDinh)
                {
                    // logStep += Environment.NewLine + "Get mapping";
                    var xetnghiem = XetNghiemHISService.GetInstance().GetMapping(item.TestCode, (int)hisConnect.HisID, allowRefreshMapping);
                    allowRefreshMapping = false;
                    if (xetnghiem != null)
                    {
                        if (!string.IsNullOrEmpty(xetnghiem.maxn) || !string.IsNullOrEmpty(xetnghiem.maprofile))
                        {
                            if (xetnghiem.isprofile || !string.IsNullOrEmpty(xetnghiem.maprofile))
                                allow = true;
                            else
                            {
                                // logStep += Environment.NewLine + "get mapping XN";
                                var dmxn = XetNghiemHISService.GetInstance().GetMappingXN(xetnghiem.maxn);
                                //   logStep += Environment.NewLine + "check mã xn";
                                if (dmxn != null)
                                {
                                    if (!string.IsNullOrEmpty(dmxn.maxn))
                                        allow = true;
                                    else
                                    {
                                        allow = false;
                                        notmapping += string.Format("[Mã XN {0} không tồn tại] - {1}", xetnghiem.maxn, item.TestCode);
                                    }
                                }
                                else
                                {
                                    allow = false;
                                    notmapping += string.Format("[Mã XN {0} không tồn tại] - {1}", xetnghiem.maxn, item.TestCode);
                                }
                            }
                            if (allow)
                            {
                                if (!chiDinhLis.Contains(xetnghiem))
                                {
                                    if (!string.IsNullOrEmpty(item.MaBSChiDinh))
                                    {
                                        if (previousBSHis.Equals(item.MaBSChiDinh))
                                        {
                                            item.MaBSChiDinh = previousBSLis;
                                        }
                                        else
                                        {
                                            mappingCheck.CategoryID = (int)HisMappingCategory.NhanVien;
                                            mappingCheck.HISID = item.MaBSChiDinh;
                                            mappingCheck.ItemName = item.TenBSChiDinh;

                                            previousBSHis = item.MaBSChiDinh;
                                            previousBSLis = HISMappingService.GetInstance().CheckMappingAndSync(mappingCheck, false).LISID;
                                            //NhanVienService.GetInstance().SyncNhanVien(item.MaBSChiDinh, item.TenBSChiDinh).MaNhanVien;
                                            item.MaBSChiDinh = previousBSLis;
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(item.MaKhoaChiDinh))
                                    {
                                        if (previousKhoaHis.Equals(item.MaKhoaChiDinh))
                                        {
                                            item.MaKhoaChiDinh = previousKhoaLis;
                                        }
                                        else
                                        {
                                            mappingCheck.CategoryID = (int)HisMappingCategory.KhoaPhong;
                                            mappingCheck.HISID = item.MaKhoaChiDinh;
                                            mappingCheck.ItemName = item.TenKhoaChiDinh;

                                            previousKhoaHis = item.MaKhoaChiDinh;
                                            previousKhoaLis = HISMappingService.GetInstance().CheckMappingAndSync(mappingCheck, false).LISID;
                                            item.MaKhoaChiDinh = previousKhoaLis;
                                        }
                                    }
                                    item.TrangThaiMau = OrderStatus.OrderRecieved;
                                    item.MaXN_His = item.TestCode;

                                    chidinhHisInfo.Add(item);
                                    chiDinhLis.Add(xetnghiem);
                                    var log = string.Format("Add for insert order test: {0}-[{2}|{3}] for sampleid: {1}", item.TestCode, info.Matiepnhan, xetnghiem.maxn, xetnghiem.tendichvu);
                                    LogService.RecordLogFile("GET_HisOrder", log, (new StackTrace()).GetFrame(0).GetMethod().Name);
                                    if (!item.LisAutoAdd)
                                    {
                                        hisInfoparaInfoList.Add(new HisParaGetList()
                                        {
                                            IDChiDinh = item.IdChiTiet,
                                            IDChiDinhDichVu = item.IDDichVuChiDinh,
                                            SoPhieuChiDinh = item.SoPhieuChiDinh,
                                            MaBenhAn = info.Bn_id,
                                            IDGiayto = info.Giayto_id,
                                            MaXetNghiemLIS = item.TestCode,
                                            MaTiepNhanLIS = info.Matiepnhan,
                                            NgayTiepNhan = info.Ngaytiepnhan,
                                            NoiTru = info.Noitru,
                                            TrangThai = (hisConnect.HisID == HisProvider.FPT_SP ? FPTTrangThaiChiDinh.DaCap : 1),
                                            TrangThaiHL7 = OrderStatus.OrderRecieved,
                                            IDBangKe = item.Bangkeid,
                                            TenDichVu = item.TenXN_His,
                                            ThoiGianThucHien = item.Thoigianxacnhan,
                                            IDUserThucHien = item.MaNhanVienThucHien,
                                            IDUserLayMau = item.NguoiLayMauHIS,
                                            ThoiGianLayMau = item.ThoiGianLayMau,
                                            MaDichVu = item.MaXN_His
                                        });
                                    }
                                }
                                else
                                    LogService.RecordLogFile("GET_HisOrder",
                                        string.Format("Order test duplicate: {0}-[{2}|{3}] for sampleid: {1}", item.TestCode, info.Matiepnhan, xetnghiem.maxn, xetnghiem.tendichvu)
                                        , (new StackTrace()).GetFrame(0).GetMethod().Name);
                            }
                        }
                        else
                        {
                            notmapping += string.Format("{0}|", item.TestCode);
                        }
                    }
                    else
                    {
                        notmapping += string.Format("{0} chưa được khai báo trên LIS|", item.TestCode);
                    }
                }
                if (chidinhHisInfo.Count > 0 && chiDinhLis.Count > 0)
                {
                    logStep += Environment.NewLine + string.Format("Start insert test chidinhHisInfoCount: {0} - chiDinhLisCount: {1} item(s)", chidinhHisInfo.Count, chiDinhLis.Count);
                    insert = _itestResult.InsertTestFromHis(info, chidinhHisInfo, chiDinhLis);
                }

                if (updateGet && insert > 0)
                {
                    logStep += Environment.NewLine + "Update allowdown load infinity";
                    _itestResult.UpdateAllowDownload(info.Matiepnhan);
                    logStep += Environment.NewLine + "Update check HIS";
                    //Xử lý lại danh sách nếu là his DH
                    if (hisConnect.HisID == HisProvider.DH_API || hisConnect.HisID == HisProvider.DH_DHG)
                    {
                        var para = hisInfoparaInfoList.GroupBy(x => new { x.SoPhieuChiDinh, x.NgayChiDinh }).Select(g => new { g.Key.SoPhieuChiDinh, g.Key.NgayChiDinh }).ToList();
                        hisInfoparaInfoList = new List<HisParaGetList>();
                        foreach (var item in para)
                        {
                            hisInfoparaInfoList.Add(new HisParaGetList { SoPhieuChiDinh = item.SoPhieuChiDinh, NgayChiDinh = item.NgayChiDinh });
                        }
                        Task.Factory.StartNew(() =>
                        {
                            _iGetHisService.LISCheck(hisConnect, hisFunction, hisInfoparaInfoList);
                        });
                    }
                    else
                    {
                        info.ChiDinh = info.ChiDinh.Where(x => !x.LisAutoAdd).ToList();
                        Task.Factory.StartNew(() =>
                        {
                            LISCheckOrder(hisConnect, hisFunction, info);
                        });
                    }
                }

                if (!string.IsNullOrEmpty(notmapping))
                {
                    mess = string.Format("Các mã xét nghiệm: {0} chưa được mapping", notmapping);
                }
                return insert > 0;
            }
            catch (Exception ex)
            {
                mess = string.Format("Có lỗi xảy ra khi thêm chỉ định, chi tiết {0} -- {1}", logStep, ex.Message);
                LogService.RecordLogFile(mess);
                return insert > 0;
            }
        }
        public HISReturnBase DanhMucHIS(HISParaInfo para, HisConnection hisInfo, List<HisFunctionConfig> hisFunctionMapping)
        {
            var returData = new HISReturnBase();

            if (para == HISParaInfo.XetNghiem)
                returData = _iGetHisService.DanhMucXetNghiem(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.BacSi)
                returData = _iGetHisService.DanhMucBacSi(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.KhoaPhong)
                returData = _iGetHisService.DanhMucKhoaPhong(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.Doituong)
                returData = _iGetHisService.DanhMucDoiTuong(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.ChanDoan)
                returData = _iGetHisService.DanhMucChanDoan(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.MayXN)
                returData = _iGetHisService.DanhMucMayXN(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.Phong)
                returData = _iGetHisService.DanhMucPhong(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.DonViGuiMau)
                returData = _iGetHisService.DanhSachGuiMauDi(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.SinhLy)
                returData = _iGetHisService.DanhMucSinhLy(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.CongtyHopDong)
                returData = _iGetHisService.DanhMucCongTyHopDong(hisInfo, hisFunctionMapping);
            else if (para == HISParaInfo.LoaiMau)
                returData = _iGetHisService.DanhMucLoaiMau(hisInfo, hisFunctionMapping);
            if (returData.Data != null)
            {
                foreach (DataColumn c in returData.Data.Columns)
                {
                    c.ColumnName = c.ColumnName.ToLower();
                }
            }
            return returData;
        }
        public HISReturnBase GetPatientOrderedList(HisConnection hisInfo, List<HisFunctionConfig> hisFunctionMapping, HisParaGetList paraInfo, HISDataColumnNames hColumnName)
        {
            var returData = _iGetHisService.GetPatientOrderedList(hisInfo, hisFunctionMapping, paraInfo);
            if (returData.Data != null)
            {
                foreach (DataColumn c in returData.Data.Columns)
                {
                    c.ColumnName = c.ColumnName.ToLower();
                }
            }
            return returData;

        }
        public HISReturnBase GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList)
        {
            return _iGetHisService.GetPatientInformationDetail(hisConnect, hisFunction, paraInfoList);
        }
        public HISReturnBase Get_BsLayMauThuThuat(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iGetHisService.Get_BsLayMauThuThuat(hisConnect, hisFunction, paraInfoList);
        }
        public HISReturnBase Get_ViTriLayMauPAP(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iGetHisService.Get_ViTriLayMauPAP(hisConnect, hisFunction, paraInfoList);
        }
        public HISReturnBase GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, List<HISDataColumnNames> hisColumns
            , bool onlyNotGet = false, HISDataColumnNames hColumnName = null, DataTable mappingData = null)
        {
            var hColumnNames = _iGetHisService.GetHisColumnNameConfiguartion(hisConnect, hisColumns);
            var returData = _iGetHisService.GetPatientOrderedDetail(hisConnect, hisFunction, paraInfo);
            if (returData.Data != null)
            {
                var xetnghiem = XetNghiemHISService.GetInstance().GetData_HisMapping_All(true);
                if (paraInfo.IDNhomXN != TestGroup.ALL)
                {
                    if (returData.Data.Rows.Count > 0)
                    {
                        var data = (from order in returData.Data.AsEnumerable()
                                    join dmxn in xetnghiem.AsEnumerable() on order.Field<string>(hColumnNames.chidinhMadichvu) equals dmxn.Field<string>("madichvu")
                                    where dmxn.Field<string>("nhomxn") == paraInfo.MaNhom
                                    select order);
                        if (data != null)
                        {
                            if (data.Count() > 0)
                            {
                                returData.Data = data.CopyToDataTable();
                            }
                            else
                            {
                                returData.Data = returData.Data.Clone();
                            }
                        }
                        else
                        {
                            returData.Data = returData.Data.Clone();
                        }
                    }
                }

                if (returData.Data.Rows.Count > 0)
                {
                    if (onlyNotGet)
                    {
                        var conn = SqlDbConfigurationBase.GetConnection();
                        var tb = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChinhDinh_DaLayTu_HIS", new SqlParameter[]
                        {
                        new SqlParameter("@ngaydk", paraInfo.NgayChiDinh.Value.Date),
                        new SqlParameter("@SoPhieuYeuCau", paraInfo.SoPhieuChiDinh),
                        }).Tables[0];
                        if (tb.Rows.Count > 0)
                        {
                            List<string> s = tb.AsEnumerable().Select(x => x["maxn_his"].ToString()).ToList();
                            //var d = from c in tb.AsEnumerable() select c.Field<string>("maxn_his");
                            var tbn = returData.Data.AsEnumerable().Where(r => !s.Contains(r.Field<string>(hColumnNames.chidinhMadichvu)));
                            if (tbn != null)
                            {
                                if (tbn.Count() > 0)
                                {
                                    returData.Data = tbn.CopyToDataTable();
                                }
                                else
                                {
                                    returData.Data = returData.Data.Clone();
                                }
                            }
                        }
                    }
                }
                returData.Data = MergeMappingLIS(returData.Data, hColumnName, (int)hisConnect.HisID, mappingData);
                foreach (DataColumn c in returData.Data.Columns)
                {
                    c.ColumnName = c.ColumnName.ToLower();
                }
            }
            return returData;
        }
        public DataTable MergeMappingLIS(DataTable dataSource, HISDataColumnNames hColumnName, int hisproviderID, DataTable mappingData = null)
        {
            if (!string.IsNullOrEmpty(hColumnName.chidinhMadichvu))
            {
                if (dataSource.Columns.Contains(hColumnName.chidinhMadichvu))
                {
                    if (!dataSource.Columns.Contains("madichvulis"))
                        dataSource.Columns.Add("madichvulis", typeof(string));
                    if (!dataSource.Columns.Contains("maprofilelis"))
                        dataSource.Columns.Add("maprofilelis", typeof(string));
                    if (!dataSource.Columns.Contains("loaidichvulis"))
                        dataSource.Columns.Add("loaidichvulis", typeof(string));
                    if (!dataSource.Columns.Contains("loaixetnghiemlis"))
                        dataSource.Columns.Add("loaixetnghiemlis", typeof(string));
                    if (!dataSource.Columns.Contains("tennhomcls"))
                        dataSource.Columns.Add("tennhomcls", typeof(string));
                    if (!dataSource.Columns.Contains("thutuin"))
                        dataSource.Columns.Add("thutuin", typeof(int));
                    if (!dataSource.Columns.Contains("sapxep"))
                        dataSource.Columns.Add("sapxep", typeof(int));
                    if (!dataSource.Columns.Contains("trangthaichidinh"))
                        dataSource.Columns.Add("trangthaichidinh", typeof(string));
                    if (!dataSource.Columns.Contains("liscode"))
                        dataSource.Columns.Add("liscode", typeof(string));

                    if (dataSource.Rows.Count > 0)
                    {
                        var dataMapping = new DataTable();
                        if (mappingData == null)
                            dataMapping = DataMapping(hisproviderID);
                        else
                            dataMapping = mappingData;

                        foreach (DataRow drH in dataSource.Rows)
                        {
                            string filter = string.Format("MaDichVu = '{0}'", drH[hColumnName.chidinhMadichvu].ToString());
                            if (!string.IsNullOrEmpty(hColumnName.chidinhidDichvuchidinhcaptren) && hisproviderID != (int)HisProvider.DH_API)
                            {
                                var macaptren = drH[hColumnName.chidinhidDichvuchidinhcaptren].ToString();
                                if (!string.IsNullOrEmpty(macaptren))
                                {
                                    filter += string.Format(" and macaptren = '{0}'", macaptren);
                                }
                            }
                            var dataFind = WorkingServices.SearchResult_OnDatatable_NoneSort(dataMapping, filter);
                            if (dataFind.Rows.Count > 0)
                            {
                                var maXNLis = dataFind.Rows[0]["MaXN"].ToString();
                                var maProfileLis = dataFind.Rows[0]["ProfileID"].ToString();
                                if (!string.IsNullOrEmpty(hColumnName.chidinhBarcodexn))
                                {
                                    drH["liscode"] = drH[hColumnName.chidinhBarcodexn];
                                }
                                if (string.IsNullOrEmpty(maXNLis) && string.IsNullOrEmpty(maProfileLis))
                                {
                                    drH["tennhomcls"] = "[A] - MÃ XN MAPPING SAI HOẶC BỊ THAY ĐỔI";
                                    drH["thutuin"] = 0;
                                    drH["sapxep"] = 0;
                                    drH["madichvulis"] = dataFind.Rows[0]["lis_id"];
                                    drH["maprofilelis"] = dataFind.Rows[0]["lis_profileid"];
                                    drH["loaidichvulis"] = dataFind.Rows[0]["loaixn"];
                                    drH["loaixetnghiemlis"] = 0;
                                }
                                else
                                {
                                    drH["madichvulis"] = dataFind.Rows[0]["lis_id"];
                                    drH["maprofilelis"] = dataFind.Rows[0]["lis_profileid"];
                                    drH["loaidichvulis"] = dataFind.Rows[0]["loaixn"];

                                    drH["tennhomcls"] = dataFind.Rows[0]["TenNhomCLS"];
                                    drH["thutuin"] = int.Parse(dataFind.Rows[0]["ThuTuIn"].ToString()) + 2;
                                    drH["sapxep"] = dataFind.Rows[0]["SapXep"];
                                    drH["loaixetnghiemlis"] = dataFind.Rows[0]["loaixetnghiem"];
                                }
                            }
                            else
                            {
                                drH["tennhomcls"] = "[A] - CHƯA MAPPING MÃ";
                                drH["thutuin"] = 1;
                                drH["sapxep"] = 0;
                                drH["loaixetnghiemlis"] = 0;
                            }
                        }

                        dataSource.AcceptChanges();
                        dataSource.DefaultView.Sort = "thutuin,tennhomcls,sapxep asc";
                        dataSource = dataSource.DefaultView.ToTable();
                    }
                }
            }
            foreach (DataColumn c in dataSource.Columns)
            {
                c.ColumnName = c.ColumnName.ToLower();
            }
            return dataSource;
        }
        public DataTable DataMapping(int hisproviderID)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMucXn_MappingHis", new SqlParameter[]
                    {
                        new SqlParameter("@hisProviderID", hisproviderID)
                    }).Tables[0];
        }
        public string InsertPatientFromHIS(BenhNhanInfoForHIS lisInfo, bool updateGet, HisConnection hisConnect
            , List<HisFunctionConfig> hisFunction, bool useHISBarcode)
        {
            return InsertBenhNhan(lisInfo, updateGet, hisConnect, hisFunction, useHISBarcode);
        }
        public int LISCheckOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info)
        {
            var hisInfo = new List<HisParaGetList>();
            var trangThaiHL7 = string.Empty;
            foreach (var item in info.ChiDinh)
            {
                var HisParaGetList = new HisParaGetList
                {
                    IDChiDinh = item.IdChiTiet,
                    IDChiDinhDichVu = item.IDDichVuChiDinh,
                    SoPhieuChiDinh = item.SoPhieuChiDinh,
                    MaBenhAn = info.Bn_id,
                    IDGiayto = info.Giayto_id,
                    MaXetNghiemLIS = item.TestCode,
                    MaTiepNhanLIS = info.Matiepnhan,
                    NgayTiepNhan = info.Ngaytiepnhan,
                    ThoiGianNhapBN = info.Thoigiannhap,
                    NgayChiDinh = item.Thoigiangui,
                    NoiTru = info.Noitru,
                    TrangThai = (hisConnect.HisID == HisProvider.FPT_SP ?
                      (item.TrangThaiMau == OrderStatus.OrderRecieved ? FPTTrangThaiChiDinh.DaCap : FPTTrangThaiChiDinh.ChuaCap) :
                      (item.TrangThaiMau == OrderStatus.OrderRecieved || item.TrangThaiMau == OrderStatus.SampleCollect ? (hisConnect.HisID == HisProvider.ERecord_API ? 10 : 1) : 0)),
                    TrangThaiHL7 = item.TrangThaiMau,
                    TenDichVu = item.TenXN_His,
                    IDUserThucHien = item.MaNhanVienThucHien,
                    ThoiGianThucHien = item.Thoigianxacnhan,
                    IDUserLayMau = item.NguoiLayMauHIS,
                    ThoiGianLayMau = item.ThoiGianLayMau,
                    MaDichVu = item.MaXN_His
                };
                if (!hisInfo.Where(x => x.Equals(HisParaGetList)).Any())
                {
                    hisInfo.Add(HisParaGetList);
                }
            }
            if (hisConnect.HisID == HisProvider.ISofH)
            {

                var bnInfo = GetDataUploadToHIS(new GetUploadCondit
                {
                    userID = "Uploader",
                    matiepnhan = info.Matiepnhan,
                    onlyValid = false,
                    onlyPrinted = false,
                    arrCatePrint = null,
                    arrtestCodePrint = null,
                    arrTestTypeID = new string[] { },
                    frombackup = false,
                    manualUpload = true,
                    forStatus = true
                });

                //null khi chỉ định đã bị xóa => trường hợp này truyền đủ thông tin từ form delete để xừ lý 
                // != null thì chỉ lấy lại danh sách theo list cần xử lý
                if (bnInfo != null)
                {
                    var arrAction = info.ChiDinh.Select(x => x.TestCode).ToArray();
                    var lst = bnInfo.ChiDinh.Where(x => arrAction.Where(y => y.Equals(x.TestCode)).Any());
                    if (lst.Any())
                        info.ChiDinh = lst.ToList();
                }
                var resultBaseList = GetUploadResultInfo(hisConnect, info);
                //Xử lý bỏ xn cha ra khỏi danh sách.
                //Lấy danh sách xn cha.
                var lsCha = resultBaseList.Where(x => !string.IsNullOrEmpty(x.MaDichVuChaHIS));
                if (lsCha.Any())
                {
                    var lstMaCha = from p in lsCha group p.MaDichVuChaHIS by p.MaDichVuChaHIS into g select new { MaDichVuChaHIS = g.Key };
                    resultBaseList = resultBaseList.Where(x => !(lstMaCha.Where(c => c.MaDichVuChaHIS.Equals(x.MaDichVuHIS)).Any())).ToList();
                }
                ////Xử lý lấy user tương ứng với từng loại trạng thái 
                //foreach (var itmPara in resultBaseList)
                //{
                //    if(trangThaiHL7 == OrderStatus.SampleCollect)
                //    {
                //        itmPara.MaNhanVienChiDinh = itmPara.LIS_MaNguoiLayMau;
                //        itmPara.HISMaBSChiDinh = itmPara.LIS_MaNguoiLayMau;
                //        itmPara.TenBSChiDinh = itmPara.LIS_NguoiLayMau;
                //    }
                //    else if(trangThaiHL7 == OrderStatus.SampleGet)
                //    {
                //        itmPara.MaNhanVienChiDinh = itmPara.LIS_MaNguoiNhanMau;
                //        itmPara.HISMaBSChiDinh = itmPara.LIS_MaNguoiNhanMau;
                //        itmPara.TenBSChiDinh = itmPara.LIS_NguoiNhanMau;
                //    }
                //}
                return _iGetHisService.LISCheckHL7(hisConnect, hisFunction, hisInfo, resultBaseList);
            }
            else
                return _iGetHisService.LISCheck(hisConnect, hisFunction, hisInfo);
        }
        public HISReturnBase Update_HuyKetQua(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iGetHisService.Update_HuyKetQua(hisConnect, hisFunction, paraInfoList);
        }
        public int LISTransferResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info)
        {
            var excute = 0;
            try
            {
                string log = "";
                var hisInfo = new DaiHocCanTho_OrderInfo { SoPhieuYeuCau = info.Sophieuyeucau };
                //Kiểm tra nếu nội trú thì trả theo BANGKE_ID, BANGKE_CHIPHI_ID 
                //Ngoại trú trả theo CLS_CHIDINH_ID, CLS_CHIDINH_CHITIET_CLS_ID
                //Nội trú mã bắt đầu là số 2
                //Nội trú mã bắt đầu là số 1
                var resultReturn = new List<HisResultBase>();
                if (hisConnect.HisID == HisProvider.DHCanTho)
                {
                    foreach (var i in info.ChiDinh)
                    {
                        //  Logger.DebugFormat("Bangkeid {0}", i.Bangkeid);
                        //  Logger.DebugFormat("IDDichVuChiDinh {0}", i.IDDichVuChiDinh);
                        var returnObj = new DaiHocCanTho_ResultInfo();
                        returnObj.CLS_SOPHIEU = i.SoPhieuChiDinh;
                        if (returnObj.CLS_SOPHIEU.Trim()[0] == '1')
                        {
                            returnObj.CLS_CHIDINH_ID = int.Parse(i.Bangkeid);

                            returnObj.CLS_CHIDINH_CHITIET_CLS_ID = int.Parse(i.IDDichVuChiDinh);
                        }
                        else
                        {
                            returnObj.BANGKE_ID = int.Parse(i.Bangkeid);
                            returnObj.BANGKE_CHIPHI_ID = int.Parse(i.IDDichVuChiDinh);
                        }
                        if (WorkingServices.IsNumeric(i.IDBenh))
                            returnObj.IDBENH = int.Parse(i.IDBenh);
                        returnObj.IDNHOMCHUCNANGCLS = int.Parse(i.Idnhomchucnangcls);
                        returnObj.IDLOAICHUCNANGCLS = int.Parse(i.Idloaichucnangcls);
                        returnObj.CLS_TENLOAICLS = i.TestName;
                        returnObj.CLS_KQ_NGAYLAP = i.DateTimeResult;
                        returnObj.IDNHOMNOIDUNGCLS = -1;// cái này select từ danh mục nó ra luôn
                        returnObj.IDNOIDUNGCLS = int.Parse(i.TestCode);
                        returnObj.KETQUA1 = WorkingServices.IsNumeric(i.Result) ? double.Parse(i.Result).ToString("0.###").Replace(".", ",") : "";
                        returnObj.KETQUA2 = "";
                        returnObj.KETQUA3 = WorkingServices.IsNumeric(i.Result) ? "" : i.Result;
                        returnObj.CreatedDate = DateTime.Now;
                        hisInfo.resultInfo.Add(returnObj);
                    }
                }
                else
                {
                    resultReturn = GetUploadResultInfo(hisConnect, info);
                    var masophieuCurrent = string.Empty;
                    var dataCheck = new DataTable();

                    if (hisConnect.HisID == HisProvider.DH_DHG || hisConnect.HisID == HisProvider.DH_API)
                    {
                        foreach (var i in resultReturn)
                        {
                            if (!masophieuCurrent.Equals(i.SoPhieuYeuCau))
                            {
                                masophieuCurrent = i.SoPhieuYeuCau;
                                if (hisConnect.HisID == HisProvider.DH_API)
                                {
                                    var obj = _iGetHisService.GetPatientOrderedDetail(hisConnect, hisFunction,
                                        new HisParaGetList { SoPhieuChiDinh = i.MaBN, NgayChiDinh = i.NgayChiDinh });
                                    if (obj.Code == 100)
                                        dataCheck = null;
                                    else
                                        dataCheck = obj.Data;
                                }
                                else
                                {
                                    dataCheck = _iGetHisService.GetPatientOrderedDetail(hisConnect, hisFunction,
                                        new HisParaGetList { SoPhieuChiDinh = i.SoPhieuYeuCau }).Data;
                                }
                            }
                            if (dataCheck != null)
                            {
                                if (dataCheck.Rows.Count > 0)
                                {
                                    var findR = WorkingServices.SearchResult_OnDatatable_NoneSort(dataCheck, string.Format("{0} = '{1}' and {2} = '{3}'", "idqr", i.IdChiTiet_HIS, "sophieuyeucau", masophieuCurrent));
                                    if (findR.Rows.Count > 0)
                                    {
                                        var giochiDinh = DateTime.Parse(findR.Rows[0]["ngaychidinh"].ToString());
                                        if (giochiDinh != i.NgayChiDinh.Value)
                                        {
                                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format("-->Thời gian chỉ định [{2}] không khớp: Dữ liệu {0} - His {1}", i.NgayChiDinh.Value.ToString("yyyy-MM-dd HH:mm:ss"), giochiDinh.ToString("yyyy-MM-dd HH:mm:ss"), i.TenXetNghiem_Lis));
                                            if (UpdateThoiGianChiDinh(i.MaSoXetNghiem, i.MaXetNghiemLIS, giochiDinh) > -1)
                                            {
                                                i.NgayChiDinh = giochiDinh;
                                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format("-->Cập nhật thời gian chỉ định: {0}", giochiDinh.ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                var lstNotFinishList = new List<string>();
                var iE = _iGetHisService.TransferResultToHIS(hisConnect, hisFunction, resultReturn, ref lstNotFinishList);
                excute += (hisConnect.DbType == DBConnectType.POSTGRE ? 1 : iE);
                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Excute count: {0}", excute));
                if (excute > -1)
                {
                    if (lstNotFinishList.Count > 0)
                    {
                        LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format(" DS upload lỗi: {0}", lstNotFinishList.Count));
                        foreach (var itmMaXN in lstNotFinishList)
                        {
                            for (int item = info.ChiDinh.Count - 1; item >= 0; item--)
                            {
                                if (info.ChiDinh[item].MaXN.Trim().Equals(itmMaXN.Trim(), StringComparison.OrdinalIgnoreCase))
                                {
                                    LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format(" Loại trừ DS upload lỗi: {0}", itmMaXN));
                                    info.ChiDinh.RemoveAt(item);
                                    break;
                                }
                            }
                        }
                        LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format(" Insert trở lại danh sách upload: {0}", info.Matiepnhan));
                        ReInsertUploadList(info.Matiepnhan);
                    }
                    if (info.ChiDinh.Count > 0)
                    {
                        LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format("Update trạng thái\n - SID: {0} -Số phiếu: {1}", info.Matiepnhan, info.Sophieuyeucau));
                        int count = 0;
                        count += UpdateLISTransferResult(info);
                        LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format(" - Tổng số record update: {0}", count));
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogError("HISUploader", "UploadHIS", ex, 0, ex.Message,
                    "LISTransferResult");
            }
            return excute;
        }
        public int UploadFileToHis(HisConnection hisConnect, List<HisFunctionConfig> hisFunction
            , BenhNhanInfoForHIS info, bool fromAuto = false)
        {
            int iCount = -1;
            var conn = SqlDbConfigurationBase.GetConnection();
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuKySo_DanhSachUpload",
                  new SqlParameter[]
                  {
                        new SqlParameter("@MaTiepNhan",(info == null ?string.Empty:  info.Matiepnhan)),
                        new SqlParameter("@FromAuto", fromAuto)
                  }
              ).Tables[0];
            if (data.Rows.Count > 0)
            {
                var lstUpload = new List<HisResultBase>();
                // ID, MaTiepNhan, MaHoSo, MaBn, SoPhieu, NgayTaoPhieu, TrangThai
                //, nv.his_id as UserKy, LoaiKy, NgayKy, LanKy, PdfFileID, DaUpLoad
                //, ThoiGianUpload, SoLanUpLoad, PDFContent, MoTa, LanKQ, isnull(LoaiPhieu, '9999999') as LoaiPhieu
                foreach (DataRow dr in data.Rows)
                {
                    var objKySo = (THONGTINFILEKY)WorkingServices.Get_InfoForObject(new THONGTINFILEKY(), dr);

                    var arr = (objKySo.MoTa ?? String.Empty).Split('^');
                    // var fileData = (byte[])dr["PDFContent"];
                    var objreturn = new HisResultBase();
                    objreturn.PdfIdTraKetQua = objKySo.Id.ToString();
                    objreturn.PDFBase64String = Convert.ToBase64String(objKySo.Pdfcontent, 0, objKySo.Pdfcontent.Length);
                    objreturn.PdfSoPhieuYeuCau = objKySo.SoPhieuChiDinh;
                    objreturn.PdfMaBN = objKySo.Mabn;
                    objreturn.PdfMaBA = objKySo.Mahoso;
                    objreturn.PdfSoPhieuKetQua = objKySo.Matiepnhan;
                    objreturn.PdfId = objKySo.Pdffileid;
                    objreturn.PdfLstIdDichVu = arr.ToList();
                    objreturn.PdfFormID = objKySo.LoaiPhieu;
                    objreturn.PdfLanKy = objKySo.Lanky;
                    objreturn.PdfLoaiKy = objKySo.Loaiky;
                    objreturn.PdfLoaiXetNghiem = objKySo.LoaiXetNghiem.ToString();
                    objreturn.PdfMoTa = objKySo.MoTa;
                    objreturn.PdfNguoiKy = objKySo.Userky;
                    objreturn.PdfSophieu = objKySo.Sophieu;
                    objreturn.PdfTenFileHIS = objKySo.TenFileHIS;
                    objreturn.PdfTenFileLIS = objKySo.TenFileLIS;

                    lstUpload.Add(objreturn);
                }
                if (_iGetHisService.UploadFileToHis(hisConnect, hisFunction, lstUpload) > 0)
                {
                    foreach (var item in lstUpload)
                    {
                        iCount += UpdateFileUploaded(int.Parse(item.PdfIdTraKetQua));
                    }
                }
            }
            return iCount;
        }
        public int UpdateFileUploaded(int id)
        {
            var i = 0;
            var conn = SqlDbConfigurationBase.GetConnection();
            i += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updChuKySo_CapNhatDaUpload",
                new SqlParameter[]
                {
                        new SqlParameter("@ID", id)
                }
            );
            return i;
        }
        public int UploadValidResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HISResultValid> paraInfoList)
        {
            return _iGetHisService.UploadValidResult(hisConnect, hisFunction, paraInfoList);
        }
        public void AddDataAntibiotic(ref HisResultBase mainResult, HisProvider HisID)
        {
            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", HisID.ToString()), string.Format("Lấy thông tin kết quả kháng sinh đồ: {0}", mainResult.MaSoXetNghiem));
            var conn = SqlDbConfigurationBase.GetConnection();
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selResult_AntiBiotic_UploadHis",
                  new SqlParameter[]
                  {
                        new SqlParameter("@MaTiepNhan", mainResult.MaSoXetNghiem),
                        new SqlParameter("@MaYeuCau", mainResult.MaXetNghiemLIS)
                  }
              ).Tables[0];
            var lstResturn = new List<HisResultBase>();
            var item = new HisResultBase();

            if (data.Rows.Count > 0)
            {
                //kết quả kháng sinh đồ
                //MaViKhuan
                //TenViKhuan 
                //MaKhangSinh 
                //TenKhangSinh 
                //KetQuaSRI 
                //TenKhangKhangSinh 
                //KetQuaKhangKhangSinh 
                //TenVaKetQuaKhangKhangSinh 

                foreach (DataRow dr in data.Rows)
                {
                    item = new HisResultBase();
                    item = mainResult.Copy();
                    item.MaViKhuan = dr["MaPhanLoai"].ToString();
                    item.TenViKhuan = dr["TenPhanLoai"].ToString();
                    item.MaKhangSinh = dr["MaKhangSinh"].ToString();
                    item.TenKhangSinh = dr["TenKhangSinh"].ToString();
                    item.KyThuatKSD = dr["KyThuat"].ToString();
                    item.BenhPham = dr["BenhPham"].ToString();
                    item.KetQuaSRI = dr["KetQuaSRI"].ToString().Trim();
                    item.KetQuaDinhLuong = dr["KetQuaDinhLuong"].ToString();
                    item.TenVaKetQuaKhangKhangSinh = dr["KetQuaKhangKS"].ToString();
                    item.NgayCoKetQua = (string.IsNullOrEmpty(dr["GioNhap"].ToString()) ? item.NgayCoKetQua : DateTime.Parse(dr["GioNhap"].ToString()));// thoigiancokq
                    lstResturn.Add(item);
                }
                mainResult.lstKetQuaKhangSinh = lstResturn;
            }
        }
        public int UpdateThoiGianChiDinh(string matiepnhan, string maxn, DateTime thoigianchidinh)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            var sql = string.Format("update ketqua_cls_xetnghiem set thoigianchidinhhis = '{0}' where matiepnhan = '{1}' and maxn = '{2}'", thoigianchidinh.ToString("yyyy-MM-dd HH:mm:ss"), matiepnhan, maxn);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sql);
        }
        public int UpdateLISTransferResult(BenhNhanInfoForHIS info)
        {
            var i = 0;
            var conn = SqlDbConfigurationBase.GetConnection();
            if (info.ChiDinh.Count <= 0) return i;
            var maxXnList = Utilities.ConvertStrinArryToInClauseSQLForSplitString(info.ChiDinh.Select(x => x.MaXN).ToList<string>(), "|");
            i += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updUploadResultToHIS",
                new SqlParameter[]
                {
                        new SqlParameter("@maTiepNhan", info.Matiepnhan),
                        new SqlParameter("@maxn", maxXnList),
                        new SqlParameter("@usertransfer", info.userTransfer)
                }
            );

            return i;
        }
        public DataTable DataUploadToHisList(string matiepnhan, bool daxacnhan, bool dain)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDataUploadHIS_PatientList",
                  new SqlParameter[]
                  {
                        new SqlParameter("@daxacnhan", daxacnhan),
                        new SqlParameter("@dain", dain),
                        new SqlParameter("@maTiepNhan", matiepnhan)
                  }
              ).Tables[0];
        }
        public bool ReInsertUploadList(string maTiepNhan)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insInsert_UploadList",
                new SqlParameter[]
                {
                   new SqlParameter("@maTiepNhan", maTiepNhan)
                }
            ) > -1;
        }
        public List<HisResultBase> GetUploadResultInfo(HisConnection hisConnect, BenhNhanInfoForHIS info)
        {
            var resultReturn = new List<HisResultBase>();
            foreach (var i in info.ChiDinh)
            {
                var objThongTinXacNhan = new HISResultValid
                {
                    TrangThaiXacNhanKhoa = true,
                    LyDoBoXacNhanKhoa = i.LyDoBoXacNhanKhoa,
                    IDKhoaXetNghiem = i.IDKhoaXetNghiem,
                    ThoiGianXacNhanKhoa = i.Thoigianxacnhan,
                    NguoiXacNhanKhoa = i.MaNhanVienThucHien,
                    SoHoSo = i.SoHoSo,
                    SoPhieuChiDinh = i.SoPhieuChiDinh
                };

                var objreturn = new HisResultBase();
                objreturn.NgayTiepNhan = info.Ngaytiepnhan;
                objreturn.Barcode = i.Barcode;
                objreturn.BatThuong = i.Abnormal ? 1 : 0;
                objreturn.BatThuongBool = i.Abnormal;
                objreturn.BatThuongLech = (i.AbnormalFlag == 2 ? 1 : (i.AbnormalFlag == 3 ? 2 : 0));
                objreturn.BatThuongHL7 = (i.AbnormalFlag == 2 ? "L" : (i.AbnormalFlag == 3 ? "H" : "N"));
                objreturn.ChiSoBinhThuong = (hisConnect.HisID == HisProvider.HangMinh
                    ? Utilities.ConvertStringText(i.NormalRange, 1, 2)
                    : i.NormalRange);
                objreturn.CanTren = i.CanTren;
                objreturn.CanDuoi = i.CanDuoi;
                objreturn.CanDuoiCanhBao = i.CanDuoiWarning;
                objreturn.CanTrenCanhBao = i.CanTrenWarning;
                objreturn.BatThuongCanhBao = i.AbnormalWarning ? 1 : 0;
                objreturn.IDDichVuHIS = i.IDDichVuChiDinh;
                objreturn.IdTraKetQua = null;
                objreturn.KetLuan = i.KetLuan ?? "";
                objreturn.KetQua = (hisConnect.HisID == HisProvider.HangMinh
                    ? Utilities.ConvertStringText(i.Result, 1, 2)
                    : i.Result);
                objreturn.DonViTinh = (hisConnect.HisID == HisProvider.HangMinh
                    ? Utilities.ConvertStringText(i.Unit, 1, 2)
                    : i.Unit);
                objreturn.KetQuaDinhLuong = i.ResultQualitative;
                objreturn.KetQuaDinTinh = i.ResultQualitative;
                objreturn.MaBacSiKetLuan = i.BSKetLuan;
                objreturn.MaBN = i.MaBN;
                objreturn.MaDichVuChaHIS = (hisConnect.HisID == HisProvider.ISofH && i.MaXNCha_His.Equals(i.MaXN_His) ? String.Empty : i.MaXNCha_His);
                objreturn.MaDichVuHIS = i.MaXN_His;
                objreturn.TenDichVuHIS = i.TenXN_His;
                objreturn.MaLoaiDichVu = i.MaLoaiXN_His;
                objreturn.MaNhanVienChiDinh = i.MaNhanVienChiDinh;
                objreturn.MaNhanVienThucHien = i.MaNhanVienThucHien;
                objreturn.MaNhomXetNghiem = i.MaNhomXN;
                objreturn.MaSoXetNghiem = i.SoPKQ;
                objreturn.MaXetNghiemChaLIS = i.MaXnChaLIS;
                objreturn.MaXetNghiemLIS = i.MaXN;
                objreturn.NamKeToan = i.Namkt;
                objreturn.ThangKeToan = i.Thangkt;
                objreturn.NgayChiDinh = i.Thoigiangui;
                objreturn.NgayCoKetQua = i.DateTimeResult;
                objreturn.SoPhieuYeuCau = i.SoPhieuChiDinh;
                objreturn.TenNhomXetNghiem = i.TenNhomXetNghiem;
                objreturn.TenXetNghiem_Lis = (hisConnect.HisID == HisProvider.HangMinh ? Utilities.ConvertStringText(i.TestName, 1, 2) : i.TestName);
                objreturn.TenXetNghiemChaLIS = i.TenXNChaLis;
                objreturn.IDMayXN = int.Parse(i.IDMayXn ?? "0");
                objreturn.MaKhoaCLS = string.Empty;
                objreturn.UserUpload = i.User;
                objreturn.IDMayXnBHYT = i.IDMayXnBHYT;
                objreturn.IDMayXNHIS = i.IDMayXnHIS;
                objreturn.ThoiGianTiepNhan = i.Thoigiantiepnhan;
                objreturn.NgayInKetQualanDau = i.Thoigianinlandau;
                objreturn.NgayXacNhanKetQua = i.Thoigianxacnhan;
                objreturn.SoTTHIS = (i.STT == null ? string.Empty : (i.STT.Value.ToString() == "0" ? string.Empty : i.STT.Value.ToString()));
                objreturn.QuyTrinhPPXN = i.QuyTrinhPPXN;
                objreturn.TenMayXn = i.TenMayXN;
                objreturn.KetQuaMaXnMay = i.MaXNMay;
                objreturn.LowHighAlarm = i.LowHighAlarm;
                objreturn.LoaiXetNghiem = i.LoaiXetNghiem;
                objreturn.IdChiTiet_HIS = i.IdChiTiet;
                objreturn.SapXepNhom = i.SapXepNhom;
                objreturn.SapXepXetNghiem = i.SapXepXetNghiem;
                objreturn.GhichuXN = i.GhiChuXN;
                objreturn.ThoiGianLayMau = i.ThoiGianLayMau;
                objreturn.ThoiGianNhanMau = i.ThoiGianNhanMau;
                objreturn.LIS_MaNguoiTiepNhan = i.MaNguoiTiepNhan;
                objreturn.LIS_NguoiTiepNhan = i.NguoiTiepNhan;
                objreturn.LIS_MaNguoiLayMau = i.MaNguoiLayMau;
                objreturn.LIS_NguoiLayMau = i.NguoiLayMau;
                objreturn.LIS_MaNguoiNhanMau = i.MaNguoiNhanMau;
                objreturn.LIS_NguoiDuyetKetQua = i.NguoiDuyetKetQua;
                objreturn.LIS_MaNguoiDuyetKetQua = i.MaNguoiDuyetKetQua;
                objreturn.LIS_NguoiNhanMau = i.NguoiNhanMau;
                objreturn.LIS_MaLoaiMau = i.MaLoaiMau;
                objreturn.LIS_TenLoaiMau = i.TenLoaiMau;
                objreturn.HIS_NguoiLayMau = i.NguoiLayMauHIS;
                objreturn.HIS_NguoiNhanMau = i.NguoiNhanMauHIS;
                objreturn.LIS_LanInKQ = i.LanInCuaXN;
                objreturn.LIS_TinhTrangMau = i.TinhTrangMau;
                objreturn.MaBA = i.SoHoSo;
                objreturn.XNChinh = i.XNChinh;
                objreturn.TenBenhNhan = info.Tenbn;
                objreturn.HISMaBSChiDinh = info.Bacsicd;
                objreturn.TenBSChiDinh = info.Tenbacsichidinh;
                objreturn.HISMaKhoaChiDinh = info.Madonvi;
                objreturn.TenKhoaChiDinh = info.Tendonvi;
                objreturn.NamSinh = info.Tuoi.ToString();
                objreturn.GioiTinh = info.Gioitinh;
                objreturn.SinhNhat = info.Sinhnhat ?? DateTime.Now;
                objreturn.NoiTru = info.Noitru;
                objreturn.IDGiayto = info.IDGiayto;
                objreturn.NoiTruChar = (info.Noitru ? "I" : "O");
                objreturn.ThongTinXacNhanKhoa = objThongTinXacNhan;

                resultReturn.Add(objreturn);
                if ((i.LoaiXetNghiem ?? String.Empty).Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                    AddDataAntibiotic(ref objreturn, hisConnect.HisID);
            }
            return resultReturn;
        }

        public BenhNhanInfoForHIS GetDataUploadToHIS(GetUploadCondit uploadCondit)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            DataTable dtData = new DataTable();
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDataUploadHIS_Result",
                new SqlParameter[]
                {
                        new SqlParameter("@maTiepNhan", uploadCondit.matiepnhan),
                        new SqlParameter("@daxacnhan",uploadCondit.onlyValid),
                        new SqlParameter("@dain", uploadCondit.onlyPrinted),
                        new SqlParameter("@manhomclsList", Utilities.ConvertStrinArryToInClauseSQL(uploadCondit.arrCatePrint, true)),
                        new SqlParameter("@maxnList", Utilities.ConvertStrinArryToInClauseSQL(uploadCondit.arrtestCodePrint, true) ),
                        new SqlParameter("@maLoaiXN",Utilities.ConvertStrinArryToInClauseSQL(uploadCondit.arrTestTypeID, true)),
                        new SqlParameter("@FromBackup", uploadCondit.frombackup),
                        new SqlParameter("@ManualUpload", uploadCondit.manualUpload),
                        new SqlParameter("@ForStatus", uploadCondit.forStatus)
                }
            );
            if (ds != null)
                dtData = ds.Tables[0];

            BenhNhanInfoForHIS bnInfo = null;
            // string log = "";
            if (dtData.Rows.Count > 0)
            {
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow drUpload = dtData.Rows[i];
                    if (i == 0)
                    {
                        bnInfo = (BenhNhanInfoForHIS)WorkingServices.Get_InfoForObject(new BenhNhanInfoForHIS(), drUpload);
                        bnInfo.userTransfer = uploadCondit.userID;
                    }
                    var resultInfo = (ChiDinhHISInfo)WorkingServices.Get_InfoForObject(new ChiDinhHISInfo(), drUpload);
                    if (resultInfo != null)
                    {
                        if (!string.IsNullOrEmpty(resultInfo.MaXN) && (resultInfo.DaXacNhan || uploadCondit.forStatus))
                        {
                            if ((!string.IsNullOrEmpty(bnInfo.Sophieuyeucau) &&
                                !string.IsNullOrEmpty(resultInfo.MaXN_His) &&
                                (!string.IsNullOrEmpty(resultInfo.Result) || resultInfo.XNChinh) || uploadCondit.forStatus))
                            {
                                resultInfo.LowHighAlarm = (resultInfo.AbnormalFlag == 1 ? string.Empty : (resultInfo.AbnormalFlag == 2 ? "L" : "H"));
                                if (!string.IsNullOrEmpty(resultInfo.GhiChuXN))
                                    resultInfo.LowHighAlarm += (string.IsNullOrEmpty(resultInfo.LowHighAlarm) ? resultInfo.GhiChuXN : string.Format("\n{0}", resultInfo.GhiChuXN));
                                resultInfo.User = uploadCondit.userID;
                                if (resultInfo.Thoigiangui == DateTime.MinValue) resultInfo.Thoigiangui = DateTime.Now;
                                if (resultInfo.DateTimeResult == DateTime.MinValue) resultInfo.DateTimeResult = DateTime.Now;
                                bnInfo.ChiDinh.Add(resultInfo);
                            }
                        }
                    }
                }
            }
            return bnInfo;
        }
        public DataTable DataUploadFileList()
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuKySo_DanhSachBenhNhan"
              ).Tables[0];

        }
        public bool ExistsMaBenhNhan(string mabenhnhan)
        {
            var sqlQuery = string.Format("select MaTiepNhan from benhnhan_tiepnhan(nolock) where MaBN= '{0}'", mabenhnhan);
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0].Rows.Count > 0;
        }
        public bool ExistsMaBenhNhanVaBarcode(string mabenhnhan, string barcode)
        {
            var sqlQuery = string.Format("select MaTiepNhan from benhnhan_tiepnhan(nolock) where MaBN= '{0}' and Seq = '{1}'", mabenhnhan, barcode);
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0].Rows.Count > 0;
        }
        public bool ExistsMaBenhNhanVaMaTiepNhan(string mabenhnhan, string matiepnhan)
        {
            var sqlQuery = string.Format("select MaTiepNhan from benhnhan_tiepnhan(nolock) where MaBN= '{0}' and MaTiepNhan = '{1}'", mabenhnhan, matiepnhan);
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0].Rows.Count > 0;
        }
        public bool ExistsMaTiepNhan(string matiepnhan)
        {
            var sqlQuery = string.Format("select MaTiepNhan from benhnhan_cls_xetnghiem(nolock) where MaTiepNhan= '{0}'", matiepnhan);
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0].Rows.Count > 0;
        }
        public bool ExistsBarcode(string barcode)
        {
            var sqlQuery = string.Format("select MaTiepNhan from benhnhan_cls_xetnghiem(nolock) where MaTiepNhan like '______.{0}'", barcode);
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0].Rows.Count > 0;
        }
        public bool ExistsBarcodeWithday(string barcode, int limitDay)
        {
            var sqlQuery = string.Format("select t.MaTiepNhan from benhnhan_tiepnhan t where t.MaTiepNhan like '______.{0}' and t.NgayTiepNhan between CONVERT(date, getdate() - ({1} -1)) and CONVERT(date, getdate())", barcode, limitDay);
            var conn = SqlDbConfigurationBase.GetConnection();
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0].Rows.Count > 0;
        }
        public bool CapNhat_ChuaUpload(string maTiepNhan, string maXN)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            var sqlPara = new SqlParameter[]
                {
                        new SqlParameter("@MaTiepNhan", maTiepNhan),
                        new SqlParameter("@MaXn", maXN.Replace("'",""))
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udptrangThai_ChuaUpload_ThuongQuy", sqlPara) > -1;
        }
        public bool CapNhat_ChuaUploadVS(string maTiepNhan, string maXN)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            var sqlPara = new SqlParameter[]
                {
                        new SqlParameter("@MaTiepNhan", maTiepNhan),
                        new SqlParameter("@MaXn", maXN.Replace("'",""))
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udptrangThai_ChuaUpload_ViSinh", sqlPara) > -1;
        }
        public DataTable DataTableHisThongTin(string HisID = "")
        {
            string sqlQuery = "select * from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his";
            if (!string.IsNullOrEmpty(HisID))
            {
                sqlQuery += string.Format(" where HisID = {0}", HisID);
            }
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public List<HisConnection> DataHisThongTin()
        {
            var data = DataTableHisThongTin();
            var returnList = new List<HisConnection>();
            foreach (DataRow row in data.Rows)
            {
                returnList.Add(new HisConnection()
                {
                    HisID = (HisProvider)Enum.Parse(typeof(HisProvider), row["HisID"].ToString()),
                    HisName = string.IsNullOrEmpty("HisName") ? string.Empty : row["HisName"].ToString(),
                    DbType = (DBConnectType)Enum.Parse(typeof(DBConnectType), row["DBConnectType"].ToString()),
                    ServerName = string.IsNullOrEmpty("Servername") ? string.Empty : row["Servername"].ToString(),
                    DatabaseName = string.IsNullOrEmpty("Databasename") ? string.Empty : row["Databasename"].ToString(),
                    UserName = string.IsNullOrEmpty("UserName") ? string.Empty : row["UserName"].ToString(),
                    PassWord = string.IsNullOrEmpty("Password") ? string.Empty : row["Password"].ToString(),
                    PortNumber = string.IsNullOrEmpty("PortNumber") ? string.Empty : row["PortNumber"].ToString(),

                    Internalcolumn = string.IsNullOrEmpty("Internalcolumn") ? string.Empty : row["Internalcolumn"].ToString(),
                    InteralByCharIndex = string.IsNullOrEmpty("InteralByCharIndex") ? false : bool.Parse(row["InteralByCharIndex"].ToString()),
                    InternalContaint = string.IsNullOrEmpty("InternalContaint") ? false : bool.Parse(row["InternalContaint"].ToString()),
                    InternalBitValue = string.IsNullOrEmpty("InternalBitValue") ? false : bool.Parse(row["InternalBitValue"].ToString()),
                    InternalCharValue = string.IsNullOrEmpty("InternalCharValue") ? string.Empty : row["InternalCharValue"].ToString(),
                    InternalCharStartIndex = string.IsNullOrEmpty("InternalCharStartIndex") ? string.Empty : row["InternalCharStartIndex"].ToString(),
                    IsActive = string.IsNullOrEmpty("IsActive") ? false : bool.Parse(row["IsActive"].ToString()),
                    DifferenceInOut = string.IsNullOrEmpty("DifferenceInOut") ? false : bool.Parse(row["DifferenceInOut"].ToString()),
                    NotUsePatientList = string.IsNullOrEmpty("NotUsePatientList") ? false : bool.Parse(row["NotUsePatientList"].ToString()),
                    FindNameOnHIS = string.IsNullOrEmpty("FindNameOnHIS") ? false : bool.Parse(row["FindNameOnHIS"].ToString()),
                    LISServerName = string.IsNullOrEmpty("LISServername") ? string.Empty : row["LISServername"].ToString(),
                    LISDatabasename = string.IsNullOrEmpty("LISDatabasename") ? string.Empty : row["LISDatabasename"].ToString(),
                    LISUserName = string.IsNullOrEmpty("LISUserName") ? string.Empty : row["LISUserName"].ToString(),
                    LISPassword = string.IsNullOrEmpty("LISPassword") ? string.Empty : row["LISPassword"].ToString(),
                    LISCallADTName = string.IsNullOrEmpty("LISCallADTName") ? string.Empty : row["LISCallADTName"].ToString()

                });
            }
            return returnList;
        }
        public DataTable DataTableHisThongTinHamn(string HisID = "")
        {
            string sqlQuery = "select * from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_thutuc";
            if (!string.IsNullOrEmpty(HisID))
            {
                sqlQuery += string.Format(" where HisID = {0}", HisID);
            }
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public List<HisFunctionConfig> DataHisThongTinHam()
        {
            var data = DataTableHisThongTinHamn();
            var returnList = new List<HisFunctionConfig>();
            foreach (DataRow row in data.Rows)
            {
                returnList.Add(new HisFunctionConfig()
                {
                    FunctionTypeID = (FunctionType)Enum.Parse(typeof(FunctionType), row["FunctionTypeID"].ToString()),
                    HisID = (HisProvider)Enum.Parse(typeof(HisProvider), row["HisID"].ToString()),
                    FunctionID = string.IsNullOrEmpty("FunctionID") ? string.Empty : row["FunctionID"].ToString(),
                    FunctionName = string.IsNullOrEmpty("FunctionName") ? string.Empty : row["FunctionName"].ToString(),
                    FunctionParaValues = string.IsNullOrEmpty("FunctionParaValues") ? string.Empty : row["FunctionParaValues"].ToString(),
                    FunctionParaNames = string.IsNullOrEmpty("FunctionParaNames") ? string.Empty : row["FunctionParaNames"].ToString(),
                    FunctionValuesType = string.IsNullOrEmpty("FunctionValuesType") ? string.Empty : row["FunctionValuesType"].ToString(),
                    LISColumns = string.IsNullOrEmpty("HisLISColumnsID") ? string.Empty : row["LISColumns"].ToString()
                });
            }
            return returnList;
        }
        public DataTable DataTableHisThongTinMappingCot(string HisID = "")
        {
            string sqlQuery = "select * from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave";
            if (!string.IsNullOrEmpty(HisID))
            {
                sqlQuery += string.Format(" where HisID = {0}", HisID);
            }
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public List<HISDataColumnNames> DataHisThongTinMappingCot()
        {
            string sqlQuery = "DECLARE @cols AS NVARCHAR(MAX),";
            sqlQuery += "\n @query AS NVARCHAR(MAX)";
            sqlQuery += "\nselect @cols = STUFF((SELECT ',' + QUOTENAME(HisColumnsName)";
            sqlQuery += "\nfrom {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave where HisID = 0";
            sqlQuery += "\ngroup by HisColumnsName, HisID";
            sqlQuery += "\norder by HisID";
            sqlQuery += "\nFOR XML PATH(''), TYPE";
            sqlQuery += "\n).value('.', 'NVARCHAR(MAX)')";
            sqlQuery += "\n,1,1,'')";
            sqlQuery += "\nset @query = N'SELECT HisID,' + @cols + N' from ";
            sqlQuery += "\n(";
            sqlQuery += "\nselect HisColumnValue, HisColumnsName, HisID";
            sqlQuery += "\nfrom {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave";
            sqlQuery += "\n) x";
            sqlQuery += "\n pivot";
            sqlQuery += "\n (";
            sqlQuery += "\n max(HisColumnValue)";
            sqlQuery += "\n for HisColumnsName in (' + @cols + N')";
            sqlQuery += "\n) p '";
            sqlQuery += "\nexec sp_executesql @query; ";

            var data = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            var returnList = new List<HISDataColumnNames>();
            var objhisColumn = new HISDataColumnNames();
            foreach (DataRow row in data.Rows)
            {
                objhisColumn = new HISDataColumnNames();
                PropertyInfo[] fiCheck = objhisColumn.GetType().GetProperties();
                foreach (var item in fiCheck)
                {
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        if (data.Columns[i].ColumnName.Equals(item.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            var obj = row[item.Name];
                            if (obj != DBNull.Value)
                            {
                                if (item.Name.Equals("HisID"))
                                    obj = (HisProvider)Enum.Parse(typeof(HisProvider), obj.ToString());

                                objhisColumn.GetType().GetProperty(item.Name).SetValue(objhisColumn, row[item.Name], null);
                            }
                        }
                    }
                }
                returnList.Add(objhisColumn);
            }
            return returnList;
        }
        public HISDataColumnNames GetHisThongTinMappingCot(HisConnection hisInfo, List<HISDataColumnNames> columnsList)
        {
            if (hisInfo != null)
            {
                if (columnsList != null)
                {
                    var resultObj = from items in columnsList where items.HisID.Equals(hisInfo.HisID) select items;
                    if (resultObj != null)
                        return resultObj.FirstOrDefault();
                }
            }
            return new HISDataColumnNames();
        }
        public HisFunctionConfig GetHisThongTinMappingHam(HisConnection hisInfo, List<HisFunctionConfig> columnsList)
        {
            if (hisInfo != null)
            {
                if (columnsList != null)
                {
                    var resultObj = from items in columnsList where items.HisID.Equals(hisInfo.HisID) select items;
                    if (resultObj != null)
                        return resultObj.FirstOrDefault();
                }
            }
            return new HisFunctionConfig();
        }
        public HisConnection GetHisThongTinMappingHis(string hisID, List<HisConnection> columnsList)
        {
            if (columnsList != null)
            {
                var resultObj = from items in columnsList where items.HisID.Equals(hisID) select items;
                if (resultObj != null)
                    return resultObj.FirstOrDefault();
            }

            return new HisConnection();
        }
        public void HisNhapCauHinhChuan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his (HisID, DBConnectType, HisName)");
            sb.Append("\nselect 0 as HisID, 1 as DBConnectType, N'Thông tin HIS chuẩn' as HisName from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his where HisID not in (0)");
            DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
            //thêm các tên trường chuẩn theo class khai báo
        }
        public void HisNhapCauHinhTheoChuan(int HisID, string HisName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his (HisID, DBConnectType, HisName)");
            sb.AppendFormat("\nselect {0} as HisID, DBConnectType, N'{1}' as HisName  from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his where HISID = 0 and not exists (select HisID from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his where HisID = {0})", HisID, HisName);
            DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());

            sb = new StringBuilder();
            sb.Append("insert into {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave(HisID, HisColumnsName, HisColumnValue)");
            sb.AppendFormat("\nselect {0} as HisID, HisColumnsName, HisColumnValue from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave t where HisID = 0", HisID);
            sb.AppendFormat("\nand not exists (select a.* from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave a where hisid = {0} and t.HisColumnsName = a.HisColumnsName)", HisID);
            DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());

            sb = new StringBuilder();
            sb.Append("insert into {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_thutuc(HisID, FunctionID, FunctionTypeID)");
            sb.AppendFormat("\nselect {0} as HisID, FunctionID, 1 as FunctionTypeID from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_thutuc t where HisID = 0", HisID);
            sb.AppendFormat("\nand not exists (select a.* from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_thutuc a where hisid = {0} and t.FunctionID = a.FunctionID)", HisID);
            DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public int Update_HisConnection(HisConnection objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his set");
            sb.AppendFormat("\n Dbconnecttype = {0}", ((int)objInfo.DbType).ToString());
            sb.AppendFormat("\n, Hisname = {0}", (objInfo.HisName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.HisName.ToString()) + "'"));
            sb.AppendFormat("\n, Servername = {0}", (objInfo.ServerName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.ServerName.ToString()) + "'"));
            sb.AppendFormat("\n, Username = {0}", (objInfo.UserName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.UserName.ToString()) + "'"));
            sb.AppendFormat("\n, Password = {0}", (objInfo.PassWord == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.PassWord.ToString()) + "'"));
            sb.AppendFormat("\n, Portnumber = {0}", (objInfo.PortNumber == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.PortNumber.ToString()) + "'"));
            sb.AppendFormat("\n, Databasename = {0}", (objInfo.DatabaseName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.DatabaseName.ToString()) + "'"));
            sb.AppendFormat("\n, Internalcolumn = {0}", (objInfo.Internalcolumn == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Internalcolumn.ToString()) + "'"));
            sb.AppendFormat("\n, Interalbycharindex = {0}", (bool.Parse(objInfo.InteralByCharIndex.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Internalcontaint = {0}", (bool.Parse(objInfo.InternalContaint.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Internalbitvalue = {0}", (bool.Parse(objInfo.InternalBitValue.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Internalcharvalue = {0}", (objInfo.InternalCharValue == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.InternalCharValue.ToString()) + "'"));
            sb.AppendFormat("\n, Internalcharstartindex = {0}", string.IsNullOrEmpty(objInfo.InternalCharStartIndex) ? "0" : objInfo.InternalCharStartIndex.ToString());
            sb.AppendFormat("\n, Isactive = {0}", (bool.Parse(objInfo.IsActive.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Differenceinout = {0}", (bool.Parse(objInfo.DifferenceInOut.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, NotUsePatientList = {0}", (objInfo.NotUsePatientList ? "1" : "0"));
            sb.AppendFormat("\n, FindNameOnHIS = {0}", (objInfo.FindNameOnHIS ? "1" : "0"));
            sb.AppendFormat("\n, LISServername = {0}", (objInfo.LISServerName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.LISServerName.ToString()) + "'"));
            sb.AppendFormat("\n, LISUsername = {0}", (objInfo.LISUserName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.LISUserName.ToString()) + "'"));
            sb.AppendFormat("\n, LISPassword = {0}", (objInfo.LISPassword == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.LISPassword.ToString()) + "'"));
            sb.AppendFormat("\n, LISCallADTName = {0}", (objInfo.LISCallADTName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.LISCallADTName.ToString()) + "'"));
            sb.AppendFormat("\n, LISDatabasename = {0}", (objInfo.LISDatabasename == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.LISDatabasename.ToString()) + "'"));

            sb.Append("\nwhere Hisid =  " + ((int)objInfo.HisID).ToString());
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public int Update_ThongTinHam(HisFunctionConfig objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_THUTUC set");
            sb.AppendFormat("\n Functiontypeid = {0}", ((int)objInfo.FunctionTypeID).ToString());
            sb.AppendFormat("\n, Functionname = {0}", (objInfo.FunctionName == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.FunctionName.ToString()) + "'"));
            sb.AppendFormat("\n, Functionparanames = {0}", (objInfo.FunctionParaNames == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.FunctionParaNames.ToString()) + "'"));
            sb.AppendFormat("\n, Functionparavalues = {0}", (objInfo.FunctionParaValues == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.FunctionParaValues.ToString()) + "'"));
            sb.AppendFormat("\n, Functionvaluestype = {0}", (objInfo.FunctionValuesType == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.FunctionValuesType.ToString()) + "'"));
            sb.AppendFormat("\n, Liscolumns = {0}", (objInfo.LISColumns == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.LISColumns.ToString()) + "'"));
            sb.Append("\nwhere  Hisid =  " + ((int)objInfo.HisID).ToString() + " and Functionid =  " + "'" + Utilities.ConvertSqlString(objInfo.FunctionID.ToString()).ToString() + "'");
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public int Insert_ThongTinTruongHISTraVe(string HisFieldName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("If not exists (select h.HisColumnsName from  {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave h where h.HISId = 0 and HisColumnsName = '{0}')", HisFieldName);
            sb.AppendLine("Begin");
            sb.AppendLine("insert into {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_tentruongtrave ([HisID], [HisColumnsName])");
            sb.AppendFormat("\n values (0, '{0}')", HisFieldName);
            sb.AppendLine("End");
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public int Insert_ThongTinThuTucHIS(string FunctionId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("If not exists (select h.FunctionID from  {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_THUTUC h where h.HISId = 0 and h.FunctionID = '{0}')", FunctionId);
            sb.AppendLine("Begin");
            sb.AppendLine("insert into {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_THUTUC ([HisID], [FunctionID], FunctionTypeID)");
            sb.AppendFormat("\n values (0, '{0}', 1)", FunctionId);
            sb.AppendLine("End");
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public int Update_ThongTinMappingCot(string HisID, string Hiscolumnsname, string Hiscolumnvalue)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his_TENTRUONGTRAVE set");
            sb.AppendFormat("\n Hiscolumnvalue = {0}", (string.IsNullOrEmpty(Hiscolumnvalue) ? "NULL" : "'" + Utilities.ConvertSqlString(Hiscolumnvalue) + "'"));
            sb.AppendFormat("\n where HisID = {0} and Hiscolumnsname = '{1}'", HisID, Hiscolumnsname);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        //For LabBlood
        public int InsertOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iGetHisService.InsertOrderedBloodElement(hisConnect, hisFunction, paraInfoList);
        }
        public int DeleteOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iGetHisService.DeleteOrderedBloodElement(hisConnect, hisFunction, paraInfoList);
        }
        public int ResetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iGetHisService.ResetBarcodeLabBlood(hisConnect, hisFunction, paraInfoList);
        }
        public int ReGetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iGetHisService.ReGetBarcodeLabBlood(hisConnect, hisFunction, paraInfoList);
        }
        public string MaNhanVienHis_TheoUser(string manguoiDung, int HisProviderId)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_MaNhanVienHis_TheoUser", new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@HisProviderID", HisProviderId),
                WorkingServices.GetParaFromOject("@MaNguoiDung", manguoiDung)
            }).Tables[0];
            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["HISID"].ToString();
            }
            return string.Empty;
        }
        public string MaXNHis_TheoMaXNLIS(string maXNLIS, int HisProviderId, ref string manhomHIS)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_MaXNHis_TheoXN", new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@HisProviderID", HisProviderId),
                WorkingServices.GetParaFromOject("@MaXN", maXNLIS)
            }).Tables[0];
            if (data.Rows.Count > 0)
            {
                manhomHIS = data.Rows[0]["nhomxn"].ToString();
                return data.Rows[0]["madichvu"].ToString();
            }
            return string.Empty;
        }
        public HISReturnBase ThemTiepNhanVaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iGetHisService.ThemTiepNhanVaChiDinh(hisConnect, tiepNhan);
        }

        public HISReturnBase LayKetQua(HisConnection hisConnect, Dictionary<string, object> paraInfoList)
        {
            var returData = _iGetHisService.LayKetQua(hisConnect, paraInfoList);
            if (returData.Data != null)
            {
                foreach (DataColumn c in returData.Data.Columns)
                {
                    c.ColumnName = c.ColumnName.ToLower();
                }
            }
            return returData;
        }

        public HISReturnBase ThemChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iGetHisService.ThemChiDinh(hisConnect, tiepNhan);
        }

        public HISReturnBase XoaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iGetHisService.XoaChiDinh(hisConnect, tiepNhan);
        }

        public HISReturnBase UploadFileKetQua(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iGetHisService.UploadFileKetQua(hisConnect, tiepNhan);
        }
    }
}