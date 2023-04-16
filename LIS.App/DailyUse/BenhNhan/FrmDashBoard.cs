using System;
using System.Linq;
using System.Windows.Forms;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmDashBoard : FrmTemplate
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }

        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            ucDashBoard1.lstBoPhanAllow = CommonAppVarsAndFunctions.BoPhanClsXetNghiem.ToList();
            ucDashBoard1.serverDate = CommonAppVarsAndFunctions.ServerTime;
            ucDashBoard1.StartTimerTime();
            ucDashBoard1.Load_ThongTinDangLuoi();
            ucDashBoard1.StartTimer();
        }

        private void FrmDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDashBoard1.StopTimerTime();
            ucDashBoard1.StopTimer();
        }

        private void FrmDashBoard_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F11)
            {
                if (this.FormBorderStyle != FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    lblMainESC.Visible = false;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Maximized;
                    lblMainESC.Visible = true;
                }
            }
            
        }
    }
}
