using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChonLoaiMauLuu : FrmTemplate
    {
        public FrmChonLoaiMauLuu()
        {
            InitializeComponent();
        }
        public DataTable SetDataSource
        {
            set
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = value;   
            }
        }
        public string MaLoaiChinh = string.Empty;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                MaLoaiChinh = dataGridView1.CurrentRow.Cells[colMaLoaiMauChinh.Name].Value.ToString();
                this.Close();
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn loại mẫu lưu.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChonLoaiMauLuu_Load(object sender, EventArgs e)
        {

        }
    }
}
