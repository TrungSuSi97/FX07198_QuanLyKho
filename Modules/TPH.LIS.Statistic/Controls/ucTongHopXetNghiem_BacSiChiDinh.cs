using System;
using System.Data;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopXetNghiem_BacSiChiDinh : UserControl
    {
        public ucTongHopXetNghiem_BacSiChiDinh()
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
                return colTongTienCTBS.Visible;
            }
            set
            {
                colTongTienCTBS.Visible = value;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            TK_XetNghiemBSChiDinh();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcChiDinh, string.Format("SoLuongXetnghiem_BenhNhan_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void TK_XetNghiemBSChiDinh()
        {
            var condit = getCondit();
            var dtTemp = _iStatistic.ThongKeChiTiet_BSThucHien(condit);

            DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp,
                new[] { "NgayTiepNhan", "MaTiepNhan", "TenBN", "BacSiCD", "TenNhanVien", "TuNgay", "DenNgay" });
            dtResult.Columns.Add("TenXN", typeof(string));
            dtResult.Columns.Add("TongTien", typeof(double));
            dtResult.Columns.Add("TienCong", typeof(double));

            double sumTongTien = 0, sumTienCong = 0;
            string matiepNhanMain = string.Empty;
            string matiepNhanDetail = string.Empty;
            string tenXn = string.Empty;

            foreach (DataRow dr in dtResult.Rows)
            {
                tenXn = string.Empty;
                matiepNhanMain = dr["MatiepNhan"].ToString().Trim();

                DataTable dtTempResultDetail = dtTemp.Clone();
                dtTemp.Select("MaTiepNhan = '" + matiepNhanMain + "'").CopyToDataTable(dtTempResultDetail, LoadOption.OverwriteChanges);
                sumTongTien = double.Parse(dtTempResultDetail.Compute("Sum(TongTien)", "").ToString());
                sumTienCong = double.Parse(dtTempResultDetail.Compute("Sum(TienCong)", "").ToString());

                for (int i = 0; i < dtTempResultDetail.Rows.Count; i++)
                {
                    tenXn += (string.IsNullOrEmpty(tenXn) ? dtTempResultDetail.Rows[i]["TenXN"].ToString().Trim() : " | " + dtTempResultDetail.Rows[i]["TenXN"].ToString().Trim());
                }

                dr["TongTien"] = sumTongTien;
                dr["TienCong"] = sumTienCong;
                dr["TenXN"] = tenXn;
                dtResult.AcceptChanges();
            }

            gcChiDinh.DataSource = dtResult;
            gvChiDinh.ExpandAllGroups();
        }

        private void ucTongHopXetNghiem_BacSiChiDinh_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
