using System;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmThongTinSangLocTruocSinh : FrmTemplate
    {
        public FrmThongTinSangLocTruocSinh()
        {
            InitializeComponent();
        }

        private void FrmThongTinSangLocTruocSinh_Load(object sender, EventArgs e)
        {
            ucThongTinSangLocTruocSinh1.Load_Config();
        }
    }
}
