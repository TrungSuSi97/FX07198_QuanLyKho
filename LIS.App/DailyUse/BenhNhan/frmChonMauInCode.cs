using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class frmChonMauInCode : Form
    {
        public frmChonMauInCode()
        {
            InitializeComponent();
        }
        public DataTable dataReturn;
        public int numberOfCopy = 0;

        public DataTable dataIn = new DataTable();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSLIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachChonMau.RowCount > 0)
            {
                txtSLIn.Focus();
                var dataR = dataIn.AsEnumerable().Where(w => w.Field<bool>("chon")).ToList();
                if (dataR.Any())
                {
                    dataReturn = dataR.CopyToDataTable();
                    numberOfCopy = int.Parse((txtSLIn.Text == "" ? "0" : txtSLIn.Text));
                    this.Close();
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Không có loại mẫu nào được chọn!");
                }
            }
        }

        private void frmChonMauInCode_Load(object sender, EventArgs e)
        {
            dtgDanhSachChonMau.DataSource = dataIn;
            if (dtgDanhSachChonMau.RowCount > 0)
            {
                dtgDanhSachChonMau.CurrentRow.Cells[colChon.Name].Value = true;
                dtgDanhSachChonMau.Focus();
            }
            if (txtSLIn.Enabled)
            {
                txtSLIn.Focus();
                txtSLIn.Select(0, txtSLIn.Text.Length);
            }
            else
                btnDongY.Focus();

        }

        private void txtSLIn_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSLIn.Focus();
                btnDongY_Click(sender, e);
            }
        }

        private void txtSLIn_Click(object sender, EventArgs e)
        {
            txtSLIn.Select(0, txtSLIn.Text.Length);
        }

        private void txtSLIn_Enter(object sender, EventArgs e)
        {
            txtSLIn.Select(0, txtSLIn.Text.Length);
        }

        private void frmChonMauInCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
