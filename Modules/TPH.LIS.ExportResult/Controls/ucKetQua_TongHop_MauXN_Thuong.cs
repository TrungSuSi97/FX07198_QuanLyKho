using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.ExportResult.Service;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.ExportResult.Models;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucKetQua_TongHop_MauXN_Thuong : UserControl
    {
        public ucKetQua_TongHop_MauXN_Thuong()
        {
            InitializeComponent();
        }
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;
        public string TenBV = string.Empty;
        public string TenSYT = string.Empty;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietMauXN();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcCTXN, string.Format("SoLayNhanMau_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), false, -1, -1, new string[]
               {lblTitle.Text, lblNgayBaoCao.Text}, new int[] { 16, 13 },
               new string[] { TenSYT, TenBV, lblKhoa.Text });
        }
        private void ThongKeChiTietMauXN()
        {
            gcCTXN.DataSource = null;
            lblKhoa.Text = "Khoa:";
            var condit = getCondit();
            lblNgayBaoCao.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"), condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var data = _iexport.XuatThongTinMau_Normal(condit);
            if (data != null)
            {
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....");
                if (!data.Columns.Contains("STT"))
                    data.Columns.Add("STT", typeof(int));
                if (data.Rows.Count > 0)
                {
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
                    //Group by các dòng lại
                    //Vì mã bộ phận làm ra nhiều dòng
                    data.Columns.Remove("MaBoPhan");
                    data = data.DefaultView.ToTable(true, data.Columns.Cast<DataColumn>()
                                     .Select(x => x.ColumnName)
                                     .ToArray());
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        data.Rows[i]["STT"] = i + 1;
                    }
                }
                gcCTXN.DataSource = data;
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

        private void ucKetQua_TongHop_MauXN_Thuong_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
