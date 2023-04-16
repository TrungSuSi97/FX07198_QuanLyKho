namespace TPH.Lab.Middleware.LISConnect.DataAccesses
{
    using Helpers.Enum;
    using System.Collections.Generic;
    using System.Data;
    using LIS.Patient.Model;
    using Data.HIS.Models;
    using HISConnect.Models;
    using TPH.Lab.Middleware.LISConnect.Models;

    public interface IConnectHISDataAccess
    {
        HISReturnBase DanhMucHIS(HISParaInfo para, HisConnection hisInfo, List<HisFunctionConfig> hisFunctionMapping);
        string InsertPatientFromHIS(BenhNhanInfoForHIS lisInfo, bool updateGet
            , HisConnection hisConnect, List<HisFunctionConfig> hisFunction,bool useHISBarcode);
        HISReturnBase GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction
            , HisParaGetList paraInfo, List<HISDataColumnNames> hisColumns, bool onlyNotGet = false
            , HISDataColumnNames hColumnName = null, DataTable dataMapping = null);
        HISReturnBase GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList);
        DataTable DataMapping(int hisproviderID);
        DataTable MergeMappingLIS(DataTable dataSource, HISDataColumnNames hColumnName, int hisproviderID, DataTable mappingData = null);
        HISReturnBase GetPatientOrderedList(HisConnection hisInfo, List<HisFunctionConfig> hisFunctionMapping, HisParaGetList paraInfo, HISDataColumnNames hColumnName);
        int SoLuongMau(string matiepnhan, int theoNhom);
        int LISCheckOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info);
        HISReturnBase Update_HuyKetQua(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int LISTransferResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info);
        int UploadFileToHis(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, BenhNhanInfoForHIS info, bool fromAuto = false);
        int UploadValidResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HISResultValid> paraInfoList);
        int UpdateLISTransferResult(BenhNhanInfoForHIS info);
        DataTable DataUploadToHisList(string matiepnhan, bool daxacnhan, bool dain);
        BenhNhanInfoForHIS GetDataUploadToHIS(GetUploadCondit uploadCondit);
        DataTable DataUploadFileList();
        bool ExistsMaBenhNhan(string mabenhnhan);
        bool ExistsMaBenhNhanVaBarcode(string mabenhnhan, string matiepnhan);
        bool ExistsMaBenhNhanVaMaTiepNhan(string mabenhnhan, string matiepnhan);
        bool ExistsMaTiepNhan(string matiepnhan);
        bool ExistsBarcode(string barcode);
        bool ExistsBarcodeWithday(string barcode, int limitDay);
        bool CapNhat_ChuaUpload(string maTiepNhan, string maXN);
        bool CapNhat_ChuaUploadVS(string maTiepNhan, string maXN);
        List<HisConnection> DataHisThongTin();
        List<Data.HIS.Models.HisFunctionConfig> DataHisThongTinHam();
        List<HISDataColumnNames> DataHisThongTinMappingCot();
        HISDataColumnNames GetHisThongTinMappingCot(HisConnection hisInfo, List<HISDataColumnNames> columnsList);
        HisFunctionConfig GetHisThongTinMappingHam(HisConnection hisInfo, List<HisFunctionConfig> hisFunctionConfigList);
        HisConnection GetHisThongTinMappingHis(string hisID, List<HisConnection> hisConnectionList);
        DataTable DataTableHisThongTin(string HisID = "");
        DataTable DataTableHisThongTinHamn(string HisID = "");
        DataTable DataTableHisThongTinMappingCot(string HisID = "");
        void HisNhapCauHinhTheoChuan(int HisID, string HisName);
        int Update_HisConnection(HisConnection objInfo);
        int Update_ThongTinHam(HisFunctionConfig objInfo);
        int Insert_ThongTinTruongHISTraVe(string HisFieldName);
        int Insert_ThongTinThuTucHIS(string FunctionId);
        int Update_ThongTinMappingCot(string HisID, string Hiscolumnsname, string Hiscolumnvalue);
        HISReturnBase Get_BsLayMauThuThuat(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        HISReturnBase Get_ViTriLayMauPAP(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);

        //For LabBlood
        int InsertOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int DeleteOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int ResetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int ReGetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        string MaNhanVienHis_TheoUser(string manguoiDung, int HisProviderId);
        string MaXNHis_TheoMaXNLIS(string maXNLIS, int HisProviderId, ref string manhomHIS);
        HISReturnBase ThemTiepNhanVaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan);
        HISReturnBase LayKetQua(HisConnection hisConnect, Dictionary<string, object> paraInfoList);
        HISReturnBase ThemChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan);
        HISReturnBase XoaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan);
        HISReturnBase UploadFileKetQua(HisConnection hisConnect, Dictionary<string, object> tiepNhan);
    }
}
