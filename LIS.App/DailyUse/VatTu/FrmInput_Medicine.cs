using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.PropertiesMember;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.ThucThi.VatTu
{
    public partial class FrmInput_Medicine : FrmTemplate
    {
        public FrmInput_Medicine()
        {
            InitializeComponent();
        }
        VT_NHAPKHO_PHIEUNHAP_THUOC_DAL phieuNhapDAL = new VT_NHAPKHO_PHIEUNHAP_THUOC_DAL();
        VT_NHAPKHO_CHIETTIET_THUOC_DAL chitietDAL = new VT_NHAPKHO_CHIETTIET_THUOC_DAL();
        DM_THUOC_DAL thuocDAL = new DM_THUOC_DAL();
        private void FrmInput_Medicine_Load(object sender, EventArgs e)
        {
            Load_NhaCungCap();
            Load_NhomVatTu();
        }

        private void Clear_Info()
        {
            dtpNgayNhap.DataBindings.Clear();
            dtpNgayNhap.Value = DateTime.Now;
            txtSoPhieuNhap.DataBindings.Clear();
            txtSoPhieuNhap.Text = "";
            txtNguoiLapPhieu.DataBindings.Clear();
            txtNguoiLapPhieu.Text = "";
            txtNgayLapPhieu.DataBindings.Clear();
            txtNgayLapPhieu.Text = "";
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.Text = "";
        }

        private void Clear_Detail()
        {
            cboNhaCungCap.SelectedIndex = -1;
            cboNhomVatTu.SelectedIndex = -1;
            cboVatTu.SelectedIndex = -1;
            txtSoLuong.Text = "";
            dtpHanSuDung.Checked = false;
        }

        private void Bind_InfoData(DataTable dt)
        {
            txtSoPhieuNhap.DataBindings.Add("Text", dt, "MaPhieuNhap");
            txtNguoiLapPhieu.DataBindings.Add("Text", dt, "NguoiNhap");
            txtGhiChu.DataBindings.Add("Text", dt, "GhiChu");
            dtpNgayNhap.DataBindings.Add("Value", dt, "NgayNhap");
            txtNgayLapPhieu.DataBindings.Add("Text", dt, "TGNhap", true, DataSourceUpdateMode.Never, "", "dd/MM/yyyy HH:mm:ss");
        }
        private void Enable_Control_Info(bool _isEnable, bool _editMode)
        {
            dtpNgayNhap.Enabled = _isEnable;
            if (_isEnable)
            {
                if (_editMode)
                {
                    txtSoPhieuNhap.BackColor = Color.LightGreen;
                }
                else
                {
                    txtSoPhieuNhap.BackColor = Color.Yellow;
                    btnXemDanhSach.Enabled = false;
                }
            }
            else
            {
                btnXemDanhSach.Enabled = true;
                txtSoPhieuNhap.BackColor = SystemColors.Control;
            }
            txtGhiChu.ReadOnly = !_isEnable;
        }

        private void Start_AddNew()
        {
            Clear_Info();
            Enable_Control_Info(true, false);
            dtpNgayNhap.Focus();
        }
        private void Start_Edit()
        {
            Enable_Control_Info(true, true);
            txtGhiChu.Focus();
        }
        private void Delete_Info()
        {
            if (txtNguoiLapPhieu.Text.Trim().ToLower().Equals(CommonAppVarsAndFunctions.UserID.Trim().ToLower()) || CommonAppVarsAndFunctions.UserID.Trim().ToLower().Equals("admin"))
            {
                string _maphieunhap = txtSoPhieuNhap.Text;
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa phiếu: " + _maphieunhap))
                {
                    if (phieuNhapDAL.Delete_VT_NHAPKHO_PHIEUNHAP_THUOC(new VT_NHAPKHO_PHIEUNHAP_THUOC("", txtSoPhieuNhap.Text, DateTime.Now, "", "", DateTime.Now, DateTime.Now)) > -1)
                    {
                        Load_Input_Info(_maphieunhap);
                    }
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Bạn không thể xóa phiếu nhập của người khác!");
            }
        }
        private int Insert_Update_Inputinfo()
        {
            if (txtSoPhieuNhap.BackColor == Color.LightGreen || txtSoPhieuNhap.BackColor == Color.Yellow)
            {
                bool _isUpdate = false;
                _isUpdate = (txtSoPhieuNhap.BackColor == Color.LightGreen);
                if (!_isUpdate)
                {
                    txtNguoiLapPhieu.Text = CommonAppVarsAndFunctions.UserID;
                    Gernerate_Input_Code();
                }
                else
                {
                    txtGhiChu.Focus();
                    if (CustomMessageBox.MSG_Question_YesNo_GetNo("Cập nhật thông tin chỉnh sửa?"))
                    {
                        return -1;
                    }
                }
                if (phieuNhapDAL.Insert_Update_VT_NHAPKHO_PHIEUNHAP_THUOC(
                       new VT_NHAPKHO_PHIEUNHAP_THUOC(txtGhiChu.Text, txtSoPhieuNhap.Text, dtpNgayNhap.Value, CommonAppVarsAndFunctions.UserID, txtNguoiLapPhieu.Text, DateTime.Now, DateTime.Now), _isUpdate) > -1)
                {
                    Load_Input_Info(txtSoPhieuNhap.Text);

                    return 1;
                }
                else
                    return -1;
            }
            else
                return -1;

        }

        private void Gernerate_Input_Code()
        {
            string _first_string = "NK.TH";
            string _day = dtpNgayNhap.Value.Day.ToString("00");
            string _month = dtpNgayNhap.Value.Month.ToString("00");
            string _year = dtpNgayNhap.Value.Year.ToString("0000");

            string _finalString = _first_string + "." + _day + "." + _month + "." + _year + ".";
            DataTable dt = phieuNhapDAL.Data_VT_NhapKho_PhieuNhap_Thuoc_CodeList(_finalString);
            string _tempID = "";
            if (dt.Rows.Count > 0)
            {
                _tempID = dt.Rows[0]["CodeNo"].ToString();
                if (_tempID.Trim() == "")
                    _tempID = "001";
                else
                    _tempID = (int.Parse(_tempID) + 1).ToString("000");
            }
            else
            {
                _tempID = "001";
            }

            txtSoPhieuNhap.Text = _finalString  + _tempID;
        }

        private void dtpNgayNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGhiChu);
        }

        private void Load_Input_Info(string _MaPhieuNhap)
        {
            DataTable dt = new DataTable();
            dt = phieuNhapDAL.Data_VT_NhapKho_PhieuNhap_Thuoc(_MaPhieuNhap);
            Clear_Info();
            Enable_Control_Info(false, false);
            Bind_InfoData(dt);
            Load_DanhSachNhap();
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                Insert_Update_Inputinfo();
            }
        }

        private void txtTimSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                Load_Input_Info(txtTimSoPhieu.Text);
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            Insert_Update_Inputinfo();
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            Start_AddNew();
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            Start_Edit();
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            Delete_Info();
        }

        private void Load_NhaCungCap()
        {
            VT_DM_NHACUNGCAP_DAL nccDAL = new VT_DM_NHACUNGCAP_DAL();
            nccDAL.Data_VT_DM_NhaCungCap(cboNhaCungCap, "MaNhaCungCap", "GoTat", "MaNhaCungCap, GoTat,TenNhaCungCap", "50,50,200", txtNhaCungCap, 1, "");
        }

        private void Load_NhomVatTu()
        {
            DM_THUOC_NHOMTHUOC_DAL nhomDAL = new DM_THUOC_NHOMTHUOC_DAL();
            nhomDAL.Data_DM_Thuoc_NhomThuoc(cboNhomVatTu, "MaNhomThuoc", "MaNhomThuoc", "MaNhomThuoc, TenNhomThuoc", "50,150", txtNhomVatTu, 1, "");
        }

        private void Load_VatTu()
        {
            string _MaNhomThuoc = (cboNhomVatTu.SelectedIndex != -1 ? cboNhomVatTu.SelectedValue.ToString() : "");
            string _MaNhaCungCap = (cboNhaCungCap.SelectedIndex == -1 ? "" : cboNhaCungCap.SelectedValue.ToString().Trim());
            cboVatTu.LinkedColumnIndex2 = 2;
            cboVatTu.LinkedTextBox2 = txtDonViTinh;
            thuocDAL.Data_DM_Thuoc_ForInput(cboVatTu, "MaVatTu", "MaVatTu", "MaVatTu, TenVatTu, DonViTinh", "50,50,150", txtVatTu, 1, _MaNhaCungCap, _MaNhomThuoc);
        }

        private void cboVatTu_Enter(object sender, EventArgs e)
        {
            Load_VatTu();
        }

        private void cboNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                Load_VatTu();
                cboNhomVatTu.Focus();
                e.Handled = true;
            }
        }

        private void cboNhomVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboVatTu);
        }

        private void cboVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                if (cboVatTu.SelectedIndex != -1)
                {
                    dtpHanSuDung.Checked = (bool)((DataTable)cboVatTu.DataSource).Rows[cboVatTu.SelectedIndex]["CoHSD"];
                    txtGiaNhap.Focus();
                }
                else
                {
                    dtpHanSuDung.Checked = false;
                }   
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                if (dtpHanSuDung.Checked)
                {
                    dtpHanSuDung.Focus();
                }
                else
                    btnNhapKho.Focus();
            }
            ControlExtension.KeyNumber(e, false);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            Insert_Thuoc();
        }
        private void Insert_Thuoc()
        {
            if (cboNhaCungCap.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn nhà cung cấp.");
                cboNhaCungCap.Focus();
            }
            else if (cboVatTu.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn thuốc.");
                cboVatTu.Focus();
            }
            else if (txtSoLuong.Text == "" || txtSoLuong.Text == "0")
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập số lượng.");
                txtSoLuong.Focus();
            }
            else
            {
                if (LabServices_Helper.IsNumeric(txtSoLuong.Text))
                {
                    if (float.Parse(txtSoLuong.Text) > 0)
                    {
                        VT_NHAPKHO_CHIETTIET_THUOC thuocNhapKho = new VT_NHAPKHO_CHIETTIET_THUOC();
                        thuocNhapKho.Cohsd = dtpHanSuDung.Checked;
                        thuocNhapKho.Donvitinh = "";
                        thuocNhapKho.Dvtquicachcap1 = "";
                        thuocNhapKho.Magocthuoc = "";
                        thuocNhapKho.Manhacungcap = cboNhaCungCap.SelectedValue.ToString().Trim();
                        thuocNhapKho.Maphieunhap = txtSoPhieuNhap.Text.Trim();
                        thuocNhapKho.Mavattu = cboVatTu.SelectedValue.ToString().Trim();
                        thuocNhapKho.Slquicachcap1 = 0;
                        thuocNhapKho.Slquicachcap2 = 0;
                        thuocNhapKho.Soluongnhap = float.Parse(txtSoLuong.Text);
                        thuocNhapKho.Soluongtheoquicach = 0;
                        thuocNhapKho.Soluongxuat = 0;
                        thuocNhapKho.Soluongxuattheoquicach = 0;
                        thuocNhapKho.Tenthuoc = "";
                        thuocNhapKho.Tgnhap = DateTime.Now;
                        thuocNhapKho.Xuattheoqcdg = false;
                        thuocNhapKho.Hansudung = dtpHanSuDung.Value;
                        thuocNhapKho.Hangtang = chkHangTang.Checked;
                        thuocNhapKho.Gianhap = decimal.Parse(txtGiaNhap.Text == "" ? "0" : txtGiaNhap.Text);
                        if (chitietDAL.Insert_Update_VT_NHAPKHO_CHIETTIET_THUOC(thuocNhapKho, false) > -1)
                        {
                            Load_DanhSachNhap();
                            cboVatTu.Focus();
                        }
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Số lượng không hợp lệ.");
                }
            }
        }
        private void Load_DanhSachNhap()
        {
            ControlExtension.BindDataToGrid(chitietDAL.Data_VT_NhapKho_ChietTiet_Thuoc("", txtSoPhieuNhap.Text, ""), ref dtgChiTietNhap, ref bvChiTietNhap);
        }
        private void cboVatTu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboVatTu.SelectedIndex != -1)
            {
                dtpHanSuDung.Checked = (bool)((DataTable)cboVatTu.DataSource).Rows[cboVatTu.SelectedIndex]["CoHSD"];
            }
            else
                dtpHanSuDung.Checked = false;
        }

        private void txtSoLuong_Enter(object sender, EventArgs e)
        {
            txtSoLuong.SelectAll();
        }

        private void txtGiaNhap_Enter(object sender, EventArgs e)
        {
            txtGiaNhap.SelectAll();
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            LabServices_Helper.LeaveFocusNext(e, txtSoLuong);
        }

        private void cboNhaCungCap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_VatTu();
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            FrmInput_List f = new FrmInput_List();
            f.IndexLoaiVatTu = "THUOC";
            f.ShowDialog();
            txtTimSoPhieu.Text = f.StrReturn;
            f.Dispose();
            if (txtTimSoPhieu.Text != "")
            {
                Load_Input_Info(txtTimSoPhieu.Text);
            }
        }
    }
}
