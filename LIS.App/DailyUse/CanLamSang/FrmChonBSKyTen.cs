using System;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmChonBSKyTen : Form
    {
        public FrmChonBSKyTen()
        {
            InitializeComponent();
        }
        public string NguoiKyTen = string.Empty;
        public bool DoiChieuSHPT = false;
        private void FrmChonBSKyTen_Load(object sender, EventArgs e)
        {
            //Load user ký tên
            IUserManagementService userManagement = new UserManagementService();
            var dataKyten = userManagement.GetUsersKyTenCoPhanQuyen("", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), DoiChieuSHPT);
            ControlExtension.BindDataToCobobox(dataKyten, ref cboNguoiKyTen, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150", txtNguoiKyTen, 1);
        }

        private void btnCapNhatMayXn_Click(object sender, EventArgs e)
        {
            if(cboNguoiKyTen.SelectedIndex >-1)
            {
                NguoiKyTen = cboNguoiKyTen.SelectedValue.ToString();
                Close();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên");
                cboNguoiKyTen.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NguoiKyTen = string.Empty;
            Close();
        }
    }
}
