using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmDichVuCLS : FrmTemplate
    {
        readonly SqlDataAdapter _daDichVuCls = new SqlDataAdapter();
        DataTable _dtDichVuCls = new DataTable();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();

        public frmDichVuCLS()
        {
            InitializeComponent();
        }

        private void frmDichVuCLS_Load(object sender, EventArgs e)
        {
            var subclinical = _systemConfigService.GetSubclinical(string.Empty);
            ControlExtension.BindDataToGrid(subclinical, ref dtgDichVuCLS, ref bvDichVuCLS);
        }

        private void dtgDichVuCLS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(_daDichVuCls, ref _dtDichVuCls, dtgDichVuCLS, string.Empty, string.Empty);
        }
    }
}
