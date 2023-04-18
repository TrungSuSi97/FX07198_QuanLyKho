using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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
    public partial class FrmStartup_Old : Form
    {
        public FrmStartup_Old()
        {
            InitializeComponent();
            ShowManChe();
        }
        Panel manche = new Panel();
        public void ShowManChe()
        {
            if (manche == null)
                manche = new Panel();
            manche.BackColor = Color.FromArgb(224, 238, 243);
            manche.Size = this.Size;
            manche.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(manche);
            manche.BringToFront();

        }
        public void AnManChe()
        {
            manche.Size = new Size(0, 0);
            this.Controls.Remove(manche);
        }
        private void btnChangePass_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmMDIParent fm = (frmMDIParent)this.MdiParent;
            fm.LogOut();
        }

        private void FrmStartUp_Load(object sender, EventArgs e)
        {
            lblTieuDe.Focus();
        }

        private void FrmStartUp_Shown(object sender, EventArgs e)
        {

            frmMDIParent fParent = (frmMDIParent)this.MdiParent;

            fParent.rbCauHinhHeThong.Enabled = fParent.rbCaiDatKetNoiHis.Enabled = CommonAppVarsAndFunctions.IsAdmin;

            fParent.rbKQUploadHIS.Visibility =
                fParent.rbDanhMucKetNoiHIS.Visibility
                = fParent.rbCaiDatKetNoiHis.Visibility
                = fParent.rbTiepNhanHIS.Visibility = (CommonAppVarsAndFunctions.sysConfig.ConnectHIS ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                 lblTiepNhanHis.Visible 
                = CommonAppVarsAndFunctions.sysConfig.ConnectHIS;
            fParent.rbThuPhi.Visibility =
                ((CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh == EnumQuiTrinhLAB.NhapTay_ThuTien_KetQua || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);

            CheckEnableControls();


            //Kiểm tra bật tắt chức năng siêu âm
            lblUltraSound.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsSieuAm);
            //fParent.rbKetQuSieuAm.Visibility = (lblUltraSound.Visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);// fParent.mnuKQSieuAm.Visible = fParent.mnuTKTongHopSieuAm.Visible =;
            //Kiểm tra bật tắt chức năng X-Quang
            lblXRay.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsXQuang);
            //fParent.rbXQuang.Visibility = (lblXRay.Visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never); // = fParent.mnuTKTongHopXQuang.Visible;
            //Kiểm tra bật tắt chức năng điện tim
            lblElectrocardiogram.Visible = (CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.Enclitic) || CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.DvKhac)); 
             fParent.rbDichVuKhac.Visibility = (lblElectrocardiogram.Visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never); //fParent.mnuCLS_KQDV_Khac.Visible = 
            //Kiểm tra bật tắt chức năng điện tim
            lblEndoscopic.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsNoiSoi);
            //fParent.rbNoiSoi.Visibility = (lblEndoscopic.Visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never); // = fParent.mnuKQNoiSoi.Visible = fParent.mnuTKTongHopNoiSoi.Visible = 

            //if (lblUltraSound.Visible || lblXRay.Visible || lblElectrocardiogram.Visible || lblEndoscopic.Visible)
            //    fParent.rbGroupKetQuaCLSKhac.Visible = true;
            //else
            //    fParent.rbGroupKetQuaCLSKhac.Visible = false;
            //Kiểm tra bật tắt khám bệnh
            //  pnKhamBenh.Visible = fParent.mnuDMKhamBenh.Visible = fParent.mnuKhamBenh.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.KhamBenh);
            if (!pnKhamBenh.Visible)
            {
                pnMenuMain.Width = pnMenuMain.Width - pnKhamBenh.Width;
                pnMenuMain.Location = new Point(pnMenuMain.Location.X + ( pnKhamBenh.Width / 2) + (pnKhamBenh.Width / 4 ), pnMenuMain.Location.Y);
            }
            //Kiểm tra bật tắt vi sinh
            lblKetqQuaViSinh.Visible = lblXuatKetQuaViSinh.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsXNViSinh);
            fParent.rbKQViSinhNuoiCay.Visibility = fParent.rbDanhMucViSinh.Visibility = (lblKetqQuaViSinh.Visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
            lbltraKetQua.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungDanhSachChoTraKQ;

            //if(lblUltraSound.Visible || lblXRay.Visible || lblElectrocardiogram.Visible || pnKhamBenh.Visible
            //    || lblKetqQuaViSinh.Visible)
            //{
            //    fParent.mnuTKCanLamSang.Visible = true;
            //}
            //else
            //    fParent.mnuTKCanLamSang.Visible = false;
            AnManChe();
        }
        private void CheckEnableControls()
        {

            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            lblPatientInfo.Enabled = fParent.rbTiepNhanBenhNhan.Enabled;
            lblTiepNhanHis.Enabled = fParent.rbTiepNhanHIS.Enabled;
            lblSearPatient.Enabled = fParent.rbTimKiem.Enabled;

            lblLaboratory.Enabled = fParent.rbKetQuaThuongQuy.Enabled;
            lblKetQuaSHPT.Enabled = fParent.rbKQSinhHocPhanTu.Enabled;
            lblKetqQuaViSinh.Enabled = fParent.rbKQViSinhNuoiCay.Enabled;

            lblXuatKetQuaThuongQui.Enabled = fParent.rbXuatKetQua.Enabled;
            lblThongKeTongHop.Enabled = fParent.rbThongKeTongHopXn.Enabled;

            lblXuatKetQuaViSinh.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSExportResult);

            lblLayMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestCollectSample);
            lblNhanMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestGetSample);
            lbltraKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionReturnResult);
            lblChuyenMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);
            Check_VisibleRule();
        }
        private void Check_VisibleRule()
        {
            //frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            //var processRule = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh;
            //switch (processRule)
            //{
            //    case EnumQuiTrinhLAB.NhapTay_KetQua:
            //        lblLayMau.Visible = false;
            //        lblNhanMau.Visible = false;
            //        fParent.btnTiepNhanHis.Visible = fParent.tsbLayMau.Visible = fParent.tsbNhanMau.Visible = fParent.tsbChuyenMau.Visible = lblTiepNhanHis.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_LayMau_KetQua:
            //        lblNhanMau.Visible = false;
            //        fParent.btnTiepNhanHis.Visible = fParent.tsbNhanMau.Visible = fParent.tsbChuyenMau.Visible = lblTiepNhanHis.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_LayMau_NhanMau_KetQua:
            //        fParent.btnTiepNhanHis.Visible = lblTiepNhanHis.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_NhanMau_KetQua:
            //        lblLayMau.Visible = false;
            //        fParent.btnTiepNhanHis.Visible = fParent.tsbLayMau.Visible = lblTiepNhanHis.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTuHIS_KetQua:
            //        fParent.btnTiepNhanThuCong.Visible = false;
            //        lblLayMau.Visible = false;
            //        lblNhanMau.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTuHIS_LayMau_KetQua:
            //        fParent.btnTiepNhanThuCong.Visible = false;
            //        lblNhanMau.Visible = false;
            //        fParent.tsbChuyenMau.Visible = fParent.tsbNhanMau.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTuHIS_NhanMau_KetQua:
            //        fParent.btnTiepNhanThuCong.Visible = false;
            //        lblLayMau.Visible = false;
            //        fParent.tsbLayMau.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTuHIS_LayMau_NhanMau_KetQua:
            //        fParent.btnTiepNhanThuCong.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_ThuTien_KetQua:
            //        lblLayMau.Visible = false;
            //        lblNhanMau.Visible = false;
            //        fParent.btnTiepNhanHis.Visible = fParent.tsbNhanMau.Visible = fParent.tsbLayMau.Visible = lblTiepNhanHis.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua:
            //        lblNhanMau.Visible = false;
            //        fParent.btnTiepNhanHis.Visible = fParent.tsbNhanMau.Visible = lblTiepNhanHis.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua:
            //        fParent.btnTiepNhanHis.Visible = lblTiepNhanHis.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    default:
            //        lblLayMau.Visible = true;
            //        lblNhanMau.Visible = true;
            //        fParent.btnTiepNhanHis.Visible = fParent.tsbLayMau.Visible = lblTiepNhanHis.Visible = true;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
            //        break;
            //}


        }

        private void lblPatientFile_Click(object sender, EventArgs e)
        {
            FrmHoSoBenhAn f = new FrmHoSoBenhAn();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblSearPatient_Click(object sender, EventArgs e)
        {
            FrmTimBenhNhan f = new FrmTimBenhNhan();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblUltraSound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCLSKQSieuAm f = new frmCLSKQSieuAm();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblEndoscopic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCLSKQNoiSoi f = new frmCLSKQNoiSoi();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblXRay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCLSKetQuaXQuang f = new frmCLSKetQuaXQuang();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblElectrocardiogram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDienTim f = new FrmDienTim();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblLaboratory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCLSKetQuaXN f = new frmCLSKetQuaXN();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblKhamBenh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKhamBenh f = new FrmKhamBenh();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblPatientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmTiepNhanBenhNhan();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblInvoice_Click(object sender, EventArgs e)
        {
            FrmThuPhiDichVu f = new FrmThuPhiDichVu();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lblSearPatient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmTimBenhNhan f = new FrmTimBenhNhan();
            f.DtDateFromG = DateTime.Now.AddMonths(-1);
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lblReception_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new DailyUse.BenhNhan.FrmTiepNhanBenhNhan();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lblOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmChiDinhCLS f = new FrmChiDinhCLS();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void lblNhapTheoDanhSach_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FrmTiepNhanTuiMau f = new FrmTiepNhanTuiMau();
            //frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            //fParent.ShowForm(f);
        }
        private void lblCheckResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FrmDuyetKetquaXN f = new FrmDuyetKetquaXN();
            //frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            //fParent.ShowForm(f);
        }

        private void lblXuatKQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new ThongKe.frmXuatKetQuaXetNghiem();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblInterFace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.StartInterface();
        }
        private void lblTiepNhanHis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmTiepNhanHIS();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lblKetQuaSHPT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new DailyUse.CanLamSang.FrmSinhHocPhanTu();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lblLayMau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new DailyUse.BenhNhan.FrmLayMau();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lbltraKetQua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new DailyUse.BenhNhan.FrmTraKetQua();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }
        private void lblKetqQuaViSinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var f = new DailyUse.CanLamSang.FrmKetQuaCLSXetNghiem_ViSinhNuoiCay();
            //frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            //fParent.ShowForm(f);
        }

        private void lblNhanMau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmCLSXetNghiem_DuyetNhanMau();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblThongKeTongHop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new ThongKe.frmThongKeTongHopXN();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void FrmStartUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BackgroundImage = null;
        }

        private void lblChuyenMau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmXacNhanChuyenMau();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void lblXuatKetQuaViSinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new frmXuatKetQuaXetNghiem_ViSinh();
            frmMDIParent fParent = (frmMDIParent)this.MdiParent;
            fParent.ShowForm(f);
        }

        private void FrmStartUp_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}