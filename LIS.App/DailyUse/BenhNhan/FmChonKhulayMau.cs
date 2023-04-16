using System;
using System.Data;
using System.Linq;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FmChonKhulayMau : FrmTemplate
    {
        public FmChonKhulayMau()
        {
            InitializeComponent();
        }
        public string IDKhuLayMau = string.Empty;
        public string TenKhuLayMau = string.Empty;
        public string userId = string.Empty;
        private readonly ISystemConfigService _sysConfig = new SystemConfigService();
        private readonly IUserManagementService _userManagement = new UserManagementService();
        private bool Load_DanhSachKhuLayMau(string[] arrDataAllow)
        {
            var data = _sysConfig.Data_dm_khulaymau(string.Empty, CommonAppVarsAndFunctions.PCWorkPlace);
            if (arrDataAllow != null)
            {
                var selectData = data.AsEnumerable().Where(x => arrDataAllow.Contains(x["IDKhuLayMau"].ToString()));
                if (selectData.Any())
                {
                    cbKhuLayMau.DataSource = selectData.CopyToDataTable();
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Khu vực lấy mẫu của tài khoản không tồn tại!");
                    return false;
                }
            }
            else
                cbKhuLayMau.DataSource = data;
            cbKhuLayMau.ValueMember = "IDKhuLayMau";
            cbKhuLayMau.DisplayMember = "TenKhuLayMau";
            return true;
        }

        private void FmChonKhulayMau_Load(object sender, EventArgs e)
        {
            Check_SetKhuLayMau();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check_GetKhuLayMau();
        }
        private void Check_GetKhuLayMau()
        {
            if (cbKhuLayMau.SelectedIndex > -1)
            {
                IDKhuLayMau = cbKhuLayMau.SelectedValue.ToString();
                TenKhuLayMau = cbKhuLayMau.Text;
                this.Close();
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn khu lấy mẫu!");
        }
        private void Check_SetKhuLayMau()
        {
            if (!CommonAppVarsAndFunctions.IsAdmin)
            {
                var data = _userManagement.Get_Info_ql_nguoidung(userId);
                var khlayMauPhanQuyen = data.Idkhulaymau.Trim().Split(new string[] { "|", "-1" }, StringSplitOptions.RemoveEmptyEntries);
                if (khlayMauPhanQuyen.Length > 0)
                {
                    if (khlayMauPhanQuyen.Length == 1)
                    {
                        if (!string.IsNullOrEmpty(khlayMauPhanQuyen[0]))
                        {
                            if (Load_DanhSachKhuLayMau(khlayMauPhanQuyen))
                            {
                                cbKhuLayMau.SelectedValue = int.Parse(khlayMauPhanQuyen[0].Trim());
                                Check_GetKhuLayMau();
                            }
                            else
                                this.Close();
                        }
                        else
                        {
                           // CustomMessageBox.MSG_Information_OK("Tài khoản chưa được khai báo khu vực lấy mẫu!");
                            this.Close();
                        }
                    }
                    else
                    {
                        Load_DanhSachKhuLayMau(khlayMauPhanQuyen);
                        cbKhuLayMau.SelectedIndex = 0;
                    }
                }
                else
                {
                   // CustomMessageBox.MSG_Information_OK("Tài khoản chưa được khai báo khu vực lấy mẫu!");
                    this.Close();
                }
            }
            else
                Load_DanhSachKhuLayMau(null);
        }

        private void FmChonKhulayMau_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            FormEscape(sender, e);
        }
    }
}
