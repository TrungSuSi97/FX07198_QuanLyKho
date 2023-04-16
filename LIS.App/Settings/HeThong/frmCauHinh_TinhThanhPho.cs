using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.HeThong
{
    public partial class frmCauHinh_TinhThanhPho : FrmTemplate
    {
        public frmCauHinh_TinhThanhPho()
        {
            InitializeComponent();
        }
        SqlDataAdapter daTinhTP = new SqlDataAdapter();
        SqlDataAdapter daQuanHuyen = new SqlDataAdapter();
        
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        DataTable dtTinhTP = new DataTable();
        DataTable dtQuanHuyen = new DataTable();

        private void frmCauHinh_TinhThanhPho_Load(object sender, EventArgs e)
        {
            data.Get_TinhTP(daTinhTP, dtgTinhTP,bvTinhTp, "", ref dtTinhTP);
        }

        private void dtgTinhTP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string _condit = (dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString() == "" ? "and MaTinh =  0" : " and MaTinh = " + dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString()) + (txtTenHuyen.Text == "" ? "" : "and (QuanHuyen like N'" + txtTenHuyen.Text + "%' or QuanHuyen like N'%" + txtTenHuyen.Text + "%' or QuanHuyen like N'%" + txtTenHuyen.Text + "')");
            data.Get_QuanHuyen(daQuanHuyen, dtgQuanHuyen, bvQuanHuyen,_condit, ref dtQuanHuyen);
        }

        private void dtgTinhTP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataProvider.UpdateData(daTinhTP, ref dtTinhTP, dtgTinhTP, "", ""))
            {
                string _condit = txtTenTinh.Text == "" ? "" : "and (TenTinh like N'" + txtTenTinh.Text + "%' or TenTinh like N'%" + txtTenTinh.Text + "%' or TenTinh like N'%" + txtTenTinh.Text + "')";
                data.Get_TinhTP(daTinhTP, dtgTinhTP, bvTinhTp, _condit, ref dtTinhTP);
            }
        }

        private void dtgQuanHuyen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataProvider.UpdateData(daQuanHuyen, ref dtQuanHuyen, dtgQuanHuyen, "", ""))
            {
                string _condit = (dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString() == "" ? "and MaTinh =  0" : " and MaTinh = " + dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString()) + (txtTenHuyen.Text == "" ? "" : "and (QuanHuyen like N'" + txtTenHuyen.Text + "%' or QuanHuyen like N'%" + txtTenHuyen.Text + "%' or QuanHuyen like N'%" + txtTenHuyen.Text + "')");
                data.Get_QuanHuyen(daQuanHuyen, dtgQuanHuyen, bvQuanHuyen, _condit, ref dtQuanHuyen);
            }
        }

        private void dtgQuanHuyen_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void dtgQuanHuyen_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString() != "" && dtgQuanHuyen.CurrentRow.Cells["hMaTinh"].Value.ToString() == "")
            {
                dtgQuanHuyen.CurrentRow.Cells["hMaTinh"].Value = dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString();
            }
        }

        private void btnRefreshTinh_Click(object sender, EventArgs e)
        {
            string _condit = txtTenTinh.Text == "" ? "" : "and (TenTinh like N'" + txtTenTinh.Text + "%' or TenTinh like N'%" + txtTenTinh.Text + "%' or TenTinh like N'%" + txtTenTinh.Text + "')";
            data.Get_TinhTP(daTinhTP, dtgTinhTP, bvTinhTp, _condit, ref dtTinhTP);
        }

        private void txtTenTinh_KeyUp(object sender, KeyEventArgs e)
        {
            string _condit = txtTenTinh.Text == "" ? "" : "and (TenTinh like N'" + txtTenTinh.Text + "%' or TenTinh like N'%" + txtTenTinh.Text + "%' or TenTinh like N'%" + txtTenTinh.Text + "')";
            data.Get_TinhTP(daTinhTP, dtgTinhTP, bvTinhTp, _condit, ref dtTinhTP);
        }

        private void txtTenHuyen_KeyUp(object sender, KeyEventArgs e)
        {
            string _condit = (dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString() == "" ? "and MaTinh =  0" :" and MaTinh = " + dtgTinhTP.CurrentRow.Cells["MaTinh"].Value.ToString()) + (txtTenHuyen.Text == "" ? "" : "and (QuanHuyen like N'" + txtTenHuyen.Text + "%' or QuanHuyen like N'%" + txtTenHuyen.Text + "%' or QuanHuyen like N'%" + txtTenHuyen.Text + "')");
            data.Get_QuanHuyen(daQuanHuyen, dtgQuanHuyen, bvQuanHuyen,_condit, ref dtQuanHuyen);
        }
    }
}
