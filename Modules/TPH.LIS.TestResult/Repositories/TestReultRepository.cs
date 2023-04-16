using TPH.LIS.BarcodePrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Lab.BusinessService.Models;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Log;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Constants;
using TPH.LIS.TestResult.Model;
using TPH.LIS.User.Enum;
using TPH.LIS.Log.Constants;
using static TPH.LIS.Common.TestType;
using DevExpress.XtraRichEdit.Layout.Engine;
using System.Xml.Serialization;

namespace TPH.LIS.TestResult.Repositories
{
    class TestReultRepository : ITestReultRepository
    {
        private readonly IPatientInformationService iPatient = new PatientInformationService();
        private readonly IWorkingLogService _iWorkingLog = new WorkingLogService();
        #region Log
        public void ResultLog(string maTiepNhan, LogActionId action, List<string> maXn, string maProfile, string userAction)
        {
            _iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(action, userAction, Utilities.ConvertSqlString(maTiepNhan), maXn, maProfile);
        }
        #endregion
        public bool InsertTest(BENHNHAN_TIEPNHAN objBn, XetNghiemInfo objxn)
        {
            	//,@NgayLayMau datetime = null
             //   , @Nguoilaymau varchar(25) = null
	            //,@PCThucHien nvarchar(100)
            iPatient.Insert_BenhNhan_CLS_XetNghiem(objBn.Matiepnhan);
            var sqlPara = new SqlParameter[]
          {
            WorkingServices.GetParaFromOject("@MaTiepNhan", objBn.Matiepnhan)
            , WorkingServices.GetParaFromOject("@MaDichVu",objxn.maxn)
            , WorkingServices.GetParaFromOject("@MaDoiTuong", objBn.Doituongdichvu)
            , WorkingServices.GetParaFromOject("@GiaRieng",(objxn.Dongia < 0 ? (object)DBNull.Value : objxn.Dongia))
            , WorkingServices.GetParaFromOject("@XnProfile", objxn.xetnghiemProfile)
            , WorkingServices.GetParaFromOject("@idabo",objxn.idABO)
            , WorkingServices.GetParaFromOject("@ABOresult", objxn.ABOResult)
            , WorkingServices.GetParaFromOject("@idRH",objxn.idRh)
            , WorkingServices.GetParaFromOject("@resultRH", objxn.RhResult)
            , WorkingServices.GetParaFromOject("@nguoiNhapKQ",objxn.nguoiNhap)
            , WorkingServices.GetParaFromOject("@Khuvucnhanid", objxn.Khuvucnhanid)
            , WorkingServices.GetParaFromOject("@Khuvucthuchienid",objxn.Khuvucthuchienid)
            , WorkingServices.GetParaFromOject("@maCaptren", string.IsNullOrEmpty(objxn.MaCaptren)? (object)DBNull.Value: objxn.MaCaptren)
            , WorkingServices.GetParaFromOject("@ProfileId",objxn.maprofile)
            , WorkingServices.GetParaFromOject("@NgayLayMau",objxn.Thoigianlaymau)
            , WorkingServices.GetParaFromOject("@Nguoilaymau", objxn.Nguoilaymau)
            , WorkingServices.GetParaFromOject("@PCThucHien",objxn.Pcthuchien)
          };
            int excute = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "insChiDinhThuCong"
             , sqlPara);

            if (excute > 0)
            {
                excute += InsertCategoryOfTest(objBn.Matiepnhan);
                excute += Reset_full_PrintOut_valid_FroInsertNewTest(objBn.Matiepnhan);
            }

