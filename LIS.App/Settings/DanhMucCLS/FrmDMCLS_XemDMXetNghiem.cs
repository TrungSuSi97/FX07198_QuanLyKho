using System;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmDMCLS_XemDMXetNghiem : FrmTemplate
    {
        public FrmDMCLS_XemDMXetNghiem()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private void Load_DanhMuc()
        {
            var manhom = string.Empty;
            if (cboMaNhomCLSFilter.SelectedIndex != -1)
            {
                manhom = cboMaNhomCLSFilter.SelectedValue.ToString().Trim();
            }

            var _dtLisCode = _systemConfigService.GetSubclinicalTestAndProfile(null, manhom, string.Empty, string.Empty, false);
            ControlExtension.BindDataToGrid(_dtLisCode, ref dtgXetNghiem, ref bvXetNghiem);
            SearchLISTest();
        }

        private void txtTestNameFilter_TextChanged(object sender, EventArgs e)
        {
            SearchLISTest();
        }
        void SearchLISTest()
        {
            if (bvXetNghiem.BindingSource != null)
            {
                bvXetNghiem.BindingSource.Filter = string.Format("maxn like '%{0}%' or tenxn like '%{0}%'", WorkingServices.EscapeLikeValue(txtTestNameFilter.Text));
            }
        }

        private void FrmDMCLS_XemDMXetNghiem_Load(object sender, EventArgs e)
        {
            cboMaNhomCLSFilter.SelectedIndexChanged -= cboMaNhomCLSFilter_SelectedIndexChanged;
            ControlExtension.BindDataToCobobox(_systemConfigService.GetTestGroup(string.Empty), ref cboMaNhomCLSFilter,
                       "MaNhomCLS", "TenNhomCLS");
            cboMaNhomCLSFilter.SelectedIndexChanged += cboMaNhomCLSFilter_SelectedIndexChanged;
            Load_DanhMuc();
        }

        private void cboMaNhomCLSFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DanhMuc();
        }
    }
}
