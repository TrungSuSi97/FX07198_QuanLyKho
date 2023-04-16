using System;
using System.Linq;
using System.Windows.Forms;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmDashBoardTAT_Chart : FrmTemplate
    {
        public FrmDashBoardTAT_Chart()
        {
            InitializeComponent();
        }
        private string MaBoPhan = string.Empty;
        private void FrmDashBoardTAT_Load(object sender, EventArgs e)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemTATDashboardTheoBoPhan)
            {
                if (CommonAppVarsAndFunctions.BoPhanClsXetNghiem.Count() == 1)
                {
                    MaBoPhan = CommonAppVarsAndFunctions.BoPhanClsXetNghiem[0];
                    lblTitle.Text += " - " + MaBoPhan;
                }
                else
                {
                    var f = new FrmChonKhoa();
                    f.ShowDialog();
                    if (!string.IsNullOrEmpty(f.BoPhan))
                    {
                        MaBoPhan = f.BoPhan;
                        lblTitle.Text += " - " + MaBoPhan;
                    }
                    else
                        this.Close();
                }
            }
        }

        private void FrmDashBoardTAT_Shown(object sender, EventArgs e)
        {
            ucDashBoard_DepartmentWithTAT1.Load_Config();
            ucDashBoard_DepartmentWithTAT1.BoPhan = MaBoPhan;
            ucDashBoard_DepartmentWithTAT1.serverDate = CommonAppVarsAndFunctions.ServerTime;
            ucDashBoard_DepartmentWithTAT1.StartTimerTime();
            ucDashBoard_DepartmentWithTAT1.StartTimer();
            ucDashBoard_DepartmentWithTAT1.Load_ThongTin();
        }

        private void FrmDashBoardTAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDashBoard_DepartmentWithTAT1.StopTimerTime();
            ucDashBoard_DepartmentWithTAT1.StopTimer();
        }

        private void FrmDashBoardTAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                if (this.FormBorderStyle != FormBorderStyle.None)
                {
                  
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Normal;
                    this.WindowState = FormWindowState.Maximized;
                    lblMainESC.Visible = false;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                    lblMainESC.Visible = true;
                }
            }
        }
    }
}
