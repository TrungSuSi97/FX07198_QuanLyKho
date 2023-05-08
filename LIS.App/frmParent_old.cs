using Microsoft.AspNet.SignalR.Client;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Language;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.CauHinh.DanhMucCLS;
using TPH.LIS.App.CauHinh.DanhMucKhamBenh;
using TPH.LIS.App.CauHinh.HeThong;
using TPH.LIS.App.CauHinh.NhanVien;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.LIS.App.DailyUse.CanLamSang;
using TPH.LIS.App.DailyUse.NhatKy;
using TPH.LIS.App.Settings.DanhMucCLS;
using TPH.LIS.App.Settings.DanhMucCLS.ViSinh;
using TPH.LIS.App.Settings.HeThong;
using TPH.LIS.App.Settings.NhanVien;
using TPH.LIS.App.Statistics;
using TPH.LIS.App.ThongKe;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.App.ThucThi.CanLamSang;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Constants;

namespace TPH.LIS.App
{
    public partial class frmParent_old : TPHParentForm
    {
        public void LockMenuItem(TPHDropdownMenuStrip menu)
        {
            foreach (var item in menu.Items)
            {
                if (item is ToolStripMenuItem)
                {

                    ((ToolStripMenuItem)item).Enabled = false;
                }
            }
        }
        public void LockAllMenu()
        {
            LockMenuItem(tphDropdownBenhNhan);
            LockMenuItem(tphDropdownCauHinh);
            LockMenuItem(tphDropdownDanhMuc);
            LockMenuItem(tphDropdownKetQua);
            LockMenuItem(tphDropdownMenuHanhChinh);
            LockMenuItem(tphDropdownOngMau);
            LockMenuItem(tphDropdownThongKe);
            LockMenuItem(tphDropdownThuPhi);
        }
        public void Check_EnableControl(string userId)
        {
            rbCapNhatPhanMem.Enabled = true;
            btnTrangChinh.Enabled = true;
            rbDangKy.Enabled = true;
            btnTaiKhoan.Enabled = true;

            Check_Enable_BangLuong();

            Check_Enable_ViSinh();
            Check_Enable_TN();
            Check_Enable_XN();
            Check_Enable_SA();
            Check_Enable_ThuNgan();
            Check_Enable_QuanLy();
            mnuCapNhatData.Enabled = CommonAppVarsAndFunctions.IsAdmin;
            mnuCapNhatData.Visible = CommonAppVarsAndFunctions.IsAdmin;

        }

