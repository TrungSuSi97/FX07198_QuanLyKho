using System;
using System.Collections.Generic;
using System.Data;
using TPH.LIS.Log.Model;

namespace TPH.LIS.Log.Repositories.WorkingLog
{
    public interface IWorkingLogRepository
    {
        object WriteLog_BenhNhan_TiepNhan(LogActionId actionId, string userAction, string maTiepNhan);
        object WriteLog_BenhNhan_CLS_XetNghiem(LogActionId actionId, string userAction, string maTiepNhan);
        object WriteLog_BenhNhan_CLS_SieuAm(LogActionId actionId, string userAction, string maTiepNhan);
        object WriteLog_BenhNhan_CLS_NoiSoi(LogActionId actionId, string userAction, string maTiepNhan);
        object WriteLog_BenhNhan_CLS_XQuang(LogActionId actionId, string userAction, string maTiepNhan);
        object WriteLog_BenhNhan_CLS_DVKhac(LogActionId actionId, string userAction, string maTiepNhan);
        object WriteLog_KetQua_CLS_XetNghiem(LogActionId actionId, string userAction, string maTiepNhan,
            List<string> maxetNghiem, string maProfile, List<NewValue> lstNewValue = null);
        object WriteLog_KetQua_CLS_XetNghiem_KetQua(LogActionId actionId, string userAction, string maTiepNhan,
        string maxetNghiem, List<NewValue> lstNewValue = null);
        object WriteLog_KetQua_CLS_SieuAm(LogActionId actionId, string userAction, string maTiepNhan,
            string maSoMau);
        object WriteLog_p_payment(LogActionId actionId, string userAction, string maTiepNhan,
        string maSoMau);
        object WriteLog_KetQua_CLS_NoiSoi(LogActionId actionId, string userAction, string maTiepNhan,
            string maSoMauNoiSoi);

        object WriteLog_KetQua_CLS_XQuang(LogActionId actionId, string userAction, string maTiepNhan,
            string maKyThuatChup, string maVungChup);

        object WriteLog_KetQua_CLS_DVKhac(LogActionId actionId, string userAction, string maTiepNhan,
            string maDvKhac, string maVungChup);
        int WriteLog_Login(string userAction);
        int WriteLog_ChangeInstrumentSid(string fromSid, string toSid, DateTime fromDate, DateTime toDate, string userAction);
        int NhatKy_InKetQua(string matiepNhan, string BSKyTen, string NguoiIn, string NhomXetNghiem, string XnChon
            , int LanIn, string PCThucHien);
        DataTable DataNhatKy_InKetQua(string maTiepNhan);
        object WriteLog_DanhMucMapping_XetNghiem(LogActionId actionId, string userAction, string maXn, string idMayXN);
        DataTable ReadLog_instrumentSid(DateTime actionFromDate, DateTime actionToDate, string testcode, bool isProfile, int inID, string fromSid, string toSid);
        DataTable ReadLog_List(string tableId, LogActionId actionId, string userAction,
            string desription, DateTime fromDate, DateTime toDate, string matiepnhan);
        DataTable ReadLog_Detail(string logId);
        List<NewValue> ConvertStringToNewList(string str);
        int WriteLog_KetQua_XetNghiem_Duyet(string maTiepNhan, string barcode, string soHoSo, string maBn, List<NhatKy_DuyetKetQua_ChiTiet> lstlog);
        #region HeThong_NhatKyDanhMuc
        int Insert_HeThong_NhatKyDanhMuc(HETHONG_NHATKYDANHMUC objInfo);
        DataTable Data_HeThong_NhatKyDanhMucById(long id);
        DataTable Data_HeThong_NhatKyDanhMucByDate(DateTime fromdate, DateTime todate,string IDNhatKy);
        DataTable Data_HeThong_NhatKyDanhMucByMaDanhMuc(string MaDanhMuc, string IDNhatKy);
        #endregion
    }
}
