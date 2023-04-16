using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Report.Services.Impl;
using TPH.Report.Services;
using TPH.Report.Models;
using DevExpress.XtraReports.UI;
using System.Data;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using System.Drawing;
using System.Windows.Forms;

namespace TPH.LIS.App.AppCode
{
    public class GetReportConfigAndPrint
    {
        private static readonly IReportService _reportInfo = new ReportServiceImpl();
        private static List<ReportModel> lstResultReportInfo = new List<ReportModel>();
        public static ReportModel GetReportInList(string reportID)
        {
            if (CommonAppVarsAndFunctions.RefreshReport)
            {
                lstResultReportInfo = new List<ReportModel>();
            }
            var lst = lstResultReportInfo.Where(x => x.ReportId.Equals(reportID));
            if (lst.Any())
            {
                return lst.FirstOrDefault();
            }
            else
            {
                var rp = _reportInfo.Info_Report(reportID);
                if (!string.IsNullOrEmpty(rp.ReportId))
                {
                    lstResultReportInfo.Add(rp);
                    return rp;
                }
            }
            return null;
        }
        public static bool Print_Previewreport(string reportContants
           , Image reportLogo, ListBox listPrinter, bool isPrint
           , DataTable dataMain
           , DataTable dataSub_1 = null
           , DataTable dataSub_2 = null)
        {

            var resultReportInfo = new XtraReport();
            var reportUse = new ReportModel();
            reportUse = GetReportInList(reportContants);
            if (reportUse == null)
            {
                CustomMessageBox.MSG_Information_OK("Biểu mẫu in chưa được khai báo.");
                return false;
            }
            if (dataMain != null)
            {
                var f = new FrmPreViewReport();
                var printerName = string.Empty;
                var arrLogo = GraphicSupport.ImageToByteArray(reportLogo);
                if (!dataMain.Columns.Contains("ReportLogo"))
                {
                    dataMain.Columns.Add("ReportLogo", typeof(byte[]));
                }
                foreach (DataRow drCo in dataMain.Rows)
                {
                    drCo["ReportLogo"] = arrLogo;
                }

                if (listPrinter != null)
                {
                    if (listPrinter.Items.Count > 0 && string.IsNullOrEmpty(printerName))
                    {
                        if (listPrinter.SelectedIndex == -1)
                        {
                            listPrinter.SelectedIndex = 0;
                        }
                        printerName = listPrinter.SelectedItem.ToString();
                    }
                }
                resultReportInfo = _reportInfo.CreateReportFromStream(reportUse.ReportSuDung);
                return f.ShowReport(resultReportInfo, dataMain, isPrint, printerName, "XN", reportUse.TenDataset, reportUse.TenDatatable);
            }
            return false;
        }
    }
}
