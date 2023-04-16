using System.ComponentModel;
using System.Data;

namespace TPH.AnalyzerChart.Constants
{
    public class GiaoThucVeHinh
    {
        [Description("ABX")]
        public const string ABX = "ABX";
        [Description("ABOTT")]
        public const string ABOTT = "ABOTT";
        [Description("CELLDIFF")]
        public const string CELLDIFF = "CELLDIFF";
        [Description("NCC51")]
        public const string NCC51 = "NCC51";
        [Description("ELITE580")]
        public const string ELITE580 = "ELITE580";
        [Description("MatrixGelsystem")]
        public const string MatrixGelsystem = "MatrixGelsystem";
        public static DataTable Load_DanhSach_Protocol()
        {
            var data = new DataTable();
            data.Columns.Add("Protocol", typeof(string));
            data.Columns.Add("Description", typeof(string));
            var dataR = data.NewRow();
            dataR["Protocol"] = string.Empty;
            dataR["Description"] = "---None---";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = ABX;
            dataR["Description"] = "ABX";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = ABOTT;
            dataR["Description"] = "ABOTT";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = CELLDIFF;
            dataR["Description"] = "CELLDIFF";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = NCC51;
            dataR["Description"] = "NCC51";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = ELITE580;
            dataR["Description"] = "ELITE580";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = MatrixGelsystem;
            dataR["Description"] = "MatrixGelsystem";
            data.Rows.Add(dataR);
            data.AcceptChanges();
            return data;
        }
    }
    public enum enumLoaiXnVeHinh
    {
        None = 0,
        WBC = 1,
        RBC = 2,
        PLT = 3,
        S10Catter = 4,
        S90Catter = 5
    }
    public class AnalyzerChartConstants
    {
        public const string WBC_Histogram = "WBC";
        public const string RBC_Histogram = "RBC";
        public const string PLT_Histogram = "PLT";
        public const string S10_DDIFFCattergram = "S10";
        public const string S90_DDIFFCattergram = "S90";
    }
}
