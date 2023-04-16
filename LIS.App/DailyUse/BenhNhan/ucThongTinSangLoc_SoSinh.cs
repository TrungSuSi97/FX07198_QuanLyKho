using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Model;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Services.UserManagement;
using TPH.Report.Constants;
using TPH.Report.Services;
using TPH.Report.Services.Impl;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class ucThongTinSangLoc_SoSinh : UserControl
    {
        private readonly IPatientInformationService informationService = new PatientInformationService();
        private readonly ITestResultService testService = new TestResultService();
        private readonly IMicrobilogyTestResultService _microbilogyTestResultService = new MicrobilogyTestResultService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IUserManagementService _userManagement = new UserManagementService();
        private BENHNHAN_TIEPNHAN currentPatient = new BENHNHAN_TIEPNHAN();
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        public ucThongTinSangLoc_SoSinh()
        {
            InitializeComponent();
        }
        [Category("Custom")]
        private void SetLock_Unlock(bool isLock)
        {
            dtpNgayTiepNhan.Enabled = !isLock;
            dtpNgaySinh.Enabled = !isLock;
            dtpTGLayMau.Enabled = !isLock;
            ucSearchLookupEditor_District1.Enabled = !isLock;
            ucSearchLookupEditor_Gender1.Enabled = !isLock;
            ucSearchLookupEditor_DonViGuiMau.Enabled = !isLock;
            ucSearchLookupEditor_KhoaPhong.Enabled = !isLock;
            ucSearchLookupEditor_Provice1.Enabled = !isLock;
            ucSearchLookupEditor_TinhGuiMau.Enabled = !isLock;
            ucSearchLookupEditor_Object1.Enabled = !isLock;
            numCanNang.Enabled = !isLock;
            numTuoiThai.Enabled = !isLock;
            txtMaBenhNhan.ReadOnly = isLock;
            txtBarcodeLayMau.ReadOnly = isLock;
            txtBarcodeXN.ReadOnly = isLock;
            cboDanToc.Enabled = !isLock;
            txtDiaChi.ReadOnly = isLock;
            txtDienThoai.ReadOnly = isLock;
            txtHoTenDemMe.ReadOnly = isLock;
            txtNamSinhMe.ReadOnly = isLock;
            txtNguoiLayMau.ReadOnly = isLock;
            txtTenMe.ReadOnly = isLock;
            chkTraKQSLSSTaiNha.Enabled = !isLock;
            ucSearchLookupEditor_DanhSachDichVu1.Enabled = !isLock;
        }
        private void ClearControl()
        {
            dtpNgayTiepNhan.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNgaySinh.SetValue(null);
            dtpTGLayMau.SetValue(null);
            ucAddEditControl1.SetStatusButtonNormal();
            ucSearchLookupEditor_District1.SelectedValue = null;
            ucSearchLookupEditor_Gender1.SelectedValue = null;
            ucSearchLookupEditor_DonViGuiMau.SelectedValue = null;
            ucSearchLookupEditor_KhoaPhong.SelectedValue = null;
            ucSearchLookupEditor_Provice1.SelectedValue = null;
            ucSearchLookupEditor_TinhGuiMau.SelectedValue = null;
            ucSearchLookupEditor_Object1.SelectedValue = null;
            numTuoiThai.Value = 1;
            txtMaBenhNhan.Text = string.Empty;
            txtBarcodeLayMau.Text = string.Empty;
            txtBarcodeXN.Text = string.Empty;
            cboDanToc.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtHoTenDemMe.Text = string.Empty;
            txtMaTiepNhan.Text = string.Empty;
            txtNamSinhMe.Text = string.Empty;
            txtNguoiLayMau.Text = string.Empty;
            txtNguoiNhap.Text = string.Empty;
            txtTenMe.Text = string.Empty;
            chkTraKQSLSSTaiNha.Checked = false;
            ucSearchLookupEditor_DanhSachDichVu1.SelectedValue = null;
        }
        private void LoadDataInfo(string maTiepNhan)
        {
            var objTiepNhan = informationService.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });
            var objSangLoc = informationService.Get_ThongTinSLSoSinh(maTiepNhan);
            ClearControl();
            SetLock_Unlock(true);
            Check_Enable();
            SetDataInformation(objTiepNhan, objSangLoc);
            currentPatient = objTiepNhan.Copy();
        }
        private void GetDataInformation(ref BENHNHAN_TIEPNHAN objTiepNhan, ref BENHNHAN_MAUSANGLOC objSangLoc)
        {
            objTiepNhan.Ngaytiepnhan = dtpNgayTiepNhan.Value;
            objTiepNhan.Mahuyen = int.Parse(ucSearchLookupEditor_District1.SelectedValue == null ? "0" : ucSearchLookupEditor_District1.SelectedValue.ToString());
            objTiepNhan.Gioitinh = ucSearchLookupEditor_Gender1.SelectedValue.ToString();
            objTiepNhan.Madonvi = (ucSearchLookupEditor_KhoaPhong.SelectedValue ?? (object)string.Empty).ToString();
            objTiepNhan.Matinh = int.Parse(ucSearchLookupEditor_Provice1.SelectedValue == null ? "0" : ucSearchLookupEditor_Provice1.SelectedValue.ToString());
            objTiepNhan.Doituongdichvu = ucSearchLookupEditor_Object1.SelectedValue.ToString();
            objTiepNhan.Mabn = txtMaBenhNhan.Text;
            objTiepNhan.Seq = txtBarcodeXN.Text;
            objTiepNhan.Matiepnhan = txtMaTiepNhan.Text;
            objTiepNhan.Usernhap = txtNguoiNhap.Text;
            objTiepNhan.Sinhnhat = dtpNgaySinh.GetValue();
            objTiepNhan.Tuoi = dtpNgaySinh.GetValue() == null ? DateTime.Now.Year: ((DateTime)dtpNgaySinh.GetValue()).Year;
            objTiepNhan.Usercapnhat = CommonAppVarsAndFunctions.UserID;
            objTiepNhan.Tenbn = string.Format("{0} {1}", txtHoTenDemMe.Text.Trim(), txtTenMe.Text.Trim());
            objSangLoc.Ngaysinh = (DateTime)dtpNgaySinh.GetValue();
            objSangLoc.Thoigianlaymau = dtpTGLayMau.GetValue();
            objSangLoc.Noisinh = (ucSearchLookupEditor_KhoaPhong.SelectedValue ?? (object)string.Empty).ToString();
            objSangLoc.Matinhguimau = int.Parse((ucSearchLookupEditor_TinhGuiMau.SelectedValue ?? (object)"0").ToString());
            objSangLoc.Cannang = (float)numCanNang.Value;
            objSangLoc.Tuoithai = (int)numTuoiThai.Value;
            objSangLoc.Barcodelaymau = txtBarcodeLayMau.Text;
            objSangLoc.Dantoc = cboDanToc.Text;
            objSangLoc.Dienthoaididong = txtDienThoai.Text;
            objSangLoc.Hotenme = txtHoTenDemMe.Text;
            objSangLoc.Namsinhme = int.Parse(string.IsNullOrEmpty(txtNamSinhMe.Text) ? "0" : txtNamSinhMe.Text);
            objSangLoc.Tennguoilaymau = txtNguoiLayMau.Text;
            objSangLoc.Noiguimau = (ucSearchLookupEditor_DonViGuiMau.SelectedValue ?? (object)string.Empty).ToString();
            objSangLoc.Diachi = txtDiaChi.Text;
            objTiepNhan.Diachi = txtDiaChi.Text;
            objSangLoc.Tenme = txtTenMe.Text;
            objSangLoc.Sosinh = true;
            objSangLoc.TraKQSLTaiNha = chkTraKQSLSSTaiNha.Checked;

        }
        private void SetDataInformation(BENHNHAN_TIEPNHAN objTiepNhan, BENHNHAN_MAUSANGLOC objSangLoc)
        {
            if (string.IsNullOrEmpty(objTiepNhan.Matiepnhan))
                return;
            dtpNgayTiepNhan.Value = objTiepNhan.Ngaytiepnhan;
            ucSearchLookupEditor_Gender1.SelectedValue = objTiepNhan.Gioitinh;
            ucSearchLookupEditor_Provice1.SelectedValue = objTiepNhan.Matinh;
            ucSearchLookupEditor_District1.SelectedValue = objTiepNhan.Mahuyen;
            ucSearchLookupEditor_DonViGuiMau.SelectedValue = objSangLoc.Noiguimau;
            ucSearchLookupEditor_Object1.SelectedValue = objTiepNhan.Doituongdichvu;
            txtMaBenhNhan.Text = objTiepNhan.Mabn;
            txtBarcodeXN.Text = objTiepNhan.Seq;
            txtDiaChi.Text = string.IsNullOrEmpty(objTiepNhan.Diachi) ? (objSangLoc.Diachi ?? string.Empty) : objTiepNhan.Diachi;
            txtMaTiepNhan.Text = objTiepNhan.Matiepnhan;
            txtNguoiNhap.Text = objTiepNhan.Usernhap;
            ucSearchLookupEditor_KhoaPhong.SelectedValue = objTiepNhan.Madonvi;
            dtpNgaySinh.SetValue(objSangLoc.Ngaysinh);
            if (objSangLoc.Thoigianlaymau != null)
            {
                dtpTGLayMau.SetValue(objSangLoc.Thoigianlaymau);
            }
        
            ucSearchLookupEditor_TinhGuiMau.SelectedValue = objSangLoc.Matinhguimau;
            numCanNang.Value = (decimal)objSangLoc.Cannang;
            ucSearchLookupEditor_DanhSachDichVu1.SelectedValue = objSangLoc.Goixn;
            numTuoiThai.Value = objSangLoc.Tuoithai;
            txtBarcodeLayMau.Text = objSangLoc.Barcodelaymau;
            cboDanToc.Text = objSangLoc.Dantoc;
            txtDienThoai.Text = objSangLoc.Dienthoaididong;
            txtHoTenDemMe.Text = objSangLoc.Hotenme;
            txtNamSinhMe.Text = objSangLoc.Namsinhme.ToString();
            txtNguoiLayMau.Text = objSangLoc.Tennguoilaymau;
            txtTenMe.Text = objSangLoc.Tenme;
            chkTraKQSLSSTaiNha.Checked = objSangLoc.TraKQSLTaiNha;
        }
        private void Set_AddNewMode()
        {
            if (txtBarcodeXN.ForeColor == Color.Red)
            {
                CustomMessageBox.MSG_Information_OK("Bạn đang trong chế độ nhập mới!");
                txtHoTenDemMe.Focus();
            }
            else
            {
                gvPatient.FindFilterText = string.Empty;
                ClearControl();
                SetLock_Unlock(false);
                gcPatient.Enabled = false;
                dtpNgayTiepNhan.Value = C_Ultilities.ServerDate();
                if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu))
                {
                    ucSearchLookupEditor_Object1.SelectedValue = "TTSLCT";
                    ucSearchLookupEditor_DonViGuiMau.SelectedValue = "PSCT";
                    var idTinhGuiMau = ucSearchLookupEditor_TinhGuiMau.GetObjectIdByName("CẦN THƠ");
                    if (!string.IsNullOrEmpty(idTinhGuiMau))
                        ucSearchLookupEditor_TinhGuiMau.SelectedValue = int.Parse(idTinhGuiMau);
                    if (CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu.Equals(SystemStypeConstant.AutoBarcode.ToString()))
                    {
                        if (string.IsNullOrEmpty(txtBarcodeXN.Text))
                        {
                            txtBarcodeXN.Text = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpNgayTiepNhan.Value);
                            txtMaTiepNhan.Text = ConfigurationDetail.Get_MaTiepNhan(txtBarcodeXN.Text, dtpNgayTiepNhan.Value);
                        }
                        txtBarcodeXN.ReadOnly = true;
                        txtBarcodeLayMau.Focus();
                    }
                    else
                    {
                        txtBarcodeXN.ReadOnly = false;
                        txtBarcodeLayMau.Focus();
                    }
                }
                else
                {
                    txtBarcodeXN.Focus();
                }
                txtNguoiNhap.Text = CommonAppVarsAndFunctions.UserID;
                txtBarcodeXN.ForeColor = Color.Red;
            }
        }
        private string Get_MaBenhNhan()
        {
            if (txtBarcodeXN.ForeColor != Color.Red)
                return string.Empty;
            var currentPidSeq = informationService.Get_MaBnNhanGanNhat();
            return CommonAppVarsAndFunctions.sysConfig.Get_MaBenhNhan(dtpNgayTiepNhan.Value, currentPidSeq);
        }
        private void SavePatient()
        {
            if (string.IsNullOrEmpty(txtBarcodeLayMau.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã xét nghiệm.");
                txtBarcodeLayMau.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtMaBenhNhan.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã bệnh nhân.");
                txtMaBenhNhan.Focus();
                return;
            }
            else if (ucSearchLookupEditor_Object1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn chương trình sàng lọc.");
                ucSearchLookupEditor_Object1.Focus();
                return;
            }
            else if (ucSearchLookupEditor_DanhSachDichVu1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn gói xét nghiệm.");
                ucSearchLookupEditor_DanhSachDichVu1.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtHoTenDemMe.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập họ và tên đệm.");
                txtHoTenDemMe.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtTenMe.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập tên.");
                txtTenMe.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtNamSinhMe.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập năm sinh.");
                txtNamSinhMe.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập địa chỉ.");
                txtDiaChi.Focus();
                return;
            }
            else if (ucSearchLookupEditor_Provice1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn Tỉnh/TP.");
                ucSearchLookupEditor_Provice1.Focus();
                return;
            }
            else if (ucSearchLookupEditor_District1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn Quận/Huyện.");
                ucSearchLookupEditor_District1.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập số điện thoại.");
                txtDienThoai.Focus();
                return;
            }
            else if (ucSearchLookupEditor_Gender1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn giới tính.");
                ucSearchLookupEditor_Gender1.Focus();
                return;
            }
            else if (ucSearchLookupEditor_Gender1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn giới tính.");
                ucSearchLookupEditor_Gender1.Focus();
                return;
            }
            else if (dtpNgaySinh.GetValue() == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập ngày giờ sinh.");
                dtpNgaySinh.Focus();
                return;
            }
            else if (dtpNgaySinh.GetValue() >= DateTime.Now)
            {
                CustomMessageBox.MSG_Information_OK("Ngày giờ sinh không hợp lệ.");
                dtpNgaySinh.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(cboDanToc.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập dân tộc.");
                cboDanToc.Focus();
                return;
            }
            else if (((int)numTuoiThai.Value) == 0)
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập tuổi thai.");
                numTuoiThai.Focus();
                return;
            }
            else if (((int)numCanNang.Value) == 0)
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập cân nặng.");
                numCanNang.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtNguoiLayMau.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập người lấy mẫu.");
                txtNguoiLayMau.Focus();
                return;
            }
            else if (dtpTGLayMau.GetValue() == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập thời gian lấy mẫu.");
                dtpTGLayMau.Focus();
                return;
            }
            else if (dtpTGLayMau.GetValue() > DateTime.Now)
            {
                CustomMessageBox.MSG_Information_OK("Thời gian lấy mẫu không hợp lệ.");
                dtpTGLayMau.Focus();
                return;
            }
            else if (ucSearchLookupEditor_DonViGuiMau.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn đơn vị.");
                ucSearchLookupEditor_DonViGuiMau.Focus();
                return;
            }
            else if (ucSearchLookupEditor_KhoaPhong.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn khoa phòng.");
                ucSearchLookupEditor_KhoaPhong.Focus();
                return;
            }
            else if (ucSearchLookupEditor_TinhGuiMau.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn Tỉnh/TP gửi mẫu.");
                ucSearchLookupEditor_TinhGuiMau.Focus();
                return;
            }
            else
            {
                var currentGoiXn = string.Empty;
                var objTiepNhan = (string.IsNullOrEmpty(txtMaTiepNhan.Text) ? new BENHNHAN_TIEPNHAN() : informationService.Get_Info_BenhNhan_TiepNhan(txtMaTiepNhan.Text, new string[] { }));
                var objSangLoc = (string.IsNullOrEmpty(txtMaTiepNhan.Text) ? new BENHNHAN_MAUSANGLOC() : informationService.Get_ThongTinSLSoSinh(txtMaTiepNhan.Text)) ?? new BENHNHAN_MAUSANGLOC();
                if (!string.IsNullOrEmpty(objSangLoc.Goixn))
                    currentGoiXn = objSangLoc.Goixn;

                GetDataInformation(ref objTiepNhan, ref objSangLoc);
                objTiepNhan.Nguonnhap = InputSourceEnum.SangLocSoSinh.ToString();
                objTiepNhan.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(txtBarcodeXN.Text, dtpNgayTiepNhan.Value);
                objTiepNhan.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
                objSangLoc.Matiepnhan = objTiepNhan.Matiepnhan;
                objSangLoc.Goixn = (ucSearchLookupEditor_DanhSachDichVu1.SelectedValue ?? (object)string.Empty).ToString();

                if (txtBarcodeXN.ForeColor == Color.Red)
                {
                    informationService.Insert_BenhNhan_TiepNhan(objTiepNhan, true);
                    informationService.Insert_ThongTinSLSoSinh(objSangLoc);
                }
                else
                {
                    informationService.Update_BenhNhan_TiepNhan(objTiepNhan);
                    informationService.Update_ThongTinSLSoSinh(objSangLoc);
                }
                if (!string.IsNullOrEmpty(currentGoiXn) && !currentGoiXn.Equals(objSangLoc.Goixn, StringComparison.OrdinalIgnoreCase))
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Thay đổi gói xét nghiệm?\nLưu ý: Các xét nghiệm của gói trước sẽ bị xóa!"))
                    {
                        //Xóa gói sàng lọc trước
                        if (!testService.Check_HaveResult_For_XNChinh(objTiepNhan.Matiepnhan, currentGoiXn))
                        {
                            testService.Delete_ChiDinhCLS_XN(objTiepNhan.Matiepnhan, string.Empty, currentGoiXn, CommonAppVarsAndFunctions.UserID, false);
                        }
                    }
                }
                InsertDichVuXn(objTiepNhan, objSangLoc.Goixn, ProfileTestContant.ProfileChar, objSangLoc.Goixn);
                testService.UpdateProfileID(objTiepNhan.Matiepnhan, objSangLoc.Goixn);

                txtBarcodeXN.BackColor = Color.Empty;
                txtBarcodeXN.ForeColor = Color.Empty;
                gcPatient.Enabled = true;
                Get_DanhSach_TiepNhan();
                gvPatient.FindFilterText = objTiepNhan.Matiepnhan;
                LoadDataInfo(objTiepNhan.Matiepnhan);
                ucAddEditControl1.SetStatusButtonNormal();
                //btnThemChiDinh.Focus();
            }
        }
        
        private void Get_DanhSach_TiepNhan()
        {
            ucChiTietChiDinh1.gcChiDinh.DataSource = null;
            gvPatient.FocusedRowChanged -= GvPatient_FocusedRowChanged;
            gvPatient.FocusedColumnChanged -= GvPatient_FocusedColumnChanged;
            var data = informationService.Data_DSTreSoSinhSangLoc(dtpNgayTiepNhan_DS.Value, dtpNgayTiepNhan_DS.Value);
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            gcPatient.DataSource = bs;
            gvPatient.FocusedRowChanged += GvPatient_FocusedRowChanged;
            gvPatient.FocusedColumnChanged += GvPatient_FocusedColumnChanged;
            Load_ThongTinVaChiDinh();
        }
        private void Load_ThongTinVaChiDinh()
        {
            if (gvPatient.FocusedRowHandle > -1)
            {
                var maTiepNhan = gvPatient.GetFocusedRowCellValue(colMaTiepNhan);
                if (maTiepNhan != null)
                {
                    LoadDataInfo(maTiepNhan.ToString());
                    ucChiTietChiDinh1.Get_ChiTietChiDinh(maTiepNhan.ToString(), null);
                }
            }
        }
        private void GvPatient_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_ThongTinVaChiDinh();
        }

        private void GvPatient_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_ThongTinVaChiDinh();
        }
        private void Delete_Patient()
        {
            if (currentPatient == null) return;
            if (!CheckAllowAction())
            {
                CustomMessageBox.MSG_Information_OK("Không thể xóa khi chỉ định đã được nhận mẫu!");
                return;
            }
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeletePatient))
            {
                if (testService.Check_HaveResult_XN(currentPatient.Matiepnhan, string.Empty))
                {
                    if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeleteOrderAndPatientWithResult))
                    {
                        CustomMessageBox.MSG_Waring_OK("Bệnh nhân đã có KQ.\nBạn không thể xóa bệnh nhân này!");
                        return;
                    }
                }
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Bạn không thể xóa thông tin bệnh nhân.");
                return;
            }

            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xoá bệnh nhân: " + txtMaTiepNhan.Text + " ?")) return;
            if (ucChiTietChiDinh1.XoaChiDinh(false, true))
            {
                informationService.Delete_BenhNhan_TiepNhan(currentPatient.Matiepnhan, CommonAppVarsAndFunctions.UserID);
                ClearControl();
                SetLock_Unlock(true);
                Get_DanhSach_TiepNhan();
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Bạn không thể xóa thông tin bệnh nhân do không thể xóa hết các chỉ định.");
                return;
            }
        }
        private void Check_Enable()
        {
            var allow = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionInsertPatient);
            ucAddEditControl1.btnAdd.Enabled = allow;

            ucAddEditControl1.btnEdit.Enabled = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionEditPatient);
            ucAddEditControl1.btnDelete.Enabled = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeletePatient);
            ucChiTietChiDinh1.HienThiXoaChiDinh = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeleteOrder);
        }
        private void ucAddEditControl1_ButtonAddClick(object sender, EventArgs e)
        {
            Set_AddNewMode();
        }

        private void txtBarcodeXN_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            if (e.KeyChar == (char)Keys.Enter && txtBarcodeXN.ReadOnly == false)
            {
                if (txtBarcodeXN.ForeColor == Color.Red && !string.IsNullOrEmpty(txtBarcodeXN.Text))
                {
                    txtMaTiepNhan.Text = ConfigurationDetail.Get_MaTiepNhan(txtBarcodeXN.Text, dtpNgayTiepNhan.Value);
                    txtMaBenhNhan.Text = Get_MaBenhNhan();
                    txtBarcodeLayMau.Focus();
                    e.Handled = true;
                }
            }
        }

        private void ucAddEditControl1_ButtonCancelClick(object sender, EventArgs e)
        {
            if (txtBarcodeXN.ForeColor == Color.Red)
            {
                ClearControl();
                txtBarcodeXN.ForeColor = Color.Black;
                gcPatient.Enabled = true;

                Get_DanhSach_TiepNhan();
            }
            else if(!string.IsNullOrEmpty(txtMaTiepNhan.Text))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy thao tác chỉnh sửa thông tin ?"))
                {
                    LoadDataInfo(txtMaTiepNhan.Text);
                }
            }
        }
        private void ucSearchLookupEditor_NhomDichVu1_EditValueChanged(object sender, EventArgs e)
        {
            Load_DanhmucDichVu();
        }
        private void Load_DanhmucDichVu()
        {

            var loaiDichVu = ServiceType.ClsXetNghiem.ToString();
            var nhomdichVu = string.Empty;

            var doiTuongDv = (ucSearchLookupEditor_Object1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_Object1.SelectedValue.ToString());
            var sex = (ucSearchLookupEditor_Gender1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_Gender1.SelectedValue.ToString());
            ucSearchLookupEditor_DanhSachDichVu1.Load_DataLSS();
            ucSearchLookupEditor_DanhSachDichVu1.CatchEnterKey = true;
            ucSearchLookupEditor_DanhSachDichVu1.CatchTabKey = true;
            ucSearchLookupEditor_DanhSachDichVu1.ControlBack = ucSearchLookupEditor_Object1;
            ucSearchLookupEditor_DanhSachDichVu1.ControlNext = txtHoTenDemMe;
        }
        private void InsertItem()
        {
            //if (txtBarcodeXN.ForeColor == Color.Red && CommonAppVarsAndFunctions.sysConfig.BenhNhanTuLuuThongTinNhapMoi)
            //{
            //    SavePatient();
            //}
            //else if (ucAddEditControl1.btnSave.Enabled)
            //{
            //    CustomMessageBox.MSG_Information_OK("Hãy lưu thông tin bệnh nhân trước khi nhập chỉ định!");
            //    ucAddEditControl1.Focus();
            //    ucAddEditControl1.btnSave.Focus();
            //}

            if (ucSearchLookupEditor_DanhSachDichVu1.SelectedValue == null)
                return;

            //1: madichvu
            //2: profile
            var maloaidichvu = ServiceType.ClsXetNghiem.ToString();
            var madichvu = ucSearchLookupEditor_DanhSachDichVu1.SelectedValue.ToString();
            //Xử lý insert bộ dịch vụ

            InsertDichVuXn(currentPatient, madichvu, ProfileTestContant.ProfileChar, string.Empty);

            if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianNhapCD)
            {
                informationService.Update_ThoiGianThucHienXN(currentPatient.Matiepnhan);
                informationService.Update_ThoiGianThucHienXN_Nhom(currentPatient.Matiepnhan, (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
            }
            //if (!string.IsNullOrEmpty(currentPatient.Doituongdichvu))
            //{
            //    ucChiTietChiDinh1.Get_ChiTietChiDinh(currentPatient.Matiepnhan, null);
            //}
            informationService.Update_TrangThaiLayMau(currentPatient.Matiepnhan);
        }
        private bool InsertDichVuXn(BENHNHAN_TIEPNHAN objBenhnhanTiepnhan, string maxn, string profileChar, string profileId)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                string _sampleID = objBenhnhanTiepnhan.Matiepnhan;
                string _maxn = maxn;
                bool profile = (profileChar == ProfileTestContant.ProfileChar);
                if (testService.CheckTonTaiChiDinh(_sampleID, _maxn, profile))
                {
                    CustomMessageBox.CloseAlert();
                    CustomMessageBox.MSG_Information_OK(string.Format("{0} [{1}] đã được nhập", (profile ? "Profile" : "Chỉ định"), _maxn));
                    return false;
                }

                var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
                objChiDinh.maxn = _maxn;
                objChiDinh.xetnghiemProfile = profile;
                objChiDinh.Dongia = -1;
                objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;
                objChiDinh.maprofile = profileId;
                return testService.InsertTest(objBenhnhanTiepnhan, objChiDinh);
            }
            else
                CustomMessageBox.MSG_Question_YesNo_GetYes("Chưa nhập đối tượng bệnh nhân.");

            return false;
        }
        private void ucSearchLookupEditor_DanhSachDichVu1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter && ucSearchLookupEditor_DanhSachDichVu1.SelectedValue != null)
            //{
            //    InsertItem();
            //    e.Handled = true;
            //}
        }
        public void Load_Config()
        {
            SetLock_Unlock(true);
            ucSearchLookupEditor_TinhGuiMau.Load_Tinh();
            ucSearchLookupEditor_Provice1.Load_Tinh();
            ucSearchLookupEditor_Provice1.SeletedValueChanged += UcSearchLookupEditor_Provice1_SeletedValueChanged;
            ucSearchLookupEditor_District1.Load_Data(string.Empty);
            ucSearchLookupEditor_Gender1.Load_GioiTinh();
           // ucSearchLookupEditor_NhomDichVu1.Load_DanhMucNhomDichVu(ServiceType.ClsXetNghiem.ToString());
           // ucSearchLookupEditor_NhomDichVu1.NhomChiDinh_EditValueChanged += ucSearchLookupEditor_NhomDichVu1_EditValueChanged;
            Load_DanhmucDichVu();
            ucSearchLookupEditor_Object1.Load_DoiTuong();
            ucSearchLookupEditor_DonViGuiMau.Load_DonVi(string.Empty);
            ucSearchLookupEditor_KhoaPhong.Load_DonVi();
            ucSearchLookupEditor_BSChiDinh.Load_BacSi();

            Get_DanhSach_TiepNhan();
            objKhuLayMau = sysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);
            dtpNgayTiepNhan_DS.ValueChanged += DtpNgayTiepNhan_DS_ValueChanged;
            Check_Enable();
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterReturnResultTime, false);
            logo = sysConfig.Load_Logo("XN");
            listPrinter.SelectedItem = _registryExtension.ReadRegistry(UserConstant.RegistryPrinterReturnResultTimeSLSS);
            listPrinter.SelectedIndexChanged += listPrinter_SelectedIndexChanged;
        }

        private void UcSearchLookupEditor_Provice1_SeletedValueChanged(object sender, EventArgs e)
        {
            ucSearchLookupEditor_District1.Load_Data((ucSearchLookupEditor_Provice1.SelectedValue ?? (object)string.Empty).ToString());
        }

        private void DtpNgayTiepNhan_DS_ValueChanged(object sender, EventArgs e)
        {
            Get_DanhSach_TiepNhan();
        }

        private void ucAddEditControl1_ButtonSaveClick(object sender, EventArgs e)
        {
            SavePatient();
        }
        private bool CheckAllowAction()
        {
            var data = informationService.Data_ChiDinhDaLayMau(txtMaTiepNhan.Text);
            if (data.Rows.Count > 0)
            {
                var dtNhanMau = WorkingServices.SearchResult_OnDatatable(data, string.Format("DaNhanMau = true and LoaiXetNghiem in({0})", (int)TestType.EnumTestType.SLSS));
                if (dtNhanMau.Rows.Count > 0 && !CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionEditNewbornInfoAfterGet))
                {
                   return false;
                }
            }
            return true;
        }
        private void ucAddEditControl1_ButtonEditClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaTiepNhan.Text))
            {
                //Kiểm tra tình trạng nhận mãu
                bool allow = CheckAllowAction();
                if (allow)
                {
                    SetLock_Unlock(false);
                    txtBarcodeXN.ReadOnly = true;
                    //if(!string.IsNullOrEmpty(currentPatient.Sophieuyeucau))
                    //{
                    if (ucSearchLookupEditor_Object1.SelectedValue == null)
                        ucSearchLookupEditor_Object1.SelectedValue = "TTSLCT";
                    else if (!string.IsNullOrEmpty(currentPatient.Sophieuyeucau)
                        && !ucSearchLookupEditor_Object1.SelectedValue.ToString().Equals("QG")
                        && !ucSearchLookupEditor_Object1.SelectedValue.ToString().Equals("TTSLCT")
                        && !ucSearchLookupEditor_Object1.SelectedValue.ToString().Equals("XHH"))
                    {
                        ucSearchLookupEditor_Object1.SelectedValue = "TTSLCT";
                    }
                    if (ucSearchLookupEditor_DonViGuiMau.SelectedValue == null)
                        ucSearchLookupEditor_DonViGuiMau.SelectedValue = "PSCT";
                    var currentID = int.Parse((ucSearchLookupEditor_TinhGuiMau.SelectedValue ?? (object)"0").ToString());
                    if (currentID == 0)
                    {
                        var idTinhGuiMau = ucSearchLookupEditor_TinhGuiMau.GetObjectIdByName("CẦN THƠ");
                        if (!string.IsNullOrEmpty(idTinhGuiMau))
                            ucSearchLookupEditor_TinhGuiMau.SelectedValue = int.Parse(idTinhGuiMau);
                    }
                    //  }
                    txtHoTenDemMe.Focus();
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Bạn không thể sửa thông tin đã nhận mẫu.");
                    ucAddEditControl1.SetStatusButtonNormal();
                    Check_Enable();
                }
            }
        }

        private void ucAddEditControl1_ButtonDeleteClick(object sender, EventArgs e)
        {
            Delete_Patient();
        }

        private void txtBarcodeLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtMaBenhNhan);
        }

        private void numTuoiThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numCanNang);
        }

        private void numCanNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtNguoiLayMau);
        }
        private void dtpNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboDanToc);
        }

        private void txtDanToc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numTuoiThai);
        }

        private void txtHoTenMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenMe);
        }

        private void txtNamSinhMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            ControlExtension.LeaveFocusNext(e, txtDiaChi);
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_Provice1);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_Gender1);
        }

        private void dtpTGLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_KhoaPhong);
        }

        private void txtNguoiLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, dtpTGLayMau);
        }

        private void txtDiaChiNoiGuiMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_TinhGuiMau);
        }

        private void btnLoadDanhSachTiepNhan_Click(object sender, EventArgs e)
        {
            Get_DanhSach_TiepNhan();
        }

        private void txtNamSinhMe_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNamSinhMe.Text))
            {
                int _a = int.Parse(txtNamSinhMe.Text);
                if (_a < 1000)
                {
                    _a = dtpNgayTiepNhan.Value.Year - _a;
                }
                txtNamSinhMe.Text = _a.ToString();
            }
        }
        private void btnThemChiDinh_Click(object sender, EventArgs e)
        {
            InsertItem();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            var dataGet = Excel.ExportToExcel.ReadAndGetData();
            if (dataGet != null)
            {
                var dataResult = dataGet.Clone();
                var f = new FrmChonLoaiKQSL();
                f.ShowDialog();
                if (f.objReturn != null && f.lstObjMapping != null)
                {
                    var objLoaiImport = f.objReturn;
                    if (objLoaiImport.Noidong && !string.IsNullOrEmpty(objLoaiImport.Cotindexnoidong))
                    {
                        var columnName = (objLoaiImport.Loaiimport == 1 ? string.Format("Column{0}", objLoaiImport.Cotindexnoidong) : objLoaiImport.Cotindexnoidong);
                        var distinctIndex = dataGet.DefaultView.ToTable(true, columnName);
                        if (distinctIndex.Rows.Count > 0)
                        {
                            foreach (DataRow drMerge in distinctIndex.Rows)
                            {
                                var valueFind = drMerge[columnName].ToString();
                                var dataFound = WorkingServices.SearchResult_OnDatatable(dataGet, string.Format("{0} = '{1}'", columnName, valueFind));

                                if (dataFound.Rows.Count > 0)
                                {
                                    var drR = dataResult.NewRow();
                                    foreach (DataRow drF in dataFound.Rows)
                                    {
                                        foreach (DataColumn dtc in dataGet.Columns)
                                        {
                                            if (string.IsNullOrEmpty(drR[dtc.ColumnName].ToString()))
                                                drR[dtc.ColumnName] = drF[dtc.ColumnName];
                                            else
                                            {
                                                var currenntVar = drR[dtc.ColumnName].ToString();
                                                var newVar = drF[dtc.ColumnName].ToString();
                                                if (!string.IsNullOrEmpty(newVar))
                                                {
                                                    if (!currenntVar.Equals(newVar, StringComparison.OrdinalIgnoreCase))
                                                    {
                                                        drR[dtc.ColumnName] = string.Format("{0}|{1}", currenntVar, newVar);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    dataResult.Rows.Add(drR);
                                }
                            }
                        }
                    }
                    else
                        dataResult = dataGet;
                    var dataDmXetNghiem = sysConfig.Data_dm_xetnghiem(string.Empty, false, string.Empty);
                    var dataUser = _userManagement.GetAllUsers();
                    dtpNgayTiepNhan.Value = CommonAppVarsAndFunctions.ServerTime;
                    foreach (DataRow dr in dataResult.Rows)
                    {
                        GetDataInformationByImport_Automap(dr, dataDmXetNghiem, dataUser, f.objReturn, f.lstObjMapping, f.IdMay);
                    }
                    CustomMessageBox.CloseAlert();
                    Get_DanhSach_TiepNhan();
                }
            }
        }
        private string GetDataWithMapping(DataRow dr, int LoaiImport, List<DM_LOAIIMPORT_MAPPING> lstobjMapping, string lisColumn)
        {
            var finalString = string.Empty;
            var colInfo = lstobjMapping.Where(x => x.Liscolumn.Equals(lisColumn));
            if (colInfo.Any())
            {
                var mappingCol = colInfo.First().Excelcolumn.Split(new string[] { "[&&]" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var col in mappingCol)
                {
                    finalString += GetDataFromRow(dr, LoaiImport, col.Trim());
                }
            }
            return finalString;
        }
        private string GetDataTestMappingWithResult(DataRow dr, int LoaiImport, List<DM_LOAIIMPORT_MAPPING> lstobjMapping, string lisTestCode)
        {
            var finalString = string.Empty;
            var colInfo = lstobjMapping.Where(x => x.Maxnlis.Equals(lisTestCode));
            if (colInfo.Any())
            {
                var mappingCol = colInfo.First().Excelcolumn.Split(new string[] { "[&&]" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var col in mappingCol)
                {
                    if (!string.IsNullOrEmpty(finalString))
                        finalString += " ";
                    finalString += GetDataFromRow(dr, LoaiImport, col.Trim()).Trim();
                }
            }
            return finalString;
        }
        private string GetDataTestMappingWithNote(DataRow dr, int LoaiImport, List<DM_LOAIIMPORT_MAPPING> lstobjMapping, string lisTestCode)
        {
            var finalString = string.Empty;
            var colInfo = lstobjMapping.Where(x => x.Maxnlis.Equals(lisTestCode));
            if (colInfo.Any())
            {
                if (!string.IsNullOrEmpty(colInfo.First().Ketluancuaxn))
                {
                    var mappingCol = colInfo.First().Ketluancuaxn.Split(new string[] { "[&&]" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var col in mappingCol)
                    {
                        if (!string.IsNullOrEmpty(finalString))
                            finalString += " ";
                        finalString += GetDataFromRow(dr, LoaiImport, col.Trim()).Trim();
                    }
                }
            }
            return finalString;
        }
        private string GetDataFromRow(DataRow dr, int LoaiImport, string mappingCol)
        {
            if (!string.IsNullOrEmpty(mappingCol))
            {
                if (mappingCol.Contains("[\"") && mappingCol.Contains("\"]"))
                    return mappingCol.Replace("[\"", "").Replace("\"]", "");
                else
                {
                    var indexget = -1;
                    var formatString = string.Empty;
                    if (mappingCol.Contains("[{") && mappingCol.Contains("}]"))
                    {
                        var arr = mappingCol.Split(new string[] { "[{", "}]" }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length == 2)
                        {
                            formatString = arr[1];
                            mappingCol = arr[0];
                        }
                        else
                            return string.Empty;
                    }
                    if (mappingCol.Contains("[") && mappingCol.Contains("]"))
                    {
                        var arr = mappingCol.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length == 2)
                        {
                            indexget = int.Parse(arr[1]);
                            mappingCol = arr[0];
                        }
                        else
                            return string.Empty;
                    }
                    var tempValue = string.Empty;
                    if (LoaiImport == 0)
                    {
                        if (dr.Table.Columns.Contains(mappingCol))
                            tempValue = dr[mappingCol].ToString();
                    }
                    else if (WorkingServices.IsNumeric(mappingCol))
                    {
                        if (int.Parse(mappingCol) < dr.Table.Columns.Count)
                            tempValue = dr[int.Parse(mappingCol)].ToString();
                    }

                    if (!string.IsNullOrEmpty(tempValue))
                    {
                        tempValue = (indexget > -1 ? tempValue[indexget].ToString() : tempValue);
                        if (!string.IsNullOrEmpty(formatString))
                        {
                            if (formatString.Equals("yyyyMMdd"))
                                tempValue = string.Format("{0}/{1}/{2}", tempValue.Substring(4, 2), tempValue.Substring(6, 2), tempValue.Substring(0, 4));
                            else if (formatString.Equals("ddMMyyyy"))
                                tempValue = string.Format("{0}/{1}/{2}", tempValue.Substring(0, 2), tempValue.Substring(3, 2), tempValue.Substring(4, 4));
                            else if (formatString.Equals("ddMMyyyy"))
                                tempValue = string.Format("{0}/{1}/{2}", tempValue.Substring(3, 2), tempValue.Substring(0, 2), tempValue.Substring(4, 4));
                            else if (formatString.Equals("yyyy/MM/dd") || formatString.Equals("yyyy-MM-dd"))
                                tempValue = string.Format("{0}/{1}/{2}", tempValue.Substring(5, 2), tempValue.Substring(7, 2), tempValue.Substring(0, 4));
                            else if (formatString.Equals("dd/MM/yyyy") || formatString.Equals("dd-MM-yyyy"))
                                tempValue = string.Format("{0}/{1}/{2}", tempValue.Substring(0, 2), tempValue.Substring(4, 2), tempValue.Substring(5, 4));
                            else if (formatString.Equals("dd/MM/yyyy") || formatString.Equals("dd-MM-yyyy"))
                                tempValue = string.Format("{0}/{1}/{2}", tempValue.Substring(4, 2), tempValue.Substring(0, 2), tempValue.Substring(5, 4));
                        }
                    }
                    return tempValue;
                }
            }
            return string.Empty;
        }

        private void GetDataInformationByImport_Automap(DataRow dr,DataTable dataDMXetnghiem, DataTable dataUser, DM_LOAIIMPORT objConfig
            , List<DM_LOAIIMPORT_MAPPING> lstobjMapping, int IdMay)
        {
            var objTiepNhan = new BENHNHAN_TIEPNHAN();
            var objSangLoc = new BENHNHAN_MAUSANGLOC();
            objSangLoc.Sosinh = true;
            objSangLoc.Hotenme = GetDataWithMapping(dr, objConfig.Loaiimport,lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Hotenme));
            objSangLoc.Tenme = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tenme)).Trim();
            objTiepNhan.Tenbn = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tenbn));
            if(string.IsNullOrEmpty(objTiepNhan.Tenbn))
                objTiepNhan.Tenbn = string.Format("{0} {1}", objSangLoc.Hotenme, objSangLoc.Tenme);
            CustomMessageBox.ShowAlert(string.Format("Đang import: {0}", (string.IsNullOrEmpty(objSangLoc.Hotenme) ? objTiepNhan.Tenbn : objSangLoc.Hotenme)), topMost: true);
            //importype: 1: SGP - 2: Immu - 3:Qsight
            objTiepNhan.Usernhap = CommonAppVarsAndFunctions.UserID;
            objTiepNhan.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
            objTiepNhan.Nguonnhap = InputSourceEnum.SangLocSoSinh.ToString();
            objTiepNhan.Usercapnhat = CommonAppVarsAndFunctions.UserID;
            objTiepNhan.Ngaytiepnhan = dtpNgayTiepNhan.Value;
            objSangLoc.Barcodelaymau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Barcodelaymau));
            objTiepNhan.Seq = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpNgayTiepNhan.Value);
            objTiepNhan.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(objTiepNhan.Seq, dtpNgayTiepNhan.Value);
            objSangLoc.Matiepnhan = objTiepNhan.Matiepnhan;
            objTiepNhan.Mabn = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Mabn));
            objTiepNhan.Quoctich = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Quoctich));
            objTiepNhan.Bacsicd = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Bacsicd));
            objTiepNhan.TenBScd = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tenbacsicd));
            if(string.IsNullOrEmpty(objTiepNhan.Bacsicd) && !string.IsNullOrEmpty(objTiepNhan.TenBScd))
            {
                var Bacsicd = ucSearchLookupEditor_BSChiDinh.GetDoctorIdByName(objTiepNhan.TenBScd);
                if (!string.IsNullOrEmpty(Bacsicd))
                    objTiepNhan.Bacsicd = Bacsicd;
            }
            var namsinhMe = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Namsinhme));
            objSangLoc.Namsinhme = int.Parse(string.IsNullOrEmpty(namsinhMe) ? "0" : namsinhMe);
            objSangLoc.Hotenbo = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Hotenbo));
            var namsinhBo = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Namsinhbo));
            objSangLoc.Namsinhbo = int.Parse(string.IsNullOrEmpty(namsinhBo) ? "0" : namsinhBo);
            var tuoiThai = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tuoithai));
            objSangLoc.Tuoithai = int.Parse(string.IsNullOrEmpty(tuoiThai) ? "0" : tuoiThai);
            objSangLoc.Dienthoaididong = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dienthoaididong));
            objSangLoc.Dienthoaiban = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dienthoaiban));
            objTiepNhan.Diachi = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Diachi));
            objSangLoc.Diachi = objTiepNhan.Diachi;
            var ngaysinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ngaysinh));
            if (!string.IsNullOrEmpty(ngaysinh))
            {
                var birthday = DateTime.Now;
                DateTime.TryParse(ngaysinh, out birthday);
                //+ GIO SINH
                if (birthday.Equals(DateTime.MinValue))
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("Ngày sinh của {0} không hợp lệ.", objTiepNhan.Tenbn));
                }
                else
                {
                    var giosinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Giosinh)).Trim().Split(new string[] { "H" }, StringSplitOptions.RemoveEmptyEntries);
                    if (giosinh.Length > 0)
                    {
                        birthday = birthday.AddHours(double.Parse(giosinh[0]));
                        if (giosinh.Length > 1)
                            birthday = birthday.AddMinutes(double.Parse(giosinh[1]));
                    }
                    objTiepNhan.Tuoi = birthday.Year;
                    objTiepNhan.Sinhnhat = birthday;
                    objSangLoc.Ngaysinh = birthday;
                }
            }
            else
            { 
                ngaysinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Sinhnhat));
                var birthday = DateTime.Now;
                DateTime.TryParse(ngaysinh, out birthday);
                if (!birthday.Equals(DateTime.MinValue))
                {
                    objTiepNhan.Tuoi = birthday.Year;
                    objTiepNhan.Sinhnhat = birthday;
                    objSangLoc.Ngaysinh = birthday;
                }
            }
            var gioiTinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Gioitinh)).Trim();
            objTiepNhan.Gioitinh =(gioiTinh.Equals("f", StringComparison.OrdinalIgnoreCase) || gioiTinh.Equals("nữ", StringComparison.OrdinalIgnoreCase) ? "F"
                :"M" );
            var canNang = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Cannang)).Trim();
            objSangLoc.Cannang = int.Parse(string.IsNullOrEmpty(canNang) ? "0" : canNang);
            var ngayLayMau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ngaylaymau)).Trim();
            var ngaygioLayMau = DateTime.Now;
            DateTime.TryParse(ngayLayMau, out ngaygioLayMau);
            //GIO LAY
            if (ngaygioLayMau.Equals(DateTime.MinValue))
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Ngày lấy mẫu của {0} không hợp lệ.", objTiepNhan.Tenbn));
            }
            else
            {

                var giolay = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Giolaymau)).Trim().Split(new string[] { "H" }, StringSplitOptions.RemoveEmptyEntries);
                if (giolay.Length > 0)
                {
                    ngaygioLayMau = ngaygioLayMau.AddHours(double.Parse(giolay[0]));
                    if (giolay.Length > 1)
                        ngaygioLayMau = ngaygioLayMau.AddMinutes(double.Parse(giolay[1]));
                }
                objSangLoc.Thoigianlaymau = ngaygioLayMau;
            }
            objSangLoc.Tennguoilaymau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tennguoilaymau)).Trim();
            var rdonVi = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Madonvi));
            objTiepNhan.Madonvi = ucSearchLookupEditor_KhoaPhong.GetObjectIdByName(rdonVi.Trim());
            if(string.IsNullOrEmpty(objTiepNhan.Madonvi))
            {
                objTiepNhan.Madonvi = ucSearchLookupEditor_KhoaPhong.GetObjectIdImport(rdonVi.Trim());
            }
            var strMaTinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Matinh)).Trim();
            strMaTinh = string.IsNullOrEmpty(strMaTinh) ? GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Matinhguimau)).Trim(): strMaTinh;
            var maTinh = ucSearchLookupEditor_Provice1.GetObjectIdByName(strMaTinh);
            if (!string.IsNullOrEmpty(maTinh))
            {
                objTiepNhan.Matinh = int.Parse(maTinh);
                var strMaHuyen = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Mahuyen)).Trim();
                strMaHuyen = string.IsNullOrEmpty(strMaHuyen) ? GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Mahuyenguimau)).Trim() : strMaHuyen;
                var maHuyen = ucSearchLookupEditor_District1.GetObjectIdByName(strMaHuyen, int.Parse(maTinh));
                objTiepNhan.Mahuyen = int.Parse((string.IsNullOrEmpty(maHuyen) ? "0" : maHuyen));
            }
            else
            {
                objTiepNhan.Matinh = 0;
                objTiepNhan.Mahuyen = 0;
            }
            var strDoiTuong = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Doituongdichvu)).Trim().Replace("\n", "");
            var maDoiTuongDichVu = ucSearchLookupEditor_Object1.GetObjectIdByName(!string.IsNullOrEmpty(strDoiTuong)? strDoiTuong.Trim() : "Thu Phí");
            objTiepNhan.Doituongdichvu = maDoiTuongDichVu;
            var maTinhGui = ucSearchLookupEditor_TinhGuiMau.GetObjectIdByName(GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Matinhguimau)).Trim());
            if (!string.IsNullOrEmpty(maTinhGui))
            {
                objSangLoc.Matinhguimau = int.Parse(maTinhGui);
                var huyen = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Mahuyenguimau)).Trim();
                var maHuyen = ucSearchLookupEditor_District1.GetObjectIdByName(huyen, int.Parse(maTinhGui));
                objSangLoc.Mahuyenguimau = int.Parse((string.IsNullOrEmpty(maHuyen) ? "0" : maHuyen));
            }
            else
            {
                objSangLoc.Mahuyenguimau = 0;
                objSangLoc.Matinhguimau = 0;
            }

            var noisinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Noisinh)).Trim();
            objSangLoc.Noisinh = ucSearchLookupEditor_KhoaPhong.GetObjectIdByName(noisinh.Trim());
            if (string.IsNullOrEmpty(objSangLoc.Noisinh))
            {
                objSangLoc.Noisinh = ucSearchLookupEditor_KhoaPhong.GetObjectIdImport(noisinh.Trim());
            }
            objSangLoc.Dantoc = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dantoc)).Trim();
            objSangLoc.Diachinoiguimau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Diachinoiguimau)).Trim();
            var noiguimau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Noiguimau)).Trim();
            objSangLoc.Noiguimau = ucSearchLookupEditor_DonViGuiMau.GetObjectIdByName(noiguimau.Trim());
            if (string.IsNullOrEmpty(objSangLoc.Noiguimau))
            {
                objSangLoc.Noiguimau = ucSearchLookupEditor_DonViGuiMau.GetObjectIdImport(noiguimau.Trim());
            }
            var luongTruyenmau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ttluongtruyenmau)).Trim();
            objSangLoc.Ttluongtruyenmau = int.Parse((string.IsNullOrEmpty(luongTruyenmau) ? "0" : luongTruyenmau));
            var slSinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Soluongsinh)).Trim();
            objSangLoc.Soluongsinh = int.Parse((string.IsNullOrEmpty(slSinh) ? "0" : slSinh));
            var chieucao = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Chieucao)).Trim();
            objSangLoc.Chieucao = int.Parse((string.IsNullOrEmpty(chieucao) ? "0" : chieucao));
            objSangLoc.Para1 = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Para1)).Trim();
            objSangLoc.Para2 = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Para2)).Trim();
            objSangLoc.Para3 = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Para3)).Trim();
            objSangLoc.Para4 = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Para4)).Trim();
            var getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Kieudekhac)).Trim();
            objSangLoc.Kieudekhac = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Kieudemo)).Trim();
            objSangLoc.Kieudemo = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Kieudethuong)).Trim();
            objSangLoc.Kieudethuong = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dinhduongbubinh)).Trim();
            objSangLoc.Dinhduongbubinh = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dinhduongbume)).Trim();
            objSangLoc.Dinhduongbume = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dinhduongtinhmach)).Trim();
            objSangLoc.Dinhduongtinhmach = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ttdangbenh)).Trim();
            objSangLoc.Ttdangbenh = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ttbinhthuong)).Trim();
            objSangLoc.Ttbinhthuong = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ttdungkhangsinh)).Trim();
            objSangLoc.Ttdungkhangsinh = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ttdungsteriod)).Trim();
            objSangLoc.Ttdungsteriod = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tttruyenmau)).Trim();
            objSangLoc.Tttruyenmau = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Vitrigotchan)).Trim();
            objSangLoc.Vitrigotchan = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Vitrikhac)).Trim();
            objSangLoc.Vitrikhac = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Vitritinhmach)).Trim();
            objSangLoc.Vitritinhmach = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            var cannangMe = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Cannangme)).Trim();
            objSangLoc.Cannangme = float.Parse((string.IsNullOrEmpty(cannangMe) ? "0" : cannangMe));
            var chieucaoMe = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Chieucaome)).Trim();
            objSangLoc.Chieucaome = float.Parse((string.IsNullOrEmpty(chieucaoMe) ? "0" : chieucaoMe));
            var soThai = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Sothai)).Trim();
            objSangLoc.Sothai = (string.IsNullOrEmpty(soThai) ? 0 : (soThai.Equals("Đơn Thai", StringComparison.OrdinalIgnoreCase) || soThai.Equals("1") ? 1
                            : (soThai.Equals("Song Thai", StringComparison.OrdinalIgnoreCase) || soThai.Equals("2") ? 2 : 3)));
            var tuoithaime = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tuoithaime)).Trim();
            objSangLoc.Tuoithaime = int.Parse((string.IsNullOrEmpty(tuoithaime) ? "0" : tuoithaime));

            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ivf)).Trim();
            objSangLoc.Ivf = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Hutthuoc)).Trim();
            objSangLoc.Hutthuoc = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            var bpd = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Bpd)).Trim();
            objSangLoc.Bpd = int.Parse((string.IsNullOrEmpty(bpd) ? "0" : bpd));
            objSangLoc.Chungtoc = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Chungtoc)).Trim();
            objSangLoc.Daithaoduong = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Daithaoduong)).Trim();
            objSangLoc.Daithaoduong2 = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Daithaoduong2)).Trim();
            objSangLoc.Tiensu = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tiensu)).Trim();
            objSangLoc.Bssieuam = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Bssieuam)).Trim();
            var bmi = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Bmi)).Trim();
            objSangLoc.Bmi = float.Parse((string.IsNullOrEmpty(bmi) ? "0" : bmi));  
            var crl = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Crl)).Trim();
            objSangLoc.Crl = int.Parse((string.IsNullOrEmpty(crl) ? "0" : crl));
            var xuongMui = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Xuongmui)).Trim();
            objSangLoc.Xuongmui = float.Parse((string.IsNullOrEmpty(xuongMui) ? "0" : xuongMui));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tanghamantinh)).Trim();
            objSangLoc.Tanghamantinh = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Thaiphumactsg)).Trim();
            objSangLoc.Thaiphumactsg = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Methaiphumactsg)).Trim();
            objSangLoc.Methaiphumactsg = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Antiphospholipid)).Trim();
            objSangLoc.Antiphospholipid = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Lupusbando)).Trim();
            objSangLoc.Lupusbando = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dacothaihon24)).Trim();
            objSangLoc.Dacothaihon24 = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));
            var strngaySinhTruoc= GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ngaysinhtruoc)).Trim();
            if (!string.IsNullOrEmpty(strngaySinhTruoc))
            {
                var ngaySinhTruoc = DateTime.Now;
                DateTime.TryParse(strngaySinhTruoc, out ngaySinhTruoc);

                if (ngaySinhTruoc.Equals(DateTime.MinValue))
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("Ngày siêu âm của {0} không hợp lệ.", objTiepNhan.Tenbn));
                }
                else
                {
                    objSangLoc.Ngaysinhtruoc = ngaySinhTruoc;
                }
            }
            var tuoiThaiSinhTruoc = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tuoithaisinhtruoc)).Trim();
            objSangLoc.Tuoithaisinhtruoc = int.Parse((string.IsNullOrEmpty(tuoiThaiSinhTruoc) ? "0" : tuoiThaiSinhTruoc));
            getBool = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Sinhcont21t18t13)).Trim();
            objSangLoc.Sinhcont21t18t13 = (string.IsNullOrEmpty(getBool) ? false : (getBool == "1" || getBool.Equals("true", StringComparison.OrdinalIgnoreCase) || getBool.Equals("có", StringComparison.OrdinalIgnoreCase) ? true : false));

            //Ngày siêu âm
            var strngaySieuAm = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ngaysieuam)).Trim();
            if (!string.IsNullOrEmpty(strngaySieuAm))
            {
                var ngaySieuAm = DateTime.Now;
                DateTime.TryParse(strngaySieuAm, out ngaySieuAm);

                if (ngaySieuAm.Equals(DateTime.MinValue))
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("Ngày siêu âm của {0} không hợp lệ.", objTiepNhan.Tenbn));
                }
                else
                {
                    objSangLoc.Ngaysieuam = ngaySieuAm;
                }
            }
            var strngayNhanMau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ngaynhanmau)).Trim();
            var ngaygionhanMau = DateTime.Now;
            if (!string.IsNullOrEmpty(strngayNhanMau))
            {
                DateTime.TryParse(strngayNhanMau, out ngaygionhanMau);

                if (ngaygionhanMau.Equals(DateTime.MinValue))
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("Ngày nhận mẫu của {0} không hợp lệ.", objTiepNhan.Tenbn));
                }
                else
                {
                    var gionhan = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Gionhanmau)).Trim().Split(new string[] { "H" }, StringSplitOptions.RemoveEmptyEntries);
                    if (gionhan.Length > 0)
                    {
                        ngaygioLayMau = ngaygioLayMau.AddHours(double.Parse(gionhan[0]));
                        if (gionhan.Length > 1)
                            ngaygioLayMau = ngaygioLayMau.AddMinutes(double.Parse(gionhan[1]));
                    }
                }
            }
            var goiXetNghiem = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.ProfileID)).Trim();
            var tinhTrangMau = "Đạt";
            objSangLoc.Goixn = goiXetNghiem;
            informationService.Insert_BenhNhan_TiepNhan(objTiepNhan, true);
            informationService.Insert_ThongTinSLSoSinh(objSangLoc);
            var nguoixacnhan = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.NguoixacnhanKQ)).Trim();
            var dtguoiXacNhan = WorkingServices.SearchResult_OnDatatable(dataUser, string.Format("TenNhanVien = '{0}'", nguoixacnhan.Trim()));
            if(dtguoiXacNhan.Rows.Count >0)
            {
                nguoixacnhan = dtguoiXacNhan.Rows[0]["MaNguoiDung"].ToString();
            }
            var bsKyTen = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Nguoikyten)).Trim();
            var dtnguoiIn = WorkingServices.SearchResult_OnDatatable(dataUser, string.Format("TenNhanVien = '{0}'", bsKyTen.Trim()));
            if (dtnguoiIn.Rows.Count > 0)
            {
                bsKyTen = dtnguoiIn.Rows[0]["MaNguoiDung"].ToString();
            }
            var lstXNInsert = lstobjMapping.Where(x => !string.IsNullOrEmpty(x.Maxnlis) && x.Liscolumn.Equals(ControlExtension.PropertyName<PatientImportInfo>(x2 => x2.Maxetnghiem)));
            if(lstXNInsert.Any())
            {
                foreach (var item in lstXNInsert)
                {
                    var maXn = item.Maxnlis;
                    var ketQua = GetDataTestMappingWithResult(dr, objConfig.Loaiimport, lstXNInsert.ToList(), maXn);
                    if (string.IsNullOrEmpty(ketQua))
                        continue;
                    var ghiChu = GetDataTestMappingWithNote(dr, objConfig.Loaiimport, lstXNInsert.ToList(), maXn);
                    var dtXn = WorkingServices.SearchResult_OnDatatable(dataDMXetnghiem, string.Format("MaXN = '{0}'", maXn.Trim()));
                    if (dtXn.Rows.Count > 0)
                    {
                        var loaiXn = int.Parse(dtXn.Rows[0]["LoaiXetNghiem"].ToString());
                        var maloaiMau = dtXn.Rows[0]["LoaiMau"].ToString();
       
                        InsertDichVuXn(objTiepNhan, maXn, ProfileTestContant.TestChar,goiXetNghiem);
                        var lstDSLayMau = new List<LayMauInfo>();
                        lstDSLayMau.Add(
                                       new LayMauInfo
                                       {
                                           MaTiepNhan = objTiepNhan.Matiepnhan,
                                           TrangThai = enumThucHien.DaThucHien,
                                           MaNhomLoaiMau = maloaiMau,
                                           NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                                           Pcthuchien = Environment.MachineName,
                                           CheckXacNhanHis = true,
                                           Maxn = maXn,
                                           IDKhuLayMau = objKhuLayMau.Idkhulaymau,
                                           ThoiGianLayMau = ngaygioLayMau,
                                           LoaiXetNghiem = loaiXn,
                                           IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                           BanLayMau = 0,
                                           MaCapTren = string.Empty,
                                           ProfileId = string.Empty
                                       });
                        //Cap nhat lay mau cho test
                        informationService.Update_MauXn_LayMau(lstDSLayMau);
                        var lstDSNhanMau = new List<NhanMauInfo>();
                        lstDSNhanMau.Add(new NhanMauInfo()
                        {
                            MaTiepNhan = objTiepNhan.Matiepnhan,
                            NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                            NguoiThucHienNhanMau = CommonAppVarsAndFunctions.UserID,
                            Pcthuchien = Environment.MachineName,
                            TrangThaiNhan = enumThucHien.DaThucHien,
                            LyDoTuChoi = string.Empty,
                            TinhTrangMau = tinhTrangMau,
                            MaLoaiMau = maloaiMau,
                            CheckXacNhanHis = false,
                            Maxn = maXn,
                            DeleteOrder = false,
                            ThoiGianNhanMau = ngaygionhanMau,
                            LoaiXetNghiem = loaiXn,
                            MaLoaiMauNhan = maloaiMau,
                            IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                            KhuThucHienID = CommonAppVarsAndFunctions.PCWorkPlace,
                            MaCapTren = string.Empty,
                            ProfileId = string.Empty
                        });
                        informationService.Update_MauXn_NhanMau(lstDSNhanMau);

                        //Xử lý kết quả
                        var flag = 1;
                        var flagCanhBao = 1;

                        var obUpdate = new UpdateResultNormalInfo()
                        {
                            maTiepNhan = objTiepNhan.Matiepnhan,
                            maXN = maXn,
                            ketQua = ketQua,
                            capNhatghiChu = true,
                            ghiChu = ghiChu,
                            co = flag.ToString(),
                            userNhap = CommonAppVarsAndFunctions.UserID,
                            suaKQ = false,
                            round = "",
                            userUpdate = CommonAppVarsAndFunctions.UserID,
                            coCanhBao = flagCanhBao,
                            tuValid = (string.IsNullOrEmpty(nguoixacnhan) ? false : true),
                            uservalid = nguoixacnhan,
                            iDMayXetNghiem = IdMay.ToString()
                        };
                        testService.CapNhat_KQ_XN(obUpdate);
                        testService.CapNhat_CSBT(objTiepNhan.Matiepnhan, maXn, IdMay.ToString(), true, false);
                        if (!string.IsNullOrEmpty(bsKyTen))
                        {
                            testService.CapNhat_BSKyten(objTiepNhan.Matiepnhan, maXn, bsKyTen, CommonAppVarsAndFunctions.UserID, Environment.MachineName, false);
                        }
                    }
                }
            }
          
            //Tín > Cập nhật trạng thái lấy mẫu cho nhóm và bộ phận
            informationService.Update_TrangThaiLayMau(objTiepNhan.Matiepnhan);
            //Tín > Cập nhật trạng thái nhận mẫu cho nhóm và bộ phận
            informationService.Update_TrangThaiNhanMau(objTiepNhan.Matiepnhan, true);
            //cập nhật trạng thái đủ kết quả
            testService.CapNhat_DuKQ_XN(objTiepNhan.Matiepnhan);
            //cập nhật nhận xét, đề nghị, kết luận
            var nhanxet = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Nhanxetsangloc)).Trim();
            var ketluan = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ketluansangloc)).Trim();
            var denghi = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Denghisangloc)).Trim();
            if (!string.IsNullOrEmpty(nhanxet) || !string.IsNullOrEmpty(ketluan) || !string.IsNullOrEmpty(denghi))
            {
                informationService.Update_NhanXetDeNghi_SangLoc(objTiepNhan.Matiepnhan, nhanxet
               , (string.IsNullOrEmpty(nhanxet) ? string.Empty : CommonAppVarsAndFunctions.UserID)
               , denghi, (string.IsNullOrEmpty(denghi) ? string.Empty : CommonAppVarsAndFunctions.UserID)
               , ketluan, (string.IsNullOrEmpty(ketluan) ? string.Empty : CommonAppVarsAndFunctions.UserID));
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ucSearchLookupEditor_NoiSinh_Load(object sender, EventArgs e)
        {

        }
        private void txtMaBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_Object1);
        }

        private void txtTenMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtNamSinhMe);
        }
        private void cboDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                numTuoiThai.Focus();
        }

        private void numTuoiThai_Enter(object sender, EventArgs e)
        {
            numTuoiThai.Select(0, (numTuoiThai.Value).ToString().Length);
        }

        private void numCanNang_Enter(object sender, EventArgs e)
        {
            numCanNang.Select(0, (numCanNang.Value).ToString().Length);
        }

        private void btnCapNhatGoiXetNghiem_Click(object sender, EventArgs e)
        {
            //if (ucSearchLookupEditor_DanhSachDichVu1.SelectedValue != null)
            //{
            //    if (ucSearchLookupEditor_DanhSachDichVu1.GetProfileChar.Equals(ProfileTestContant.ProfileChar))
            //    {
            //        if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin gói xét nghiệm?"))
            //        {
            //            var matiepNhan = currentPatient.Matiepnhan;
            //            var maprofile = ucSearchLookupEditor_DanhSachDichVu1.SelectedValue.ToString();
            //            testService.UpdateProfileID(matiepNhan, maprofile);
            //            ucChiTietChiDinh1.Get_ChiTietChiDinh(matiepNhan, null);
            //        }
            //    }
            //    else
            //        CustomMessageBox.MSG_Information_OK("Hãy chọn gói xét nghiệm.");
            //}
        }
        private Image logo;
        private static XtraReport ticketReport;
        private static Report.Models.ReportModel resultReportInfo;
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private void btnInPhieuHen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaTiepNhan.Text))
            {
                if (ucSearchLookupEditor_DanhSachDichVu1.SelectedValue != null)
                {
                    if (resultReportInfo == null)
                    {
                        resultReportInfo = _reportInfo.Info_Report(ReportConstants.PhieuHenSLSS);
                    }

                    if (resultReportInfo.ReportSuDung == null)
                        return;
                    var dataHen = informationService.Data_PhieuHen_SLSS(txtMaTiepNhan.Text);
                    if (dataHen.Rows.Count > 0)
                    {
                        var crv = new FrmPreViewReport();
                        crv.SampleID = string.Format("PhieuHenKQXN_SLSS_{0}", dataHen.Rows[0]["BarcodeTPH"].ToString().Trim());
                        crv.TenBN = dataHen.Rows[0]["TenMe"].ToString().Trim();
                        crv.SoTTLayMau = 0;
                        crv.InGiohen = true;
                        var printerName = string.Empty;
                        var logoAdd = GraphicSupport.ImageToByteArray(logo);
                        dataHen.Columns.Add("Logo", typeof(byte[]));
                        foreach (DataRow dr in dataHen.Rows)
                        {
                            dr["Logo"] = logoAdd;
                        }
                        if (listPrinter.Items.Count > 0)
                        {
                            if (listPrinter.SelectedIndex == -1)
                            {
                                listPrinter.SelectedIndex = 0;
                            }
                            printerName = listPrinter.SelectedItem.ToString();
                        }
                        if (dataHen.Rows.Count > 0)
                        {
                            ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                            var print = crv.ShowReport(ticketReport, dataHen, !chkPrintPreview.Checked, printerName, "XN", resultReportInfo.TenDataset, resultReportInfo.TenDatatable);
                        }
                    }
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Hãy cập nhật thông tin gói xét nghiẹm trước khi in phiếu hẹn.");
                }
            }
            
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count > 0)
            {
                _registryExtension.WriteRegistry(
                    UserConstant.RegistryPrinterReturnResultTimeSLSS,
                    listPrinter.SelectedItem.ToString());
            }
        }
    }
}
