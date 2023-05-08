using System;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Language;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.LIS.App.DailyUse.CanLamSang;
using TPH.LIS.App.ThongKe;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.App.ThucThi.CanLamSang;
using TPH.LIS.App.ThucThi.KhamLamSang;
using TPH.LIS.Common;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App
{
    
    public partial class FrmHome : Form
    {
        
        public FrmHome()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            this.BackColor = CommonAppColors.ColorAppFormColor;
            //pnTop.BackColor = CommonAppColors.ColorMainAppColor;
            ShowManChe();
        }
        Panel _manche = new Panel();
        public void ShowManChe()
        {
            if (_manche == null)
                _manche = new Panel();
            _manche.BackColor = Color.FromArgb(224, 238, 243);
            _manche.Size = this.Size;
            _manche.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(_manche);
            _manche.BringToFront();
        }
        public void AnManChe()
        {
            _manche.Size = new Size(0, 0);
            this.Controls.Remove(_manche);
        }
        private void btnChangePass_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            lblUserName.Text = CommonAppVarsAndFunctions.HelloUserId;
            lblTieuDe.Focus();
            lblPCName.Text = Environment.MachineName;
            lblUserId.Text = GetOSFriendlyName();
            lblSystemType.Text = Environment.Is64BitOperatingSystem ? "64-bit operating system" : "32-bit operating system";
        }
        private static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

        private void FrmHome_Shown(object sender, EventArgs e)
        {
            frmParent_old fParent = (frmParent_old) this.TopLevelControl;

            fParent.rbCauHinhHeThong.Enabled = fParent.rbCaiDatKetNoiHis.Enabled = CommonAppVarsAndFunctions.IsAdmin;
            //fParent.rabCapNhatThongTinTuHis.Visible =
            //    fParent.rbKQUploadHIS.Visible
            //        = fParent.rbTiepNhanHIS.Visible = CommonAppVarsAndFunctions.sysConfig.ConnectHIS;
            //lblTiepNhanHis.Visible = fParent.rbLayMau.Visible = CommonAppVarsAndFunctions.sysConfig.ConnectHIS;
            //fParent.btnThuPhi.Visible =
            //    ((CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh ==
            //      EnumQuiTrinhLAB.NhapTay_ThuTien_KetQua ||
            //      CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh ==
            //      EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua ||
            //      CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh ==
            //      EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua)
            //        ? true
            //        : false);
            //fParent.rbGroupCaiDatKetNoiHis.Visible = (CommonAppVarsAndFunctions.sysConfig.ConnectHIS || CommonAppVarsAndFunctions.sysConfig.TPHLabIMSWeb_TuDongGuiChiDinh);
            CheckEnableControls();

            //Kiểm tra bật tắt chức năng siêu âm
            lblUltraSound.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsSieuAm);
            fParent.rbKetQuSieuAm.Visible =
                (lblUltraSound.Visible
                    ? true
                    : false); // fParent.mnuKQSieuAm.Visible = fParent.mnuTKTongHopSieuAm.Visible =;
            //Kiểm tra bật tắt chức năng X-Quang
            lblXRay.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsXQuang);
            fParent.rbXQuang.Visible = (lblXRay.Visible); // = fParent.mnuTKTongHopXQuang.Visible;
            //Kiểm tra bật tắt chức năng điện tim
            lblElectrocardiogram.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.Enclitic) ||
                                           CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.DvKhac);
            //  fParent.rbDichVuKhac.Visible = (lblElectrocardiogram.Visible ? true : false); //fParent.mnuCLS_KQDV_Khac.Visible = 
            //Kiểm tra bật tắt chức năng điện tim
            lblEndoscopic.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsNoiSoi);
            fParent.rbNoiSoi.Visible =
                (lblEndoscopic.Visible); // = fParent.mnuKQNoiSoi.Visible = fParent.mnuTKTongHopNoiSoi.Visible = 

            //if (lblUltraSound.Visible || lblXRay.Visible || lblElectrocardiogram.Visible || lblEndoscopic.Visible)
            //    fParent.rbGroupKetQuaCLSKhac.Visible = true;
            //else
            //    fParent.rbGroupKetQuaCLSKhac.Visible = false;

            //Kiểm tra bật tắt khám bệnh
            //if (!pnKhamBenh.Visible)
            //{
            //    pnMenuMain.Width = pnMenuMain.Width - pnKhamBenh.Width;
            //    pnMenuMain.Location = new Point(pnMenuMain.Location.X + (pnKhamBenh.Width / 2) + (pnKhamBenh.Width / 4), pnMenuMain.Location.Y);
            //}

            //Kiểm tra bật tắt vi sinh
            //   lblKetqQuaViSinh.Visible = lblXuatKetQuaViSinh.Visible =
            //       CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemViSinhNuoicay);

            //   fParent.rbDanhMucViSinh.Visible = fParent.rbKQViSinhNuoiCay.Visible =
            //       fParent.rbDanhMucViSinh.Visible = (lblKetqQuaViSinh.Visible);
            //   lbltraKetQua.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungDanhSachChoTraKQ;

            ////   lblNhapViTriChayMau.Visible =
            //       lblThongTinMauSangLocSoSinh.Visible = lblThongTinMauSangLocTruocSinh.Visible =
            //       btnKetQuaSangLocSoSinh.Visible = lblKetQuaSangLocTruocSinh.Visible =
            //           CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemSangLoc);
            //   fParent.rbThongTinSangLocSoSinh.Visible = fParent.rbThongTinSangLocTruocSinh.Visible =
            //       (lblThongTinMauSangLocTruocSinh.Visible);

            //   lblLaboratoryResult.Visible = CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemThuongQuy);
            //   fParent.rbInTheoDanhSach.Visible = fParent.rbKetQuaThuongQuy.Visible = (lblLaboratoryResult.Visible);
            //   //fParent.tsbKetQuaXN.Visible = lblLaboratoryResult.Visible;

            //   lblKetQuaSHPT.Visible = CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemSHPT);
            //   fParent.rbKQSinhHocPhanTu.Visible = lblLaboratoryResult.Visible;
            //   fParent.rbKQSinhHocPhanTu.Visible = lblKetQuaSHPT.Visible;

            //   if (!lblLaboratoryResult.Visible && !lblKetQuaSHPT.Visible)
            //   {
            //       fParent.rbXuatKetQua.Visible = false;
            //       lblXuatKetQuaThuongQui.Visible = false;
            //   }

            //   lblKetQuaHuyetTuyDo.Visible = CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemHuyetTuyDo);
            fParent.btnBenhNhan.Enabled = true;
            fParent.btnCaiDat.Enabled = true;
            fParent.btnDanhMuc.Enabled = true;
            fParent.btnKetQua.Enabled = true;
            fParent.btnOngMau.Enabled = true;
            fParent.btnTaiKhoan.Enabled = true;
            fParent.btnThongKe.Enabled = true;
            fParent.btnThuPhi.Enabled = true;
            fParent.btnTrangChinh.Enabled = true;
            AnManChe();
            LanguageExtension.LocalizeForm(this, string.Empty);
        }

        private void CheckEnableControls()
        {
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            lblTiepNhanHis.Enabled = fParent.rbTiepNhanHIS.Enabled;
            lblSearPatient.Enabled = fParent.rbTimKiem.Enabled;
            lblReception.Enabled = fParent.rbTiepNhanBenhNhan.Enabled;
            lblLaboratoryResult.Enabled = fParent.rbKetQuaThuongQuy.Enabled;
            lblKetQuaSHPT.Enabled = fParent.rbKQSinhHocPhanTu.Enabled;
            lblKetqQuaViSinh.Enabled = fParent.rbKQViSinhNuoiCay.Enabled;
            lblKetQuaSangLocTruocSinh.Enabled = fParent.rbKetQuaThuongQuy.Enabled;
            btnKetQuaSangLocSoSinh.Enabled = fParent.rbKetQuaThuongQuy.Enabled;
            lblNhapViTriChayMau.Enabled = fParent.rbKetQuaThuongQuy.Enabled;
            lblXuatKetQuaThuongQui.Enabled = fParent.rbXuatKetQua.Enabled;
            lblThongKeTongHop.Enabled = fParent.rbThongKeTongHopXn.Enabled;
            lblKetQuaHuyetTuyDo.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestViewResult);
            lblXuatKetQuaViSinh.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSExportResult);
            lblThongTinMauSangLocSoSinh.Enabled = fParent.rbThongTinSangLocSoSinh.Enabled;
            lblThongTinMauSangLocTruocSinh.Enabled = fParent.rbThongTinSangLocTruocSinh.Enabled;
            lblLayMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestCollectSample);
            lblNhanMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestGetSample);
            lbltraKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionReturnResult);
            lblChuyenMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);
            //Check_VisibleRule();

        }
        private void Check_VisibleRule()
        {
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            var processRule = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh;
            switch (processRule)
            {
                case EnumQuiTrinhLAB.NhapTay_KetQua:
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    lblLayMau.Visible = false;
                    lblNhanMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    fParent.rbTiepNhanHIS.Visible = fParent.rbLayMau.Visible = fParent.rbNhanMau.Visible = fParent.rbChuyenMau.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
                    break;
                case EnumQuiTrinhLAB.NhapTay_LayMau_KetQua:
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    lblNhanMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    fParent.rbTiepNhanHIS.Visible = fParent.rbNhanMau.Visible = fParent.rbChuyenMau.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
                    fParent.rbLayMau.Visible = true;
                    break;
                case EnumQuiTrinhLAB.NhapTay_LayMau_NhanMau_KetQua:
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    fParent.rbTiepNhanHIS.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
                    fParent.rbLayMau.Visible = true;
                    break;
                case EnumQuiTrinhLAB.NhapTay_NhanMau_KetQua:
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    lblLayMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    fParent.rbTiepNhanHIS.Visible = fParent.rbLayMau.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
                    break;
                case EnumQuiTrinhLAB.NhapTuHIS_KetQua:
                    // fParent.rbTiepNhanBenhNhan.Visible = false;
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    lblLayMau.Visible = false;
                    lblNhanMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
                    break;
                case EnumQuiTrinhLAB.NhapTuHIS_LayMau_KetQua:
                    //  fParent.rbTiepNhanBenhNhan.Visible = false;
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    lblNhanMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    fParent.rbChuyenMau.Visible = fParent.rbNhanMau.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
                    break;
                case EnumQuiTrinhLAB.NhapTuHIS_NhanMau_KetQua:
                    //  fParent.rbTiepNhanBenhNhan.Visible = false;
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    lblLayMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    fParent.rbLayMau.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
                    break;
                case EnumQuiTrinhLAB.NhapTuHIS_LayMau_NhanMau_KetQua:
                    //  fParent.rbTiepNhanBenhNhan.Visible = false;
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
                    break;
                case EnumQuiTrinhLAB.NhapTay_ThuTien_KetQua:
                    lblInvoice.Visible = true;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = true;
                    lblLayMau.Visible = false;
                    lblNhanMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    fParent.rbTiepNhanHIS.Visible = fParent.rbNhanMau.Visible = fParent.rbLayMau.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
                    break;
                case EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua:
                    lblInvoice.Visible = true;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = true;
                    lblNhanMau.Visible = false;
                    lblChuyenMau.Visible = false;
                    fParent.rbTiepNhanHIS.Visible = fParent.rbNhanMau.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
                    break;
                case EnumQuiTrinhLAB.NhapTay_ThuTien_NhanMau_KetQua:
                    fParent.rbLayMau.Visible = lblLayMau.Visible = false;
                    fParent.rbChuyenMau.Visible = lblChuyenMau.Visible = false;
                    lblInvoice.Visible = true;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = true;
                    fParent.rbTiepNhanHIS.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
                    break;
                case EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua:
                    lblInvoice.Visible = true;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = true;
                    fParent.rbTiepNhanHIS.Visible = lblTiepNhanHis.Visible = false;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
                    break;
                default:
                    lblInvoice.Visible = false;
                    fParent.rbThuPhiDichVu.Visible = fParent.rbBaoCaoDoanhThu.Visible = false;
                    lblLayMau.Visible = true;
                    lblNhanMau.Visible = true;
                    lblChuyenMau.Visible = true;
                    fParent.rbTiepNhanHIS.Visible = fParent.rbLayMau.Visible = lblTiepNhanHis.Visible = true;
                    CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
                    break;
            }
        }
        private void lblPatientFile_Click(object sender, EventArgs e)
        {
            FrmHoSoBenhAn f = new FrmHoSoBenhAn();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }

        private void lblSearPatient_Click(object sender, EventArgs e)
        {
            var f = new FrmTimBenhNhan();
            f.pnMenu.Visible = false;
            var fParent = (frmParent_old)this.TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblUltraSound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCLSKQSieuAm f = new frmCLSKQSieuAm();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }

        private void lblEndoscopic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCLSKQNoiSoi f = new frmCLSKQNoiSoi();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }

        private void lblXRay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCLSKetQuaXQuang f = new frmCLSKetQuaXQuang();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }

        private void lblElectrocardiogram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDienTim f = new FrmDienTim();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }

        private void lblKhamBenh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKhamBenh f = new FrmKhamBenh();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }

        private void lblInvoice_Click(object sender, EventArgs e)
        {
            var f = new FrmThuPhiDichVu();
            var fParent = (frmParent_old)this.TopLevelControl;
            fParent?.ShowForm(f);
        }
        private void lblOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmChiDinhCLS f = new FrmChiDinhCLS();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }
        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }
        private void FrmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BackgroundImage = null;
        }
        private void FrmHome_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void lblNhapViTriChayMau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmNhapViTriMauSangLocSoSinh();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }
        private void btnKetQuaSangLocSoSinh_licked(object sender, EventArgs e)
        {
            var f = new FrmKetQuaXnSangLocSoSinh();
            frmParent_old fParent = (frmParent_old)this.TopLevelControl;
            fParent.ShowForm(f);
        }

        private void lblAboutUs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmAboutUs();
            f.ShowDialog();
        }

        private void FrmHome_ResizeEnd(object sender, EventArgs e)
        {
            this.BackgroundImage = global::TPH.LIS.App.Properties.Resources.bg;
        }
        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void FrmHome_Resize(object sender, EventArgs e)
        {
            //this.BackgroundImage = null;
        }

        private void lblReception_Click(object sender, EventArgs e)
        {
            var f = new FrmTiepNhanBenhNhan();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lbltraKetQua_Click(object sender, EventArgs e)
        {
            var f = new FrmTraKetQua();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblTiepNhanHis_Click(object sender, EventArgs e)
        {
            //var f = new FrmTiepNhanHIS();
            //var fParent = (frmParent_old)TopLevelControl;
            //fParent?.ShowForm(f);
        }

        private void lblThongTinMauSangLocTruocSinh_Click(object sender, EventArgs e)
        {
            var f = new FrmThongTinSangLocTruocSinh();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblThongTinMauSangLocSoSinh_Click(object sender, EventArgs e)
        {
            var f = new FrmThongTinSangLocSoSinh();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblThongKeTongHop_Click(object sender, EventArgs e)
        {
            var f = new frmThongKeTongHopXN();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblXuatKetQuaViSinh_Click(object sender, EventArgs e)
        {
            var f = new frmXuatKetQuaXetNghiem_ViSinh();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblXuatKetQuaThuongQui_Click(object sender, EventArgs e)
        {
            var f = new frmXuatKetQuaXetNghiem();
            frmParent_old fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblLayMau_Click(object sender, EventArgs e)
        {
            //var f = new FrmLayMau();
            //var fParent = (frmParent_old)TopLevelControl;
            //fParent?.ShowForm(f);
        }

        private void lblChuyenMau_Click(object sender, EventArgs e)
        {
            var f = new FrmXacNhanChuyenMau();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblNhanMau_Click(object sender, EventArgs e)
        {
            var f = new FrmCLSXetNghiem_DuyetNhanMau();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblLaboratoryResult_Click(object sender, EventArgs e)
        {
            var f = new frmCLSKetQuaXN();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblKetqQuaViSinh_Click(object sender, EventArgs e)
        {
            var f = new FrmCLSKetQuaViSinh();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblKetQuaSHPT_Click(object sender, EventArgs e)
        {
            var f = new FrmSinhHocPhanTu();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblKetQuaHuyetTuyDo_Click(object sender, EventArgs e)
        {
            var f = new FrmCLS_KetQua_HuyetTuyDo();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void lblKetQuaSangLocTruocSinh_Click(object sender, EventArgs e)
        {
            var f = new FrmKetQuaXnSangLocTruocSinh();
            var fParent = (frmParent_old)TopLevelControl;
            fParent?.ShowForm(f);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            CommonAppVarsAndFunctions.IsLogOut = true;
            Application.Restart();
        }
    }
}