using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.ThucThi.VatTu
{
    public partial class FrmOutput_List : FrmTemplate
    {
        public FrmOutput_List()
        {
            InitializeComponent();
        }
        VT_XUATKHO_PHIEUXUAT_THUOC_DAL phieuXuatDAL = new VT_XUATKHO_PHIEUXUAT_THUOC_DAL();
        VT_XUATKHO_CHITIET_THUOC_DAL chitietDAL = new VT_XUATKHO_CHITIET_THUOC_DAL();
        DM_THUOC_DAL thuocDAL = new DM_THUOC_DAL();

        private string _indexLoaiVatTu = "";
        bool _isloading = false;
        public string IndexLoaiVatTu
        {
            get { return _indexLoaiVatTu; }
            set { _indexLoaiVatTu = value; }
        }
        private string _strReturn = "";

        public string StrReturn
        {
            get { return _strReturn; }
            set { _strReturn = value; }
        }

        private void Load_NhaCungCap()
        {
            VT_DM_NHACUNGCAP_DAL nccDAL = new VT_DM_NHACUNGCAP_DAL();
            nccDAL.Data_VT_DM_NhaCungCap(cboNhaCungCap, "MaNhaCungCap", "GoTat", "MaNhaCungCap, GoTat,TenNhaCungCap", "50,50,200", txtNhaCungCap, 1, "");
        }
        private void Load_LoaiVatTu()
        {
            VT_DM_LOAIVT_DAL loaiDAL = new VT_DM_LOAIVT_DAL();
            loaiDAL.Data_VT_DM_LoaiVT(cboLoaiVatTu, "MaLoaiVT", "MaLoaiVT", "MaLoaiVT, TenLoaiVT", "50,150", txtLoaiVatTu, 1, "");
            if (IndexLoaiVatTu.Trim().ToUpper().Equals("THUOC"))
            {
                cboLoaiVatTu.SelectedValue = "THUOC";
                cboLoaiVatTu.Enabled = false;
            }
            else if (_indexLoaiVatTu != "")
                cboLoaiVatTu.SelectedValue = _indexLoaiVatTu;
        }
        private void Load_NhomVatTu()
        {
            if (IndexLoaiVatTu.Trim().ToUpper().Equals("THUOC"))
            {
                DM_THUOC_NHOMTHUOC_DAL nhomDAL = new DM_THUOC_NHOMTHUOC_DAL();
                nhomDAL.Data_DM_Thuoc_NhomThuoc(cboNhomVatTu, "MaNhomThuoc", "MaNhomThuoc", "MaNhomThuoc, TenNhomThuoc", "50,150", txtNhomVatTu, 1, "");
            }
            else
            {
                string _MaLoaiVatTu = (cboLoaiVatTu.SelectedIndex == -1 ? "" : cboLoaiVatTu.SelectedValue.ToString().Trim());
                VT_DM_NHOMVT_DAL nhomDAL = new VT_DM_NHOMVT_DAL();
                nhomDAL.Data_VT_DM_NhomVT(cboNhomVatTu, "MaNhomVT", "MaNhomVT", "MaNhomVT, TenNhomVT", "50,150", txtNhomVatTu, 1, _MaLoaiVatTu, "");
            }
        }
        private void Load_VatTu()
        {
            string _MaNhomVatTu = (cboNhomVatTu.SelectedIndex != -1 ? cboNhomVatTu.SelectedValue.ToString() : "");
            string _MaNhaCungCap = (cboNhaCungCap.SelectedIndex == -1 ? "" : cboNhaCungCap.SelectedValue.ToString().Trim());
            string _MaLoaiVatTu = (cboLoaiVatTu.SelectedIndex == -1 ? "" : cboLoaiVatTu.SelectedValue.ToString().Trim());
            if (IndexLoaiVatTu.Trim().ToUpper().Equals("THUOC"))
            {
                thuocDAL.Data_DM_Thuoc_ForInput(cboVatTu, "MaVatTu", "MaVatTu", "MaVatTu, TenVatTu, DonViTinh", "50,50,150", txtVatTu, 1, _MaNhaCungCap, _MaNhomVatTu);
            }   
        }
        private void FrmInput_List_Load(object sender, EventArgs e)
        {
            _isloading = true;
            dtpFromDate.Value = dtpFromDate.Value.AddMonths(-1);
            Load_NhaCungCap();
            Load_LoaiVatTu();
            Search_Output_Thuoc();
            Load_Detail();
            _isloading = false;
        }

        private void cboLoaiVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Check_Load_CauHinh_VatTu();
        }

        private void Check_Load_CauHinh_VatTu()
        {
            if (cboLoaiVatTu.SelectedIndex != -1)
            {
                Load_NhomVatTu();
                Load_VatTu();
                cboNhomVatTu.Enabled = true;
                cboVatTu.Enabled = true;
            }
            else
            {
                cboNhomVatTu.SelectedIndex = -1;
                cboVatTu.SelectedIndex = -1;
                cboNhomVatTu.Enabled = false;
                cboVatTu.Enabled = false;
            }
        }
        private void Search_Output_Thuoc()
        {
            string _MaNhomVatTu = (cboNhomVatTu.SelectedIndex != -1 ? cboNhomVatTu.SelectedValue.ToString() : "");
            string _MaNhaCungCap = (cboNhaCungCap.SelectedIndex == -1 ? "" : cboNhaCungCap.SelectedValue.ToString().Trim());
            string _VatTu = (cboVatTu.SelectedIndex == -1 ? "" : cboVatTu.SelectedValue.ToString().Trim());
            DataTable dt = phieuXuatDAL.Data_Search_OutputList(dtpFromDate.Value, dtpToDate.Value, txtTimSoPhieu.Text, txtNguoiLap.Text, _MaNhaCungCap, _MaNhomVatTu, _VatTu);
            ControlExtension.BindDataToGrid(dt, ref dtgList, ref bvList);
        }

        private void cboLoaiVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                Check_Load_CauHinh_VatTu();
            }
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            if (IndexLoaiVatTu.Trim().ToUpper().Equals("THUOC"))
            {
                _isloading = true;
                Search_Output_Thuoc();
                Load_Detail();
                _isloading = false;
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isloading)
            {
                Search_Output_Thuoc();
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isloading)
            {
                Search_Output_Thuoc();
            }
        }

        private void txtTimSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search_Output_Thuoc();
        }

        private void dtgList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!_isloading)
            {
                Load_Detail();
            }
        }

        private void Load_Detail()
        {
            string _MaSoPhieu = "-1";
            if (dtgList.RowCount > 0)
            {
                _MaSoPhieu = dtgList.CurrentRow.Cells[MaSoPhieu.Name].Value.ToString().Trim();

            }
            if (IndexLoaiVatTu.Trim().ToUpper().Equals("THUOC"))
            {
                ControlExtension.BindDataToGrid(chitietDAL.Data_VT_XuatKho_ChiTiet_Thuoc("", _MaSoPhieu, ""), ref dtgDetail, ref bvDetail);
            }
        }

        private void dtgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgList.RowCount > 0)
            {
                _strReturn = dtgList.CurrentRow.Cells[MaSoPhieu.Name].Value.ToString().Trim();
                this.Close();
            }
        }
    }
}
