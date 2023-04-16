using System;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChonKhoa : Form
    {
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        public FrmChonKhoa()
        {
            InitializeComponent();
        }
        public string BoPhan = string.Empty;
        private void FrmChonKhoa_Load(object sender, EventArgs e)
        {
            var dataKhoa = _isSysConfig.Data_dm_xetnghiem_bophan(Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true));
            cboKhoaXetNghiem.DataSource = dataKhoa;
            cboKhoaXetNghiem.ValueMember = "MaBoPhan";
            cboKhoaXetNghiem.DisplayMember = "TenBoPhan";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboKhoaXetNghiem.SelectedIndex > -1)
            {
                BoPhan = cboKhoaXetNghiem.SelectedValue.ToString().Trim();
                this.Close();
            }
            else
                MessageBox.Show("Hãy chọn khoa.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            BoPhan = string.Empty;
            this.Close();
        }
    }
}
