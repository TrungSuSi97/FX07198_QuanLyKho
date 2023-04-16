using System;
using System.Data;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls.CustomMsgBox
{
    public partial class FrmShowRawData : Form
    {
        private DataTable data = null;

        public FrmShowRawData()
        {
            InitializeComponent();
        }

        public DataTable ShowData
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
                ClearAllColumn();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = data;
            }
        }
        private void ClearAllColumn()
        {
            if (dataGridView1.ColumnCount > 0)
            {
                for (int i = dataGridView1.ColumnCount; i > 0; i--)
                {
                    dataGridView1.Columns.RemoveAt(i-1);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.ShowDialog();
            if (diag.FileName != null)
            {
                data.TableName = "RawData";
                data.WriteXml(diag.FileName);
                this.Close();
            }
        }
    }
}
