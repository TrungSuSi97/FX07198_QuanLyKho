using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.PropertiesMember;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.VatTu
{
    public partial class frmDM_VatTu_NhomLoai : FrmTemplate
    {
        public frmDM_VatTu_NhomLoai()
        {
            InitializeComponent();
        }
        bool _isLoading = false;

        DataTable dtLoaiVT= new DataTable();
        SqlDataAdapter daLoaiVT= new SqlDataAdapter();

        DataTable dtNhomVT = new DataTable();
        SqlDataAdapter daNhomVT = new SqlDataAdapter();


        VT_DM_VATTU_DAL vattuDAL = new VT_DM_VATTU_DAL();
        VT_DM_LOAIVT_DAL loaivattuDAL = new VT_DM_LOAIVT_DAL();
        VT_DM_NHOMVT_DAL nhomvattuDAL = new VT_DM_NHOMVT_DAL();

        private void frmDM_VatTu_NhomLoai_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            Load_LoaiVT();
            _isLoading = false;
            Load_NhomVT();
        }

        private void Load_LoaiVT()
        {
            loaivattuDAL.Data_VT_DM_LoaiVT(ref daLoaiVT, ref dtLoaiVT, ref dtgLoaiVatTu, ref bvLoaiVT, "");
            txtN_MaLoaiVatTu.DataBindings.Clear();
            txtN_MaLoaiVatTu.Text = "";
            txtN_MaLoaiVatTu.DataBindings.Add("Text", bvLoaiVT.BindingSource, "MaLoaiVT");
        }
        private void Load_NhomVT()
        {
            string _LoaiVT = "";
            if (dtgLoaiVatTu.RowCount > 0)
            {
                _LoaiVT = dtgLoaiVatTu.CurrentRow.Cells[MaLoaiVT.Name].Value.ToString();
            }
            nhomvattuDAL.Data_VT_DM_NhomVT(ref daNhomVT, ref dtNhomVT, ref dtgNhomVT, ref bvNhomVT, _LoaiVT, "");
        }

        private void btnThemMoiLoaiVatTu_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "")
            {
                loaivattuDAL.Insert_Update_VT_DM_LOAIVT(new VT_DM_LOAIVT(txtMaLoai.Text, txtTenLoai.Text), false);
                Load_LoaiVT();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Nhập mã loại vật tư");
                txtMaLoai.Focus();
            }
        }

        private void btnThemMoiNhomVatTu_Click(object sender, EventArgs e)
        {
            if (txtMaNhom.Text != "")
            {
                nhomvattuDAL.Insert_Update_VT_DM_NHOMVT(new VT_DM_NHOMVT(txtN_MaLoaiVatTu.Text, txtMaNhom.Text, txtTenNhom.Text), false);
                Load_NhomVT();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Nhập mã nhóm vật tư");
                txtMaNhom.Focus();
            }
        }

        private void dtgLoaiVT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            loaivattuDAL.Update_DataTable_VT_DM_LoaiVT(ref daLoaiVT, ref dtLoaiVT, dtgLoaiVatTu, bvLoaiVT);
        }

        private void dtgNhomVT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            nhomvattuDAL.Update_DataTable_VT_DM_NhomVT(ref daNhomVT, ref dtNhomVT, dtgNhomVT, bvNhomVT);
        }

        private void btnXoaNhomVT_Click(object sender, EventArgs e)
        {
            if (dtgNhomVT.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa nhóm vật tư đang chọn ?"))
                {
                    bvNhomVT.BindingSource.RemoveCurrent();
                    Load_NhomVT();
                }
            }
        }

        private void btnXoaLoaiVT_Click(object sender, EventArgs e)
        {
            if (dtgLoaiVatTu.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa loại vật tư đang chọn ?"))
                {
                    bvLoaiVT.BindingSource.RemoveCurrent();
                    Load_LoaiVT();
                }
                else
                {
                    return;
                }
            }
        }

        private void dtgLoaiVatTu_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_isLoading == false)
            {
                Load_NhomVT();
            }
        }

    }
}
