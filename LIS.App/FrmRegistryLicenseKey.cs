using System;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Common.StringCryptography;
using TPH.LIS.Common;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App
{
    public partial class FrmRegistryLicenseKey : Form
    {
        private static ISystemConfigService _systemService = new SystemConfigService();
        bool f = false;
        public FrmRegistryLicenseKey()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }
        private void FrmRegistryKey_Load(object sender, EventArgs e)
        {
            txtSerial.Text = TPHSerialKeys.GetSerial();
            CheckLicense();
            if (CommonAppVarsAndFunctions.License.CheckLicenseOnServer && 
                !CommonAppVarsAndFunctions.License.PcName.Equals(TPHSerialKeys.GetComputerName()))
            {
                btnOk.Enabled = false;
            }
        }

        private void FrmRegistryKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!f)
                e.Cancel = true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show(CommonAppVarsAndFunctions.LangMessageConstant.VuiLongNhapMaDangKy, CommonConstant.ApplicationName);
                txtKey.Focus();
            }
            else
            {
                //var computerName = TPHSerialKeys.GetComputerName();
                var applicationName = TPHSerialKeys.GetApplicationName();
                var splitAppName = TPHSerialKeys.GetApplicationId().Split('.');
                var application = string.Format("{0}.{1}", splitAppName[0], splitAppName[1]);
                f = TPHSerialKeys.CheckProtocolLicense(txtSerial.Text, application, txtKey.Text);
                if (f)
                {
                    _systemService.UpdateSerialKey(
                        CommonAppVarsAndFunctions.License.PcName,
                        applicationName.Replace(CommonConstant.ApplicationName, application),
                        txtSerial.Text,
                        txtKey.Text);

                    MessageBox.Show(CommonAppVarsAndFunctions.LangMessageConstant.XinChucMungBanDangKyThanhCong, CommonConstant.ApplicationName);

                    var licenseDescrypted = EnDeCrypt.DecryptString(txtKey.Text);
                    var licenseValues = licenseDescrypted.Split('_');

                    if (licenseValues != null && licenseValues.Length > 3)
                    {
                        CommonAppVarsAndFunctions.License.FullLicense = false;

                        CommonAppVarsAndFunctions.License.StartDate = DateTimeConverter.ToDateTime(licenseValues[3]);
                        CommonAppVarsAndFunctions.License.EndDate = DateTimeConverter.ToDateTime(licenseValues[4]);
                        CommonAppVarsAndFunctions.License.ChangeLicense = true;
                        var isTrial = NumberConverter.ToInt(licenseValues[2]);
                        if (isTrial == 0)
                        {
                            CommonAppVarsAndFunctions.License.FullLicense = true;
                        }
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show(CommonAppVarsAndFunctions.LangMessageConstant.MaDangKyKhongDung, CommonConstant.ApplicationName);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            f = true;
            //Application.Exit();
        }
        private void CheckLicense()
        {
            var licenseInfo = _systemService.ValidLicense(CommonAppVarsAndFunctions.License.PcName, CommonConstant.ApplicationName, txtSerial.Text.Trim());
            lblStatus.Text = licenseInfo.StatusShortDescription;
            lblTitle.Text = licenseInfo.StatusFullDescription;
        }
    }
}