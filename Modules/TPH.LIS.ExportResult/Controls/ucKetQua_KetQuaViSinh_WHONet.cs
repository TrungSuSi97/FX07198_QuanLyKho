using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.ExportResult.Service;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using Finisar.SQLite;
using TPH.LIS.Common.Controls;
using TPH.Excel;
using TPH.Language;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucKetQua_KetQuaViSinh_WHONet : UserControl
    {
        public ucKetQua_KetQuaViSinh_WHONet()
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

        private void ThongKe()
        {
            int limitDatagridDesign = 22;
            var dataResult = new DataTable();
            var condit = getCondit();
            //Xóa các cột cũ, giữ lại các cột đã tạo mặc định

            for (var i = limitDatagridDesign; i < gvbaocaovisinhWhonet.Columns.Count(); i++)
            {
                gvbaocaovisinhWhonet.Columns.RemoveAt(i);
                i--;
            }
            lblNgayBaoCao.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"), condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
            var data = _iexport.XuatKetQuaViSinh_KSD(getCondit());
            if (data.Rows.Count > 0)
            {
                dataResult = data.DefaultView.ToTable(true, new[]
                    {
                        //"QuocGia", "TenLab", "MaBN", "SEQ", "MaTiepNhan",
                        //"NgayTiepNhan", "TenBN", "KhoaPhongTA",
                        //"GioiTinh", "Tuoi", "LoaiMauNhan", "TGNhanMau",
                        //"MaPhanLoai", "TenPhanLoai","MaSoMau",
                        //"Esbl", "BetaLactamase","AmPC","Carbapenemase","Inducible_clindamycin","MRSA",
                        //"VRE","SEROTYPE"
                        "QuocGia", "TenLab", "MaBN", "SEQ", "MaTiepNhan",
                        "NgayTiepNhan", "TenBN", "KhoaPhongTA",
                        "GioiTinh", "Tuoi", "LoaiMauNhan", "TGNhanMau",
                        "MaPhanLoai", "TenPhanLoai","MaSoMau",
                        "ESBL", "BETA_LACT","AmPC","Carbapenemase","Inducible_clindamycin","MRSA_SCRN",
                        "VRE","SEROTYPE",
                        "DATE_BIRTH","KyThuat"
                    });
                //List Danh Sách kháng sinh đồ.
                var dataKSD = new DataTable();
                var tenCotkhangSinh = "WHON5_TEST";
                //if (chkViewAllKSD.Checked)3
                //{
                //    dataKSD = bacConfig.Data_dm_xetnghiem_khangsinh(string.Empty, string.Empty);
                //    tenCotkhangSinh = "TenKhangSinh";
                //}
                //else
                //{
                dataKSD = data.DefaultView.ToTable(true, new[] { "MaKhangSinh", "TenCotKhangSinh", "GuideLine", "KyThuat", "Potency"
                                                    , "WHON5_TEST", "WHON5_TEST_DRSLST1", "WHONETID" });
                data.Columns.Add("WHON5_TEST_ADD");
                //}
                //Thêm danh sách các cột kháng sinh cho lưới
                if (dataKSD.Rows.Count > 0)
                {
                    var ks_WHON5_TEST = string.Empty;
                    var kyTu_ToChuc = string.Empty;
                    var kyTu_DISK_MIC = string.Empty;
                    var kyTu_Potency = string.Empty;
                    var guideLine = string.Empty;
                    var kyThuat = string.Empty;
                    var potency = string.Empty;
                    var WHON5_TEST_DRSLST1 = string.Empty;

                    foreach (DataRow drKs in dataKSD.Rows)
                    {
                        //WHON5_TEST_DRSLST1 = drKs["WHON5_TEST_DRSLST1"].ToString();
                        //if (string.IsNullOrEmpty(WHON5_TEST_DRSLST1))
                        //    WHON5_TEST_DRSLST1 = drKs["WHONETID"].ToString();

                        var ksdName = string.Format("{0}_{1}", drKs["MaKhangSinh"].ToString(), kyTu_DISK_MIC);
                        guideLine = drKs["GuideLine"].ToString();
                        kyThuat = drKs["KyThuat"].ToString();
                        potency = drKs["Potency"].ToString();

                        kyTu_ToChuc = returnToChuc_WHON5_TEST(guideLine);
                        kyTu_DISK_MIC = returnKyThuat_WHON5_TEST(kyThuat);
                        kyTu_Potency = returnPotency_WHON5_TEST(potency);

                        //Ghép lại để lấy đúng mã WHON5_TEST
                        drKs[tenCotkhangSinh] = drKs[tenCotkhangSinh].ToString() + kyTu_ToChuc + kyTu_DISK_MIC;
                        if (kyThuat.Equals("DISK", StringComparison.OrdinalIgnoreCase))
                            drKs[tenCotkhangSinh] = drKs[tenCotkhangSinh].ToString() + kyTu_Potency;

                        ks_WHON5_TEST = drKs[tenCotkhangSinh].ToString();
                        //var myColumn = TPH.Common.Converter.StringConverter.ToString(gvbaocaovisinhWhonet.Columns[WHON5_TEST_DRSLST1]);
                        var myColumn = TPH.Common.Converter.StringConverter.ToString(gvbaocaovisinhWhonet.Columns[ks_WHON5_TEST]);
                        if (string.IsNullOrEmpty(myColumn))
                        {
                            //Add cột mới có tên là theo mã WHON5_TEST
                            gvbaocaovisinhWhonet.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                            {
                                Caption = ks_WHON5_TEST,
                                ColumnEdit = null,
                                VisibleIndex = gvbaocaovisinhWhonet.Columns.Count(),
                                Width = 100,
                                UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                                FieldName = drKs["MaKhangSinh"].ToString(),
                                OptionsColumn = { AllowEdit = false }
                            });
                            if (!dataResult.Columns.Contains(drKs["MaKhangSinh"].ToString()))
                                dataResult.Columns.Add(drKs["MaKhangSinh"].ToString());
                        }
                    }
                }
                string maTiepNhan = string.Empty;
                string maViKhuan = string.Empty;
                //Lặp lại để lấy giá trị
                foreach (DataRow dr in dataResult.Rows)
                {
                    maTiepNhan = dr["MaTiepNhan"].ToString();
                    maViKhuan = dr["MaPhanLoai"].ToString();

                    var dtaSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(data,
                        string.Format("MaTiepNhan = '{0}' and MaPhanLoai = '{1}'", maTiepNhan, maViKhuan));
                    if (dtaSearch.Rows.Count > 0)
                    {
                        string maKS = string.Empty;
                        string ketQua = string.Empty;
                        string SRI = string.Empty;
                        foreach (DataRow drKS in dtaSearch.Rows)
                        {
                            maKS = drKS["MaKhangSinh"].ToString();
                            //if (!string.IsNullOrEmpty(maKS))
                            //{
                            //    ketQua = drKS["KetQuaDinhLuong"].ToString();
                            //    RIS = drKS["KetQuaSRI"].ToString();
                            //    dr[maKS] = string.IsNullOrEmpty(ketQua.Trim()) ? RIS : ketQua;
                            //}
                            if (!string.IsNullOrEmpty(maKS))
                            {
                                ketQua = drKS["KetQuaDinhLuong"].ToString();
                                SRI = drKS["KetQuaSRI"].ToString();
                                //Phương pháp MIC, DISK: Lấy kết quả SRI (Cột SRI trên Form F6)
                                if (dr["KyThuat"].ToString().Equals("DISK", StringComparison.OrdinalIgnoreCase)
                                    || dr["KyThuat"].ToString().Equals("MIC", StringComparison.OrdinalIgnoreCase))
                                {
                                    dr[maKS] = SRI;
                                }
                                //Phương pháp ETEST: Lấy kết quả MIC (kết quả định lượng cột kết quả trên Form F6)
                                else
                                {
                                    dr[maKS] = ketQua;
                                }
                            }
                        }
                    }
                }
            }

            //Distinct datatable do sẽ có cái sifeInfection khác, sẽ ra 2 dòng
            gcbaocaovisinhWhonet.DataSource = distinctDT_KyThuat(dataResult);
        }

        private DataTable distinctDT_KyThuat(DataTable dataResult)
        {
            List<string> dataDistinct = new List<string>();
            foreach (DataColumn dc in dataResult.Columns)
            {
                //Bỏ cột Kythuat ra do lấy sẽ ra 2 dòng
                if (dc.ColumnName.ToString().Equals("KyThuat", StringComparison.OrdinalIgnoreCase)) continue;
                dataDistinct.Add(dc.ColumnName.ToString());
            }
            DataTable distinctValues = new DataTable();
            if (dataResult.Rows.Count > 0)
            {
                DataView view = new DataView(dataResult);
                distinctValues = view.ToTable(true, dataDistinct.ToArray());
            }
            return distinctValues;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export_VS(gcbaocaovisinhWhonet, string.Format("PTT_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), false, -1, -1, new string[]
             {lblTitle.Text, lblNgayBaoCao.Text}, new int[] { 16, 13 },
             new string[] { "SỞ Y TẾ THÀNH PHỐ HÀ NỘI", "BỆNH VIỆN ĐẠI HỌC Y HÀ NỘI", "Khoa: Vi sinh" });
        }

        private void btnExportSQLite_Click(object sender, EventArgs e)
        {
            //Xuất ra SQL lite
            Add();
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=WHONET.sqlite;Version=3;Compress=True;New=False");
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

        private bool CheckIfTableExists(string tableName)
        {
            SetConnection();
            sql_con.Open();

            sql_cmd = sql_con.CreateCommand();


            sql_cmd.CommandText = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tableName}';";
            object result = sql_cmd.ExecuteScalar();
            int resultCount = Convert.ToInt32(result);
            if (resultCount > 0)
            {
                sql_con.Close();
                return true;
            }
            sql_con.Close();

            return false;
        }

        private void Add()
        {

            if (CheckIfTableExists("Isolates"))
                DropDB();
            //Add sẽ khác thống kê
            int limitDatagridDesign = 22;
            var dataResult = new DataTable();
            //Xóa các cột cũ ở gridview
            for (var i = limitDatagridDesign; i < gvbaocaovisinhWhonet.Columns.Count(); i++)
            {
                gvbaocaovisinhWhonet.Columns.RemoveAt(i);
                i--;
            }
            var data = _iexport.XuatKetQuaViSinh_KSD(getCondit());
            if (data.Rows.Count > 0)
            {
                // Lấy ra các cột mặc định để lát tạo bảng
                dataResult = data.DefaultView.ToTable(true, new[]
                    {
                        "QuocGia","LABORATORY","TenLab", "MaBN", "SEQ", "MaTiepNhan",
                        "NgayTiepNhan", "TenBN", "KhoaPhongTA",
                        "GioiTinh", "Tuoi", "LoaiMauNhan", "TGNhanMau",
                        "MaPhanLoai", "TenPhanLoai","MaSoMau","DiaChi","MaKhoaPhong","TenKhoaPhong",
                        "ESBL", "BETA_LACT","AmPC","Carbapenemase","Inducible_clindamycin","MRSA_SCRN",
                        "VRE","SEROTYPE","DATE_BIRTH","DATE_ADMIS","ORGANISM","SPEC_NUM"
                        ,"X_LIS","SPEC_DATE","KyThuat","GRAM"
                    });
                //List Danh Sách kháng sinh đồ.
                var dataKSD = new DataTable();
                var tenCotkhangSinh = "WHON5_TEST";
                //if (chkViewAllKSD.Checked)
                //{
                //    dataKSD = bacConfig.Data_dm_xetnghiem_khangsinh(string.Empty, string.Empty);
                //    tenCotkhangSinh = "TenKhangSinh";
                //}
                //else
                //{

                //Lấy các data để lát tính theo mã WHON5_TEST
                dataKSD = data.DefaultView.ToTable(true, new[] { "MaKhangSinh", "TenCotKhangSinh", "GuideLine", "KyThuat"
                                        , "Potency", "WHON5_TEST", "WHON5_TEST_DRSLST1", "WHONETID"});
                data.Columns.Add("WHON5_TEST_ADD");

                //}
                //Thêm danh sách các cột kháng sinh cho lưới
                if (dataKSD.Rows.Count > 0)
                {
                    var ks_WHON5_TEST = string.Empty;
                    var kyTu_ToChuc = string.Empty;
                    var kyTu_DISK_MIC = string.Empty;
                    var kyTu_Potency = string.Empty;
                    var guideLine = string.Empty;
                    var kyThuat = string.Empty;
                    var potency = string.Empty;
                    var WHON5_TEST_DRSLST1 = string.Empty;

                    foreach (DataRow drKs in dataKSD.Rows)
                    {
                        //WHON5_TEST_DRSLST1 = drKs["WHON5_TEST_DRSLST1"].ToString();
                        //if (string.IsNullOrEmpty(WHON5_TEST_DRSLST1))
                        //    WHON5_TEST_DRSLST1 = drKs["WHONETID"].ToString();

                        var ksdName = string.Format("{0}_{1}", drKs["MaKhangSinh"].ToString(), kyTu_DISK_MIC);
                        guideLine = drKs["GuideLine"].ToString();
                        kyThuat = drKs["KyThuat"].ToString();
                        potency = drKs["Potency"].ToString();

                        kyTu_ToChuc = returnToChuc_WHON5_TEST(guideLine);
                        kyTu_DISK_MIC = returnKyThuat_WHON5_TEST(kyThuat);
                        kyTu_Potency = returnPotency_WHON5_TEST(potency);

                        //Ghép lại để lấy đúng mã WHON5_TEST
                        drKs[tenCotkhangSinh] = drKs[tenCotkhangSinh].ToString() + kyTu_ToChuc + kyTu_DISK_MIC;
                        if (kyThuat.Equals("DISK", StringComparison.OrdinalIgnoreCase))
                            drKs[tenCotkhangSinh] = drKs[tenCotkhangSinh].ToString() + kyTu_Potency;

                        ks_WHON5_TEST = drKs[tenCotkhangSinh].ToString();
                        //var myColumn = TPH.Common.Converter.StringConverter.ToString(gvbaocaovisinhWhonet.Columns[WHON5_TEST_DRSLST1]);
                        var myColumn = TPH.Common.Converter.StringConverter.ToString(gvbaocaovisinhWhonet.Columns[ks_WHON5_TEST]);
                        if (string.IsNullOrEmpty(myColumn))
                        {
                            gvbaocaovisinhWhonet.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                            {
                                Caption = ks_WHON5_TEST,
                                ColumnEdit = null,
                                VisibleIndex = gvbaocaovisinhWhonet.Columns.Count(),
                                Width = 100,
                                UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                                FieldName = drKs["MaKhangSinh"].ToString(),
                                OptionsColumn = { AllowEdit = false }
                            });
                            //if (!dataResult.Columns.Contains(drKs["MaKhangSinh"].ToString()))
                            //    dataResult.Columns.Add(drKs["MaKhangSinh"].ToString());
                            if (!dataResult.Columns.Contains(ks_WHON5_TEST))
                                dataResult.Columns.Add(ks_WHON5_TEST);
                        }
                        //Lặp lại cái data để add kháng sinh theo mã WHON5_TEST vào, phân biệt theo WHONETID, ví dụ WHONETID là AMC_M
                        foreach (DataRow dr in data.Rows)
                        {
                            if (dr["WHONETID"].ToString().Equals(drKs["WHONETID"].ToString(), StringComparison.OrdinalIgnoreCase))
                                dr["WHON5_TEST_ADD"] = drKs["WHON5_TEST"].ToString();
                        }
                    }
                }
                string maTiepNhan = string.Empty;
                string maViKhuan = string.Empty;
                foreach (DataRow dr in dataResult.Rows)
                {
                    maTiepNhan = dr["MaTiepNhan"].ToString();
                    maViKhuan = dr["MaPhanLoai"].ToString();

                    var dtaSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(data,
                        string.Format("MaTiepNhan = '{0}' and MaPhanLoai = '{1}'", maTiepNhan, maViKhuan));
                    if (dtaSearch.Rows.Count > 0)
                    {
                        string maKS = string.Empty;
                        string ketQua = string.Empty;
                        string SRI = string.Empty;
                        foreach (DataRow drKS in dtaSearch.Rows)
                        {
                            //Nếu giống cái mã ks theo WHON5_TEST thì gán value vào
                            //Chỗ lấy này về sau có thể sai nếu có 2 con kháng sinh khác siteinfection, các thứ còn lại giống
                            maKS = drKS["WHON5_TEST_ADD"].ToString();
                            if (!string.IsNullOrEmpty(maKS))
                            {
                                ketQua = drKS["KetQuaDinhLuong"].ToString();
                                SRI = drKS["KetQuaSRI"].ToString();
                                //Phương pháp MIC, DISK: Lấy kết quả SRI (Cột SRI trên Form F6)
                                if (dr["KyThuat"].ToString().Equals("DISK", StringComparison.OrdinalIgnoreCase)
                                    || dr["KyThuat"].ToString().Equals("MIC", StringComparison.OrdinalIgnoreCase))
                                {
                                    dr[maKS] = SRI;
                                }
                                //Phương pháp ETEST: Lấy kết quả MIC (kết quả định lượng cột kết quả trên Form F6)
                                else
                                {
                                    dr[maKS] = ketQua;
                                }
                            }
                        }
                    }
                }
            }

            dataResult = distinctDT_KyThuat(dataResult);
            if (dataResult.Rows.Count > 0)
            {
                CreateDB("Isolates", dataResult);
                Insert_SQLite(dataResult);
                CustomMessageBox.MSG_Information_OK("Đã xuất dữ liệu thành công!");
            }
        }

        private void CreateDB(string DB_Name, DataTable data)
        {
            //số index để thêm các cột chưa có
            int limitDatagridDesign = 19;
            var sb = new StringBuilder();
            sb.AppendFormat("CREATE TABLE \"{0}\" (", DB_Name);
            sb.Append("\"ROW_IDX\" INTEGER NOT NULL UNIQUE,");
            sb.Append("\"COUNTRY_A\"    TEXT,\"LABORATORY\"	TEXT,\"ORIGIN\"	TEXT,\"PATIENT_ID\"	TEXT,");
            sb.Append("\"LAST_NAME\"	TEXT,\"FULL_NAME\"	TEXT,");
            sb.Append("\"FIRST_NAME\"    TEXT, \"SEX\"   TEXT, \"AGE\"   TEXT, \"WARD\"  TEXT,");
            sb.Append("\"INSTITUT\"    TEXT, \"DEPARTMENT\"   TEXT, \"WARD_TYPE\"    TEXT, \"SPEC_TYPE\"  TEXT,\"SPEC_CODE\" TEXT,");
            sb.Append("\"SPEC_REAS\"    TEXT, \"ISOL_NUM\"   TEXT, \"ORG_TYPE\"   TEXT,");
            sb.Append("\"CARBAPENEM\"   TEXT, \"INDUC_CLI\"    TEXT, \"COMMENT\"   TEXT, \"DATE_DATA\"  DATE,");
            for (int i = limitDatagridDesign; i < data.Columns.Count; i++)
            {
                if (data.Columns[i].ToString().Equals("DATE_BIRTH", StringComparison.OrdinalIgnoreCase)
                    || data.Columns[i].ToString().Equals("DATE_ADMIS", StringComparison.OrdinalIgnoreCase)
                    || data.Columns[i].ToString().Equals("SPEC_DATE", StringComparison.OrdinalIgnoreCase))
                    sb.AppendFormat("\"{0}\" DATE ,", data.Columns[i].ToString());
                else
                    sb.AppendFormat("\"{0}\" TEXT ,", data.Columns[i].ToString());
            }
            sb.Append(" PRIMARY KEY(\"ROW_IDX\" AUTOINCREMENT));");
            ExecuteQuery(sb.ToString());
        }

        private void DropDB()
        {
            var sb = new StringBuilder();
            sb.Append("DROP TABLE Isolates");
            ExecuteQuery(sb.ToString());
        }

        private void Insert_SQLite(DataTable dataResult)
        {
            //Insert giá trị vào
            int limit = 31;
            foreach (DataRow dr in dataResult.Rows)
            {
                var sinhNhat = dr["DATE_BIRTH"].ToString();
                var ngayTiepNhan = dr["NgayTiepNhan"].ToString();
                var thoiGianLayMau = dr["SPEC_DATE"].ToString();
                if (!string.IsNullOrEmpty(sinhNhat))
                {
                    DateTime dt = Convert.ToDateTime(sinhNhat);
                    sinhNhat = dt.ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrEmpty(ngayTiepNhan))
                {
                    DateTime dt = Convert.ToDateTime(ngayTiepNhan);
                    ngayTiepNhan = dt.ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrEmpty(thoiGianLayMau))
                {
                    DateTime dt = Convert.ToDateTime(thoiGianLayMau);
                    thoiGianLayMau = dt.ToString("yyyy-MM-dd");
                }
                var sb = new StringBuilder();
                sb.Append("insert into  Isolates (COUNTRY_A,LABORATORY,PATIENT_ID,FULL_NAME,SEX" +
                          ",DATE_BIRTH,AGE,WARD,DATE_ADMIS,ORGANISM,ESBL" +
                          ",MRSA_SCRN,SPEC_NUM,INSTITUT,SPEC_TYPE,SPEC_DATE,FIRST_NAME,DEPARTMENT,ORG_TYPE");
                for (int i = limit; i < dataResult.Columns.Count; i++)
                {
                    sb.AppendFormat(",{0}", dataResult.Columns[i].ToString());
                }
                sb.Append(") values ");
                sb.AppendFormat("('{0}'", dr["QuocGia"]);
                sb.AppendFormat(",'{0}'", dr["LABORATORY"]);
                sb.AppendFormat(",'{0}'", dr["MaBN"]);
                sb.AppendFormat(",'{0}'", dr["TenBN"]);
                sb.AppendFormat(",'{0}'", dr["GioiTinh"]);
                sb.AppendFormat(",'{0}'", sinhNhat);
                sb.AppendFormat(",'{0}'", dr["Tuoi"]);
                sb.AppendFormat(",'{0}'", dr["KhoaPhongTA"]);
                sb.AppendFormat(",'{0}'", ngayTiepNhan);
                sb.AppendFormat(",'{0}'", dr["MaPhanLoai"]);
                sb.AppendFormat(",'{0}'", dr["ESBL"]);
                sb.AppendFormat(",'{0}'", dr["MRSA_SCRN"]);
                sb.AppendFormat(",'{0}'", dr["SPEC_NUM"]);
                sb.AppendFormat(",'{0}'", dr["LABORATORY"]);
                sb.AppendFormat(",'{0}'", dr["LoaiMauNhan"]);
                sb.AppendFormat(",'{0}'", thoiGianLayMau);
                sb.AppendFormat(",'{0}'", dr["TenBN"]);
                sb.AppendFormat(",'{0}'", dr["KhoaPhongTA"]);
                sb.AppendFormat(",'{0}'", dr["GRAM"]);

                for (int i = limit; i < dr.ItemArray.Length; i++)
                {
                    sb.AppendFormat(",'{0}'", dr.ItemArray[i].ToString());
                }
                sb.Append(")");

                ExecuteQuery(sb.ToString());
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
            List<string> batThuong
                    = new List<string>() { "20/10ug", "1.25/23.75ug", "200-300ug", "75/10-15ug", "2.5ug", "1.25ug" };
            if (batThuong.Contains(data))
            {
                switch (data.Trim())
                {
                    case "20/10ug":
                        return "20";
                    case "1.25/23.75ug":
                        return "1_2";
                    case "200-300ug":
                        return "200";
                    case "75/10-15ug":
                        return "75";
                    case "2.5ug":
                        return "2_5";
                    case "1.25ug":
                        return "1_5";
                    default:
                        return "";
                }
            }
            else
            {
                data = data.ToUpper().Replace("UNIT", "").Replace("UNITS", "").Replace("UG", "").Trim();
                string[] result = data.Split('-', '/');
                return result[0];
            }

        }

        private void ucKetQua_KetQuaViSinh_WHONet_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
