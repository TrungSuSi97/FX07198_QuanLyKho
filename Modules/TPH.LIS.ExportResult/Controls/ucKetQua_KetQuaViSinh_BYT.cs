using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Finisar.SQLite;
using TPH.Language;
using TPH.LIS.ExportResult.Service;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucKetQua_KetQuaViSinh_BYT : UserControl
    {
        public ucKetQua_KetQuaViSinh_BYT()
        {
            InitializeComponent();
        }
        private readonly IBacteriumAntibioticService bacConfig = new BacteriumAntibioticService();
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;
        string colKSD = "colKSD_";

        //SQLite
        private DataGrid Grid;
        private TextBox txtDesc;
        private Button btnDel;
        private Button btnAdd;
        private Button btnNew;
        private Label lblDesc;
        private Button btnEdit;

        private int i = 0;


        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private Container components_sql = null;
        //SQLite
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe();
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            Excel.ExportToExcel.Export(gckhangsinh_byt);
        }

        private void btnExportSQLite_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Export_SQLite()
        {
            var data = _iexport.XuatKetQuaViSinh_KSD(getCondit());

        }

        private void ThongKe()
        {
            var data = _iexport.XuatKetQuaViSinh_KSD(getCondit());
            //ControlExtension.BindDataToGrid(data, ref dtgList, ref bvList, false);
            gckhangsinh_byt.DataSource = data;
        }
        private void Add()
        {
            var data = _iexport.XuatKetQuaViSinh_KSD(getCondit());
            //format lại định dạng date dd/mm/yyyy
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    var kyTu_ToChuc = returnToChuc_WHON5_TEST(dr["GuideLine"].ToString());
                    var kyTu_DISK_MIC = returnKyThuat_WHON5_TEST(dr["KyThuat"].ToString());
                    var kyTu_Potency = returnPotency_WHON5_TEST(dr["Potency"].ToString());

                    var sinhNhat = dr["SinhNhat"].ToString();
                    var ngayTiepNhan = dr["NgayTiepNhan"].ToString();
                    var thoiGianLayMau = dr["TGLayMau"].ToString();
                    var specDateHour = dr["SPEC_TIME_HOUR"].ToString();
                    var loaiKetQua = dr["LoaiKetQua"].ToString();
                    if (int.Parse(loaiKetQua) == 0)
                    {
                        dr["CULTURE_RESULTS"] = "DƯƠNG TÍNH";
                    }
                    else
                    {
                        dr["CULTURE_RESULTS"] = "ÂM TÍNH";
                    }
                    if (!string.IsNullOrEmpty(specDateHour))
                    {
                        if (Int32.Parse(specDateHour) <= 48)
                        {
                            dr["SPEC_TIME"] = "<=48";
                            dr["RISK_DF"] = "Cộng Đồng";
                        }
                        else
                        {
                            dr["SPEC_TIME"] = ">=48";
                            dr["RISK_DF"] = "Bệnh Viện";
                        }
                    }

                    if (!string.IsNullOrEmpty(sinhNhat))
                    {
                        DateTime dt = Convert.ToDateTime(sinhNhat);
                        sinhNhat = dt.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(ngayTiepNhan))
                    {
                        DateTime dt = Convert.ToDateTime(ngayTiepNhan);
                        ngayTiepNhan = dt.ToString("dd/MM/yyyy");
                    }
                    if (!string.IsNullOrEmpty(thoiGianLayMau))
                    {
                        DateTime dt = Convert.ToDateTime(thoiGianLayMau);
                        thoiGianLayMau = dt.ToString("dd/MM/yyyy");
                    }
                    insertSQLite(dr, sinhNhat, ngayTiepNhan, thoiGianLayMau);

                }
                CustomMessageBox.MSG_Information_OK("Đã xuất dữ liệu thành công!");
            }
        }

        private string returnToChuc_WHON5_TEST(string data)
        {
            data = data.Substring(0, data.Length - 2).ToUpper();
            switch (data)
            {
                case "CLSI":
                    return "N";
                case "EUCST":
                    return "E";
                case "SFM":
                    return "F";
                case "SRGA":
                    return "S";
                case "BSAC":
                    return "B";
                case "DIN":
                    return "D";
                case "NEODK":
                    return "T";
                case "AFA":
                    return "A";
                default:
                    return "";
            }
        }

        private string returnKyThuat_WHON5_TEST(string data)
        {
            if (data.Equals("DISK", StringComparison.OrdinalIgnoreCase))
                return "D";
            if (data.Equals("MIC", StringComparison.OrdinalIgnoreCase))
                return "M";
            return "";
        }

        private string returnPotency_WHON5_TEST(string data)
        {


            return null;
        }

        private void insertSQLite(DataRow dr, string sinhNhat, string ngayTiepNhan, string thoiGianLayMau)
        {
            var sb = new StringBuilder();
            sb.Append("insert into  bao_cao_khang_sinh_byt (COUNTRY_A,LABORATORY,PATIENT_ID,FULL_NAME,SEX,ADDRESS" +
                      ",DATE_BIRTH,AGE,WARD_ID" +
                      ",WARD,DATE_ADMIS,SPEC_DATE,ORG_CODE,ORGANISM,DIAGNOSTIC,RESULT,SIR" +
                      ",LOCA_ANTID,ANT_CODE,ANTIBIOTIC,WHON5_TEST,ESBL" +
                      ",SEROTYPE,MRSA,BETA_LACT,SPEC_NUM,SPEC_TIME,RISK_DF,INSTITUT,TEST,LOCAL_TEST" +
                      ",LOCAL_SPECID,SPEC_TYPE,LOCAL_SPECN,CULTURE_RESULTS,VRE) values ");
            sb.AppendFormat("('{0}'", dr["COUNTRY_A"]);
            sb.AppendFormat(",'{0}'", dr["LABORATORY"]);
            sb.AppendFormat(",'{0}'", dr["MaBN"]);
            sb.AppendFormat(",'{0}'", dr["TenBN"]);
            sb.AppendFormat(",'{0}'", dr["GioiTinh"]);
            sb.AppendFormat(",'{0}'", dr["DiaChi"]);
            sb.AppendFormat(",'{0}'", sinhNhat);
            sb.AppendFormat(",'{0}'", dr["Tuoi"]);
            sb.AppendFormat(",'{0}'", dr["MaKhoaPhong"]);
            sb.AppendFormat(",'{0}'", dr["TenKhoaPhong"]);
            sb.AppendFormat(",'{0}'", ngayTiepNhan);
            sb.AppendFormat(",'{0}'", thoiGianLayMau);
            sb.AppendFormat(",'{0}'", dr["MaPhanLoai"]);
            sb.AppendFormat(",'{0}'", dr["TenPhanLoai"]);
            sb.AppendFormat(",'{0}'", dr["ChanDoan"]);
            sb.AppendFormat(",'{0}'", dr["KetQuaDinhLuong"]);
            sb.AppendFormat(",'{0}'", dr["KetQuaSRI"]);
            sb.AppendFormat(",'{0}'", dr["MaKhangSinhGoc"]);
            sb.AppendFormat(",'{0}'", dr["MaKhangSinhGoc"]);
            sb.AppendFormat(",'{0}'", dr["TenKhangSinh"]);
            sb.AppendFormat(",'{0}'", dr["WHON5_TEST"]);
            sb.AppendFormat(",'{0}'", dr["ESBL"]);
            sb.AppendFormat(",'{0}'", dr["SEROTYPE"]);
            sb.AppendFormat(",'{0}'", dr["MRSA_SCRN"]);
            sb.AppendFormat(",'{0}'", dr["BETA_LACT"]);
            sb.AppendFormat(",'{0}'", dr["Seq"]);
            sb.AppendFormat(",'{0}'", dr["SPEC_TIME"]);
            sb.AppendFormat(",'{0}'", dr["RISK_DF"]);
            sb.AppendFormat(",'{0}'", dr["LABORATORY"]);
            sb.AppendFormat(",'{0}'", dr["KyThuat"]);
            sb.AppendFormat(",'{0}'", dr["KyThuat"]);
            sb.AppendFormat(",'{0}'", dr["MaLoaiMau"]);
            sb.AppendFormat(",'{0}'", dr["LoaiMauNhan"]);
            sb.AppendFormat(",'{0}'", dr["TenLoaiMau"]);
            sb.AppendFormat(",'{0}'", dr["CULTURE_RESULTS"]);
            sb.AppendFormat(",'{0}')", dr["VRE"]);

            ExecuteQuery(sb.ToString());
        }

        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;

            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=WHONET.sqlite;Version=3;Compress=True;New=False");
        }

        private void ucKetQua_KetQuaViSinh_BYT_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
