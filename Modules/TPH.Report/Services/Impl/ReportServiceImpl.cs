using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using TPH.LIS.Data;
using TPH.Report.Models;

namespace TPH.Report.Services.Impl
{
    public class ReportServiceImpl: IReportService
    {
        public DataTable Data_DanhSachReport(int reportApp)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDM_Report_DSReportID", new SqlParameter[] {
            new SqlParameter("@ReportApp",reportApp) });
            if (data != null)
                return data.Tables[0];
            return null;
        }
        public DataTable Data_ChiTiet_Report(string reportId)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDM_Report_ChiTiet", new SqlParameter[] {new SqlParameter("@ReportId", reportId) });
            if (data != null)
                return data.Tables[0];
            return null;
        }
        public int Insert_Report(string reportId, int reportApp = 0)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insDM_Report"
                , new SqlParameter[] { new SqlParameter("@ReportId", reportId), new SqlParameter("@AppId", reportApp)  });
        }
        public int Update_ReportGoc(string reportId
            , byte[] reportGoc
            , string tenDataset, string tenDatatable
            , string userThucHien, string pcThucHien
            , string ReportSub1, string TenDataSetSub1, string TenDatatableSub1
            , string ReportSub2, string TenDataSetSub2, string TenDatatableSub2)
        {
            return (int)DataProvider.ExecuteNonQuery(
                CommandType.StoredProcedure, "updDM_Report_MauMoi"
                , new SqlParameter[] 
                {
                  new SqlParameter("@ReportId", reportId)
                , new SqlParameter("@ReportGoc",reportGoc)
                , new SqlParameter("@TenDataSet", tenDataset)
                , new SqlParameter("@TenDatatable", tenDatatable)
                , new SqlParameter("@NguoiSua", userThucHien)
                , new SqlParameter("@PCSua", pcThucHien)
                , new SqlParameter("@ReportSub1", string.IsNullOrEmpty(ReportSub1)?(object)DBNull.Value: ReportSub1)
                , new SqlParameter("@TenDataSetSub1", string.IsNullOrEmpty(TenDataSetSub1)?(object)DBNull.Value: TenDataSetSub1)
                , new SqlParameter("@TenDatatableSub1", string.IsNullOrEmpty(TenDatatableSub1)?(object)DBNull.Value: TenDatatableSub1)
                , new SqlParameter("@ReportSub2", string.IsNullOrEmpty(ReportSub2)?(object)DBNull.Value: ReportSub2)
                , new SqlParameter("@TenDataSetSub2", string.IsNullOrEmpty(TenDataSetSub2)?(object)DBNull.Value: TenDataSetSub2)
                , new SqlParameter("@TenDatatableSub2", string.IsNullOrEmpty(TenDatatableSub2)?(object)DBNull.Value: TenDatatableSub2)
                }
                );
        }
        public int Update_Report_ApDung(string reportId, string userApDung)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updDM_Report_ApDung"
                , new SqlParameter[] {
                    new SqlParameter("@ReportId", reportId)
                    , new SqlParameter("@NguoiApDung", userApDung)
                });
        }
        public ReportModel Info_Report(string reportId)
        {
            var info = new ReportModel();
            var data = Data_ChiTiet_Report(reportId);
            if(data !=null)
            {
                if (data.Rows.Count > 0)
                {
                    var dr = data.Rows[0];
                    info.ReportId = reportId;
                    info.ReportGoc = (byte[])(dr["ReportGoc"] == DBNull.Value ? null : dr["ReportGoc"]);
                    info.ReportSuDung = (byte[])(dr["ReportSuDung"] == DBNull.Value ? null : dr["ReportSuDung"]);
                    info.NguoiSua = dr["NguoiSua"].ToString();
                    info.NguoiApDung = dr["NguoiApDung"].ToString();
                    info.PCSua = dr["PCSua"].ToString();
                    info.NgaySua = (string.IsNullOrEmpty(dr["NgaySua"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["NgaySua"].ToString()));
                    info.NgayApDung = (string.IsNullOrEmpty(dr["NgayApDung"].ToString()) ? (DateTime?)null : DateTime.Parse(dr["NgayApDung"].ToString()));
                    info.KichHoat = bool.Parse(dr["KichHoat"].ToString());
                    info.TenDataset = dr["TenDataset"].ToString();
                    info.TenDatatable = dr["TenDatatable"].ToString();
                    info.ReportSub1 = dr["ReportSub1"].ToString();
                    info.TenDataSetSub1 = dr["TenDataSetSub1"].ToString();
                    info.TenDatatableSub1 = dr["TenDatatableSub1"].ToString();
                    info.ReportSub2 = dr["ReportSub2"].ToString();
                    info.TenDataSetSub2 = dr["TenDataSetSub2"].ToString();
                    info.TenDatatableSub2 = dr["TenDatatableSub2"].ToString();
                }
            }
            return info;
        }
        public XtraReport GetReport_SuDung_TheoCauHinh(string reportId)
        {
            var info = Info_Report(reportId);
            if(!string.IsNullOrEmpty(info.ReportId) && info.ReportSuDung != null)
            {
                return CreateReportFromStream(info.ReportSuDung);
            }
            return null;
        }
        public XtraReport CreateReportFromStream(byte[] byteArray)
        {
            if (byteArray != null)
            {
                MemoryStream stream = new MemoryStream(byteArray);
                var report = XtraReport.FromStream(stream, true);
                return report;
            }
            else
                return null;
        }
        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }
}
