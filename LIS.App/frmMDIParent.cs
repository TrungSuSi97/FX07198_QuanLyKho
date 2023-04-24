using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTab.Drawing;
using DevExpress.XtraTab.ViewInfo;
using TPH.Data.HIS.HISDataCommon;
using TPH.Data.HIS.Models;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.App.ActionLog;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.LIS.App.DailyUse.CanLamSang;
using TPH.LIS.App.Settings.DanhMucCLS;
using TPH.LIS.App.Settings.HeThong;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using System.Net.Sockets;
using System.Net;
using TPH.LIS.App.QuanLyChamCong;

namespace TPH.LIS.App
{
    public partial class frmMDIParent : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMDIParent()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        public bool IsFinishShow = false;
        private string LoadCustomerKey()
        {
            return Configurations.AppSettings.CustomerKey;
        }

        public void SetCloseProgram(bool forceClose)
        {
            CommonAppVarsAndFunctions._askWhenClose = !forceClose;
            if (forceClose)
            {
                CloseAllForm();
                Application.Exit();
            }
        }
        public void CloseAllForm()
        {
            foreach (Form f in MdiChildren)
            {
                f.Dispose();
            }
        }


        public static string ListEnumLoaiDichVu()
        {
            string list = string.Empty;
            foreach (int val in CommonAppVarsAndFunctions.arrLoaiDichVu)
            {
                list += (string.IsNullOrEmpty(list) ? "" : ",") + string.Format("{0}", val);
            }
            return list;
        }


        private int iCountToCheckUpdate = 900;
        private int iCountingUpdate = 0;
        private bool isNeedUpdate = false;
        private bool forceUpdateRequest = false;
        private int iCountingforceUpdate = 0;

        private bool closeApp = false;

        string LongRunningMethod(int iCallTime, out int iExecThread)
        {
            Thread.Sleep(iCallTime);
            iExecThread = Thread.CurrentThread.ManagedThreadId;
            return string.Format("Thời gian thực thi là: {0}", iCallTime);
        }
        private bool _active = false;
        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            rbMainMenu.Minimized = true;

            Show_HideAlarm(false);
            LockControl(true);
            CommonAppVarsAndFunctions.fileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            var fInfo = new FileInfo(Application.ExecutablePath);
            CommonAppVarsAndFunctions.appName = fInfo.Name.Replace(fInfo.Extension, "");
            //CommonAppVarsAndFunctions._iConfig.Update_PcLogin(Environment.MachineName, CommonAppVarsAndFunctions.fileVersion, GetLocalIPAddress(), CommonAppVarsAndFunctions.appName);
            lblVersion.Text = string.Format(" | Phiên bản:{0}", CommonAppVarsAndFunctions.fileVersion);
            //var udpFlat = CommonAppVarsAndFunctions._iConfig.Check_UpdateSoftware(Environment.MachineName, CommonAppVarsAndFunctions.fileVersion, CommonAppVarsAndFunctions.appName);
            //if (udpFlat == 1 || udpFlat == 2)
            //    Check_ShowUpdateSoftWare(true);

            if (closeApp)
                return;
            CommonAppVarsAndFunctions.License.FullLicense = true;
            if (CommonAppVarsAndFunctions.License.FullLicense)
            {
                WorkingServices.EmptyFolderContents("Logs", 3, null);

                CommonAppVarsAndFunctions.ServerTime = C_Ultilities.ServerDate();
                _active = true;

                LockControl(true);
                var frmLogin = new frmLogIn();
                ShowForm(frmLogin);
                LoadPrinterList();
            }
            else
            {
                CheckLicense();
            }
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

