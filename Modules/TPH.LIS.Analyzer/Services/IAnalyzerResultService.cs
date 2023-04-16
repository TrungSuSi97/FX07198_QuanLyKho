using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using TPH.LIS.Common;

namespace TPH.LIS.Analyzer.Services
{
    public interface IAnalyzerResultService
    {
        int Update_KQMay_Barcode(string fromSid, DateTime dtFromDate, string toSid, DateTime dtToDate
            , string userUpdate, string IDlist);
        string Update_KQMay_TrangThai(string id, string trangThai, bool forExcute = false);
        DataTable Data_Analyzer_Result(DateTime dateTuNgay, DateTime dateDenNgay
            , string barcode, string trangthai, string idMayXn, string[] nhomXn, string maXn
            , string userAllow, bool lanChaySau, int[] statusId, bool history = false
            , int topSelect = -1, int limitHour = -1, bool toolAuto = false, int loaiMay = -1);
        void UpdateCLSResultFromDatatable(DataTable dtAnalyzerResult, DataTable dtconvertResult
            , ProgressBar probar, AutoResetEvent LockUpdateAuto, ref int iNumAuto
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien, EnumKieuLayKetQuaMay kieuLay
            , bool toolAuto, bool deKetQuaChuaDuyet, bool getLastRuntime, bool tuXacNhan, bool khongXacNhanKQbatThuong);
        void UpdateCLSResultFromDataView(DataView analyzerResult, DataTable dtconvertResult
            , ProgressBar probar, AutoResetEvent LockUpdateManual, ref int iNumManual
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien, EnumKieuLayKetQuaMay kieuLay
            , bool toolAuto, bool deKetQuaChuaDuyet, bool getLastRuntime, bool tuXacNhan, bool khongXacNhanKQbatThuong);

        int UpdateResendInfinity(int ID);
        string Check_ConvertInstrumentresult(DataTable dtConvert, string mamay, string maxnmay,
            string ketQuaGoc, ref string posneg);
        string Convert_Result(string ketQuaGoc, string kqSoSanh, string kqBienDich, bool soSanhTuyetDoi);
        int UpdateDownloadStatus(bool isDowloaded, string matiepnhan, List<string> maxn, string userID, bool isInfinity, bool normalAnalyzer);
        DataTable GetTestInDownloadList(DateTime? fromDate, DateTime? toDate, int downloaded, string seq
     , string idMayXetNghiem, string maXetNghiem, string nhomXn);
        DataTable GetTestingDownload(DateTime fromDate, DateTime toDate, bool dachidinh, bool downloaded, string maBenhNhan,
            string tenBenhNhan, string sid, string tenXetNghiem, string idMayXetNghiem, bool history = false);
        DataTable GetTestinCancel(DateTime fromDate, DateTime toDate, int downloaded, string maBenhNhan,
            string tenBenhNhan, string sid, string tenXetNghiem, string idMayXetNghiem);
        #region Xử lý kết quả nhập lưới
        string Lay_MatiepNhan(bool RepeatBarcode, int DayScanSID, string seq);
        int CapNhat_MaTiepNhan(string oldSeq, string newSeq, string maTiepNhan, string idList, int statusID);
        DataTable Data_KetQuaMayChoGhepCode(int IdMayXN, int statusID);
        #endregion
        #region Cờ từ máy
        DataTable Data_DanhSachCoTuMay(List<string> lstBoPhan, List<string> lstNhom, List<string> lstMay, string maTiepNhan);
        int Update_DaXemCoTuMay(List<string> lstId);
        #endregion
    }
}
