using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucKhamBenh
{
    public partial class FrmDanhMucChanDoan : FrmTemplate
    {
        public FrmDanhMucChanDoan()
        {
            InitializeComponent();
        }
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        SqlDataAdapter daChanDoan = new SqlDataAdapter();
        DataTable dtChanDoan = new DataTable();
        
        private void Load_ChanDoan(string _filter)
        {
            data.Get_ChanDoan(daChanDoan, dtgChanDoan, bvChanDoan, _filter, ref dtChanDoan);
        }
        private void btnAddChanDoan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtChanDoan.Text))
            {
                data.Add_ChanDoan(txtMaChanDoan.Text, txtChanDoan.Text);
                txtChanDoan.Text = string.Empty;
                txtMaChanDoan.Text = string.Empty;
                txtMaChanDoan.Focus();
                Load_ChanDoan(string.Empty);
            }
        }

        private void dtgChanDoan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgChanDoan != null && dtgChanDoan.RowCount > 0)
            {
                DataProvider.UpdateData(daChanDoan, ref dtChanDoan, dtgChanDoan, string.Empty, string.Empty);
            }
        }

        private void btnRefreshMaNhomCLS_Click(object sender, EventArgs e)
        {
            Load_ChanDoan(string.Empty);
        }
        private void txtMaChanDoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtChanDoan);
        }

        private void txtChanDoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnAddChanDoan);
        }

        private void FrmDanhMucChanDoan_Load(object sender, EventArgs e)
        {
            Load_ChanDoan(string.Empty);
        }

    }
}
