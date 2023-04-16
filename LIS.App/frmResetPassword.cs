using System;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmResetPassword : FrmTemplate
    {
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        C_NguoiDung nguoidung = new C_NguoiDung();
        public frmResetPassword()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        private void LoadUser(string _filter)
        {
            nguoidung.Get_UserList(cboUser, (string.IsNullOrEmpty(_filter) ? "" : " and MaNguoiDung = '" + _filter + "'"));
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            if (CommonAppVarsAndFunctions.IsAdmin)
            {
                LoadUser("");
                cboUser.Visible = true;
                lblUser.Visible = true;
                lblReset.Visible = true;
                btnReset.Visible = true;
                txtPassReset.Visible = true;
                lblUser.Visible = true;
                cboUser.Focus();
            }
            else
            {
                //LoadUser(CommonAppVarsAndFunctions.UserID.Trim());
                //cboUser.SelectedValue = CommonAppVarsAndFunctions.UserID.Trim();
                txtOldPass.Focus();
            }
        }

        private void cboUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtOldPass);
        }

        private void txtOldPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtNewPass);
        }

        private void txtNewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnSave);
        }

        private void txtPassReset_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnReset);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (cboUser.SelectedIndex != -1)
            {
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
                    return;
                }
                if (nguoidung.Reset_Password(cboUser.SelectedValue.ToString().Trim(), txtPassReset.Text))
                {
                    CustomMessageBox.MSG_Information_OK("Tạo mật khẩu mới thành công");
                    txtOldPass.Text = txtNewPass.Text = txtPassReset.Text = "";
                    cboUser.Focus();
                }
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Hãy chọn user cần tạo mật khẩu!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (cboUser.Visible)
            //{
            //    if (cboUser.SelectedIndex == -1)
            //    {
            //        CustomMessageBox.MSG_Information_OK("Vui lòng chọn user");
            //        cboUser.Focus();
            //        return;
            //    }
            //}
            if (string.IsNullOrEmpty(txtOldPass.Text))
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng nhập mật khẩu cũ");
                txtOldPass.Focus();
                return;
            }
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
                return;
            }
            string _userid = "";
            //if (cboUser.Visible)
            //    _userid = cboUser.SelectedValue.ToString();
            //else
                _userid = CommonAppVarsAndFunctions.UserID;

            if (!nguoidung.Check_Login(_userid, txtOldPass.Text))
            {
                CustomMessageBox.MSG_Information_OK("Mật khẩu cũ không hợp lệ, vui lòng kiểm tra lại");
                txtOldPass.Focus();
                return;
            }

            if (nguoidung.Update_Password(_userid, txtOldPass.Text, txtNewPass.Text))
            {
                CustomMessageBox.MSG_Information_OK("Đổi mật khẩu mới thành công");
                txtOldPass.Text = txtNewPass.Text = txtPassReset.Text = "";
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Đổi mật khẩu không thành công!\nVui lòng thử lại");
            }
        }

        private void ucGroupHeaderChonMain_MouseDown(object sender, MouseEventArgs e)
        {
            pnMenu_MouseDown(sender, e);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            pnMenu_MouseDown(sender, e);
        }
    }
}
