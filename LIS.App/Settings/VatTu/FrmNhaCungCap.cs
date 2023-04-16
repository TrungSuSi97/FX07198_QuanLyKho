using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.PropertiesMember;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.CauHinh.VatTu
{
    public partial class FrmNhaCungCap : FrmTemplate
    {
        public FrmNhaCungCap()
        {
            InitializeComponent();
        }
        VT_DM_NHACUNGCAP_DAL nhaccungcapDAL = new VT_DM_NHACUNGCAP_DAL();
        VT_NHACUNGCAP_VATTU_DAL ncc_vattuDAL = new VT_NHACUNGCAP_VATTU_DAL();
        SqlDataAdapter daNhaCungCap = new SqlDataAdapter();
        DataTable dtNhaCungCap = new DataTable();
        bool _isLoading = false;
        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            Load_NhaCungCap();
            Load_Loai_VatTu();
            Load_NhaCC_VatTu();
            _isLoading = false;
        }

        private void Load_NhaCungCap()
        {
            nhaccungcapDAL.Data_VT_DM_NhaCungCap(ref daNhaCungCap, ref dtNhaCungCap, ref dtgNhaCungCap, ref bvNhaCungCap, "");
            ControlExtension.BindDataToGrid(dtNhaCungCap.Copy(), ref dtgS_NhaCungCap, ref bvS_NhaCungCap);
        }

        private void dtgNhaCungCap_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            nhaccungcapDAL.Update_DataTable_VT_DM_NhaCungCap(ref daNhaCungCap, ref dtNhaCungCap, dtgNhaCungCap, bvNhaCungCap);
        }
        private void Insert_NhaCungCap()
        {
            if (txtMaNhaCungCap.Text != "")
            {
                VT_DM_NHACUNGCAP ncc = new VT_DM_NHACUNGCAP();
                ncc.Diachi = txtDiaChi.Text;
                ncc.Dienthoai = txtDienThoai.Text;
                ncc.Email = txtEmail.Text;
                ncc.Ghichu = txtGhiChu.Text;
                ncc.Gotat = txtGoTat.Text;
                ncc.Manhacungcap = txtMaNhaCungCap.Text;
                ncc.Tennhacungcap = txtTenNhaCungCap.Text;
                nhaccungcapDAL.Insert_Update_VT_DM_NHACUNGCAP(ncc, false);
                Clear_Control();
                _isLoading = true;
                Load_NhaCungCap();
                Load_NhaCC_VatTu();
                _isLoading = false;
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã nhà cung cấp.");
        }

        private void Load_Loai_VatTu()
        {
            VT_DM_LOAIVT_DAL loaivtDAL = new VT_DM_LOAIVT_DAL();
            loaivtDAL.Data_VT_DM_LoaiVT(cboLoaiVatTu, "MaLoaiVT", "MaLoaiVT", "MaLoaiVT,TenLoaiVT", "50,150", txtLoaiVatTu, 1, "");
        }
        private void Load_NhomVatTu()
        {
            if (cboLoaiVatTu.SelectedIndex != -1)
            {
                string _MaLoaivatTu = cboLoaiVatTu.SelectedValue.ToString();
                if (_MaLoaivatTu.Trim().ToUpper() == "THUOC")
                {
                    DM_THUOC_NHOMTHUOC_DAL nhomthuocDAL = new DM_THUOC_NHOMTHUOC_DAL();
                    nhomthuocDAL.Data_DM_Thuoc_NhomThuoc(cboNhomVatTu, "MaNhomThuoc", "MaNhomThuoc", "MaNhomThuoc,TenNhomThuoc", "50,150", txtNhomVatTu, 1, "");
                }
                else
                {
                    VT_DM_NHOMVT_DAL nhomvattuDAL = new VT_DM_NHOMVT_DAL();
                    nhomvattuDAL.Data_VT_DM_NhomVT(cboNhomVatTu, "MaNhomVT", "MaNhomVT", "MaNhomVT,TenNhomVT", "50,150", txtNhomVatTu, 1, _MaLoaivatTu, "");
                }
            }
        }

        private void Load_VatTu()
        {
            if (cboLoaiVatTu.SelectedIndex != -1)
            {
                string _MaLoaivatTu = cboLoaiVatTu.SelectedValue.ToString();
                string _MaNhomVatTu = cboNhomVatTu.SelectedIndex == -1 ? "" : cboNhomVatTu.SelectedValue.ToString().Trim();

                if (_MaLoaivatTu.Trim().ToUpper() == "THUOC")
                {
                    DM_THUOC_DAL thuocDAL = new DM_THUOC_DAL();
                    thuocDAL.Data_DM_Thuoc(cboVatTu, "MaThuoc", "GoTat", "MaThuoc, GoTat,TenThuoc", "50,50,200", txtVatTu, 2, "", "", _MaNhomVatTu);
                }
                else
                {
                    VT_DM_VATTU_DAL vattuDAL = new VT_DM_VATTU_DAL();
                    vattuDAL.Data_VT_DM_VatTu(cboVatTu, "MaVatTu", "MaVatTu", "MaVatTu, TenVatTu", "50,200", txtVatTu, 1, _MaLoaivatTu, _MaNhomVatTu, "");
                }
            }
        }

        private void Insert_NCC_VatTu()
        {
            if (dtgS_NhaCungCap.RowCount > 0)
            {
                if (cboLoaiVatTu.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn loại vật tư.");
                }
                else if (cboVatTu.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn vật tư.");
                }
                else
                {
                    VT_NHACUNGCAP_VATTU ncc_vattu = new VT_NHACUNGCAP_VATTU();
                    ncc_vattu.Maloaivattu = cboLoaiVatTu.SelectedValue.ToString().Trim();
                    ncc_vattu.Manhacungcap = dtgS_NhaCungCap.CurrentRow.Cells[S_MaNhaCungCap.Name].Value.ToString().Trim();
                    ncc_vattu.Mavattu = cboVatTu.SelectedValue.ToString().Trim();

                    if (ncc_vattuDAL.Insert_Update_VT_NHACUNGCAP_VATTU(ncc_vattu, false) > -1)
                    {
                        Load_NhaCC_VatTu();
                    }
                }
            }
        }
        private void Delete_NCC_VatTu()
        {
            if (dtgSanPham.RowCount > 0)
            {
                VT_NHACUNGCAP_VATTU ncc_vattu = new VT_NHACUNGCAP_VATTU();
                ncc_vattu.Maloaivattu = dtgSanPham.CurrentRow.Cells[MaLoaiVatTu.Name].Value.ToString().Trim();
                ncc_vattu.Manhacungcap = dtgSanPham.CurrentRow.Cells[NCC_S_MaNhaCungCap.Name].Value.ToString().Trim();
                ncc_vattu.Mavattu = dtgSanPham.CurrentRow.Cells[MaSanPham.Name].Value.ToString().Trim();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa vật tư đang chọn?"))
                {
                    if (ncc_vattuDAL.Delete_VT_NHACUNGCAP_VATTU(ncc_vattu) > -1)
                    {
                        Load_NhaCC_VatTu();
                    }
                }
            }
        }
        private void Load_NhaCC_VatTu()
        {
            if (dtgS_NhaCungCap.RowCount > 0)
            {
                string _MaNhaCungCap = (dtgS_NhaCungCap.CurrentRow == null ? "" : dtgS_NhaCungCap.CurrentRow.Cells[S_MaNhaCungCap.Name].Value.ToString().Trim());
                string _MaLoaiVatTu = cboLoaiVatTu.SelectedIndex == -1 ? "" : cboLoaiVatTu.SelectedValue.ToString().Trim();
                string _MaVatTu = "";// cboVatTu.SelectedIndex == -1 ? "" : cboVatTu.SelectedValue.ToString().Trim();
                ControlExtension.BindDataToGrid(ncc_vattuDAL.Data_VT_NhaCungCap_VatTu(_MaLoaiVatTu, _MaNhaCungCap, _MaVatTu), ref dtgSanPham, ref bvSanPham);
            }
        }
        private void txtMaNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGoTat);
        }

        private void txtGoTat_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenNhaCungCap);
        }

        private void txtTenNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtDienThoai);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {   
            LabServices_Helper.LeaveFocusNext(e, txtDiaChi);
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtEmail);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGhiChu);
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemNhaCungCap);
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            Insert_NhaCungCap();
        }
        private void Clear_Control()
        {
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.Text = "";
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.Text = "";
            txtEmail.DataBindings.Clear();
            txtEmail.Text = "";
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.Text="";
            txtGoTat.DataBindings.Clear();
            txtGoTat.Text="";
            txtMaNhaCungCap.DataBindings.Clear();
            txtMaNhaCungCap.Text="";
            txtTenNhaCungCap.DataBindings.Clear();
            txtTenNhaCungCap.Text="";
        }

        private void cboNhomVatTu_Enter(object sender, EventArgs e)
        {
            Load_NhomVatTu();
        }

        private void cboVatTu_Enter(object sender, EventArgs e)
        {
            Load_VatTu();
        }

        private void dtgS_NhaCungCap_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!_isLoading)
            {
                Load_NhaCC_VatTu();
            }

        }

        private void btnAdd_Sanpham_Click(object sender, EventArgs e)
        {
            Insert_NCC_VatTu();
        }

        private void cboVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                if (cboVatTu.SelectedIndex != -1)
                {
                    Insert_NCC_VatTu();
                }
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            Delete_NCC_VatTu();
        }

        private void cboLoaiVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboNhomVatTu);
        }

        private void cboNhomVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboVatTu);
        }
    }
}
