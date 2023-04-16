using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopXetNghiem : UserControl
    {
        public ucTongHopXetNghiem()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        public bool ShowMoney
        {
            get
            {
                return colTongTien.Visible;
            }
            set
            {
                colTongTien.Visible = value;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var condit = getCondit();
            condit.SumColumns = new List<string> { "SoLuong", "SoLuongHeSo", "TongTien", "TienCong", "BHYT", "ThuPhi" };
            gcXetNghiem.DataSource = _iStatistic.ThongKeXetNghiemThucHien(condit);
            gvXetNghiem.ExpandAllGroups();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcXetNghiem, string.Format("SoLuongXetnghiem_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void ucTongHopXetNghiem_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
