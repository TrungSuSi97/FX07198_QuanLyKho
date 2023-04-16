using System;
using System.Collections.Generic;
using System.Data;
using TPH.LIS.Log.Model;
using TPH.LIS.Log.Repositories.WorkingLog;

namespace TPH.LIS.Log.Services.WorkingLog
{

    public class WorkingLogService : IWorkingLogService
    {
        private readonly IWorkingLogRepository _workingLogRepository;

        public WorkingLogService()
            : this(null)
        {
        }

        public WorkingLogService(IWorkingLogRepository workingLogRepository)
        {
            _workingLogRepository = workingLogRepository ?? new WorkingLogRepository();
        }

        public object WriteLog_BenhNhan_TiepNhan(LogActionId actionId, string userAction, string maTiepNhan)
        {
            return _workingLogRepository.WriteLog_BenhNhan_TiepNhan(actionId, userAction, maTiepNhan);
        }

        public object WriteLog_BenhNhan_CLS_XetNghiem(LogActionId actionId, string userAction, string maTiepNhan)
        {
            return _workingLogRepository.WriteLog_BenhNhan_CLS_XetNghiem(actionId, userAction, maTiepNhan);
        }

        public object WriteLog_BenhNhan_CLS_SieuAm(LogActionId actionId, string userAction, string maTiepNhan)
        {
            return _workingLogRepository.WriteLog_BenhNhan_CLS_SieuAm(actionId, userAction, maTiepNhan);
        }

        public object WriteLog_BenhNhan_CLS_NoiSoi(LogActionId actionId, string userAction, string maTiepNhan)
        {
            return _workingLogRepository.WriteLog_BenhNhan_CLS_NoiSoi(actionId, userAction, maTiepNhan);
        }

        public object WriteLog_BenhNhan_CLS_XQuang(LogActionId actionId, string userAction, string maTiepNhan)
        {
            return _workingLogRepository.WriteLog_BenhNhan_CLS_XQuang(actionId, userAction, maTiepNhan);
        }

        public object WriteLog_BenhNhan_CLS_DVKhac(LogActionId actionId, string userAction, string maTiepNhan)
        {
            return _workingLogRepository.WriteLog_BenhNhan_CLS_DVKhac(actionId, userAction, maTiepNhan);
        }

        public object WriteLog_KetQua_CLS_XetNghiem(LogActionId actionId, string userAction, string maTiepNhan,
            List<string> maxetNghiem, string maProfile, List<NewValue> lstNewValue = null)
        {
            return _workingLogRepository.WriteLog_KetQua_CLS_XetNghiem(actionId, userAction, maTiepNhan, maxetNghiem,
                maProfile, lstNewValue);
        }
        public object WriteLog_KetQua_CLS_XetNghiem_KetQua(LogActionId actionId, string userAction, string maTiepNhan,
        string maxetNghiem, List<NewValue> lstNewValue = null)
        {
            return _workingLogRepository.WriteLog_KetQua_CLS_XetNghiem_KetQua(actionId, userAction, maTiepNhan,
        maxetNghiem, lstNewValue);
        }
        public object WriteLog_KetQua_CLS_SieuAm(LogActionId actionId, string userAction, string maTiepNhan,
            string maSoMau)
        {
            return _workingLogRepository.WriteLog_KetQua_CLS_SieuAm(actionId, userAction, maTiepNhan,
                maSoMau);
        }
        public object WriteLog_p_payment(LogActionId actionId, string userAction, string maTiepNhan,
        string maSoMau)
        {
            return _workingLogRepository.WriteLog_p_payment(actionId, userAction, maTiepNhan,
                maSoMau);
        }
    

        public object WriteLog_KetQua_CLS_NoiSoi(LogActionId actionId, string userAction, string maTiepNhan,
            string maSoMauNoiSoi)
        {
            return _workingLogRepository.WriteLog_KetQua_CLS_NoiSoi(actionId, userAction, maTiepNhan,
                maSoMauNoiSoi);
        }

