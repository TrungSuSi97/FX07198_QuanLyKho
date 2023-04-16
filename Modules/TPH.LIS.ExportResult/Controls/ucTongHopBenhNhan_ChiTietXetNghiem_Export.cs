using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.ExportResult.Service;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucTongHopBenhNhan_ChiTietXetNghiem_Export : UserControl
    {
        public ucTongHopBenhNhan_ChiTietXetNghiem_Export()
        {
            InitializeComponent();
        }
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;
  
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietXetNghiemTheoNgay();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (gvXetNghiemExport.RowCount > 0)
            {
                var arrCellMergeStar = new int[2, 2];
                arrCellMergeStar[0, 0] = 1;//row start
                arrCellMergeStar[0, 1] = 1;//column start

                arrCellMergeStar[1, 0] = 1;//row start
                arrCellMergeStar[1, 1] = 2;//column start

                var arrCellMergeEnd = new int[2, 2];
                arrCellMergeEnd[0, 0] = 2;//row end
                arrCellMergeEnd[0, 1] = 1;//column end

                arrCellMergeEnd[1, 0] = 2;//row end
                arrCellMergeEnd[1, 1] = 2;//column end


                var arrCellMergeRemove = new int[1, 2];
                arrCellMergeRemove[0, 0] = 1;//row end
                arrCellMergeRemove[0, 1] = 1;//column end

               Excel.ExportToExcel.Export(gvXetNghiemExport, string.Format("Xetnghiem_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), arrCellMergeStar, arrCellMergeEnd, arrCellMergeRemove);
            }
        }
        private void ThongKeChiTietXetNghiemTheoNgay()
        {
      
            gcXetNghiemExport.DataSource = null;
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var condit = getCondit();
            var dtTemp = _iexport.DanhSachExport_SangLoc_TruocSinh(condit);
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....");
                DataTable dtPatient = WorkingServices.DataTable_DistinctValue(dtTemp,
                    new string[] { "MaTiepNhan" });
                DataTable dtTestWithSepcialCode = WorkingServices.DataTable_DistinctValue(dtTemp,
                    new string[] { "MaXN","KyHieu" });

                var dmxn = dtTemp.AsEnumerable().Cast<DataRow>()
                                .Select(row => new
                                {
                                    MaXN = row.Field<string>("MaXN"),
                                    KyHieu = row.Field<string>("KyHieu")
                                }).Distinct().ToList();
                DataTable dataResult = dtTemp.Clone();
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Thêm các cột cho thống kê.");
                foreach (var item in dmxn)
                {
                    for (int i = 0; i < gvXetNghiemExport.Columns.Count; i++)
                    {
                        var col = gvXetNghiemExport.Columns[i];
                        if (col.Caption.Trim()
                            .Equals((item.KyHieu ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase)
                            )
                        {
                            col.FieldName = item.MaXN.ToLower();
                            dtTemp.Columns.Add(col.FieldName, typeof(string));
                            for (int iKl = 0; iKl < gvXetNghiemExport.Columns.Count; iKl++)
                            {
                                var colKl = gvXetNghiemExport.Columns[i];
                                var klCol = string.Format("kl_{0}", colKl.Caption.Trim());
                                var checkColKl = string.Format("kl_{0}", (item.KyHieu ?? string.Empty).Trim());
                                if (colKl.Caption.Trim()
                                    .Equals(checkColKl, StringComparison.OrdinalIgnoreCase)
                                    )
                                {
                                    colKl.FieldName = string.Format("kl_{0}", item.MaXN).ToLower();
                                    dtTemp.Columns.Add(colKl.FieldName, typeof(string));
                                }
                            }
                            break;
                        }
                        else
                            col.FieldName = col.FieldName.ToLower();
                    }
                }
                string finishAddColumns = string.Empty;
                var ngayTiepNhan = string.Empty;
                string tenXn = string.Empty;
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Tổng hợp kết quả xét nghiệm.");
                foreach (DataRow dr in dtPatient.Rows)
                {
                    var dtResulbyPatient = WorkingServices.SearchResult_OnDatatable(dtTemp, string.Format("MaTiepNhan = '{0}'", dr["MaTiepNhan"].ToString()));
                    if (dtResulbyPatient.Rows.Count > 0)
                    {
                        var drAdd = dataResult.NewRow();
                        foreach (DataColumn dtcP in dataResult.Columns)
                        {
                            drAdd[dtcP.ColumnName] = dtResulbyPatient.Rows[0][dtcP.ColumnName];
                        }
                        var kqTang = string.Empty;
                        var kqGiam = string.Empty;
                        foreach (DataRow drK in dtResulbyPatient.Rows)
                        {
                            var colName = drK["MaXN"].ToString();
                            if (dataResult.Columns.Contains(colName))
                            {
                                drAdd[colName] = drK["KetQua"].ToString();
                                if (!string.IsNullOrEmpty(drK["Tang"].ToString()))
                                    kqTang += (string.IsNullOrEmpty(kqTang) ? "" : ",") + drK["Tang"].ToString();
                                if (!string.IsNullOrEmpty(drK["Giam"].ToString()))
                                    kqGiam += (string.IsNullOrEmpty(kqGiam) ? "" : ",") + drK["Giam"].ToString();
                            }
                        }
                        drAdd["Tang"] = kqTang;
                        drAdd["Giam"] = kqGiam;
                        dataResult.Rows.Add(drAdd);
                    }
                }

                dataResult = WorkingServices.ConvertColumnNameToLower_Upper(dataResult, true);
                gcXetNghiemExport.DataSource = dataResult;
                gvXetNghiemExport.ExpandAllGroups();
            }
            CustomMessageBox.CloseAlert();
        }
        private void InsertNewColToGrid(GridView gridView, string fieldName, string title,
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

        private void ucTongHopBenhNhan_ChiTietXetNghiem_Export_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
