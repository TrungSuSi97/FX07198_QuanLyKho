using System;

namespace TPH.LIS.App.Settings.NhanVien
{
    public partial class FrmTaiKhoanNguoiDung : FrmTemplate
    {
        public FrmTaiKhoanNguoiDung()
        {
            InitializeComponent();
        }

        private void FrmTaiKhoanNguoiDung_Load(object sender, EventArgs e)
        {
            ucQuanLyNguoiDung1.UserIdAction = CommonAppVarsAndFunctions.UserID;
            ucQuanLyNguoiDung1.HeThong = "TPH.LabIMS";
            ucQuanLyNguoiDung1.Load_Data();
        }

        private void ucQuanLyNguoiDung1_Load(object sender, EventArgs e)
        {

        }
    }
}
