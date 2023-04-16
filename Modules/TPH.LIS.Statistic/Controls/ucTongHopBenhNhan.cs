using System;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopBenhNhan : UserControl
    {
        public ucTongHopBenhNhan()
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
                return colTongTienBN.Visible;
            }
            set
            {
                colTongTienBN.Visible = value;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var condit = getCondit();
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....", 8);
            gcKetQua.DataSource = _iStatistic.ThongKeBenhNhanXetNghiem(condit);
            gvKetQua.ExpandAllGroups();
            CustomMessageBox.CloseAlert();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcKetQua, string.Format("SoLuongXetnghiem_BenhNhan_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void ucTongHopBenhNhan_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
