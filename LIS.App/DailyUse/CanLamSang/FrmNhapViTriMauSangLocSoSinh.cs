using System;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmNhapViTriMauSangLocSoSinh : FrmTemplate
    {
        public FrmNhapViTriMauSangLocSoSinh()
        {
            InitializeComponent();
        }

        private void FrmNhapViTriMauSangLocSoSinh_Load(object sender, EventArgs e)
        {
            ucSamplePosition1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucSamplePosition1.Load_CauHinh();
        }
    }
}
