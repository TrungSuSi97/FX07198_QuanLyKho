using System.ComponentModel;
using System.Data;

namespace TPH.LIS.BarcodePrinting
{

    public class PrintingSystemProtocolList
    {
        [Description("Tiêu chuẩn")]
        public static string TIEUCHUAN = "TIEUCHUAN";
        [Description("Tiêu chuẩn 2 tem")]
        public static string TIEUCHUAN2 = "TIEUCHUAN2";
        [Description("Tiêu chuẩn_VS")]
        public static string TIEUCHUANVS = "TIEUCHUANVS";
        [Description("Bartender")]
        public static string BARTENDER = "BARTENDER";
        [Description("HEN")]
        public static string HEN = "HEN";
        [Description("BCRobo Minh Tâm")]
        public static string BCRoboMT = "BCRoboMT";
        [Description("OLPASO")]
        public static string OLPASO = "OLPASO";

        public static DataTable Load_DanhSach_Protocol()
        {
            var data = new DataTable();
            data.Columns.Add("Protocol", typeof(string));
            data.Columns.Add("Description", typeof(string));
            var dataR = data.NewRow();
            dataR["Protocol"] = TIEUCHUAN;
            dataR["Description"] = "Barcode tiêu chuẩn";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = TIEUCHUAN2;
            dataR["Description"] = "Barcode tiêu chuẩn 2";
            data.Rows.Add(dataR);

            dataR = data.NewRow();
            dataR["Protocol"] = BARTENDER;
            dataR["Description"] = "Barcode bartender";
            data.Rows.Add(dataR);
            dataR = data.NewRow();
            dataR["Protocol"] = BCRoboMT;
            dataR["Description"] = "BCRobo Minh Tâm";
            data.Rows.Add(dataR);
            dataR = data.NewRow();
            dataR["Protocol"] = HEN;
            dataR["Description"] = "HEN";
            data.Rows.Add(dataR);
            dataR = data.NewRow();
            dataR["Protocol"] = OLPASO;
            dataR["Description"] = "OLPASO";
            data.Rows.Add(dataR);
            data.AcceptChanges();
            return data;

        }
    }

}
