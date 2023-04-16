using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.ExportResult.Service;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.Common.Controls;
using TPH.Common.Converter;
using TPH.Excel;
using TPH.Language;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucKetQua_ViSinh_PhieuTienTrinh : UserControl
    {
        public ucKetQua_ViSinh_PhieuTienTrinh()
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
        private void ThongKeChiTietMauXN()
        {
            gcResult.DataSource = null;
            //lblKhoa.Text = "Khoa:";
            var condit = getCondit();
            lblNgayBaoCao.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"), condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var data = new DataTable();

            data = _iexport.XuatThongTinMau_ViSinh_PhieuTienTrinh(condit);

            if (!data.Columns.Contains("STT"))
                data.Columns.Add("STT", typeof(int));
            if (data.Rows.Count > 0)
            {
                int temp = 1;
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[0]["STT"] = 1;
                    if (i == 0)
                        continue;
                    if (NumberConverter.ToInt(data.Rows[i]["Seq"]) != NumberConverter.ToInt(data.Rows[i - 1]["Seq"]))
                    {
                        data.Rows[i]["STT"] = temp + 1;
                        temp++;
                    }
                }
            }
            //WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcResult.DataSource = data;
            CustomMessageBox.CloseAlert();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export_VS(gcResult, string.Format("PTT_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), false, -1, -1, new string[]
              {lblTitle.Text, lblNgayBaoCao.Text}, new int[] { 16, 13 },
              new string[] { "SỞ Y TẾ THÀNH PHỐ HÀ NỘI", "BỆNH VIỆN ĐẠI HỌC Y HÀ NỘI", "Khoa: Vi sinh" });
        }

        private void gvResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            //Nếu là cột tuổi
            if (e.Column == colPTT_Tuoi)
            {
                // Đem so sánh với seq nếu giống thì merge
                string text1 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Tuoi);
                string text2 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Tuoi);
                string text3 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Seq);
                string text4 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Seq);

                e.Merge = (text1 == text2) && (text3 == text4);
                e.Handled = true;
            }
            else if (e.Column == colPTT_TenBN)
            {
                // Đem so sánh với seq nếu giống thì merge
                string text1 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_TenBN);
                string text2 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_TenBN);
                string text3 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Seq);
                string text4 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Seq);

                e.Merge = (text1 == text2) && (text3 == text4);
                e.Handled = true;
            }
            else if (e.Column == colPTT_TenBN)
            {
                // Đem so sánh với seq nếu giống thì merge
                string text1 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_TenBN);
                string text2 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_TenBN);
                string text3 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Seq);
                string text4 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Seq);

                e.Merge = (text1 == text2) && (text3 == text4);
                e.Handled = true;
            }
            else if (e.Column == colPTT_GioiTinh)
            {
                // Đem so sánh với seq nếu giống thì merge
                string text1 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_GioiTinh);
                string text2 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_GioiTinh);
                string text3 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Seq);
                string text4 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Seq);

                e.Merge = (text1 == text2) && (text3 == text4);
                e.Handled = true;
            }
            else if (e.Column == colPTT_TenLoaiMauHis)
            {
                // Đem so sánh với seq nếu giống thì merge
                string text1 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_TenLoaiMauHis);
                string text2 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_TenLoaiMauHis);
                string text3 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Seq);
                string text4 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Seq);

                e.Merge = (text1 == text2) && (text3 == text4);
                e.Handled = true;
            }
            else if (e.Column == colPTT_TenYeuCau)
            {
                // Đem so sánh với seq nếu giống thì merge
                string text1 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_TenYeuCau);
                string text2 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_TenYeuCau);
                string text3 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Seq);
                string text4 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Seq);

                e.Merge = (text1 == text2) && (text3 == text4);
                e.Handled = true;
            }
            else if (e.Column == colSTT)
            {
                // Đem so sánh với seq nếu giống thì merge
                string text1 = gvResult.GetRowCellDisplayText(e.RowHandle1, colSTT);
                string text2 = gvResult.GetRowCellDisplayText(e.RowHandle2, colSTT);
                string text3 = gvResult.GetRowCellDisplayText(e.RowHandle1, colPTT_Seq);
                string text4 = gvResult.GetRowCellDisplayText(e.RowHandle2, colPTT_Seq);

                e.Merge = (text1 != text2) && (text3 == text4);
                e.Handled = true;
            }
        }

        private void gvResult_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            
        }

        private void ucKetQua_ViSinh_PhieuTienTrinh_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
