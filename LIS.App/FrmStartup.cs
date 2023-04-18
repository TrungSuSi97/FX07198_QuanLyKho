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
    public partial class FrmStartUp : Form
    {
        public FrmStartUp()
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
                = fParent.rbTiepNhanHIS.Visibility 
                = (CommonAppVarsAndFunctions.sysConfig.ConnectHIS ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
            fParent.rbThuPhi.Visibility =
                ((CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh == EnumQuiTrinhLAB.NhapTay_ThuTien_KetQua || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);

            CheckEnableControls();


            //Kiểm tra bật tắt chức năng siêu âm
            //lblUltraSound.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.ClsSieuAm);
            //Kiểm tra bật tắt khám bệnh
            //  pnKhamBenh.Visible = fParent.mnuDMKhamBenh.Visible = fParent.mnuKhamBenh.Visible = CommonAppVarsAndFunctions.CheckExist_LoaiDichVu(ServiceType.KhamBenh);
            if (!pnKhamBenh.Visible)
            {
                pnMenuMain.Width = pnMenuMain.Width - pnKhamBenh.Width;
                pnMenuMain.Location = new Point(pnMenuMain.Location.X + ( pnKhamBenh.Width / 2) + (pnKhamBenh.Width / 4 ), pnMenuMain.Location.Y);
            }

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
            lblThongKeTongHop.Enabled = fParent.rbThongKeTongHopXn.Enabled;


            lblLayMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestCollectSample);
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
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_LayMau_KetQua:
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_LayMau_NhanMau_KetQua:
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_NhanMau_KetQua:
            //        lblLayMau.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTuHIS_KetQua:
            //        fParent.btnTiepNhanThuCong.Visible = false;
            //        lblLayMau.Visible = false;
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTuHIS_LayMau_KetQua:
            //        fParent.btnTiepNhanThuCong.Visible = false;
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
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua:
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianLayMau;
            //        break;
            //    case EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua:
            //        CommonAppVarsAndFunctions.gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhanMau;
            //        break;
            //    default:
            //        lblLayMau.Visible = true;
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