using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.ExportResult.Service;
using TPH.LIS.Common.Extensions;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.LIS.Common.Controls;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.Common;
using TPH.Excel;
using TPH.Language;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucKetQua_KetQuaViSinh_BCTH : UserControl
    {
        public ucKetQua_KetQuaViSinh_BCTH()
        {
            InitializeComponent();
        }
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            foreach (GridColumn item in bandedGridView1.Columns)
            {
                item.FieldName = item.FieldName.ToLower().Trim();
            }
            ThongKeChiTietMauXN();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportToExcel.Export_VS(gcCTXN, string.Format("THVS_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), false, -1, -1, new string[]
               {lblTitle.Text, lblNgayBaoCao.Text}, new int[] { 16, 13 },
               new string[] { "SỞ Y TẾ THÀNH PHỐ HÀ NỘI", "BỆNH VIỆN ĐẠI HỌC Y HÀ NỘI", "Khoa: Vi sinh" });
        }
        private void ThongKeChiTietMauXN()
        {
            gcCTXN.DataSource = null;
            //lblKhoa.Text = "Khoa:";
            var condit = getCondit();
            lblNgayBaoCao.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"), condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var data = new DataTable();
            if (chb_VSTQ.Checked)
            {
                condit.LoaiXetNghiem = new List<TestType.EnumTestType>()
                {
                    TestType.EnumTestType.ViSinh_TQ
                    ,TestType.EnumTestType.ViSinh
                    ,TestType.EnumTestType.ViSinhNam
                    ,TestType.EnumTestType.ViSinhSoiNhuom
                    ,TestType.EnumTestType.SinhHocPhanTu
                };
                data = _iexport.XuatThongTinMau_ViSinhThuongQui(condit);
            }
            else
            {
                condit.LoaiXetNghiem = new List<TestType.EnumTestType>()
                {
                    TestType.EnumTestType.ViSinhNuoiCay
                };
                data = _iexport.XuatThongTinMau_ViSinh(condit);
            }

            if (!data.Columns.Contains("STT"))
                data.Columns.Add("STT", typeof(int));
            if (data.Rows.Count > 0)
            {
                //var danhsachKhoaXN = data.DefaultView.ToTable(true, "MaBoPhan");
                //string dsKhoaXN = string.Empty;
                //foreach (DataRow drBp in danhsachKhoaXN.Rows)
                //{
                //    if (!string.IsNullOrEmpty(drBp["MaBoPhan"].ToString()))
                //    {
                //        dsKhoaXN += (string.IsNullOrEmpty(dsKhoaXN) ? "" : ", ");
                //        dsKhoaXN += drBp["MaBoPhan"].ToString();
                //    }
                //}
                //lblKhoa.Text = string.Format("Khoa: {0}", dsKhoaXN);
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["STT"] = i + 1;
                }
            }
            WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcCTXN.DataSource = data;
            CustomMessageBox.CloseAlert();
        }

        private void InsertNewColToGrid(GridView gridView,
          string fieldName, string title,
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

        private void chb_VSTQ_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ucKetQua_KetQuaViSinh_BCTH_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
