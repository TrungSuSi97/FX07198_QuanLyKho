using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.AppCode.PropertiesMember;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.User.Constants;

namespace TPH.LIS.App.ThucThi.VatTu
{
    public partial class FrmOutput_Medicine : FrmTemplate
    {
        VT_XUATKHO_PHIEUXUAT_THUOC_DAL phieuXuatDAL = new VT_XUATKHO_PHIEUXUAT_THUOC_DAL();
        VT_XUATKHO_CHITIET_THUOC_DAL chitietDAL = new VT_XUATKHO_CHITIET_THUOC_DAL();
        VT_NHAPKHO_CHIETTIET_THUOC_DAL nhapchitietDAL = new VT_NHAPKHO_CHIETTIET_THUOC_DAL();
        THUPHI_THUOC_DAL thuphiDAL = new THUPHI_THUOC_DAL();
        DM_THUOC_DAL thuocDAL = new DM_THUOC_DAL();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);

        public FrmOutput_Medicine()
        {
            InitializeComponent();
        }

        private void FrmOutput_Medicine_Load(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, "OutputPrinter", false);
            Load_CachDung();
        }
        private void Clear_Info()
        {
            dtpNgayNhap.DataBindings.Clear();
            dtpNgayNhap.Value = DateTime.Now;
            txtSoPhieuXuat.DataBindings.Clear();
            txtSoPhieuXuat.Text = "";
            txtMaTiepNhan.DataBindings.Clear();
            txtMaTiepNhan.Text="";
            txtNguoiLapPhieu.DataBindings.Clear();
            txtNguoiLapPhieu.Text = "";
            txtNgayLapPhieu.DataBindings.Clear();
            txtNgayLapPhieu.Text = "";
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.Text = "";
        }
        private void Bind_InfoData(DataTable dt)
        {
            txtSoPhieuXuat.DataBindings.Add("Text", dt, "MaPhieuXuat");
            txtMaTiepNhan.DataBindings.Add("Text", dt, "MaTiepNhan");
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
                    txtSoPhieuXuat.BackColor = Color.LightGreen;
                }
                else
                    txtSoPhieuXuat.BackColor = Color.Yellow;
            }
            else
            {
                txtSoPhieuXuat.BackColor = SystemColors.Control;
            }
            txtMaTiepNhan.ReadOnly = !_isEnable;
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
        private void Load_CachDung()
        {
            DM_THUOC_CACHDUNG_DAL cachdungDAL = new DM_THUOC_CACHDUNG_DAL();
            DataTable dt = cachdungDAL.Data_DM_Thuoc_CachDung("");
            ctCachDung.DataSource = dt;
            ctCachDung.DisplayMember = "TenCachDung";
            ctCachDung.ValueMember = "ID";
        }
        private void Gernerate_Output_Code()
        {
            string _first_string = "XK.TH";
            string _day = dtpNgayNhap.Value.Day.ToString("00");
            string _month = dtpNgayNhap.Value.Month.ToString("00");
            string _year = dtpNgayNhap.Value.Year.ToString("0000");

            string _finalString = _first_string + "." + _day + "." + _month + "." + _year + ".";
            DataTable dt = phieuXuatDAL.Data_VT_XuatKho_PhieuXuat_Thuoc_CodeList(_finalString);
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

            txtSoPhieuXuat.Text = _finalString + _tempID;
        }
        private int Insert_Update_Inputinfo()
        {
            if (txtSoPhieuXuat.BackColor == Color.LightGreen || txtSoPhieuXuat.BackColor == Color.Yellow)
            {
                string _MaTiepNhan = txtMaTiepNhan.Text;
                if (!_MaTiepNhan.Trim().Contains("-"))
                {
                    C_Patient patient = new C_Patient();
                    _MaTiepNhan = ConfigurationDetail.Get_MaTiepNhan(_MaTiepNhan, dtpNgayNhap.Value);
                    txtMaTiepNhan.Text = _MaTiepNhan;
                }

                bool _isUpdate = false;
                _isUpdate = (txtSoPhieuXuat.BackColor == Color.LightGreen);
                if (!_isUpdate)
                {
                    txtNguoiLapPhieu.Text = CommonAppVarsAndFunctions.UserID;
                    Gernerate_Output_Code();
                }
                else
                {
                    txtGhiChu.Focus();
                    if (CustomMessageBox.MSG_Question_YesNo_GetNo("Cập nhật thông tin chỉnh sửa?"))
                    {
                        return -1;
                    }
                }
                if (phieuXuatDAL.Insert_Update_VT_XUATKHO_PHIEUXUAT_THUOC(new VT_XUATKHO_PHIEUXUAT_THUOC(txtGhiChu.Text, txtSoPhieuXuat.Text, txtMaTiepNhan.Text, dtpNgayNhap.Value, CommonAppVarsAndFunctions.UserID, txtNguoiLapPhieu.Text, DateTime.Now, DateTime.Now), _isUpdate) > -1)
                {
                    Load_Output_Info(txtSoPhieuXuat.Text);
                    Load_Detail_ThuPhi();

                    return 1;
                }
                else
                    return -1;
            }
            else
                return -1;

        }
        private void Load_Output_Info(string _MaPhieuXuat)
        {
            DataTable dt = new DataTable();
            dt =phieuXuatDAL.Data_VT_XuatKho_PhieuXuat_Thuoc(_MaPhieuXuat);
            Clear_Info();
            Enable_Control_Info(false, false);
            Bind_InfoData(dt);
            Load_Detail_ThuPhi();
            Load_Input_Detail();
            Load_Output_Detail();
        }
        private void Delete_Info()
        {
            if (txtNguoiLapPhieu.Text.Trim().ToLower().Equals(CommonAppVarsAndFunctions.UserID.Trim().ToLower()) || CommonAppVarsAndFunctions.UserID.Trim().ToLower().Equals("admin"))
            {
                string _maphieuxuat = txtSoPhieuXuat.Text;
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa phiếu: " + _maphieuxuat))
                {
                    //Delete detail
                    VT_XUATKHO_CHITIET_THUOC chitiet = new VT_XUATKHO_CHITIET_THUOC();
                    chitiet.Maphieuxuat = _maphieuxuat;
                    chitiet.Mathuoc = "";
                    chitiet.Maphieunhap = "";
                    //Xóa chi tiết
                    if (dtgChiDinhThuoc.RowCount > 0)
                    {
                        for (int i = 0; i < dtgChiDinhThuoc.RowCount; i++)
                        {
                            Delete_ChiTietXuat(i, true);
                        }
                    }
                    //Xóa thông tin
                    if (phieuXuatDAL.Delete_VT_XUATKHO_PHIEUXUAT_THUOC(new VT_XUATKHO_PHIEUXUAT_THUOC("", txtSoPhieuXuat.Text, txtMaTiepNhan.Text, DateTime.Now, "", "", DateTime.Now, DateTime.Now)) > -1)
                    {
                        Load_Output_Info(_maphieuxuat);
                    }

                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Bạn không thể xóa phiếu xuất của người khác!");
            }
        }
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            Start_AddNew();
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            Start_Edit();
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            Insert_Update_Inputinfo();
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            Delete_Info();
        }

        private void txtMaTiepNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LabServices_Helper.IsKeyEnter(e))
            {
                if (txtSoPhieuXuat.BackColor == Color.Yellow && txtMaTiepNhan.Text !="")
                {
                    Insert_Update_Inputinfo();
                }
            }
        }
        bool _isLoadinhThuPhi = false;
        private void Load_Detail_ThuPhi()
        {
            if (txtMaTiepNhan.Text != "" && txtSoPhieuXuat.Text != "")
            {
                _isLoadinhThuPhi = true;
                ControlExtension.BindDataToGrid(thuphiDAL.Data_ThuPhi_Thuoc("", txtMaTiepNhan.Text, true), ref dtgDSThuocThuPhi, ref bvDSThuocThuPhi);
                Load_Input_Detail();
                _isLoadinhThuPhi = false;
            }
        }
        private void Insert_OutPutDetail(string _MaThuoc, string _MaPhieuNhap,string _MaPhieuXuat, string _MaNhaCungCap, string _LuongTon, string _SoLuong, string _SoLo, bool _XuatTheoQCDG)
        {
            if (txtMaTiepNhan.Text != "" && txtSoPhieuXuat.Text != "")
            {
                //Kiểm tra hợp lệ
                float _Ton = float.Parse(_LuongTon);
                float _Xuat = 0;
                float _CanXuat = float.Parse(dtgDSThuocThuPhi.CurrentRow.Cells[tpSoLuong.Name].Value.ToString());
                if (LabServices_Helper.IsNumeric(_SoLuong))
                    _Xuat = float.Parse(_SoLuong);
                if (_Xuat > 0)
                {
                    if (_Xuat <= _CanXuat)
                    {
                        if (_Xuat <= _Ton)
                        {
                            VT_XUATKHO_CHITIET_THUOC ctXuat = new VT_XUATKHO_CHITIET_THUOC();
                            ctXuat.Manhacungcap = _MaNhaCungCap;
                            ctXuat.Mathuoc = _MaThuoc;
                            ctXuat.Soluong = _Xuat;
                            ctXuat.Maphieunhap = _MaPhieuNhap;
                            ctXuat.Maphieuxuat = _MaPhieuXuat;
                            ctXuat.Solo = _SoLo;
                            ctXuat.Tgcapnhat = DateTime.Now;
                            ctXuat.Tgnhap = DateTime.Now;

                            if (chitietDAL.Insert_Update_VT_XUATKHO_CHITIET_THUOC(ctXuat, false) > 0)
                            {
                                nhapchitietDAL.Update_Output(_MaPhieuNhap, _MaThuoc, _Xuat, _XuatTheoQCDG);
                            }
                        }
                        else
                            CustomMessageBox.MSG_Information_OK("Số lượng xuất không được lớn hơn số lượng tồn.");
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Số lượng xuất không được nhiều hơn số lượng đã tính tiền.");
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Số lượng xuất phải lớn hơn 0.");
                }
                Load_Input_Detail();
                Load_Output_Detail();
            }
        }

        private void Delete_ChiTietXuat(int _index, bool _fromPhieuNhap)
        {
            if (dtgChiDinhThuoc.RowCount > 0)
            {
                bool _allow = false;
                if (_fromPhieuNhap)
                    _allow = true;
                else
                    _allow = CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chi tiết xuất đang chọn?");

                if (_allow)
                {
                    string _MaPhieuNhap = dtgChiDinhThuoc[ctMaPhieuNhap.Name, _index].Value.ToString();
                    string _MaPhieuXuat = dtgChiDinhThuoc[ctMaPhieuXuat.Name, _index].Value.ToString();
                    string _MaThuoc = dtgChiDinhThuoc[ctMaThuoc.Name, _index].Value.ToString();
                    float _SoLuong = float.Parse(dtgChiDinhThuoc[ctSoLuong.Name, _index].Value.ToString());
                    string _MaNhaCungCap = dtgChiDinhThuoc[ctMaNhaCungCap.Name, _index].Value.ToString();
                    string _SoLo = dtgChiDinhThuoc[ctSoLo.Name, _index].Value.ToString();
                    bool _XuatTheoQCDG = (bool)dtgChiDinhThuoc[ctXuatTheoQCDG.Name, _index].Value;
                    VT_XUATKHO_CHITIET_THUOC ctXuat = new VT_XUATKHO_CHITIET_THUOC();
                    ctXuat.Manhacungcap = _MaNhaCungCap;
                    ctXuat.Mathuoc = _MaThuoc;
                    ctXuat.Soluong = _SoLuong;
                    ctXuat.Maphieunhap = _MaPhieuNhap;
                    ctXuat.Maphieuxuat = _MaPhieuXuat;
                    ctXuat.Solo = _SoLo;
                    ctXuat.Tgcapnhat = DateTime.Now;
                    ctXuat.Tgnhap = DateTime.Now;
                    if (chitietDAL.Delete_VT_XUATKHO_CHITIET_THUOC(ctXuat, false) > 0)
                    {
                        nhapchitietDAL.Update_Output_return(_MaPhieuNhap, _MaThuoc, _SoLuong, _XuatTheoQCDG);
                    }
                    if (!_fromPhieuNhap)
                    {
                        Load_Input_Detail();
                        Load_Output_Detail();
                    }
                }
            }

        }

        private void Load_Output_Detail()
        {
            ControlExtension.BindDataToGrid(chitietDAL.Data_VT_XuatKho_ChiTiet_Thuoc("", txtSoPhieuXuat.Text, ""), ref dtgChiDinhThuoc, ref bvChiDinhThuoc);
        }
        private void Load_Input_Detail()
        {
            string _MaVatTu = "";
            if (dtgDSThuocThuPhi.RowCount > 0)
            {
                _MaVatTu = dtgDSThuocThuPhi.CurrentRow.Cells[tpMaVatTu.Name].Value.ToString().Trim();
            }
            ControlExtension.BindDataToGrid(nhapchitietDAL.Data_VT_NhapKho_ChiTiet_Xuat(_MaVatTu, ""), ref dtgChiTietNhap, ref bvChiTietNhap);
            if (dtgChiTietNhap.RowCount > 0 && dtgDSThuocThuPhi.RowCount > 0)
            {
                float _CanXuat = float.Parse(dtgDSThuocThuPhi.CurrentRow.Cells[tpSoLuong.Name].Value.ToString());
                for (int i = 0; i < dtgChiTietNhap.RowCount; i++)
                {
                    float _Ton = float.Parse(dtgChiTietNhap[SLTrongKho.Name, i].Value.ToString());
                    if (_CanXuat <= _Ton)
                    {
                        dtgChiTietNhap[SLXuat.Name, i].Value = _CanXuat;
                        break;
                    }
                    else if ((i + 1) < dtgChiTietNhap.RowCount)
                    {
                        dtgChiTietNhap[SLXuat.Name, i].Value = _Ton;
                        _CanXuat = _CanXuat - _Ton;
                    }
                }
            }
            if (dtgDSThuocThuPhi.RowCount < 1)
            {
                dtgChiTietNhap.Enabled = false;
                //CustomMessageBox.MSG_Information_OK("Không có chỉ định thuốc hoặc chưa thu tiền!");
            }
            else
                dtgChiTietNhap.Enabled = true;
        }
        private void dtgDSThuocThuPhi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!_isLoadinhThuPhi)
                Load_Input_Detail();
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            FrmOutput_List f = new FrmOutput_List();
            f.IndexLoaiVatTu = "THUOC";
            f.ShowDialog(); 
            f.Dispose();
            txtTimSoPhieu.Text = f.StrReturn;
            if (txtTimSoPhieu.Text != "")
            {
                Load_Output_Info(txtTimSoPhieu.Text);
            }
        }

        private void dtgChiTietNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Insert_Detail(e.RowIndex);
        }

        private void Insert_Detail(int RowIndex)
        {
            if (txtSoPhieuXuat.Text != "" && dtgChiTietNhap.RowCount > 0)
            {
                string _MaThuoc = "";
                string _MaPhieuNhap = "";
                string _MaPhieuXuat = "";
                string _MaNhaCungCap = "";
                string _LuongTon = "";
                string _SoLuong = "";
                string _SoLo = "";
                bool _XuatTheoQCDG = false;
                _MaThuoc = dtgChiTietNhap[iMaThuoc.Name, RowIndex].Value.ToString();
                _MaPhieuNhap = dtgChiTietNhap[MaphieuNhap.Name, RowIndex].Value.ToString();
                _MaPhieuXuat = txtSoPhieuXuat.Text.Trim();
                _MaNhaCungCap = dtgChiTietNhap[MaNhaCungCap.Name, RowIndex].Value.ToString();
                _LuongTon = dtgChiTietNhap[SLTrongKho.Name, RowIndex].Value.ToString();
                _SoLuong = dtgChiTietNhap[SLXuat.Name, RowIndex].Value.ToString();
                _SoLo = dtgChiTietNhap[SoLo.Name, RowIndex].Value.ToString();
                _XuatTheoQCDG = (bool)dtgChiTietNhap[XuatTheoQCDG.Name, RowIndex].Value;
                Insert_OutPutDetail(_MaThuoc, _MaPhieuNhap, _MaPhieuXuat, _MaNhaCungCap, _LuongTon, _SoLuong, _SoLo, _XuatTheoQCDG);
            }
        }
        private void btnDeleteThuoc_ChiTiet_Click(object sender, EventArgs e)
        {
            Delete_ChiTietXuat(dtgChiDinhThuoc.CurrentRow.Index, false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print_DonThuoc(true);
        }
        private void Print_DonThuoc(bool _isPrint)
        {
            if (txtSoPhieuXuat.Text != "" && txtMaTiepNhan.Text != "" && dtgChiDinhThuoc.RowCount > 0)
            {
                string _printerName = "";
                if (listPrinter.SelectedItem != null)
                {
                    _printerName = listPrinter.SelectedItem.ToString();
                }
                chitietDAL.Print_DonThuoc(txtSoPhieuXuat.Text, _isPrint, _printerName);
            }
        }
        private void Update_DonThuoc(int index)
        {
            if (dtgChiDinhThuoc.RowCount > 0)
            {
                VT_XUATKHO_CHITIET_THUOC chitiet = new VT_XUATKHO_CHITIET_THUOC();
                chitiet.Maphieuxuat = dtgChiDinhThuoc[ctMaPhieuXuat.Name, index].Value.ToString();
                chitiet.Maphieunhap = dtgChiDinhThuoc[ctMaPhieuNhap.Name, index].Value.ToString();
                chitiet.Manhacungcap = dtgChiDinhThuoc[ctMaNhaCungCap.Name, index].Value.ToString();
                chitiet.Mathuoc = dtgChiDinhThuoc[ctMaThuoc.Name, index].Value.ToString();
                chitiet.Soluong = int.Parse(dtgChiDinhThuoc[ctSoLuong.Name, index].Value.ToString() == "" ? "0" : dtgChiDinhThuoc[ctSoLuong.Name, index].Value.ToString());
                chitiet.Sang = dtgChiDinhThuoc[ctSang.Name, index].Value.ToString();
                chitiet.Trua = dtgChiDinhThuoc[ctTrua.Name, index].Value.ToString();
                chitiet.Chieu = dtgChiDinhThuoc[ctChieu.Name, index].Value.ToString();
                chitiet.Toi = dtgChiDinhThuoc[ctToi.Name, index].Value.ToString();
                chitiet.Cachdung = dtgChiDinhThuoc[ctCachDung.Name, index].Value.ToString();
                chitiet.Ghichu = dtgChiDinhThuoc[ctGhiChu.Name, index].Value.ToString();
                if (chitiet.Soluong == 0)
                {
                    CustomMessageBox.MSG_Information_OK("Số lượng không hợp lệ!");
                }
                else
                {
                    if (chitietDAL.Update_Donthuoc(chitiet) < 0)
                    {
                        CustomMessageBox.MSG_Information_OK("Cập nhật đơn thuốc bị lỗi !");
                    }
                }

            }
        }

        private void dtgChiDinhThuoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgChiDinhThuoc.RowCount > 0)
            {
                Update_DonThuoc(e.RowIndex);
            }
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryOutputPrinter, 
                listPrinter.SelectedIndex.ToString());
        }

        private void dtpNgayNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtMaTiepNhan);
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgChiTietNhap.RowCount; i++)
            {
                string _SL = dtgChiTietNhap[SLXuat.Name, i].Value.ToString();
                if (_SL != "" && _SL != "0")
                {
                    Insert_Detail(i);
                }
            }
        }

        private void btnDonThuoc_PrintPreview_Click(object sender, EventArgs e)
        {
            Print_DonThuoc(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
