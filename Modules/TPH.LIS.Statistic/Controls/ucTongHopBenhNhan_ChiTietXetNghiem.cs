using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Extensions;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.LIS.Common.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using TPH.Language;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopBenhNhan_ChiTietXetNghiem : UserControl
    {
        public ucTongHopBenhNhan_ChiTietXetNghiem()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietXetNghiem();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcCTXN, string.Format("ChiTietXetnghiem_BenhNhan_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }
        private void ThongKeChiTietXetNghiem()
        {
            var c = 3;
            while (bgvChiTiet.Columns.Count > c)
            {
                bgvChiTiet.Columns.RemoveAt(c);
            }
            var d = 1;
            while (bgvChiTiet.Bands.Count > d)
            {
                bgvChiTiet.Bands.RemoveAt(d);
            }
            gcCTXN.DataSource = null;

            var condit = getCondit();
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var dtTemp = _iStatistic.ThongKeXetNghiem_TheoNgay(condit);

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....", 8);
                DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp,
                    new string[] { "NgayTiepNhan", "MaTiepNhan", "TenBN", "tuoi", "BacSiCD", "TenNhanVien" });

                var dmxn = dtTemp.AsEnumerable().Cast<DataRow>()
                                .Select(row => new
                                {
                                    MaXN = row.Field<string>("MaXN"),
                                    TenXN = row.Field<string>("TenXN"),
                                    SapXep = row.Field<int>("SapXep"),
                                    ThuTuIn = row.Field<int>("ThuTuIn"),
                                    TenNhom = row.Field<string>("TenNhomCLS")
                                }).Distinct().ToList().OrderBy(x => x.ThuTuIn).ThenBy(x => x.SapXep);
                //Total = (from q in dtTemp.AsEnumerable() where q.Field<string>("MaXN") == row.Field<string>("MaXN") select q).Count()
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Thêm các cột cho thống kê.");
                GridBand bandUngroupped = new GridBand();
                var currentNhom = -1;
                string finishAddColumns = string.Empty;
                foreach (var item in dmxn)
                {
                    if (currentNhom != item.ThuTuIn)
                    {
                        currentNhom = item.ThuTuIn;
                        bandUngroupped = new GridBand();
                        bandUngroupped.Caption = item.TenNhom;
                        bgvChiTiet.Bands.Add(bandUngroupped);
                    }
                    CustomMessageBox.ShowAlert(string.Format("Đang xử lý số liệu.....\n   Thêm cột: {0}", item.TenXN));
                    var maXN = string.Format("XN_{0}", item.MaXN.Trim()).ToUpper();
                    if (!finishAddColumns.Contains(string.Format("|^{0}^|", maXN)))
                    {
                        InsertNewColToGrid(bgvChiTiet, maXN, item.TenXN, 100, null, null, FormatType.Numeric, "{0:N0}", true);
                        if (dtResult.Columns.Contains(maXN))
                            continue;
                        dtResult.Columns.Add(maXN, typeof(double));
                        bgvChiTiet.Columns[bgvChiTiet.Columns.Count - 1].OwnerBand = bandUngroupped;
                        finishAddColumns += string.Format("|^{0}^|", maXN);
                    }
                }

                InsertNewColToGrid(bgvChiTiet, "TenNhanVien", "Bác sĩ chỉ định", 250);

                string matiepNhanMain = string.Empty;
                string tenXn = string.Empty;
                DataTable dtTempResultDetail = dtTemp.Clone();
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Tổng hợp số lượng xét nghiệm.");
                foreach (DataRow dr in dtResult.Rows)
                {
                    tenXn = string.Empty;
                    matiepNhanMain = dr["MatiepNhan"].ToString().Trim();
                    dtTempResultDetail.Clear();
                    dtTemp.Select("MaTiepNhan = '" + matiepNhanMain + "'").CopyToDataTable(dtTempResultDetail, LoadOption.OverwriteChanges);
                    CustomMessageBox.ShowAlert(string.Format("Đang xử lý số liệu.....\n Tổng hợp số lượng xét nghiệm.\n Mã tiếp nhận: {0}", matiepNhanMain));
                    for (int i = 0; i < dtTempResultDetail.Rows.Count; i++)
                    {
                        var maXN = string.Format("XN_{0}", dtTempResultDetail.Rows[i]["MaXN"].ToString()).Trim().ToUpper();
                        dr[maXN] = 1;
                    }

                    dtResult.AcceptChanges();
                }
                gcCTXN.DataSource = dtResult;
                bgvChiTiet.ExpandAllGroups();

            }
            CustomMessageBox.CloseAlert();
        }
      
        private void InsertNewColToGrid(GridView gridView,
    string fieldName, string title,
    int width = 70, int? minWidth = null, int? maxWidth = null, FormatType? formatType = null, string formatString = null, bool groupSummary = false)
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
                col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName, formatString)});
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

        private void ucTongHopBenhNhan_ChiTietXetNghiem_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