        private void Check_Enable_BangLuong()
        {
            mnuChamCong.Enabled = true;

        }
        private void Check_Enable_ViSinh()
        {
            //Xem kết quả
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenViSinh,
                UserConstant.PermissionVSViewResult))
            {
                rbKQViSinhNuoiCay.Enabled = true;
                rbPhieuTienTrinhViSinh.Enabled = true;
            }
            //Quyền gửi mail
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenViSinh,
                UserConstant.PermissionTestSendMail))
            {
                rbGuiEMailKetQua.Enabled = true;
            }
        }
        private void Check_Enable_TN()
        {
            //Kiểm tra quyền được xem
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionViewPatientInfo))
            {
                // Thông tin bệnh nhân
                rbTiepNhanBenhNhan.Enabled = rbInbaracodeKSK.Enabled = true;
                rbNhapTheoDanhSach.Enabled = true;
            }
            rabCapNhatThongTinTuHis.Enabled = rbTiepNhanHIS.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                     CommonAppVarsAndFunctions.PhanQuyenTiepNhan,
                      UserConstant.PermissionReceptionFromHIS);
            rbThongTinSangLocSoSinh.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                  CommonAppVarsAndFunctions.PhanQuyenTiepNhan,
                   UserConstant.PermissionReceptionSLSS);
            rbThongTinSangLocTruocSinh.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                  CommonAppVarsAndFunctions.PhanQuyenTiepNhan,
                  UserConstant.PermissionReceptionSLTS);

            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenTiepNhan,
                UserConstant.PermissionReceptionSearchPatientInfo))
            {
                //Tìm bệnh nhân
                rbTimKiem.Enabled = true;
            }
        }
        private void Check_Enable_QuanLy()
        {
            //QL Giá dịch vụ
            rbDoituongDichVu.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionViewCustomerObject);
            rbKhoaPhong.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManangeLocation);
            rbKhoaPhong.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
              UserConstant.PermissionManangeLocation);

            rbNguoiDung.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                         CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                         UserConstant.PermissionManangeUser);
            rbMayInBarCode.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                  CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                  UserConstant.PermissionConfigBarcodeSystem);
            rbNhanVien.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                  CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                  UserConstant.PermissionCategoriesEmployee);
            rbKhuVuc.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionComputer);
            rbDanhMucLoaiMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                  CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                  UserConstant.PermissionCategoriesManagementOfSample);

            rbDmHenTraKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                 UserConstant.PermissionManageReturnResultTicket);

            rbDmHenTraKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManageReturnResultTicket);

            rbDanhMucKetNoiHIS.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionHISLISMapping);

            rbDiaChi.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManangeAddress);

            rbCauHinhPhieuIn.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionConfigTitlePrint);

            rbTieuDeTrangIn.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionConfigTitlePrint);

            rbCauHinhHeThong.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
              UserConstant.PermissionConfigSystem);
            rbTembarcode.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
              UserConstant.PermissionConfigSystem);
            radNgonNgu.Enabled = rbCauHinhHeThong.Enabled;
            //rbMayIn.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
            //   CommonAppVarsAndFunctions.PhanQuyenQuanLy,
            //   UserConstant.PermissionCategoryPrinter);

            mnuDanhMucDienGiaiSHPT.Enabled = rbDanhMucXetNghiem.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionCategoriesManagementOfTest);
            rbBienDichDanhMuc.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionConfigSystem);
            rbTinhTrangMauLyDo.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionCategoriesReason);

            rbDanhMucMaMayXetNghiem.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);
            rbMappingMayViSinh.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);
            rbBienDichCo.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);

            rbBienDichKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManagementOfConvertTest);
            rbNhatKy.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                 UserConstant.PermissionViewLog);

            rbDashboardBieuDoTron.Enabled = rbDashboardSo.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                   CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                   UserConstant.PermissionViewDasboardTAT);

            rbCaiDatKetNoiHis.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManageHISConfig);

            rbThongTinMayXN.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManageAnalyzerInformation);
            //QL Danh Mục vi sinh
            rbDanhMucViSinh.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionCategoriesManagementOfVS);
        }

        private void Check_Enable_XN()
        {
            //Xem kết quả
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestViewResult))
            {
                rbKetQuaThuongQuy.Enabled = true;
                rbXacNhanTraKetQua.Enabled = true;
                rbXemPDF.Enabled = true;
            }

            rbKetQuaTuMayXN.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
            CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestViewAnalyzerResult);

            rbChuyenKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestPrintResult);
            rbNhanPhieuKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionCollectResultReport);
            rbInTheoDanhSach.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestPrintResult);
            rbDmHenTraKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
               UserConstant.PermissionManangeLocation);

            rbDanhMucKetNoiHIS.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionManangeLocation);

            rbDanhMucLoaiMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionManangeLocation);

            rbKQSinhHocPhanTu.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                  CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                  UserConstant.PermissionMicroBiologyViewResult);

            rbDangNhapLayMau.Enabled = rbBanLayMau.Enabled = rbLayMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                  CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                  UserConstant.PermissionTestCollectSample);

            rbNhanMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestGetSample);

            rbChuyenMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);

            rbLichSuXetNghiem.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
             CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionViewHisotryTestResult);

            mnuTheoDoiMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
             CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionViewSampleTracking);

            //rbChuyenMau.Enabled = rbChuyenMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
            //    CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);

            //rbKetQuaTuiMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
            //     CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionBloodTestViewResult);

            rbKQUploadHIS.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionViewUploadedHISTestResult);
            //Thống kê - Báo cáo
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionReportStatisticOfTest))
            {
                rbThongKeTongHopXn.Enabled = true;
                // mnuThongKe.Enabled = true;
            }
            //Quyền gửi mail
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestSendMail))
            {
                rbGuiEMailKetQua.Enabled = true;
            }

            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestExportResult))
            {
                rbXuatKetQua.Enabled = true;
            }

            rbLuuMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionViewArchiveSample);
            rbHuyMauLuu.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionDestroyArchiveSample);
            mnuDanhMucTuLuuMau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionAddArchiveSample);
            mnuChanDoan.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
              UserConstant.PermissionCategoriesManagementOfDiagnostic);
            mnuQuanLyGuiMauNoiBo.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
         CommonAppVarsAndFunctions.PhanQuyenQuanLy,
         UserConstant.PermissionCategoriesManagementOfSentTestLocal);
            mnuGuimau.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
            CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
            UserConstant.PermissionCreateSentTest) || CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
            CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
            UserConstant.PermissionDeleteSentTest);

        }
        private void Check_Enable_SA()
        {
            //Xem kết quả
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenSieuAm,
                UserConstant.PermissionViewResultOfSupersonic))
            {
                rbKetQuSieuAm.Enabled = true;
            }
            //Quyền gửi mail
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenSieuAm,
                UserConstant.PermissionSendMailOfSupersonic))
            {
                rbGuiEMailKetQua.Enabled = true;
            }
        }
        private void Check_Enable_ThuNgan()
        {
            btnThuPhi.Visible = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenThuNgan,
                 UserConstant.PermissionCashierViewInvoice);
            rbBaoCaoDoanhThu.Visible = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenThuNgan,
                UserConstant.PermissionCashierViewLockIncomeData);
            rbThuPhiDichVu.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenThuNgan,
                 UserConstant.PermissionCashierViewInvoice);
            rbBaoCaoDoanhThu.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenThuNgan,
              UserConstant.PermissionCashierViewLockIncomeData);
        }
        public bool LocalizedLanguage = true;
        public static string Language = LanguageExtension.AppLanguage;
        Panel pnManChe = new Panel();
        public frmParent_old()
        {
            InitializeComponent();
            //this.Text = String.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            //DefaultFormSize = this.Size;
            pnManChe.BackColor = CommonAppColors.ColorMainAppFormColor;
            this.Controls.Add(pnManChe);

            pnManChe.BringToFront();
            pnManChe.Dock = DockStyle.Fill;
        }

        string fileVersion;
        string appName;
        private Thread _tak;
        private readonly ISystemConfigService _iConfig = new SystemConfigService();
        //private void FrmMain_Load(object sender, EventArgs e)
        //{
        //    lblTPHCopyright.Text = MessageConstant.Copyright;
        //    //CollapseMenu();
        //   // LockControl(true);
        //    fileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
        //    appName = new FileInfo(Application.ExecutablePath).Name.Replace(new FileInfo(Application.ExecutablePath).Extension, "");
        //    var asm = Assembly.GetExecutingAssembly();
        //    var ip = GetLocalIPAddress();
        //    _iConfig.Update_PcLogin(Environment.MachineName, asm.GetName().Version.ToString(), GetLocalIPAddress(), appName);
        //    var udpFlat = _iConfig.Check_UpdateSoftware(Environment.MachineName, fileVersion, appName);
        //    if (udpFlat == 1 || udpFlat == 2)
        //        Check_ShowUpdateSoftWare(true);
        //    CommonAppVarsAndFunctions._updating = false;
        //    lblVersion.Text = string.Format("| {0}:{1} | {2} | {3}", LanguageExtension.GetResourceValueFromKey("PhienBan", Language), Assembly.GetExecutingAssembly().GetName().Version, Environment.MachineName, ip);
        //    CommonAppVarsAndFunctions.ServerTime = C_Ultilities.ServerDate();
        //    timerMain.Start();
        //    if (!CommonAppVarsAndFunctions.License.FullLicense)
        //    {
        //        CheckLicense(false);
        //    }
        //    LoadPrinterList();
        //    WorkingServices.EmptyFolderContents("Logs", 3, null);
        //    SetMainMenu(tphDropdownBenhNhan);
        //    SetMainMenu(tphDropdownDanhMuc);
        //    SetMainMenu(tphDropdownKetQua);
        //    SetMainMenu(tphDropdownOngMau);
        //    SetMainMenu(tphDropdownThongKe);
        //    SetMainMenu(tphDropdownMenuHanhChinh);
        //    SetMainMenu(tphDropdownCauHinh);

        //    lblHello.Text = CommonAppVarsAndFunctions.HelloString;
        //    lblUserName.Text = CommonAppVarsAndFunctions.HelloUserId;

        //    btnTrangChinh_Click(btnTrangChinh, new EventArgs());
        //    Check_EnableControl(CommonAppVarsAndFunctions.UserID);
        //}

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //StartServiceUpdate();
            lblTPHCopyright.Text = MessageConstant.Copyright;
            fileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            appName = new FileInfo(Application.ExecutablePath).Name.Replace(new FileInfo(Application.ExecutablePath).Extension, "");
            var asm = Assembly.GetExecutingAssembly();
            var ip = GetLocalIPAddress();
            _iConfig.Update_PcLogin(Environment.MachineName, asm.GetName().Version.ToString(), GetLocalIPAddress(), appName);
            CommonAppVarsAndFunctions._updating = false;
            lblVersion.Text = string.Format("| {0}: {1} | {2} | {3}", LanguageExtension.GetResourceValueFromKey("PhienBan", Language), Assembly.GetExecutingAssembly().GetName().Version, Environment.MachineName, ip);
            CommonAppVarsAndFunctions.ServerTime = C_Ultilities.ServerDate();
            timerMain.Start();
            //if (!CommonAppVarsAndFunctions.License.FullLicense)
            //{
            //    CheckLicense(false);
            //}
            LoadPrinterList();
            WorkingServices.EmptyFolderContents("Logs", 3, null);
            SetMainMenu(tphDropdownBenhNhan);
            SetMainMenu(tphDropdownDanhMuc);
            SetMainMenu(tphDropdownKetQua);
            SetMainMenu(tphDropdownOngMau);
            SetMainMenu(tphDropdownThongKe);
            SetMainMenu(tphDropdownMenuHanhChinh);
            SetMainMenu(tphDropdownCauHinh);

            lblHello.Text = CommonAppVarsAndFunctions.HelloString;
            lblUserName.Text = CommonAppVarsAndFunctions.HelloUserId;

            btnTrangChinh_Click(btnTrangChinh, new EventArgs());
            LockAllMenu();
            Check_EnableControl(CommonAppVarsAndFunctions.UserID);
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
        private void LoadPrinterList()
        {
            Task.Factory.StartNew(() =>
            {
                LabServices_Helper.LoadPrinterName(CommonAppVarsAndFunctions.LstPrinter, UserConstant.RegistryPrinterResult, true);

            });
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            //AdjustForm();
            this.Controls.Remove(pnManChe);
            LanguageExtension.LocalizeForm(this, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownBenhNhan, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownKetQua, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownThongKe, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownDanhMuc, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownOngMau, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownCauHinh, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownMenuHanhChinh, string.Empty);
            LanguageExtension.LocalizeSpecialControl(tphDropdownThuPhi, string.Empty);

            if (!pnMenuContent.Controls.OfType<Button>().Any()) return;
            foreach (var menuButton in pnMenuContent.Controls.OfType<Button>())
            {
                var key = LanguageExtension.GetResxNameByValue(menuButton.Tag.ToString());
                //menuButton.Tag = menuButton.Text;
                var text = LanguageExtension.GetString(key, LanguageExtension.AppLanguage);
                _toolTipButton.SetToolTip(menuButton,
                    text);
            }
        }

        internal void ShowForm(Form f)
        {
            ShowFormFromMenu(null, f);
        }
        private string NgayLamViec = string.Empty;
        private string ThongbaoLamMoi = string.Empty;
        private int iCountToCheckUpdate = 900;
        private int iCountingUpdate = 0;
        private bool isNeedUpdate = false;
        private int iCountingforceUpdate = 60;
        private int counting = 0;
        private void timerMain_Tick(object sender, EventArgs e)
        {
            //CommonAppVarsAndFunctions.ServerTime = CommonAppVarsAndFunctions.ServerTime.AddSeconds(1);
            //if (string.IsNullOrEmpty(NgayLamViec))
            //{
            //    var ngay = LanguageExtension.GetResourceValueFromValue(CommonAppVarsAndFunctions.LangMessageConstant.NgayLamViec, Language);
            //    NgayLamViec = string.IsNullOrEmpty(ngay) ? CommonAppVarsAndFunctions.LangMessageConstant.NgayLamViec : ngay;
            //}
            ////if (string.IsNullOrEmpty(ThongbaoLamMoi))
            ////{
            ////    var thongbao = LanguageExtension.GetResourceValueFromKey("ThongBaoSeTuLamMoiSau", Language);
            ////    ThongbaoLamMoi = thongbao;
            ////}
            //StartServiceUpdate();
            //lblTimer.Text = string.Format("| {0}: {1: dd/MM/yyyy HH:mm:ss}", NgayLamViec, CommonAppVarsAndFunctions.ServerTime);
            ////kiểm tra update
            //if (CommonAppVarsAndFunctions.forceUpdateRequest && iCountingforceUpdate == 0)
            //{
            //    isNeedUpdate = false;
            //    Check_ShowUpdateSoftWare(true);
            //}
            //else if (iCountingUpdate >= iCountToCheckUpdate)
            //{
            //    CommonAppVarsAndFunctions.ServerTime = AppCode.C_Ultilities.ServerDate();
            //    var checkUpdateFlat = _iConfig.Check_UpdateSoftware(Environment.MachineName, fileVersion, appName);
            //    if (checkUpdateFlat == 2)
            //    {
            //        isNeedUpdate = true;
            //        iCountingUpdate = 0;
            //        iCountingforceUpdate = 60;
            //        CommonAppVarsAndFunctions.forceUpdateRequest = true;
            //    }
            //    else
            //    {
            //        CommonAppVarsAndFunctions.forceUpdateRequest = false;
            //        isNeedUpdate = checkUpdateFlat == 1;
            //        iCountingUpdate = 0;
            //    }
            //}
            //else
            //{
            //    iCountingUpdate++;
            //    if (CommonAppVarsAndFunctions.ServerTime.Hour == 0 && CommonAppVarsAndFunctions.ServerTime.Minute == 00 && CommonAppVarsAndFunctions.ServerTime.Second == 0)
            //    {
            //        WorkingServices.EmptyFolderContents("Logs", 3, null);
            //    }
            //}

            //if (isNeedUpdate)
            //{
            //    if (!lblThongBaoCapNhat.Visible)
            //        lblThongBaoCapNhat.Visible = true;
            //    lblThongBaoCapNhat.Text =
            //        string.Format(
            //            LanguageExtension.GetResourceValueFromValue("THÔNG BÁO: ỨNG DỤNG TỰ CẬP NHẬT SAU {0}s",
            //                LanguageExtension.AppLanguage), iCountingforceUpdate);
            //    lblThongBaoCapNhat.BackColor = lblThongBaoCapNhat.BackColor == Color.Gold ? Color.Empty : Color.Gold;
            //    lblThongBaoCapNhat.ForeColor = lblThongBaoCapNhat.BackColor == Color.Gold ? Color.Red : Color.Gold;
            //    iCountingforceUpdate--;
            //}
            //else
            //{
            //    if (lblThongBaoCapNhat.Visible)
            //        lblThongBaoCapNhat.Visible = false;
            //    lblThongBaoCapNhat.BackColor = Color.Empty;
            //    lblThongBaoCapNhat.ForeColor = Color.White;
            //}
            //if (!CommonAppVarsAndFunctions.License.FullLicense)
            //    CheckLicense(true);
            //counting++;
            //// lblThongbaolamMoi.Text = string.Format("{0}: {1}s", ThongbaoLamMoi, ((timerAlarm.Interval) / 1000) - counting);
        }
        //menu chính
        private void LockControl(bool isLock)
        {
            foreach (Control item in pnMenuContent.Controls)
            {
                if (item is TPH.Controls.TPHIconButton)
                    item.Enabled = !isLock;
            }
        }
        private void CheckLicense(bool fromAutocheck)
        {
            var trialDays = (CommonAppVarsAndFunctions.License.EndDate - CommonAppVarsAndFunctions.License.StartDate).Days;

            if (CommonAppVarsAndFunctions.ServerTime >= CommonAppVarsAndFunctions.License.EndDate || CommonAppVarsAndFunctions.ServerTime <= CommonAppVarsAndFunctions.License.StartDate)
            {
                timerMain.Stop();
                timerMain.Enabled = false;
                LockControl(true);
                //this.Text = string.Format(MessageConstant.PhanMemDaHetHanSuDung, CommonConstant.ApplicationName, trialDays, License.StartDate, License.EndDate);
                MessageBox.Show(string.Format(MessageConstant.PhanMemDaHetHanSuDungVuiLongLienHe, CommonConstant.ApplicationName, trialDays));
                if (fromAutocheck)
                {
                    if (!CommonAppVarsAndFunctions.License.FullLicense)
                    {
                        if (CommonAppVarsAndFunctions.ServerTime >= CommonAppVarsAndFunctions.License.EndDate || CommonAppVarsAndFunctions.ServerTime <= CommonAppVarsAndFunctions.License.StartDate)
                        {
                            timerMain.Stop();
                            CommonAppVarsAndFunctions._active = false;
                            Application.Restart();
                        }
                        else
                        {
                            if (CommonAppVarsAndFunctions.License.ChangeLicense)
                            {
                                //var difference = CommonAppVarsAndFunctions.License.EndDate - CommonAppVarsAndFunctions.ServerTime.Date;
                                //this.Text = string.Format(MessageConstant.PhanMemConNgayDungThu, CommonConstant.ApplicationName, difference.Days); ;
                                CommonAppVarsAndFunctions.License.ChangeLicense = false;
                            }
                        }
                    }
                }
            }
            else if (!fromAutocheck)
            {
                timerMain.Start();
                var difference = CommonAppVarsAndFunctions.License.EndDate.Date - CommonAppVarsAndFunctions.ServerTime.Date;
                //var versionInfo = CommonAppVarsAndFunctions.License.StatusFullDescription;
                //   this.Text = versionInfo;

                if (difference.Days < 6)
                {
                    MessageBox.Show(string.Format(MessageConstant.BanConNgayLamViecVuiLongLienHeTph, difference.Days));
                }
                lblStatus.Text = String.Format(" | Remain: {0} day(s)", difference.Days);
                _tak = new Thread(LoadPrinterList);
                CommonAppVarsAndFunctions._active = true;
            }
        }

        private void Check_ShowUpdateSoftWare(bool isAuto = false)
        {
            CommonAppVarsAndFunctions.Check_ShowUpdateSoftWare(isAuto);
        }

        private void frmMDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CommonAppVarsAndFunctions.IsLogOut)
            {
                if (CommonAppVarsAndFunctions._askWhenClose)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetNo(MessageConstant.ExitProgram))
                    {
                        e.Cancel = true;
                    }
                }
            }

            //if (!e.Cancel)
            //    CommonAppVarsAndFunctions.updateService.CloseConnect();
        }

        private void btnTrangChinh_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu((Controls.TPHIconButton)sender, new FrmHome());
        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownBenhNhan);
        }

        private void btnOngMau_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownOngMau);
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownKetQua);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownThongKe);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownDanhMuc);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            var f = new frmResetPassword();
            f.ShowDialog();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownCauHinh);
        }

        private void rbTiepNhanHIS_Click(object sender, EventArgs e)
        {
            //ShowFormFromMenu(btnBenhNhan, new FrmTiepNhanHIS());
        }

        private void mnuNhapThuCong_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmTiepNhanBenhNhan());
        }

        private void mnuNhapThongTinSangLoc_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmThongTinSangLocSoSinh());
        }

        private void rbTimKiem_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmTimBenhNhan());
        }
        private void rbKetQuaThuongQuy_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new frmCLSKetQuaXN());
        }

        private void btnThuPhi_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownThuPhi);
        }

        private void rbThongTinSangLocTruocSinh_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmThongTinSangLocTruocSinh());
        }

        private void rabCapNhatThongTinTuHis_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmCapNhatThongTin());
        }

        private void rbInbaracodeKSK_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmInbarcode());
        }

        private void rbNhapTheoDanhSach_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmNhapKSK());
        }

        private void rbXacNhanTraKetQua_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmTraKetQua());
        }

        private void rbLichSuXetNghiem_Click(object sender, EventArgs e)
        {
            var f = new FrmHoSoBenhAn();
            f.lblTitle.Text = "LỊCH SỬ XÉT NGHIỆM";
            f.Text = "LỊCH SỬ XÉT NGHIỆM";
            ShowFormFromMenu(btnBenhNhan, f);
        }

        private void rbTheoDoiMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnBenhNhan, new FrmTheoDoiMau());
        }

        private void rbKQSinhHocPhanTu_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmSinhHocPhanTu());
        }

        private void rbKQViSinhNuoiCay_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmCLSKetQuaViSinh());
        }

        private void rbKQUploadHIS_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmCheckUploadHIS());
        }

        private void rbInTheoDanhSach_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmInTheoDanhSach());
        }

        private void rbPhieuTienTrinhViSinh_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmCLSViSinh_PhieuTienTrinh());
        }

        private void rbGuiEMailKetQua_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new frmEmail());
        }

        private void rbXemPDF_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmViewPDFSigned());
        }

        private void rbChuyenKetQua_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmChuyenKetQua());
        }

        private void rbNhanPhieuKetQua_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmNhanKetQua());
        }

        private void rbKetQuaTuMayXN_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmKetQuaMayXN());
        }

        private void rbXuatKetQua_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new frmXuatKetQuaXetNghiem());
        }

        private void rbThongKeTongHopXn_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new frmThongKeTongHopXN());
        }

        private void rbNhatKy_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmXemNhatKy());
        }

        private void rbDashboard_Click(object sender, EventArgs e)
        {
            var f = new FrmDashBoardTAT();
            f.Show();
        }
        private void rbDashboardBieuDoTron_Click(object sender, EventArgs e)
        {
            var f = new FrmDashBoardTAT_Chart();
            f.Show();
        }
        private void mnuXuatKetQuaViSinh_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new frmXuatKetQuaXetNghiem_ViSinh());
        }

        private void rbDanhMucXetNghiem_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new frmDMCLS_XetNghiem());
        }

        private void rbDanhMucViSinh_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new frmDMCLS_DanhMucViSinh());
        }

        private void rbDoituongDichVu_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new frmDM_DoiTuongDichVu_Gia());
        }

        private void rbNguoiDung_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new FrmTaiKhoanNguoiDung());
        }

        private void rbKhoaPhong_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new FrmCauHinh_DMKhoaPhong());
        }

        private void rbNhanVien_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new frmNhanVien_ChanDoan());
        }

        private void rbKhuVuc_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new FrmCauHinh_KhuVuc());
        }

        private void rbDiaChi_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnKetQua, new frmCauHinh_TinhThanhPho());
        }

        private void rbMayInBarCode_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new FrmCauHinhMayTinh_HeThongInTem());
        }

        private void rbThongTinMayXN_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new FrmThongTinMayXN());
        }

        private void rbTieuDeTrangIn_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new frmPrintHeader());
        }

        private void rbCaiDatKetNoiHis_Click(object sender, EventArgs e)
        {
            //ShowFormFromMenu(btnCaiDat, new FrmCauHinh_His());
        }

        private void rbCauHinhHeThong_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new frmCauHinh_CaiDatHeThong());
        }

        private void rbDangKy_Click(object sender, EventArgs e)
        {
            //ShowFormFromMenu(btnCaiDat, new FrmRegistryLicenseKey());
            var f = new FrmRegistryLicenseKey();
            f.ShowDialog();
        }

        private void radNgonNgu_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new FrmNgonNguPhanMem());
        }

        private void rbDanhMucLoaiMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmDM_LoaiMau());
        }

        private void rbDmHenTraKetQua_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmDM_HenTraKetQua());
        }

        private void rbDanhMucKetNoiHIS_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmCauHinh_MappingHIS());
        }

        private void rbCauHinhPhieuIn_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmCauHinh_XetNghiem_MauKetQua());
        }

        private void rbTembarcode_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmQuanLyBarcode());
        }

        private void rbBienDichDanhMuc_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmNgonNguDanhMuc());
        }

        private void rbTinhTrangMauLyDo_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmTinhTrangLyDo());
        }

        private void rbDanhMucMaMayXetNghiem_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new frmDMCLS_MaXetNghiem_May());
        }

        private void rbMappingMayViSinh_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new frmMapping_MaMayXN_ViSinh());
        }

        private void rbBienDichCo_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmCauHinh_Config());
        }

        private void rbBienDichKetQua_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new Frm_DM_BienDichKetQua());
        }

        private void rbDangNhapLayMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnOngMau, new FrmDangNhapLayMau());
        }

        private void rbBanLayMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnOngMau, new FrmBanLayMau());
        }

        private void rbChuyenMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnOngMau, new FrmXacNhanChuyenMau());
        }

        private void rbNhanMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnOngMau, new FrmCLSXetNghiem_DuyetNhanMau());
        }

        private void mnuTheoDoiMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnOngMau, new FrmTheoDoiMau());
        }

        private void rbLuuMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnOngMau, new FrmLuuMau());
        }

        private void rbHuyMauLuu_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnOngMau, new FrmLuuMau_HuyMauLuu());
        }

        private void bntDanhMucHanhChinh_Click(object sender, EventArgs e)
        {
            ShowMenu((Controls.TPHIconButton)sender, tphDropdownMenuHanhChinh);
        }

        private void rbLayMau_Click(object sender, EventArgs e)
        {
            //ShowFormFromMenu(btnOngMau, new FrmLayMau());
        }

        private void rbCapNhatPhanMem_Click(object sender, EventArgs e)
        {
            Check_ShowUpdateSoftWare(false);
        }

        private void frmMDIParent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                if (rbTiepNhanHIS.Enabled)
                {
                    rbTiepNhanHIS_Click(sender, e);
                }
            }
            else if (e.KeyData == Keys.F2)
            {
                if (rbLayMau.Enabled)
                {
                    rbLayMau_Click(sender, e);
                }
            }
            else if (e.KeyData == Keys.F3)
            {
                if (rbChuyenMau.Enabled)
                {
                    rbChuyenMau_Click(sender, e);
                }
            }
            else if (e.KeyData == Keys.F4)
            {
                if (rbNhanMau.Enabled)
                {
                    rbNhanMau_Click(sender, e);
                }
            }
            else if (e.KeyData == Keys.F5)
            {
                if (rbKetQuaThuongQuy.Enabled)
                {
                    rbKetQuaThuongQuy_Click(sender, e);
                }
            }
            else if (e.KeyData == Keys.F8)
            {
                if (rbKQViSinhNuoiCay.Enabled)
                {
                    rbKQViSinhNuoiCay_Click(sender, e);
                }
            }
            else if (e.KeyData == Keys.F9)
            {
                if (rbKQSinhHocPhanTu.Enabled)
                {
                    rbKQSinhHocPhanTu_Click(sender, e);
                }
            }
            else if (e.KeyData == Keys.F10)
            {
                if (rbTimKiem.Enabled)
                {
                    rbTimKiem_Click(sender, e);
                }
            }
        }

        private void mnuChanDoan_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmDanhMucChanDoan());
        }

        private void mnuCapNhatData_Click(object sender, EventArgs e)
        {
            var f = new FrmTechUpdate();
            f.ShowDialog();
        }

        private void rbThuPhiDichVu_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnThuPhi, new FrmThuPhiDichVu());
        }

        private void rbBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnThuPhi, new FrmBaoCaoDoanhThu());
        }
        private bool _isCallSignalR;
        private bool _isCreatedGroup;
        private bool _isCallingServiceUpdate;

        private async void StartServiceUpdate()
        {
            //if (!_isCallingServiceUpdate)
            //{
            //    _isCallingServiceUpdate = true;
            //    //Tách hàm join group và tạo connect ra để tránh trường hợp bị lỗi không kết nối được do các lệnh quá nhanh chưa kịp mở connect.
            //    if (_isCallSignalR && !_isCreatedGroup)
            //    {
            //        _isCreatedGroup = true;
            //        try
            //        {
            //            await CommonAppVarsAndFunctions.updateService.JoinGroup(UpdaterManagementCommon.UpdaterGroupName);
            //            //await CommonAppVarsAndFunctions.updateService.JoinGroup(UpdaterManagementCommon.TestResultNormalGroupName);
            //            //await CommonAppVarsAndFunctions.updateService.JoinGroup(UpdaterManagementCommon.TestResultNormalResponeGroupName);
            //        }
            //        catch (Exception ex)
            //        {
            //            if (ex.Message.Equals("The connection has not been established."))
            //            {
            //                _isCreatedGroup = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (!CommonAppVarsAndFunctions.updateService.IsReady() && CommonAppVarsAndFunctions.sysConfig != null)
            //        {
            //            if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.SignalR_HostName))
            //            {
            //                CommonAppVarsAndFunctions.updateService.CreateServiceConnect(new UpdaterManagement.Models.UpdateServiceHostInfo
            //                {
            //                    HostName = CommonAppVarsAndFunctions.sysConfig.SignalR_HostName,
            //                    Port = CommonAppVarsAndFunctions.sysConfig.SignalR_Port,
            //                    UserName = Environment.MachineName,
            //                    HubName = UpdaterManagementCommon.HubIMS
            //                });
            //                if (CommonAppVarsAndFunctions.updateService.IsReady())
            //                {
            //                    _isCallSignalR = true;
            //                    var hubProxy = CommonAppVarsAndFunctions.updateService.GetHubProxy();
            //                    hubProxy.On<string, string>("addMessage", (name, message) =>
            //                        this.Invoke((Action)(() =>
            //                        {
            //                            if (name.Equals(UpdaterManagementCommon.UpdaterGroupName))
            //                            {
            //                                if (UpdaterManagementCommon.CheckIsMessageUpdate(message, UpdaterManagementCommon.LabIMS, Environment.MachineName, CommonAppVarsAndFunctions.sysConfig.CustomerID))
            //                                {
            //                                    iCountingUpdate = iCountToCheckUpdate;
            //                                }
            //                                else if (UpdaterManagementCommon.CheckIsMessageCancelUpdate(message, UpdaterManagementCommon.LabIMS, Environment.MachineName, CommonAppVarsAndFunctions.sysConfig.CustomerID))
            //                                {
            //                                    isNeedUpdate = false;
            //                                    iCountingUpdate = 0;
            //                                    iCountingforceUpdate = 0;
            //                                    CommonAppVarsAndFunctions.forceUpdateRequest = false;
            //                                    iCountingforceUpdate = 60;

            //                                }
            //                            }
            //                            ////Tạm thời chưa sử dụng chức năng này
            //                            //else if (name.Equals(UpdaterManagementCommon.TestResultNormalGroupName))
            //                            //{
            //                            //    if (CommonAppVarsAndFunctions.dicWorkingTest.Count > 0)
            //                            //    {
            //                            //        var respone = UpdaterManagementCommon.GetResponeWorkingString(message, CommonAppVarsAndFunctions.dicWorkingTest, Environment.MachineName, CommonAppVarsAndFunctions.UserID);
            //                            //        if (!string.IsNullOrEmpty(respone))
            //                            //        {
            //                            //            CommonAppVarsAndFunctions.updateService.SendMessage(respone, UpdaterManagementCommon.TestResultNormalResponeGroupName);
            //                            //        }
            //                            //    }
            //                            //}
            //                            //else if (name.Equals(UpdaterManagementCommon.TestResultNormalResponeGroupName))
            //                            //{
            //                            //    string matiepNhan = string.Empty;
            //                            //    var respone = UpdaterManagementCommon.GetPCWorkingWithCode(message, Environment.MachineName, ref matiepNhan);
            //                            //    if (!string.IsNullOrEmpty(respone))
            //                            //    {
            //                            //        var f = this.MdiChildren.Where(x => x.Name.Equals("FrmCLSKetQuaXetNghiem_ThuongQuy", StringComparison.OrdinalIgnoreCase));
            //                            //        if (f.Any())
            //                            //        {
            //                            //            var ff = (frmCLSKetQuaXN)f.First();
            //                            //            ff.ShowMessageAlarm(respone, matiepNhan);
            //                            //        }
            //                            //    }
            //                            //}
            //                        })));
            //                }
            //            }
            //        }
            //    }
            //    _isCallingServiceUpdate = false;
            //}
        }

        private void mnuDanhMucTuLuuMau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmTuLuuMau());
        }

        private void mnuQuanLyGuiMauNoiBo_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmXetNghiemKhongThucHien_KhuVuc());
        }

        private void mnuDanhMucDienGiaiSHPT_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmDanhMucDienGiai());
        }

        private void mnuGuimau_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnDanhMuc, new FrmGuiMauDonVi());
        }

        private void mnuChamCong_Click(object sender, EventArgs e)
        {
            ShowFormFromMenu(btnCaiDat, new frmCLSKetQuaXN());
        }
    }
}
