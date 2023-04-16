using System;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class frmMapping_MaMayXN_ViSinh : FrmTemplate
    {
        public frmMapping_MaMayXN_ViSinh()
        {
            InitializeComponent();
        }

        private void frmMapping_MaMayXN_ViSinh_Load(object sender, EventArgs e)
        {
            ucMappingViKhuan1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucMappingViKhuan1.Load_DanhSach_MayXN();
        }
    }
}