            return excute > 0;
        }
        public bool UpdateProfileID(string matiepNhan, string profileId)
        {
            var sqlPara = new SqlParameter[]
            {
              WorkingServices.GetParaFromOject("@MaTiepNhan", matiepNhan)
            , WorkingServices.GetParaFromOject("@MaProfile",profileId)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "updXetNghiem_MaProfile"
             , sqlPara) > 0;
        }
        public int InsertTestFromHis(BenhNhanInfoForHIS info, List<ChiDinhHISInfo> item, List<XetNghiemHISInfo> xetnghiem)
        {
            int excuteCount = 0;
            var dataInsertNormalTest = new List<InsertOrderHISModel>();

            for (int i = 0; i < item.Count; i++)
            {
                if (xetnghiem[i].LoaiXetNghiem == (int)EnumTestType.GPB)
                {
                    var sqlPara = new SqlParameter[]
                         {
                           WorkingServices.GetParaFromOject("@SID", info.Matiepnhan),
                           WorkingServices.GetParaFromOject("@TestCodeLIS", xetnghiem[i].maxn),
                           WorkingServices.GetParaFromOject("@Marker", item[i].SoLuong),
                           WorkingServices.GetParaFromOject("@CLSYeuCau_ID", info.Sophieuyeucau),
                           WorkingServices.GetParaFromOject("@CLSYeuCauChiTiet_ID", item[i].SoPhieuChiDinh),
                           WorkingServices.GetParaFromOject("@DichVu_ID", item[i].IdChiTiet),
                           WorkingServices.GetParaFromOject("@TestCodeHIS", item[i].TestCode),
                           WorkingServices.GetParaFromOject("@OrderID", item[i].SoPhieuChiDinh),
                           WorkingServices.GetParaFromOject("@OrderDate", info.Ngaydk),
                           WorkingServices.GetParaFromOject("@HisOrderDate", item[i].Thoigiangui),
                           WorkingServices.GetParaFromOject("@SampleCollectTime", item[i].ThoiGianLayMau),
                           WorkingServices.GetParaFromOject("@UserCollectSample", item[i].NguoiLayMau),
                           WorkingServices.GetParaFromOject("@PcCollectSample", item[i].Pclaymau),
                           WorkingServices.GetParaFromOject("@SampleGetTime", (DateTime?)null),
                           WorkingServices.GetParaFromOject("@UserGetSample", string.Empty),
                           WorkingServices.GetParaFromOject("@PcGetSample", string.Empty),
                           WorkingServices.GetParaFromOject("@SampleGetted", false),
                           WorkingServices.GetParaFromOject("@SampleCollected",(item[i].TrangThaiMau  == TPH.Data.HIS.HISDataCommon.OrderStatus.SampleCollect? 1: 0)),
                           WorkingServices.GetParaFromOject("@LisTestCode", xetnghiem[i].maxn),
                           WorkingServices.GetParaFromOject("@HisMasterID", item[i].MaXNCha_His),
                           WorkingServices.GetParaFromOject("@ViTriLayMau", string.Empty),
                           WorkingServices.GetParaFromOject("@UserInsert", info.Usernhap)
                        };
                    excuteCount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "Anapath_Ins_TestCodeOrderFromHis", sqlPara);
                }
                else
                {
                    dataInsertNormalTest.Add(new InsertOrderHISModel
                    {
                        Matiepnhan = info.Matiepnhan,
                        Doituongdichvu = info.Doituongdichvu,
                        Usernhapchidinh = info.Usernhap,
                        Sophieuyeucau_chung = info.Sophieuyeucau,
                        Sophieuchidinh_chitiet = item[i].SoPhieuChiDinh,
                        Maxn = xetnghiem[i].maxn,
                        Sttxn = item[i].STT,
                        Idchidinhdichvu_chitiet = item[i].IDDichVuChiDinh,
                        Iddichvuchitiet = item[i].IdChiTiet,
                        Khuvucnhanid = item[i].Khuvucnhanid,
                        Khuvucthuchienid = item[i].Khuvucthuchienid,
                        Idloaichucnangcls = item[i].Idloaichucnangcls,
                        Idnhomchucnangcls = item[i].Idnhomchucnangcls,
                        Iddmchiphi = item[i].Iddmchiphi,
                        Bangkeid = item[i].Bangkeid,
                        Idbenh = item[i].IDBenh,
                        Thangkt = item[i].Thangkt,
                        Namkt = item[i].Namkt,
                        Manhanvienchidinh = item[i].MaNhanVienChiDinh,
                        Maloaixn_his = item[i].MaLoaiXN_His,
                        Thoigianchidinhhis = item[i].Thoigiangui,
                        Maxncha_his = item[i].MaXNCha_His,
                        Mabschidinh = item[i].MaBSChiDinh,
                        Makhoachidinh = item[i].MaKhoaChiDinh,
                        Laymacaptren = item[i].LayMaCapTren,
                        Thongsocon = (xetnghiem[i].thongsocon ?? string.Empty).Replace("|", ","),
                        Maxnhis = item[i].TestCode,
                        Isprofile = xetnghiem[i].isprofile,
                        Maprofile = xetnghiem[i].maprofile,
                        Thoigianlaymau = item[i].ThoiGianLayMau,
                        Nguoilaymau = item[i].NguoiLayMau,
                        Ttnguoiduoclaymau = item[i].TTNguoiDuocLayMau,
                        Thoigianinbarcode = item[i].ThoiGianInTem,
                        Nguoiinbarcode = item[i].NguoiInTem,
                        Thoigianguimau = item[i].ThoiGianGiaoMau,
                        Nguoiguimau = item[i].NguoiGiaoMau,
                        Tinhtrangmau = item[i].TinhTrangMau,
                        Loaixetnghiem = xetnghiem[i].LoaiXetNghiem,
                        Laymaukhitiepnhan = item[i].Laymaukhitiepnhan,
                        Soluong = item[i].Soluong,
                        Pclaymau = item[i].Pclaymau,
                        Banlaymau = item[i].Banlaymau,
                        Idkhulaymau = item[i].Idkhulaymau,
                        Solan = item[i].Solan,
                        Lydo = item[i].Lydo,
                        Maloaimauhis = item[i].Maloaimauhis,
                        Tenloaimauhis = item[i].Tenloaimauhis
                    });
                }
            }
            if (dataInsertNormalTest.Count > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<InsertOrderHISModel>));
                var stringwriter = new System.IO.StringWriter();
                serializer.Serialize(stringwriter, dataInsertNormalTest);
                var xmlString = stringwriter.ToString();
                excuteCount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insChiDinhHISByXML", new SqlParameter[] { WorkingServices.GetParaFromOject("@xmlOrderString", xmlString) });
            }
            if (excuteCount > 0)
            {
                excuteCount += InsertCategoryOfTest(info.Matiepnhan);
                excuteCount += Reset_full_PrintOut_valid_FroInsertNewTest(info.Matiepnhan);
            }
            return excuteCount;
        }
        public int Update_ThongTinChiDinh(string matiepnhan, string maXn, DateTime ngayChiDinh)
        {
            //  thoigianchidinhhis

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Update ketqua_cls_xetnghiem set thoigianchidinhhis = '{0}' where MaTiepNhan = '{1}' "
                , ngayChiDinh.ToString("yyyy-MM-dd HH:mm:ss")
                , matiepnhan);
            if (!string.IsNullOrEmpty(maXn))
            {
                sb.AppendFormat("\n and MaXN = '{0}'", maXn);
            }
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }

        public int UpdateHISInfoForAutoInsertTest(string matiepnhan, string maxn, string maxnChinh)
        {
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
            , WorkingServices.GetParaFromOject("@maXNChinh", maxnChinh)
              ,WorkingServices.GetParaFromOject("@maxn", maxn)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_ChonThem_ThongTinXNCon", sqlPara);
        }
        public bool CheckExistsTest(string matiepnhan, string maxn)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, string.Format("select * from ketqua_cls_xetnghiem where MaTiepNhan = '{0}' and MaXN = '{1}'", matiepnhan, maxn)).Tables[0].Rows.Count > 0;
        }
        public int Reset_full_PrintOut_valid_FroInsertNewTest(string maTiepNhan)
        {
            var sqlQuery = string.Format("update benhnhan_cls_xetnghiem set DuKQXN = 0, ValidKQXN = 0, DaInKQXN = 0 where MatiepNhan = '{0}' ", maTiepNhan);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
        }
        public int DeleteCategoryOfTest(string matiepnhan)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delXetNghiem_NhomCuaXetNghiem", new SqlParameter[]
              {
                   WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
              });
        }
        public int InsertCategoryOfTest(string matiepnhan)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_NhomCuaXetNghiem", new SqlParameter[]
                     {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
                     });
        }
        public DataTable DataCategoryOrTest(string maTiepNhan, int loaiThoiGian, string inNhom)
        {
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
            , WorkingServices.GetParaFromOject("@LoaiThoiGian", loaiThoiGian)
            , WorkingServices.GetParaFromOject("@inNhom", inNhom)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selXetNghiem_NhomCuaXetNghiem"
             , sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DataDepartmentOrTest(string maTiepNhan, int loaiThoiGian, string inBoPhan)
        {
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
            , WorkingServices.GetParaFromOject("@LoaiThoiGian", loaiThoiGian)
              ,WorkingServices.GetParaFromOject("@inBoPhan", inBoPhan)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selXetNghiem_BoPhanCuaXetNghiem"
             , sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public int UpdateFullAndValidResultCategory(string matiepnhan)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpFullResultNhom", new SqlParameter[]
                     {
                                    WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
                     });
        }
        public int UpdatePrintOutCategory(string matiepnhan, string manhom, bool daIn, string userIn)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updCapNhat_TrangThaiDaInChoNhom", new SqlParameter[]
                     {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
                        ,WorkingServices.GetParaFromOject("@manhom", manhom)
                        ,WorkingServices.GetParaFromOject("@daIn", daIn)
                        ,WorkingServices.GetParaFromOject("@userIn", userIn)
                     });
        }
        public int UpdatePrintOutPatientAndCategoryAndDeparment(string matiepnhan, string manhom
            , bool daIn, string userIn, bool isSigned, string userSignDigital
            , string pcName, DateTime? dateSignDigital, int reportType )
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpPrintStatusCategoryAndPatient", new SqlParameter[]
                     {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
                        ,WorkingServices.GetParaFromOject("@daIn", daIn)
                        ,WorkingServices.GetParaFromOject("@userIn", userIn)
                        ,WorkingServices.GetParaFromOject("@manhom", manhom)
                        ,WorkingServices.GetParaFromOject("@userky", userSignDigital)
                        ,WorkingServices.GetParaFromOject("@pcname", pcName)
                        ,WorkingServices.GetParaFromOject("@dakycks", isSigned)
                        ,WorkingServices.GetParaFromOject("@ngayky", dateSignDigital)
                        ,WorkingServices.GetParaFromOject("@LoaiPhieuIn", reportType)
                     });
        }
        public int UpdateDownloadPatient(string maTiepNhan)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendFormat("update benhnhan_tiepnhan set sent=0, datesent=null where matiepnhan='{0}' and sent=1\n", Utilities.ConvertSqlString(maTiepNhan));
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
        }
        public int UpdateAllowDownload(string maTiepNhan)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendFormat("update benhnhan_tiepnhan set allowdownload=1 where matiepnhan='{0}'\n", Utilities.ConvertSqlString(maTiepNhan));
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
        }
        public int UpdateGiaDichVuXN(string maTiepNhan)
        {
            string strSQL = "\nupdate k";
            strSQL += "\nset k.GiaRieng = d.GiaRieng";
            strSQL += "\nfrom KetQua_CLS_XetNghiem k inner join benhnhan_tiepnhan t on t.MaTiepNhan=k.MaTiepNhan";
            strSQL += "\ninner join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia d " + string.Format("on (k.MAXN = d.MaDichVu and d.MaDoiTuongDichVu= t.Doituongdichvu and MaLoaiDichVu = '{0}')", ServiceType.ClsXetNghiem.ToString());
            strSQL += string.Format("\nwhere k.MaTiepNhan  = '{0}'", Utilities.ConvertSqlString(maTiepNhan));
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
        }
        public int UpdateDiscountDoctor(string maTiepNhan, string maDichVu, bool isProfile)
        {
            string strSQL = "update k\n";
            strSQL += "set k.ChietKhau=c.Chietkhau,k.TienCong=c.TienCong\n";
            strSQL += "from benhnhan_tiepnhan t\n";
            strSQL += "inner join ketqua_cls_xetnghiem k on t.MaTiepNhan=k.MaTiepNhan\n";
            strSQL += "inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            strSQL += string.Format("inner join QL_NhanVien_ChietKhau c on t.BacSiCD=c.MaNhanVien and c.MaLoaiDichVu='{0}' and c.MaDichVu=k.MaXN\n", ServiceType.ClsXetNghiem.ToString());
            strSQL += string.Format("where t.MaTiepNhan  = '{0}'", Utilities.ConvertSqlString(maTiepNhan));
            if (!string.IsNullOrEmpty(maDichVu))
            {
                if (isProfile)
                {
                    strSQL += string.Format("\n and k.ProfileID = {0}", maDichVu);
                }
                else
                    strSQL += string.Format("\n and k.MaXN = {0}", maDichVu);
            }
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
        }
        public int SoLuongMau(string maTiepNhan, int kieuLay, bool maudaLay = false)
        {
            var sqlPara = new SqlParameter[]
          {
                WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                , WorkingServices.GetParaFromOject("@theoNhom",kieuLay)
                , WorkingServices.GetParaFromOject("@kiemTraKetQua", true)
                , WorkingServices.GetParaFromOject("@mauDaLay", maudaLay)
          };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selXetNghiem_DanhSachMau"
             , sqlPara);
            if (ds != null)
            {
                if (kieuLay == 1)
                {
                    var data = ds.Tables[0];
                    if (data.Rows.Count > 0)
                        return int.Parse(string.IsNullOrEmpty(data.Rows[0]["SL"].ToString()) ? "0" : data.Rows[0]["SL"].ToString());
                    else
                        return 0;
                }
                else if (kieuLay == 2)
                {
                    //lấy số dòng đề có khi cần ghép mã loại mẫu vào
                    return ds.Tables[0].Rows.Count;
                }
                else
                {
                    var data = ds.Tables[0];
                    if (data.Rows.Count > 0)
                        return int.Parse(string.IsNullOrEmpty(data.Rows[0]["SL"].ToString()) ? "0" : data.Rows[0]["SL"].ToString());
                    else
                        return 0;
                }
            }
            return 0;
        }
        public DataTable SoLuongMau_Data(string maTiepNhan, bool mauDaLay, int idLayLoaiMau, bool dulieuChuyenMau = false, bool danhDauCong = false)
        {
            //lấy số dòng đề có khi cần ghép mã loại mẫu vào
            var sqlPara = new SqlParameter[]
                   {
                       WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                        , WorkingServices.GetParaFromOject("@theoNhom",5)
                        , WorkingServices.GetParaFromOject("@kiemTraKetQua", true)
                        , WorkingServices.GetParaFromOject("@mauDaLay", (mauDaLay?1:2))
                        , WorkingServices.GetParaFromOject("@duLieuChuyenMau", (dulieuChuyenMau?1:0))
                        , WorkingServices.GetParaFromOject("@idLayLoaiMau", idLayLoaiMau)
                   };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selXetNghiem_DanhSachMau_CoDanhDau"
             , sqlPara);
            if (ds != null)
            {
                var data = ds.Tables[0];
                var dataGroupByKyTuDanhDau = WorkingServices.SearchResult_OnDatatable(data, "KyTuDanhDau is not null");
                var dataGroupByKhongKyTuDanhDau = WorkingServices.SearchResult_OnDatatable(data, "KyTuDanhDau is null or KyTuDanhDau = '' ");
                if (dataGroupByKyTuDanhDau.Rows.Count > 0 && data.Rows.Count > 0)
                {
                    //Set null lại các giá trị ký tự đánh dấu
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        data.Rows[i]["KyTuDanhDau"] = string.Empty;
                    }
                    var arrCol = new string[data.Columns.Count];
                    for (int c = 0; c < data.Columns.Count; c++)
                    {
                        arrCol[c] = data.Columns[c].ColumnName;
                    }
                    data = data.DefaultView.ToTable(true, arrCol);

                    //grop các thông tin có cùng Nhóm loại mẫu
                    var groupByNhom = dataGroupByKyTuDanhDau.DefaultView.ToTable(true, "LoaiMau", "LoaiMauChay");
                    foreach (DataRow drgNhom in groupByNhom.Rows)
                    {
                        var finishString = string.Empty;
                        var lstAdded = new List<string>();
                        var loaiMau = drgNhom["LoaiMau"].ToString();
                        var loaiMauChay = drgNhom["LoaiMauChay"].ToString();
                        var dataList = WorkingServices.SearchResult_OnDatatable(dataGroupByKyTuDanhDau, string.Format("LoaiMau = '{0}' and LoaiMauChay = '{1}'", loaiMau, loaiMauChay));
                        var dataKoKyTuDanhDau = WorkingServices.SearchResult_OnDatatable(dataGroupByKhongKyTuDanhDau, string.Format("LoaiMau = '{0}' and LoaiMauChay = '{1}'", loaiMau, loaiMauChay));
                        if (dataList.Rows.Count > 0)
                        {
                            foreach (DataRow drL in dataList.Rows)
                            {
                                if (!string.IsNullOrEmpty(drL["KyTuDanhDau"].ToString()))
                                {
                                    if (!lstAdded.Where(x => x.Equals(drL["KyTuDanhDau"].ToString().Trim(), StringComparison.OrdinalIgnoreCase)).Any())
                                    {
                                        finishString += string.IsNullOrEmpty(finishString) ? "" : ",";
                                        finishString += drL["KyTuDanhDau"].ToString();
                                        lstAdded.Add(drL["KyTuDanhDau"].ToString().Trim());
                                    }
                                }
                            }
                        }
                        if (dataKoKyTuDanhDau.Rows.Count > 0 && danhDauCong)
                        {
                            finishString = "+" + finishString;
                        }
                        foreach (DataRow drMain in data.Rows)
                        {
                            var loaiMauMain = drMain["LoaiMau"].ToString();
                            var loaiMauChayMain = drMain["LoaiMauChay"].ToString();
                            if (loaiMau.Equals(loaiMauMain, StringComparison.OrdinalIgnoreCase)
                                && loaiMauChay.Equals(loaiMauChayMain, StringComparison.OrdinalIgnoreCase))
                            {
                                drMain["KyTuDanhDau"] = finishString;
                            }
                        }
                    }
                }
                return data;
            }
            return null;
        }
        public DataTable Get_Patient_XN_Theobarcode(string maTiepNhan, string dateIn, enumThucHien dainKQ
     , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
     , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
     , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
     , string lstNhomXN)
        {
            var paFromDate = WorkingServices.GetParaFromOject("@datein", SqlDbType.DateTime);
            if (string.IsNullOrEmpty(dateIn))
                paFromDate.Value = DBNull.Value;
            else
                paFromDate.Value = DateTime.Parse(dateIn).Date;
            var objTestType = string.Empty;
            if (lstTestType != null)
            {
                if (lstTestType.Count > 0)
                {
                    foreach (var item in lstTestType)
                    {
                        objTestType += (string.IsNullOrEmpty(objTestType) ? "" : ",");
                        objTestType += ((int)item).ToString();
                    }
                }
            }
            var sqlPara = new SqlParameter[]
            {
                    paFromDate
                        , WorkingServices.GetParaFromOject("@maTiepNhan", string.IsNullOrEmpty(maTiepNhan)? (object)DBNull.Value: maTiepNhan)
                        , WorkingServices.GetParaFromOject("@printType",(int)dainKQ)
                        , WorkingServices.GetParaFromOject("@duKetQua",(int)duKetQua)
                        , WorkingServices.GetParaFromOject("@daXacNhan",(int)daXacNhan)
                        , WorkingServices.GetParaFromOject("@inKkhuvuc",khuvuc.Length == 0? (object)DBNull.Value: Utilities.ConvertStrinArryToInClauseSQL(khuvuc, false))
                        , WorkingServices.GetParaFromOject("@inTestType",string.IsNullOrEmpty(objTestType) ?(object)DBNull.Value: objTestType )
                        , WorkingServices.GetParaFromOject("@checkmauDaLay",checkmauDaLay)
                        , WorkingServices.GetParaFromOject("@checkDaNhanMau",checkMauDaNhan)
                        , WorkingServices.GetParaFromOject("@MaBenhNhan", string.IsNullOrEmpty(maBN)? (object)DBNull.Value: maBN)
                        , WorkingServices.GetParaFromOject("@lstBoPhan", string.IsNullOrEmpty(lstBoPhan)? (object)DBNull.Value: lstBoPhan)
                        , WorkingServices.GetParaFromOject("@lstKhoaPhong", string.IsNullOrEmpty(lstKhoaPhong)? (object)DBNull.Value: lstKhoaPhong)
                        , WorkingServices.GetParaFromOject("@khuDieuTri", string.IsNullOrEmpty(maKhuDieuTri)? (object)DBNull.Value: maKhuDieuTri)
                        , WorkingServices.GetParaFromOject("@lstNhomxetnghiem", string.IsNullOrEmpty(lstNhomXN)? (object)DBNull.Value: lstNhomXN)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selDanhSach_BenhNhan_KQXNThuongQui_MaCode"
             , sqlPara);
            return ds?.Tables[0];
        }
        public DataTable Get_Patient_XN_TheoNgayNhanMau(string maTiepNhan, string dateIn, enumThucHien dainKQ
  , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
  , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
  , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
  , string lstNhomXN)
        {
            var paFromDate = WorkingServices.GetParaFromOject("@datein", SqlDbType.DateTime);
            if (string.IsNullOrEmpty(dateIn))
                paFromDate.Value = DBNull.Value;
            else
                paFromDate.Value = DateTime.Parse(dateIn).Date;
            var objTestType = string.Empty;
            if (lstTestType != null)
            {
                if (lstTestType.Count > 0)
                {
                    foreach (var item in lstTestType)
                    {
                        objTestType += (string.IsNullOrEmpty(objTestType) ? "" : ",");
                        objTestType += ((int)item).ToString();
                    }
                }
            }
            var sqlPara = new SqlParameter[]
            {
                    paFromDate
                        , WorkingServices.GetParaFromOject("@maTiepNhan", string.IsNullOrEmpty(maTiepNhan)? (object)DBNull.Value: maTiepNhan)
                        , WorkingServices.GetParaFromOject("@printType",(int)dainKQ)
                        , WorkingServices.GetParaFromOject("@duKetQua",(int)duKetQua)
                        , WorkingServices.GetParaFromOject("@daXacNhan",(int)daXacNhan)
                        , WorkingServices.GetParaFromOject("@inKkhuvuc",khuvuc.Length == 0? (object)DBNull.Value: Utilities.ConvertStrinArryToInClauseSQL(khuvuc, false))
                        , WorkingServices.GetParaFromOject("@inTestType",string.IsNullOrEmpty(objTestType) ?(object)DBNull.Value: objTestType )
                        , WorkingServices.GetParaFromOject("@checkmauDaLay",checkmauDaLay)
                        , WorkingServices.GetParaFromOject("@checkDaNhanMau",checkMauDaNhan)
                        , WorkingServices.GetParaFromOject("@MaBenhNhan", string.IsNullOrEmpty(maBN)? (object)DBNull.Value: maBN)
                        , WorkingServices.GetParaFromOject("@lstBoPhan", string.IsNullOrEmpty(lstBoPhan)? (object)DBNull.Value: lstBoPhan)
                        , WorkingServices.GetParaFromOject("@lstKhoaPhong", string.IsNullOrEmpty(lstKhoaPhong)? (object)DBNull.Value: lstKhoaPhong)
                        , WorkingServices.GetParaFromOject("@khuDieuTri", string.IsNullOrEmpty(maKhuDieuTri)? (object)DBNull.Value: maKhuDieuTri)
                        , WorkingServices.GetParaFromOject("@lstNhomxetnghiem", string.IsNullOrEmpty(lstNhomXN)? (object)DBNull.Value: lstNhomXN)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selDanhSach_BenhNhan_KQXNThuongQui_NgayNhanMau"
             , sqlPara);
            return ds?.Tables[0];
        }
        public DataTable Get_Patient_XN_TheoNgayTiepNhan(string maTiepNhan, string dateIn, enumThucHien dainKQ
          , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
          , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
          , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
          , string lstNhomXN)
        {
            var paFromDate = WorkingServices.GetParaFromOject("@datein", SqlDbType.DateTime);
            if (string.IsNullOrEmpty(dateIn))
                paFromDate.Value = DBNull.Value;
            else
                paFromDate.Value = DateTime.Parse(dateIn).Date;
            var objTestType = string.Empty;
            if (lstTestType != null)
            {
                if (lstTestType.Count > 0)
                {
                    foreach (var item in lstTestType)
                    {
                        objTestType += (string.IsNullOrEmpty(objTestType) ? "" : ",");
                        objTestType += ((int)item).ToString();
                    }
                }
            }
            var sqlPara = new SqlParameter[]
            {
                    paFromDate
                        , WorkingServices.GetParaFromOject("@maTiepNhan", string.IsNullOrEmpty(maTiepNhan)? (object)DBNull.Value: maTiepNhan)
                        , WorkingServices.GetParaFromOject("@printType",(int)dainKQ)
                        , WorkingServices.GetParaFromOject("@duKetQua",(int)duKetQua)
                        , WorkingServices.GetParaFromOject("@daXacNhan",(int)daXacNhan)
                        , WorkingServices.GetParaFromOject("@inKkhuvuc",khuvuc.Length == 0? (object)DBNull.Value: Utilities.ConvertStrinArryToInClauseSQL(khuvuc, false))
                        , WorkingServices.GetParaFromOject("@inTestType",string.IsNullOrEmpty(objTestType) ?(object)DBNull.Value: objTestType )
                        , WorkingServices.GetParaFromOject("@checkmauDaLay",checkmauDaLay)
                        , WorkingServices.GetParaFromOject("@checkDaNhanMau",checkMauDaNhan)
                        , WorkingServices.GetParaFromOject("@MaBenhNhan", string.IsNullOrEmpty(maBN)? (object)DBNull.Value: maBN)
                        , WorkingServices.GetParaFromOject("@lstBoPhan", string.IsNullOrEmpty(lstBoPhan)? (object)DBNull.Value: lstBoPhan)
                        , WorkingServices.GetParaFromOject("@lstKhoaPhong", string.IsNullOrEmpty(lstKhoaPhong)? (object)DBNull.Value: lstKhoaPhong)
                        , WorkingServices.GetParaFromOject("@khuDieuTri", string.IsNullOrEmpty(maKhuDieuTri)? (object)DBNull.Value: maKhuDieuTri)
                        , WorkingServices.GetParaFromOject("@lstNhomxetnghiem", string.IsNullOrEmpty(lstNhomXN)? (object)DBNull.Value: lstNhomXN)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selDanhSach_BenhNhan_KQXNThuongQui_NgayTiepNhan"
             , sqlPara);
            return ds?.Tables[0];
        }
        public DataTable Get_Patient_XNViSinh(string maTiepNhan, string dateIn, enumThucHien dainKQ
            , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
            , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
            , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
            , string lstNhomXN)
        {
            var paFromDate = WorkingServices.GetParaFromOject("@datein", SqlDbType.DateTime);
            if (string.IsNullOrEmpty(dateIn))
                paFromDate.Value = DBNull.Value;
            else
                paFromDate.Value = DateTime.Parse(dateIn).Date;
            var objTestType = string.Empty;
            if (lstTestType.Count > 0)
            {
                foreach (var item in lstTestType)
                {
                    objTestType += (string.IsNullOrEmpty(objTestType) ? "" : ",");
                    objTestType += ((int)item).ToString();
                }
            }
            var sqlPara = new SqlParameter[]
            {
                    paFromDate
                        , WorkingServices.GetParaFromOject("@maTiepNhan", string.IsNullOrEmpty(maTiepNhan)? (object)DBNull.Value: maTiepNhan)
                        , WorkingServices.GetParaFromOject("@printType",(int)dainKQ)
                        , WorkingServices.GetParaFromOject("@duKetQua",(int)duKetQua)
                        , WorkingServices.GetParaFromOject("@daXacNhan",(int)daXacNhan)
                        , WorkingServices.GetParaFromOject("@inKkhuvuc",khuvuc.Length == 0? (object)DBNull.Value: Utilities.ConvertStrinArryToInClauseSQL(khuvuc, false))
                        , WorkingServices.GetParaFromOject("@inTestType",string.IsNullOrEmpty(objTestType) ?(object)DBNull.Value: objTestType )
                        , WorkingServices.GetParaFromOject("@checkmauDaLay",checkmauDaLay)
                        , WorkingServices.GetParaFromOject("@checkDaNhanMau",checkMauDaNhan)
                        , WorkingServices.GetParaFromOject("@MaBenhNhan", string.IsNullOrEmpty(maBN)? (object)DBNull.Value: maBN)
                        , WorkingServices.GetParaFromOject("@lstBoPhan", string.IsNullOrEmpty(lstBoPhan)? (object)DBNull.Value: lstBoPhan)
                        , WorkingServices.GetParaFromOject("@lstKhoaPhong", string.IsNullOrEmpty(lstKhoaPhong)? (object)DBNull.Value: lstKhoaPhong)
                        , WorkingServices.GetParaFromOject("@khuDieuTri", string.IsNullOrEmpty(maKhuDieuTri)? (object)DBNull.Value: maKhuDieuTri)
                        , WorkingServices.GetParaFromOject("@lstNhomxetnghiem", string.IsNullOrEmpty(lstNhomXN)? (object)DBNull.Value: lstNhomXN)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selDanhSach_BenhNhan_KQXNViSinh"
             , sqlPara);
            return ds?.Tables[0];
        }
        public DataTable GetValueConfig(int idConfig)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("select * from  {{TPH_Standard}}_System.dbo.config where idconfig={0}", idConfig);
            dt = DataProvider.ExecuteDataset(CommandType.Text, sql).Tables[0];
            return dt;
        }
        public void UpdateABOForFBlood(BloodInfo bloodInfo)
        {
            if (bloodInfo != null)
            {
                if (!string.IsNullOrEmpty(bloodInfo.ABOResult) && !string.IsNullOrEmpty(bloodInfo.RhResult))
                {
                    StringBuilder sqlQuery = new StringBuilder();
                    sqlQuery.AppendFormat("if exists(select AutoID from {0}..tbl_Blood where ISNULL(BloodHigherID,BloodID)='{1}' and (ABO is null or Rh is null))\n", bloodInfo.FBloodDB, bloodInfo.BloodID);
                    sqlQuery.AppendFormat("begin\n");
                    sqlQuery.AppendFormat("update \n");
                    sqlQuery.AppendFormat("{0}..tbl_Blood set ABO=case when ABO is null then '{1}' else ABO end,\n", bloodInfo.FBloodDB, bloodInfo.ABOResult);
                    sqlQuery.AppendFormat("Rh=case when Rh is null then '{0}' else Rh end\n", bloodInfo.RhResult);
                    sqlQuery.AppendFormat("where ISNULL(BloodHigherID,BloodID)='{0}' and (ABO is null or Rh is null)\n", bloodInfo.BloodID);
                    sqlQuery.AppendFormat("end\n");

                    int insert = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());

                    if (insert > 0)
                    {
                        sqlQuery.Clear();
                        sqlQuery.AppendFormat("insert {0}..lichsu_capnhat_abo_lis(bloodid, ABO, Rh, userinsert, dateinsert, comment)\n", bloodInfo.FBloodDB);
                        sqlQuery.AppendFormat("select '{0}' as bloodid, '{1}' as ABO, '{2}' as Rh, '{3}' as userinsert, getdate() as dateinsert, N'{4}' as comment",
                            bloodInfo.BloodID, bloodInfo.ABOResult, bloodInfo.RhResult, bloodInfo.UserInsert, bloodInfo.Comment);

                        DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
                    }
                }
            }
        }
        public DataTable Load_ChiDinhXetNghiem(string _MaTiepNhan)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select * from KetQua_CLS_XetNghiem where MatiepNhan='" + _MaTiepNhan + "'").Tables[0];
        }
        public bool CheckTonTaiChiDinh(string _MaTiepNhan, string _maxn, bool _profile)
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();
            if (!_profile)
            {
                sql.AppendFormat("select matiepnhan from KetQua_CLS_XetNghiem where matiepnhan='{0}' and maxn='{1}'", _MaTiepNhan, _maxn);
            }
            else
            {
                sql.AppendFormat("select matiepnhan,count(ProfileID) as CountTest from ketqua_cls_xetnghiem x\n");
                sql.AppendFormat("where matiepnhan='{0}' and ProfileID='{1}'\n", _MaTiepNhan, _maxn);
                sql.AppendFormat("group by matiepnhan,ProfileID\n");
                sql.AppendFormat("having count(ProfileID)=(select count(ProfileID) from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet where ProfileID=x.ProfileID)");
            }

            if (DataProvider.ExecuteDataset(CommandType.Text, sql.ToString()).Tables[0].Rows.Count > 0)
                result = true;

            return result;
        }
        public bool Get_MaBN_XNTruoc(string maBn, string maTiepNhan, string ngayNhap, ref string tenBangTn, ref string tenBangXn)
        {
            var sqlQuery = "select MaTiepNhan,' BenhNhan_TiepNhan ' as TblP, ' KetQua_CLS_XetNghiem ' as TblR, ThoiGianNhap from BenhNhan_TiepNhan where MaBN='" + maBn + "' and MaTiepNhan<>'" + Utilities.ConvertSqlString(maTiepNhan) + "' and ThoiGianNhap <'" + ngayNhap + "' ";
            sqlQuery = " select MaTiepNhan, Ltrim(RTrim(tblP)) as TblP, Ltrim(RTrim(tblR)) as TblR, ThoiGianNhap from (" + Environment.NewLine + sqlQuery + Environment.NewLine + ") as A order by ThoiGianNhap DESC";
            var dtCheck = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            if (dtCheck.Rows.Count <= 0) return false;

            tenBangTn = dtCheck.Rows[0]["tblP"].ToString();
            tenBangXn = dtCheck.Rows[0]["tblR"].ToString();

            return true;
        }
        public void CapNhat_DuKQ_XN(string maTiepNhan)
        {
            var sqlPara = new SqlParameter[]
                {
                     WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                };
            DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "udpFullResult"
             , sqlPara);
            //    > -1)
            //{
            //    UpdateFullAndValidResultCategory(maTiepNhan);
            //}
        }
        public void CapNhat_Valid_XN(string maTiepNhan, string uservalid)
        {
            var sqlPara = new SqlParameter[]
                 {
                    WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@uservalid", uservalid)

                 };
            if ((int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "updCapNhatThongTin_ValidXN"
             , sqlPara) > -1)
            {
                UpdateFullAndValidResultCategory(maTiepNhan);
            }
        }
        public void InsertNATToInfinity(string maTiepNhan, DateTime date)
        {
            string sql = string.Format("select x.MaTiepNhan, sum(case when x.flat<=1 then 0 else 1 end) as danhgia\n");
            sql += string.Format("from KetQua_CLS_XetNghiem x inner join benhnhan_tiepnhan b on x.matiepnhan=b.matiepnhan\n");
            sql += string.Format("inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet p on x.MaXN=p.MaXN and p.ProfileID=(select value1 from {{TPH_Standard}}_System.dbo.config where idconfig=8)\n");
            sql += string.Format("where x.MaTiepNhan='{0}' and isnull(x.KetQua,'')<>'' and x.XacNhanKQ=1 and b.nguonnhap='NHM'\n", Utilities.ConvertSqlString(maTiepNhan));
            sql += string.Format("group by x.MaTiepNhan\n");
            sql += string.Format("having count(x.matiepnhan)=(select value2 from {{TPH_Standard}}_System.dbo.config where idconfig=8)\n");

            DataTable dt = DataProvider.ExecuteDataset(CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r["danhgia"].ToString().Equals("0")) //Âm tính
                    {
                        DownloadTest(r["matiepnhan"].ToString(), 5);
                    }
                    else if (r["danhgia"].ToString().Equals("1")) //Dương tính
                    {
                        if (DownloadTest(r["matiepnhan"].ToString(), 6) > 0) //Nếu insert order thành công
                        {
                            //Xóa NAT khi XN thử dương tính
                            DeleteNAT(r["matiepnhan"].ToString(), 9);
                        }

                    }
                }
            }
        }
        public int DownloadTest(string sid, int value)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendFormat("insert {{TPH_Standard}}_Analyzer.dbo.h_ordertest(ngayluu, thoigianchidinh, mabn, sid, tenbn, namsinh, gioitinh, diachi, maxn, tenxetnghiem, maxnmay, idmay, loaimau)\n");
            sqlQuery.AppendFormat("select '{0:MM/dd/yyyy}' as ngayluu,getdate() as thoigianchidinh,b.MaTiepNhan as MaBN, cast(b.Seq as varchar(15)) as sid,b.TenBN,b.Tuoi as namsinh,b.GioiTinh,b.DiaChi,dx.maxn,dx.TenXN,case when isnull(mm.mamay2,'')='' then mm.mamay else mamay2 end as mamay,mm.idmay,mm.loaimau\n", DateTime.Now);
            sqlQuery.AppendFormat("from benhnhan_tiepnhan b inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dx on b.matiepnhan='{0}' inner join {{TPH_Standard}}_Dictionary.dbo.h_bangmamayxn mm on dx.MaXN=mm.maxn\n", sid);
            sqlQuery.AppendFormat("where mm.idmay=(select value1 from {{TPH_Standard}}_System.dbo.config where idconfig=7) and mm.camdown=0 and (isnull(mm.mamay,'')<>'' or isnull(mm.mamay2,'')<>'')\n");
            sqlQuery.AppendFormat("and dx.MaXN in(select maxn from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet where ProfileID=(select value1 from {{TPH_Standard}}_System.dbo.config where idconfig={0}))", value);

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
        }
        public int DeleteNAT(string sid, int value)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendFormat("delete x\n");
            sqlQuery.AppendFormat("from KetQua_CLS_XetNghiem x\n");
            sqlQuery.AppendFormat("inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet p on x.maxn=p.maxn and p.ProfileID=(select value1 from {{TPH_Standard}}_System.dbo.config where idconfig={0})\n", value);
            sqlQuery.AppendFormat("where MaTiepNhan='{0}'\n", sid);

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
        }
        public void UpdateDownload(string maTiepNhan, string maXN, bool download)
        {
            string _strSQL = "";
            _strSQL = string.Format("update KetQua_CLS_XetNghiem set downloadanother = {0} where MaTiepNhan = '{1}' and MaXN='{2}'", download ? 1 : 0, Utilities.ConvertSqlString(maTiepNhan), maXN);
            if (!string.IsNullOrEmpty(_strSQL))
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_KQ_XN_TuyDo(KetQuaHuyetTuyDo objInfo)
        {
            var sqlPara = new SqlParameter[]{WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@KetQua", objInfo.Ketqua),
                        WorkingServices.GetParaFromOject("@KetQuaTuy", objInfo.Ketquatuy),
                        WorkingServices.GetParaFromOject("@GhiChu", objInfo.Ghichu),
                        WorkingServices.GetParaFromOject("@Flag", objInfo.Flag),
                        WorkingServices.GetParaFromOject("@UserLuu", objInfo.Userluu),
                        WorkingServices.GetParaFromOject("@IDMayXetNghiem", objInfo.Idmayxetnghiem),
                        WorkingServices.GetParaFromOject("@UploadWeb", objInfo.Uploadweb),
                        WorkingServices.GetParaFromOject("@KetQuaQuiDoi", objInfo.Ketquaquidoi),
                        WorkingServices.GetParaFromOject("@SuaKetQua", objInfo.SuaKetQua)
            };
            if (objInfo.SuaKetQua)
            {
                //Ghi log
                _iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Update, objInfo.Userluu, Utilities.ConvertSqlString(objInfo.Matiepnhan), new List<string> { objInfo.Maxn }, string.Empty);
            }
            //else
            //{
            //    //Update data
            //    _strSQL = string.Format("update KetQua_CLS_XetNghiem set KetQua = N'{0}', KetQuaTuy =  N'{1}', GhiChu=N'{2}', Flat = {3},ThoiGianNhapKQ = '{4}', ThoiGianNhapKQ = getdate(),IDMayXetNghiem=0,UploadWeb=0 \n"
            //        , Utilities.ConvertSqlString(ketQuaMau), (string.IsNullOrEmpty(ketQuaTuy) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(ketQuaTuy)))
            //        , Utilities.ConvertSqlString(ghiChu)
            //        , co, userNhap);

            //}
            //if (WorkingServices.IsNumeric(ketQuaMau))
            //{
            //    if (!string.IsNullOrEmpty(round))
            //        _strSQL += string.Format(", KetQuaQuiDoi = (case when HeSoQuiDoi = 0 then NULL else round(cast('{0}' as float) * HeSoQuiDoi,{1}) end )\n", ketQuaMau, round);
            //    else
            //        _strSQL += string.Format(", KetQuaQuiDoi = (case when HeSoQuiDoi = 0 then NULL else cast('{0}' as float) * HeSoQuiDoi end )\n", ketQuaMau);
            //}
            //else
            //    _strSQL += ", KetQuaQuiDoi = null\n";
            //_strSQL += string.Format("where MaTiepNhan = '{0}' and MaXN='{1}'", Utilities.ConvertSqlString(maTiepNhan), maXN);

            //if (!string.IsNullOrEmpty(_strSQL))
                DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updKetQua_HuyetTuyDo", sqlPara);
        }
        public int CapNhat_CSBT(string maTiepNhan, string maXN, string IdMay, bool withUpdateFlat = false, bool capnhatGhichu = true)
        {
            var sqlPara = new SqlParameter[]
                {
                               WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                               , WorkingServices.GetParaFromOject("@maXN", maXN)
                               , WorkingServices.GetParaFromOject("@IdMay", IdMay)
                               , WorkingServices.GetParaFromOject("@withUpdateFlat", withUpdateFlat)
                               , WorkingServices.GetParaFromOject("@capnhatGhichu", capnhatGhichu)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
              , "updChiSoBinhThuong"
              , sqlPara);
        }
        public int CapNhat_BSKyten(string maTiepNhan, string lstMaXn, string BsKyTenMoi
            ,string NguoiThucHien,string PcThucHien,bool CapNhatUpload)
        {
            var sqlPara = new SqlParameter[]
                {
                        WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@lstMaXn",lstMaXn)
                        , WorkingServices.GetParaFromOject("@BsKyTenMoi",BsKyTenMoi)
                        , WorkingServices.GetParaFromOject("@NguoiThucHien",NguoiThucHien)
                        , WorkingServices.GetParaFromOject("@PcThucHien",PcThucHien)
                        , WorkingServices.GetParaFromOject("@CapNhatUpload",CapNhatUpload)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
              , "updKetQua_ThayDoiNguoiKyTen"
              , sqlPara);
        }
        public void CapNhat_MayChay_Ketqua(string maTiepNhan, string maXN, string IdMay, string userNhap, bool capNhatGhiChu = true)
        {
            //Ghi log
            _iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Update, userNhap, Utilities.ConvertSqlString(maTiepNhan), new List<string> { maXN }, string.Empty);
            //Edit data
            var sqlPara = new SqlParameter[]
               {
                               WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                               , WorkingServices.GetParaFromOject("@maXN", maXN)
                               , WorkingServices.GetParaFromOject("@idMayXn", IdMay)
               };
            if ((int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
              , "updXetNghiem_MayXetNghiem"
              , sqlPara) > -1)
            {
                CapNhat_CSBT(maTiepNhan, maXN, IdMay, withUpdateFlat: true, capnhatGhichu: capNhatGhiChu);
            }

        }
        public bool CapNhat_GhiChuTuDong(string matiepNhan, string maXn)
        {
            //selXetNghiem_CapNhatGhiChuTuDong
           return (int) DataProvider.ExecuteNonQuery(CommandType.StoredProcedure,
                "selXetNghiem_CapNhatGhiChuTuDong"
                , new SqlParameter[]
                {  WorkingServices.GetParaFromOject("@maTiepNhan",matiepNhan)
                        , WorkingServices.GetParaFromOject("@maXn",maXn)
                }) > -1;
        }
        public void CapNhat_Co_Ketqua(string maTiepNhan, string maXN, string co, string userNhap)
        {
            //Ghi log
            _iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Update, userNhap, Utilities.ConvertSqlString(maTiepNhan), new List<string> { maXN }, string.Empty);
            //Edit data
            var _strSQL = string.Format("update KetQua_CLS_XetNghiem set Flat = {0}, ThoiGianSuaKQ = getdate(),UploadWeb=0 \n", co);
            _strSQL += string.Format("where MaTiepNhan = '{0}' and MaXN='{1}'", Utilities.ConvertSqlString(maTiepNhan), maXN);

            if (!string.IsNullOrEmpty(_strSQL))
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_GhiChuKQ_XN(string maTiepNhan, string maXN, string ghiChu, string userNhap, string userUpdate)
        {
            string _strSQL = "";
            //Ghi log
            _iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Update, userUpdate, Utilities.ConvertSqlString(maTiepNhan), new List<string> { maXN }, string.Empty);
            //Edit data
            DataProvider.ExecuteNonQuery(CommandType.StoredProcedure,
        "updXetNghiem_GhiChu"
        , new SqlParameter[]
        {  WorkingServices.GetParaFromOject("@maTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@maXn",maXN)
                        , WorkingServices.GetParaFromOject("@UserNhap",userNhap)
                         , WorkingServices.GetParaFromOject("@GhiChu",ghiChu)
        });
        }
        public string CapNhat_KQ_XN(UpdateResultNormalInfo info)
        {
            if (info.suaKQ)
            {
                //Ghi log
                _iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Update, info.userUpdate, info.maTiepNhan
                    , new List<string> { info.maXN }, string.Empty
                    , new List<Log.Model.NewValue> {
                        new Log.Model.NewValue {colmnName = ColumnConstants.KetQuaXn_KetQua, newValue = info.ketQua }
                        , new Log.Model.NewValue {colmnName = ColumnConstants.KetQuaXn_IDMay, newValue = info.iDMayXetNghiem }
                        , new Log.Model.NewValue {colmnName = ColumnConstants.KetQuaXn_GhiChu, newValue = info.ghiChu }
                    });
            }
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@maTiepNhan",  info.maTiepNhan),
                WorkingServices.GetParaFromOject("@maXN", info.maXN),
                WorkingServices.GetParaFromOject("@ketQua", info.ketQua),
                WorkingServices.GetParaFromOject("@capnhatGhichu", info.capNhatghiChu),
                WorkingServices.GetParaFromOject("@ghiChu", info.ghiChu),
                WorkingServices.GetParaFromOject("@co", info.co),
                WorkingServices.GetParaFromOject("@userNhap", info.userNhap),
                WorkingServices.GetParaFromOject("@suaKQ", info.suaKQ),
                WorkingServices.GetParaFromOject("@lamtronNhanheso", info.round),
                WorkingServices.GetParaFromOject("@userUpdate",info.userUpdate),
                WorkingServices.GetParaFromOject("@iDMayXetNghiem", string.IsNullOrEmpty(info.iDMayXetNghiem) ? -1 :int.Parse(info.iDMayXetNghiem)),
                WorkingServices.GetParaFromOject("@modules", info.modules),
                WorkingServices.GetParaFromOject("@maXNMay", info.maXNMay),
                WorkingServices.GetParaFromOject("@updateCSBT", info.updateCsbt ),
                WorkingServices.GetParaFromOject("@chisoBT", info.chisoBT),
                WorkingServices.GetParaFromOject("@canTren",info.canTren),
                WorkingServices.GetParaFromOject("@canDuoi", info.canDuoi),
                WorkingServices.GetParaFromOject("@dvTinh", info.dvTinh),
                WorkingServices.GetParaFromOject("@dkBatThuong", info.dkBatThuong),
                WorkingServices.GetParaFromOject("@autoValid", info.tuValid),
                WorkingServices.GetParaFromOject("@uservalid", info. uservalid),
                WorkingServices.GetParaFromOject("@thoigianvalid", info.tgValid),
                WorkingServices.GetParaFromOject("@CoCapNhatKQHeSo", info.coCapnhatHeso ),
                WorkingServices.GetParaFromOject("@KetQuaHeSo",info.ketquaHeso),
                WorkingServices.GetParaFromOject("@capNhatDinhLuong", info.capnhatDinhLuong ),
                WorkingServices.GetParaFromOject("@KetQuaDinhLuong", info.ketquaDinhLuong),
                WorkingServices.GetParaFromOject("@capNhatDinhTinh", info.capnhatDinhTinh),
                WorkingServices.GetParaFromOject("@KetQuaDinhTinh", info.ketquaDinhTinh),
                WorkingServices.GetParaFromOject("@CapNhatDonviTinh", info.updateDVT ),
                WorkingServices.GetParaFromOject("@CapNhatCo", info.capnhatCoKetQua ),
                WorkingServices.GetParaFromOject("@CoKetQua", info.coKetQua),
                WorkingServices.GetParaFromOject("@chisoBTCanhBao", info.chisoBTCanhBao),
                WorkingServices.GetParaFromOject("@canTrenCanhBao",info.canTrenCanhBao),
                WorkingServices.GetParaFromOject("@canDuoiCanhBao", info.canDuoiCanhBao),
                WorkingServices.GetParaFromOject("@CoCanhBao",info.coCanhBao),
                WorkingServices.GetParaFromOject("@QCOut", info.Qcout),
                WorkingServices.GetParaFromOject("@HesoQuyDoi", info.Hesoquydoi),
                WorkingServices.GetParaFromOject("@KetQuaQuiDoi",info.Ketquaquidoi),
                WorkingServices.GetParaFromOject("@KetQuaDTQuiDoi", info.Ketquadtquidoi),
                WorkingServices.GetParaFromOject("@DVTQuiDoi",info.Donviquidoi),
                WorkingServices.GetParaFromOject("@CSBTQuiDoi", info.Csbtquidoi)
        };
            return ((int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upKetQuaXetNghiem", sqlPara)).ToString();
        }
        public string CapNhat_ThongTinMayXn_XnChinh(string maTiepNhan, bool forAnalyzer = false)
        {
            string sql = string.Format("Exec updCapNhat_ThongTinMay_XNChinh_TheoMaTiepNhan @maTiepNhan = '{0}'", maTiepNhan);
            if (forAnalyzer)
                return sql;
            else
                return ((int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updCapNhat_ThongTinMay_XNChinh_TheoMaTiepNhan"
                    , new SqlParameter[] { WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan) })).ToString();
        }
        public int UpdateNguoiDoiChieu(string maTiepNhan, string maXn, string nguoiDoiChieu, string tgDoichieu)
        {
            var sqlPara = new SqlParameter[]
                  {
                        WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                        ,WorkingServices.GetParaFromOject("@maXn",maXn )
                        ,WorkingServices.GetParaFromOject("@NguoiDoiChieu",string.IsNullOrEmpty(nguoiDoiChieu)?(object)DBNull.Value: nguoiDoiChieu )
                        ,WorkingServices.GetParaFromOject("@TGDoiChieu",string.IsNullOrEmpty(tgDoichieu)?(object)DBNull.Value: tgDoichieu )
                  };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "udpXetNghiem_CapNhatNguoiDoiChieuKQ"
             , sqlPara);
        }
        public int UpdateDienGiai_DeNghi_XN(string maTiepNhan, string maXn, string diengiai, string denghi)
        {
            var sqlPara = new SqlParameter[]
                  {
                      
                        WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                        ,WorkingServices.GetParaFromOject("@maXn",maXn )
                        ,WorkingServices.GetParaFromOject("@DienGiai", diengiai)
                        ,WorkingServices.GetParaFromOject("@DeNghi", denghi)
                  };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "udpXetNghiem_CapNhatDienGiai_DeNghiXetNghiem"
             , sqlPara);
        }
        public void XacNhan_KQ_XN(string maTiepNhan, string maXn, string trangThai, bool valid
            , string nguoiXn, bool xacNhanDe, int layNguoiThucHien)
        {
            var sqlPara = new SqlParameter[]
              {
                   WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                   ,WorkingServices.GetParaFromOject("@maXn",maXn )
                   ,WorkingServices.GetParaFromOject("@trangThai", trangThai)
                   ,WorkingServices.GetParaFromOject("@valid", valid)
                   ,WorkingServices.GetParaFromOject("@nguoiXn", nguoiXn)
                   , WorkingServices.GetParaFromOject("@xacNhanDe", xacNhanDe)
                   , WorkingServices.GetParaFromOject("@layNguoiThucHien", layNguoiThucHien) 
              };
            var ds = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "udpXacNhanKetQua"
             , sqlPara);
        }
        public int CapNhat_In_KQ_XN(string maTiepNhan, string nguoiXN, bool xacNhanketqua)
        {
            var sqlPara = new SqlParameter[]
          {
                   WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                   ,WorkingServices.GetParaFromOject("@nguoiThucHien",nguoiXN )
                   ,WorkingServices.GetParaFromOject("@xacnhanketqua", xacNhanketqua)
          };
            var ds = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "updCapNhatThongTin_DaInKetQua"
             , sqlPara);
            return ds;
        }
        public bool CapNhatIDMauKetQua(string matiepnhan, string maXn)
        {
            var sqlPara = new SqlParameter[]
         {
                   WorkingServices.GetParaFromOject("@maTiepNhan", matiepnhan)
                   ,WorkingServices.GetParaFromOject("@maXn",maXn )

         };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "udpLoaiMauIn_KetQua"
             , sqlPara) > -1;

        }
        public DataTable DataIDMauKetQua(string matiepnhan, string maBoPhan)
        {
            var sqlPara = new SqlParameter[]
         {
                   WorkingServices.GetParaFromOject("@maTiepNhan", matiepnhan)
                   ,WorkingServices.GetParaFromOject("@BoPhanAllow",maBoPhan )

         };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selKetQua_DSIDmauKetQua"
             , sqlPara).Tables[0];

        }
        public bool CapNhatPrintOut_WithoutReportType(string maTiepnhan, string someTestIn
            , string categoryPrint, bool isPrint, string nguoiIn, string boPhan
            , bool tuXacNhan, bool xacNhanDe, string kyTen, int idLayNguoiThucHien)
        {
            var sqlPara = new SqlParameter[]
            {
                   WorkingServices.GetParaFromOject("@maTiepnhan", maTiepnhan)
                   ,WorkingServices.GetParaFromOject("@someTestIn",Utilities.ReplaceInStringForParameter(someTestIn))
                   ,WorkingServices.GetParaFromOject("@categoryPrint", Utilities.ReplaceInStringForParameter(categoryPrint) )
                   ,WorkingServices.GetParaFromOject("@isPrint", isPrint)
                   ,WorkingServices.GetParaFromOject("@nguoiIn", nguoiIn)
                   ,WorkingServices.GetParaFromOject("@boPhan", Utilities.ReplaceInStringForParameter(boPhan))
                   ,WorkingServices.GetParaFromOject("@tuXacNhan", tuXacNhan)
                   ,WorkingServices.GetParaFromOject("@xacNhanDe", xacNhanDe)
                   ,WorkingServices.GetParaFromOject("@kyTen", kyTen)
                   ,WorkingServices.GetParaFromOject("@idLayNguoiThucHien", idLayNguoiThucHien)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "udpCapNhatDaIn_KhongMauReport"
             , sqlPara) > -1;
        }
        public bool CapNhatPrintOut_WithReportType(string maTiepnhan, string reportType
            , bool isPrint, string nguoiIn, bool tuXacNhan, string someTestIn, bool xacNhanDe, string kyTen, int idLayNguoiThucHien)
        {
            /*
            @maTiepnhan varchar(20)
           , @reportType varchar(50)
           , @isPrint bit
           , @nguoiIn varchar(20)
           , @tuXacNhan bit
           , @someTestIn varchar(250)
           , @xacNhanDe bit
            */
            var sqlPara = new SqlParameter[]
            {
                   WorkingServices.GetParaFromOject("@maTiepnhan", maTiepnhan)
                   ,WorkingServices.GetParaFromOject("@reportType",reportType )
                   ,WorkingServices.GetParaFromOject("@isPrint", isPrint)
                   ,WorkingServices.GetParaFromOject("@nguoiIn", nguoiIn)
                   ,WorkingServices.GetParaFromOject("@tuXacNhan", tuXacNhan)
                   ,WorkingServices.GetParaFromOject("@someTestIn", Utilities.ReplaceInStringForParameter(someTestIn))
                   ,WorkingServices.GetParaFromOject("@xacNhanDe", xacNhanDe)
                   ,WorkingServices.GetParaFromOject("@kyTen", kyTen)
                   ,WorkingServices.GetParaFromOject("@idLayNguoiThucHien", idLayNguoiThucHien)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "udpCapNhatDaIn_CoMauIn"
             , sqlPara) > -1;
        }
        public bool CapNhatValid_WithReportType(string maTiepnhan, string reportType, bool isValid, string nguoiValid, string category)
        {
            var sqlQuery = string.Format("update ketqua_cls_xetnghiem set XacNhanKQ = {0}, NguoiXacNhan = '{3}',manvthuchien = (select his_id from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN where MaNhanVien = (select MaNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung where MaNguoiDung = '{3}')) where (([matiepnhan] = '{1}' {2}) or (IDMauKetQua is null and MaNhomCLS in (select MaNhomCLS from ketqua_cls_xetnghiem where [matiepnhan] = '{1}' {2})) ) and (KetQua is not null or XNChinh =1) and XacNhanKQ = {4} and [matiepnhan] = '{1}' and MaNhomCLS in ({5})"
                , isValid ? "1" : "0"
                , maTiepnhan
                , (string.IsNullOrEmpty(reportType) || reportType.Equals(ReportResultTemplateConstant.Mau_TC_ThongThuong, StringComparison.OrdinalIgnoreCase) ? "" : string.Format(" and IDMauKetQua in({0})", (reportType.Contains(",") ? reportType : "'" + reportType + "'")))
                , nguoiValid
                , isValid ? "0" : "1"
                , category);// cái isvalid này để tránh trường hợp xác nhận đè
            return DataProvider.ExecuteQuery(sqlQuery);
        }
        public bool CapNhatValid_WithCondit(string maTiepnhan, string lisMaXN, bool isValid, string nguoiValid)
        {
            var sqlQuery = string.Format("update ketqua_cls_xetnghiem set XacNhanKQ = {0}, NguoiXacNhan = '{3}',manvthuchien = (select his_id from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN where MaNhanVien = (select MaNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung where MaNguoiDung = '{3}')) where [matiepnhan] = '{1}' {2} and (KetQua is not null or XNChinh =1)  and XacNhanKQ = {4}"
                , isValid ? "1" : "0", maTiepnhan
                , (string.IsNullOrEmpty(lisMaXN) ? "" : string.Format(" and MaXn in({0})", (lisMaXN.Contains(",") ? lisMaXN : (lisMaXN.Trim()[0].ToString() == "'" ? lisMaXN : "'" + lisMaXN + "'"))))
                , nguoiValid
                , isValid ? "0" : "1");// cái này để tránh trường hợp xác nhận đè
            return DataProvider.ExecuteQuery(sqlQuery);
        }
        public bool CapNhat_GhiChuHenTraKQ(string matTiepNhan, string maNhom, string maXn, bool cotKetQua, string noidung, DateTime tgtraKQ,string TGCoKQ)
        {
            StringBuilder sb = new StringBuilder();
            sb = new StringBuilder();
            sb.AppendFormat("Update kq set kq.{0} = case when exists (select dm.MaXN from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dm where dm.HenTraVaoketQua = 1 and dm.MaXN = kq.maXN) then {1} else null end ", (cotKetQua ? "KetQua" : "GhiChu"), (string.IsNullOrEmpty(noidung) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(noidung))));
            sb.AppendFormat("\n,kq.GioHenTraKetQua = '{0}'", tgtraKQ.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendFormat("\n,kq.TGCoKetQua = '{0}'", TGCoKQ);
            sb.AppendFormat("\n from ketqua_cls_xetnghiem kq");
            sb.AppendFormat("\nwhere kq.MaTiepNhan = '{0}' and kq.KetQua is null ", matTiepNhan);
            if (!string.IsNullOrEmpty(maNhom))
                sb.AppendFormat("\n and kq.MaNhomCLS = '{0}'", maNhom);
            if (!string.IsNullOrEmpty(maXn))
                sb.AppendFormat("\n and kq.MaXN = '{0}'", maXn);
           
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public DataTable Load_ChiDinhXetNghiem(string _MaTiepNhan, string maXn = "")
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select * from KetQua_CLS_XetNghiem where matiepnhan='{0}'", _MaTiepNhan);
            if (!string.IsNullOrEmpty(maXn))
            {
                sql.AppendFormat(" and MaXN ='{0}'", maXn);
            }
            return DataProvider.ExecuteDataset(CommandType.Text, sql.ToString()).Tables[0];
        }
        public bool Ins_KetQua_LabBlood(string maTiepNhan, string lstXN)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@lstMaXN", lstXN)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
            , "LabBlood_ins_KetQuaTuIMS"
            , sqlPara) > -1;
        }
        public bool Del_KetQua_LabBlood(string maTiepNhan, string lstXN)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@lstMaXN", lstXN)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
            , "LabBlood_del_KetQuaTuIMS"
            , sqlPara) > -1;
        }
        public bool Update_BnTruyenMau_KQNhomMau(string sid, string abo, string rh, string userU)
        {
            var para = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@sid",sid),
                    WorkingServices.GetParaFromOject("@PGroupIDTest",abo),
                    WorkingServices.GetParaFromOject("@PRhTest",rh),
                    WorkingServices.GetParaFromOject("@UserUpdateTest",userU)
                };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "LabBlood_upd_BenhNhan_KetQua", para) > -1;
        }
        public DataTable DuLieuIn_XN(DataTable dtThongTin, int index, bool layMailTheoBn, string userSign, string xnIn, bool title, DateTime? ngayInKQ
            , string[] userWorkPlace, string reportType, bool reprint, TestType.EnumTestType[] testType, string inCategory, bool TgInDauTien = false
            , bool sinhHocPhanTu = false, string maCaptren = "", bool dulieuIn = false
            , string inBoPhan = "", bool chiInCoKetQua = false, string userPermision = ""
            , bool huyetDo = false
            , TestType.EnumTestType idLoaiXnHuyetDo = TestType.EnumTestType.HuyetDo
            , string soPhieuChiDinh = "", bool layTienSu = false)
        {
            if (dtThongTin == null || dtThongTin.Rows.Count <= 0 || index == -1) return null;

            var maTiepNhan = dtThongTin.Rows[index]["MaTiepNhan"].ToString().Trim();
            var tgNhap = DateTime.Parse(dtThongTin.Rows[index]["ThoiGianNhap"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            var maBn = dtThongTin.Rows[index]["MaBN"].ToString().Trim();
            var bangTnJoin = string.Empty;
            var bangKqxnJoin = string.Empty;
            int printtitle = title ? 1 : 0;

            var sb = new StringBuilder();
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
                "selXetNghiem_KetQuaThuongQui_DuLieuIn"
                , new SqlParameter[]
                {
                        WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@layTienSu",layTienSu)
                        , WorkingServices.GetParaFromOject("@tgNhap",tgNhap)
                        , WorkingServices.GetParaFromOject("@maBn",maBn)
                        , WorkingServices.GetParaFromOject("@bangTnJoin",bangTnJoin)
                        , WorkingServices.GetParaFromOject("@bangKqxnJoin",bangKqxnJoin)
                        , WorkingServices.GetParaFromOject("@layMailTheoBn",layMailTheoBn)
                        , WorkingServices.GetParaFromOject("@userSign",userSign)
                        , WorkingServices.GetParaFromOject("@xnIn",Utilities.ReplaceInStringForParameter(xnIn))
                        , WorkingServices.GetParaFromOject("@withTitle",title)
                        , WorkingServices.GetParaFromOject("@ngayInKQ",(ngayInKQ == null ?(object)DBNull.Value:ngayInKQ))
                        , WorkingServices.GetParaFromOject("@userWorkPlace",Utilities.ConvertStrinArryToInClauseSQL(userWorkPlace, false))
                        , WorkingServices.GetParaFromOject("@reportType",string.IsNullOrEmpty(reportType) ? "------": reportType.Replace("'",""))
                        , WorkingServices.GetParaFromOject("@reprint",reprint)
                        , WorkingServices.GetParaFromOject("@testType",Utilities.ConvertStrinArryToInClauseSQL(testType.Select(a=>((int)a).ToString()).ToArray(), false) )
                        , WorkingServices.GetParaFromOject("@inCategory",Utilities.ReplaceInStringForParameter(inCategory))
                        , WorkingServices.GetParaFromOject("@tgInDauTien",TgInDauTien)
                        , WorkingServices.GetParaFromOject("@sinhHocPhanTu",sinhHocPhanTu)
                        , WorkingServices.GetParaFromOject("@maCaptren",maCaptren)
                        , WorkingServices.GetParaFromOject("@dulieuIn",dulieuIn)
                        , WorkingServices.GetParaFromOject("@inBoPhan",Utilities.ReplaceInStringForParameter(inBoPhan) )
                        , WorkingServices.GetParaFromOject("@chiInCoKetQua",chiInCoKetQua)
                        , WorkingServices.GetParaFromOject("@userallow",string.IsNullOrEmpty(userPermision) ? (object)DBNull.Value: userPermision)
                        , WorkingServices.GetParaFromOject("@huyetDo",huyetDo)
                        , WorkingServices.GetParaFromOject("@idLoaiXnHuyetDo",(int)idLoaiXnHuyetDo )
                        , WorkingServices.GetParaFromOject("@SoPhieuChiDinh",string.IsNullOrEmpty(soPhieuChiDinh) ? (object)DBNull.Value: soPhieuChiDinh)
                });
            if (ds != null)
            {
                return GhepKetQuaTienSu(ds.Tables[0], layTienSu, maBn, maTiepNhan, tgNhap);
            }
            else
                return new DataTable();
        }
        public DataTable DuLieuKetQua_XN(DataTable dtThongTin, int index, bool layMailTheoBn, string userSign, string xnIn, bool title, DateTime? ngayInKQ
             , string[] userWorkPlace, string reportType, bool reprint, TestType.EnumTestType[] testType, string inCategory, bool TgInDauTien = false
             , bool sinhHocPhanTu = false, string maCaptren = "", bool dulieuIn = false
             , string inBoPhan = "", bool chiInCoKetQua = false, string userPermision = ""
             , bool huyetDo = false
             , TestType.EnumTestType idLoaiXnHuyetDo = TestType.EnumTestType.HuyetDo
             , string soPhieuChiDinh = "")
        {
            if (dtThongTin == null || dtThongTin.Rows.Count <= 0 || index == -1) return null;

            var maTiepNhan = dtThongTin.Rows[index]["MaTiepNhan"].ToString().Trim();
            var tgNhap = DateTime.Parse(dtThongTin.Rows[index]["ThoiGianNhap"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            var maBn = dtThongTin.Rows[index]["MaBN"].ToString().Trim();
            var bangTnJoin = string.Empty;
            var bangKqxnJoin = string.Empty;
            var layTienSu = true;
            //if (layTienSu)
            //    Get_MaBN_XNTruoc(maBn, maTiepNhan, tgNhap, ref bangTnJoin, ref bangKqxnJoin);
            int printtitle = title ? 1 : 0;

            var sb = new StringBuilder();
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
                "selXetNghiem_KetQuaThuongQui_Form"
                , new[]
                {
                        WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@layTienSu",layTienSu)
                        , WorkingServices.GetParaFromOject("@tgNhap",tgNhap)
                        , WorkingServices.GetParaFromOject("@maBn",maBn)
                        , WorkingServices.GetParaFromOject("@bangTnJoin",bangTnJoin)
                        , WorkingServices.GetParaFromOject("@bangKqxnJoin",bangKqxnJoin)
                        , WorkingServices.GetParaFromOject("@layMailTheoBn",layMailTheoBn)
                        , WorkingServices.GetParaFromOject("@userSign",userSign)
                        , WorkingServices.GetParaFromOject("@xnIn",Utilities.ReplaceInStringForParameter(xnIn))
                        , WorkingServices.GetParaFromOject("@withTitle",title)
                        , WorkingServices.GetParaFromOject("@ngayInKQ",(ngayInKQ == null ?(object)DBNull.Value:ngayInKQ))
                        , WorkingServices.GetParaFromOject("@userWorkPlace",Utilities.ConvertStrinArryToInClauseSQL(userWorkPlace, false))
                        , WorkingServices.GetParaFromOject("@reportType",string.IsNullOrEmpty(reportType) ? "------": reportType.Replace("'",""))
                        , WorkingServices.GetParaFromOject("@reprint",reprint)
                        , WorkingServices.GetParaFromOject("@testType",Utilities.ConvertStrinArryToInClauseSQL(testType.Select(a=>((int)a).ToString()).ToArray(), false) )
                        , WorkingServices.GetParaFromOject("@inCategory",Utilities.ReplaceInStringForParameter(inCategory))
                        , WorkingServices.GetParaFromOject("@tgInDauTien",TgInDauTien)
                        , WorkingServices.GetParaFromOject("@sinhHocPhanTu",sinhHocPhanTu)
                        , WorkingServices.GetParaFromOject("@maCaptren",maCaptren)
                        , WorkingServices.GetParaFromOject("@dulieuIn",dulieuIn)
                        , WorkingServices.GetParaFromOject("@inBoPhan",Utilities.ReplaceInStringForParameter(inBoPhan) )
                        , WorkingServices.GetParaFromOject("@chiInCoKetQua",chiInCoKetQua)
                        , WorkingServices.GetParaFromOject("@userallow",string.IsNullOrEmpty(userPermision) ? (object)DBNull.Value: userPermision)
                        , WorkingServices.GetParaFromOject("@huyetDo",huyetDo)
                        , WorkingServices.GetParaFromOject("@idLoaiXnHuyetDo",(int)idLoaiXnHuyetDo)
                        , WorkingServices.GetParaFromOject("@SoPhieuChiDinh",string.IsNullOrEmpty(soPhieuChiDinh) ? (object)DBNull.Value: soPhieuChiDinh)
                });
            if (ds != null)
            {
                return GhepKetQuaTienSu(ds.Tables[0], layTienSu, maBn, maTiepNhan, tgNhap);
            }
            else
                return new DataTable();
        }
        private DataTable GhepKetQuaTienSu(DataTable dataResult, bool layTienSu, string maBn, string maTiepNhan, string tgNhap)
        {
            if (dataResult.Columns.Contains("MaTienSu"))
                dataResult.Columns.Remove("MaTienSu");
            dataResult.Columns.Add("MaTienSu", typeof(string));
            if (dataResult.Columns.Contains("KQTienSu"))
                dataResult.Columns.Remove("KQTienSu");
            dataResult.Columns.Add("KQTienSu", typeof(string));
            if (dataResult.Columns.Contains("TGCoKQTienSu"))
                dataResult.Columns.Remove("TGCoKQTienSu");
            dataResult.Columns.Add("TGCoKQTienSu", typeof(DateTime));
            if (dataResult.Columns.Contains("FlatTienSu"))
                dataResult.Columns.Remove("FlatTienSu");
            dataResult.Columns.Add("FlatTienSu", typeof(int));
            if (dataResult.Columns.Contains("GhiChuTienSu"))
                dataResult.Columns.Remove("GhiChuTienSu");
            dataResult.Columns.Add("GhiChuTienSu", typeof(string));
            if (dataResult.Columns.Contains("NgayDuyetTienSu"))
                dataResult.Columns.Remove("NgayDuyetTienSu");
            dataResult.Columns.Add("NgayDuyetTienSu", typeof(DateTime));

            if (layTienSu && !string.IsNullOrEmpty(maBn))
            {
                var dataKQMaBN = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selKetQuaXetnghiem_TheomaBenhNhan", new SqlParameter[] { WorkingServices.GetParaFromOject("@MaBN", maBn) }).Tables[0];
                if (dataKQMaBN.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataResult.Rows)
                    {
                        var maxn = dr["MAXN"].ToString().Trim();
                        var foundData = WorkingServices.SearchResult_OnDatatable(dataKQMaBN, string.Format("MaXN = '{0}' and MaTiepNhan <> '{1}' and ThoiGianNhap < '{2}'", maxn, maTiepNhan, tgNhap));
                        if (foundData.Rows.Count > 0)
                        {
                            foundData.DefaultView.Sort = "ThoiGianNhap DESC";
                            foundData = foundData.DefaultView.ToTable();
                            //,A.MaTiepNhan as MaTienSu, A.KetQua as KQTienSu, A.ThoiGianNhapKQ as TGCoKQTienSu
                            //, A.Flat as FlatTienSu, A.GhiChu as GhiChuTienSu, A.thoigianxacnhankq as NgayDuyetTienSu
                            dr["MaTienSu"] = foundData.Rows[0]["MaTiepNhan"];
                            dr["KQTienSu"] = foundData.Rows[0]["KetQua"];
                            if (!string.IsNullOrEmpty(foundData.Rows[0]["ThoiGianNhapKQ"].ToString()))
                                dr["TGCoKQTienSu"] = foundData.Rows[0]["ThoiGianNhapKQ"];
                            dr["FlatTienSu"] = foundData.Rows[0]["Flat"];
                            dr["GhiChuTienSu"] = foundData.Rows[0]["GhiChu"];
                            if (!string.IsNullOrEmpty(foundData.Rows[0]["thoigianxacnhankq"].ToString()))
                                dr["NgayDuyetTienSu"] = foundData.Rows[0]["thoigianxacnhankq"];
                        }
                    }
                    dataResult.AcceptChanges();
                }
            }
            dataResult.DefaultView.Sort = "ThuTuNhom asc, SapXep asc, MaXN asc";
            return dataResult.DefaultView.ToTable();
        }
        public DataTable DuLieuXetNghiemCanhBao(string maTiepNhan)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select k.maXn,k.TenXn, k.ketQua, cast ((case when k.Flat > 1 then 1 else 0 end) as bit) as BatThuong, k.CSBT ");
            sb.Append("\nfrom KetQua_CLS_XetNghiem(nolock) k inner join BenhNhan_TiepNhan(nolock) t on k.MaTiepNhan = t.MaTiepNhan");
            sb.Append("\ninner join BenhNhan_CLS_XetNghiem(nolock)  tx on tx.MaTiepNhan = t.MaTiepNhan");
            sb.Append("\ninner join DM_XetNghiem(nolock) xn on xn.MaXN = k.MaXN");
            sb.AppendFormat("\n where k.MaTiepNhan = '{0}' and xn.BatCanhBaoBatThuong = 1", Utilities.ConvertSqlString(maTiepNhan));
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }
        public void CapNhat_KetLuan_XN(string maTiepNhan, string ketLuan, string ghiChu)
        {

            ketLuan = string.IsNullOrEmpty(ketLuan) ? "NULL" : "N'" + Utilities.ConvertSqlString(ketLuan) + "'";
            ghiChu = string.IsNullOrEmpty(ghiChu) ? "NULL" : "N'" + Utilities.ConvertSqlString(ghiChu) + "'";

            string _strSQL = string.Format("update BenhNhan_CLS_XetNghiem set KetLuanXN = {0},ghichuxn={1}  where MaTiepNhan = '{2}'", ketLuan, ghiChu, Utilities.ConvertSqlString(maTiepNhan));
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public int CapNhat_GhiChu_XNTheoBoPhan(string maTiepNhan, string maBoPhan, string ghiChu, string userNhap)
        {
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
            ,WorkingServices.GetParaFromOject("@MaBoPhan", maBoPhan)
            ,WorkingServices.GetParaFromOject("@GhiChu", ghiChu)
             ,WorkingServices.GetParaFromOject("@UserNhap", userNhap)
            };
            return (int) DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "updBophan_GhiChu"
             , sqlPara);
        }
        public void CapNhat_SauChiDinh_XetNghiem(string maTiepNhan, string tenTruong, bool co, string user)
        {
            var sqlQuery = "update BenhNhan_CLS_XetNghiem set " + tenTruong + " = " +
                             (co
                                 ? "1" +
                                   (!string.IsNullOrWhiteSpace(user)
                                       ? ",UserINXN= case when len(userinXN) > 0 then UserInXN + ',' + '" + user +
                                         "' else '" + user + "' end , LanInXN= LanInXN + 1  "
                                       : "")
                                 : "0") + " where MaTiepNhan = '" + Utilities.ConvertSqlString(maTiepNhan) + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void CapNhat_PhatHanhKQXN(string maTiepNhan, bool bPhatHanh, string user)
        {
            var sqlQuery = "update BenhNhan_CLS_XetNghiem set phathanhkqlenweb = " +
                             (bPhatHanh ? "1" : "0") + ", ngayphathanhketqua=getdate(), userphathanh='" + user + "' where MaTiepNhan = '" + Utilities.ConvertSqlString(maTiepNhan) + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public bool CapNhatKetQuaXN_TheoLoaiXN(string maTiepNhan, string ketQua, int enumLoaiXN)
        {
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@MatiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@KetQua", ketQua),
                WorkingServices.GetParaFromOject("@LoaiXetNghiem", enumLoaiXN)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
              , "udpKetQuaXetNghiem_TheoLoaiXn"
              , sqlPara) > 0;
        }
        public int CapNhat_NoiKiemTraChatLuong(string maTiepNhan, string maXN, string noikiemTraChatLuong)
        {
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@maTiepNhan",  maTiepNhan),
                WorkingServices.GetParaFromOject("@maXN", maXN),
                WorkingServices.GetParaFromOject("@NoiKiemTraChatLuong", string.IsNullOrEmpty(noikiemTraChatLuong) ?(object)DBNull.Value: noikiemTraChatLuong)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_CapNhat_NoiKiemTraChatLuong", sqlPara);
        }
        public DataTable Data_DanhSach_HuyXacNhanHIS(string maTiepNhan, string lstXN, string userID)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
                    "selThongTin_HuyXacNhanHIS"
                    , new SqlParameter[]
                    {
                        WorkingServices.GetParaFromOject("@maTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@lstMaXn",lstXN)
                        , WorkingServices.GetParaFromOject("@userThuHien",userID)
                    });
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public bool Check_HaveResult_XN(string maTiepNhan, string maXn)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
                   "selCheck_XnCoKetQua"
                   , new SqlParameter[]
                   {  WorkingServices.GetParaFromOject("@maTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@maXn",maXn)
                   });
            if (ds != null)
                return ds.Tables[0].Rows.Count > 0;
            else
                return false;
        }
        public bool Check_HaveResult_For_XNChinh(string maTiepNhan, string profileId)
        {
            string strSQL = "select top 1 * from KetQua_CLS_XetNghiem where MaTiepNhan ='" + Utilities.ConvertSqlString(maTiepNhan) + "' and nullif(rtrim(KetQua),'') is not null and ProfileID ='" + profileId + "'";
            if (DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Get_GhiChuCuaXetNghiem(string maTiepNhan, string maXn)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
                   "selXetNghiem_GhiChu"
                   , new SqlParameter[]
                   {  WorkingServices.GetParaFromOject("@maTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@maXn",maXn)
                   });
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return StringConverter.ToString(ds.Tables[0].Rows[0]["GhiChu"]);
            }

            return string.Empty;
        }
        public ThongTinKetQua Info_ThongTinKetQua(string maTiepNhan, string maXn)
        {
            var obj = new ThongTinKetQua();
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
           "selXetNghiem_GhiChu"
           , new SqlParameter[]
           {  WorkingServices.GetParaFromOject("@maTiepNhan",maTiepNhan)
                            , WorkingServices.GetParaFromOject("@maXn",maXn)
           });
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var dr = ds.Tables[0].Rows[0];
                    WorkingServices.Get_InfoForObject(obj, dr);
                }
            }
            return obj;
        }
        public bool Delete_ChiDinhCLS_XN(string maTiepNhan, string maXn, string profileId, string userDelete, bool delPatient = false)
        {
            try
            {
                StringBuilder sqlQuery = new StringBuilder();
                var iCount = 0;
                if (!delPatient)
                {

                    //Thêm thao tac ghi log

                    _iWorkingLog.WriteLog_BenhNhan_CLS_XetNghiem(LogActionId.Delete, userDelete, maTiepNhan);

                    if (string.IsNullOrEmpty(profileId))
                    {
                        sqlQuery.Append("insert {{TPH_Standard}}_Analyzer.dbo.h_ordercancel(ngayluu, thoigianchidinh, mabn, sid, tenbn, namsinh, gioitinh, diachi, maxn, tenxetnghiem, maxnmay, idmay, loaimau, statusrun)");
                        sqlQuery.AppendFormat("select distinct ngayluu, '{2:yyyy/MM/dd HH:mm}' as thoigianchidinh, mabn, sid, tenbn, namsinh, gioitinh, diachi, maxn, tenxetnghiem, maxnmay, idmay, loaimau,'T2' as statusrun from {{TPH_Standard}}_Analyzer.dbo.h_ordertest where mabn='{0}' and ( MaXN = '{1}' or MaXN in (select MaXN from  KetQua_CLS_XetNghiem x1 where x1.MaTiepNhan = '{0}' and x1.macaptren is not null and x1.macaptren in (select x2.maxn_his from KetQua_CLS_XetNghiem x2 where x2.MaTiepNhan = '{0}' and x2.MaXN = '{1}'))) and thoigiandownload is not null;\n", maTiepNhan, maXn, DateTime.Now);

                        sqlQuery.AppendFormat("delete KetQua_CLS_XetNghiem where MaTiepNhan ='{0}' {1} and DaThuTien = 0 "
                            , maTiepNhan
                            , string.IsNullOrEmpty(maXn) ? "" : string.Format(" and (MaXN = '{0}' or (macaptren is not null and macaptren in (select x2.maxn_his from KetQua_CLS_XetNghiem x2 where x2.MaTiepNhan = '{1}' and x2.MaXN = '{0}')))", maXn, maTiepNhan)
                            );
                        ResultLog(maTiepNhan, LogActionId.Delete,new List<string> { maXn }, string.Empty, userDelete);
                        iCount = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
                        iCount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delKetQua_XetNghiem_GhiChu", new SqlParameter[] { WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan) });
                    }
                    else
                    {
                        sqlQuery.Append("insert {{TPH_Standard}}_Analyzer.dbo.h_ordercancel(ngayluu, thoigianchidinh, mabn, sid, tenbn, namsinh, gioitinh, diachi, maxn, tenxetnghiem, maxnmay, idmay, loaimau, statusrun)");
                        sqlQuery.AppendFormat("select distinct ngayluu, '{2:yyyy/MM/dd HH:mm}' as thoigianchidinh, mabn, sid, tenbn, namsinh, gioitinh, diachi, maxn, tenxetnghiem, maxnmay, idmay, loaimau,'T2' as statusrun from {{TPH_Standard}}_Analyzer.dbo.h_ordertest where mabn='{0}' and maxn in(select maxn from KetQua_CLS_XetNghiem where MaTiepNhan='{0}' and ProfileID='{1}') and thoigiandownload is not null;\n", maTiepNhan, profileId, DateTime.Now);

                        sqlQuery.Append("delete KetQua_CLS_XetNghiem where MaTiepNhan ='" + maTiepNhan + "' and ProfileID ='" + profileId + "' and DaThuTien = 0");
                        ResultLog(maTiepNhan, LogActionId.Delete,new List<string>(), profileId, userDelete);
                        iCount = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
                        iCount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delKetQua_XetNghiem_GhiChu", new SqlParameter[] { WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan) });
                    }
                }
                else
                {
                    sqlQuery.Append("insert {{TPH_Standard}}_Analyzer.dbo.h_ordercancel(ngayluu, thoigianchidinh, mabn, sid, tenbn, namsinh, gioitinh, diachi, maxn, tenxetnghiem, maxnmay, idmay, loaimau, statusrun)");
                    sqlQuery.AppendFormat("select distinct ngayluu, '{1:yyyy/MM/dd HH:mm}' as thoigianchidinh, mabn, sid, tenbn, namsinh, gioitinh, diachi, maxn, tenxetnghiem, maxnmay, idmay, loaimau,'O2' as statusrun from {{TPH_Standard}}_Analyzer.dbo.h_ordertest where mabn='{0}' and maxn in(select maxn from KetQua_CLS_XetNghiem where MaTiepNhan='{0}') and thoigiandownload is not null;\n", maTiepNhan, DateTime.Now);

                    sqlQuery.Append("delete KetQua_CLS_XetNghiem where MaTiepNhan ='" + maTiepNhan + "' and DaThuTien = 0");
                    ResultLog(maTiepNhan, LogActionId.Delete, new List<string>(), profileId, userDelete);
                    iCount = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString());
                    iCount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delKetQua_XetNghiem_GhiChu", new SqlParameter[] { WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan) });
                }
                if (iCount > -1)
                    iCount = DeleteCategoryOfTest(maTiepNhan);

                iCount = (int)DataProvider.ExecuteNonQuery(CommandType.Text, "Delete BenhNhan_CLS_XetNghiem where MaTiepNhan ='" + maTiepNhan + "' and (select count (*) from KetQua_CLS_XetNghiem where  MaTiepNhan ='" + maTiepNhan + "') = 0");

                return iCount > -1;
            }
            catch
            {
                return false;
            }
        }
        public DataTable DanhSachBenhNhanInTuDong(DieuKienInTuDong dieuKien)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@PCName", dieuKien.PCName)
                , WorkingServices.GetParaFromOject("@AllowMaBoPhan", dieuKien.ListAllowBoPhan)
                , WorkingServices.GetParaFromOject("@TuNgay", dieuKien.TuNgay??(object)DBNull.Value)
                , WorkingServices.GetParaFromOject("@DenNgay", dieuKien.DenNgay??(object)DBNull.Value)
                , WorkingServices.GetParaFromOject("@TuBarcode", string.IsNullOrEmpty(dieuKien.TuBarCode)?(object)DBNull.Value: dieuKien.TuBarCode)
                , WorkingServices.GetParaFromOject("@DenBarcode", string.IsNullOrEmpty(dieuKien.DenBarcode)?(object)DBNull.Value: dieuKien.DenBarcode)
                , WorkingServices.GetParaFromOject("@XacNhanBenhNhan", dieuKien.XacNhanBenhNhan)
                , WorkingServices.GetParaFromOject("@XacNhanKhoa", dieuKien.XacNhanTheoKhoa)
                , WorkingServices.GetParaFromOject("@ListKhoaChiDinh", string.IsNullOrEmpty(dieuKien.ListKhoaChiDinh)?(object)DBNull.Value: dieuKien.ListKhoaChiDinh)
                , WorkingServices.GetParaFromOject("@ListKhoaHienThoi", string.IsNullOrEmpty(dieuKien.ListKhoaHienthoi)?(object)DBNull.Value: dieuKien.ListKhoaHienthoi)
                , WorkingServices.GetParaFromOject("@ForUpdate", dieuKien.DungChoCapNhat)
                , WorkingServices.GetParaFromOject("@ListDoiTuong", string.IsNullOrEmpty(dieuKien.ListAllowDoiTuong)?(object)DBNull.Value: dieuKien.ListAllowDoiTuong)
                , WorkingServices.GetParaFromOject("@UserValid", string.IsNullOrEmpty(dieuKien.UserValid)?(object)DBNull.Value: dieuKien.UserValid)
                , WorkingServices.GetParaFromOject("@XacNhanTheoNhom", dieuKien.XacNhanTheoNhom)
                , WorkingServices.GetParaFromOject("@AllowMaNhom",string.IsNullOrEmpty(dieuKien.ListAllowNhom)?(object)DBNull.Value: dieuKien.ListAllowNhom)
                , WorkingServices.GetParaFromOject("@DaIn", dieuKien.DaIn == 2? (object)DBNull.Value:dieuKien.DaIn )
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selInTuDong_DanhSach", sqlPara);
            if(ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public DataTable DanhSachBenhNhanInHangLoat(DieuKienInTuDong dieuKien)
        {
            //@AllowMaBoPhan varchar(350) = null
            //, @AllowMaNhom varchar(350) = null
            //, @TuNgay datetime = null
            //, @DenNgay datetime = null
            //, @XacNhanBenhNhan bit = 0
            //, @XacNhanKhoa bit = 0
            //, @ListKhoaChiDinh varchar(max)
            //, @ListKhoaHienThoi varchar(max)
            //, @ListDoiTuong varchar(max) = null
            //, @UserValid varchar(12) = null
            //, @DaIn int = 0


            var sqlPara = new SqlParameter[]
            {
                 WorkingServices.GetParaFromOject("@AllowMaBoPhan", dieuKien.ListAllowBoPhan)
                 , WorkingServices.GetParaFromOject("@AllowMaNhom",string.IsNullOrEmpty(dieuKien.ListAllowNhom)?(object)DBNull.Value: dieuKien.ListAllowNhom)
                , WorkingServices.GetParaFromOject("@TuNgay", dieuKien.TuNgay??(object)DBNull.Value)
                , WorkingServices.GetParaFromOject("@DenNgay", dieuKien.DenNgay??(object)DBNull.Value)
                , WorkingServices.GetParaFromOject("@TuBarcode", string.IsNullOrEmpty(dieuKien.TuBarCode)?(object)DBNull.Value: dieuKien.TuBarCode)
                , WorkingServices.GetParaFromOject("@DenBarcode", string.IsNullOrEmpty(dieuKien.DenBarcode)?(object)DBNull.Value: dieuKien.DenBarcode)
                , WorkingServices.GetParaFromOject("@XacNhanBenhNhan", dieuKien.XacNhanBenhNhan)
                , WorkingServices.GetParaFromOject("@XacNhanKhoa", dieuKien.XacNhanTheoKhoa)
                , WorkingServices.GetParaFromOject("@ListKhoaChiDinh", string.IsNullOrEmpty(dieuKien.ListKhoaChiDinh)?(object)DBNull.Value: dieuKien.ListKhoaChiDinh)
                , WorkingServices.GetParaFromOject("@ListKhoaHienThoi", string.IsNullOrEmpty(dieuKien.ListKhoaHienthoi)?(object)DBNull.Value: dieuKien.ListKhoaHienthoi)
                , WorkingServices.GetParaFromOject("@ListDoiTuong", string.IsNullOrEmpty(dieuKien.ListAllowDoiTuong)?(object)DBNull.Value: dieuKien.ListAllowDoiTuong)
                , WorkingServices.GetParaFromOject("@UserValid", string.IsNullOrEmpty(dieuKien.UserValid)?(object)DBNull.Value: dieuKien.UserValid)
                , WorkingServices.GetParaFromOject("@DaIn", dieuKien.DaIn)
            };

            var ds = new DataSet();
            if (dieuKien.IdNgay == 1)
                ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selInHangLoat_DanhSach_NhanMau", sqlPara);
            else if (dieuKien.IdNgay == 2)
                ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selInHangLoat_DanhSach_DuyetKetQua", sqlPara);
            else
                ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selInHangLoat_DanhSach", sqlPara);

            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public void Search_PatientXN(DateTime dtDateFrom, DateTime dtDateTo, string serviceId, string patientName
            , string seq, bool fullRsult, bool printed, string testId, string category, bool isTestProfile, bool nhapTheoDanhSach
            , DataGridView dtg, BindingNavigator bv, string maBN = "", string sdt = "")
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,t.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi,d.LamTieuDe, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,MaBN,tx.KetLuanXN as KetLuan, tx.DuKQXN as DuKQ,tx.DaInKQXN as DaIn \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = Tx.MatiepNhan \n";
            strSQL += "inner join KetQua_CLS_XetNghiem k on t.MaTiepNhan = k.MaTiepNhan \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  as D on t.DoiTuongDichVu = d.MaDoiTuongDichVu \n";
            strSQL += "where t.NgayTiepNhan between '" + dtDateFrom.ToString("yyyy-MM-dd 00:00:00.00") + "' and '" + dtDateTo.ToString("yyyy-MM-dd 00:00:00.00") + "'";
            if (serviceId != "")
            {
                strSQL += " and t.DoiTuongDichVu='" + serviceId.Trim() + "'";
            }
            if (seq != "")
            {
                strSQL += " and t.SEQ = '" + seq.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(maBN))
            {
                strSQL += " and t.MaBN = '" + maBN + "'\n";
            }
            if (!string.IsNullOrEmpty(sdt))
            {
                strSQL += " and t.SDT = '" + sdt + "'\n";
            }
            if (patientName != "")
            {
                strSQL += " and (t.tenBN like N'%" + patientName.Trim() + "%' or t.tenBN like N'%" + patientName.Trim() + "' or t.tenBN like N'" + patientName.Trim() + "%' or t.tenBN = N'" + patientName.Trim() + "')";
            }
            if (fullRsult)
            {
                strSQL += " and tx.DuKQXN = 1";
            }
            if (printed)
            {
                strSQL += " and tx.DaInKQXN = 1";
            }
            if (testId != "")
            {
                if (isTestProfile)
                {
                    strSQL += " and k.MaXN in (select MaXN from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet p where p.ProfileID = '" + testId + "') \n";
                }
                else
                {
                    strSQL += " and k.MaXN = '" + testId + "' \n";
                }
            }
            if (category != "")
            {
                strSQL += " and k.MaNhomCLS = '" + category + "' \n";
            }
            if (nhapTheoDanhSach)
                strSQL += "\n and t.NguonNhap ='" + InputSourceEnum.ByList.ToString() + "'";
            DataTable dt;
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void CapNhat_ThuTien(string maTiepNhan, string chiDinh, bool daThu)
        {
            string _strSQL = "update KetQua_CLS_XetNghiem set DaThuTien = " + (daThu == true ? "1" : "0");
            _strSQL += "\nWhere MatiepNhan = '" + Utilities.ConvertSqlString(maTiepNhan) + "' and MaXN in (" + chiDinh + ")";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            _strSQL = "update KetQua_CLS_XetNghiem set DaThuTien = " + (daThu == true ? "1" : "0");
            _strSQL += "\nWhere MatiepNhan = '" + Utilities.ConvertSqlString(maTiepNhan) + "' and ProfileID in (select distinct ProfileID from KetQua_CLS_XetNghiem where MaXN in  (" + chiDinh + "))";
            _strSQL += "\n and MaXN not in (" + chiDinh + ")";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void Get_DanhSachChiDinh(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt, bool defaultChecked)
        {
            dt = new DataTable();
            string _strSQL = " select cast (" + (defaultChecked == true ? "1" : "0") + " as bit) as chon,MatiepNhan, MaXN as MaChiDinh, TenXN as TenChiDinh,ThuTuIn , MaNhomCLS, MaPhanLoai,GiaRieng,SapXep, DaThuTien, UserNhapCD, N'XÉT NGHIỆM' as LoaiChiDinh, ProfileID, XNChinh from KetQua_CLS_XetNghiem";
            if (filter != "")
            {
                _strSQL += " where " + filter;
            }
            _strSQL += " order by MaNhomCLS,SapXep, MaXN, TenXN";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        #region Xử lý data hiển thị phiếu in BHYT
        public DataTable DataAllwayShowTest(string maMauIn, string matiepnhan, string conditSomeTestPrint)
        {
            var sqlPara = new SqlParameter[]
              {
                   WorkingServices.GetParaFromOject("@maTiepNhan", matiepnhan),
                   WorkingServices.GetParaFromOject("@IdMauIn", maMauIn),
                   WorkingServices.GetParaFromOject("@xnIn", conditSomeTestPrint)

              };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selTesLuonHienThiBHYT"
             , sqlPara);
            return ds?.Tables[0];
        }
        public DataTable ConvertDataResultPrintFrom_RowToColumn(DataTable dtSource, string conditSomeTestPrint)
        {
            DataTable dtResult = new DataTable();
            dtResult = dtSource.Clone();
            if (dtSource.Rows.Count > 0)
            {
                dtResult.ImportRow(dtSource.Rows[0]);

                //Import roi thi xoa bot cot để thêm cột hiển thị
                dtResult.Columns.Remove("chon");
                dtResult.Columns.Remove("CSBTQuiDoi");
                dtResult.Columns.Remove("KetQuaQuiDoi");
                dtResult.Columns.Remove("HeSoQuiDoi");
                

                dtResult.Columns.Remove("TGCoKetQua");
                dtResult.Columns.Remove("UserNhapKQ");
                dtResult.Columns.Remove("UserSuaKQ");

                dtResult.Columns.Remove("RSoPhieuYeuCau");
                dtResult.Columns.Remove("maxn_his");

                dtResult.Columns.Remove("SapXep");
                dtResult.Columns.Remove("InDam");
                dtResult.Columns.Remove("InDamKQ");
                dtResult.Columns.Remove("KichCoChu");
                dtResult.Columns.Remove("KichCoKQ");
                dtResult.Columns.Remove("CanhLe");
                dtResult.Columns.Remove("lamtron");

                dtResult.Columns.Remove("IdChiDinhHis");
                dtResult.Columns.Remove("NguongDuoi");
                dtResult.Columns.Remove("NguongTren");

                dtResult.Columns.Remove("Mavitri");
                dtResult.Columns.Remove("TenXN");
                dtResult.Columns.Remove("BYTTenXN");
                dtResult.Columns.Remove("MaXN");
                dtResult.Columns.Remove("KetQua");
                dtResult.Columns.Remove("Flat");
                dtResult.Columns.Remove("DonVi");
                dtResult.Columns.Remove("CSBT");
                dtResult.Columns.Remove("NoiCot");
                dtResult.Columns.Remove("HienThiTen");
                dtResult.Columns.Remove("HienThiKetQua");
                dtResult.Columns.Remove("HienThiKQBatThuong");

                dtResult.Columns.Remove("DiaChiDoiTuongDichVu");
                dtResult.Columns.Remove("EmailDoiTuongDichVu");
                dtResult.Columns.Remove("LamTieuDe");
                dtResult.Columns.Remove("PhoneDoiTuongDichVu");
                dtResult.Columns.Remove("TenDoiTuongDichVu");
                dtResult.Columns.Remove("WebSiteDoiTuongDichVu");
                dtResult.Columns.Remove("DoiTuongLoGo");

                dtResult.Columns.Remove("MaTienSu");
                dtResult.Columns.Remove("KQTienSu");
                dtResult.Columns.Remove("TGCoKQTienSu");
                dtResult.Columns.Remove("TenNhomCLS");
                dtResult.Columns.Remove("MaNhomCLS");
                dtResult.Columns.Remove("ThuTuNhom");

                dtResult.AcceptChanges();
                //Thêm các cột tiêu chuẩn
                string suffixResult = "_R";
                string suffixResultMarrow = "_RMARROW";
                string suffixTestName = "_N";
                string suffixTestCode = "_M";
                string suffixFlat = "_F";
                string suffixUnit = "_U";
                string suffixMergeColumn = "_MC";
                string suffixNormalRange = "_RF";
                string suffixTestNameStyle = "_NST";
                string suffixResultStyle = "_RST";
                string suffixResultUpnormalStyle = "_RUST";
                string suffixResultMethod = "_METHOD";
                string suffixResultNote = "_NOTE";
                string refixColName = string.Empty;
                //ở đây giới hạn 30 dòng theo const
                int LimitClumn = 40;
                for (int iCount = 1; iCount <= LimitClumn; iCount++)
                {
                    //Cột trái trong lưới
                    refixColName = ReportResultPositionConstant.KQ_L_G_01.Replace("01", string.Format("{0:00}", iCount));
                    Add_CotKetQua(ref dtResult, refixColName
                        , suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange
                        , suffixMergeColumn, suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle
                        , suffixResultMethod, suffixResultNote, suffixResultMarrow);
                    ////Cột giữa trong lưới
                    //refixColName = ReportResultPositionConstant.KQ_M_G_01.Replace("01", string.Format("{0:00}", i));
                    //Add_CotKetQua(ref dtResult, refixColName, suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange);
                    //Cột phải trong lưới
                    refixColName = ReportResultPositionConstant.KQ_R_G_01.Replace("01", string.Format("{0:00}", iCount));
                    Add_CotKetQua(ref dtResult, refixColName
                        , suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange
                        , suffixMergeColumn, suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle
                        , suffixResultMethod, suffixResultNote, suffixResultMarrow);

                    if (iCount < 11)
                    {
                        //Cột trái ngoài lưới
                        refixColName = ReportResultPositionConstant.KQ_L_O_01.Replace("01", string.Format("{0:00}", iCount));
                        Add_CotKetQua(ref dtResult, refixColName, suffixResult, suffixTestName, suffixTestCode
                            , suffixFlat, suffixUnit, suffixNormalRange, suffixMergeColumn, suffixTestNameStyle
                            , suffixResultStyle, suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote, suffixResultMarrow);
                        ////Cột giữa ngoài lưới
                        //refixColName = ReportResultPositionConstant.KQ_M_O_01.Replace("01", string.Format("{0:00}", i));
                        //Add_CotKetQua(ref dtResult, refixColName, suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange);
                        //Cột phải ngoài lưới
                        refixColName = ReportResultPositionConstant.KQ_R_O_01.Replace("01", string.Format("{0:00}", iCount));
                        Add_CotKetQua(ref dtResult, refixColName, suffixResult, suffixTestName, suffixTestCode
                            , suffixFlat, suffixUnit, suffixNormalRange, suffixMergeColumn, suffixTestNameStyle, suffixResultStyle
                            , suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote, suffixResultMarrow);
                    }
                }

                dtResult.AcceptChanges();

                var IDMauKetQua = string.Empty;
                foreach (DataRow drS in dtSource.Rows)
                {
                    if (!string.IsNullOrEmpty(drS["Mavitri"].ToString()))
                    {
                        Set_GiaTriVaoCot(ref dtResult, true, false, drS["Mavitri"].ToString(), suffixResult
                        , suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange, suffixMergeColumn
                        , suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote
                        , drS["KetQua"].ToString(), drS["BYTTenXN"].ToString(), drS["MaXN"].ToString()
                        , drS["Flat"].ToString(), drS["DonVi"].ToString(), drS["CSBT"].ToString()
                        , drS["NoiCot"].ToString(), drS["HienThiTen"].ToString(), drS["HienThiKetQua"].ToString()
                        , drS["HienThiKQBatThuong"].ToString(), drS["QuiTrinh"].ToString(), drS["GhiChu"].ToString()
                        , suffixResultMarrow, drS["KetQuaTuy"].ToString());

                        IDMauKetQua = drS["IDMauKetQua"].ToString();
                    }
                }
                var dtSource2 = DataAllwayShowTest(IDMauKetQua, dtSource.Rows[0]["MaTiepNhan"].ToString(), conditSomeTestPrint);
                if (dtSource2.Rows.Count > 0)
                {
                    foreach (DataRow drS2 in dtSource2.Rows)
                    {
                        Set_GiaTriVaoCot(ref dtResult, true, true, drS2["Mavitri"].ToString(), suffixResult
                       , suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange, suffixMergeColumn
                       , suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote
                       , drS2["KetQua"].ToString(), drS2["BYTTenXN"].ToString(), drS2["MaXN"].ToString()
                        , drS2["Flat"].ToString(), drS2["DonVi"].ToString(), drS2["CSBT"].ToString()
                        , drS2["NoiCot"].ToString(), drS2["HienThiTen"].ToString()
                        , drS2["HienThiKetQua"].ToString(), drS2["HienThiKQBatThuong"].ToString()
                        , string.Empty, string.Empty, suffixResultMarrow, string.Empty);
                    }
                }

                SapXepCot(IDMauKetQua, ref dtResult, suffixResult
                , suffixTestName, suffixTestCode, suffixFlat, suffixUnit
                , suffixNormalRange, suffixMergeColumn, suffixTestNameStyle, suffixResultStyle
                , suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote, suffixResultMarrow);

                //string sql = "select ";
                //foreach (DataColumn dc in dtResult.Columns)
                //{
                //    if (dc.DataType == typeof(int))
                //        sql += string.Format(",0 as {0}", dc.ColumnName);
                //    else if (dc.DataType == typeof(bool))
                //        sql += string.Format(",cast(0 as bit) as {0}", dc.ColumnName);
                //    else
                //        sql += string.Format(",'{0}' as {0}", dc.ColumnName);
                //}
                //Common.Controls.CustomMessageBox.MSG_Information_OK(sql.Replace("select ,", "select "));
            }
            return dtResult;
        }
        private void SapXepCot(string idMauPhieuIn, ref DataTable dtSource, string suffixResult
            , string suffixTestName, string suffixTestCode, string suffixFlat, string suffixUnit
            , string suffixNormalRange, string suffixMergeColumn, string suffixTestNameStyle
            , string suffixResultStyle, string suffixResultUpnormalStyle, string suffixResultMethod, string suffixResultNote
            , string suffixMarrow)
        {
            string refixColNameLeft = string.Empty;
            string refixColNameRight = string.Empty;

            var query = "select VitriSapXepTrai, VitriSapXepPhai,VitriSapXepTraiGioiHan,VitriSapXepPhaiGioiHan";
            query += "\n,VitriSapXepTraiNgoai, VitriSapXepPhaiNgoai,VitriSapXepTraiGioiHanNgoai,VitriSapXepPhaiGioiHanNgoai";
            query += string.Format("\n from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN where IDMauKetQua = '{0}'", idMauPhieuIn);
            DataTable dtVitrSapXep = DataProvider.ExecuteDataset(CommandType.Text, query).Tables[0];

            if (dtVitrSapXep.Rows.Count > 0)
            {

                //Cột trong lưới
                int vitritrai = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepTrai"].ToString());
                int vitriphai = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepPhai"].ToString());
                int VitriSapXepTraiGioiHan = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepTraiGioiHan"].ToString());
                int VitriSapXepPhaiGioiHan = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepPhaiGioiHan"].ToString());

                if (vitritrai > -1 && VitriSapXepTraiGioiHan > -1)
                {
                    for (int i = vitritrai; i <= VitriSapXepTraiGioiHan; i++)
                    {
                        refixColNameLeft = ReportResultPositionConstant.KQ_L_G_01.Replace("01", string.Format("{0:00}", i));
                        //khi kết quả này rỗng
                        if (string.IsNullOrEmpty(dtSource.Rows[0][string.Format("{0}{1}", refixColNameLeft, suffixResult)].ToString()))
                        {
                            TimKiemDeGanViTriToiHan(ref dtSource, i, VitriSapXepTraiGioiHan, refixColNameLeft, ReportResultPositionConstant.KQ_L_G_01
                                 , suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange
                                , suffixMergeColumn, suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle
                                , suffixResultMethod, suffixResultNote, suffixMarrow);
                        }
                    }
                }
                if (vitriphai > -1 && VitriSapXepPhaiGioiHan > -1)
                {
                    for (int i = vitriphai; i <= VitriSapXepPhaiGioiHan; i++)
                    {
                        refixColNameRight = ReportResultPositionConstant.KQ_R_G_01.Replace("01", string.Format("{0:00}", i));
                        //khi kết quả này rỗng
                        if (string.IsNullOrEmpty(dtSource.Rows[0][string.Format("{0}{1}", refixColNameRight, suffixResult)].ToString()))
                        {
                            TimKiemDeGanViTriToiHan(ref dtSource, i, VitriSapXepPhaiGioiHan, refixColNameRight, ReportResultPositionConstant.KQ_R_G_01
                                 , suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange
                                , suffixMergeColumn, suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle
                                , suffixResultMethod, suffixResultNote, suffixMarrow);
                        }
                    }
                }
                //Cột ngoài lưới
                vitritrai = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepTraiNgoai"].ToString());
                vitriphai = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepPhaiNgoai"].ToString());
                VitriSapXepTraiGioiHan = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepTraiGioiHanNgoai"].ToString());
                VitriSapXepPhaiGioiHan = int.Parse(dtVitrSapXep.Rows[0]["VitriSapXepPhaiGioiHanNgoai"].ToString());

                if (vitritrai > -1 && VitriSapXepTraiGioiHan > -1)
                {
                    for (int i = vitritrai; i <= VitriSapXepTraiGioiHan; i++)
                    {
                        refixColNameLeft = ReportResultPositionConstant.KQ_L_O_01.Replace("01", string.Format("{0:00}", i));
                        //khi kết quả này rỗng
                        if (string.IsNullOrEmpty(dtSource.Rows[0][string.Format("{0}{1}", refixColNameLeft, suffixResult)].ToString()))
                        {
                            TimKiemDeGanViTriToiHan(ref dtSource, i, VitriSapXepTraiGioiHan, refixColNameLeft, ReportResultPositionConstant.KQ_L_O_01
                                 , suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange
                                , suffixMergeColumn, suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle
                                , suffixResultMethod, suffixResultNote, suffixMarrow);
                        }
                    }
                }
                if (vitriphai > -1 && VitriSapXepPhaiGioiHan > -1)
                {
                    for (int i = vitriphai; i <= VitriSapXepPhaiGioiHan; i++)
                    {
                        refixColNameRight = ReportResultPositionConstant.KQ_R_O_01.Replace("01", string.Format("{0:00}", i));
                        //khi kết quả này rỗng
                        if (string.IsNullOrEmpty(dtSource.Rows[0][string.Format("{0}{1}", refixColNameRight, suffixResult)].ToString()))
                        {
                            TimKiemDeGanViTriToiHan(ref dtSource, i, VitriSapXepPhaiGioiHan, refixColNameRight, ReportResultPositionConstant.KQ_R_O_01
                                 , suffixResult, suffixTestName, suffixTestCode, suffixFlat, suffixUnit, suffixNormalRange
                                , suffixMergeColumn, suffixTestNameStyle, suffixResultStyle, suffixResultUpnormalStyle
                                , suffixResultMethod, suffixResultNote, suffixMarrow);
                        }
                    }
                }

            }
        }
        private void TimKiemDeGanViTriToiHan(ref DataTable dtSource, int fromCol, int toCol, string refixColName
            , string refixColNameTemplate, string suffixResult
            , string suffixTestName, string suffixTestCode, string suffixFlat, string suffixUnit
            , string suffixNormalRange, string suffixMergeColumn, string suffixTestNameStyle, string suffixResultStyle
            , string suffixResultUpnormalStyle, string suffixResultMethod, string suffixResultNote, string suffixMarrow)
        {
            string refixSearchCoName = string.Empty;

            //clean value current postion first
            CleanVlaue(ref dtSource, refixColName, suffixResult
              , suffixTestName, suffixTestCode, suffixFlat, suffixUnit
              , suffixNormalRange, suffixMergeColumn, suffixTestNameStyle, suffixResultStyle
              , suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote, suffixMarrow);

            for (int i = (fromCol + 1); i <= toCol; i++)
            {
                refixSearchCoName = refixColNameTemplate.Replace("01", string.Format("{0:00}", i));

                if (!string.IsNullOrEmpty(dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixResult)].ToString()))
                {
                    //set value first
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResult)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixResult)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixTestName)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixTestName)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixTestCode)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixTestCode)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixFlat)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixFlat)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixUnit)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixUnit)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixNormalRange)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixNormalRange)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixMergeColumn)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixMergeColumn)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixTestNameStyle)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixTestNameStyle)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultStyle)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixResultStyle)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultUpnormalStyle)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixResultUpnormalStyle)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultMethod)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixResultMethod)];
                    dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultNote)] = dtSource.Rows[0][string.Format("{0}{1}", refixSearchCoName, suffixResultNote)];
                    
                    //clean value
                    CleanVlaue(ref dtSource, refixSearchCoName, suffixResult
                      , suffixTestName, suffixTestCode, suffixFlat, suffixUnit
                      , suffixNormalRange, suffixMergeColumn, suffixTestNameStyle
                      , suffixResultStyle, suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote, suffixMarrow);

                    dtSource.AcceptChanges();
                    break;
                }
                else
                {
                    CleanVlaue(ref dtSource, refixSearchCoName, suffixResult
                    , suffixTestName, suffixTestCode, suffixFlat, suffixUnit
                    , suffixNormalRange, suffixMergeColumn, suffixTestNameStyle
                    , suffixResultStyle, suffixResultUpnormalStyle, suffixResultMethod, suffixResultNote, suffixMarrow);

                }
            }
        }
        private void CleanVlaue(ref DataTable dtSource, string refixColName, string suffixResult
            , string suffixTestName, string suffixTestCode, string suffixFlat, string suffixUnit
            , string suffixNormalRange, string suffixMergeColumn, string suffixTestNameStyle, string suffixResultStyle
            , string suffixResultUpnormalStyle, string suffixResultMethod, string suffixResultNote, string suffixRMarrow)
        {
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResult)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixTestName)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixTestCode)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixFlat)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixUnit)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixNormalRange)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixMergeColumn)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixTestNameStyle)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultStyle)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultUpnormalStyle)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultMethod)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixResultNote)] = DBNull.Value;
            dtSource.Rows[0][string.Format("{0}{1}", refixColName, suffixRMarrow)] = DBNull.Value;
        }
        private void Add_CotKetQua(ref DataTable dt, string refixColName, string suffixResult
            , string suffixTestName, string suffixTestCode, string suffixFlat, string suffixUnit
            , string suffixNormalRange, string suffixMergeColumn, string suffixTestNameStyle, string suffixResultStyle
            , string suffixResultUpnormalStyle, string suffixResultMethod, string suffixResultNote, string suffixRMarrow)
        {
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixResult), typeof(string));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixTestName), typeof(string));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixTestCode), typeof(string));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixFlat), typeof(int));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixUnit), typeof(string));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixNormalRange), typeof(string));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixMergeColumn), typeof(bool));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixTestNameStyle), typeof(int));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixResultStyle), typeof(int));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixResultUpnormalStyle), typeof(int));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixResultMethod), typeof(string));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixResultNote), typeof(string));
            dt.Columns.Add(string.Format("{0}{1}", refixColName, suffixRMarrow), typeof(string));
        }
        private void Set_GiaTriVaoCot(ref DataTable dt, bool newLineSamePosition, bool forFullTest, string refixColName, string suffixResult
            , string suffixTestName, string suffixTestCode, string suffixFlat, string suffixUnit, string suffixNormalRange
            , string suffixMergeColumn, string suffixTestNameStyle, string suffixResultStyle, string suffixResultUpnormalStyle
            , string suffixResultMethod,string suffixResultNote
            , string valResult, string valTestName, string valTestCode, string valFlat, string valUnit, string valNormalRange
            , string valueMergeColumn, string valueTestNameStyle, string valueResultStyle
            , string valueResultUpnormalStyle, string valuesResultMethod, string valuesResultNote, string suffixMarrow, string valueResultMarrow)
        {
            DataRow dataRow = dt.Rows[0];
            if (string.IsNullOrEmpty(dataRow[string.Format("{0}{1}", refixColName, suffixTestCode)].ToString()))
            {
                dataRow[string.Format("{0}{1}", refixColName, suffixResult)]
                    = Check_ReturnValueToSet(dataRow, refixColName, suffixResult, valResult, newLineSamePosition, forFullTest);
                dataRow[string.Format("{0}{1}", refixColName, suffixTestName)]
                    = Check_ReturnValueToSet(dataRow, refixColName, suffixTestName, valTestName, newLineSamePosition, forFullTest);
                dataRow[string.Format("{0}{1}", refixColName, suffixTestCode)]
                    = Check_ReturnValueToSet(dataRow, refixColName, suffixTestCode, valTestCode, newLineSamePosition, forFullTest);
                dataRow[string.Format("{0}{1}", refixColName, suffixFlat)]
                    = int.Parse(string.IsNullOrEmpty(valFlat) ? "1" : valFlat);
                dataRow[string.Format("{0}{1}", refixColName, suffixUnit)]
                    = Check_ReturnValueToSet(dataRow, refixColName, suffixUnit, valUnit, newLineSamePosition, forFullTest);
                dataRow[string.Format("{0}{1}", refixColName, suffixNormalRange)]
                    = Check_ReturnValueToSet(dataRow, refixColName, suffixNormalRange, string.Format("{0} {1}", valNormalRange.Trim(), valUnit.Trim()), newLineSamePosition, forFullTest);
                dataRow[string.Format("{0}{1}", refixColName, suffixMergeColumn)]
                    = bool.Parse(string.IsNullOrEmpty(valueMergeColumn) ? false.ToString() : valueMergeColumn);
                dataRow[string.Format("{0}{1}", refixColName, suffixTestNameStyle)]
                    = int.Parse(string.IsNullOrEmpty(valueTestNameStyle) ? "0" : valueTestNameStyle);
                dataRow[string.Format("{0}{1}", refixColName, suffixResultStyle)]
                    = int.Parse(string.IsNullOrEmpty(valueResultStyle) ? "0" : valueResultStyle);
                dataRow[string.Format("{0}{1}", refixColName, suffixResultUpnormalStyle)]
                    = int.Parse(string.IsNullOrEmpty(valueResultUpnormalStyle) ? "0" : valueResultUpnormalStyle);
                dataRow[string.Format("{0}{1}", refixColName, suffixResultMethod)] = valuesResultMethod;
                dataRow[string.Format("{0}{1}", refixColName, suffixResultNote)] = valuesResultNote;
                dataRow[string.Format("{0}{1}", refixColName, suffixMarrow)]
                        = Check_ReturnValueToSet(dataRow, refixColName, suffixMarrow, valueResultMarrow, newLineSamePosition, forFullTest);

            }
            dt.AcceptChanges();
        }
        private string Check_ReturnValueToSet(DataRow dr, string refix, string suffFix, string value, bool newLineSamePosition, bool forFullTest)
        {
            var currentValue = StringConverter.ToString(dr[string.Format("{0}{1}", refix, suffFix)]);
            if (string.IsNullOrEmpty(currentValue))
                return value;
            else
            {
                if (forFullTest)
                    return currentValue;
                else if (newLineSamePosition)
                    return string.Format("{0}{1}{2}", currentValue, Environment.NewLine, value);
                else
                    return string.Format("{0}; {1}{2}", currentValue, value);
            }
        }
        #endregion
        #region Data in cho phiếu thường quy
        /// <summary>
        /// Xử lý dữ liệu trước khi in phiếu thường quy
        /// </summary>
        /// <param name="dataIn">Dữ liệu nguồn</param>
        /// <param name="CategoryOrDepartment">True: Nhóm - False: Bộ phận</param>
        /// <returns></returns>
        public DataTable DataPrintList_NotAutoSplit(DataTable dataIn, bool CategoryOrDepartment,
            bool coTachPhieu = false, bool showGhiChuTheoXn = false
            , bool ghepTenXnghiChu = false, bool ghepGhiChuKhoa = false
            , string dinhdangGhepDuyet = "", string dinhdangGhepNhapKQ = "")
        {
            string ColumnGroupSplit = CategoryOrDepartment ? "MaNhomCLS" : "NhomIn";

            var dataGroup = dataIn.DefaultView.ToTable(true, new string[] { ColumnGroupSplit });
            var categoryCount = dataGroup.Rows.Count;

            var returnData = new DataTable[categoryCount];
            var dataReult = dataIn.Clone();

            DataTable returntable = dataIn.Clone();
            //barcode
            var barcode = BarcodeHelper.TextToBarcode(dataIn.Rows[0]["Seq"].ToString());
            var tenBS = XuLyTenBS(dataIn);
            var tenKhoa = XuLyTenKhoa(dataIn);
            var ghiChuTheoXn = false;
            var GhepTenXnGhiChu = false;
            var GhepGhiChuKhoa = false;
            string ghichuchung = string.Empty;
            for (int i = 0; i < categoryCount; i++)
            {
                var testOfCate = new DataTable();
                if (!string.IsNullOrEmpty(dataGroup.Rows[i][ColumnGroupSplit].ToString()))
                    testOfCate = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, string.Format("{0} = '{1}'", ColumnGroupSplit, dataGroup.Rows[i][ColumnGroupSplit].ToString()));
                else
                    testOfCate = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, string.Format("{0} = '' or {0} is null", ColumnGroupSplit));
                if (coTachPhieu)
                {
                    ghiChuTheoXn = bool.Parse(testOfCate.Rows[0]["GhiChuDuoiKetQua"].ToString());
                    GhepTenXnGhiChu = bool.Parse(testOfCate.Rows[0]["GhepTenXnGhiChu"].ToString());
                    GhepGhiChuKhoa = bool.Parse(testOfCate.Rows[0]["GhepGhiChuKhoa"].ToString());
                    dinhdangGhepDuyet = testOfCate.Rows[0]["DinhDangGhepDuyetKQ"].ToString();
                    dinhdangGhepNhapKQ = testOfCate.Rows[0]["DinhDangGhepNhapKQ"].ToString();
                }
                else
                {
                    ghiChuTheoXn = showGhiChuTheoXn;
                    GhepTenXnGhiChu = ghepTenXnghiChu;
                    GhepGhiChuKhoa = ghepGhiChuKhoa;
                }
                var CacMayChay = XuLytenMayChay(testOfCate);
                //Xử lý lấy loại mẫu
                var tenLoaiMau = XuLytenLoaiMau(testOfCate);
                //Xử lý lấy thời gian sau cùng ứng với người duyệt KQ
                var nguoiDuyetYKhoa = XuLyNguoiDuyetYKhoa(dataIn, true, dinhdangGhepDuyet);
                //xử lý người nhập kết quả
                var nguoiNhapKetQua = XuLyNguoiNhapKetQua(dataIn, true, dinhdangGhepNhapKQ);
                //Xử lý ghi chú
                var ghiChuISO = XulyCommnetChung(testOfCate, ghiChuTheoXn, GhepTenXnGhiChu, GhepGhiChuKhoa);
                var nullLogoISO = WorkingServices.SearchResult_OnDatatable(testOfCate, "datchungnhan = 1 ").Rows.Count == 0;
             
                foreach (DataRow dr in testOfCate.Rows)
                {
                    dr["LoaiMau"] = tenLoaiMau;
                    dr["DuyetYKhoa"] = nguoiDuyetYKhoa;
                    dr["NhapKetQua"] = nguoiNhapKetQua;
                    dr["GhiChuISO"] = ghiChuISO;

                    dr["Barcode"] = barcode;
                    dr["TenMayGhep"] = CacMayChay;
                    dr["TenNhanVien"] = tenBS;
                    dr["TenKhoaPhong"] = tenKhoa;
                    dr["NullISOLogo"] = (bool)dr["NullISOLogo"] == false && nullLogoISO && !((bool)dr["KhongCheckISOLogo1"]) ? true : (bool)dr["NullISOLogo"];
                    dr["NullISOLogo2"] = (bool)dr["NullISOLogo2"] == false &&  nullLogoISO && !((bool)dr["KhongCheckISOLogo2"]) ? true : (bool)dr["NullISOLogo2"];
                    var kytenTheoNguoiDuyet = (bool)dr["CoChuKyUserValid"];
                    if (!kytenTheoNguoiDuyet)
                    {
                        dr["NguoiXacNhan"] = string.Empty;
                        dr["TenNguoiXacNhan"] = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(ghiChuISO))
                    ghichuchung += (string.IsNullOrEmpty(ghichuchung) ? "" : "\n") + ghiChuISO;
                returntable.Merge(testOfCate);
            }
            if (!string.IsNullOrEmpty(ghichuchung))
            {
                foreach (DataRow item in returntable.Rows)
                {
                    item["ghichuphieuin"] = ghichuchung;
                }
            }
            returntable.AcceptChanges();
            returntable.DefaultView.Sort = "NhomIn, ThuTuNhom, SapXep, MaXN ASC";
            returntable = returntable.DefaultView.ToTable();
            return returntable;
        }
        //public DataTable XuLyLoaiMau_TheoBiPhan_UserXacNhan(DataTable dataSource)
        //{

        //}
        private int CalculateRow(int inputValue, int inputLimit)
        {
            var lenght = 0;
            var div = inputValue % (inputLimit == 0 ? 1 : inputLimit);
            if (div > 0)
                lenght = (inputValue / inputLimit) + 1;
            else
                lenght = (inputValue / inputLimit);

            return lenght;
        }
        public DataTable DataPrintList_AutoSplit(DataTable dataIn, int rowLimit, int rowForSign, int testLenghtLimt, int testResultLenghtLimt
    , int addressLenghtLimt, int diagnostictLenghtLimt, bool printWithConvert)
        {
            int totalLimit = rowLimit - rowForSign;
            //Tính số dòng cho chẩn đoán, đại chỉ, bs, khoa phòng
            if (addressLenghtLimt > -1)
            {
                var len = CalculateRow(dataIn.Rows[0]["diachi"].ToString().Length, addressLenghtLimt);
                if (len > 1)
                    totalLimit -= len - 1;
            }
            if (diagnostictLenghtLimt > -1)
            {
                var len = CalculateRow(dataIn.Rows[0]["chandoan"].ToString().Length, addressLenghtLimt);
                if (len > 1)
                    totalLimit -= len - 1;
            }
            var tenBs = dataIn.Rows[0]["TenNhanVien"].ToString().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (tenBs.Length > 1)
            {
                totalLimit -= tenBs.Length - 1;
            }

            int soKyTuDoRong = testLenghtLimt;
            string maXNTemp = "--TEMP--";
            var testName = string.Empty;
            var ketqua = string.Empty;
            var xnChinh = false;
            int lenghtMax = 1;
            for (int i = 0; i < dataIn.Rows.Count; i++)
            {
                if (dataIn.Rows[i]["MaXN"].ToString() != maXNTemp)
                {
                    ketqua = dataIn.Rows[i]["ketqua"].ToString();
                    testName = dataIn.Rows[i]["TenXn"].ToString();
                    xnChinh = (bool)dataIn.Rows[i]["XnChinh"];
                    lenghtMax = CalculateRow(testName.Length, testLenghtLimt);
                    var tempLenght = CalculateRow(ketqua.Length, testResultLenghtLimt);
                    if (tempLenght > lenghtMax)
                        lenghtMax = tempLenght;

                    if (lenghtMax > 1 && xnChinh == false)
                    {
                        for (int a = 0; a < lenghtMax; a++)
                        {
                            var dr = dataIn.Rows[i];
                            dataIn = WorkingServices.DataTable_MoveData(dataIn, dr, i);
                            dataIn.Rows[i + 1]["MaXN"] = maXNTemp;
                            i++;
                            dataIn.AcceptChanges();
                        }
                    }
                }
            }
            //tính toán số record tổng.
            //số test 
            var barcode = BarcodeHelper.TextToBarcode(dataIn.Rows[0]["Seq"].ToString());
            var dinhdangGhepDuyet = dataIn.Rows[0]["DinhDangGhepDuyetKQ"].ToString();
            var dinhdangGhepNhapKQ = dataIn.Rows[0]["DinhDangGhepNhapKQ"].ToString();
            string tenBS = XuLyTenBS(dataIn);
            string tenKhoa = XuLyTenKhoa(dataIn);

            var numberOftest = dataIn.Rows.Count;
            var dataCategory = dataIn.DefaultView.ToTable(true, new string[] { "MaNhomCLS" });
            var categoryCount = dataCategory.Rows.Count;

            var rowsOfConvert = 0;
            var dataConvert = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, "KetQuaQuiDoi is not null");
            if (printWithConvert)
            {
                rowsOfConvert = dataConvert.Rows.Count;
            }
            var totalTestrow = numberOftest + rowsOfConvert + categoryCount;


            if (totalTestrow > totalLimit && categoryCount > 1)
            {
                return RemoveTempRow(XuLy_NhieuNhom(rowLimit, categoryCount, barcode, tenBS, tenKhoa, dataIn, dataCategory), maXNTemp);
            }
            else
            {
                int nhomin = 0;
                int countingRows = 0;
                DataTable returntable = dataIn.Clone();
                //Xử lý lấy loại mẫu
                string tenLoaiMau = XuLytenLoaiMau(dataIn);
                //Xử lý lấy thời gian sau cùng ứng với người duyệt KQ
                var nguoiDuyetYKhoa = XuLyNguoiDuyetYKhoa(dataIn, true, dinhdangGhepDuyet);
                //xử lý người nhập kết quả
                var nguoiNhapKetQua = XuLyNguoiNhapKetQua(dataIn, true, dinhdangGhepNhapKQ);
                //Xử lý ghi chú
                string ghiChuISO = XulyCommnetChung(dataIn);
                var CacMayChay = XuLytenMayChay(dataIn);
                var nullLogoISO = WorkingServices.SearchResult_OnDatatable(dataIn, "datchungnhan = 1 ").Rows.Count == 0;

                foreach (DataRow dr in dataIn.Rows)
                {
                    countingRows++;
                    if (printWithConvert)
                    {
                        if (!string.IsNullOrEmpty(dr["KetQuaQuiDoi"].ToString()))
                        {
                            countingRows++;
                        }
                    }

                    nhomin = int.Parse(((float)(countingRows / rowLimit)).ToString().Substring(0, 1));

                    dr["NhomIn"] = nhomin.ToString();
                    dr["LoaiMau"] = tenLoaiMau;
                    dr["DuyetYKhoa"] = nguoiDuyetYKhoa;
                    dr["NhapKetQua"] = nguoiNhapKetQua;
                    dr["GhiChuISO"] = ghiChuISO;

                    dr["Barcode"] = barcode;
                    dr["TenMayGhep"] = CacMayChay;
                    dr["TenNhanVien"] = tenBS;
                    dr["TenKhoaPhong"] = tenKhoa;
                    dr["NullISOLogo"] = (bool)dr["NullISOLogo"] ? false : nullLogoISO;
                    dr["NullISOLogo2"] = (bool)dr["NullISOLogo2"] ? false : nullLogoISO;
                }
                return RemoveTempRow(dataIn, maXNTemp);
            }
        }
        public DataTable XuLy_NhieuNhom(int rowLimit, int categoryCount, byte[] barcode, string tenBS, string tenKhoa
            , DataTable dataIn, DataTable dataCategory)
        {
            var returnData = new DataTable[categoryCount];

            //Đếm các dòng và các nhóm có thể xảy ra
            var arrayCatgoryCount = new int[3, categoryCount];
            var dataReult = dataIn.Clone();

            for (int i = 0; i < categoryCount; i++)
            {
                var testOfCate = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, "MaNhomCLS = '" + dataCategory.Rows[i]["MaNhomCLS"].ToString() + "'");
                var testOfComment = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, "MaNhomCLS = '" + dataCategory.Rows[i]["MaNhomCLS"].ToString() + "' and Ghichu <> ''");
                var CommentofPatient = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, "MaNhomCLS = '" + dataCategory.Rows[i]["MaNhomCLS"].ToString() + "' and GhichuXN <>''");
                arrayCatgoryCount[0, i] = testOfCate.Rows.Count + 1 + testOfComment.Rows.Count + CommentofPatient.Rows.Count;//công 1 cho dòng tên nhóm
                arrayCatgoryCount[1, i] = WorkingServices.SearchResult_OnDatatable_NoneSort(testOfCate, "KetQuaQuiDoi is not null").Rows.Count;
                arrayCatgoryCount[2, i] = arrayCatgoryCount[0, i] + arrayCatgoryCount[1, i];

                returnData[i] = testOfCate;
            }
            //kiểm tra so sánh khi cộng các nhóm
            for (int a = 0; a < categoryCount; a++)
            {
                if (returnData[a] != null)
                {
                    if (a < categoryCount - 1)
                    {
                        //trừ 2 để có thể add ít nhất 1 test + 1 tên nhóm
                        if (arrayCatgoryCount[2, a] < rowLimit - 2)
                        {
                            for (int b = a + 1; b < categoryCount; b++)
                            {
                                if (returnData[b] != null)
                                {
                                    if ((arrayCatgoryCount[2, a] + arrayCatgoryCount[2, b]) <= rowLimit)
                                    {
                                        returnData[a].Merge(returnData[b]);
                                        arrayCatgoryCount[2, a] += arrayCatgoryCount[2, b];
                                        returnData[b] = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //convert thành 1 datatable để hiển thị report
            int nhomin = 0;
            DataTable returntable = dataIn.Clone();
            foreach (DataTable dt in returnData)
            {
                if (dt != null)
                {
                    var dinhdangGhepDuyet = dt.Rows[0]["DinhDangGhepDuyetKQ"].ToString();
                    var dinhdangGhepNhapKQ = dt.Rows[0]["DinhDangGhepNhapKQ"].ToString();
                    //Xử lý lấy loại mẫu
                    string tenLoaiMau = XuLytenLoaiMau(dt);
                    //Xử lý lấy thời gian sau cùng ứng với người duyệt KQ
                    var nguoiDuyetYKhoa = XuLyNguoiDuyetYKhoa(dt, false, dinhdangGhepDuyet);
                    //xử lý người nhập kết quả
                    var nguoiNhapKetQua = XuLyNguoiNhapKetQua(dt, false, dinhdangGhepNhapKQ);
                    //Xử lý ghi chú
                    string ghiChuISO = XulyCommnetChung(dt);
                    var CacMayChay = XuLytenMayChay(dt);

                    nhomin++;

                    int countingRows = 0;
                    var tempNhomin = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        countingRows++;
                        tempNhomin = int.Parse(((float)(countingRows / rowLimit)).ToString().Substring(0, 1));

                        dr["NhomIn"] = (nhomin + tempNhomin).ToString();
                        dr["LoaiMau"] = tenLoaiMau;
                        dr["DuyetYKhoa"] = nguoiDuyetYKhoa;
                        dr["NhapKetQua"] = nguoiNhapKetQua;
                        dr["GhiChuISO"] = ghiChuISO;

                        dr["Barcode"] = barcode;
                        dr["TenMayGhep"] = CacMayChay;
                        dr["TenNhanVien"] = tenBS;
                        dr["TenKhoaPhong"] = tenKhoa;
                    }
                    countingRows = countingRows + tempNhomin;
                    returntable.Merge(dt);
                }
            }
            return returntable;
        }
        private DataTable RemoveTempRow(DataTable dataIn, string maXNtemp)
        {
            for (int i = 0; i < dataIn.Rows.Count; i++)
            {
                if (dataIn.Rows[i]["MaXN"].ToString().Equals(maXNtemp))
                {
                    dataIn.Rows.RemoveAt(i);
                    dataIn.AcceptChanges();
                    i--;
                }
            }
            return dataIn;
        }
        public string XuLytenMayChay(DataTable dataResultIn)
        {
            var CacMayChay = string.Empty;
            var dataTenMay = dataResultIn.DefaultView.ToTable(true, new string[] { "TenMay" });
            foreach (DataRow drtenMay in dataTenMay.Rows)
            {
                if (!string.IsNullOrEmpty(drtenMay["TenMay"].ToString().Trim()))
                {
                    CacMayChay += (string.IsNullOrEmpty(CacMayChay) ? "" : ", ") + drtenMay["TenMay"].ToString().Trim();
                }
            }
            return CacMayChay;
        }
        public string XuLyTenBS(DataTable dataResultIn)
        {
            var distincBacSi = dataResultIn.DefaultView.ToTable(true, "TenNhanVien");
            var tenBS = string.Empty;

            if (distincBacSi.Rows.Count > 0)
            {
                foreach (DataRow drB in distincBacSi.Rows)
                {
                    tenBS += string.IsNullOrEmpty(tenBS) ? "" : "\n";
                    tenBS += drB["TenNhanVien"].ToString().Trim();
                }
            }
            return tenBS;
        }
        public string XuLyTenKhoa(DataTable dataResultIn)
        {
            var tenKhoa = string.Empty;
            var distincKhoa = dataResultIn.DefaultView.ToTable(true, "TenKhoaPhong");
            if (distincKhoa.Rows.Count > 0)
            {
                foreach (DataRow drB in distincKhoa.Rows)
                {
                    tenKhoa += string.IsNullOrEmpty(tenKhoa) ? "" : ", ";
                    tenKhoa += drB["TenKhoaPhong"].ToString().Trim();
                }
            }
            return tenKhoa;
        }
        public string XuLytenLoaiMau(DataTable dataResultIn)
        {
            string tenLoaiMau = string.Empty;
            var dataDistinctLoaiMau = dataResultIn.DefaultView.ToTable(true, "LoaiMau");

            foreach (DataRow drl in dataDistinctLoaiMau.Rows)
            {
                tenLoaiMau += string.IsNullOrEmpty(tenLoaiMau) ? "" : ", ";
                tenLoaiMau += drl["LoaiMau"].ToString().Trim();
            }
            return tenLoaiMau;
        }
        public string XuLyNguoiDuyetYKhoa(DataTable dataResultIn, bool tacnhNhom, string dinhdangGhep)
        {
            var nguoiDuyetYKhoa = string.Empty;
            if (string.IsNullOrEmpty(dinhdangGhep))
                return string.Empty;
            var distinctNguoiDuyet = dataResultIn.DefaultView.ToTable(true, new string[] { "MaNhomCLS", "ThoiGianDuyet", "ThuTuNhom", "NguoiXacNhan", "TenNguoiXacNhan" });

            if (!tacnhNhom)
            {
                distinctNguoiDuyet.DefaultView.Sort = "NguoiXacNhan ASC";
                distinctNguoiDuyet = distinctNguoiDuyet.DefaultView.ToTable();
                var currentIDNguoiDuyet = string.Empty;
                var currentThuTuIn = 0;
                var currentNhom = string.Empty;
                int count = 0;
                foreach (DataRow dr in distinctNguoiDuyet.Rows)
                {
                    if (currentIDNguoiDuyet != dr["NguoiXacNhan"].ToString())
                    {
                        currentIDNguoiDuyet = dr["NguoiXacNhan"].ToString();
                        currentThuTuIn = int.Parse(dr["ThuTuNhom"].ToString());
                        currentNhom = dr["MaNhomCLS"].ToString();
                        dr["MaNhomCLS"] = currentNhom;
                    }
                    else
                    {
                        dr["ThuTuNhom"] = currentThuTuIn;
                        dr["MaNhomCLS"] = currentNhom;
                    }
                }
            }
            distinctNguoiDuyet.DefaultView.Sort = "ThuTuNhom ASC, MaNhomCLS ASC, ThoiGianDuyet DESC";
            distinctNguoiDuyet = distinctNguoiDuyet.DefaultView.ToTable();

            var lstMaNhomCLS = new List<string>();
            var lstNguoiDuyet = new List<string>();
            foreach (DataRow drD in distinctNguoiDuyet.Rows)
            {
                var currentManHomCLS = drD["MaNhomCLS"].ToString().Trim();
                //if (!lstMaNhomCLS.Contains(currentManHomCLS))
                //{
                //    lstMaNhomCLS.Add(currentManHomCLS);
                var sel = string.Empty;
                if (!string.IsNullOrEmpty(drD["ThoiGianDuyet"].ToString()))
                {
                    sel = DateTime.Parse(drD["ThoiGianDuyet"].ToString()).ToString("HH:mm dd/MM/yyyy");
                }
                if (!string.IsNullOrEmpty(sel))
                {
                    var nguoiduyet = dinhdangGhep.Replace("{T}", sel).Replace("{U}", drD["TenNguoiXacNhan"].ToString().Trim());
                    var userDuyet = drD["TenNguoiXacNhan"].ToString();
                    if (!lstNguoiDuyet.Contains(userDuyet))
                    {
                        lstNguoiDuyet.Add(userDuyet);
                        nguoiDuyetYKhoa += (string.IsNullOrEmpty(nguoiDuyetYKhoa) ? "" : "\n") + nguoiduyet;
                    }
                }
                // }
            }
            return nguoiDuyetYKhoa;
        }
        public string XuLyNguoiNhapKetQua(DataTable dataResultIn, bool tacnhNhom, string dinhdangGhep)
        {
            if (string.IsNullOrEmpty(dinhdangGhep))
                return string.Empty;
            var nguoiDuyetYKhoa = string.Empty;
            var distinctNguoiDuyet = dataResultIn.DefaultView.ToTable(true, new string[] { "MaNhomCLS", "ThoiGianNhapKQ", "ThuTuNhom", "UserNhapKQ", "TenNguoiNhapKQ" });

            if (!tacnhNhom)
            {
                distinctNguoiDuyet.DefaultView.Sort = "UserNhapKQ ASC";
                distinctNguoiDuyet = distinctNguoiDuyet.DefaultView.ToTable();
                var currentIDNguoiDuyet = string.Empty;
                var currentThuTuIn = 0;
                var currentNhom = string.Empty;
                int count = 0;
                foreach (DataRow dr in distinctNguoiDuyet.Rows)
                {
                    if (currentIDNguoiDuyet != dr["UserNhapKQ"].ToString())
                    {
                        currentIDNguoiDuyet = dr["UserNhapKQ"].ToString();
                        currentThuTuIn = int.Parse(dr["ThuTuNhom"].ToString());
                        currentNhom = dr["MaNhomCLS"].ToString();
                        dr["MaNhomCLS"] = currentNhom;
                    }
                    else
                    {
                        dr["ThuTuNhom"] = currentThuTuIn;
                        dr["MaNhomCLS"] = currentNhom;
                    }
                }
            }
            distinctNguoiDuyet.DefaultView.Sort = "ThuTuNhom ASC, MaNhomCLS ASC, ThoiGianNhapKQ DESC";
            distinctNguoiDuyet = distinctNguoiDuyet.DefaultView.ToTable();

            var lstMaNhomCLS = new List<string>();
            var lstNguoiDuyet = new List<string>();
            foreach (DataRow drD in distinctNguoiDuyet.Rows)
            {
                var currentManHomCLS = drD["MaNhomCLS"].ToString().Trim();
                var sel = string.Empty;
                if (!string.IsNullOrEmpty(drD["ThoiGianNhapKQ"].ToString()))
                {
                    sel = DateTime.Parse(drD["ThoiGianNhapKQ"].ToString()).ToString("HH:mm dd/MM/yyyy");
                }
                if (!string.IsNullOrEmpty(sel))
                {
                    var nguoiduyet = dinhdangGhep.Replace("{T}", sel).Replace("{U}", drD["TenNguoiNhapKQ"].ToString().Trim());
                    var userDuyet = drD["TenNguoiNhapKQ"].ToString();
                    if (!lstNguoiDuyet.Contains(userDuyet))
                    {
                        lstNguoiDuyet.Add(userDuyet);
                        nguoiDuyetYKhoa += (string.IsNullOrEmpty(nguoiDuyetYKhoa) ? "" : "\n") + nguoiduyet;
                    }
                }
            }
            return nguoiDuyetYKhoa;
        }
        public string XulyCommnetChung(DataTable dataResultIn, bool ghiChuTheoXn = false
            , bool gheptenXnghiChu = false, bool ghepCghiChuKhoa = false)
        {
            //Comment 1 hiển thị trên all các trang in 
            //Comment 2 hiển thị trên trang in có nhóm xn đó
            //Comment 3 hiện thị trên trang in có xn đó
            var ghiChuChung = string.Empty;
            var commentCate = string.Empty;
            if (dataResultIn.Rows.Count > 0)
            {
                var lisOfBoPhan = dataResultIn.AsEnumerable().Select(x => x.Field<string>("MaBoPhan")).Distinct().ToList();

                var splitComment = dataResultIn.Rows[0]["GhiChuBoPhan"].ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (splitComment.Length > 0)
                {
                    foreach (string sC in splitComment)
                    {
                        var sctrim = sC.Trim();
                        if (
                            (sctrim.Contains("HH: ") && lisOfBoPhan.Contains("HH"))
                            || (sctrim.Contains("HSMD: ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("MD") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("HS: ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("SH: ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("NT: ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("VS: ") && lisOfBoPhan.Contains("VS"))
                            || (sctrim.Contains("SHPT: ") && lisOfBoPhan.Contains("SHPT"))
                            || (sctrim.Contains("HH : ") && lisOfBoPhan.Contains("HH"))
                            || (sctrim.Contains("HSMD : ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("MD") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("HS : ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("SH : ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("NT : ") && (lisOfBoPhan.Contains("SH") || lisOfBoPhan.Contains("HS")))
                            || (sctrim.Contains("VS : ") && lisOfBoPhan.Contains("VS"))
                            || (sctrim.Contains("SHPT : ") && lisOfBoPhan.Contains("SHPT"))
                            )
                        {
                            commentCate += (string.IsNullOrEmpty(commentCate) ? "" : "\n") + sctrim;
                        }
                        else if (!sctrim.Contains("HH: ") && !sctrim.Contains("HSMD: ") && !sctrim.Contains("HS: ") && !sctrim.Contains("SH: ")
                            && !sctrim.Contains("NT: ") && !sctrim.Contains("VS: ") && !sctrim.Contains("SHPT: ")
                           && !sctrim.Contains("HH : ") && !sctrim.Contains("HSMD : ") && !sctrim.Contains("HS : ") && !sctrim.Contains("SH : ")
                            && !sctrim.Contains("NT : ") && !sctrim.Contains("VS : ") && !sctrim.Contains("SHPT : "))
                        {
                            ghiChuChung += (string.IsNullOrEmpty(ghiChuChung) ? "" : "\n") + sctrim;
                        }
                    }
                }

                string commentTest = string.Empty;
                if (!ghiChuTheoXn)
                {
                    if (gheptenXnghiChu)
                    {
                        var distinctGhiChuTest = dataResultIn.DefaultView.ToTable(true, new string[] { "GhiChu", "TenXN" });
                        foreach (DataRow drCom in distinctGhiChuTest.Rows)
                        {
                            var tempComment = drCom["GhiChu"].ToString().Trim();
                            var tenXn = drCom["TenXN"].ToString().Trim();
                            if (!string.IsNullOrEmpty(tempComment))
                            {
                                commentTest += (string.IsNullOrEmpty(commentTest) ? "" : "\n") + string.Format("{0}: {1}", tenXn, tempComment);
                            }
                        }
                    }
                    else
                    {
                        var distinctGhiChuTest = dataResultIn.DefaultView.ToTable(true, new string[] { "GhiChu" });
                        foreach (DataRow drCom in distinctGhiChuTest.Rows)
                        {
                            var tempComment = drCom["GhiChu"].ToString().Trim();
                            if (!string.IsNullOrEmpty(tempComment))
                            {
                                commentTest += (string.IsNullOrEmpty(commentTest) ? "" : "\n") + tempComment;
                            }
                        }
                    }
                }
                if (ghepCghiChuKhoa)
                {
                    if (!string.IsNullOrEmpty(commentCate))
                        ghiChuChung += (string.IsNullOrEmpty(ghiChuChung) ? "" : "\n") + commentCate;
                    if (!string.IsNullOrEmpty(commentTest))
                        ghiChuChung += (string.IsNullOrEmpty(ghiChuChung) ? "" : "\n") + commentTest;
                }
                else
                    ghiChuChung = commentTest;

                // var ghiChuISO = dataResultIn.Rows[0]["GhiChuISO"].ToString();
                //if (!string.IsNullOrEmpty(ghiChuISO))
                //    ghiChuChung += (string.IsNullOrEmpty(ghiChuChung) ? "" : "\n") + ghiChuISO;
            }
            return ghiChuChung;
        }
        #endregion
        #region Sinh học phân tử
        public int LuuKetQua_SHPT(KETQUA_CLS_XETNGHIEM_SPHT obj)
        {
            bool suaKetqua = false;
            var data = new DataTable();
            if (obj.withImage)
                data = Insert_Update_SHPT_ThongTin(obj);
            if (data.Rows.Count > 0 || obj.withImage == false)
            {
                if (obj.withImage)
                    CapNhat_Hinhanh_SHPT(obj);
                suaKetqua = obj.suaKetqua;
                var i = int.Parse(CapNhat_KQ_XN(new UpdateResultNormalInfo
                {
                    maTiepNhan = obj.Matiepnhan,
                    maXN = obj.Maxn,
                    ketQua = obj.KetLuan,
                    capNhatghiChu = true,
                    ghiChu = obj.GhiChu,
                    co = "1",
                    userNhap = obj.Nguoinhap,
                    suaKQ = suaKetqua,
                    round = "0",
                    userUpdate = obj.Nguoisua,
                    coCapnhatHeso = true,
                    ketquaHeso = obj.KetQuaHeSo,
                    updateDVT = obj.CapNhatDonVi,
                    dvTinh = obj.DonViTinh,
                    capnhatDinhLuong = obj.CapNhatKetQuaDinhLuong,
                    ketquaDinhLuong = obj.KetQuaDinhLuong,
                    capnhatDinhTinh = obj.CapNhatKetQuaDinhTinh,
                    ketquaDinhTinh = obj.KetQuaDinhTinh
                }));

                if (i > 0)
                {
                    CapNhat_MayChay_Ketqua(obj.Matiepnhan, obj.Maxn, obj.IDMayXn, obj.Nguoinhap, obj.CapNhatGhiChu);
                }
                //Cập nhật cái này sau để pp không bị update ngược
                if (obj.coNgaykhoiPhat)
                {
                    i += CapNhat_LanXn_NgayKhoiPhat(obj.Matiepnhan, obj.Maxn, obj.ThoiGianXacNhanThucHien, obj.LanXetNghiem, obj.PhuongPhap);
                }
                return i;
            }
            else
                return -1;
        }
        public int CapNhat_LanXn_NgayKhoiPhat(string maTiepNhan, string maXn, DateTime? ngayKhoiPhat, int lanXetNghiem, string phuongPhap)
        {
            var para = new SqlParameter[]
         {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                ,WorkingServices.GetParaFromOject("@MaXn", maXn)
                ,WorkingServices.GetParaFromOject("@LanXN", lanXetNghiem)
                ,WorkingServices.GetParaFromOject("@NgayKhoiPhat",(ngayKhoiPhat == null?(object)DBNull.Value: ngayKhoiPhat.Value))
                ,WorkingServices.GetParaFromOject("@phuongPhap", string.IsNullOrEmpty(phuongPhap)?(object)DBNull.Value: phuongPhap)
         };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_LanXn_NgayKhoiPhat", para);
        }
        public DataTable Insert_Update_SHPT_ThongTin(KETQUA_CLS_XETNGHIEM_SPHT obj)
        {
            //create proc insUpd_SHPT_ThongTin
            // @maTiepNhan varchar(20)
            // ,@maXn varchar(25)
            // ,@nguoiNhap varchar(25)
            // ,@nguoiSua varchar (25

            var para = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@maTiepNhan", obj.Matiepnhan)
                ,WorkingServices.GetParaFromOject("@maXn", obj.Maxn)
                ,WorkingServices.GetParaFromOject("@nguoiNhap", obj.Nguoinhap)
                ,WorkingServices.GetParaFromOject("@nguoiSua", obj.Nguoisua)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "insUpd_SHPT_ThongTin", para).Tables[0];
        }
        public int LuuKetQua_SHPT_KhongUpdateKetQua(KETQUA_CLS_XETNGHIEM_SPHT obj)
        {
            var data = Insert_Update_SHPT_ThongTin(obj);
            if (data.Rows.Count > 0)
            {
                return CapNhat_Hinhanh_SHPT(obj);
            }
            else
                return -1;
        }
        public int CapNhat_Hinhanh_SHPT(KETQUA_CLS_XETNGHIEM_SPHT obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update ketqua_cls_xetnghiem_spht set HinhAnh1 = @HinhAnh1, HinhAnh2 = @HinhAnh2 , HinhAnh3 = @HinhAnh3, HinhAnh4 = @HinhAnh4, HinhAnh5 = @HinhAnh5");
            sb.AppendFormat("\n where Matiepnhan = {0}", "'" + Utilities.ConvertSqlString(obj.Matiepnhan) + "'");
            sb.AppendFormat("\n and Maxn = {0}", "'" + Utilities.ConvertSqlString(obj.Maxn) + "'");

            var para1 = WorkingServices.GetParaFromOject("@HinhAnh1", obj.Hinhanh1 == null ? (object)DBNull.Value : GraphicSupport.ImageToByteArray(obj.Hinhanh1));
            para1.DbType = DbType.Binary;
            var para2 = WorkingServices.GetParaFromOject("@HinhAnh2", obj.Hinhanh2 == null ? (object)DBNull.Value : GraphicSupport.ImageToByteArray(obj.Hinhanh2));
            para2.DbType = DbType.Binary;
            var para3 = WorkingServices.GetParaFromOject("@HinhAnh3", obj.Hinhanh3 == null ? (object)DBNull.Value : GraphicSupport.ImageToByteArray(obj.Hinhanh3));
            para3.DbType = DbType.Binary;
            var para4 = WorkingServices.GetParaFromOject("@HinhAnh4", obj.Hinhanh4 == null ? (object)DBNull.Value : GraphicSupport.ImageToByteArray(obj.Hinhanh4));
            para4.DbType = DbType.Binary;
            var para5 = WorkingServices.GetParaFromOject("@HinhAnh5", obj.Hinhanh5 == null ? (object)DBNull.Value : GraphicSupport.ImageToByteArray(obj.Hinhanh5));
            para5.DbType = DbType.Binary;

            SqlParameter[] para = new SqlParameter[]
            {
                para1,
                para2,
                para3,
                para4,
                para5
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString(), para);
        }
        public bool Delete_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete ketqua_cls_xetnghiem_spht");
            sb.AppendFormat("\n where Matiepnhan = {0}", "'" + Utilities.ConvertSqlString(matiepnhan) + "'");
            sb.AppendFormat("\n and Maxn = {0}", "'" + Utilities.ConvertSqlString(maxn) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ketqua_cls_xetnghiem_spht where 1=1");
            if (!string.IsNullOrEmpty(matiepnhan))
                sb.AppendFormat("\n and  matiepnhan = {0}", "'" + matiepnhan + "'");
            if (!string.IsNullOrEmpty(maxn))
                sb.AppendFormat("\n and  maxn in ({0})", (maxn.Contains("'") ? maxn : "'" + maxn + "'"));
            return sb.ToString();
        }
        public DataTable Data_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_ketqua_cls_xetnghiem_spht(matiepnhan, maxn)).Tables[0];
            return dtData;
        }

        public KETQUA_CLS_XETNGHIEM_SPHT Get_Info_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn)
        {
            DataTable dt = Data_ketqua_cls_xetnghiem_spht(matiepnhan, maxn);
            KETQUA_CLS_XETNGHIEM_SPHT obj = new KETQUA_CLS_XETNGHIEM_SPHT();
            if (dt.Rows.Count > 0)
            {
                obj.Matiepnhan = StringConverter.ToString(dt.Rows[0]["matiepnhan"]);
                obj.Maxn = StringConverter.ToString(dt.Rows[0]["maxn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["hinhanh1"].ToString()))
                    obj.Hinhanh1 = (Bitmap)((new ImageConverter()).ConvertFrom(dt.Rows[0]["hinhanh1"]));
                if (!string.IsNullOrEmpty(dt.Rows[0]["hinhanh2"].ToString()))
                    obj.Hinhanh2 = (Bitmap)((new ImageConverter()).ConvertFrom(dt.Rows[0]["hinhanh2"]));
                if (!string.IsNullOrEmpty(dt.Rows[0]["hinhanh3"].ToString()))
                    obj.Hinhanh3 = (Bitmap)((new ImageConverter()).ConvertFrom(dt.Rows[0]["hinhanh3"]));
                if (!string.IsNullOrEmpty(dt.Rows[0]["hinhanh4"].ToString()))
                    obj.Hinhanh4 = (Bitmap)((new ImageConverter()).ConvertFrom(dt.Rows[0]["hinhanh4"]));
                if (!string.IsNullOrEmpty(dt.Rows[0]["hinhanh5"].ToString()))
                    obj.Hinhanh5 = (Bitmap)((new ImageConverter()).ConvertFrom(dt.Rows[0]["hinhanh5"]));
                if (!string.IsNullOrEmpty(dt.Rows[0]["tgcokq"].ToString()))
                    obj.Tgcokq = (DateTime)dt.Rows[0]["tgcokq"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoinhap"].ToString()))
                    obj.Nguoinhap = StringConverter.ToString(dt.Rows[0]["nguoinhap"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoisua"].ToString()))
                    obj.Nguoisua = StringConverter.ToString(dt.Rows[0]["nguoisua"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tgsua"].ToString()))
                    obj.Tgsua = (DateTime)dt.Rows[0]["tgsua"];
            }
            return obj;
        }

        public bool Check_ExistsSHPT_Gen(string matiepnhan, string maxn, string magen)
        {
            var obj = Get_Info_SHPT_Gen(matiepnhan, maxn, magen);
            return !string.IsNullOrEmpty(obj.Matiepnhan);
        }

        public int Insert_Update_SHPT_Gen(KETQUA_CLS_XETNGHIEM_SHPT_GEN obj)
        {
            var para = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@maTiepNhan", obj.Matiepnhan)
                ,WorkingServices.GetParaFromOject("@maXn", obj.Maxn)
                ,WorkingServices.GetParaFromOject("@maGen", obj.Magen)
                ,WorkingServices.GetParaFromOject("@KetQuaDinhLuong", string.IsNullOrEmpty(obj.Ketquadinhluong)?(object)DBNull.Value: obj.Ketquadinhluong)
                ,WorkingServices.GetParaFromOject("@KetQuaDinhTinh", string.IsNullOrEmpty(obj.Ketquadinhtinh)?(object)DBNull.Value: obj.Ketquadinhtinh)
                ,WorkingServices.GetParaFromOject("@NguoiNhap", obj.Nguoinhap)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insUdpXetNghiem_KetQuaGen", para);
        }
        public int Delete_SHPT_Gen(KETQUA_CLS_XETNGHIEM_SHPT_GEN obj)
        {
            var para = new SqlParameter[]
                   {
                        WorkingServices.GetParaFromOject("@maTiepNhan", obj.Matiepnhan)
                        ,WorkingServices.GetParaFromOject("@maXn", obj.Maxn)
                        ,WorkingServices.GetParaFromOject("@maGen", obj.Magen)
                   };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delXetNghiem_KetQuaGen", para);
        }
        public KETQUA_CLS_XETNGHIEM_SHPT_GEN Get_Info_SHPT_Gen(string matiepnhan, string maxn, string magen)
        {
            var obj = new KETQUA_CLS_XETNGHIEM_SHPT_GEN();
          
            var dt = Data_SHPT_Gen(matiepnhan, maxn, magen);
            if (dt.Rows.Count > 0)
            {
                obj = (KETQUA_CLS_XETNGHIEM_SHPT_GEN)WorkingServices.Get_InfoForObject(obj, dt.Rows[0]);

                //    obj.Matiepnhan = StringConverter.ToString(dt.Rows[0]["matiepnhan"]);
                //    obj.Maxn = StringConverter.ToString(dt.Rows[0]["maxn"]);
                //    obj.Magen = StringConverter.ToString(dt.Rows[0]["magen"]);
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["ketquadinhtinh"].ToString()))
                //        obj.Ketquadinhtinh = StringConverter.ToString(dt.Rows[0]["ketquadinhtinh"]);
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["ketquadinhluong"].ToString()))
                //        obj.Ketquadinhluong = StringConverter.ToString(dt.Rows[0]["ketquadinhluong"]);
                //    obj.Nguoinhap = StringConverter.ToString(dt.Rows[0]["nguoinhap"]);
                //    obj.Tgnhap = (DateTime)dt.Rows[0]["tgnhap"];
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["nguoisua"].ToString()))
                //        obj.Nguoisua = StringConverter.ToString(dt.Rows[0]["nguoisua"]);
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["tgsua"].ToString()))
                //        obj.Tgsua = (DateTime)dt.Rows[0]["tgsua"];
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["donvitinh"].ToString()))
                //        obj.Donvitinh = StringConverter.ToString(dt.Rows[0]["donvitinh"]);
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["cantren"].ToString()))
                //        obj.Cantren = NumberConverter.To<float>(dt.Rows[0]["cantren"]);
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["canduoi"].ToString()))
                //        obj.Canduoi = NumberConverter.To<float>(dt.Rows[0]["canduoi"]);
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["dkdanhgia"].ToString()))
                //        obj.Dkdanhgia = StringConverter.ToString(dt.Rows[0]["dkdanhgia"]);
            }
            return obj;
        }
        public DataTable Data_SHPT_Gen(string matiepnhan, string maxn, string magen)
        {
            var para = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@maTiepNhan", matiepnhan)
                    ,WorkingServices.GetParaFromOject("@maXn", maxn)
                    ,WorkingServices.GetParaFromOject("@maGen", string.IsNullOrEmpty( magen)?(object)DBNull.Value: magen)
                };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNghiem_KetQuaGen", para).Tables[0];
        }
        public DataTable Data_SHPT_Gen_In(string matiepnhan, string maxn, string magen)
        {
            var para = new SqlParameter[]
                   {
                    WorkingServices.GetParaFromOject("@maTiepNhan", matiepnhan)
                    ,WorkingServices.GetParaFromOject("@maXn", maxn)
                    ,WorkingServices.GetParaFromOject("@maGen", string.IsNullOrEmpty( magen)?(object)DBNull.Value: magen)
                   };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNghiem_KetQuaGen_Print", para).Tables[0];
        }

        public int LuuIdDienGiai(string matiepnhan, string maxn, int id, string nguoiThuchien)
        {
            var para = new SqlParameter[]
            {
                    WorkingServices.GetParaFromOject("@maTiepNhan", matiepnhan)
                    ,WorkingServices.GetParaFromOject("@maXn", maxn)
                    ,WorkingServices.GetParaFromOject("@Id", id)
                    ,WorkingServices.GetParaFromOject("@NguoiNhap", nguoiThuchien)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "shpt_ins_DienGiaiKetQua", para);
        }
        public DataTable DataThongTinDienGiai(string matiepnhan, string maxn)
        {
            var sqlPara = new SqlParameter[]
               {    new SqlParameter("@maTiepNhan", matiepnhan)
                 , new SqlParameter("@MaXN",maxn)
              };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "shpt_sel_DienGiaiKetQua"
             , sqlPara);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }
        //Kiểu gen
        public void CapNhat_KieuGen_XN(string maTiepNhan, string maXN, string kieugen, string userNhap, string userUpdate)
        {
            //Ghi log
            _iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Update, userUpdate, Utilities.ConvertSqlString(maTiepNhan), new List<string> { maXN }, string.Empty);
            //Edit data
            DataProvider.ExecuteNonQuery(CommandType.StoredProcedure,
        "updXetNghiem_KieuGen"
        , new SqlParameter[]
                {
                        WorkingServices.GetParaFromOject("@maTiepNhan",maTiepNhan)
                        , WorkingServices.GetParaFromOject("@maXn",maXN)
                        , WorkingServices.GetParaFromOject("@UserNhap",userNhap)
                        , WorkingServices.GetParaFromOject("@KieuGen",kieugen)
                });
        }

        #endregion

        #region Danh sách chỉ định xet nghiem
        public DataTable Load_ChiDinhXetNghiemDichVuTheoOngMau(List<string> lstMaTiepNhan, string manhomloaiMau)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaTiepNhan",Utilities.ConvertStrinArryToInClauseSQLForSplitString(lstMaTiepNhan)  )
                    , WorkingServices.GetParaFromOject("@NhomLoaiMau", string.IsNullOrEmpty(manhomloaiMau)?(object)DBNull.Value: manhomloaiMau)

                };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNghiem_DSChiDinhXN", sqlPara).Tables[0];

            //string sqlQuery = "select k.*, nlm.MaNhomLoaiMau, nlm.TenNhomLoaiMau, nlm.ID2 as BCRoboTypeID, n.TenNhomCLS, xn.KhongSD from KetQua_CLS_XetNghiem k ";
            //sqlQuery += "\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem xn on k.MaXN = xn.MaXN ";
            //sqlQuery += "\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on k.MaNhomCLS = n.MaNhomCLS ";
            //sqlQuery += "\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_LoaiMau lm on k.LoaiMau = lm.MaLoaiMau";
            //sqlQuery += "\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_LoaiMau_Nhom nlm on lm.MaNhomLoaiMau = nlm.MaNhomLoaiMau";
            //sqlQuery += string.Format( "\n  where k.MatiepNhan in ({0})", _MaTiepNhan.Contains("'")?_MaTiepNhan: string.Format("'{0}'", _MaTiepNhan));
            //sqlQuery += "\n and xn.KhongSD = 1";
            //if (!string.IsNullOrEmpty(manhomloaiMau))
            //    sqlQuery += string.Format("\n and lm.MaNhomLoaiMau in ({0})", manhomloaiMau);
            //sqlQuery += "\n order by k.MaTiepNhan,xn.ThuTuIn, xn.SapXep";
            //return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public List<KETQUA_CLS_XETNGHIEM> lstXetnghiem(List<string> lstMaTiepNhan, string maOngMau)
        {
            var lastLoaiMau_MaTiepNhan = new List<string>();

            DataTable dt = Load_ChiDinhXetNghiemDichVuTheoOngMau(lstMaTiepNhan, maOngMau);
            var objList = new List<KETQUA_CLS_XETNGHIEM>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var matiepNhan = StringConverter.ToString(dt.Rows[i]["matiepnhan"]);
                    var xnDichVu = NumberConverter.To<bool>(dt.Rows[i]["KhongSD"]);
                     
                    var obj = new KETQUA_CLS_XETNGHIEM();

                    obj.Matiepnhan = StringConverter.ToString(dt.Rows[i]["matiepnhan"]);
                    obj.Maxn = StringConverter.ToString(dt.Rows[i]["maxn"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["tenxn"].ToString()))
                        obj.Tenxn = StringConverter.ToString(dt.Rows[i]["tenxn"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["ketqua"].ToString()))
                        obj.Ketqua = StringConverter.ToString(dt.Rows[i]["ketqua"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["ghichu"].ToString()))
                        obj.Ghichu = StringConverter.ToString(dt.Rows[i]["ghichu"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["manhomcls"].ToString()))
                        obj.Manhomcls = StringConverter.ToString(dt.Rows[i]["manhomcls"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["csbt"].ToString()))
                        obj.Csbt = StringConverter.ToString(dt.Rows[i]["csbt"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["donvi"].ToString()))
                        obj.Donvi = StringConverter.ToString(dt.Rows[i]["donvi"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["nguongtren"].ToString()))
                        obj.Nguongtren = NumberConverter.To<float>(dt.Rows[i]["nguongtren"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["nguongduoi"].ToString()))
                        obj.Nguongduoi = NumberConverter.To<float>(dt.Rows[i]["nguongduoi"]);
                    obj.Thutuin = NumberConverter.To<int>(dt.Rows[i]["thutuin"]);
                    obj.Xnchinh = NumberConverter.To<bool>(dt.Rows[i]["xnchinh"]);
                    obj.Khongsudung = NumberConverter.To<bool>(dt.Rows[i]["khongsudung"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["loaimau"].ToString()))
                        obj.Loaimau = StringConverter.ToString(dt.Rows[i]["loaimau"]);
                    obj.Thoigiannhap = (DateTime)dt.Rows[i]["thoigiannhap"];
                    if (!string.IsNullOrEmpty(dt.Rows[i]["profileid"].ToString()))
                        obj.Profileid = StringConverter.ToString(dt.Rows[i]["profileid"]);
                    obj.Flat = NumberConverter.To<int>(dt.Rows[i]["flat"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["trangthai"].ToString()))
                        obj.Trangthai = StringConverter.ToString(dt.Rows[i]["trangthai"]);
                    obj.Xacnhankq = NumberConverter.To<bool>(dt.Rows[i]["xacnhankq"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["nguoixacnhan"].ToString()))
                        obj.Nguoixacnhan = StringConverter.ToString(dt.Rows[i]["nguoixacnhan"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["dkbatthuong"].ToString()))
                        obj.Dkbatthuong = StringConverter.ToString(dt.Rows[i]["dkbatthuong"]);
                    obj.Tgcoketqua = NumberConverter.To<int>(dt.Rows[i]["tgcoketqua"]);
                    obj.Giachuan = NumberConverter.To<decimal>(dt.Rows[i]["giachuan"]);
                    obj.Giarieng = NumberConverter.To<decimal>(dt.Rows[i]["giarieng"]);
                    obj.Hesoxn = NumberConverter.To<int>(dt.Rows[i]["hesoxn"]);
                    obj.Madichvucls = NumberConverter.To<int>(dt.Rows[i]["madichvucls"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["thoigiannhapkq"].ToString()))
                        obj.Thoigiannhapkq = (DateTime)dt.Rows[i]["thoigiannhapkq"];
                    if (!string.IsNullOrEmpty(dt.Rows[i]["thoigiansuakq"].ToString()))
                        obj.Thoigiansuakq = (DateTime)dt.Rows[i]["thoigiansuakq"];
                    if (!string.IsNullOrEmpty(dt.Rows[i]["usernhapkq"].ToString()))
                        obj.Usernhapkq = StringConverter.ToString(dt.Rows[i]["usernhapkq"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["usersuakq"].ToString()))
                        obj.Usersuakq = StringConverter.ToString(dt.Rows[i]["usersuakq"]);
                    obj.Dathutien = NumberConverter.To<bool>(dt.Rows[i]["dathutien"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["usernhapcd"].ToString()))
                        obj.Usernhapcd = StringConverter.ToString(dt.Rows[i]["usernhapcd"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["mavattu"].ToString()))
                        obj.Mavattu = StringConverter.ToString(dt.Rows[i]["mavattu"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["dvttieuhao"].ToString()))
                        obj.Dvttieuhao = StringConverter.ToString(dt.Rows[i]["dvttieuhao"]);
                    obj.Tieuhao = NumberConverter.To<float>(dt.Rows[i]["tieuhao"]);
                    obj.Chietkhau = NumberConverter.To<float>(dt.Rows[i]["chietkhau"]);
                    obj.Tiencong = NumberConverter.To<decimal>(dt.Rows[i]["tiencong"]);
                    obj.Hesoquidoi = NumberConverter.To<float>(dt.Rows[i]["hesoquidoi"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["ketquaquidoi"].ToString()))
                        obj.Ketquaquidoi = NumberConverter.To<float>(dt.Rows[i]["ketquaquidoi"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["donviquidoi"].ToString()))
                        obj.Donviquidoi = StringConverter.ToString(dt.Rows[i]["donviquidoi"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["csbtquidoi"].ToString()))
                        obj.Csbtquidoi = StringConverter.ToString(dt.Rows[i]["csbtquidoi"]);
                    obj.Dadownload = NumberConverter.To<bool>(dt.Rows[i]["dadownload"]);
                    obj.Idmaydownload = NumberConverter.To<int>(dt.Rows[i]["idmaydownload"]);
                    obj.Idmayxetnghiem = NumberConverter.To<int>(dt.Rows[i]["idmayxetnghiem"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["tenmayxetnghiem"].ToString()))
                        obj.Tenmayxetnghiem = StringConverter.ToString(dt.Rows[i]["tenmayxetnghiem"]);
                    obj.Maphanloai = StringConverter.ToString(dt.Rows[i]["maphanloai"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["datedownload"].ToString()))
                        obj.Datedownload = (DateTime)dt.Rows[i]["datedownload"];
                    if (!string.IsNullOrEmpty(dt.Rows[i]["maxnmay"].ToString()))
                        obj.Maxnmay = StringConverter.ToString(dt.Rows[i]["maxnmay"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["uploadweb"].ToString()))
                        obj.Uploadweb = NumberConverter.To<bool>(dt.Rows[i]["uploadweb"]);
                    obj.Khongin = NumberConverter.To<bool>(dt.Rows[i]["khongin"]);
                    obj.Giabenhnhan = NumberConverter.To<decimal>(dt.Rows[i]["giabenhnhan"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["stt"].ToString()))
                        obj.Stt = StringConverter.ToString(dt.Rows[i]["stt"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["rsophieuyeucau"].ToString()))
                        obj.Rsophieuyeucau = StringConverter.ToString(dt.Rows[i]["rsophieuyeucau"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["maxn_his"].ToString()))
                        obj.Maxn_his = StringConverter.ToString(dt.Rows[i]["maxn_his"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["transferresultothis"].ToString()))
                        obj.Transferresultothis = NumberConverter.To<int>(dt.Rows[i]["transferresultothis"]);
                    obj.Downloadanother = NumberConverter.To<bool>(dt.Rows[i]["downloadanother"]);

                    if (!string.IsNullOrEmpty(dt.Rows[i]["thoigianlaymau"].ToString()))
                        obj.Thoigianlaymau = (DateTime)dt.Rows[i]["thoigianlaymau"];

                    obj.Nguoilaymau = StringConverter.ToString(dt.Rows[i]["nguoilaymau"]);
                    obj.TenNhomLoaimau = StringConverter.ToString(dt.Rows[i]["TenNhomLoaiMau"]);
                    obj.BCRoBoTypeID = StringConverter.ToString(dt.Rows[i]["BCRoboTypeID"]);
                    obj.TenNhomCLS = StringConverter.ToString(dt.Rows[i]["MaNhomLoaiMau"]);
                    obj.TenNhomCLS = StringConverter.ToString(dt.Rows[i]["TenNhomCLS"]);
                    if (!string.IsNullOrEmpty(dt.Rows[i]["idchitiethis"].ToString()))
                        obj.Idchitiethis = StringConverter.ToString(dt.Rows[i]["idchitiethis"]);
                    objList.Add(obj);
                }
            }
            return objList;
        }
        #endregion
        #region Hinh anh may huyet do
        public int CapNhat_HinhAnh_MayXN(string maTiepNhan, string idMay, string maXnMay, string chuoiHinhAnh, Image hinhAnh)
        {
            //insKetQua_HinhAnh_MayXN
            //@MaTiepNhan, @IDMay, @MaXnMay, @ChuoiHinhAnh, @HinhAnh
            var paraHinh = new SqlParameter();
            paraHinh.ParameterName = "@HinhAnh";
            paraHinh.SqlDbType = SqlDbType.Binary;
            paraHinh.Value = hinhAnh == null ? (object)DBNull.Value : GraphicSupport.ImageToByteArray(hinhAnh);
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@IDMay", idMay),
                WorkingServices.GetParaFromOject("@MaXnMay", maXnMay),
                WorkingServices.GetParaFromOject("@ChuoiHinhAnh", chuoiHinhAnh),
               paraHinh
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "insKetQua_HinhAnh_MayXN"
             , sqlPara);
        }
        public int Xoa_HinhAnh_MayXn(string maTiepNhan, string idMay)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@IDMay", idMay),
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "delKetQua_HinhAnh_MayXN"
             , sqlPara);
        }
        public DataTable Data_HinhAnh_TuMay(string maTiepNhan, string IdMay)
        {
            //selKetQua_HinhAnh_BieuDoTuMay
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                , WorkingServices.GetParaFromOject("@idMay",string.IsNullOrEmpty(IdMay)?(object)DBNull.Value: IdMay)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selKetQua_HinhAnh_BieuDoTuMay", sqlPara);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        #endregion
        #region Cap nhat dang xu ly
        public int CapNhat_TrangThaiDangXuLy_ChoBoPhan(string maTiepNhan, List<string> lstBoPhan, bool dangXuly)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@lsMaBoPhan", string.Join(",",lstBoPhan))
                    , WorkingServices.GetParaFromOject("@DangXuly", dangXuly)

                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
              , "updTrangThaiDangXuLy_BoPhan"
              , sqlPara);
        }
        public int CapNhat_TrangThaiDangXuLy_ChoNhom(string maTiepNhan, List<string> lstNhom, bool dangXuly)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@lsNhom", string.Join(",",lstNhom))
                    , WorkingServices.GetParaFromOject("@DangXuly", dangXuly)

                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
              , "updTrangThaiDangXuLy_Nhom"
              , sqlPara);
        }
        #endregion
        #region XetNghiem_LayMauThuThuat
        public int InsUpdDel_XetNghiem_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo, string flag)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "Ins_Upd_Del_XetNghiem_MauThuThuat", new SqlParameter[]
                     {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan)
                        ,WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn)
                        ,WorkingServices.GetParaFromOject("@MauCoNgoai", objInfo.Maucongoai)
                        ,WorkingServices.GetParaFromOject("@MauCoTrong", objInfo.Maucotrong)
                        ,WorkingServices.GetParaFromOject("@MauAmDao", objInfo.Mauamdao)
                        ,WorkingServices.GetParaFromOject("@BSLayMau", objInfo.Bslaymau)
                        ,WorkingServices.GetParaFromOject("@ThoiGianLayMauThuThuat", objInfo.Thoigianlaymauthuthuat)
                        ,WorkingServices.GetParaFromOject("@DMLFlag", flag)
                     });
        }
        public int Delete_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo)
        {
            return InsUpdDel_XetNghiem_LayMauThuThuat(objInfo, "D");
        }
        public int Insert_Update_XetNghiem_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo)
        {
            if (Data_LayMauThuThuat(objInfo.Matiepnhan, objInfo.Maxn).Rows.Count > 0)
                return InsUpdDel_XetNghiem_LayMauThuThuat(objInfo, "U");
            else
                return InsUpdDel_XetNghiem_LayMauThuThuat(objInfo, "I");
        }
        public DataTable Data_LayMauThuThuat(string matiepnhan, string maxn)
        {
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_XetNghiem_MauThuThuat", new SqlParameter[] {
            WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),WorkingServices.GetParaFromOject("@MaXN", maxn)}).Tables[0];
        }
        public KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT GetInfo_XetNghiem_LayMauThuThuat(string matiepnhan, string maxn)
        {
            var data = Data_LayMauThuThuat(matiepnhan, maxn);
            if (data.Rows.Count > 0)
            {
                return GetInfo_XetNghiem_LayMauThuThuatByRow(data.Rows[0]);
            }
            return null;
        }
        public KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT GetInfo_XetNghiem_LayMauThuThuatByRow(DataRow dr)
        {
            var obj = new KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT();
            obj.Matiepnhan = StringConverter.ToString(dr["matiepnhan"]);
            obj.Maxn = StringConverter.ToString(dr["maxn"]);
            obj.Maucongoai = NumberConverter.To<bool>(dr["maucongoai"]);
            obj.Maucotrong = NumberConverter.To<bool>(dr["maucotrong"]);
            obj.Mauamdao = NumberConverter.To<bool>(dr["mauamdao"]);
            if (!string.IsNullOrEmpty(dr["bslaymau"].ToString()))
                obj.Bslaymau = StringConverter.ToString(dr["bslaymau"]);
            if (!string.IsNullOrEmpty(dr["thoigianlaymauthuthuat"].ToString()))
                obj.Thoigianlaymauthuthuat = (DateTime)dr["thoigianlaymauthuthuat"];

            return obj;
        }
        #endregion
        #region Nhận xét - Đề nghị - Kết luận => Nhóm
       public int Update_NhanXetDeNghi_Nhom(string maTiepNhan, string maNhomCLS, string nhanXet, string nguoiNhanXet
           , string deNghi, string nguoiDeNghi, string ketLuan, string nguoiKetLuan, bool nguyCoCao, bool xetNghiemLan2
           , bool thamgiachandoan, bool chandoancobenh)
        {
            var sqlPara = new SqlParameter[] {
                  WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                , WorkingServices.GetParaFromOject("@MaNhom", maNhomCLS)
                , WorkingServices.GetParaFromOject("@NguoiNhanXet", nguoiNhanXet)
                , WorkingServices.GetParaFromOject("@NhanXet", nhanXet)
                , WorkingServices.GetParaFromOject("@NguoiDeNghi", nguoiDeNghi)
                , WorkingServices.GetParaFromOject("@DeNghi", deNghi)
                , WorkingServices.GetParaFromOject("@NguoiKetLuan", nguoiKetLuan)
                , WorkingServices.GetParaFromOject("@KetLuan", ketLuan)
                , WorkingServices.GetParaFromOject("@thamgiachandoan", thamgiachandoan)
                , WorkingServices.GetParaFromOject("@chandoancobenh", chandoancobenh)
                , WorkingServices.GetParaFromOject("@nguyCoCao", nguyCoCao)
                , WorkingServices.GetParaFromOject("@xetNghiemLan2", xetNghiemLan2)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_NhanXet_DeNghi_Nhom", sqlPara);
        }
        #endregion

    }
}
