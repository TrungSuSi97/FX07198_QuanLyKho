using System;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App
{
    public partial class FrmInputPasswordToReset : Form
    {
        public FrmInputPasswordToReset()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }
        public string Password { get; set; }
        public bool OK { get; set; }
        private void btnReset_Click(object sender, EventArgs e)
        {
            OK = false;
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng nhập mật khẩu mới");
                txtNewPass.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassReset.Text))
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng nhập lại mật khẩu");
                txtPassReset.Focus();
                return;
            }
            if (!txtPassReset.Text.Equals(txtNewPass.Text, StringComparison.OrdinalIgnoreCase))
            {
                CustomMessageBox.MSG_Information_OK("Mật khẩu nhập lại không đúng, vui lòng thử lại");
                txtPassReset.Focus();
                txtPassReset.SelectAll();
                return;
            }
            Password = txtNewPass.Text;
            OK = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OK = true;
            Password = null;
            this.Close();
        }

        private void FrmInputPasswordToReset_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OK)
                e.Cancel = true;
        }

        private void FrmInputPasswordToReset_Load(object sender, EventArgs e)
        {

        }
    }
}
