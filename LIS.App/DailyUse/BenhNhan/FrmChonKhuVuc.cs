using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChonKhuVuc : FrmTemplate
    {
        public FrmChonKhuVuc()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _sysConfig = new SystemConfigService();
        private void Load_KhuVuc()
        {
            var data = _sysConfig.Data_dm_khuvuc(string.Empty);
            cboKhuNha.DataSource = data;
            cboKhuNha.ValueMember = "MaKhuVuc";
            cboKhuNha.DisplayMember = "TenKhuVuc";
            cboKhuNha.SelectedIndex = -1;
        }
        public string IdKhuNhan { get; set; }
        private void FrmChonKhuVuc_Load(object sender, EventArgs e)
        {
            Load_KhuVuc();
            if (!string.IsNullOrEmpty(IdKhuNhan))
                cboKhuNha.SelectedValue = IdKhuNhan;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (cboKhuNha.SelectedIndex > -1)
            {
                IdKhuNhan = cboKhuNha.SelectedValue.ToString();
                if(IdKhuNhan.Equals(CommonAppVarsAndFunctions.PCWorkPlace, StringComparison.OrdinalIgnoreCase))
                {
                    CustomMessageBox.MSG_Information_OK("Nơi nhận phải khác khu vực đang làm việc.");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn khu vực nhận.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            IdKhuNhan = String.Empty;
            this.Close();
        }
    }
}
