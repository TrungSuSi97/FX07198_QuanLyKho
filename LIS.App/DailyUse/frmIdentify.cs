using System;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThucThi
{
    public partial class frmIdentify : FrmTemplate
    {
        public frmIdentify()
        {
            InitializeComponent();
        }
        private string _UserID = "";

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _UserName = "";

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public bool Accepted = false;
        C_NguoiDung nguoidung = new C_NguoiDung();
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            CheckAcount();
        }
        private void CheckAcount()
        {
            bool _admin = false;
            string _NhomIn = "";
            if (nguoidung.Check_Login(txtUserID.Text.Trim(), txtPassword.Text, ref _UserName, ref _NhomIn, ref _admin))
            {
                _UserID = txtUserID.Text.Trim();
                Accepted = true;
                this.Close();
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Thông tin xác nhận không đúng!");
            }
        }
        private void frmIdentify_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_UserID))
            {
                txtUserID.Text = _UserID;
                txtUserID.Enabled = false;
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtUserID.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                    CheckAcount();
            }
        }

        private void frmIdentify_Shown(object sender, EventArgs e)
        {
            if (!txtUserID.Enabled)
                txtPassword.Focus();
        }
    }
}
