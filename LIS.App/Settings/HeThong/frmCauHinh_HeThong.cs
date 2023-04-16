using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.CauHinh.HeThong
{
    public partial class frmCauHinh_HeThong : FrmTemplate
    {
        public frmCauHinh_HeThong()
        {
            InitializeComponent();
        }
        C_Config config = new C_Config();
        private void btnBrowseSaveSieuAm_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowDialog();
            if (fld.SelectedPath != null)
            {
                txtPathSaveSieuAm.Text = fld.SelectedPath;
            }
        }

        private void radAutoCalculate_CheckedChanged(object sender, EventArgs e)
        {
            pnAutoCalculate.Enabled = radAutoCalculate.Checked;

        }

        private void txtAutoCalculateTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void btnLuuXQuang_Click(object sender, EventArgs e)
        {
            if (txtPathSaveSieuAm.Text != "")
            {
                config.Update_CauHinhSA(txtPathSaveSieuAm.Text, txtPathVideo.Text);
            }
        }

        private void btnLuuXN_Click(object sender, EventArgs e)
        {
            bool _ValidPrint = radValidWhenPrint.Checked;
            bool _AutoCalculate = radAutoCalculate.Checked;
            int _Time = (txtAutoCalculateTime.Text == "" ? 0 : int.Parse(txtAutoCalculateTime.Text));
            bool _AutoCalculateAll = chkCalculateInday.Checked;
            config.Update_CauHinhXN(_ValidPrint, _AutoCalculate, _Time, _AutoCalculateAll);
        }

        private void btnLuuTN_Click(object sender, EventArgs e)
        {
            bool _AutoID = radAutoID.Checked;
            config.Update_CauHinhTiepNhan(_AutoID);
        }

        private void Set_Config()
        {
            DataTable dtConfig = config.Data_Config();
            if (dtConfig.Rows.Count > 0)
            {
                //Cấu hình của tiếp nhận
                radAutoID.DataBindings.Clear();
                radAutoID.DataBindings.Add("Checked", dtConfig, "AutoID");
                //Cấu hình XN
                radValidWhenPrint.DataBindings.Clear();
                radValidWhenPrint.DataBindings.Add("Checked", dtConfig, "ValidPrintXN");
                radAutoCalculate.DataBindings.Clear();
                radAutoCalculate.DataBindings.Add("Checked", dtConfig, "AutoCalculate");
                chkCalculateInday.DataBindings.Clear();
                chkCalculateInday.DataBindings.Add("Checked", dtConfig, "AutoCalculateAll");
                txtPathSaveSieuAm.DataBindings.Clear();
                txtPathSaveSieuAm.DataBindings.Add("Text", dtConfig, "AutoCalculateTime");
                //Cấu hình siêu âm
                txtPathSaveSieuAm.DataBindings.Clear();
                txtPathSaveSieuAm.DataBindings.Add("Text", dtConfig, "CapturePath");
                txtPathVideo.DataBindings.Clear();
                txtPathVideo.DataBindings.Add("Text", dtConfig, "VideoStreamPath");
                //Cấu hình nội soi
                txtPathImageNS.DataBindings.Clear();
                txtPathImageNS.DataBindings.Add("Text", dtConfig, "CapturePathNS");
                txtPathVideoNS.DataBindings.Clear();
                txtPathVideoNS.DataBindings.Add("Text", dtConfig, "VideoStreamPathNS");
                Set_ConfigPreviewNS(dtConfig.Rows[0]["PreviewCaptureNS"].ToString());
                //Cấu hình điện tim
                txtECGResultPath.DataBindings.Clear();
                txtECGResultPath.DataBindings.Add("Text", dtConfig, "ECGInsPath");
                txtECGLastestResult.DataBindings.Clear();
                txtECGLastestResult.DataBindings.Add("Text", dtConfig, "ECGResultPath");
                Set_ConfigImageDienTim(dtConfig.Rows[0]["ECGImageSize"].ToString());

            }
        }

        private void frmCauHinh_HeThong_Load(object sender, EventArgs e)
        {
            Set_Config();
            tabConfig.TabPages.Remove(tabSieuAm);
            tabConfig.TabPages.Remove(tabNoiSoi);
            tabConfig.TabPages.Remove(tabDienTim);
        }

        private void btnBrowsePathVideo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowDialog();
            if (fld.SelectedPath != null)
            {
                txtPathVideo.Text = fld.SelectedPath;
            }
        }

        private void btnBrowseImgNS_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowDialog();
            if (fld.SelectedPath != null)
            {
                txtPathImageNS.Text = fld.SelectedPath;
            }
        }

        private void btnBrowseVideoNS_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowDialog();
            if (fld.SelectedPath != null)
            {
                txtPathVideoNS.Text = fld.SelectedPath;
            }
        }

        private void btnSaveConfigNS_Click(object sender, EventArgs e)
        {
            config.Update_CauHinhNS(txtPathImageNS.Text, txtPathVideoNS.Text, Get_ConfigPreviewNS());
        }
        private string Get_ConfigPreviewNS()
        {
            string _result = "";
            if (rad1024x768.Checked)
                _result = "1024x768";
            else if (radNS800x600.Checked)
                _result = "800x600";
            else if (radNS640x480.Checked)
                _result = "640x480";
            else
                _result = "320x240";
            frmMDIParent.PreviewCaptureNs = _result;
            return _result;
        }

        private void Set_ConfigPreviewNS(string _configstring)
        {
            if (_configstring == "1024x768")
                rad1024x768.Checked = true;
            else if (_configstring == "800x600")
                radNS800x600.Checked = true;
            else if (_configstring == "640x480")
                radNS640x480.Checked = true;
            else
                radNS320x240.Checked = true;

        }

        private void btnBrowseECGrsPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowDialog();
            if (fld.SelectedPath != null)
            {
                txtECGResultPath.Text = fld.SelectedPath;
            }
        }

        private void btnBrowseECGrsLastest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowDialog();
            if (fld.SelectedPath != null)
            {
                txtECGLastestResult.Text = fld.SelectedPath;
            }
        }

        private void btnSaveConfigDienTim_Click(object sender, EventArgs e)
        {
            config.Update_CauHinhDienTim(txtECGResultPath.Text, txtECGLastestResult.Text, Get_ConfigImageDienTim());
            frmMDIParent.EcgInsPath = txtECGResultPath.Text;
            frmMDIParent.EcgResultPath = txtECGLastestResult.Text;
        }
        private string Get_ConfigImageDienTim()
        {
            string _result = "";
            if (radECG1024x768.Checked)
                _result = "1024x768";
            else if (radECG800x600.Checked)
                _result = "800x600";
            else if (radECG640x480.Checked)
                _result = "640x480";
            else
                _result = "320x240";
            frmMDIParent.EcgImageSize = _result;
            return _result;
        }
        private void Set_ConfigImageDienTim(string _configstring)
        {
            if (_configstring == "1024x768")
                radECG1024x768.Checked = true;
            else if (_configstring == "800x600")
                radECG800x600.Checked = true;
            else if (_configstring == "640x480")
                radECG640x480.Checked = true;
            else
                radNS320x240.Checked = true;

        }
    }
}
