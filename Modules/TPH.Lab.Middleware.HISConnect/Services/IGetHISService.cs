namespace TPH.Lab.Middleware.HISConnect.Services
{
    using System.Data;
    using System.Windows.Forms;
    using Models;
    using Data.HIS.Models;
    using System.Collections.Generic;

    public interface IGetHISService
    {
        HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns);
        void SetDataPropertyNameForDatagriview(DataGridView dgv, HisConnection hisConnect, List<HISDataColumnNames> hisColumns);
        HISReturnBase DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucKhoaPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucMayXN(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucSinhLy(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucCongTyHopDong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase DanhMucLoaiMau(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        int LISCheckHL7(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList, List<HisResultBase> paraResultBase);
        int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        HISReturnBase Update_HuyKetQua(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        HISReturnBase Update_TGHenTraKetQua(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        HISReturnBase GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList);
        HISReturnBase GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList);
        HISReturnBase GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList);
        DataTable GetUploadKeyOfOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList, ref List<string> SelectedColumns);
        DataTable GetUploadKeyOfDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList, ref List<string> SelectedColumns);
        int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList, ref List<string> lstNotFinishList);
        int UploadFileToHis(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList);
        int UploadValidResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HISResultValid> paraInfoList);
        HISReturnBase GetBarcodeFromHis(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList);
        HISReturnBase Get_BsLayMauThuThuat(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        HISReturnBase Get_ViTriLayMauPAP(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        HISReturnBase Get_ViTriLayMauSinhThiet(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        //LabBlood
        int InsertOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int DeleteOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int ResetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int ReGetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        HISReturnBase DanhSachGuiMauDi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        HISReturnBase ThemTiepNhanVaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan);
        HISReturnBase LayKetQua(HisConnection hisConnect, Dictionary<string, object> paraInfoList);
        HISReturnBase ThemChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan);
        HISReturnBase XoaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan);
        HISReturnBase UploadFileKetQua(HisConnection hisConnect, Dictionary<string, object> tiepNhan);

    }
}
