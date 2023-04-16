using System;
using System.Data;
using System.Windows.Forms;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmDSChuyenMauTheoBarcode : FrmTemplate
    {
        public FrmDSChuyenMauTheoBarcode()
        {
            InitializeComponent();
        }
        public DataTable dataChuyenMau;
        public int IDChuyenMau = 0;
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if(dtgDanhSachChuyen.CurrentRow != null)
            {
                IDChuyenMau = int.Parse(dtgDanhSachChuyen.CurrentRow.Cells[colIDChuyenMau.Name].Value.ToString());
                this.Close();
            }
        }

        private void dtgDanhSachChuyen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDanhSachChuyen.CurrentRow != null)
            {
                IDChuyenMau = int.Parse(dtgDanhSachChuyen.CurrentRow.Cells[colIDChuyenMau.Name].Value.ToString());
                this.Close();
            }
        }

        private void FrmDSChuyenMauTheoBarcode_Load(object sender, EventArgs e)
        {
            if(dataChuyenMau != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataChuyenMau;
                bvDanhSach.BindingSource = bs;
                dtgDanhSachChuyen.AutoGenerateColumns = false;
                dtgDanhSachChuyen.DataSource = bs;

            }
        }

        private void FrmDSChuyenMauTheoBarcode_Shown(object sender, EventArgs e)
        {
            btnChon.Focus();
        }
    }
}
