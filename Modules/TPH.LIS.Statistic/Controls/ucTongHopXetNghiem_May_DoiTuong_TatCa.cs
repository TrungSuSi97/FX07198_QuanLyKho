using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using TPH.LIS.Configuration.Services.SystemConfig;
using DevExpress.XtraGrid.Views.BandedGrid;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Controls;
using TPH.Excel;
using TPH.Language;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopXetNghiem_May_DoiTuong_TatCa : UserControl
    {
        public ucTongHopXetNghiem_May_DoiTuong_TatCa()
        {
            InitializeComponent();
        }

        private readonly IStatisticService _iStatistic = new StatisticService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();

        public delegate NormalStatisticCondit GetCondit();

        public event GetCondit getCondit;

        public bool ShowMoney
        {
            get { return colTongTien.Visible; }
            set { colTongTien.Visible = value; }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lblMayXetNghiem.Text = "Máy xét nghiệm:";
            lblKhoa.Text = "Khoa:";
            gcXetNghiem.DataSource = null;
            var c = 4;
            while (bgvXetNghiem.Columns.Count > c)
            {
                bgvXetNghiem.Columns.RemoveAt(c);
            }

            var d = 2;

            while (bgvXetNghiem.Bands.Count > d)
            {
                bgvXetNghiem.Bands.RemoveAt(d);
            }

            CustomMessageBox.ShowAlert("Đọc dữ liệu từ server......");
            var condit = getCondit();
            condit.SumColumns = new List<string> {"SoLuong", "SoLuongHeSo", "TongTien", "TienCong"};
            //set may ve null vì form này load tất cả máy
            condit.MayXetNghiem = null;

            var data = _iStatistic.ThongXetNghiemThucHien_DoiTuong(condit);
            lblNgayBaoCao.Text =
                string.Format(
                    LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"),
                    condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
            if (data != null)
            {
                var dataResult = data.DefaultView.ToTable(true, "MaXN", "TenXN", "ThuTuIn", "SapXep");
                dataResult.DefaultView.Sort = "ThuTuIn asc, SapXep asc";
                dataResult = dataResult.DefaultView.ToTable();

                var danhsachMay = data.DefaultView.ToTable(true, "TenMay");
                string dsMay = string.Empty;
                foreach (DataRow drTM in danhsachMay.Rows)
                {
                    if (!string.IsNullOrEmpty(drTM["TenMay"].ToString()))
                    {
                        dsMay += (string.IsNullOrEmpty(dsMay) ? "" : " | ");
                        dsMay += drTM["TenMay"].ToString();
                    }
                }

                lblMayXetNghiem.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Máy xét nghiệm: {0}",
                    LanguageExtension.AppLanguage), dsMay);

                var danhsachKhoaXN = data.DefaultView.ToTable(true, "MaBoPhan");
                string dsKhoaXN = string.Empty;
                foreach (DataRow drBp in danhsachKhoaXN.Rows)
                {
                    if (!string.IsNullOrEmpty(drBp["MaBoPhan"].ToString()))
                    {
                        dsKhoaXN += (string.IsNullOrEmpty(dsKhoaXN) ? "" : ", ");
                        dsKhoaXN += drBp["MaBoPhan"].ToString();
                    }
                }

                lblKhoa.Text = string.Format("Khoa: {0}", dsKhoaXN);
                var dataDistincDoiTuong = _isSysConfig.Get_DoiTuongDichVu(string.Empty);
                var colTong = colSoLuong.FieldName;
                var colHeSo = colSoLuongHeSo.FieldName;
                dataResult.Columns.Add(colTong, typeof(double));
                dataResult.Columns.Add(colHeSo, typeof(double));
                var ms = "Đang xử lý số liệu.....\r\nĐối tượng: {0}";
                foreach (DataRow item in dataDistincDoiTuong.Rows)
                {
                    var maDoiTuong = item["MaDoiTuongDichVu"].ToString();
                    var colSlName = string.Format("{0}_SL", maDoiTuong);
                    var colHSName = string.Format("{0}_HS", maDoiTuong);
                    var colName = item["TenDoiTuongDichVu"].ToString();
                   
                    CustomMessageBox.ShowAlert(string.Format(LanguageExtension.GetResourceValueFromValue(ms,
                        LanguageExtension.AppLanguage), colName));
                    //add cột vào  dataresutl và lưới
                    dataResult.Columns.Add(colSlName, typeof(double));
                    dataResult.Columns.Add(colHSName, typeof(double));
                    //Add cột vào bandedgridview
                    //1. tạo 1 gridband mới
                    GridBand bandUngroupped = new GridBand {Caption = colName};

                    bgvXetNghiem.Bands.Add(bandUngroupped);
                    var count = LanguageExtension.GetResourceValueFromValue("Số lượng",
                        LanguageExtension.AppLanguage);
                    var testNum = LanguageExtension.GetResourceValueFromValue("Số test",
                        LanguageExtension.AppLanguage);
                    InsertNewColToGrid(bgvXetNghiem, colSlName, count, colSoLuong.Width, null, null,
                        FormatType.Numeric, "{0:N0}", true);
                    bgvXetNghiem.Columns[bgvXetNghiem.Columns.Count - 1].OwnerBand = bandUngroupped;
                    InsertNewColToGrid(bgvXetNghiem, colHSName, testNum, colSoLuongHeSo.Width, null, null,
                        FormatType.Numeric, "{0:N0}", true);
                    bgvXetNghiem.Columns[bgvXetNghiem.Columns.Count - 1].OwnerBand = bandUngroupped;


                    //Thống kê số liệu
                    foreach (DataRow drXN in dataResult.Rows)
                    {
                        var maXN = drXN["MaXN"].ToString();
                        var dataSum = WorkingServices.SearchResult_OnDatatable_NoneSort(data,
                            string.Format("MaXN = '{0}' and DoiTuongDichVu = '{1}'", maXN, maDoiTuong));
                        if (dataSum.Rows.Count > 0)
                        {
                            var tongSo = dataSum.AsEnumerable().Sum(r => r.Field<double?>("SoLuong") ?? 0);
                            var heSo = dataSum.AsEnumerable().Sum(r => r.Field<double?>("SoLuongHeSo") ?? 0);
                            if (!chkHeSoTinhRieng.Checked)
                                heSo = tongSo;
                            drXN[colSlName] = tongSo;
                            drXN[colHSName] = heSo;

                            drXN[colTong] = (double.Parse(string.IsNullOrEmpty(drXN[colTong].ToString())
                                                ? "0"
                                                : drXN[colTong].ToString())) + tongSo;
                            drXN[colHeSo] = (double.Parse(string.IsNullOrEmpty(drXN[colHeSo].ToString())
                                                ? "0"
                                                : drXN[colHeSo].ToString())) + heSo;
                        }
                    }
                }

                gcXetNghiem.DataSource = dataResult;
                bgvXetNghiem.ExpandAllGroups();
            }

            CustomMessageBox.CloseAlert();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gcXetNghiem,
                string.Format("SoLuongXetnghiemTheoMay_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), false, -1, -1,
                new[]
                    {lblTitle.Text, lblNgayBaoCao.Text, lblMayXetNghiem.Text}, new[] {16, 13, 13},
                new[] {"BỘ QUỐC PHÒNG", "BỆNH VIỆN TWQĐ 108", lblKhoa.Text});
        }

        private void InsertNewColToGrid(GridView gridView, string fieldName, string title, int width = 70,
            int? minWidth = null, int? maxWidth = null, FormatType? formatType = null, string formatString = null,
            bool groupSummary = false)
        {
            GridColumn col = gridView.Columns.AddVisible(fieldName, title);
            if (formatType != null)
            {
                col.DisplayFormat.FormatType = formatType.Value;
                col.GroupFormat.FormatType = formatType.Value;
            }

            if (!string.IsNullOrEmpty(formatString))
            {
                col.DisplayFormat.FormatString = formatString;
                col.GroupFormat.FormatString = formatString;
            }

            if (groupSummary)
            {
                col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[]
                {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName,
                        formatString)
                });
            }

            col.OptionsColumn.AllowEdit = false;
            col.OptionsColumn.ReadOnly = true;
            col.Width = width;
            if (minWidth != null)
            {
                col.MinWidth = 10;
            }

            if (maxWidth != null)
            {
                col.MaxWidth = 500;
            }

            col.ColumnEdit = new RepositoryItemTextEdit();
        }

        private void ucTongHopXetNghiem_May_DoiTuong_TatCa_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
