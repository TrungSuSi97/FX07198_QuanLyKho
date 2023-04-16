using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Extensions;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.Language;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopXetNghiem_TheoNgay : UserControl
    {
        public ucTongHopXetNghiem_TheoNgay()
        {
            InitializeComponent();
        }

        private readonly IStatisticService _iStatistic = new StatisticService();

        public delegate NormalStatisticCondit GetCondit();

        public event GetCondit getCondit;

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietXetNghiemTheoNgay();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (bandedGridView1.RowCount > 0)
            {
                var arrCellMergeStar = new int[2, 2];
                arrCellMergeStar[0, 0] = 1; //row start
                arrCellMergeStar[0, 1] = 1; //column start

                arrCellMergeStar[1, 0] = 1; //row start
                arrCellMergeStar[1, 1] = 2; //column start

                var arrCellMergeEnd = new int[2, 2];
                arrCellMergeEnd[0, 0] = 2; //row end
                arrCellMergeEnd[0, 1] = 1; //column end

                arrCellMergeEnd[1, 0] = 2; //row end
                arrCellMergeEnd[1, 1] = 2; //column end


                var arrCellMergeRemove = new int[1, 2];
                arrCellMergeRemove[0, 0] = 1; //row end
                arrCellMergeRemove[0, 1] = 1; //column end

                Excel.ExportToExcel.Export(bandedGridView1,
                    string.Format("XetnghiemTheoNgay_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), arrCellMergeStar,
                    arrCellMergeEnd, arrCellMergeRemove);
            }
        }

        private void ThongKeChiTietXetNghiemTheoNgay()
        {

            gcXetNghiemTheoNgay.DataSource = null;
            var c = 2;
            while (bandedGridView1.Columns.Count > c)
            {
                bandedGridView1.Columns.RemoveAt(c);
            }

            var d = 1;
            while (bandedGridView1.Bands.Count > d)
            {
                bandedGridView1.Bands.RemoveAt(d);
            }

            CustomMessageBox.ShowAlert(LanguageExtension.GetResourceValueFromValue("Đang tổng hợp số liệu.....",
                LanguageExtension.AppLanguage));
            var condit = getCondit();
            var dtTemp = _iStatistic.ThongKeXetNghiem_TheoNgay(condit);
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                CustomMessageBox.ShowAlert(LanguageExtension.GetResourceValueFromValue("Đang xử lý số liệu.....",
                    LanguageExtension.AppLanguage));
                DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp,
                    new string[] {"NgayTiepNhan"});

                dtResult.Columns.Add("STT", typeof(int));

                var dmxn = dtTemp.AsEnumerable().Cast<DataRow>()
                    .Select(row => new
                    {
                        MaXN = row.Field<string>("MaXN"),
                        TenXN = row.Field<string>("TenXN"),
                        ThuTuIn = row.Field<int>("ThuTuIn"),
                        SapXep = row.Field<int>("SapXep"),
                        TenNhom = row.Field<string>("TenNhomCLS")
                    }).Distinct().OrderBy(x => x.ThuTuIn).ThenBy(x => x.SapXep).ToList();
                CustomMessageBox.ShowAlert(LanguageExtension.GetResourceValueFromValue(
                    "Đang xử lý số liệu.....\r\n   Thêm các cột cho thống kê.",
                    LanguageExtension.AppLanguage));
                GridBand bandUngroupped = new GridBand();
                string finishAddColumns = string.Empty;
                var currentNhom = -1;
                var ms = LanguageExtension.GetResourceValueFromValue("Đang xử lý số liệu.....\r\n   Thêm cột: {0}",
                    LanguageExtension.AppLanguage);
                foreach (var item in dmxn)
                {
                    CustomMessageBox.ShowAlert(string.Format(ms, item.TenXN));
                    if (currentNhom != item.ThuTuIn)
                    {
                        currentNhom = item.ThuTuIn;
                        bandUngroupped = new GridBand();
                        bandUngroupped.Caption = item.TenNhom;
                        bandedGridView1.Bands.Add(bandUngroupped);
                    }

                    var maXN = string.Format("XN_{0}", item.MaXN.Trim()).ToUpper();
                    if (!finishAddColumns.Contains(string.Format("|^{0}^|", maXN)))
                    {
                        InsertNewColToGrid(bandedGridView1, maXN, item.TenXN, 100, null, null, FormatType.Numeric,
                            "{0:N0}", true);
                        if (dtResult.Columns.Contains(maXN))
                            continue;
                        dtResult.Columns.Add(maXN, typeof(double));
                        bandedGridView1.Columns[bandedGridView1.Columns.Count - 1].OwnerBand = bandUngroupped;
                        finishAddColumns += string.Format("|^{0}^|", maXN);
                    }
                }

                var ngayTiepNhan = string.Empty;

                string tenXn = string.Empty;
                int colCount = 0;
                CustomMessageBox.ShowAlert(LanguageExtension.GetResourceValueFromValue(
                    "Đang xử lý số liệu.....\r\n   Tổng hợp số lượng xét nghiệm.",
                    LanguageExtension.AppLanguage));
                ms = LanguageExtension.GetResourceValueFromValue(
                    "Đang xử lý số liệu.....\r\n Tổng hợp số lượng xét nghiệm.\r\n Ngày tiếp nhận: {0}",
                    LanguageExtension.AppLanguage);
                foreach (DataRow dr in dtResult.Rows)
                {
                    tenXn = string.Empty;
                    ngayTiepNhan = dr["NgayTiepNhan"].ToString().Trim();
                    CustomMessageBox.ShowAlert(string.Format(ms, DateTime.Parse(ngayTiepNhan).ToString("dd/MM/yyyy")));
                    colCount++;

                    dr["STT"] = colCount;

                    DataTable dtTempResultDetail = dtTemp.Clone();
                    dtTemp.Select("NgayTiepNhan = '" + ngayTiepNhan + "'")
                        .CopyToDataTable(dtTempResultDetail, LoadOption.OverwriteChanges);
                    double sum = 0;
                    for (int i = 0; i < dtTempResultDetail.Rows.Count; i++)
                    {
                        var maXN = string.Format("XN_{0}", dtTempResultDetail.Rows[i]["MaXN"].ToString().Trim())
                            .ToUpper();
                        sum = double.Parse(string.IsNullOrEmpty(dr[maXN].ToString()) ? "0" : dr[maXN].ToString());
                        sum += double.Parse(dtTempResultDetail.Rows[i]["SoLuong"].ToString().Trim());
                        dr[maXN] = sum;
                    }

                    dtResult.AcceptChanges();
                }

                gcXetNghiemTheoNgay.DataSource = dtResult;

                bandedGridView1.ExpandAllGroups();
            }

            CustomMessageBox.CloseAlert();
        }

        private void InsertNewColToGrid(GridView gridView, string fieldName, string title,
            int width = 70, int? minWidth = null, int? maxWidth = null, FormatType? formatType = null,
            string formatString = null, bool groupSummary = false)
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

        private void ucTongHopXetNghiem_TheoNgay_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}