using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucDashBoard_DepartmentWithTAT_Chart : UserControl
    {
        private readonly IStatisticService _iStatistic = new StatisticService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        public bool XemTATTheoBoPhan = false;
        public ucDashBoard_DepartmentWithTAT_Chart()
        {
            InitializeComponent();
        }
        private DateTime CurrentDate = DateTime.Now;
        public string BoPhan = string.Empty;
        
        public DateTime serverDate
        {
            set {CurrentDate = value; }
        }
        public void StartTimer()
        {
            timerReLoad.Tick += timerReLoad_Tick;
            timerReLoad.Enabled = true;
            timerReLoad.Start();
        }
        public void StopTimer()
        {
            timerReLoad.Stop();
            timerReLoad.Enabled = false;
        }
        public void StartTimerTime()
        {
            timerCount.Tick += timerCount_Tick;
            timerCount.Enabled = true;
            timerCount.Start();
        }
        public void StopTimerTime()
        {
            timerCount.Enabled = true;
            timerCount.Start();
        }
        private void timerCount_Tick(object sender, EventArgs e)
        {
            CurrentDate = CurrentDate.AddSeconds(1);
            lblTimer.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", CurrentDate);
        }
        private void timerReLoad_Tick(object sender, EventArgs e)
        {
            Load_ThongTin();
        }
        public void Load_Config()
        {
            var data = _isSysConfig.Data_dm_khuvuc(string.Empty);
            cboKhuVuc.DataSource = data;
            cboKhuVuc.DisplayMember = "TenKhuVuc";
            cboKhuVuc.ValueMember = "MaKhuVuc";
            cboKhuVuc.SelectedIndex = 0;
            cboKhuVuc.SelectedIndexChanged += CboKhuVuc_SelectedIndexChanged;
        }

        private void CboKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ThongTinTAT();
        }

        public void Load_ThongTin()
        {
            ucDashBoard_Department_Chart1.SetDataSource = null;
            if (XemTATTheoBoPhan)
            {
                var data = _iStatistic.DashBoard_TongHopmauTheoBoPhan(CurrentDate.Date, CurrentDate.Date, new List<string> { BoPhan });
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {

                        var maBophan = data.Rows[0]["BoPhan"].ToString().Trim();
                        var tenBoPhan = data.Rows[0]["TenBoPhan"].ToString().Trim();
                        ucDashBoard_Department_Chart1.TenBoPhan = tenBoPhan;
                        ucDashBoard_Department_Chart1.MaBoPhan = maBophan;
                        ucDashBoard_Department_Chart1.SetDataSource = data;

                    }
                }
            }
            else
            {
                var data = _iStatistic.DashBoard_TongHopmauTheoBenhNhan(CurrentDate.Date, CurrentDate.Date);
                var maBophan = "All";
                var tenBoPhan = "Tất cả";
                ucDashBoard_Department_Chart1.TenBoPhan = tenBoPhan;
                ucDashBoard_Department_Chart1.MaBoPhan = maBophan;
                ucDashBoard_Department_Chart1.SetDataSource = data;
            }
            Load_ThongTinTAT();
            btnRefresh.Focus();
        }
        private void Load_ThongTinTAT()
        {
            var maKhuVuc = (cboKhuVuc.SelectedIndex > -1 ? cboKhuVuc.SelectedValue.ToString() : string.Empty);
            if (!string.IsNullOrEmpty(maKhuVuc))
            {
                if (XemTATTheoBoPhan)
                {
                    //load danh sách TAT
                    var dataTAT = _iStatistic.DashBoard_DanhSachTAT(CurrentDate.Date, new List<string> { BoPhan }, new List<string> { maKhuVuc });
                    ucDashBoard_TAT1.SetDataSource = dataTAT;
                }
                else
                {
                    //load danh sách TAT theo bệnh nhân
                    var dataTATBN = _iStatistic.DashBoard_DanhSachTAT_BenhNhan(CurrentDate.Date, new List<string> { maKhuVuc });
                    ucDashBoard_TAT1.SetDataSource = dataTATBN;
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_ThongTin();
        }

        private void ucDashBoard_DepartmentWithTAT_Chart_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
