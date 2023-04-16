using System;
using System.Windows.Forms;
using TPH.LIS.ExportResult.Service;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.LIS.Common.Controls;
using TPH.LIS.ExportResult.Models;
using TPH.Excel;
using TPH.Language;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucKetQua_ViSinh_ThongTinMau : UserControl
    {
        public ucKetQua_ViSinh_ThongTinMau()
        {
            InitializeComponent();
        }
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietMauXN();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export_VS(gcCTXN, string.Format("SoTheoDoi_TTNuoiCayPLViKhuan_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), false, -1, -1, new string[]
               {lblTitle.Text, lblNgayBaoCao.Text}, new int[] { 16, 13 },
               new string[] { "SỞ Y TẾ THÀNH PHỐ HÀ NỘI", "BỆNH VIỆN ĐẠI HỌC Y HÀ NỘI", "Khoa: Vi sinh"});
        }
        private void ThongKeChiTietMauXN()
        {
            gcCTXN.DataSource = null;
            var condit = getCondit();
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var data = _iexport.XuatKetQuaViSinh_ThongTinMau(condit);
            //if (!data.Columns.Contains("STT"))
            //    data.Columns.Add("STT", typeof(int));
            //if (!data.Columns.Contains("Ten"))
            //    data.Columns.Add("Ten", typeof(string));
            //if (data.Rows.Count > 0)
            //{
            //    var danhsachKhoaXN = data.DefaultView.ToTable(true, "MaBoPhan");
            //    string dsKhoaXN = string.Empty;
            //    foreach (DataRow drBp in danhsachKhoaXN.Rows)
            //    {
            //        if (!string.IsNullOrEmpty(drBp["MaBoPhan"].ToString()))
            //        {
            //            dsKhoaXN += (string.IsNullOrEmpty(dsKhoaXN) ? "" : ", ");
            //            dsKhoaXN += drBp["MaBoPhan"].ToString();
            //        }
            //    }
            //    for (int i = 0; i < data.Rows.Count; i++)
            //    {
            //        data.Rows[i]["STT"] = i + 1;
            //        var ten = data.Rows[i]["TenBN"].ToString().Replace("  ", " ").Trim().Split(' ');
            //        data.Rows[i]["Ten"] = ten[ten.Length - 1];
            //    }
            //}
            gcCTXN.DataSource = data;
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

        private void ucKetQua_ViSinh_ThongTinMau_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
