using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class ucThongTinSangLoc : UserControl
    {
        private readonly IPatientInformationService informationService = new PatientInformationService();
        private readonly ITestResultService testService = new TestResultService();
        private readonly IMicrobilogyTestResultService _microbilogyTestResultService = new MicrobilogyTestResultService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IUserManagementService _userManagement = new UserManagementService();
        private BENHNHAN_TIEPNHAN currentPatient = new BENHNHAN_TIEPNHAN();
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        public ucThongTinSangLoc()
        {
            InitializeComponent();
        }
        [Category("Custom")]
        public bool LoaiXetNghiemSangLocSoSinh
        {
            set { pnSangLocSoSinh.Visible = value; pnSangLocTruocSinh.Visible = !value; gpThongTingiaDinh.Visible = value; }
            get { return pnSangLocSoSinh.Visible; }
        }
        private void SetLock_Unlock(bool isLock)
        {
            dtpNgayTiepNhan.Enabled = !isLock;
            dtpNgaySinh.Enabled = !isLock;
            dtpTGLayMau.Enabled = !isLock;
            ucSearchLookupEditor_District1.Enabled = !isLock;
            ucSearchLookupEditor_Gender1.Enabled = !isLock;
            ucSearchLookupEditor_HuyenGuiMau.Enabled = !isLock;
            ucSearchLookupEditor_NoiSinh.Enabled = !isLock;
            ucSearchLookupEditor_NoiGuiMau.Enabled = !isLock;
            ucSearchLookupEditor_Provice1.Enabled = !isLock;
            ucSearchLookupEditor_TinhGuiMau.Enabled = !isLock;
            ucSearchLookupEditor_Object1.Enabled = !isLock;
            ucSearchLookupEditor_BSChiDinh.Enabled = !isLock;
            txtQuocTich.ReadOnly = isLock;
            numCanNang.Enabled = !isLock;
            numChieuCao.Enabled = !isLock;
            numTuoiThai.Enabled = !isLock;
            txtMaBenhNhan.ReadOnly = isLock;
            txtBarcodeLayMau.ReadOnly = isLock;
            txtBarcodeXN.ReadOnly = isLock;
            txtDanToc.ReadOnly = isLock;
            txtDiaChi.ReadOnly = isLock;
            txtDiaChiNoiGuiMau.ReadOnly = isLock;
            txtDiDong.ReadOnly = isLock;
            txtDienThoai.ReadOnly = isLock;
            txtHoTenBo.ReadOnly = isLock;
            txtHoTenMe.ReadOnly = isLock;
            txtHoTenTre.ReadOnly = isLock;
            txtNamSinhBo.ReadOnly = isLock;
            txtNamSinhMe.ReadOnly = isLock;
            txtNguoiLayMau.ReadOnly = isLock;
            txtPara_1.ReadOnly = isLock;
            txtPara_2.ReadOnly = isLock;
            txtPara_3.ReadOnly = isLock;
            txtPara_4.ReadOnly = isLock;
            txtTinhTragLayMau_SoLuongTruyenMau.ReadOnly = isLock;
            txtSoTreLucSinh.ReadOnly = isLock;
            radSinh1.Enabled = !isLock;
            radSinh2.Enabled = !isLock;
            radSinh3.Enabled = !isLock;
            radSinhKhac.Enabled = !isLock;
            radDeKhac.Enabled = !isLock;
            radDemo.Enabled = !isLock;
            radDeThuong.Enabled = !isLock;
            chkDinhDuong_BuBinh.Enabled = !isLock;
            chkDinhDuong_BuMe.Enabled = !isLock;
            chkDinhDuong_TinhMach.Enabled = !isLock;
            chkTinhTragLayMau_BiBenh.Enabled = !isLock;
            chkTinhTragLayMau_BinhThuong.Enabled = !isLock;
            chkTinhTragLayMau_KhangSinh.Enabled = !isLock;
            chkTinhTragLayMau_Steriod.Enabled = !isLock;
            chkTinhTragLayMau_TruyenMau.Enabled = !isLock;
            chkViTriLayMau_GotChan.Enabled = !isLock;
            chkViTriLayMau_Khac.Enabled = !isLock;
            chkViTriLayMau_TinhMach.Enabled = !isLock;

            //Sàng lọc trước sinh
            numCanNangMe.Enabled = !isLock;
            numChieuCaoMe.Enabled = !isLock;
            numSoThai.Enabled = !isLock;
            numBPD.Enabled = !isLock;
            numTuoiThaiMe.Enabled = !isLock;
            cboChungToc.Enabled = !isLock;
            txtTienSu.ReadOnly = isLock;
            txtDaiThaoDuong1.ReadOnly = isLock;
            txtBSSieuAm.ReadOnly = isLock;
            txtDiaChiMe.ReadOnly = isLock;
            txtSDT.ReadOnly = isLock;
            chkIVF.Enabled = !isLock;
            chkHutThuoc.Enabled = !isLock;

            numBMIMe.Enabled = !isLock;
            numCRL.Enabled = !isLock;
            numXuongMui.Enabled = !isLock;
            txtDaiThaoDuong2.ReadOnly = isLock;
            chkHuyetApManTinh.Enabled = !isLock;
            chkTienSanGiat.Enabled = !isLock;
            chkTienSanGiat_Ngoai.Enabled = !isLock;
            chkAntiphosLipid.Enabled = !isLock;
            chkLupusBanDo.Enabled = !isLock;
            chkDacoThaiHon24.Enabled = !isLock;
            dtpNgaySinhTruoc.Enabled = !isLock;
            numTuoiThaiSinhTruoc.Enabled = !isLock;
            chkSinhT21T18T13.Enabled = !isLock;
            dtpNgayDuSinh.Enabled = !isLock;
           
        }
        private void ClearControl()
        {
            dtpNgayTiepNhan.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNgaySinh.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpTGLayMau.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNgayDuSinh.SetValue(null);
            ucAddEditControl1.SetStatusButtonNormal();
            ucSearchLookupEditor_District1.SelectedValue = null;
            ucSearchLookupEditor_Gender1.SelectedValue = null;
            ucSearchLookupEditor_HuyenGuiMau.SelectedValue = null;
            ucSearchLookupEditor_NoiSinh.SelectedValue = null;
            ucSearchLookupEditor_NoiGuiMau.SelectedValue = null;
            ucSearchLookupEditor_Provice1.SelectedValue = null;
            ucSearchLookupEditor_TinhGuiMau.SelectedValue = null;
            ucSearchLookupEditor_Object1.SelectedValue = null;
            ucSearchLookupEditor_BSChiDinh.SelectedValue = null;
            txtQuocTich.Text = string.Empty;
            numCanNang.Value = 1;
            numChieuCao.Value = 1;
            numTuoiThai.Value = 1;
            txtMaBenhNhan.Text = string.Empty;

            txtBarcodeLayMau.Text = string.Empty;
            txtBarcodeXN.Text = string.Empty;
            txtDanToc.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDiaChiNoiGuiMau.Text = string.Empty;
            txtDiDong.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtHoTenBo.Text = string.Empty;
            txtHoTenMe.Text = string.Empty;
            txtHoTenTre.Text = string.Empty;
            txtMaTiepNhan.Text = string.Empty;
            txtNamSinhBo.Text = string.Empty;
            txtNamSinhMe.Text = string.Empty;
            txtNguoiLayMau.Text = string.Empty;
            txtNguoiNhap.Text = string.Empty;
            txtPara_1.Text = string.Empty;
            txtPara_2.Text = string.Empty;
            txtPara_3.Text = string.Empty;
            txtPara_4.Text = string.Empty;
            txtTinhTragLayMau_SoLuongTruyenMau.Text = string.Empty;
            txtSoTreLucSinh.Text = string.Empty;
            radSinh1.Checked = false;
            radSinh2.Checked = false;
            radSinh3.Checked = false;
            radSinhKhac.Checked = false;
            radDeKhac.Checked = false;
            radDemo.Checked = false;
            radDeThuong.Checked = false;
            chkDinhDuong_BuBinh.Checked = false;
            chkDinhDuong_BuMe.Checked = false;
            chkDinhDuong_TinhMach.Checked = false;
            chkTinhTragLayMau_BiBenh.Checked = false;
            chkTinhTragLayMau_BinhThuong.Checked = false;
            chkTinhTragLayMau_KhangSinh.Checked = false;
            chkTinhTragLayMau_Steriod.Checked = false;
            chkTinhTragLayMau_TruyenMau.Checked = false;
            chkViTriLayMau_GotChan.Checked = false;
            chkViTriLayMau_Khac.Checked = false;
            chkViTriLayMau_TinhMach.Checked = false;
            //Sàng lọc trước sinh
            numCanNangMe.Value = 0;
            numSoThai.Value = 0;
            numBPD.Value = 0;
            numTuoiThaiMe.Value = 0;
            numChieuCaoMe.Value = 0;
            cboChungToc.Text = string.Empty;
            txtTienSu.Text = string.Empty;
            txtDaiThaoDuong1.Text = string.Empty;
            txtBSSieuAm.Text = string.Empty;
            txtDiaChiMe.Text = string.Empty;
            txtSDT.Text = string.Empty;
            chkIVF.Checked = false;
            chkHutThuoc.Checked = false;
            txtDiaChiMe.Text = string.Empty;
            txtSDT.Text = string.Empty;

            numBMIMe.Value = 0;
            numCRL.Value = 0;
            numXuongMui.Value = 0;
            txtDaiThaoDuong2.Text = string.Empty;
            chkHuyetApManTinh.Checked = false;
            chkTienSanGiat.Checked = false;
            chkTienSanGiat_Ngoai.Checked = false;
            chkAntiphosLipid.Checked = false;
            chkLupusBanDo.Checked = false;
            chkDacoThaiHon24.Checked = false;

            dtpNgaySinhTruoc.SetValue(null);
            dtpNgaySieuAm.SetValue(null);
            numTuoiThaiSinhTruoc.Value = 0;
            chkSinhT21T18T13.Checked = false;
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
        private void Check_Enable()
        {
            var allow = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionInsertPatient);
            ucAddEditControl1.btnAdd.Enabled = allow;

            ucAddEditControl1.btnEdit.Enabled = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionEditPatient);
            ucAddEditControl1.btnDelete.Enabled = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeletePatient);
            ucChiTietChiDinh1.HienThiXoaChiDinh = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeleteOrder);
        }
        private void GetDataInformation(ref BENHNHAN_TIEPNHAN objTiepNhan, ref BENHNHAN_MAUSANGLOC objSangLoc)
        {
            objSangLoc = objSangLoc ?? new BENHNHAN_MAUSANGLOC();
            objTiepNhan.Ngaytiepnhan = dtpNgayTiepNhan.Value;
            objTiepNhan.Mahuyen = int.Parse(ucSearchLookupEditor_District1.SelectedValue == null ? "0" : ucSearchLookupEditor_District1.SelectedValue.ToString());
            objTiepNhan.Gioitinh = ucSearchLookupEditor_Gender1.SelectedValue.ToString();
            objTiepNhan.Madonvi = (ucSearchLookupEditor_NoiGuiMau.SelectedValue ?? (object)string.Empty).ToString();
            objTiepNhan.Matinh = int.Parse(ucSearchLookupEditor_Provice1.SelectedValue == null ? "0" : ucSearchLookupEditor_Provice1.SelectedValue.ToString());
            objTiepNhan.Doituongdichvu = ucSearchLookupEditor_Object1.SelectedValue.ToString();
            objTiepNhan.TenBScd = (ucSearchLookupEditor_BSChiDinh.SelectedValue ?? (object)string.Empty).ToString();
            objTiepNhan.Quoctich = txtQuocTich.Text;
            objTiepNhan.Mabn = txtMaBenhNhan.Text;
            objTiepNhan.Seq = txtBarcodeXN.Text;
            objTiepNhan.Diachi = string.IsNullOrEmpty(txtDiaChi.Text) ? txtDiaChiMe.Text : txtDiaChi.Text;
            objTiepNhan.Tenbn = txtHoTenTre.Text;
            objTiepNhan.Matiepnhan = txtMaTiepNhan.Text;
            objTiepNhan.Usernhap = txtNguoiNhap.Text;
            objTiepNhan.Sinhnhat = dtpNgaySinh.Value;
            objTiepNhan.Tuoi = dtpNgaySinh.Value.Year;
            objTiepNhan.Usercapnhat = CommonAppVarsAndFunctions.UserID;
            objTiepNhan.Sdt = txtSDT.Text;
            objTiepNhan.Bacsicd = (ucSearchLookupEditor_BSChiDinh.SelectedValue ?? (object)string.Empty).ToString();
            objSangLoc.Ngaysinh = dtpNgaySinh.Value;
            objSangLoc.Thoigianlaymau = dtpTGLayMau.Value;
            objSangLoc.Mahuyenguimau = int.Parse(ucSearchLookupEditor_HuyenGuiMau.SelectedValue == null ? "0" : ucSearchLookupEditor_HuyenGuiMau.SelectedValue.ToString());
            objSangLoc.Noisinh = (ucSearchLookupEditor_NoiSinh.SelectedValue ?? (object)string.Empty).ToString();
            objSangLoc.Matinhguimau = int.Parse((ucSearchLookupEditor_TinhGuiMau.SelectedValue ?? (object)"0").ToString());
            objSangLoc.Cannang = (float)numCanNang.Value;
            objSangLoc.Chieucao = (float)numChieuCao.Value;
            objSangLoc.Tuoithai = (int)numTuoiThai.Value;
            objSangLoc.Barcodelaymau = txtBarcodeLayMau.Text;
            objSangLoc.Dantoc = txtDanToc.Text;
            objSangLoc.Diachinoiguimau = txtDiaChiNoiGuiMau.Text;
            objSangLoc.Dienthoaididong = txtDiDong.Text;
            objSangLoc.Dienthoaiban = txtDienThoai.Text;
            objSangLoc.Hotenbo = txtHoTenBo.Text;
            objSangLoc.Hotenme = txtHoTenMe.Text;
            objSangLoc.Namsinhbo = int.Parse(string.IsNullOrEmpty(txtNamSinhBo.Text) ? "0" : txtNamSinhBo.Text);
            objSangLoc.Namsinhme = int.Parse(string.IsNullOrEmpty(txtNamSinhMe.Text) ? "0" : txtNamSinhMe.Text);
            objSangLoc.Tennguoilaymau = txtNguoiLayMau.Text;
            objSangLoc.Para1 = txtPara_1.Text;
            objSangLoc.Para2 = txtPara_2.Text;
            objSangLoc.Para3 = txtPara_3.Text;
            objSangLoc.Para4 = txtPara_4.Text;
            objSangLoc.Noiguimau = (ucSearchLookupEditor_NoiGuiMau.SelectedValue ?? (object)string.Empty).ToString();
            objSangLoc.Diachi = txtDiaChi.Text;
            objTiepNhan.Diachi = txtDiaChi.Text;
            txtTinhTragLayMau_SoLuongTruyenMau.Text = string.Format("0", objSangLoc.Ttluongtruyenmau == null ? (object)string.Empty : objSangLoc.Ttluongtruyenmau.Value);
            objSangLoc.Soluongsinh = int.Parse(string.IsNullOrEmpty(txtSoTreLucSinh.Text) ? "0" : txtSoTreLucSinh.Text);

            objSangLoc.Kieudekhac = radDeKhac.Checked;
            objSangLoc.Kieudemo = radDemo.Checked;
            objSangLoc.Kieudethuong = radDeThuong.Checked;
            objSangLoc.Dinhduongbubinh = chkDinhDuong_BuBinh.Checked;
            objSangLoc.Dinhduongbume = chkDinhDuong_BuMe.Checked;
            objSangLoc.Dinhduongtinhmach = chkDinhDuong_TinhMach.Checked;
            objSangLoc.Ttdangbenh = chkTinhTragLayMau_BiBenh.Checked;
            objSangLoc.Ttbinhthuong = chkTinhTragLayMau_BinhThuong.Checked;
            objSangLoc.Ttdungkhangsinh = chkTinhTragLayMau_KhangSinh.Checked;
            objSangLoc.Ttdungsteriod = chkTinhTragLayMau_Steriod.Checked;
            objSangLoc.Tttruyenmau = chkTinhTragLayMau_TruyenMau.Checked;
            objSangLoc.Vitrigotchan = chkViTriLayMau_GotChan.Checked;
            objSangLoc.Vitrikhac = chkViTriLayMau_Khac.Checked;
            objSangLoc.Vitritinhmach = chkViTriLayMau_TinhMach.Checked;
            objSangLoc.Ngaydusinh = dtpNgayDuSinh.GetValue();
            objSangLoc.Cannangme = (float)numCanNangMe.Value;
            objSangLoc.Chieucaome = (float)numChieuCaoMe.Value;
            objSangLoc.Sothai = (int)numSoThai.Value;
            objSangLoc.Tuoithaime = (int)numTuoiThaiMe.Value;
            objSangLoc.Ivf = chkIVF.Checked;
            objSangLoc.Hutthuoc = chkHutThuoc.Checked;
            objSangLoc.Bpd = (int)numBPD.Value;
            objSangLoc.Chungtoc = cboChungToc.Text;
            objSangLoc.Daithaoduong = txtDaiThaoDuong1.Text;
            objSangLoc.Tiensu = txtTienSu.Text;
            objSangLoc.Bssieuam = txtBSSieuAm.Text;
            objSangLoc.Ngaysieuam = dtpNgaySieuAm.GetValue();

            objSangLoc.Bmi = (float)numBMIMe.Value;
            objSangLoc.Crl = (int)numCRL.Value;
            objSangLoc.Xuongmui = (float)numXuongMui.Value;
            objSangLoc.Daithaoduong2 = txtDaiThaoDuong2.Text;
            objSangLoc.Tanghamantinh = chkHuyetApManTinh.Checked;
            objSangLoc.Thaiphumactsg = chkTienSanGiat.Checked;
            objSangLoc.Methaiphumactsg = chkTienSanGiat_Ngoai.Checked;
            objSangLoc.Antiphospholipid = chkAntiphosLipid.Checked;
            objSangLoc.Lupusbando = chkLupusBanDo.Checked;
            objSangLoc.Dacothaihon24 = chkDacoThaiHon24.Checked;
            objSangLoc.Ngaysinhtruoc = dtpNgaySinhTruoc.GetValue();
            objSangLoc.Tuoithaisinhtruoc = (int)numTuoiThaiSinhTruoc.Value;
            objSangLoc.Sinhcont21t18t13 = chkSinhT21T18T13.Checked;
            objSangLoc.Sosinh = LoaiXetNghiemSangLocSoSinh;
            objSangLoc.Tiensan = !LoaiXetNghiemSangLocSoSinh;
        }
        private void SetSoLuongSinh()
        {
            if (!radSinhKhac.Checked)
            {
                txtSoTreLucSinh.Enabled = false;
                if (radSinh1.Checked)
                    txtSoTreLucSinh.Text = "1";
                else if (radSinh2.Checked)
                    txtSoTreLucSinh.Text = "2";
                else if (radSinh3.Checked)
                    txtSoTreLucSinh.Text = "3";
                else
                    txtSoTreLucSinh.Text = "0";
            }
            else
            {
                txtSoTreLucSinh.Enabled = true;
            }
        }
        private void SetDataInformation(BENHNHAN_TIEPNHAN objTiepNhan, BENHNHAN_MAUSANGLOC objSangLoc)
        {
            dtpNgayTiepNhan.Value = objTiepNhan.Ngaytiepnhan;
            ucSearchLookupEditor_District1.SelectedValue = objTiepNhan.Mahuyen;
            ucSearchLookupEditor_Gender1.SelectedValue = objTiepNhan.Gioitinh;
            ucSearchLookupEditor_NoiGuiMau.SelectedValue = objTiepNhan.Madonvi;
            ucSearchLookupEditor_Provice1.SelectedValue = objTiepNhan.Matinh;
            ucSearchLookupEditor_Object1.SelectedValue = objTiepNhan.Doituongdichvu;
            ucSearchLookupEditor_BSChiDinh.SelectedValue = objTiepNhan.Bacsicd;
            txtQuocTich.Text = objTiepNhan.Quoctich;
            txtMaBenhNhan.Text = objTiepNhan.Mabn;
            txtBarcodeXN.Text = objTiepNhan.Seq;
            txtDiaChi.Text = string.IsNullOrEmpty(objTiepNhan.Diachi) ? (objSangLoc.Diachi ?? string.Empty) : objTiepNhan.Diachi;
            txtHoTenTre.Text = objTiepNhan.Tenbn;
            txtMaTiepNhan.Text = objTiepNhan.Matiepnhan;
            txtNguoiNhap.Text = objTiepNhan.Usernhap;

            dtpNgaySinh.Value = objSangLoc.Ngaysinh;
            if (objSangLoc.Thoigianlaymau != null)
                dtpTGLayMau.Value = objSangLoc.Thoigianlaymau.Value;
            ucSearchLookupEditor_HuyenGuiMau.SelectedValue = objSangLoc.Mahuyenguimau;
            ucSearchLookupEditor_NoiSinh.SelectedValue = objSangLoc.Noisinh;
            ucSearchLookupEditor_TinhGuiMau.SelectedValue = objSangLoc.Matinhguimau;
            numCanNang.Value = (decimal)objSangLoc.Cannang;
            numChieuCao.Value = (decimal)objSangLoc.Chieucao;

            numTuoiThai.Value = objSangLoc.Tuoithai;
            txtBarcodeLayMau.Text = objSangLoc.Barcodelaymau;
            txtDanToc.Text = objSangLoc.Dantoc;
            txtDiaChiNoiGuiMau.Text = objSangLoc.Diachinoiguimau;
            txtDiDong.Text = objSangLoc.Dienthoaididong;
            txtDienThoai.Text = objSangLoc.Dienthoaiban;
            txtHoTenBo.Text = objSangLoc.Hotenbo;
            txtHoTenMe.Text = objSangLoc.Hotenme;
            txtNamSinhBo.Text = objSangLoc.Namsinhbo.ToString();
            txtNamSinhMe.Text = objSangLoc.Namsinhme.ToString();
            txtNguoiLayMau.Text = objSangLoc.Tennguoilaymau;
            txtPara_1.Text = objSangLoc.Para1;
            txtPara_2.Text = objSangLoc.Para2;
            txtPara_3.Text = objSangLoc.Para3;
            txtPara_4.Text = objSangLoc.Para4;
            txtTinhTragLayMau_SoLuongTruyenMau.Text = string.Format("0", objSangLoc.Ttluongtruyenmau == null ? (object)string.Empty : objSangLoc.Ttluongtruyenmau.Value);
            txtSoTreLucSinh.Text = objSangLoc.Soluongsinh < 3 ? string.Empty : objSangLoc.Soluongsinh.ToString();
            radSinh1.Checked = objSangLoc.Soluongsinh == 1;
            radSinh2.Checked = objSangLoc.Soluongsinh == 2;
            radSinh3.Checked = objSangLoc.Soluongsinh == 3;
            radSinhKhac.Checked = objSangLoc.Soluongsinh > 3;
            radDeKhac.Checked = objSangLoc.Kieudekhac;
            radDemo.Checked = objSangLoc.Kieudemo;
            radDeThuong.Checked = objSangLoc.Kieudethuong;
            chkDinhDuong_BuBinh.Checked = objSangLoc.Dinhduongbubinh;
            chkDinhDuong_BuMe.Checked = objSangLoc.Dinhduongbume;
            chkDinhDuong_TinhMach.Checked = objSangLoc.Dinhduongtinhmach;
            chkTinhTragLayMau_BiBenh.Checked = objSangLoc.Ttdangbenh;
            chkTinhTragLayMau_BinhThuong.Checked = objSangLoc.Ttbinhthuong;
            chkTinhTragLayMau_KhangSinh.Checked = objSangLoc.Ttdungkhangsinh;
            chkTinhTragLayMau_Steriod.Checked = objSangLoc.Ttdungsteriod;
            chkTinhTragLayMau_TruyenMau.Checked = objSangLoc.Tttruyenmau;
            chkViTriLayMau_GotChan.Checked = objSangLoc.Vitrigotchan;
            chkViTriLayMau_Khac.Checked = objSangLoc.Vitrikhac;
            chkViTriLayMau_TinhMach.Checked = objSangLoc.Vitritinhmach;

            numCanNangMe.Value = (decimal)objSangLoc.Cannangme;
            numChieuCaoMe.Value = (decimal)objSangLoc.Chieucaome;
            numSoThai.Value = objSangLoc.Sothai;
            numTuoiThaiMe.Value = objSangLoc.Tuoithaime;
            chkIVF.Checked = objSangLoc.Ivf;
            chkHutThuoc.Checked = objSangLoc.Hutthuoc;
            numBPD.Value = objSangLoc.Bpd;
            cboChungToc.Text = objSangLoc.Chungtoc;
            txtDaiThaoDuong1.Text = objSangLoc.Daithaoduong;
            txtTienSu.Text = objSangLoc.Tiensu;
            txtBSSieuAm.Text = objSangLoc.Bssieuam;
            txtDiaChiMe.Text = objTiepNhan.Diachi;
            txtSDT.Text = objTiepNhan.Sdt;

            numBMIMe.Value = (decimal)objSangLoc.Bmi;
            numCRL.Value = objSangLoc.Crl;
            numXuongMui.Value = (decimal)objSangLoc.Xuongmui;
            txtDaiThaoDuong2.Text = objSangLoc.Daithaoduong2;
            chkHuyetApManTinh.Checked = objSangLoc.Tanghamantinh;
            chkTienSanGiat.Checked = objSangLoc.Thaiphumactsg;
            chkTienSanGiat_Ngoai.Checked = objSangLoc.Methaiphumactsg;
            chkAntiphosLipid.Checked = objSangLoc.Antiphospholipid;
            chkLupusBanDo.Checked = objSangLoc.Lupusbando;
            chkDacoThaiHon24.Checked = objSangLoc.Dacothaihon24;
            dtpNgaySinhTruoc.SetValue(objSangLoc.Ngaysinhtruoc);
            numTuoiThaiSinhTruoc.Value = objSangLoc.Tuoithaisinhtruoc;
            chkSinhT21T18T13.Checked = objSangLoc.Sinhcont21t18t13;
            dtpNgaySieuAm.SetValue(objSangLoc.Ngaysieuam);
            dtpNgayDuSinh.SetValue(objSangLoc.Ngaydusinh);

        }
        private void Set_AddNewMode()
        {
            if (txtBarcodeXN.ForeColor == Color.Red)
            {
                CustomMessageBox.MSG_Information_OK("Bạn đang trong chế độ nhập mới!");
                txtHoTenTre.Focus();
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
                    if (CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu.Equals(SystemStypeConstant.AutoBarcode.ToString()))
                    {
                        if (string.IsNullOrEmpty(txtBarcodeXN.Text))
                        {
                            txtBarcodeXN.Text = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpNgayTiepNhan.Value);
                            // txtMSBenhNhan.Text = Get_MaBenhNhan();
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
            if (ucSearchLookupEditor_Object1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn chương trình sàng lọc.");
                ucSearchLookupEditor_Object1.Focus();
                return;
            }
            var objTiepNhan = (string.IsNullOrEmpty(txtMaTiepNhan.Text) ? new BENHNHAN_TIEPNHAN() : informationService.Get_Info_BenhNhan_TiepNhan(txtMaTiepNhan.Text, new string[] { }));
            var objSangLoc = (string.IsNullOrEmpty(txtMaTiepNhan.Text) ? new BENHNHAN_MAUSANGLOC() : informationService.Get_ThongTinSLSoSinh(txtMaTiepNhan.Text));
            GetDataInformation(ref objTiepNhan, ref objSangLoc);
            objTiepNhan.Nguonnhap = InputSourceEnum.SangLocSoSinh.ToString();
            objTiepNhan.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(txtBarcodeXN.Text, dtpNgayTiepNhan.Value);
            objTiepNhan.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
            objSangLoc.Matiepnhan = objTiepNhan.Matiepnhan;
            objSangLoc.Tiensan = true;
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
            txtBarcodeXN.BackColor = Color.Empty;
            txtBarcodeXN.ForeColor = Color.Empty;
            gcPatient.Enabled = true;
            Get_DanhSach_TiepNhan();
            gvPatient.FindFilterText = objTiepNhan.Matiepnhan;
            LoadDataInfo(objTiepNhan.Matiepnhan);
            ucAddEditControl1.SetStatusButtonNormal();
            btnThemChiDinh.Focus();
        }
        
        private void Get_DanhSach_TiepNhan()
        {
            ucChiTietChiDinh1.gcChiDinh.DataSource = null;
            gvPatient.FocusedRowChanged -= GvPatient_FocusedRowChanged;
            gvPatient.FocusedColumnChanged -= GvPatient_FocusedColumnChanged;
            var data = (LoaiXetNghiemSangLocSoSinh? informationService.Data_DSTreSoSinhSangLoc(dtpNgayTiepNhan_DS.Value, dtpNgayTiepNhan_DS.Value) : informationService.Data_DSSangLocTruocSinh(dtpNgayTiepNhan_DS.Value, dtpNgayTiepNhan_DS.Value) );
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
            informationService.Delete_BenhNhan_TiepNhan(currentPatient.Matiepnhan, CommonAppVarsAndFunctions.UserID);
            ClearControl();
            SetLock_Unlock (true);
            Get_DanhSach_TiepNhan();
        }
        private void radSinh_CheckedChanged(object sender, EventArgs e)
        {
            var rd = (RadioButton)sender;
            if (rd.Checked)
            {
                SetSoLuongSinh();
            }
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
            var nhomdichVu = (ucSearchLookupEditor_NhomDichVu1.SelectedValue != null ? ucSearchLookupEditor_NhomDichVu1.SelectedValue.ToString() : string.Empty);

            var doiTuongDv = (ucSearchLookupEditor_Object1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_Object1.SelectedValue.ToString());
            var sex = (ucSearchLookupEditor_Gender1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_Gender1.SelectedValue.ToString());

            ucSearchLookupEditor_DanhSachDichVu1.ChiDinh_Keypress = ucSearchLookupEditor_DanhSachDichVu1_KeyPress;


            ucSearchLookupEditor_DanhSachDichVu1.Load_DanhMucDichVu(loaiDichVu, nhomdichVu, doiTuongDv, sex);

            ucSearchLookupEditor_DanhSachDichVu1.CatchEnterKey = true;
            ucSearchLookupEditor_DanhSachDichVu1.CatchTabKey = true;
            //ucSearchLookupEditor_DanhSachDichVu1.ControlNext = btnThemChiDinh;
            ucSearchLookupEditor_DanhSachDichVu1.ControlBack = ucSearchLookupEditor_NhomDichVu1;

        }
        private void InsertItem(string profileID)
        {
            if (txtBarcodeXN.ForeColor == Color.Red && CommonAppVarsAndFunctions.sysConfig.BenhNhanTuLuuThongTinNhapMoi)
            {
                SavePatient();
            }
            else if (ucAddEditControl1.btnSave.Enabled)
            {
                CustomMessageBox.MSG_Information_OK("Hãy lưu thông tin bệnh nhân trước khi nhập chỉ định!");
                ucAddEditControl1.Focus();
                ucAddEditControl1.btnSave.Focus();
            }

            if (ucSearchLookupEditor_DanhSachDichVu1.SelectedValue == null
                || ucSearchLookupEditor_DanhSachDichVu1.SelectedDataRowView == null)
                return;

            //1: madichvu
            //2: profile
            var maloaidichvu = ServiceType.ClsXetNghiem.ToString();
            var madichvu = ucSearchLookupEditor_DanhSachDichVu1.SelectedValue.ToString();
            var profileChar = ucSearchLookupEditor_DanhSachDichVu1.SelectedDataRowView.Row["isprofile"].ToString();
            //Xử lý insert bộ dịch vụ
            if (profileChar == ProfileTestContant.GroupChar)
            {
                var dataChiTietBo = sysConfig.Data_dm_xetnghiem_bo_chitiet(madichvu, string.Empty, false);
                if (dataChiTietBo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataChiTietBo.Rows)
                    {
                        var isProfile = bool.Parse(dr["XNProfile"].ToString());
                        var maChiDinh = dr["MaChiDinh"].ToString();
                        var pChar = isProfile ? ProfileTestContant.ProfileChar : ProfileTestContant.TestChar;
                        InsertDichVuXn(currentPatient, maChiDinh, pChar, profileID);
                    }
                }
            }
            else
            {
                InsertDichVuXn(currentPatient, madichvu, profileChar, profileID);
            }
            if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianNhapCD)
            {
                informationService.Update_ThoiGianThucHienXN(currentPatient.Matiepnhan);
                informationService.Update_ThoiGianThucHienXN_Nhom(currentPatient.Matiepnhan, (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
            }

            if (!string.IsNullOrEmpty(currentPatient.Doituongdichvu))
            {
                ucChiTietChiDinh1.Get_ChiTietChiDinh(currentPatient.Matiepnhan, null);
            }

            ucSearchLookupEditor_DanhSachDichVu1.Focus();
            ucSearchLookupEditor_DanhSachDichVu1.ShowPopup();

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
            if (e.KeyChar == (char)Keys.Enter && ucSearchLookupEditor_DanhSachDichVu1.SelectedValue != null)
            {
                InsertItem(string.Empty);
                e.Handled = true;
            }
        }
        public void Load_Config()
        {
            SetLock_Unlock(true);
            ucSearchLookupEditor_TinhGuiMau.Load_Tinh();
            ucSearchLookupEditor_Provice1.Load_Tinh();
            ucSearchLookupEditor_District1.Load_Data(string.Empty);
            ucSearchLookupEditor_Gender1.Load_GioiTinh();
            ucSearchLookupEditor_HuyenGuiMau.Load_Data(string.Empty);
           
            ucSearchLookupEditor_NhomDichVu1.Load_DanhMucNhomDichVu(ServiceType.ClsXetNghiem.ToString());
            ucSearchLookupEditor_NhomDichVu1.NhomChiDinh_EditValueChanged += ucSearchLookupEditor_NhomDichVu1_EditValueChanged;
            Load_DanhmucDichVu();
            ucSearchLookupEditor_Object1.Load_DoiTuong();
            ucSearchLookupEditor_NoiSinh.Load_DonVi(string.Empty);
            ucSearchLookupEditor_NoiGuiMau.Load_DonVi();
            ucSearchLookupEditor_BSChiDinh.Load_BacSi();
            Get_DanhSach_TiepNhan();
            objKhuLayMau = sysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);
            dtpNgayTiepNhan_DS.ValueChanged += DtpNgayTiepNhan_DS_ValueChanged;
            Check_Enable();
        }

        private void DtpNgayTiepNhan_DS_ValueChanged(object sender, EventArgs e)
        {
            Get_DanhSach_TiepNhan();
        }

        private void ucAddEditControl1_ButtonSaveClick(object sender, EventArgs e)
        {
            SavePatient();
        }

        private void ucAddEditControl1_ButtonEditClick(object sender, EventArgs e)
        {
            SetLock_Unlock(false);
            txtBarcodeXN.ReadOnly = true;
            txtHoTenTre.Focus();
        }

        private void ucAddEditControl1_ButtonDeleteClick(object sender, EventArgs e)
        {
            Delete_Patient();
        }

        private void txtBarcodeLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtHoTenTre);
        }

        private void txtHoTenTre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numTuoiThai);
        }

        private void numTuoiThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_Gender1);
        }

        private void numCanNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numChieuCao);
        }

        private void numChieuCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, dtpNgaySinh);
        }

        private void dtpNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtDanToc);
        }

        private void txtDanToc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, radSinh1);
        }

        private void txtHoTenMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtNamSinhMe);
        }

        private void txtNamSinhMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtHoTenBo);
        }

        private void txtHoTenBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtNamSinhBo);
        }

        private void txtNamSinhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtDiaChi);
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_Object1);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtDiDong);
        }

        private void txtDiDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtPara_1);
        }

        private void txtPara_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtPara_2);
        }

        private void txtPara_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtPara_3);
        }

        private void txtPara_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtPara_4);
        }

        private void txtPara_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, radDeThuong);
        }

        private void dtpTGLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtNguoiLayMau);
        }

        private void txtNguoiLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, ucSearchLookupEditor_NoiGuiMau);
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

        private void txtNamSinhBo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNamSinhBo.Text))
            {
                int _a = int.Parse(txtNamSinhBo.Text);
                if (_a < 1000)
                {
                    _a = dtpNgayTiepNhan.Value.Year - _a;
                }
                txtNamSinhBo.Text = _a.ToString();
            }
        }

        private void btnThemChiDinh_Click(object sender, EventArgs e)
        {
            InsertItem(string.Empty);
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
            objSangLoc.Sosinh = LoaiXetNghiemSangLocSoSinh;
            objSangLoc.Tiensan = !LoaiXetNghiemSangLocSoSinh;
            objSangLoc.Hotenme = GetDataWithMapping(dr, objConfig.Loaiimport,lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Hotenme));
            objTiepNhan.Tenbn = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Tenbn));
            CustomMessageBox.ShowAlert(string.Format("Đang import: {0}", (string.IsNullOrEmpty(objSangLoc.Hotenme) ? objTiepNhan.Tenbn : objSangLoc.Hotenme)), topMost: true);
            //importype: 1: SGP - 2: Immu - 3:Qsight
            objTiepNhan.Usernhap = CommonAppVarsAndFunctions.UserID;
            objTiepNhan.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
            objTiepNhan.Nguonnhap = (LoaiXetNghiemSangLocSoSinh ? InputSourceEnum.SangLocSoSinh.ToString() : InputSourceEnum.SangLocTruocSinh.ToString());
            objTiepNhan.Usercapnhat = CommonAppVarsAndFunctions.UserID;
            objTiepNhan.Ngaytiepnhan = dtpNgayTiepNhan.Value;
            objSangLoc.Barcodelaymau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Barcodelaymau));
            objTiepNhan.Seq = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpNgayTiepNhan.Value);
            objTiepNhan.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(objTiepNhan.Seq, dtpNgayTiepNhan.Value);
            objSangLoc.Matiepnhan = objTiepNhan.Matiepnhan;
            objTiepNhan.Mabn = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Mabn));
            objTiepNhan.Quoctich = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Quoctich));
            if (string.IsNullOrEmpty(objTiepNhan.Quoctich))
                objTiepNhan.Quoctich = "VIỆT NAM";
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

            //ngày dự sinh
            var ngayDuSinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Ngaydusinh)).Trim();
            var ngaygioDuSinh = DateTime.Now;
            if (!string.IsNullOrEmpty(ngayDuSinh))
            {
                DateTime.TryParse(ngayDuSinh, out ngaygioDuSinh);
                //GIO LAY
                if (ngaygioDuSinh.Equals(DateTime.MinValue))
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("Ngày dự sinh của {0} không hợp lệ.", objTiepNhan.Tenbn));
                }
                else
                {
                    objSangLoc.Ngaydusinh = ngaygioDuSinh;
                }
            }
            var Madonvi = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Madonvi)).Trim();
            objTiepNhan.Madonvi = ucSearchLookupEditor_NoiGuiMau.GetObjectIdByName(Madonvi);
            if(string.IsNullOrEmpty(objTiepNhan.Madonvi))
            {
                objTiepNhan.Madonvi = ucSearchLookupEditor_NoiGuiMau.GetObjectIdImport(Madonvi);
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
            if (LoaiXetNghiemSangLocSoSinh)
            {
                var Noisinh = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Noisinh)).Trim();
                objSangLoc.Noisinh = ucSearchLookupEditor_NoiGuiMau.GetObjectIdByName(Noisinh);
                if (string.IsNullOrEmpty(objSangLoc.Noisinh))
                {
                    objSangLoc.Noisinh = ucSearchLookupEditor_NoiGuiMau.GetObjectIdImport(Noisinh);
                }
            }
            else
                objSangLoc.Noisinh = string.IsNullOrEmpty(objTiepNhan.Madonvi) ? objSangLoc.Noiguimau : objTiepNhan.Madonvi;

            objSangLoc.Dantoc = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Dantoc)).Trim();
            objSangLoc.Diachinoiguimau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Diachinoiguimau)).Trim();
            var Noiguimau = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Noiguimau)).Trim();
            objSangLoc.Noiguimau = ucSearchLookupEditor_NoiGuiMau.GetObjectIdByName(Noiguimau);
            if (string.IsNullOrEmpty(objSangLoc.Noiguimau))
            {
                objSangLoc.Noiguimau = ucSearchLookupEditor_NoiGuiMau.GetObjectIdImport(Noiguimau);
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
            if (string.IsNullOrEmpty(objSangLoc.Chungtoc))
                objSangLoc.Chungtoc = "VIỆT NAM";
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
            informationService.Insert_BenhNhan_TiepNhan(objTiepNhan, true);
            informationService.Insert_ThongTinSLSoSinh(objSangLoc);
            var nguoixacnhan = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.NguoixacnhanKQ)).Trim();
            var dtnguoiXacNhan = WorkingServices.SearchResult_OnDatatable(dataUser, string.Format("TenNhanVien = '{0}'", nguoixacnhan.Trim()));
            if(dtnguoiXacNhan.Rows.Count >0)
            {
                nguoixacnhan = dtnguoiXacNhan.Rows[0]["MaNguoiDung"].ToString();
            }
            var bsKyTen = GetDataWithMapping(dr, objConfig.Loaiimport, lstobjMapping, ControlExtension.PropertyName<PatientImportInfo>(x => x.Nguoikyten)).Trim();
            var dtnguoiIn = WorkingServices.SearchResult_OnDatatable(dataUser, string.Format("TenNhanVien = '{0}'", bsKyTen.Trim()));
            if (dtnguoiIn.Rows.Count > 0)
            {
                bsKyTen = dtnguoiIn.Rows[0]["MaNguoiDung"].ToString();
            }

            var lstXNInsert = lstobjMapping.Where(x => !string.IsNullOrEmpty(x.Maxnlis) && x.Liscolumn.Equals(ControlExtension.PropertyName<PatientImportInfo>(x2 => x2.Maxetnghiem)));
            if (lstXNInsert.Any())
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

                        InsertDichVuXn(objTiepNhan, maXn, ProfileTestContant.TestChar, goiXetNghiem);
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

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaBenhNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
