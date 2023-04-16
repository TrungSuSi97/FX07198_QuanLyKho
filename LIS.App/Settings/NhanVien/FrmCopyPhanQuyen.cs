using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.Settings.NhanVien
{
    public partial class FrmCopyPhanQuyen : Form
    {
        public FrmCopyPhanQuyen()
        {
            InitializeComponent();
        }
        private readonly IUserManagementService _userService = new UserManagementService();
        private void Load_DSTaiKhoan()
        {
            var datUser =from sdata in _userService.Data_ql_nguoidung(string.Empty).AsEnumerable()
                               where !sdata["MaNguoiDung"].ToString().Equals("admin")
                               select sdata ;
            cboFromUser.DataSource = datUser.AsDataView().ToTable().Copy();
            cboFromUser.ValueMember = "MaNguoiDung";
            cboFromUser.DisplayMember = "TenNhanVien";
            cboFromUser.SelectedIndex = -1;

            cboToUser.DataSource = datUser.AsDataView().ToTable().Copy();
            cboToUser.ValueMember = "MaNguoiDung";
            cboToUser.DisplayMember = "TenNhanVien";
            cboToUser.SelectedIndex = -1;

        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cboFromUser.SelectedIndex > -1 && cboToUser.SelectedIndex > -1)
            {
                if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes(string.Format("Sao chép phân quyền từ: {0} \n đến: {1} ?", cboFromUser.SelectedValue.ToString(), cboToUser.SelectedValue.ToString())))
                {
                    if (_userService.CopyPermissioin(cboFromUser.SelectedValue.ToString(), cboToUser.SelectedValue.ToString()))
                        CustomMessageBox.MSG_Information_OK("Sao chép hoàn tất!");
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọ đủ thông tin!");
        }
        private void FrmCopyPhanQuyen_Load(object sender, EventArgs e)
        {
            Load_DSTaiKhoan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
