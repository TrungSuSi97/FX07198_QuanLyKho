using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Repositories;
using TPH.LIS.Common;

namespace TPH.LIS.Analyzer.Services
{
    public class AnalyzerResultService : IAnalyzerResultService
    {
        private readonly IAnalyzerResultRepository iAnalyzer = new AnalyzerResultRepository();
        public int Update_KQMay_Barcode(string fromSid, DateTime dtFromDate, string toSid
            , DateTime dtToDate, string userUpdate, string IDlist)
        {
            return iAnalyzer.Update_KQMay_Barcode(fromSid, dtFromDate, toSid, dtToDate, userUpdate, IDlist);
        }
        public string Update_KQMay_TrangThai(string id, string trangThai, bool forExcute = false)
        {
            return iAnalyzer.Update_KQMay_TrangThai(id, trangThai, forExcute);
        }
        public DataTable Data_Analyzer_Result(DateTime dateTuNgay, DateTime dateDenNgay
            , string barcode, string trangthai, string idMayXn, string[] nhomXn, string maXn
            , string userAllow, bool lanChaySau, int[] statusId, bool history = false
            , int topSelect = -1, int limitHour = -1, bool toolAuto = false, int loaiMay = -1
            )
        {
            return iAnalyzer.Data_Analyzer_Result(dateTuNgay, dateDenNgay
            , barcode, trangthai, idMayXn, nhomXn, maXn
            , userAllow, lanChaySau, statusId, history
            , topSelect, limitHour, toolAuto, loaiMay);
        }
        public void UpdateCLSResultFromDatatable(DataTable dtAnalyzerResult, DataTable dtconvertResult
            , ProgressBar probar, AutoResetEvent LockUpdateAuto, ref int iNumAuto
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien, EnumKieuLayKetQuaMay kieuLay
            , bool toolAuto, bool deKetQuaChuaDuyet, bool getLastRuntime, bool tuXacNhan, bool khongXacNhanKQbatThuong)
        {
            iAnalyzer.UpdateCLSResultFromDatatable(dtAnalyzerResult, dtconvertResult
            , probar, LockUpdateAuto, ref iNumAuto
            , clsXetNghiemDinhDangKetqua, userId, khuVucThucHien, kieuLay, toolAuto, deKetQuaChuaDuyet, getLastRuntime, tuXacNhan, khongXacNhanKQbatThuong);
        }
        public void UpdateCLSResultFromDataView(DataView analyzerResult, DataTable dtconvertResult
            , ProgressBar probar, AutoResetEvent LockUpdateManual, ref int iNumManual
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien, EnumKieuLayKetQuaMay kieuLay
            , bool toolAuto, bool deKetQuaChuaDuyet, bool getLastRuntime, bool tuXacNhan, bool khongXacNhanKQbatThuong)
        {
            iAnalyzer.UpdateCLSResultFromDataView(analyzerResult, dtconvertResult
            , probar, LockUpdateManual, ref iNumManual
            , clsXetNghiemDinhDangKetqua, userId, khuVucThucHien, kieuLay, toolAuto, deKetQuaChuaDuyet, getLastRuntime, tuXacNhan, khongXacNhanKQbatThuong);
        }

        public int UpdateResendInfinity(int ID)
        {
            return iAnalyzer.UpdateResendInfinity(ID);
        }
        public string Check_ConvertInstrumentresult(DataTable dtConvert, string mamay, string maxnmay,
             string ketQuaGoc, ref string posneg)
        {
            return iAnalyzer.Check_ConvertInstrumentresult(dtConvert, mamay, maxnmay,
             ketQuaGoc, ref posneg);
        }
        public string Convert_Result(string ketQuaGoc, string kqSoSanh, string kqBienDich
            , bool soSanhTuyetDoi)
        {
            return iAnalyzer.Convert_Result(ketQuaGoc, kqSoSanh, kqBienDich
            , soSanhTuyetDoi);
        }
        public int UpdateDownloadStatus(bool isDowloaded, string matiepnhan, List<string> maxn, string userID, bool isInfinity, bool normalAnalyzer)
        {
            return iAnalyzer.UpdateDownloadStatus(isDowloaded, matiepnhan, maxn, userID, isInfinity, normalAnalyzer);
        }
        public DataTable GetTestInDownloadList(DateTime? fromDate, DateTime? toDate, int downloaded, string seq
     , string idMayXetNghiem, string maXetNghiem, string nhomXn)
        {
            return iAnalyzer.GetTestInDownloadList(fromDate, toDate, downloaded, seq
     , idMayXetNghiem, maXetNghiem, nhomXn);
        }
        public DataTable GetTestingDownload(DateTime fromDate, DateTime toDate, bool dachidinh, bool downloaded, string maBenhNhan,
            string tenBenhNhan, string sid, string tenXetNghiem, string idMayXetNghiem
            , bool history = false)
        {
            return iAnalyzer.GetTestingDownload(fromDate, toDate, dachidinh, downloaded, maBenhNhan,
            tenBenhNhan, sid, tenXetNghiem, idMayXetNghiem
            , history);
        }
        public DataTable GetTestinCancel(DateTime fromDate, DateTime toDate, int downloaded, string maBenhNhan,
            string tenBenhNhan, string sid, string tenXetNghiem, string idMayXetNghiem)
        {
            return iAnalyzer.GetTestinCancel(fromDate, toDate, downloaded, maBenhNhan,
            tenBenhNhan, sid, tenXetNghiem, idMayXetNghiem);
        }
        public string Lay_MatiepNhan(bool RepeatBarcode, int DayScanSID, string seq)
        {
            return iAnalyzer.Lay_MatiepNhan(RepeatBarcode, DayScanSID, seq);
        }
        public int CapNhat_MaTiepNhan(string oldSeq, string newSeq, string maTiepNhan, string idList, int statusID)
        {
            return iAnalyzer.CapNhat_MaTiepNhan(oldSeq, newSeq, maTiepNhan, idList, statusID);
        }
        public DataTable Data_KetQuaMayChoGhepCode(int IdMayXN, int statusID)
        {
            return iAnalyzer.Data_KetQuaMayChoGhepCode(IdMayXN, statusID);
        }
        #region Cờ từ máy
        public DataTable Data_DanhSachCoTuMay(List<string> lstBoPhan, List<string> lstNhom, List<string> lstMay, string maTiepNhan)
        {
            return iAnalyzer.Data_DanhSachCoTuMay(lstBoPhan, lstNhom, lstMay, maTiepNhan);
        }
        public int Update_DaXemCoTuMay(List<string> lstId)
        {
            return iAnalyzer.Update_DaXemCoTuMay(lstId);
        }
        #endregion
    }
}