        private void frmMDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_active)
            {
                if (CommonAppVarsAndFunctions._askWhenClose)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetNo(MessageConstant.ExitProgram))
                    {
                        e.Cancel = true;
                        SetStartUpBackground(false);
                    }
                    else
                    {
                        BarcodeBatenderService.CloseBartender();

                    }
                }
                else
                {
                    BarcodeBatenderService.CloseBartender();
                }
                //if (_tak != null)
                //    _tak.();
            }
            else
            {
                BarcodeBatenderService.CloseBartender();
            }
            //else if (_tak != null)
            //    _tak.st();
        }

        private void SetStartUpBackground(bool isClear)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is FrmStartUp)
                {
                    var f2 = (FrmStartUp)f;
                    if (isClear)
                    {
                        // f2.BackgroundImage = null;
                        f2.ShowManChe();
                    }
                    else
                    {
                        //if (File.Exists(@"Background\Background.jpg"))
                        //{
                        //    Image img;
                        //    using (var bmpTemp = new Bitmap(@"Background\Background.jpg"))
                        //    {
                        //        img = new Bitmap(bmpTemp);
                        //    }
                        //    f2.BackgroundImageLayout = ImageLayout.Stretch;
                        //    f2.BackgroundImage = img;
                        //}
                        f2.AnManChe();
                    }
                    break;
                }
            }
        }
        private void Frm_SizeChanged(object sender, EventArgs e)
        {
            var f = (Form)sender;
            if (f.WindowState != FormWindowState.Maximized)
            {
                f.WindowState = FormWindowState.Maximized;
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            CommonAppVarsAndFunctions.ServerTime = CommonAppVarsAndFunctions.ServerTime.AddSeconds(1);
            lblTimer.Text = string.Format("| Ngày làm việc: {0: dd/MM/yyyy HH:mm:ss}", CommonAppVarsAndFunctions.ServerTime);

            //var productKeyIsValid = ValidateProductKey();
            var productKeyIsValid = true;
            if (!productKeyIsValid)
            {
                _active = false;
                timerMain.Stop();
                CustomMessageBox.MSG_Waring_OK(ErrorConstant.ErrorProductKeyIsNotValid);
                Application.Exit();
            }
            else
            {
                _active = true;
                timerMain.Stop();
            }
        }

        private void frmMDIParent_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmMDIParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            CommonAppVarsAndFunctions.ServerTime = CommonAppVarsAndFunctions.ServerTime.AddSeconds(1);
            lblTimer.Text = string.Format("| {0}: {1: dd/MM/yyyy HH:mm:ss}", MessageConstant.NgayLamViec, CommonAppVarsAndFunctions.ServerTime);
            //if (!CommonAppVarsAndFunctions.License.FullLicense)
            //{
            //    if (CommonAppVarsAndFunctions.ServerTime >= CommonAppVarsAndFunctions.License.EndDate || CommonAppVarsAndFunctions.ServerTime <= CommonAppVarsAndFunctions.License.StartDate)
            //    {
            //        timer1.Stop();
            //        _active = false;
            //        Application.Restart();
            //    }
            //    else
            //    {
            //        if (CommonAppVarsAndFunctions.License.ChangeLicense)
            //        {
            //            var difference = CommonAppVarsAndFunctions.License.EndDate - CommonAppVarsAndFunctions.ServerTime.Date;
            //            this.Text = string.Format(MessageConstant.PhanMemConNgayDungThu, CommonConstant.ApplicationName, difference.Days); ;
            //            CommonAppVarsAndFunctions.License.ChangeLicense = false;
            //        }
            //    }
            //}

            ////kiểm tra update
            //if (iCountingUpdate >= iCountToCheckUpdate)
            //{
            //    CommonAppVarsAndFunctions.ServerTime = AppCode.C_Ultilities.ServerDate();
            //    var checkUpdateFlat = CommonAppVarsAndFunctions._iConfig.Check_UpdateSoftware(Environment.MachineName
            //        , CommonAppVarsAndFunctions.fileVersion, CommonAppVarsAndFunctions.appName);
            //    if (checkUpdateFlat == 2)
            //    {
            //        if (forceUpdateRequest)
            //        {
            //            mnuCapNhatPhanMem_Click(sender, e);
            //        }
            //        else
            //        {
            //            isNeedUpdate = true;
            //            iCountingUpdate = 0;
            //            iCountingforceUpdate = 0;
            //            forceUpdateRequest = true;
            //            // mnuCapNhatPhanMem.Text = string.Format("CẢNH BÁO: ỨNG DỤNG TỰ CẬP NHẬT SAU {0}s", iCountToCheckUpdate);
            //        }
            //    }
            //    else
            //    {
            //        forceUpdateRequest = false;
            //        //   mnuCapNhatPhanMem.Text = "Cập nhật phần mềm";
            //        isNeedUpdate = checkUpdateFlat == 1;
            //        iCountingUpdate = 0;
            //    }
            //}
            //else
            //{
            //    iCountingforceUpdate++;
            //    iCountingUpdate++;
            //    if (CommonAppVarsAndFunctions.ServerTime.Hour == 0 && CommonAppVarsAndFunctions.ServerTime.Minute == 00 && CommonAppVarsAndFunctions.ServerTime.Second == 0)
            //    {
            //        WorkingServices.EmptyFolderContents("Logs", 3, null);
            //    }
            //}

            //if (isNeedUpdate)
            //{
            //    if (forceUpdateRequest)
            //    {
            //        mnuCapNhatPhanMem.Text = string.Format("CẢNH BÁO: ỨNG DỤNG TỰ CẬP NHẬT SAU {0}s", iCountToCheckUpdate - iCountingforceUpdate);
            //    }

            //    mnuCapNhatPhanMem.BackColor = mnuCapNhatPhanMem.BackColor == Color.Yellow ? Color.Empty : Color.Yellow;
            //}
            //else
            //    mnuCapNhatPhanMem.BackColor = Color.Empty;

            //if (_haveAlarm)
            //    mnuAlarm.BackColor = (mnuAlarm.BackColor == Color.Yellow ? Color.Empty : Color.Yellow);
            //else if (mnuAlarm.BackColor == Color.Yellow)
            //    mnuAlarm.BackColor = Color.Empty;
            counting++;
            //lblThongbaolamMoi.Text = string.Format("Thông báo sẽ tự làm mới sau: {0}s", ((timerAlarm.Interval) / 1000) - counting);
        }
        private void Check_MessOfBartender()
        {
            IntPtr window = FindWindow(null, "BarTender");
            if (window != IntPtr.Zero)
            {
                WriteLog.LogService.RecordLogFile("Log_", "Bartender đang chạy, thực hiện đóng bartender...", "OpenBartender");
                SendMessage((int)window, WM_SYSCOMMAND, SC_CLOSE, 0);
                var allBartnederProccess = Process.GetProcesses().Where(x => x.ProcessName.Equals("bartend", StringComparison.OrdinalIgnoreCase)).ToArray();
                if (allBartnederProccess.Length > 0)
                {
                    foreach (var process in allBartnederProccess)
                    {
                        if (string.IsNullOrEmpty(process.MainWindowTitle))
                        {
                            WriteLog.LogService.RecordLogFile("Log_", string.Format("Thực hiện đóng bartender...{0}", process.ProcessName), "OpenBartender");
                            process.Kill();
                        }
                    }
                }
            }
        }
        private void mnuDanhMucMayXn_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmDMCLS_MayXetNghiem();
            ShowForm(frm);
        }

        private void mnuDanhMucMaXNMay_Click(object sender, EventArgs e)
        {
            //var frm = new CauHinh.DanhMucCLS.frmDMCLS_MaXetNghiem_May();
            //ShowForm(frm);
        }

        private void mnuNhapDanhSach_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.BenhNhan.FrmNhapKSK();
            ShowForm(frm);
        }

        private void tsbKetQuaXN_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmCLSKetQuaXN();
            ShowForm(frm);
        }

        private void mnuNhatKy_Click(object sender, EventArgs e)
        {
            var frm = new TPH.LIS.App.DailyUse.NhatKy.FrmXemNhatKy();
            ShowForm(frm);
        }

        private void mnuNhapTuiMau_Click(object sender, EventArgs e)
        {
            //var frm = new ThucThi.BenhNhan.FrmTiepNhanTuiMau();
            //ShowForm(frm);
        }
        private void btnTiepNhanHis_Click(object sender, EventArgs e)
        {
            var frm = new FrmTiepNhanHIS();
            ShowForm(frm);
        }

        private void mnuInput_Click(object sender, EventArgs e)
        {

        }

        private void mnuHoaChat_Click(object sender, EventArgs e)
        {

            //FrmParent frm = new FrmParent();

            //FormCollection fc = Application.OpenForms;
            //foreach (Form f in fc)
            //{
            //    if (f.Name.Equals(frm.Name))
            //    {
            //        f.Activate();
            //        frm.Dispose();
            //        return;
            //    }
            //    else
            //    {
            //        using (var fLogin = new FrmLogin())
            //        {
            //            if (fLogin.ShowDialog() == DialogResult.OK)
            //            {
            //                frm.Show();
            //            }
            //        }
            //    }
            //}
        }

        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            //var frm = new ThongKe.frmThongKeTongHopXN();
            //ShowForm(frm);
        }

        private void mnuKetNoiHIS_Click(object sender, EventArgs e)
        {
            //var frm = new CauHinh.NhanVien.FrmDanhMuc_HIS();
            //ShowForm(frm);
        }

        private void mnuTiepNhanHIS_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.BenhNhan.FrmTiepNhanHIS();
            ShowForm(frm);
        }

        private void tsbLayMau_Click(object sender, EventArgs e)
        {
            var frm = new FrmLayMau();
            ShowForm(frm);
        }

        private void mnuLicenseKey_Click(object sender, EventArgs e)
        {
            FrmRegistryLicenseKey f = new App.FrmRegistryLicenseKey();
            f.ShowDialog();
        }

        private void mnuUploadHIS_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.BenhNhan.FrmCheckUploadHIS();
            ShowForm(frm);
        }

        private void mnuLoaiMau_Click(object sender, EventArgs e)
        {
            //var f = new CauHinh.DanhMucCLS.FrmLoaiMau();
            //f.ShowDialog();
        }

        private void mnuKhuVuc_Click(object sender, EventArgs e)
        {
            var f = new Settings.HeThong.FrmCauHinh_KhuVuc();
            f.ShowDialog();
        }

        private void mnuReportPosition_Click(object sender, EventArgs e)
        {
            var f = new Settings.HeThong.FrmCauHinh_XetNghiem_MauKetQua();
            ShowForm(f);
        }

        private void mnMainMenu_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Item.Text))
                e.Item.Visible = false;
        }

        private void mnuPrinterForReport_Click(object sender, EventArgs e)
        {
            var f = new Settings.HeThong.frmCauHinh_MayInKetQuaXN();
            f.ShowDialog();
        }

        private void mnuCaiDatCauHinhHis_Click(object sender, EventArgs e)
        {
            var f = new Settings.HeThong.FrmCauHinh_His();
            f.ShowDialog();
        }

        private void mnuMoKetNoiMay_Click(object sender, EventArgs e)
        {
            StartInterface();
        }

        private void mnuSinhHocPhanTu_Click(object sender, EventArgs e)
        {
            var f = new FrmSinhHocPhanTu();
            ShowForm(f);
        }

        private void mnuCapNhatPhanMem_Click(object sender, EventArgs e)
        {
            Check_ShowUpdateSoftWare(false);
        }
        private void Check_ShowUpdateSoftWare(bool isAuto = false)
        {
            try
            {
                if (!CommonAppVarsAndFunctions._updating)
                {
                    CommonAppVarsAndFunctions._updating = true;
                    IsFinishShow = true;
                    var allow = false;

                    if (forceUpdateRequest || isAuto)
                    {
                        CustomMessageBox.MSG_Information_OK("Ứng dụng sẽ tự động cập nhật!");
                        forceUpdateRequest = false;
                        allow = true;

                    }
                    else
                        allow = CustomMessageBox.MSG_Question_YesNo_GetYes((isAuto ? "Đã có phên bản mới bạn muốn cập nhật ứng dụng?" : "Thực hiện cập nhật ứng dụng?"));
                    if (allow)
                    {
                        var p = new Process
                        {
                            StartInfo =
                    {
                        FileName = "TPH.LabIMS.Updater.exe",
                        Arguments = string.Format("{0}", 1)
                        }
                        };
                        p.Start();
                        CommonAppVarsAndFunctions._askWhenClose = false;
                        closeApp = true;
                        Application.Exit();
                    }
                    else
                        CommonAppVarsAndFunctions._updating = false;
                }
            }
            catch
            {

            }

        }
        private void mnuHenTraKetQua_Click(object sender, EventArgs e)
        {
            var f = new Settings.DanhMucCLS.FrmDM_HenTraKetQua();
            f.ShowDialog();
        }

        private void mnuThongTinChiDan_Click(object sender, EventArgs e)
        {
            var f = new CauHinh.DanhMucCLS.frmThongTinChiDan();
            f.ShowDialog();
        }

        private void mnuKetQuaViSinh_Click(object sender, EventArgs e)
        {
            //var f = new DailyUse.CanLamSang.FrmCLSKetQuaViSinh();
            //ShowForm(f);
        }

        private void mnuDM_ViSinh_Click(object sender, EventArgs e)
        {
            var f = new Settings.DanhMucCLS.ViSinh.frmDMCLS_DanhMucViSinh();
            ShowForm(f);
        }

        private void mnuThongTinMayXN_Click(object sender, EventArgs e)
        {

        }

        private void mnuLichSuXetNghiem_Click(object sender, EventArgs e)
        {
            var f = new FrmHoSoBenhAn();
            f.lblTitle.Text = "LỊCH SỬ XÉT NGHIỆM";
            ShowForm(f);
        }

        private void frmMDIParent_Shown(object sender, EventArgs e)
        {
            IsFinishShow = true;
        }

        private void mnuDanhMucbIeuMauNhapNhanh_Click(object sender, EventArgs e)
        {
            var f = new Settings.HeThong.FrmDanhMuc_ChonBieuMau();
            f.FromResult = false;
            f.ShowDialog();
        }

        private void mnuBarcodeKSK_Click(object sender, EventArgs e)
        {
            var f = new FrmInbarcode();
            f.ShowDialog();
        }

        public static bool formLoading = false;
        //Show Or Active Directly Form
        public void ShowForm(Form frm)
        {
            formLoading = true;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name.Equals(frm.Name))
                {
                    if (f is ThucThi.CanLamSang.frmCLSKetQuaXN)
                        formLoading = false;
                    f.Activate();
                    //   f.BringToFront();
                    frm.Dispose();
                    return;
                }
            }
            // SetStartUpBackground(true);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowIcon = true;
            frm.ShowInTaskbar = false;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDIParent));
            //  frm.Icon = ((Icon)(resources.GetObject("$this.IconSub")));

            //if (frm is FrmStartUp || frm is Settings.HeThong.FrmFirstReportLoader)
            //{
            //    frm.Size = this.Size;
            //    frm.MinimizeBox = false;
            //    frm.MaximizeBox = false;
            //    frm.ControlBox = false;
            //    frm.SizeChanged += Frm_SizeChanged;
            //}
            if (frm is FrmTemplate)
            {
                var f = (FrmTemplate)frm;
                f.ShowManChe();
                frm.Show();
                frm.Shown += frm_Shown;
            }
            else
            {
                frm.Show();
            }
            frm.BringToFront();
            formLoading = false;
        }
        private void frm_Shown(object sender, EventArgs e)
        {
            var f = (FrmTemplate)sender;
            f.AnManChe();
            //   SetStartUpBackground(false);

        }
        public void CloseForm(Form frm)
        {
            frm.Close();
            return;
        }

        public bool CloseChild(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name.Equals(frm.Name))
                {
                    f.Close();
                    return true;
                }
            }
            return false;
        }

        public void LogOut()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
            lblHello.Text = string.Empty;
            lblUserName.Text = string.Empty;
            LockControl(true);
            frmLogIn frm = new frmLogIn();
            ShowForm(frm);

        }
        public void StartInterface()
        {
            try
            {
                if (File.Exists("TPH.LabInterface.exe"))
                {
                    var p = new Process
                    {
                        StartInfo =
                        {

                            FileName = "TPH.LabInterface.exe",
                            Arguments = string.Format("{0},{1}", CommonAppVarsAndFunctions.UserName, CommonAppVarsAndFunctions.UserPass)
                        }
                    };

                    p.Start();
                }
            }
            catch
            {

            }
        }

        private bool ValidateProductKey()
        {
            //if (string.IsNullOrWhiteSpace(_productKey))
            //{
            //    return false;
            //}

            //var isValid = ProductionKey.ValidateNormalProductKey(
            //    _productKey,
            //    ProductContant.LIS);

            //return isValid;

            return true;
        }

        private void TimBN()
        {
            var frm = new ThucThi.BenhNhan.FrmTimBenhNhan();
            if (CloseChild(frm))
            {
                frm = new ThucThi.BenhNhan.FrmTimBenhNhan();
            }
            frm.List = false;
            frm.DtDateFromG = CommonAppVarsAndFunctions.ServerTime;
            ShowForm(frm);
        }

        private void LoadPrinterList()
        {
            Task.Factory.StartNew(() =>
            {
                LabServices_Helper.LoadPrinterName(CommonAppVarsAndFunctions.LstPrinter, UserConstant.RegistryPrinterResult, true);
            });
        }
        private void ShowStatus(string inputMess)
        {
            if (InvokeRequired)
            {
                statusStrip1.Invoke((MethodInvoker)delegate ()
                {
                    lblStatus.Text = inputMess;
                    lblStatus.Visible = true;
                });
            }
            else
            {
                lblStatus.Text = inputMess;
                lblStatus.Visible = !string.IsNullOrEmpty(inputMess);
            }
        }
        private void CheckLicense()
        {
            //var trialDays = (CommonAppVarsAndFunctions.License.EndDate - CommonAppVarsAndFunctions.License.StartDate).Days;

            //if (CommonAppVarsAndFunctions.ServerTime >= CommonAppVarsAndFunctions.License.EndDate ||CommonAppVarsAndFunctions.ServerTime <= CommonAppVarsAndFunctions.License.StartDate)
            //{
            //    LockControl(true);
            //    this.Text = string.Format(MessageConstant.PhanMemDaHetHanSuDung, CommonConstant.ApplicationName, trialDays, CommonAppVarsAndFunctions.License.StartDate, CommonAppVarsAndFunctions.License.EndDate);
            //    MessageBox.Show(string.Format(MessageConstant.PhanMemDaHetHanSuDungVuiLongLienHe, CommonConstant.ApplicationName, trialDays));
            //}
            //else
            //{
            //    timer1.Start();
            //    var difference = CommonAppVarsAndFunctions.License.EndDate.Date -CommonAppVarsAndFunctions.ServerTime.Date;
            //    var versionInfo = string.Format(MessageConstant.PhanMemConNgayDungThu, CommonConstant.ApplicationName, difference.Days);
            //    this.Text = versionInfo;

            //    if (difference.Days < 6)
            //    {
            //        MessageBox.Show(string.Format(MessageConstant.BanConNgayLamViecVuiLongLienHeTph, difference.Days));
            //    }
            //    LoadPrinterList();
            //    _active = true;
            //    LockControl(true);
            //    var loginForm = new frmLogIn();
            //    ShowForm(loginForm);
            //}
        }

        private void mnuCauHinhInTem_DanOngMau_Click(object sender, EventArgs e)
        {

        }

        private void mnuMappingMaxnMayViSinh_Click(object sender, EventArgs e)
        {
            var f = new frmMapping_MaMayXN_ViSinh();
            ShowForm(f);
        }

        private void tsbChuyenMau_Click(object sender, EventArgs e)
        {
            var f = new FrmXacNhanChuyenMau();
            ShowForm(f);
        }

        private void tsbNhanMau_Click(object sender, EventArgs e)
        {
            var f = new FrmCLSXetNghiem_DuyetNhanMau();
            ShowForm(f);
        }

        private void mnuLayMau_Click(object sender, EventArgs e)
        {
            tsbLayMau_Click(sender, e);
        }

        private void mnuChuyenMau_Click(object sender, EventArgs e)
        {
            tsbChuyenMau_Click(sender, e);
        }

        private void mnuNhanMau_Click(object sender, EventArgs e)
        {
            tsbNhanMau_Click(sender, e);
        }

        private void mnuTinhTrangMau_Click(object sender, EventArgs e)
        {
            //var f = new FrnTinhTrangLyDo();
            //f.ShowDialog();
        }

        private void btnCloseAlarm_Click(object sender, EventArgs e)
        {
            Show_HideAlarm(false);
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            Show_HideAlarm(true);
        }
        private void Show_HideAlarm(bool show)
        {
            if (show)
            {
                pnAlarm.Width = 741;
                pnAlarm.Height = 644;
            }
            else
            {
                pnAlarm.Width = 0;
                pnAlarm.Height = 0;
            }
        }
        #region Co canh bao
        private readonly IAnalyzerResultService _iAnalyzer = new AnalyzerResultService();

        private void Load_DSCanhBaoTuMay()
        {
            //Panel pnCurtaint = new Panel();
            //pnCurtaint.Size = pnAlarm.Size;
            //pnAlarm.Controls.Add(pnCurtaint);

            var data = _iAnalyzer.Data_DanhSachCoTuMay(CommonAppVarsAndFunctions.BoPhanClsXetNghiem.ToList(), CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList(), CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem.ToList(), string.Empty);
            ucAnalyzerAlarmList1.DataSource = data;
            Check_haveAlarm();
            //pnAlarm.Controls.Remove(pnCurtaint);
        }
        private void Check_haveAlarm()
        {
            CommonAppVarsAndFunctions._haveAlarm = false;
            if (ucAnalyzerAlarmList1.DataSource != null)
            {
                if (ucAnalyzerAlarmList1.DataSource.Rows.Count > 0)
                    CommonAppVarsAndFunctions._haveAlarm = true;
            }
            //còn list nào nữa thì cứ if không else
        }
        #endregion
        int counting = 0;

        //public void Start_StopAlarm(bool start)
        //{
        //    if (start)
        //    {
        //        counting = 0;
        //        timerAlarm.Enabled = true;
        //        timerAlarm.Start();
        //    }
        //    else
        //    {
        //        timerAlarm.Stop();
        //        timerAlarm.Enabled = false;
        //    }
        //}

        private void mnuTheoDoiMau_Click(object sender, EventArgs e)
        {
            var f = new FrmTheoDoiMau();
            f.ShowDialog();
        }

        private void mnuDanhSachBanLayMau_Click(object sender, EventArgs e)
        {
            var f = new FrmBanLayMau();
            f.ShowDialog();
        }

        private void mnuIntheoDanhSach_Click(object sender, EventArgs e)
        {
            var f = new FrmInTheoDanhSach();
            ShowForm(f);
        }

        private void rbTiepNhanBenhNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new DailyUse.BenhNhan.FrmTiepNhanBenhNhan();
            ShowForm(frm);
        }

        private void rbTiepNhanHIS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new ThucThi.BenhNhan.FrmTiepNhanHIS();
            ShowForm(frm);
        }

        private void rbTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimBN();
        }

        private void rbLayMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmLayMau();
            ShowForm(frm);
        }

        private void rbChuyenMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmXacNhanChuyenMau();
            ShowForm(f);
        }

        private void rbNhanMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmCLSXetNghiem_DuyetNhanMau();
            ShowForm(f);
        }

        private void rbBanLayMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmBanLayMau();
            ShowForm(f);
        }

        private void rbTheoDoiMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmTheoDoiMau();
            f.ShowDialog();
        }

        private void rbInbaracodeKSK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmInbarcode();
            f.ShowDialog();
        }

        private void rbThuPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new ThucThi.BenhNhan.FrmThuPhiDichVu();
            ShowForm(f);
        }
        private void rbKetQuaThuongQuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmCLSKetQuaXN();
            ShowForm(frm);
        }

        private void rbKQSinhHocPhanTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmSinhHocPhanTu();
            ShowForm(f);
        }

        private void rbKQViSinhNuoiCay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new DailyUse.CanLamSang.FrmKetQuaCLSXetNghiem_ViSinhNuoiCay();
            //ShowForm(f);
        }

        private void rbKetQuaTuiMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (rbKetQuaTuiMau.Enabled)
            //{
            //    var frm = new ThucThi.BenhNhan.FrmDuyetKetquaXN();
            //    ShowForm(frm);
            //}
        }

        private void rbInTheoDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmInTheoDanhSach();
            ShowForm(f);
        }

        private void rbLichSuXetNghiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmHoSoBenhAn();
            f.lblTitle.Text = "LỊCH SỬ XÉT NGHIỆM";
            ShowForm(f);
        }

        private void rbKQUploadHIS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new ThucThi.BenhNhan.FrmCheckUploadHIS();
            ShowForm(frm);
        }

        private void rbDanhMucXetNghiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmDMCLS_XetNghiem();
            ShowForm(frm);
        }

        private void rbTinhTrangMauLyDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new FrnTinhTrangLyDo();
            //f.ShowDialog();
        }

        private void rbDanhMucLoaiMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new CauHinh.DanhMucCLS.FrmLoaiMau();
            //f.ShowDialog();
        }

        private void rbCauHinhPhieuIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Settings.HeThong.FrmCauHinh_XetNghiem_MauKetQua();
            ShowForm(f);
        }
        private void rbMayInBarCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmCauHinhMayTinh_HeThongInTem();
            f.ShowDialog();
        }
        private void rbMayIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Settings.HeThong.frmCauHinh_MayInKetQuaXN();
            f.ShowDialog();
        }

        private void rbDmHenTraKetQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Settings.DanhMucCLS.FrmDM_HenTraKetQua();
            f.ShowDialog();
        }

        private void rbCauHinhHeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.HeThong.frmCauHinh_CaiDatHeThong();
            frm.ShowDialog();
        }

        private void rbBienDichKetQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var frm =
            //  new TPH.LIS.App.CauHinh.DanhMucCLS.FrmDMSCL_XetNghiem_BienDichKetQua();
            //ShowForm(frm);
        }

        private void rbKhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Settings.HeThong.FrmCauHinh_KhuVuc();
            f.ShowDialog();
        }

        private void rbDangKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new App.FrmRegistryLicenseKey();
            f.ShowDialog();
        }

        private void rbCauHinhGuiMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.HeThong.frmEmailConfig();
            frm.ShowDialog();
        }

        private void rbTieuDeTrangIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.HeThong.frmPrintHeader();
            ShowForm(frm);
        }

        private void rbDanhMucViSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Settings.DanhMucCLS.ViSinh.frmDMCLS_DanhMucViSinh();
            ShowForm(f);
        }

        private void rbDanhMucMayXetNghiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var frm = new CauHinh.DanhMucCLS.frmDMCLS_MaXetNghiem_May();
            //ShowForm(frm);
        }

        private void rbDanhMucKetNoiHIS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var frm = new CauHinh.NhanVien.FrmDanhMuc_HIS();
            //ShowForm(frm);
        }

        private void rbThongKeTongHopXn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new ThongKe.frmThongKeTongHopXN();
            ShowForm(frm);
        }

        private void rbXuatKetQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new ThongKe.frmXuatKetQuaXetNghiem();
            ShowForm(frm);
        }

        private void rbDoituongDichVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmDM_DoiTuongDichVu_Gia();
            ShowForm(frm);
        }

        private void rbKhoaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.HeThong.FrmCauHinh_DMKhoaPhong();
            ShowForm(frm);
        }

        private void rbNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.NhanVien.frmNhanVien_ChanDoan();
            ShowForm(frm);
        }

        private void rbNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Settings.NhanVien.FrmTaiKhoanNguoiDung();
            ShowForm(frm);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmResetPassword();
            frm.ShowDialog();
        }
        private void rbDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new FrmDashBoardTAT();
            //f.Show();
        }

        private void rbCaiDatKetNoiHis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Settings.HeThong.FrmCauHinh_His();
            f.ShowDialog();
        }
        private void rbUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Check_ShowUpdateSoftWare(false);
        }
        private void rbGuiEMailKetQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmEmail();
            ShowForm(frm);
        }
        private void rbNhatKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new TPH.LIS.App.DailyUse.NhatKy.FrmXemNhatKy();
            ShowForm(frm);
        }
        #region Check phân quyền
        //menu chính
        private void LockControl(bool isLock)
        {
            foreach (var item in rbMainMenu.Items)
            {
                if (item is DevExpress.XtraBars.BarButtonItem)
                {
                    var i = (DevExpress.XtraBars.BarButtonItem)item;
                    i.Enabled = !isLock;
                }
            }
            foreach (var item2 in mnSub.Items)
            {
                if (item2 is DevExpress.XtraNavBar.NavBarItem)
                {
                    var i = (DevExpress.XtraNavBar.NavBarItem)item2;
                    i.Enabled = !isLock;
                }
            }
        }
        private void rbDichVuKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void rbCapNhatPhanMem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Check_ShowUpdateSoftWare(false);
        }

        private void rbThongTinMayXN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmThongTinMayXN();
            f.ShowDialog();
        }
        public void Check_EnableControl(string userId)
        {
            btnLogOut.Enabled = true;
            btnHomeScreen.Enabled = true;
            rbDangKy.Enabled = true;
            rbDoiMatKhau.Enabled = true;

            Check_Enable_ViSinh();
            Check_Enable_TN();
            Check_Enable_XN();
            Check_Enable_SA();
            Check_Enable_XQ();
            Check_Enable_NoiSoi();
            Check_Enable_KB();
            Check_Enable_VatTu();
            Check_Enable_TCKT();
            Check_Enable_QuanLy();

            Check_Enable_BangLuong();

        }

        private void Check_Enable_BangLuong()
        {
            rbChamCong.Enabled = true;
        }

        public static bool CheckUserPermissionToAccessFunctions(
            string[] allowPermissions,
            string check)
        {
            //return
            //    allowPermissions.Any(
            //        currentPermission =>
            //            currentPermission.Trim().Equals(check.Trim(), StringComparison.OrdinalIgnoreCase));
            return true;
        }
        private void Check_Enable_ViSinh()
        {
            //Xem kết quả
            if (CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenViSinh,
                UserConstant.PermissionVSViewResult))
            {
                rbKQViSinhNuoiCay.Enabled = true;

            }
            //Quyền gửi mail
            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenViSinh,
                UserConstant.PermissionTestSendMail))
            {
                rbGuiEMailKetQua.Enabled = true;
            }
        }
        private void Check_Enable_TN()
        {
            //Kiểm tra quyền được xem
            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionViewPatientInfo))
            {
                // Thông tin bệnh nhân
                rbTiepNhanBenhNhan.Enabled
                                           = rbQLXNG.Enabled = rbNhapDanhSach.Enabled = rdGopBarcode.Enabled = true;
            }
            rbCapSoThuTu.Enabled = rabCapNhatThongTinTuHis.Enabled = rbTiepNhanHIS.Enabled = btnTiepNhanHis.Enabled = CheckUserPermissionToAccessFunctions(
                     CommonAppVarsAndFunctions.PhanQuyenTiepNhan,
                      UserConstant.PermissionReceptionFromHIS);


            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenTiepNhan,
                UserConstant.PermissionReceptionSearchPatientInfo))
            {
                //Tìm bệnh nhân
                rbTimKiem.Enabled = btnTimBenhNhan.Enabled = true;
            }
        }
        private void Check_Enable_QuanLy()
        {
            //QL Giá dịch vụ
 
            rbKhoaPhong.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManangeLocation);
            rbNguoiDung.Enabled = CheckUserPermissionToAccessFunctions(
                        CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                         UserConstant.PermissionManangeUser);
            rbMayInBarCode.Enabled = CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                  UserConstant.PermissionConfigBarcodeSystem);
            rbNhanVien.Enabled = CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                  UserConstant.PermissionCategoriesEmployee);
            rbKhuVuc.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionComputer);
            rbDanhMucLoaiMau.Enabled = CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                  UserConstant.PermissionCategoriesManagementOfSample);

            rbDmHenTraKetQua.Enabled = CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                 UserConstant.PermissionManageReturnResultTicket);

            //rbDmHenTraKetQua.Enabled = CheckUserPermissionToAccessFunctions(
            //   CommonAppVarsAndFunctions.PhanQuyenQuanLy,
            //    UserConstant.PermissionManageReturnResultTicket);

            rbDanhMucKetNoiHIS.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionHISLISMapping);

            rbKhoaPhong.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionLocation);

            rbCauHinhPhieuIn.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionConfigTitlePrint);

            rbTieuDeTrangIn.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionConfigTitlePrint);

            rbCauHinhHeThong.Enabled = CheckUserPermissionToAccessFunctions(
             CommonAppVarsAndFunctions.PhanQuyenQuanLy,
              UserConstant.PermissionConfigSystem);
     

            rbMayIn.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionCategoryPrinter);

            rbDanhMucXetNghiem.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionCategoriesManagementOfTest);

            rbTinhTrangMauLyDo.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionCategoriesReason);

            rbDanhMucMaMayXetNghiem.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);

            rbMaPPingMaMyXnViSinh.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);
            rbBienDichKetQua.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManagementOfConvertTest);
            rbNhatKy.Enabled = CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                 UserConstant.PermissionViewLog);

            rbCaiDatKetNoiHis.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManageHISConfig);

            rbThongTinMayXN.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManageAnalyzerInformation);

            rbMauReport2.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
               UserConstant.PermissionConfigSystem);

            //QL Danh Mục vi sinh
            rbDanhMucViSinh.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionCategoriesManagementOfVS);

            //QL Xet nghiệm gửi
            //rbQLXNG.Enabled = CheckUserPermissionToAccessFunctions(
            //   CommonAppVarsAndFunctions.PhanQuyenQuanLy,
            //    UserConstant.PermissionQuanLyXetNghiemGui);
        }
        private void Check_Enable_XN()
        {
            //Xem kết quả
            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestViewResult))
            {
                rbKetQuaThuongQuy.Enabled = true;
                rbXacNhanTraKetQua.Enabled = true;
            }
            rbChuyenKetQua.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestPrintResult);
            //rbNhanPhieuKetQua.Enabled = CheckUserPermissionToAccessFunctions(
            //   CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
            //    UserConstant.PermissionCollectResulReport);
            rbInTheoDanhSach.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestPrintResult);
            rbDmHenTraKetQua.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
               UserConstant.PermissionManangeLocation);

            rbDanhMucKetNoiHIS.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionManangeLocation);

            rbDanhMucLoaiMau.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionManangeLocation);

            rbKQSinhHocPhanTu.Enabled = CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                  UserConstant.PermissionMicroBiologyViewResult);

            rbDangNhapLayMau.Enabled = rbBanLayMau.Enabled = rbLayMau.Enabled = CheckUserPermissionToAccessFunctions(
                 CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                  UserConstant.PermissionTestCollectSample);

            rbNhanMau.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestGetSample);

            rbChuyenMau.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);

            rbLichSuXetNghiem.Enabled = CheckUserPermissionToAccessFunctions(
            CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionViewHisotryTestResult);

            rbTheoDoiMau.Enabled = CheckUserPermissionToAccessFunctions(
            CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionViewSampleTracking);

            rbChuyenMau.Enabled = CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);

            rbKetQuaTuiMau.Enabled = CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionBloodTestViewResult);

            rbKQUploadHIS.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionViewUploadedHISTestResult);
            //Thống kê - Báo cáo
            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionReportStatisticOfTest))
            {
                rbThongKeTongHopXn.Enabled = true;
                // mnuThongKe.Enabled = true;
            }
            //Quyền gửi mail
            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestSendMail))
            {
                rbGuiEMailKetQua.Enabled = true;
            }

            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionTestExportResult))
            {
                rbXuatKetQua.Enabled = true;
            }
            rbLuuMau.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionViewArchiveSample);
            rbHuyMauLuu.Enabled = CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                UserConstant.PermissionDestroyArchiveSample);
        }

        private void Check_Enable_SA()
        {

            //Quyền gửi mail
            if (CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenSieuAm,
                UserConstant.PermissionSendMailOfSupersonic))
            {
                rbGuiEMailKetQua.Enabled = true;
            }
        }

        private void Check_Enable_XQ()
        {
            ////Xem kết quả
            //if (CheckUserPermissionToAccessFunctions(
            //    PhanQuyenXQuang,
            //    UserConstant.PermissionViewResultOfXRay))
            //{
            //    mnuKQXQuang.Enabled = true;
            //}
            ////Quản lý danh mục
            //if (CheckUserPermissionToAccessFunctions(
            //    PhanQuyenXQuang,
            //    UserConstant.PermissionCategoriesManagementOfXRay))
            //{
            //    mnuDMXQuang.Enabled = true;
            //}
            ////Thống kê báo cáo
            //if (CheckUserPermissionToAccessFunctions(
            //    PhanQuyenTaiChinhKeToan,
            //    UserConstant.PermissionReportStatisticOfXRay))
            //{
            //    mnuTKTongHopXQuang.Enabled = true;
            //}
            ////Quyền gửi mail
            //if (CheckUserPermissionToAccessFunctions(
            //    PhanQuyenXQuang,
            //    UserConstant.PermissionSendMailOfXRay))
            //{
            //    mnuGuiEmail.Enabled = true;
            //}
        }

        private void Check_Enable_NoiSoi()
        {
        }

        private void Check_Enable_KB()
        { }

        private void Check_Enable_VatTu()
        {

        }

        private void Check_Enable_TCKT()
        {

            ////Quyền thống kê tổng hợp

            //mnuTKTongHop.Enabled = CheckUserPermissionToAccessFunctions(
            //    PhanQuyenTaiChinhKeToan,
            //    UserConstant.PermissionInteratedStatistic);
            //////TK1	TK: Thống kê XN	6
            ////mnuTKTongHopXN.Enabled = mnuThongKe.Enabled = CheckUserPermissionToAccessFunctions(
            ////    PhanQuyenTaiChinhKeToan, 
            ////    UserConstant.PermissionTestingStatistic);
            ////if (mnuTKTongHopXN.Enabled)
            ////    mnuThongKe.Enabled = true;

            ////TK2	TK: Thống kê Siêu Âm	6
            //mnuTKTongHopSieuAm.Enabled = CheckUserPermissionToAccessFunctions(
            //    PhanQuyenTaiChinhKeToan,
            //    UserConstant.PermissionSupersonicStatistic);
            ////TK3	TK: Thống kê X-Quang	3
            //mnuTKTongHopXQuang.Enabled = CheckUserPermissionToAccessFunctions(
            //    PhanQuyenTaiChinhKeToan,
            //    UserConstant.PermissionXRayStatistic);
            ////TK4	TK: Nội sôi	4
            //mnuTKTongHopNoiSoi.Enabled = CheckUserPermissionToAccessFunctions(
            //    PhanQuyenTaiChinhKeToan,
            //    UserConstant.PermissionEndoscopicStatistic);
            ////TK5	TK: Khám chữa bệnh	5
            //mnTKKhamBenh.Enabled = CheckUserPermissionToAccessFunctions(
            //    PhanQuyenTaiChinhKeToan,
            //    UserConstant.PermissionMedicalExamationStatistic);

            //mnuTKTongHopDienTim.Enabled = CheckUserPermissionToAccessFunctions(
            //    PhanQuyenTaiChinhKeToan,
            //    UserConstant.PermissionEcgStatistic);
        }
        #endregion

        private void btnHomeScreen_Click(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void nbiGrid_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmStartUp frm = new FrmStartUp();
            ShowForm(frm);
            frm.AnManChe();
        }

        private void nbiGridCardView_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new FrmTiepNhanHIS();
            ShowForm(frm);
        }

        private void nbiSpreadsheet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new FrmLayMau();
            ShowForm(frm);
        }

        private void nbiWord_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var f = new FrmXacNhanChuyenMau();
            ShowForm(f);
        }

        private void nbiSnap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var f = new FrmCLSXetNghiem_DuyetNhanMau();
            ShowForm(f);
        }

        private void nbiReports_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmCLSKetQuaXN();
            ShowForm(frm);
        }

        private void nbiPivot_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            TimBN();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Đăng xuất ứng dụng?"))
            {
                _active = false;
                Application.Restart();
            }
        }
        private void frmMDIParent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && rbTiepNhanHIS.Enabled)
            {
                var frm = new FrmTiepNhanHIS();
                ShowForm(frm);
            }
            else if (e.KeyCode == Keys.F2 && rbLayMau.Enabled)
            {
                var frm = new FrmLayMau();
                this.ShowForm(frm);
            }
            else if (e.KeyCode == Keys.F3 && rbChuyenMau.Enabled)
            {
                var frm = new FrmXacNhanChuyenMau();
                this.ShowForm(frm);
            }
            else if (e.KeyCode == Keys.F4 && rbNhanMau.Enabled)
            {
                var frm = new FrmCLSXetNghiem_DuyetNhanMau();
                this.ShowForm(frm);
            }
            else if (e.KeyCode == Keys.F5 && rbKetQuaThuongQuy.Enabled)
            {
                var frm = new ThucThi.CanLamSang.frmCLSKetQuaXN();
                this.ShowForm(frm);
            }
        }

        private void rbTembarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new TPH.LIS.BarcodePrinting.Barcode.FrmQuanLyBarcode();
            f.userDangNhap = CommonAppVarsAndFunctions.UserID;
            f.Show();
        }

        private void rbMauReport2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new FrmCauHinh_BieuMauReport();
            //f.ShowDialog();
        }

        private void rbDangNhapLayMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmDangNhapLayMau();
            ShowForm(f);
        }

        private void rbChuyenKetQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmChuyenKetQua();
            ShowForm(f);
        }

        private void rbXacNhanTraKetQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmTraKetQua();
            ShowForm(f);
        }

        private void rbNhanPhieuKetQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmNhanKetQua();
            ShowForm(f);
        }

        private void rbLuuMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmLuuMau();
            ShowForm(f);
        }

        private void rbHuyMauLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmLuuMau_HuyMauLuu();
            ShowForm(f);
        }

        private void rabCapNhatThongTinTuHis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmCapNhatThongTin();
            ShowForm(f);
        }

        private void rbQLXNG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new FrmQuanLyXetNghiemGui();
            //ShowForm(f);
        }

        private void rbNhapDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmNhapKSK();
            ShowForm(f);
        }

        private void rdGopBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new FrmGopBarcode();
            //ShowForm(f);
        }

        private void rbQLXNCB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



        }

        private void rbTuLuuMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new FrmDanhMucTuLuuMau();
            //ShowForm(f);
        }

        private void rbMaPPingMaMyXnViSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmMapping_MaMayXN_ViSinh();
            ShowForm(f);
        }

        private void rbCapSoThuTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var f = new FrmCapSothuTu_HIS();
            //ShowForm(f);
        }

        private void rbChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmChamCong();
            ShowForm(f);
        }
    }
}








