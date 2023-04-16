using System;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmBanLayMau : FrmTemplate
    {
        public FrmBanLayMau()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        private void FrmBanLayMau_Load(object sender, EventArgs e)
        {
            
            objKhuLayMau = _iSysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);
            if (objKhuLayMau.Idkhulaymau == null)
            {
                CustomMessageBox.MSG_Information_OK("Máy tính chưa khai báo khu lấy mẫu");
            }
            else
            {
                ucKiemSoatDangNhapLayMau1.Load_DataKhuLayMau(_iSysConfig.Data_dm_khulaymau(string.Empty, string.Empty));
                ucKiemSoatDangNhapLayMau1.SetMaKhuLayMau = objKhuLayMau.Idkhulaymau;
                ucKiemSoatDangNhapLayMau1.Lock_KhuLayMau = !CommonAppVarsAndFunctions.IsAdmin;
            }
        }
    }
}
