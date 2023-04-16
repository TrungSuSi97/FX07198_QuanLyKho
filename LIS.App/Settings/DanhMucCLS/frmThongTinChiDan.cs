using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmThongTinChiDan : FrmTemplate
    {
        private SqlDataAdapter _daDichVuCls = new SqlDataAdapter();
        DataTable _dtDichVuCls = new DataTable();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();

        public frmThongTinChiDan()
        {
            InitializeComponent();
        }

        private void frmDichVuCLS_Load(object sender, EventArgs e)
        {
            Load_LoaiDichVu();
        }

        private void dtgDichVuCLS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(_daDichVuCls, ref _dtDichVuCls, dtgDichVuCLS, string.Empty, string.Empty);
        }
        private void Load_LoaiDichVu()
        {
            _systemConfigService.GetSubclinical(ref _daDichVuCls, ref _dtDichVuCls, string.Format(" and EnumID in ({0})",CommonAppVarsAndFunctions.ListEnumLoaiDichVu()));
            ControlExtension.BindDataToGrid(_dtDichVuCls, ref dtgDichVuCLS, ref bvDichVuCLS);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_LoaiDichVu();
        }
    }
}
