using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopXetNghiemTuMay : UserControl
    {
        public ucTongHopXetNghiemTuMay()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var condit = getCondit();
            condit.SumColumns = new List<string> { "SoLuong" };
            gcXetNghiemMay.DataSource = _iStatistic.ThongKeXetNghiemMay(condit);
            gvXetNghiemMay.ExpandAllGroups();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcXetNghiemMay, string.Format("SoLuongXetnghiem_May_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void ucTongHopXetNghiemTuMay_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
