using System;
using System.Windows.Forms;
using TPH.Common.StringCryptography;
using TPH.LIS.Common;

namespace TPH.LIS.App
{
    public partial class FrmRegistryKey : Form
    {
        public FrmRegistryKey()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }
        public string KeyNumber { get; set; }
        public string defaultKey = string.Empty;
        private void FrmRegistryKey_Load(object sender, EventArgs e)
        {
            txtSerial.Text = string.IsNullOrEmpty(defaultKey) ? TPHSerialKeys.GetSerial() : defaultKey;
        }
        bool f = false;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Xin vui lòng nhập mã đăng ký.", MessageConstant.ClinicManagement);
                txtKey.Focus();
            }
            else
            {
                f = TPHSerialKeys.CheckSerial(txtKey.Text);
                if (f)
                {
                    KeyNumber = txtKey.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mã đăng ký không đúng, vui lòng kiểm tra lại.", MessageConstant.ClinicManagement);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            f = true;
            Application.Exit();
        }

        private void FrmRegistryKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!f)
                e.Cancel = true;
        }
    }
}
