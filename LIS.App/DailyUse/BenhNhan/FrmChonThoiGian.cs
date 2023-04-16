using System;
using System.Windows.Forms;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChonThoiGian : Form
    {
        public FrmChonThoiGian()
        {
            InitializeComponent();
        }
        public DateTime? NgayChon;

        private void btnDongY_Click(object sender, EventArgs e)
        {
            NgayChon = dtpTG.Value;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Hủy chọn ngày?", "Chọn ngày", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
