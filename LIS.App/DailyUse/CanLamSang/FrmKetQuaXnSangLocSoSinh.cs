﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmKetQuaXnSangLocSoSinh : FrmTemplate
    {
        private readonly IPatientInformationService informationService = new PatientInformationService();
        private readonly ITestResultService testService = new TestResultService();
        private readonly ISystemConfigService _iSystconfig = new SystemConfigService();
        private BENHNHAN_TIEPNHAN currentPatient = new BENHNHAN_TIEPNHAN();
        private readonly TestType.EnumTestType[] _arrLoaiXetNghiem = new TestType.EnumTestType[] { TestType.EnumTestType.SLSS};
        private int _countToFocus = 0;
        public FrmKetQuaXnSangLocSoSinh()
        {
            InitializeComponent();
            //lblNgayIn.BackColor = lblPhieuIn.BackColor = TPH.Controls.CommonAppColors.ColorMainAppColor;
            //pnCHonKyTen.BackColor = TPH.Controls.CommonAppColors.ColorMainAppFormColor;
        }

        private void FrmKetQuaXnSangLoc_Load(object sender, EventArgs e)
        {
            ucSearchLookupEditor_TinhGuiMau.Load_Tinh();
            ucSearchLookupEditor_Provice1.Load_Tinh();
            ucSearchLookupEditor_District1.Load_Data(string.Empty);
            ucSearchLookupEditor_Gender1.Load_GioiTinh();
            ucSearchLookupEditor_Object1.Load_DoiTuong();
            ucSearchLookupEditor_NoiGuiMau.Load_DonVi();
            ucSearchLookupEditor_DanhSachDichVu1.Load_DataLSS();
            IUserManagementService userManagement = new UserManagementService();
            var dataKyten = userManagement.GetUsersKyTenCoPhanQuyen("", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), true);
            DataRow dr = dataKyten.NewRow();
            dr["MaNguoiDung"] = string.Empty;
            dr["TenNhanVien"] = "---None---";
            dataKyten.Rows.InsertAt(dr, 0);
            ControlExtension.BindDataToCobobox(dataKyten.Copy(), ref cboNguoiKyTen, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150", txtNguoiKyTen, 1);
            ucKetQuaThuongQuy1.HienThiDanhGiaNhom = true;
            ucKetQuaThuongQuy1._arrLoaiXetNghiem = _arrLoaiXetNghiem;
            ucKetQuaThuongQuy1.CheDoHienThi = 0;
            ucKetQuaThuongQuy1.Load_Config();

            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusColumnChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusColumnChanged;
            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusRowChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusRowChanged;


            ucDanhSachBenhNhanXN1.ArrLoaiXetNghiem = _arrLoaiXetNghiem;
            ucDanhSachBenhNhanXN1.LstDanhSachNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            ucDanhSachBenhNhanXN1.Load_CauHinh();
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            ucDanhSachBenhNhanXN1.DataGridview_DsBenhNhan_CellEnter += UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter;
            ucDanhSachBenhNhanXN1.ShowTuyChon = false;
            ucDanhSachBenhNhanXN1.DoiNhomXN += UcDanhSachBenhNhanXN1_DoiNhomXN;

            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterResult, false);
            dtpNgayInKQ.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNgayInKQ.Checked = false;
            lblNgayIn.Visible = dtpNgayInKQ.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChongioKyTQ;
            Load_DanhSachPhieuInChon();
        }
        private void Load_DanhSachPhieuInChon()
        {
            var data = _iSystconfig.Data_dm_xetnghiem_mauphieuin_tuychon(string.Empty);
            var dr = data.NewRow();
            dr["idmauchon"] = "NONE";
            dr["tenmauchon"] = "PHIẾU MẶC ĐỊNH";
            dr["IdFormSuDung"] = 1;
            data.Rows.InsertAt(dr, 0);
            data = WorkingServices.SearchResult_OnDatatable(data, string.Format("IdFormSuDung = 1"));
            cboPhieuIn.DataSource = data;
            cboPhieuIn.ValueMember = "idmauchon";
            cboPhieuIn.DisplayMember = "tenmauchon";
            cboPhieuIn.SelectedValue = "NONE";
            if (data.Rows.Count == 1)
            {
                cboPhieuIn.Enabled = false;
            }
        }
        private void UcKetQuaThuongQuy1_DataGridview_KetQua_FocusRowChanged(object sender, EventArgs e)
        {
            _countToFocus = 0;
        }

        private void UcKetQuaThuongQuy1_DataGridview_KetQua_FocusColumnChanged(object sender, EventArgs e)
        {
            _countToFocus = 0;
        }
        private void UcDanhSachBenhNhanXN1_DoiNhomXN(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.Load_DSNhomIn(ucDanhSachBenhNhanXN1.LstDanhSachNhom.ToArray());
        }
        private void UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter(object sender, EventArgs e)
        {
            LoadDataInfo(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
            Load_ChiTietXetNghiemThuongQuy();
        }
        private void Load_ChiTietXetNghiemThuongQuy()
        {
            var matiepNhan = ucDanhSachBenhNhanXN1.MaTiepNhanDangChon;
            var ngayTiepNhan = ucDanhSachBenhNhanXN1.NgayTiepNhanDangChon;
            var hisId = ucDanhSachBenhNhanXN1.HisIdDangChon;
            var databinding = ucDanhSachBenhNhanXN1.ThongTinBNDangChon;
            ucKetQuaThuongQuy1.TuTinhToanKetQua = false; 
            ucKetQuaThuongQuy1.XoaThongTinDS();
            ucKetQuaThuongQuy1.CurrentMaTiepNhan = matiepNhan;
            ucKetQuaThuongQuy1.CurrentNgayTiepNhan = ngayTiepNhan;
            ucKetQuaThuongQuy1.hisId = hisId;
            ucKetQuaThuongQuy1.lstDanhSachNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            ucKetQuaThuongQuy1.BindPatientInfo(databinding);
            ucKetQuaThuongQuy1._dtPatient = databinding;
            ucKetQuaThuongQuy1.Load_ChiTietXN(matiepNhan, databinding);
           // ucDanhSachBenhNhanXN1.SetMenuContext(contextMenuCapNhatDangXuLy);
        }
        private void SetLock_Unlock(bool isLock)
        {
            dtpNgayTiepNhan.Enabled = !isLock;
            dtpNgaySinh.Enabled = !isLock;
            dtpTGLayMau.Enabled = !isLock;
            ucSearchLookupEditor_District1.Enabled = !isLock;
            ucSearchLookupEditor_Gender1.Enabled = !isLock;
            ucSearchLookupEditor_NoiGuiMau.Enabled = !isLock;
            ucSearchLookupEditor_Provice1.Enabled = !isLock;
            ucSearchLookupEditor_TinhGuiMau.Enabled = !isLock;
            ucSearchLookupEditor_Object1.Enabled = !isLock;
            numCanNang.Enabled = !isLock;
            numTuoiThai.Enabled = !isLock;
            txtMaBenhNhan.ReadOnly = isLock;
            txtBarcodeLayMau.ReadOnly = isLock;
            txtBarcodeXN.ReadOnly = isLock;
            txtDanToc.ReadOnly = isLock;
            txtDiaChi.ReadOnly = isLock;
            txtDienThoai.ReadOnly = isLock;
            txtNamSinhMe.ReadOnly = isLock;
            txtNguoiLayMau.ReadOnly = isLock;
            txtNhanXet.ReadOnly = isLock;
            txtDeNghi.ReadOnly = isLock;
            txtKetLuan.ReadOnly = isLock;
            chkTraKQSLSSTaiNha.AutoCheck = !isLock;
            ucSearchLookupEditor_DanhSachDichVu1.Enabled = !isLock;
        }
        private void ClearControl()
        {
            dtpNgayTiepNhan.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNgaySinh.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpTGLayMau.Value = CommonAppVarsAndFunctions.ServerTime;
            ucSearchLookupEditor_District1.SelectedValue = null;
            ucSearchLookupEditor_Gender1.SelectedValue = null;
            ucSearchLookupEditor_NoiGuiMau.SelectedValue = null;
            ucSearchLookupEditor_Provice1.SelectedValue = null;
            ucSearchLookupEditor_TinhGuiMau.SelectedValue = null;
            ucSearchLookupEditor_Object1.SelectedValue = null;
            numCanNang.Value = 1;
            numTuoiThai.Value = 1;
            txtMaBenhNhan.Text = string.Empty;
            txtBarcodeLayMau.Text = string.Empty;
            txtBarcodeXN.Text = string.Empty;
            txtDanToc.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtMaTiepNhan.Text = string.Empty;
            txtNamSinhMe.Text = string.Empty;
            txtNguoiLayMau.Text = string.Empty;
            txtNguoiNhap.Text = string.Empty;
            txtNhanXet.Text = string.Empty;
            txtDeNghi.Text = string.Empty;
            txtKetLuan.Text = string.Empty;
            chkTraKQSLSSTaiNha.Checked = false;
            ucSearchLookupEditor_DanhSachDichVu1.SelectedValue = null;
        }
        private void SetDataInformation(BENHNHAN_TIEPNHAN objTiepNhan, BENHNHAN_MAUSANGLOC objSangLoc)
        {
            dtpNgayTiepNhan.Value = objTiepNhan.Ngaytiepnhan;
            ucSearchLookupEditor_District1.SelectedValue = objTiepNhan.Mahuyen;
            ucSearchLookupEditor_Gender1.SelectedValue = objTiepNhan.Gioitinh;
            ucSearchLookupEditor_NoiGuiMau.SelectedValue = objSangLoc.Noiguimau;
            ucSearchLookupEditor_Provice1.SelectedValue = objTiepNhan.Matinh;
            ucSearchLookupEditor_Object1.SelectedValue = objTiepNhan.Doituongdichvu;
            txtMaBenhNhan.Text = objTiepNhan.Mabn;
            txtBarcodeXN.Text = objTiepNhan.Seq;
            txtDiaChi.Text = string.IsNullOrEmpty(objTiepNhan.Diachi) ? (objSangLoc.Diachi ?? string.Empty) : objTiepNhan.Diachi;
            txtMaTiepNhan.Text = objTiepNhan.Matiepnhan;
            txtNguoiNhap.Text = objTiepNhan.Usernhap;
            if (objSangLoc.Ngaysinh != DateTime.MinValue)
                dtpNgaySinh.Value = objSangLoc.Ngaysinh;
            if (objSangLoc.Thoigianlaymau != null)
                dtpTGLayMau.Value = objSangLoc.Thoigianlaymau.Value;
            ucSearchLookupEditor_KhoaPhong.SelectedValue = objSangLoc.Noisinh;
            ucSearchLookupEditor_TinhGuiMau.SelectedValue = objSangLoc.Matinhguimau;
            numCanNang.Value = (decimal)objSangLoc.Cannang;
            ucSearchLookupEditor_DanhSachDichVu1.SelectedValue = objSangLoc.Goixn;
            numTuoiThai.Value = objSangLoc.Tuoithai;
            txtBarcodeLayMau.Text = objSangLoc.Barcodelaymau;
            txtDanToc.Text = objSangLoc.Dantoc;
            txtDienThoai.Text = objSangLoc.Dienthoaididong;
            txtHoTenDemMe.Text = objSangLoc.Hotenme;
            txtNamSinhMe.Text = objSangLoc.Namsinhme.ToString();
            txtNguoiLayMau.Text = objSangLoc.Tennguoilaymau;
            txtTenMe.Text = objSangLoc.Tenme;
            chkTraKQSLSSTaiNha.Checked = objSangLoc.TraKQSLTaiNha;
        }
        private void LoadDataInfo(string maTiepNhan)
        {
            var objTiepNhan = informationService.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });
            var objSangLoc = informationService.Get_ThongTinSLSoSinh(maTiepNhan);
            ClearControl();
            SetLock_Unlock(true);

            SetDataInformation(objTiepNhan, (objSangLoc ?? new BENHNHAN_MAUSANGLOC()));
            currentPatient = objTiepNhan.Copy();
        }
        private bool CheckInThuongQuy(bool print, string maureportChon, bool byList)
        {
            var userSign = cboNguoiKyTen.SelectedIndex > -1 ? cboNguoiKyTen.SelectedValue.ToString().Trim() : string.Empty;
            if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return false;
            }

            progressPrint.Value = 0;
            var printerName = string.Empty;
            if (listPrinter.Items.Count > 0 && string.IsNullOrEmpty(printerName))
            {
                if (listPrinter.SelectedIndex == -1)
                {
                    listPrinter.SelectedIndex = 0;
                }
                progressPrint.Value++;
                printerName = listPrinter.SelectedItem.ToString();
            }

            if (ucKetQuaThuongQuy1.InKetQua(print, userSign, printerName, false, false
                , chkChiInCoKetQua.Checked, progressPrint, maureportChon, string.Empty, string.Empty, (dtpNgayInKQ.Checked ? dtpNgayInKQ.Value : (DateTime?)null), true))
            {
                if (!byList)
                {
                    ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
                    ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
                }
            }
            return true;
        }
        private void btnXacNhanKetQua_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(true, true, false);
            var maureportChon = cboPhieuIn.SelectedIndex > 0 ? cboPhieuIn.SelectedValue.ToString() : string.Empty;
            if (chkInKhiXacNhan.Checked)
            {
                CheckInThuongQuy(true, maureportChon, false);
            }
            else
            {
                ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
                ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            }
        }
        private void btnBoXacNhanKetQua_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(false, true, false);
            ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
        }

        private void btnXemTruocKetQua_Click(object sender, EventArgs e)
        {
            var maureportChon = cboPhieuIn.SelectedIndex > 0 ? cboPhieuIn.SelectedValue.ToString() : string.Empty;
            CheckInThuongQuy(false, maureportChon, false);
        }

        private void btnInKetQua_Click(object sender, EventArgs e)
        {
            var maureportChon = cboPhieuIn.SelectedIndex > 0 ? cboPhieuIn.SelectedValue.ToString() : string.Empty;
            CheckInThuongQuy(true, maureportChon, false);
        }

        private void btnHDNhanh_Click(object sender, EventArgs e)
        {
            var f = new DailyUse.CanLamSang.FrmHuongDan_FormKetQuaTQ();
            f.ShowDialog();
        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true);
        }

        private void btnLuuNX_DeNghi_Click(object sender, EventArgs e)
        {
            informationService.Update_NhanXetDeNghi_SangLoc(txtMaTiepNhan.Text, txtNhanXet.Text
                , CommonAppVarsAndFunctions.UserID, txtDeNghi.Text, CommonAppVarsAndFunctions.UserID, txtKetLuan.Text, CommonAppVarsAndFunctions.UserID);
            txtDeNghi.ReadOnly = true;
            txtNhanXet.ReadOnly = true;
            txtKetLuan.ReadOnly = true;
        }

        private void btnChinhSuaDeNghi_Click(object sender, EventArgs e)
        {
            txtDeNghi.ReadOnly = false;
            txtNhanXet.ReadOnly = false;
            txtKetLuan.ReadOnly = false;
        }
        private void ucDanhSachBenhNhanXN1_InTheoDanhSach_Click(object sender, EventArgs e)
        {
            var maureportChon = cboPhieuIn.SelectedIndex > 0 ? cboPhieuIn.SelectedValue.ToString() : string.Empty;
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("In kết quả theo danh sách đang chọn?"))
            {
                for (int i = 0; i < ucDanhSachBenhNhanXN1.gvDanhSach.RowCount; i++)
                {
                    if (i > 0)
                    {
                        ucDanhSachBenhNhanXN1.gvDanhSach.MoveNext();
                    }
                    else
                        ucDanhSachBenhNhanXN1.gvDanhSach.MoveFirst();

                    if (ucDanhSachBenhNhanXN1.RowIsChecked)
                    {
                        if (CheckInThuongQuy(true, maureportChon, true))
                        {
                            ucDanhSachBenhNhanXN1.UnCheckCurrentRow();
                        }
                        else
                            return;
                    }
                }
                ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            }
        }
        private void txtHoTenDemMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenMe);
        }

        private void txtTenMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtNamSinhMe);
        }
    }
}
