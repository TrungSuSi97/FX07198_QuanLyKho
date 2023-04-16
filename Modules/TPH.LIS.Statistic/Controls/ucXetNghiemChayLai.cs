using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.Excel;
using TPH.Language;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucXetNghiemChayLai : UserControl
    {
        public ucXetNghiemChayLai()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           ExportToExcel.Export(gcXetnghiemChayLai, string.Format("XetNghiemChayLai_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }
        private void TK_XetNghiemMay_ChayLai()
        {
            var condit = getCondit();
            var dtTemp = _iStatistic.ThongKeXetNghiemMay_ChayLay(condit);
            XuLyTimChayLai(dtTemp);
        }
        private void XuLyTimChayLai(DataTable dtTemp)
        {
            var dtResult = dtTemp.Clone();
            if (dtTemp.Rows.Count > 0)
            {
                progressBar1.Maximum = dtTemp.Rows.Count;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                //Xử lý trùng
                //Dự vào RunKey của select và kết quả để so sánh
                //1. Lấy danh sách key
                var dataDistinct = dtTemp.DefaultView.ToTable(true, "RunKey");
                var runKey = string.Empty;
                for (int i = 0; i < dataDistinct.Rows.Count; i++)
                {
                    progressBar1.Value++;
                    runKey = dataDistinct.Rows[0]["RunKey"].ToString().Trim();
                    var dataSelectted = dtTemp.AsEnumerable().Where(x => x["RunKey"].ToString().Trim().Equals(runKey)).ToList().CopyToDataTable();
                    if (dataSelectted.Rows.Count > 1)
                    {
                        dataSelectted.Rows[0]["ketqua"] = (dataSelectted.Rows.Count - 1).ToString();
                        dtResult.ImportRow(dataSelectted.Rows[0]);
                        dtResult.AcceptChanges();
                    }
                }
            }
            gcXetnghiemChayLai.DataSource = dtResult;
            gvXetnghiemChayLai.ExpandAllGroups();
            progressBar1.Visible = false;
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Action action = () => TK_XetNghiemMay_ChayLai();
            progressBar1.Invoke(action);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void ucXetNghiemChayLai_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
