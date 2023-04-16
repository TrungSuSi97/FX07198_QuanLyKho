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
    public partial class ucExportAutoDelfia_PLGF : UserControl
    {
        public ucExportAutoDelfia_PLGF()
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
               Excel.ExportToExcel.Export(gvXetNghiemExport, string.Format("Export_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), null, null, null);
            }
        }
        private void ThongKeChiTietXetNghiemTheoNgay()
        {

            gcXetNghiemExport.DataSource = null;

            var condit = getCondit();
            if (condit.MayXetNghiem != null)
            {
                if (condit.MayXetNghiem.Count == 0 && condit.NhomXetNghiem.Count == 0)
                    CustomMessageBox.MSG_Information_OK("Hãy chọn máy hoặc nhóm xét nghiệm.");
                else
                {
                    CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
                    var dtTemp = _iexport.DanhSachExport_SangLoc_TruocSinh(condit);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        CustomMessageBox.ShowAlert("Đang xử lý số liệu.....");
                        DataTable dtPatient = WorkingServices.DataTable_DistinctValue(dtTemp,
                            new string[] { "MaTiepNhan" });
                        DataTable dtTestWithSepcialCode = WorkingServices.DataTable_DistinctValue(dtTemp,
                            new string[] { "MaXN", "KyHieu" });

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
                            dataResult.Columns.Add(item.MaXN.ToLower(), typeof(string));
                            var ColKl = string.Format("kl_{0}", item.MaXN).ToLower(); ;
                            dataResult.Columns.Add(ColKl, typeof(string));
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
                                    if (dtResulbyPatient.Columns.Contains(dtcP.ColumnName))
                                    {
                                        //if (dtcP.ColumnName.Equals("diachi", StringComparison.OrdinalIgnoreCase))
                                        //{
                                        //    var strArr = dtResulbyPatient.Rows[0][dtcP.ColumnName].ToString().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                                        //    drAdd[dtcP.ColumnName] = (strArr.Length > 0 ? strArr[0] : string.Empty);
                                        //}
                                        //else 
                                        if (dtcP.ColumnName.Equals("hotenme", StringComparison.OrdinalIgnoreCase))
                                        {
                                            var ten = dtResulbyPatient.Rows[0]["HoTen"].ToString().Trim().Split(' ');
                                            var tenme = string.Empty;
                                            if (ten.Length > 0)
                                                tenme = ten[ten.Length - 1];
                                            drAdd[dtcP.ColumnName] = dtResulbyPatient.Rows[0]["HoTen"].ToString().Replace(tenme, "").Trim();
                                        }
                                        else if (dtcP.ColumnName.Equals("tenme", StringComparison.OrdinalIgnoreCase))
                                        {
                                            var ten = dtResulbyPatient.Rows[0]["HoTen"].ToString().Trim().Split(' ');
                                            var tenme = string.Empty;
                                            if (ten.Length > 0)
                                                tenme = ten[ten.Length - 1].Trim();
                                            drAdd[dtcP.ColumnName] = tenme;
                                        }
                                        else if (dtcP.ColumnName.Equals("barcodelaymau", StringComparison.OrdinalIgnoreCase))
                                        {
                                            var ten = dtResulbyPatient.Rows[0]["barcodelaymau"].ToString().Trim().Split('|');
                                            var barcode = string.Empty;
                                            if (ten.Length > 1)
                                            {
                                                barcode = ten[1];
                                                drAdd[dtcP.ColumnName] = barcode;
                                            }
                                           else
                                                drAdd[dtcP.ColumnName] = dtResulbyPatient.Rows[0]["barcodelaymau"].ToString();
                                        }
                                        else
                                            drAdd[dtcP.ColumnName] = dtResulbyPatient.Rows[0][dtcP.ColumnName];
                                    }
                                }
                                var kqTang = string.Empty;
                                var kqGiam = string.Empty;
                                foreach (DataRow drK in dtResulbyPatient.Rows)
                                {
                                    var colName = drK["MaXN"].ToString().ToLower();
                                    if (dataResult.Columns.Contains(colName))
                                    {
                                        drAdd[colName] = drK["KetQua"].ToString();
                                        drAdd[string.Format("kl_{0}", colName)] = drK["GhiChu"].ToString();
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
                        for (int i = 0; i < gvXetNghiemExport.Columns.Count; i++)
                        {
                            gvXetNghiemExport.Columns[i].FieldName = gvXetNghiemExport.Columns[i].FieldName.ToLower();
                        }
                        dataResult = WorkingServices.ConvertColumnNameToLower_Upper(dataResult, true);
                        gcXetNghiemExport.DataSource = dataResult;
                        gvXetNghiemExport.ExpandAllGroups();
                    }
                    CustomMessageBox.CloseAlert();
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm.");
            }
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

        private void ucExportAutoDelfia_PLGF_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
