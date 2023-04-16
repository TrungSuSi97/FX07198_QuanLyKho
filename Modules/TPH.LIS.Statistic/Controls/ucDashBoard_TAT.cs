using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucDashBoard_TAT : UserControl
    {
        public ucDashBoard_TAT()
        {
            InitializeComponent();
            dtgChoXuLy.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Bold);
            dtgChoXuLy.DefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Regular);
            dtgDangXuLy.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Bold);
            dtgDangXuLy.DefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Regular);
        }

        private DataTable dataSource = new DataTable();
        public DataTable SetDataSource
        {
            set { dataSource = value; SetDatatoGrid(); }
        }

        private void SetDatatoGrid()
        {
            dtgChoXuLy.AutoGenerateColumns = false;
            dtgDangXuLy.AutoGenerateColumns = false;
            dtgChoXuLy.DataSource = null;
            dtgDangXuLy.DataSource = null;
            gbChoXuLy.Text = "DANH SÁCH CHỜ XỬ LÝ";
            gbDangXuLy.Text = "DANH SÁCH ĐANG XỬ LÝ";
            if (dataSource != null)
            {
                var dataChoXuLy = WorkingServices.SearchResult_OnDatatable_NoneSort(dataSource, "DangXuLy = false");
                var dataDangXuLy = WorkingServices.SearchResult_OnDatatable_NoneSort(dataSource, "DangXuLy = true");
                if(dataChoXuLy.Rows.Count >0)
                {
                    dataChoXuLy.DefaultView.Sort = "TGThucHien asc, TAT desc";
                    dataChoXuLy = dataChoXuLy.DefaultView.ToTable();
                    dtgChoXuLy.DataSource = dataChoXuLy;
                    gbChoXuLy.Text = string.Format("DANH SÁCH CHỜ XỬ LÝ  - {0}", dtgChoXuLy.RowCount);
                    SetColorAlert(dtgChoXuLy, colChoXuLy_MauCanhBao.Name, colChoXuLy_TAT.Name);
                }

                if (dataDangXuLy.Rows.Count > 0)
                {
                    dataDangXuLy.DefaultView.Sort = "TGThucHien asc, TAT desc";
                    dataDangXuLy = dataDangXuLy.DefaultView.ToTable();
                    dtgDangXuLy.DataSource = dataDangXuLy;
                    gbDangXuLy.Text = string.Format("DANH SÁCH ĐANG XỬ LÝ  - {0}", dtgDangXuLy.RowCount);
                    SetColorAlert(dtgDangXuLy, colDangXuLy_MauCanhBao.Name, colDangXuLy_TAT.Name);
                }
            }
        }
        private void SetColorAlert(DataGridView dtg, string colName, string colSetColor)
        {
            if(dtg.RowCount>0)
            {
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    var colorCode = dtg[colName, i].Value.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (colorCode.Length == 3)
                    {
                        var color = Color.FromArgb(int.Parse(colorCode[0].Trim()), int.Parse(colorCode[1].Trim()), int.Parse(colorCode[2].Trim()));
                        dtg[colSetColor, i].Style.BackColor = color;
                    }
                }
            }
        }

        private void btnExportChoXuLy_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgChoXuLy);
        }

        private void btnExportDangXuLy_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgDangXuLy);
        }

        private void ucDashBoard_TAT_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
