namespace TPH.Lab.Middleware.LISConnect.Services
{
    using DataAccesses;
    using System.Data;
    using Helpers.Enum;
    using System.Collections.Generic;
    using LIS.Patient.Model;
    using Data.HIS.Models;
    using HISConnect.Models;
    using TPH.Lab.Middleware.LISConnect.Models;
    using System;
    using TPH.Data.HIS.HISDataCommon;
    using TPH.LIS.Common.Extensions;
    using TPH.LIS.Common.Controls;
    using DevExpress.Utils.About;
    using DevExpress.Office.Utils;

    public class ConnectHISService : IConnectHISService
    {
        private readonly IConnectHISDataAccess _iHisData = new ConnectHISDataAccess();

        public HISReturnBase DanhMucHIS(HISParaInfo para, HisConnection hisInfo, List<HisFunctionConfig> hisFunctionMapping)
        {
            return _iHisData.DanhMucHIS(para, hisInfo, hisFunctionMapping);
        }
        public string InsertPatientFromHIS(BenhNhanInfoForHIS lisInfo
            , bool updateGet, HisConnection hisConnect, List<HisFunctionConfig> hisFunction, bool useHISBarcode)
        {
            return _iHisData.InsertPatientFromHIS(lisInfo, updateGet, hisConnect, hisFunction, useHISBarcode);
        }
        public HISReturnBase GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction
            , HisParaGetList paraInfo, List<HISDataColumnNames> hisColumns
            , bool onlyNotGet = false, HISDataColumnNames hColumnName = null, DataTable dataMapping = null
            )
        {
            return _iHisData.GetPatientOrderedDetail(hisConnect, hisFunction
            , paraInfo, hisColumns, onlyNotGet, hColumnName, dataMapping);
        }
        public HISReturnBase GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList)
        {
            return _iHisData.GetPatientInformationDetail(hisConnect, hisFunction, paraInfoList);
        }
        public DataTable DataMapping(int hisproviderID)
        {
            return _iHisData.DataMapping(hisproviderID);
        }
        public DataTable MergeMappingLIS(DataTable dataSource, HISDataColumnNames hColumnName, int hisproviderID, DataTable mappingData = null)
        {
            return _iHisData.MergeMappingLIS(dataSource, hColumnName, hisproviderID, mappingData);
        }
        public HISReturnBase GetPatientOrderedList(HisConnection hisInfo, List<HisFunctionConfig> hisFunctionMapping, HisParaGetList paraInfo, HISDataColumnNames hColumnName)
        {
            return _iHisData.GetPatientOrderedList(hisInfo, hisFunctionMapping, paraInfo, hColumnName);
        }
        public int SoLuongMau(string matiepnhan, int theoNhom)
        {
            return _iHisData.SoLuongMau(matiepnhan, theoNhom);
        }
        public int LISCheckOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info)
        {
            return _iHisData.LISCheckOrder(hisConnect, hisFunction, info);
        }
        public HISReturnBase Update_HuyKetQua(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisData.Update_HuyKetQua(hisConnect, hisFunction, paraInfoList);
        }
        public int LISTransferResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info)
        {
            return _iHisData.LISTransferResult(hisConnect, hisFunction, info);
        }
        public int UploadFileToHis(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info, bool fromAuto = false)
        {
            return _iHisData.UploadFileToHis(hisConnect, hisFunction, info, fromAuto);
        }
        public int UploadValidResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HISResultValid> paraInfoList)
        {
            return _iHisData.UploadValidResult(hisConnect, hisFunction, paraInfoList);
        }
        public int UpdateLISTransferResult(BenhNhanInfoForHIS info)
        {
            return _iHisData.UpdateLISTransferResult(info);
        }
        public DataTable DataUploadToHisList(string matiepnhan
            , bool daxacnhan, bool dain)
        {
            return _iHisData.DataUploadToHisList(matiepnhan, daxacnhan, dain);
        }
        public BenhNhanInfoForHIS GetDataUploadToHIS(GetUploadCondit uploadCondit)
        {
            return _iHisData.GetDataUploadToHIS(uploadCondit);
        }
        public DataTable DataUploadFileList()
        {
            return _iHisData.DataUploadFileList();
        }
        public bool ExistsMaBenhNhan(string mabenhnhan)
        {
            return _iHisData.ExistsMaBenhNhan(mabenhnhan);
        }
        public bool ExistsMaBenhNhanVaBarcode(string mabenhnhan, string matiepnhan)
        {
            return _iHisData.ExistsMaBenhNhanVaBarcode(mabenhnhan, matiepnhan);
        }
        public bool ExistsMaBenhNhanVaMaTiepNhan(string mabenhnhan, string matiepnhan)
        {
            return _iHisData.ExistsMaBenhNhanVaMaTiepNhan(mabenhnhan, matiepnhan);
        }
        public bool ExistsMaTiepNhan(string matiepnhan)
        {
            return _iHisData.ExistsMaTiepNhan(matiepnhan);
        }
        public bool ExistsBarcode(string barcode)
        {
            return _iHisData.ExistsBarcode(barcode);
        }
        public bool ExistsBarcodeWithday(string barcode, int limitDay)
        {
            return _iHisData.ExistsBarcodeWithday(barcode, limitDay);
        }
        public bool CapNhat_ChuaUpload(string maTiepNhan, string maXN)
        {
            return _iHisData.CapNhat_ChuaUpload(maTiepNhan, maXN);
        }
        public bool CapNhat_ChuaUploadVS(string maTiepNhan, string maXN)
        {
            return _iHisData.CapNhat_ChuaUploadVS(maTiepNhan, maXN);
        }
        public List<HisConnection> DataHisThongTin()
        {
            return _iHisData.DataHisThongTin();
        }
        public List<HisFunctionConfig> DataHisThongTinHam()
        {
            return _iHisData.DataHisThongTinHam();
        }
        public List<HISDataColumnNames> DataHisThongTinMappingCot()
        {
            return _iHisData.DataHisThongTinMappingCot();
        }
        public HISDataColumnNames GetHisThongTinMappingCot(HisConnection hisInfo, List<HISDataColumnNames> columnsList)
        {
            return _iHisData.GetHisThongTinMappingCot(hisInfo, columnsList);
        }
        public HisFunctionConfig GetHisThongTinMappingHam(HisConnection hisInfo, List<HisFunctionConfig> hisFunctionConfigList)
        {
            return _iHisData.GetHisThongTinMappingHam(hisInfo, hisFunctionConfigList);
        }
        public HisConnection GetHisThongTinMappingHis(string hisID, List<HisConnection> hisConnectionList)
        {
            return _iHisData.GetHisThongTinMappingHis(hisID, hisConnectionList);
        }
        public DataTable DataTableHisThongTin(string HisID = "")
        {
            return _iHisData.DataTableHisThongTin(HisID);
        }
        public DataTable DataTableHisThongTinHamn(string HisID = "")
        {
            return _iHisData.DataTableHisThongTinHamn(HisID);
        }
        public DataTable DataTableHisThongTinMappingCot(string HisID = "")
        {
            return _iHisData.DataTableHisThongTinMappingCot(HisID);
        }
        public void HisNhapCauHinhTheoChuan(int HisID, string HisName)
        {
            _iHisData.HisNhapCauHinhTheoChuan(HisID, HisName);
        }
        public int Update_HisConnection(HisConnection objInfo)
        {
            return _iHisData.Update_HisConnection(objInfo);
        }
        public int Update_ThongTinHam(HisFunctionConfig objInfo)
        {
            return _iHisData.Update_ThongTinHam(objInfo);
        }
        public int Insert_ThongTinTruongHISTraVe(string HisFieldName)
        {
            return _iHisData.Insert_ThongTinTruongHISTraVe(HisFieldName);
        }
        public int Insert_ThongTinThuTucHIS(string FunctionId)
        {
            return _iHisData.Insert_ThongTinThuTucHIS(FunctionId);
        }
        public int Update_ThongTinMappingCot(string HisID, string Hiscolumnsname, string Hiscolumnvalue)
        {
            return _iHisData.Update_ThongTinMappingCot(HisID, Hiscolumnsname, Hiscolumnvalue);
        }
        public HISReturnBase Get_BsLayMauThuThuat(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisData.Get_BsLayMauThuThuat(hisConnect, hisFunction, paraInfoList);
        }
        public HISReturnBase Get_ViTriLayMauPAP(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisData.Get_ViTriLayMauPAP(hisConnect, hisFunction, paraInfoList);
        }
        //For LabBlood
        public int InsertOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisData.InsertOrderedBloodElement(hisConnect, hisFunction, paraInfoList);
        }
        public int DeleteOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisData.DeleteOrderedBloodElement(hisConnect, hisFunction, paraInfoList);
        }
        public int ResetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisData.ResetBarcodeLabBlood(hisConnect, hisFunction, paraInfoList);
        }
        public int ReGetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisData.ReGetBarcodeLabBlood(hisConnect, hisFunction, paraInfoList);
        }

        public string MaNhanVienHis_TheoUser(string manguoiDung, int HisProviderId)
        {
            return _iHisData.MaNhanVienHis_TheoUser(manguoiDung, HisProviderId);
        }
        public string MaXNHis_TheoMaXNLIS(string maXNLIS, int HisProviderId, ref string manhomHIS)
        {
            return _iHisData.MaXNHis_TheoMaXNLIS(maXNLIS, HisProviderId, ref manhomHIS);
        }
        public HISReturnBase ThemTiepNhanVaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iHisData.ThemTiepNhanVaChiDinh(hisConnect, tiepNhan);
        }

        public HISReturnBase LayKetQua(HisConnection hisConnect, Dictionary<string, object> paraInfoList)
        {
            return _iHisData.LayKetQua(hisConnect, paraInfoList);
        }

        public HISReturnBase ThemChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iHisData.ThemChiDinh(hisConnect, tiepNhan);
        }

        public HISReturnBase XoaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iHisData.XoaChiDinh(hisConnect, tiepNhan);
        }

        public HISReturnBase UploadFileKetQua(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            return _iHisData.UploadFileKetQua(hisConnect, tiepNhan);
        }
        #region ParseHisOrder to Lis order info
        public BenhNhanInfoForHIS ParseHisPatientInfo(DataRow drSource
            , HISDataColumnNames hColumnNames
            , HisProvider hisId)
        {
            var bnInfo = new BenhNhanInfoForHIS();
            //bnInfo.Ngaytiepnhan = dtpDateIn.Value.Date;
            //bnInfo.Usernhap = CommonAppVarsAndFunctions.UserID;  
            //bnInfo.DateReceive = dtpNgayChiDinh.Value.Date;
            //bnInfo.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
            //bnInfo.Nguonnhap = InputSourceEnum.ByHIS.ToString();
            //Convert từng properties
            bnInfo.Sophieuyeucau = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhSophieuyeucau);
            bnInfo.Mabn = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMabenhnhan);
            bnInfo.Tenbn = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTenbenhnhan);
            var namsinh = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhNamsinh);
            if (WorkingServices.IsNumeric(String.IsNullOrEmpty(namsinh) ? "0" : namsinh))
                bnInfo.Tuoi = int.Parse(String.IsNullOrEmpty(namsinh) ? "0" : namsinh);
            else
                bnInfo.Tuoi = -1;
            string sinhNhatString = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhSinhnhat);
            if (hisId == HisProvider.DH_API)
            {
                //his format dd/MM
                var arr = sinhNhatString.Split('/');
                if (arr.Length > 1)
                {
                    try
                    {
                        bnInfo.Congaysinh = true;
                        bnInfo.Sinhnhat = new DateTime(bnInfo.Tuoi, int.Parse(arr[1]), int.Parse(arr[0]));
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.MSG_Waring_OK(String.Format("Sinh nhật: {0}/{1} \nKhông hợp lệ.", sinhNhatString, namsinh));
                    }
                }
            }
            else
            {
                bnInfo.Congaysinh = true;
                bnInfo.Sinhnhat = WorkingServices.GetValueFromDataRow_DateTimeNull(drSource, hColumnNames.chidinhSinhnhat);
            }

            if (bnInfo.Tuoi == 0 && bnInfo.Sinhnhat != null)
            {
                bnInfo.Congaysinh = true;
                bnInfo.Tuoi = bnInfo.Sinhnhat.Value.Year;
            }
            var gioiTinh = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhGioitinh);
            if (gioiTinh.Trim().Equals("nữ", StringComparison.OrdinalIgnoreCase) ||
                gioiTinh.Equals("F", StringComparison.OrdinalIgnoreCase) ||
                gioiTinh.Equals("0", StringComparison.OrdinalIgnoreCase))
                bnInfo.Gioitinh = "F";
            else if (gioiTinh.Trim().Equals("nam", StringComparison.OrdinalIgnoreCase) ||
                     gioiTinh.Equals("m", StringComparison.OrdinalIgnoreCase) ||
                     gioiTinh.Equals("1", StringComparison.OrdinalIgnoreCase))
                bnInfo.Gioitinh = "M";
            else
                bnInfo.Gioitinh = string.Empty;
            bnInfo.Diachi = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhDiachi);
            bnInfo.Chandoan = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhChandoan);
            bnInfo.Bacsicd = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMabacsi);
            bnInfo.Tenbacsichidinh = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTenbacsi);
            bnInfo.Madonvi = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMakhoaphong);
            bnInfo.Tendonvi = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTenkhoaphong);
            bnInfo.Sobhyt = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhSothebhyt);
            bnInfo.Sdt = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhSodienthoai);
            bnInfo.Buong = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhBuong);
            bnInfo.Giuong = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhGiuong);
            bnInfo.Allowdownload = true;
            bnInfo.Ngaydk = WorkingServices.GetValueFromDataRow_DateTimeNull(drSource, hColumnNames.chidinhNgaychidinh);
            bnInfo.Idcongdan = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhIDCongDan);
            bnInfo.Sohochieu = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhSoHoChieu);
            bnInfo.Ngaycaphochieu = WorkingServices.GetValueFromDataRow_DateTimeNull(drSource, hColumnNames.chidinhNgayCapHoChieu);
            bnInfo.Ghichuhochieu = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhGhiChuHoChieu);
            //DH CT
            bnInfo.Dotkham_id = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhDotKhamID);
            bnInfo.Chuyenkhoa_id = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chiDinhChuyenKhoaID);
            bnInfo.Giayto_id = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhGiayToID);
            bnInfo.Bn_id = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMabenhan);
            bnInfo.Manoicapthebhyt = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMaNoiCapTheBhyt);
            bnInfo.Manoidangkythebhyt = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMaNoiDangKyTheBhyt);
            bnInfo.Madonvihopdong = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMadvhd);
            bnInfo.Tendonvihopdong = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTendvhd);
            var noitruChu = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhNoitruchu);
            var noitruBool = WorkingServices.GetValueFromDataRow_Bool(drSource, hColumnNames.chidinhNoitru);
            bnInfo.Noitru = (noitruChu.Equals("I") || noitruChu.ToUpper().Equals("NỘI TRÚ") || noitruBool);
            bnInfo.Hisproviderid = (int)hisId;
            bnInfo.Abo = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhNhomMau);
            bnInfo.Rh = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhRh);
            bnInfo.Masophong = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhSophong);
            bnInfo.Noicongtac = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhNoicongtac);
            bnInfo.Tenphong = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTenphong);
            bnInfo.Makhoahienthoi = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMakhoahienthoi);
            bnInfo.Tenkhoahienthoi = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTenkhoahienthoi);
            bnInfo.Khamsuckhoe = WorkingServices.GetValueFromDataRow_Bool(drSource, hColumnNames.chidinhKhamsuckhoe);
            //  Mức độ ưu tiên (vd: 1: TW – 2: Cấp cao – 3: Cấp cứu – 0: Thường)
            var uuTien = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhUutien);
            bnInfo.Uutien = (WorkingServices.IsNumeric(uuTien) ? int.Parse(uuTien) : 0);
            bnInfo.Capcuu = (WorkingServices.IsNumeric(uuTien) ? int.Parse(uuTien) == 1 : !uuTien.Equals("R", StringComparison.OrdinalIgnoreCase));
            bnInfo.Ngayhethanbhyt = WorkingServices.GetValueFromDataRow_DateTimeNull(drSource, hColumnNames.chidinhnNgayhethanbhy);
            bnInfo.Tgvaovien = WorkingServices.GetValueFromDataRow_DateTimeNull(drSource, hColumnNames.chidinhNgayvaovien);
            bnInfo.Ngaynhapvien = WorkingServices.GetValueFromDataRow_DateTimeNull(drSource, hColumnNames.chidinhNgaynhapvien);
            // bnInfo.Thoigiannhapvien = WorkingServices.GetValueFromDataRow_DateTimeNull(drSource, hColumnNames.chidinhNgaynhapvien);
            bnInfo.Masinhly = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMasinhly);
            bnInfo.Tensinhly = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTensinhly);
            bnInfo.Tendoituongdichvu = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhTendoituong);
            bnInfo.Doituongdichvu = WorkingServices.GetValueFromDataRow_String(drSource, hColumnNames.chidinhMadoituong);

            if (hisId == HisProvider.ISofH && string.IsNullOrEmpty(bnInfo.Doituongdichvu ?? string.Empty))
            {
                bnInfo.Doituongdichvu = (!string.IsNullOrEmpty(bnInfo.Sobhyt) ? "BHYT" : (bnInfo.Benhkemtheo.Equals("Khám sức khỏe", StringComparison.OrdinalIgnoreCase) ? "KSK" : "DV"));
                bnInfo.Tendoituongdichvu = (bnInfo.Doituongdichvu == "BHYT" ? "Bảo hiểm y tế" : (bnInfo.Doituongdichvu == "KSK" ? "Khám sức khỏe" : "Dịch vụ"));
            }
            else if (hisId == HisProvider.VNPTMN && string.IsNullOrEmpty(bnInfo.Doituongdichvu))
            {
                bnInfo.Doituongdichvu = (!string.IsNullOrEmpty(bnInfo.Sobhyt ?? string.Empty) ? "BHYT" : ((bnInfo.Benhkemtheo??string.Empty).Equals("Khám sức khỏe", StringComparison.OrdinalIgnoreCase) ? "KSK" : "DV"));
                bnInfo.Tendoituongdichvu = (bnInfo.Doituongdichvu == "BHYT" ? "Bảo hiểm y tế" : (bnInfo.Doituongdichvu == "KSK" ? "Khám sức khỏe" : "Dịch vụ"));
            }
            return bnInfo;
        }
        #endregion
    }
}
