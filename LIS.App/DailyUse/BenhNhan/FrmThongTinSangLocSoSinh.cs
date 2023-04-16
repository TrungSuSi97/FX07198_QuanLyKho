using System;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmThongTinSangLocSoSinh : FrmTemplate
    {
        public FrmThongTinSangLocSoSinh()
        {
            InitializeComponent();
        }

        private void FrmThongTinSangLocSoSinh_Load(object sender, EventArgs e)
        {
            ucThongTinSangLoc_SoSinh1.Load_Config();
        }
    }
}
