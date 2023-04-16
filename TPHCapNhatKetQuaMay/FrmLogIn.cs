using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Models;
using TPH.LIS.User.Services.Authorization;
using TPH.LIS.User.Services.UserManagement;

namespace TPHCapNhatKetQuaMay
{
    public partial class FrmLogIn : Form
    {
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly IAuthorizationService _authorizationService = new AuthorizationService();
        private readonly IUserManagementService _userManagementService = new UserManagementService();
        public UserInfo userLogInInfo ;
        public bool callFromAuto = false;
        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            CheckAndLogIn();
        }
        public void CheckAndLogIn()
        {
            if (!callFromAuto)
            {
                var isValid = _authorizationService.CheckLogin(new TPH.LIS.User.Models.Params.LoginParams { Username = txtUserID.Text, Password = txtPassword.Text, System  = "TPH.LabIMS", Ip = IpExtension.Ip() });
                if (!isValid)
                {
                    CustomMessageBox.MSG_Waring_OK(UserErrorConstant.WrongLoginuserOrPassword);
                    return;
                }
            }
            
            userLogInInfo = _userManagementService.GetUserInfoByLoginName(txtUserID.Text);
            var analyzerePermission =
             _authorizationService.GetUserAnalyzer(
                 userLogInInfo.LoginName);
            FrmAnalyerResult.PhanQuyenMayXetNghiem = analyzerePermission.Select(x => x.Maphanquyen).ToArray();
            if (FrmAnalyerResult.PhanQuyenMayXetNghiem.Length > 0 || userLogInInfo.IsAdmin)
            {
                this.Close();
            }
            else 
            {
                CustomMessageBox.MSG_Information_OK("Tài khoản chưa được cấp quyền máy xét nghiệm!");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtPassword);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnLogIn);
        }

        private void FrmLogIn_Shown(object sender, EventArgs e)
        {
            txtUserID.Focus();
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            var password = _registryExtension.ReadRegistry(UserConstant.RegistryUserPasswordKQMay);
            password = !string.IsNullOrWhiteSpace(password)
                ? TPH.Common.StringCryptography.EnDeCrypt.DecryptString(password, AuthorizationConstant.Clinic)
                : string.Empty;

            txtUserID.Text = _registryExtension.ReadRegistry(UserConstant.RegistryLoginUsernameKQMay);
            txtPassword.Text = password;
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(txtUserID.Text))
                CheckAndLogIn();
        }
    }
}
