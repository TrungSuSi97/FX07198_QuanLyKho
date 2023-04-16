using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.Controls;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucKiemSoatDownloadMayXn : UserControl
    {
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        int _barcodeLenght = 0;
        public string userLogin = string.Empty;
        public string[] arrPhanQuyenBoPhan;
        public string[] arrPhanQuyenNhom;

        public int BarcodeLenght
        {
            get
            {
                return _barcodeLenght;
            }
            set
            {
                _barcodeLenght = value;
                pnNgayTiepNhan.Visible = _barcodeLenght < 5;
                txtNhapBarcode.MaxLength = _barcodeLenght + 2;
            }
        }
        public ucKiemSoatDownloadMayXn()
        {
            InitializeComponent();
            pnTrangThaiMiddleware.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnTrangThaiTPH.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        public void Set_ShowForConfig(bool withMiddleWare )
        {
         
            pnTrangThaiMiddleware.Visible = withMiddleWare;
            colDownLoadChiDinh_DaDownLoadInfinity.Visible = withMiddleWare;
            if (!withMiddleWare)
                colDownLoadChiDinh_DaDownloadMayThuong.Caption = "Đã chỉ định";
        }
        public void SetDate(DateTime serverDate)
        {
            dtpTuNgayChiDinh.Value = WorkingServices.StartOfDay(serverDate);
            dtpDenNgayChiDinh.Value = WorkingServices.EndOfDay(serverDate);
        }
        public void Load_DanhSach_XetNghiem()
        {
            var data = _isSysConfig.Data_dm_xetnghiem(string.Join(",", arrPhanQuyenNhom ?? new string[1] { "---NONE---" }), true, string.Empty);
            foreach (DataColumn dtc in data.Columns)
            {
                dtc.ColumnName = dtc.ColumnName.ToLower();
            }
            data.AcceptChanges();
            gcTestCode.DataSource = data;
            gvTestCode.ExpandAllGroups();
        }
        private void Load_DanhSachChiDinh()
        {
            gcChiDinh.DataSource = null;
            if (string.IsNullOrEmpty(txtDanhSachBarcode.Text.Trim()))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập barcode!");
                txtNhapBarcode.Focus();
            }
            else
            {
                var fromDate = pnNgayTiepNhan.Visible ? new DateTime(dtpTuNgayChiDinh.Value.Year, dtpTuNgayChiDinh.Value.Month, dtpTuNgayChiDinh.Value.Day, 0, 0, 0) : (DateTime?)null;
                var toDate = pnNgayTiepNhan.Visible ? new DateTime(dtpDenNgayChiDinh.Value.Year, dtpDenNgayChiDinh.Value.Month, dtpDenNgayChiDinh.Value.Day, 23, 59, 59) : (DateTime?)null;
                var selectedTestID = Get_SelectedMaXN();
                gcChiDinh.DataSource = _iAnalyzerResult.GetTestInDownloadList(fromDate, toDate, 2, txtDanhSachBarcode.Text, string.Empty, selectedTestID, Utilities.ConvertStrinArryToInClauseSQL(arrPhanQuyenNhom, false));
            }
        }
        private string Get_SelectedMaXN()
        {
            var selectedTestID = string.Empty;
            foreach (int i in gvTestCode.GetSelectedRows())
            {
                if (gvTestCode.GetRowCellValue(i, clTestCode) != null)
                {
                    selectedTestID += string.IsNullOrEmpty(selectedTestID) ? "" : ",";
                    selectedTestID += gvTestCode.GetRowCellValue(i, clTestCode).ToString().Trim();
                }
            }
            return selectedTestID;
        }
        private void btnDanhSachChiDinh_Click(object sender, EventArgs e)
        {
            Load_DanhSachChiDinh();
        }

        private void txtNhapBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNhapBarcode.Text = WorkingServices.GetBarcodeInString(txtNhapBarcode.Text, _barcodeLenght);
                txtDanhSachBarcode.Text += (string.IsNullOrEmpty(txtDanhSachBarcode.Text) ? "" : ",") + txtNhapBarcode.Text.Trim();
                if (!string.IsNullOrEmpty(txtDanhSachBarcode.Text))
                    Load_DanhSachChiDinh();
                e.Handled = true;
            }
        }
        private int resetDownloadStatus(bool isDownloaded, bool infinity, bool normalAnalyzer)
        {
            int iCount = 0;
            var lstMaXn = new List<string>();
            var maTiepNhan = string.Empty;
            if (gvChiDinh.SelectedRowsCount > 0)
            {
                foreach (int i in gvChiDinh.GetSelectedRows())
                {
                    if (gvChiDinh.GetRowCellValue(i, colChiDinhMaXn) != null)
                    {
                        if (i > 0 && !gvChiDinh.GetRowCellValue(i, colChiDinhMaTiepNhan).ToString().Trim().Equals(maTiepNhan))
                        {
                            iCount += _iAnalyzerResult.UpdateDownloadStatus(isDownloaded, maTiepNhan, lstMaXn, userLogin, infinity, normalAnalyzer);
                            lstMaXn = new List<string>();
                        }
                        maTiepNhan = gvChiDinh.GetRowCellValue(i, colChiDinhMaTiepNhan).ToString();
                        lstMaXn.Add(gvChiDinh.GetRowCellValue(i, colChiDinhMaXn).ToString());
                    }
                }
                iCount += _iAnalyzerResult.UpdateDownloadStatus(isDownloaded, maTiepNhan, lstMaXn, userLogin, infinity, normalAnalyzer);
            }
            return iCount;
        }
        private void btnSetDaDownload_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Chuyển trạng thái chỉ định thành ĐÃ download ?\nLưu ý: Các chỉ định này sẽ KHÔNG được tự động chuyển đến máy xét nghiệm."))
            {
                if (resetDownloadStatus(true, false, true) > 0)
                    Load_DanhSachChiDinh();
                else
                    CustomMessageBox.MSG_Information_OK("Không có chỉ định nào được chọn.");
            }
        }

        private void btnSetChuaChiDinh_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Chuyển trạng thái chỉ định thành CHƯA download ?\nLưu ý: Các chỉ định này sẽ ĐƯỢC tự động chuyển đến máy xét nghiệm."))
            {
                if (resetDownloadStatus(false, false, true) > 0)
                    Load_DanhSachChiDinh();
                else
                    CustomMessageBox.MSG_Information_OK("Không có chỉ định nào được chọn.");
            }
        }

        private void btnDaDonwnloadInfinity_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Chuyển trạng thái chỉ định thành ĐÃ download ?\nLưu ý: Các chỉ định này sẽ KHÔNG được tự động gửi đến Infinity."))
            {
                if (resetDownloadStatus(true, true, false) > 0)
                    Load_DanhSachChiDinh();
                else
                    CustomMessageBox.MSG_Information_OK("Không có chỉ định nào được chọn.");
            }
        }

        private void btnNotDownloadInfinity_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Chuyển trạng thái chỉ định thành CHƯA download ?\nLưu ý: Các chỉ định này sẽ ĐƯỢC tự động gửi Infinity."))
            {
                if (resetDownloadStatus(false, true, false) > 0)
                    Load_DanhSachChiDinh();
                else
                    CustomMessageBox.MSG_Information_OK("Không có chỉ định nào được chọn.");
            }
        }

        private void btnXoaDanhSachSID_Click(object sender, EventArgs e)
        {
            txtDanhSachBarcode.Text = string.Empty;
        }
        public void ReCalculateSpliter()
        {
            splitContainer1.SplitterDistance = btnSetChuaChiDinh.Location.X + btnSetChuaChiDinh.Width + btnSetDaDownload.Location.X;
        }
        private void ucKiemSoatDownloadMayXn_DpiChangedAfterParent(object sender, EventArgs e)
        {
            ReCalculateSpliter();
        }
    }
}
