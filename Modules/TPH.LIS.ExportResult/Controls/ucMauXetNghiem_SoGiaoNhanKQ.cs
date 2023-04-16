using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.ExportResult.Service;
using TPH.LIS.Common.Extensions;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.ExportResult.Models;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucMauXetNghiem_SoGiaoNhanKQ : UserControl
    {
        public ucMauXetNghiem_SoGiaoNhanKQ()
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
            var condit = getCondit(); 
            var fileName = string.Format("SoGiaoNhanKetQua_{0}_{1}", 
                string.Join("-", condit.KhoaPhong),
                DateTime.Now.ToString("ddMMyyyyHHmmss"));

           Excel.ExportToExcel.Export(gcSoGiaoNhanKQXN, fileName, 
                false, -1, -1, new string[]
               {lblTitle.Text, lblNgayBaoCao.Text}, new int[] { 16, 13 },
               new string[] { TenSYT, TenBV });
        }
        private void ThongKeChiTietMauXN()
        {
            gcSoGiaoNhanKQXN.DataSource = null;
            var condit = getCondit();
            lblNgayBaoCao.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), 
                condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"), 
                condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var data = _iexport.XuatThongTinMau_GiaoNhanPhieuKQ(condit);
            if (data != null && data.Rows.Count > 0)
            {
                CustomMessageBox.ShowAlert("Đang xử lý số liệu.....");
                //  @Tungay as TuNgay, @DenNgay as DenNgay, c.MaTiepNhan, c.Barcode, c.HoTen, c.TenKhoaPhong
                //, c.NguoiChuyen, c.NguoiNhanKetQua, n.MaNhomXN, nh.TenNhomCLS, c.TGXacNhanChuyen, c.ThoiGianNhanKetQua
                //xử lý distinct
                var dataDistinct = data.DefaultView.ToTable(true, "IDChuyen", "TuNgay", "DenNgay", "MaTiepNhan", "Barcode"
                    , "HoTen", "TenKhoaPhong", "NguoiChuyen", "NguoiNhanKetQua","TGXacNhanChuyen", "ThoiGianNhanKetQua");
                var datareult = data.Clone();
                foreach (DataRow dr in dataDistinct.Rows)
                {
                    var maTiepNhan = dr["MaTiepNhan"].ToString();
                    var IDChuyen = dr["IDChuyen"].ToString();
                    var dataFound = WorkingServices.SearchResult_OnDatatable(data, string.Format("MaTiepNhan = '{0}' and IDChuyen = '{1}' "
                             , maTiepNhan, IDChuyen));

                    var tenNhom = string.Empty;
                    foreach (DataRow drNh in dataFound.Rows)
                    {
                        tenNhom += (string.IsNullOrEmpty(tenNhom) ? "" : ",") + drNh["TenNhomCLS"].ToString();
                    }
                    var r = datareult.NewRow();
                    foreach (DataColumn dtc in dataDistinct.Columns)
                    {
                        r[dtc.ColumnName] = dr[dtc.ColumnName];
                    }
                    r["TenNhomCLS"] = tenNhom;
                    datareult.Rows.Add(r);
                }
                if (!datareult.Columns.Contains("STT"))
                    datareult.Columns.Add("STT", typeof(int));
                if (datareult.Rows.Count > 0)
                {
                    for (int i = 0; i < datareult.Rows.Count; i++)
                    {
                        datareult.Rows[i]["STT"] = i + 1;
                    }
                }
                gcSoGiaoNhanKQXN.DataSource = datareult;
                gvSoGiaoNhanKQXN.ExpandAllGroups();
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

        private void ucMauXetNghiem_SoGiaoNhanKQ_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
