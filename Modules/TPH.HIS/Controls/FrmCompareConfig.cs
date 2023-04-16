using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;

namespace TPH.HIS.Controls
{
    public partial class FrmCompareConfig : Form
    {
        public FrmCompareConfig()
        {
            InitializeComponent();
        }
        public string HISParaList = string.Empty;
        public string LISParaList = string.Empty;
        public void SetLISValue(object dataSource)
        {
            ControlExtension.BindDataToCobobox(dataSource, ref cboLIS, "Key", "Value");
        }
        DataTable data = new DataTable();
        private void SplitString()
        {
            data.Columns.Add("HIS", typeof(string));
            data.Columns.Add("LIS", typeof(string));

            var arrHIS = HISParaList.Split(',');
            var arrLIS = LISParaList.Split(',');
            var max = (arrHIS.Length > arrLIS.Length ? arrHIS.Length : arrLIS.Length);
            for (int i = 0; i < max; i++)
            {
                var dr = data.NewRow();
                if (i < arrHIS.Length)
                    dr["HIS"] = arrHIS[i];
                if(i < arrLIS.Length)
                    dr["LIS"] = arrLIS[i];
                data.Rows.Add(dr);
            }
            dtgList.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            bvList.BindingSource = bs;
            dtgList.DataSource = bs;
        }

        private void FrmCompareConfig_Load(object sender, EventArgs e)
        {
            SplitString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            HISParaList = string.Empty;
            LISParaList = string.Empty;
            if (dtgList.RowCount > 0)
            {
                for (int i = 0; i < dtgList.RowCount; i++)
                {
                    var his = dtgList[colHis.Name, i].Value.ToString().Trim();
                    var lis = dtgList[colLIS.Name, i].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(his))
                    {
                        HISParaList += (string.IsNullOrEmpty(HISParaList) ? "" : ",") + his;
                        if (!string.IsNullOrEmpty(lis))
                            LISParaList += (string.IsNullOrEmpty(LISParaList) ? "" : ",") + lis;
                        else
                            LISParaList += (string.IsNullOrEmpty(LISParaList) ? "" : ",NullValue");
                    }
                }
            }
            this.Close();
        }

        private void dtgList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void cboLIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLIS.Text = (cboLIS.SelectedIndex > -1 ? cboLIS.SelectedValue.ToString() : string.Empty);
        }

        private void btnSetToRow_Click(object sender, EventArgs e)
        {
            if(dtgList.CurrentRow != null)
            {
                dtgList.CurrentRow.Cells[colLIS.Name].Value = txtLIS.Text;
            }
        }
    }
}