        public object WriteLog_KetQua_CLS_XQuang(LogActionId actionId, string userAction, string maTiepNhan,
            string maKyThuatChup, string maVungChup)
        {
            return _workingLogRepository.WriteLog_KetQua_CLS_XQuang(actionId, userAction, maTiepNhan,
                maKyThuatChup, maVungChup);
        }

        public object WriteLog_KetQua_CLS_DVKhac(LogActionId actionId, string userAction, string maTiepNhan,
            string maDvKhac, string maVungChup)
        {
            return _workingLogRepository.WriteLog_KetQua_CLS_DVKhac(actionId, userAction, maTiepNhan,
                maDvKhac, maVungChup);
        }
        public int NhatKy_InKetQua(string matiepNhan, string BSKyTen, string NguoiIn, string NhomXetNghiem, string XnChon
            , int LanIn, string PCThucHien)
        {
            return _workingLogRepository.NhatKy_InKetQua(matiepNhan, BSKyTen, NguoiIn, NhomXetNghiem, XnChon
            , LanIn, PCThucHien);
        }
        public DataTable DataNhatKy_InKetQua(string maTiepNhan)
        {
            return _workingLogRepository.DataNhatKy_InKetQua(maTiepNhan);
        }
        public int WriteLog_ChangeInstrumentSid(string fromSid, string toSid, DateTime fromDate, DateTime toDate, string userAction)
        {
            return _workingLogRepository.WriteLog_ChangeInstrumentSid(fromSid, toSid, fromDate, toDate, userAction);
        }
        public object WriteLog_DanhMucMapping_XetNghiem(LogActionId actionId, string userAction, string maXn, string idMayXN)
        {
            return _workingLogRepository.WriteLog_DanhMucMapping_XetNghiem(actionId, userAction, maXn, idMayXN);
        }
        public DataTable ReadLog_instrumentSid(DateTime actionFromDate, DateTime actionToDate, string testcode, bool isProfile, int inID, string fromSid, string toSid)
        {
            return _workingLogRepository.ReadLog_instrumentSid(actionFromDate, actionToDate, testcode, isProfile, inID, fromSid, toSid);
        }
        public int WriteLog_Login(string userAction)
        {
            return _workingLogRepository.WriteLog_Login(userAction);
        }
        public DataTable ReadLog_List(string tableId, LogActionId actionId, string userAction, string condition,
            string desription, DateTime fromDate, DateTime toDate, string matiepnhan)
        {
            return _workingLogRepository.ReadLog_List(tableId, actionId, userAction, desription, fromDate, toDate, matiepnhan);
        }
        public DataTable ReadLog_Detail(string logId)
        {
            return _workingLogRepository.ReadLog_Detail(logId);
        }
        public List<NewValue> ConvertStringToNewList(string str)
        {
            return _workingLogRepository.ConvertStringToNewList(str);
        }
        public int WriteLog_KetQua_XetNghiem_Duyet(string maTiepNhan, string barcode, string soHoSo, string maBn, List<NhatKy_DuyetKetQua_ChiTiet> lstlog)
        {
            return _workingLogRepository.WriteLog_KetQua_XetNghiem_Duyet(maTiepNhan, barcode, soHoSo, maBn, lstlog);
        }
        #region HeThong_NhatKyDanhMuc
        public int Insert_HeThong_NhatKyDanhMuc(HETHONG_NHATKYDANHMUC objInfo)
        {
            return _workingLogRepository.Insert_HeThong_NhatKyDanhMuc(objInfo);
        }
        public DataTable Data_HeThong_NhatKyDanhMucById(long id)
        {
            return _workingLogRepository.Data_HeThong_NhatKyDanhMucById(id);
        }
        public DataTable Data_HeThong_NhatKyDanhMucByDate(DateTime fromdate, DateTime todate, string IDNhatKy)
        {
            return _workingLogRepository.Data_HeThong_NhatKyDanhMucByDate(fromdate, todate, IDNhatKy);
        }
        public DataTable Data_HeThong_NhatKyDanhMucByMaDanhMuc(string MaDanhMuc, string IDNhatKy)
        {
            return _workingLogRepository.Data_HeThong_NhatKyDanhMucByMaDanhMuc(MaDanhMuc, IDNhatKy);
        }
        #endregion
    }
}
