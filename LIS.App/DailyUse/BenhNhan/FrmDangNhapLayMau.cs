using System;
using System.Windows.Forms;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmDangNhapLayMau : FrmTemplate
    {
        public FrmDangNhapLayMau()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        private void FrmDangNhapLayMau_Load(object sender, EventArgs e)
        {
            objKhuLayMau = _iSysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);

            if (objKhuLayMau.ChonNguoiLayMau)
            {
                ucDangNhapLayMau1.Load_DataKhuLayMau(_iSysConfig.Data_dm_khulaymau(string.Empty, string.Empty));
                ucDangNhapLayMau1.SetMaKhuLayMau = objKhuLayMau.Idkhulaymau;
                ucDangNhapLayMau1.Lock_KhuLayMau = !CommonAppVarsAndFunctions.IsAdmin;
            }
            else
            {
                MessageBox.Show("Khu vực không được cấu hình chọn tay người lấy mẫu.");
                this.DialogResult = DialogResult.Cancel;
                this.BeginInvoke(new MethodInvoker(Close));
            }

        }
    }
}
