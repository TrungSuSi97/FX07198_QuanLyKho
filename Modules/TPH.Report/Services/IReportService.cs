using DevExpress.XtraReports.UI;
using System.Data;
using TPH.Report.Models;

namespace TPH.Report.Services
{
    public interface IReportService
    {
        DataTable Data_DanhSachReport(int reportApp);
        DataTable Data_ChiTiet_Report(string reportId);
        int Insert_Report(string reportId, int reportApp = 0);
        int Update_ReportGoc(string reportId
            , byte[] reportGoc
            , string tenDataset, string tenDatatable
            , string userThucHien, string pcThucHien
            , string ReportSub1, string TenDataSetSub1, string TenDatatableSub1
            , string ReportSub2, string TenDataSetSub2, string TenDatatableSub2);
        int Update_Report_ApDung(string reportId, string userApDung);
        ReportModel Info_Report(string reportId);
        XtraReport GetReport_SuDung_TheoCauHinh(string reportId);
        XtraReport CreateReportFromStream(byte[] byteArray);
    }
}
