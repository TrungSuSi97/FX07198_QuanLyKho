using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucDashBoard : UserControl
    {
        public ucDashBoard()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        public DateTime serverDate
        {
            set { dtpNgayManual.Value = value; CurrentDate = value; }
        }
        private DateTime CurrentDate = DateTime.Now;
        public List<string> lstBoPhanAllow = new List<string>();
        List<ucDashBoard_Department> lstDepartment;
        public void Load_ThongTinDangLuoi()
        {
            var date = (radloadAutomatic.Checked ? CurrentDate.Date : dtpNgayManual.Value.Date);
            var data = _iStatistic.DashBoard_TongHopmauTheoBoPhan(date, date, lstBoPhanAllow);
            if (data != null)
            {
                if (data.Rows.Count > 0)
                {
                    if (lstDepartment == null)
                        lstDepartment = new List<ucDashBoard_Department>();
                    foreach (DataRow drBoPhan in data.Rows)
                    {
                        var maBophan = drBoPhan["BoPhan"].ToString().Trim();
                        var tenBoPhan = drBoPhan["TenBoPhan"].ToString().Trim();
                        var lstUc = lstDepartment.Where(x => x.MaBoPhan.Equals(maBophan));
                        ucDashBoard_Department uc;
                        if(lstUc.Any())
                        {
                            uc = lstUc.First();
                            uc.TenBoPhan = tenBoPhan;
                            uc.SetDataSource = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("BoPhan = '{0}'", maBophan));
                        }
                        else
                        {
                            uc = new ucDashBoard_Department();
                            uc.LeftMode = false;
                            uc.MaBoPhan = maBophan;
                            uc.SetDataSource = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("BoPhan = '{0}'", maBophan));
                            uc.TenBoPhan = tenBoPhan;
                            lstDepartment.Add(uc);
                            tabXemTheoDanhSach.Controls.Add(uc);
                            uc.BringToFront();
                            uc.Dock = DockStyle.Top;
                        }

                    }
                }
            }
        }
        public void StartTimer()
        {
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
            if(radloadAutomatic.Checked)
            {
                dtpNgayManual.Value = CurrentDate;
            }
            lblTime.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", CurrentDate);
        }

        private void timerReLoad_Tick(object sender, EventArgs e)
        {
            Load_ThongTinDangLuoi();
        }

        private void radLoadmanual_CheckedChanged(object sender, EventArgs e)
        {
            dtpNgayManual.Enabled = btnLamMoiDS.Enabled = radLoadmanual.Checked;
        }

        private void btnLamMoiDS_Click(object sender, EventArgs e)
        {
            Load_ThongTinDangLuoi(); ;
        }

        private void ucDashBoard_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
