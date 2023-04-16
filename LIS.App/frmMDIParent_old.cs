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
using TPH.LIS.App.CauHinh.HeThong;
using System.Net;
using System.Net.Sockets;
using TPH.LIS.App.Configurations;
using TPH.Language;

namespace TPH.LIS.App
{
    public partial class frmMDIParent_Old : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMDIParent_Old()
        {
            InitializeComponent();
            if (!DesignMode)
                LanguageExtension.LocalizeForm(this, Language);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        public bool IsFinishShow = false;
     
        public static bool ChangeLicense = false;
        public static bool FullLicense = false;
        public static string GetSerial { get; set; }

        public static LicenseModel License { get; set; } = new LicenseModel();
        public  static  ConfigurationDetail sysConfig = new ConfigurationDetail();
        public static string LoginArguments { get; set; } = "";
        public static string TempSignIdXetNghiem = "";
        public static string TempSignNameXetNghiem = "";
        public static string TempSignIdNoiSoi = "";
        public static string TempSignNameNoiSoi = "";
        public static string TempSignIdXQuang = "";
        public static string TempSignNameXQuang = "";
        public static DateTime ServerTime = DateTime.Now;
        //Thông tin user
        public static string UserID { get; set; }
        public static Bitmap _backgroundImage;
        public static string BackGroundFile = "Background.jpg";
        public static string PathBackGround = "";
        private readonly string _productKey;
        bool _active = false;
        public static bool CloseInLogIn = false;
        public static string UserName { get; set; }
        public static string UserPass { get; set; }
        public static bool IsAdmin { get; set; }
        public static bool PrintInPreview { get; set; }

        //Thông tin phiếu in
        public static string NhomIn { get; set; }
        public static string TieuDe1 { get; set; }
        public static string TieuDe2 { get; set; }
        public static string TieuDe3 { get; set; }
        public static string TieuDe4 { get; set; }
        public static string TieuDe5 { get; set; }
        public static string TieuDe6 { get; set; }
        public static bool InMau { get; set; }
        public static string ChucVu { get; set; }
        public static string TenNguoiKy { get; set; }
        public static string TenNguoiKyTamSieuAm { get; set; }
        public static string UserIDTamSieuAm { get; set; }
        public static string TenPhieu { get; set; }
        public static string DefaultObject = "";
        public static string[] ActivetedCapture;
        //Thông tin cấu hình hệ thống

        public static ServiceType[] arrLoaiDichVu = {
            ServiceType.ClsXetNghiem
            //, ServiceType.ClsNoiSoi
            //, ServiceType.ClsSieuAm
            , ServiceType.ClsXNViSinh
            //, ServiceType.ClsXQuang
            //, ServiceType.KhamBenh
            //, ServiceType.DvKhac
            , ServiceType.TiepNhan };
        public static List<IMSModule> IMSModuleAllow {
            get
            {
                    var lst = new List<IMSModule>();
                var arr = (sysConfig.ClsXetNghiemModuleKichHoat ?? (object)string.Empty).ToString().Split(',');
                    if (arr.Length > 0)
                    {
                        foreach (var m in arr)
                        {
                            if (!string.IsNullOrEmpty(m))
                            {
                                var module = (IMSModule)Enum.Parse(typeof(IMSModule), m);
                                lst.Add(module);
                                
                            }
                        }
                    }
                    return lst;
            } }
          
        public static bool CheckExist_IMSModule(IMSModule module)
        {
            return IMSModuleAllow.Where(x => x.Equals(module)).Any();
        }
        public static string ListEnumLoaiDichVu ()
        {
            string list = string.Empty;
            foreach (int val in arrLoaiDichVu)
            {
                list += (string.IsNullOrEmpty(list) ? "" : ",") + string.Format("{0}", val);
            }
            return list;
        }
        public static bool CheckExist_LoaiDichVu(ServiceType service)
        {
            var lst = ListEnumLoaiDichVu().Split(',');
            var idCheck = ((int)service).ToString();
            if(lst.Length >0)
            {
                foreach(string s in lst)
                {
                    if (s.Equals(idCheck))
                        return true;
                }
            }
            return false;
        }
        public static bool AutoconfigCapture { get; set; }
        public static string CaptureImagePath { get; set; }
        public static string VideoOuptPath { get; set; }

        public static string CaptureImagePathNs = "";
        public static string VideoOuptPathNs = "";
        public static string PreviewCaptureNs = "";

        public static string EcgInsPath = "";
        public static string EcgResultPath = "";
        public static string EcgImageSize = "";

        public static bool AutoId { get; set; }
        public static bool ValidPrintXn { get; set; }
        public static bool AutoCalculate { get; set; }
        public static bool AutoCalculateAll { get; set; }
        public static int AutoCalculateTime = 10;
        public static string clsXetNghiemDinhDangKetqua { get; set; }
        public static string TPHFBlood_DB { get; set; }
        public static string PCWorkPlace = string.Empty;
        public static int IDLayLoaiMau = 1;
        public static int[] PCWorkPlaceOfHis;
        public static string[] UserWorkPlace { get; set; }

        private int iCountToCheckUpdate = 900;
        private int iCountingUpdate = 0;
        private bool isNeedUpdate = false;
        private bool forceUpdateRequest = false;
        private int iCountingforceUpdate = 0;
        public static bool XacNhanKhiVaoketQua = false;
        //Biến cho regedit
        public static string subkey = "SOFTWARE\\ClinicSystem\\Properties\\";
      //Biến chức năng của user

       //Biến phân quyền nhóm của Xét nghiệm
        public static string[] NhomClsXetNghiem { get; set; }

        public static string[] PhanQuyenXetNghiem { get; set; }
        //Biến phân quyền máy xét nghiệm
        public static string[] PhanQuyenMayXetNghiem { get; set; }
        //phân quyền của siêu âm
        public static string[] NhomClsSieuAm { get; set; }

        public static string[] PhanQuyenSieuAm { get; set; }
        
        //phân quyền X-Quang
        public static string[] NhomClsxq { get; set; }

        //phân quyền khám bệnh
        public static string[] PhanQuyenKhamBenh { get; set; }

        public static string[] PhanQuyenXQuang { get; set; }

        //phân quyền Nội Soi
        public static string[] NhomClsNoiSoi { get; set; }

        public static string[] PhanQuyenNoiSoi { get; set; }

        ////phân quyền Tiep Nhan
        public static string[] PhanQuyenTiepNhan { get; set; }

        ////phân quyền Tài chính - kế toán
        public static string[] PhanQuyenTaiChinhKeToan { get; set; }

        ////phân quyền quản lý
        public static string[] PhanQuyenQuanLy { get; set; }
        //phân quyền vi sinh
        public static string[] NhomClsViSinh { get; set; }
        public static string[] PhanQuyenViSinh { get; set; }
        public static string[] PhanQuyenKhuVuc { get; set; }
        //Danh sách máy in
        private static ListBox _lstPrinter = new ListBox();
        public static ListBox LstPrinter
        {
            get { return _lstPrinter; }
            set { _lstPrinter = value; }
        }
        public static enumGioTinhThucHien gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
        private readonly ISystemConfigService _iConfig = new SystemConfigService();
        public static string[] BoPhanClsXetNghiem { get; set; }
        public static int[] allWorkingHis = new int[] { (int)HisProvider.TPHLabIMS_Web_API, (int)HisProvider.DH_API, (int)HisProvider.SUN };
        private static int HISSuDung { get; set; }
        public static HisProvider WorkingHis
        {
            get
            {
                if (HISSuDung > 0)
                {
                    return (HisProvider)HISSuDung;
                }
                else
                    return HisProvider.NONE;
            }
            set
            {
                HISSuDung = (int)value;
            }
        }

        private static List<HISDataColumnNames> hisDataClumnsList;
        private static List<HisFunctionConfig> hisFunctionConfigList;
        private static List<HisConnection> hisConnectList;
        private bool _updating = false;
        private Thread _tak;
        private static bool _askWhenClose = true;
        private static bool _forceClose = true;
        public bool _haveAlarm = false;
        private string fileVersion = string.Empty;
        private string appName = string.Empty;
        public void SetCloseProgram(bool forceClose)
        {
            _forceClose = forceClose;
            _askWhenClose = !forceClose;
            if (forceClose)
            {
                CloseAllForm();
                Application.Exit();
            }
        }
        public static List<HisConnection> HisConnectList
        {
            get
            {
                if (hisConnectList == null)
                {
                    Lab.Middleware.LISConnect.DataAccesses.IConnectHISDataAccess _iHisConfig = new Lab.Middleware.LISConnect.DataAccesses.ConnectHISDataAccess();
                    hisConnectList = _iHisConfig.DataHisThongTin();
                }
                return hisConnectList;
            }
            set
            {
                hisConnectList = value;
                RefreshHisConfigData();
            }
        }

        public static List<HisFunctionConfig> HisFunctionConfigList
        {
            get
            {
                if (hisFunctionConfigList == null)
                {
                    Lab.Middleware.LISConnect.DataAccesses.IConnectHISDataAccess _iHisConfig = new Lab.Middleware.LISConnect.DataAccesses.ConnectHISDataAccess();
                    hisFunctionConfigList = _iHisConfig.DataHisThongTinHam();
                }
                return hisFunctionConfigList;
            }
            set
            {
                hisFunctionConfigList = value;
            }
        }

        public static List<HISDataColumnNames> HisDataColumnsList
        {
            get
            {
                if (hisDataClumnsList == null)
                {
                    Lab.Middleware.LISConnect.DataAccesses.IConnectHISDataAccess _iHisConfig = new Lab.Middleware.LISConnect.DataAccesses.ConnectHISDataAccess();
                    hisDataClumnsList = _iHisConfig.DataHisThongTinMappingCot();
                }
                return hisDataClumnsList;
            }
            set
            {
                hisDataClumnsList = value;
            }
        }

        public static void RefreshHisConfigData()
        {
            Lab.Middleware.LISConnect.DataAccesses.IConnectHISDataAccess _iHisConfig = new Lab.Middleware.LISConnect.DataAccesses.ConnectHISDataAccess();
            hisFunctionConfigList = _iHisConfig.DataHisThongTinHam();
            hisDataClumnsList = _iHisConfig.DataHisThongTinMappingCot();
        }
        public static string DonViGui { get; internal set; }
        public static string TempSignIdXetNghiemSHPT { get; internal set; }
        public static string TempSignNameXetNghiemSHPT { get; internal set; }
        public bool LocalizedLanguage = true;

        public static string Language = string.Empty;

        //Danh sach card do hoa da kich hoạt
        public static string[] ArrayVideoCardActive = new string[5];
        internal static string TempSignIdXetNghiemViSinh;
        internal static string TempSignNameXetNghiemViSinh;
        private bool closeApp = false;

        string LongRunningMethod(int iCallTime, out int iExecThread)
        {
            Thread.Sleep(iCallTime);
            iExecThread = Thread.CurrentThread.ManagedThreadId;
            return string.Format("Thời gian thực thi là: {0}" , iCallTime);
        }
        // The following delegate 
        delegate string MethodDelegate(int iCallTime, out int iExecThread);
        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            rbMainMenu.Minimized = true;
            fileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            appName = new FileInfo(Application.ExecutablePath).Name.Replace(new FileInfo(Application.ExecutablePath).Extension, "");
            var asm = Assembly.GetExecutingAssembly();
            _iConfig.Update_PcLogin(Environment.MachineName, asm.GetName().Version.ToString(), GetLocalIPAddress(), appName);
            var udpFlat = _iConfig.Check_UpdateSoftware(Environment.MachineName, fileVersion, appName);
            if (udpFlat == 1 || udpFlat == 2)
                Check_ShowUpdateSoftWare(true);
            lblVersion.Text = lblVersion.Text = string.Format(" | {0}:{1}", LanguageExtension.GetResourceValueFromKey("PhienBan", Language), Assembly.GetExecutingAssembly().GetName().Version); 
            if (License.FullLicense)
            {
                _tak = new Thread(LoadPrinterList);
                _tak.Start();
                WorkingServices.EmptyFolderContents("Logs", 3, null);
                ServerTime = C_Ultilities.ServerDate();
                timerMain.Start();
                _active = true;

                LockControl(true);
              
                var frmLogin = new frmLogIn();
                ShowForm(frmLogin);
                
            }
            else
            {
                CheckLicense(false);
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
                if (_askWhenClose)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetNo(MessageConstant.ExitProgram))
                    {
                        e.Cancel = true;
                        SetStartUpBackground(false);
                    }
                    else
                    {
                        Start_StopAlarm(false);
                      
                    }
                }
                else
                {
                    Start_StopAlarm(false);
                }
            }
            else
            {
                Start_StopAlarm(false);
            }
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
        
        }

        private void frmMDIParent_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mnuTiepNhan_Click(object sender, EventArgs e)
        {
            var frm = new DailyUse.BenhNhan.FrmTiepNhanBenhNhan();
            ShowForm(frm);
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            TimBN();
        }

        private void btnTimBenhNhan_Click(object sender, EventArgs e)
        {
            TimBN();
        }

        private void mnuKQXetNghiem_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmCLSKetQuaXN();
            ShowForm(frm);
        }

        private void mnuXuatKQXetNghiem_Click(object sender, EventArgs e)
        {
            var frm = new ThongKe.frmXuatKetQuaXetNghiem();
            ShowForm(frm);
        }

        private void mnuKQSieuAm_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmCLSKQSieuAm();
            ShowForm(frm);
        }
        private void mnuKQNoiSoi_Click(object sender, EventArgs e)
        {
            var f = new ThucThi.CanLamSang.frmCLSKQNoiSoi();
            ShowForm(f);
        }

        private void mnuKQXQuang_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmCLSKetQuaXQuang();
            ShowForm(frm);
        }

        private void mnuGuiEmail_Click(object sender, EventArgs e)
        {
            var frm = new ThucThi.CanLamSang.frmEmail();
            ShowForm(frm);
        }

        private void mnuTKTongHopXN_Click(object sender, EventArgs e)
        {
            var frm = new ThongKe.frmThongKeTongHopXN();
            ShowForm(frm);
        }

        private void mnuTKTongHopSieuAm_Click(object sender, EventArgs e)
        {
            var frm = new ThongKe.frmThongKeTongHopSA();
            ShowForm(frm);
        }

        private void mnuTKTongHopXQuang_Click(object sender, EventArgs e)
        {
            var frm = new ThongKe.frmThongKeTongHopXQuang();
            ShowForm(frm);
        }

        private void mnuTKTongHopCLS_Click(object sender, EventArgs e)
        {
            var frm = new ThongKe.frmThongKeTongHop();
            ShowForm(frm);
        }

        private void mnuDMXetNghiem_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmDMCLS_XetNghiem();
            ShowForm(frm);
        }

        private void mnuDMXQuang_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmDMCLS_XQuang();
            ShowForm(frm);
        }

        private void mnuDMSieuAm_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmDMCLS_SieuAm();
            ShowForm(frm);
        }

        private void mnuDMDoiTuong_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmDM_DoiTuongDichVu_Gia();
            ShowForm(frm);
        }

        private void mnuDMDiaChi_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.HeThong.frmCauHinh_TinhThanhPho();
            ShowForm(frm);
        }

        private void DMNhanVien_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.NhanVien.frmNhanVien_ChanDoan();
            ShowForm(frm);
        }

        private void mnuDMUser_Click(object sender, EventArgs e)
        {
           var frm = new Settings.NhanVien.FrmTaiKhoanNguoiDung();
            frm.ShowDialog();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmResetPassword();
            frm.ShowDialog();
        }

        private void mnuDmNhomLoaiVatTu_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.VatTu.frmDM_VatTu_NhomLoai();
            ShowForm(frm);
        }

        private void mnuDMVatTu_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.VatTu.frmDM_VatTu();
            ShowForm(frm);
        }

        private void mnuCauHinhEmail_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.HeThong.frmEmailConfig();
            frm.ShowDialog();
        }

        private void mnuCauHinhPhieuIn_Click(object sender, EventArgs e)
        {
            CauHinh.HeThong.frmPrintHeader frm = new CauHinh.HeThong.frmPrintHeader();
            ShowForm(frm);
        }

        private void mnuCauHinhHeThong_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.HeThong.frmCauHinh_CaiDatHeThong();
            frm.ShowDialog();
        }

        private void mnuCaiDatBatHinh_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.HeThong.frmConfigVideoDevice();
            ShowForm(frm);
        }

        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            FrmStartUp frm = new FrmStartUp();
            ShowForm(frm);
            frm.AnManChe();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Đăng xuất ứng dụng?"))
            {
                _active = false;
                Application.Restart();
            }
        }

        private void mnuDMThuoc_Click(object sender, EventArgs e)
        {
            var frm = new CauHinh.DanhMucKhamBenh.FrmDanhMucThuoc();
            ShowForm(frm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                this.Dispose();
            }
        }

        private void frmMDIParent_FormClosed(object sender, FormClosedEventArgs e)
        {
           // this.Dispose();
        }
        private string NgayLamViec = string.Empty;
        private string ThongbaoLamMoi = string.Empty;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ServerTime = ServerTime.AddSeconds(1);
            if (string.IsNullOrEmpty(NgayLamViec))
            {
                var ngay = LanguageExtension.GetResourceValueFromValue(MessageConstant.NgayLamViec, Language);
                NgayLamViec = string.IsNullOrEmpty(ngay) ? MessageConstant.NgayLamViec : ngay;
            }
            if (string.IsNullOrEmpty(ThongbaoLamMoi))
            {
                var thongbao = LanguageExtension.GetResourceValueFromKey("ThongBaoSeTuLamMoiSau", Language);
                ThongbaoLamMoi = thongbao;
            }
            lblTimer.Text = string.Format("| {0}: {1: dd/MM/yyyy HH:mm:ss}", NgayLamViec, ServerTime);
            if (!License.FullLicense)
            {
                if (ServerTime >= License.EndDate || ServerTime <= License.StartDate)
                {
                    timerMain.Stop();
                    _active = false;
                    Application.Restart();
                }
                else
                {
                    if (License.ChangeLicense)
                    {
                        var difference = License.EndDate - ServerTime.Date;
                        this.Text = string.Format(MessageConstant.PhanMemConNgayDungThu, CommonConstant.ApplicationName, difference.Days); ;
                        License.ChangeLicense = false;
                    }
                }
            }

            //kiểm tra update
            if (iCountingUpdate >= iCountToCheckUpdate)
            {
                ServerTime = AppCode.C_Ultilities.ServerDate();
                var checkUpdateFlat = _iConfig.Check_UpdateSoftware(Environment.MachineName, fileVersion, appName);
                if (checkUpdateFlat == 2)
                {
                    if (forceUpdateRequest)
                    {
                        mnuCapNhatPhanMem_Click(sender, e);
                    }
                    else
                    {
                        isNeedUpdate = true;
                        iCountingUpdate = 0;
                        iCountingforceUpdate = 0;
                        forceUpdateRequest = true;
                        lblThongBaoCapNhat.Text = string.Format("THÔNG BÁO: ỨNG DỤNG TỰ CẬP NHẬT SAU {0}s", iCountToCheckUpdate);
                    }
                }
                else
                {
                    forceUpdateRequest = false;
                    isNeedUpdate = checkUpdateFlat == 1;
                    iCountingUpdate = 0;
                }
            }
            else
            {
                iCountingforceUpdate++;
                iCountingUpdate++;
                if (ServerTime.Hour == 0 && ServerTime.Minute == 00 && ServerTime.Second == 0)
                {
                    WorkingServices.EmptyFolderContents("Logs", 3, null);
                }
            }

            if (isNeedUpdate)
            {
                if (!lblThongBaoCapNhat.Visible)
                    lblThongBaoCapNhat.Visible = true;


                lblThongBaoCapNhat.Text = string.Format("CẢNH BÁO: ỨNG DỤNG TỰ CẬP NHẬT SAU {0}s", iCountToCheckUpdate - iCountingforceUpdate);
                lblThongBaoCapNhat.BackColor = lblThongBaoCapNhat.BackColor == Color.Yellow ? Color.WhiteSmoke : Color.Yellow;
            }
            else
            {
                if (lblThongBaoCapNhat.Visible)
                    lblThongBaoCapNhat.Visible = false;
                lblThongBaoCapNhat.BackColor = Color.WhiteSmoke;
            }
            if (!License.FullLicense)
                CheckLicense(true);
            counting++;
            lblThongbaolamMoi.Text = string.Format("{0}: {1}s", ThongbaoLamMoi, ((timerAlarm.Interval) / 1000) - counting);
        }
  
        private void tsbLayMau_Click(object sender, EventArgs e)
        {
            var frm = new FrmLayMau();
            ShowForm(frm);
        }

        private void mnuCapNhatPhanMem_Click(object sender, EventArgs e)
        {
            Check_ShowUpdateSoftWare(false);
        }
        private void Check_ShowUpdateSoftWare(bool isAuto = false)
        {
            try
            {
                if (!_updating)
                {
                    _updating = true;
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
                        FileName =string.Format("TPH.{0}.Updater.exe", Application.ProductName.Replace("TPH.","").Replace(".exe","")),
                        Arguments = string.Format("{0}", 1)
                        }
                        };
                        p.Start();
                        _askWhenClose = false;
                        closeApp = true;
                        Application.Exit();
                    }
                    else
                        _updating = false;
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
            var f = new DailyUse.CanLamSang.FrmCLSKetQuaViSinh();
            ShowForm(f);
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
        public void CloseAllForm()
        {
            foreach (Form f in MdiChildren)
            {
                f.Close();
            }
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
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDIParent));

            if (frm is FrmTemplate)
            {
                var f = (FrmTemplate)frm;
                f.ShowManChe();
                frm.Show();
                frm.Shown += frm_Shown;
            }
            else
            {
                LanguageExtension.LocalizeForm(frm, Language);
                frm.Show();
            }
            frm.BringToFront();
            formLoading = false;
        }
        private void frm_Shown(object sender, EventArgs e)
        {
            var f = (FrmTemplate)sender;
            f.AnManChe();
    
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
                            Arguments = string.Format("{0},{1}", UserName, UserPass)
                        }
                    };

                    p.Start();
                }
            }
            catch
            {

            }
        }


        void LoadTPHFBloodDBConfig()
        {
            TestResult.Services.ITestResultService p_xetnghiem = new TestResult.Services.TestResultService();
            DataTable dt = p_xetnghiem.GetValueConfig(4);
            if (dt.Rows.Count > 0)
            {
                TPHFBlood_DB = dt.Rows[0]["value1"].ToString();
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
            frm.DtDateFromG = ServerTime;
            ShowForm(frm);
        }

        private void LoadPrinterList()
        {
            if (ProgressBarMain.InvokeRequired)
            {
                ProgressBarMain.Invoke(new MethodInvoker(delegate
                {
                    Task.Factory.StartNew(() =>
                    {
                        ShowStatus("Load danh sách máy in.");
                        LabServices_Helper.LoadPrinterName(LstPrinter, UserConstant.RegistryPrinterResult, true);
                        ShowStatus("");
                    });
                }));
            }
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
        private void CheckLicense(bool fromAutocheck)
        {
            var trialDays = (License.EndDate - License.StartDate).Days;

            if (ServerTime >= License.EndDate || ServerTime <= License.StartDate)
            {
                timerMain.Stop();
                timerMain.Enabled = false;
                LockControl(true);
                this.Text = string.Format(MessageConstant.PhanMemDaHetHanSuDung, CommonConstant.ApplicationName, trialDays, License.StartDate, License.EndDate);
                MessageBox.Show(string.Format(MessageConstant.PhanMemDaHetHanSuDungVuiLongLienHe, CommonConstant.ApplicationName, trialDays));
            }
            else if(!fromAutocheck)
            {
                timerMain.Start();
                var difference = License.EndDate.Date - ServerTime.Date;
                var versionInfo = License.StatusFullDescription;
                this.Text = versionInfo;

                if (difference.Days < 6)
                {
                    MessageBox.Show(string.Format(MessageConstant.BanConNgayLamViecVuiLongLienHeTph, difference.Days));
                }
                _tak = new Thread(new ThreadStart(LoadPrinterList));
                _active = true;
                LockControl(true);
                LoadTPHFBloodDBConfig();
                var loginForm = new frmLogIn();
                ShowForm(loginForm);
                _tak.Start();
            }
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
            var f = new FrmTinhTrangLyDo();
            f.ShowDialog();
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

            var data = _iAnalyzer.Data_DanhSachCoTuMay(BoPhanClsXetNghiem.ToList(), NhomClsXetNghiem.ToList(), PhanQuyenMayXetNghiem.ToList(), string.Empty);
            ucAnalyzerAlarmList1.DataSource = data;
            Check_haveAlarm();
            //pnAlarm.Controls.Remove(pnCurtaint);
        }
       private void Check_haveAlarm()
        {
            _haveAlarm = false;
            if (ucAnalyzerAlarmList1.DataSource != null)
            {
                if (ucAnalyzerAlarmList1.DataSource.Rows.Count > 0)
                    _haveAlarm = true;
            }
            //còn list nào nữa thì cứ if không else
        }
        #endregion
        int counting = 0;
       
        private void timerAlarm_Tick(object sender, EventArgs e)
        {
            timerAlarm.Stop();
            //counting = 0;
            //try
            //{
            //    Load_DSCanhBaoTuMay();
            //}
            //catch (Exception ex)
            //{
            //    WriteLog.LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "Logs_TimerAlarm", ex);
            //}
            //counting = 0;
            timerAlarm.Start();
        }
        public void Start_StopAlarm(bool start)
        {
            if(start)
            {
                counting = 0;
                timerAlarm.Enabled = true;
                timerAlarm.Start();
            }
            else
            {
                timerAlarm.Stop();
                timerAlarm.Enabled = false;
            }
        }

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
            var f = new DailyUse.CanLamSang.FrmCLSKetQuaViSinh();
            ShowForm(f);
        }

        private void rbKetQuaTuiMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rbKetQuaTuiMau.Enabled)
            {
                var frm = new ThucThi.BenhNhan.FrmDuyetKetquaXN();
                ShowForm(frm);
            }
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
            var f = new FrmTinhTrangLyDo();
            f.ShowDialog();
        }

        private void rbDanhMucLoaiMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmDM_LoaiMau();
            ShowForm(f);
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
            var frm = new  Frm_DM_BienDichKetQua();
            ShowForm(frm);
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
            var frm = new frmDMCLS_MaXetNghiem_May();
            ShowForm(frm);
        }

        private void rbDanhMucKetNoiHIS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmCauHinh_MappingHIS();
            ShowForm(frm);
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
            frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new CauHinh.DanhMucCLS.frmResetPassword();
            frm.ShowDialog();
        }
        private void rbDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmDashBoardTAT();
            f.Show();
        }

        private void rbCaiDatKetNoiHis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new Settings.HeThong.FrmCauHinh_His();
            ShowForm(f);
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
            rbCapNhatPhanMem.Enabled = true;
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
        }

        public static bool CheckUserPermissionToAccessFunctions(
            string[] allowPermissions,
            string check)
        {
            if (allowPermissions == null)
                return false;
            return
                allowPermissions.Any(
                    currentPermission =>
                        currentPermission.Trim().Equals(check.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        private void Check_Enable_ViSinh()
        {
            //Xem kết quả
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenViSinh,
                UserConstant.PermissionVSViewResult))
            {
                rbKQViSinhNuoiCay.Enabled = true;
                rbPhieuTienTrinhViSinh.Enabled = true;
            }
            //Quyền gửi mail
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenViSinh,
                UserConstant.PermissionTestSendMail))
            {
                rbGuiEMailKetQua.Enabled = true;
            }
        }
        private void Check_Enable_TN()
        {
            //Kiểm tra quyền được xem
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenTiepNhan, UserConstant.PermissionReceptionViewPatientInfo))
            {
                // Thông tin bệnh nhân
                btnTiepNhanThuCong.Enabled = rbInbaracodeKSK.Enabled = rbTiepNhanBenhNhan.Enabled = true;
                rbNhapTheoDanhSach.Enabled = true;
            }
            rabCapNhatThongTinTuHis.Enabled = rbTiepNhanHIS.Enabled = btnTiepNhanHis.Enabled = CheckUserPermissionToAccessFunctions(
                      PhanQuyenTiepNhan,
                      UserConstant.PermissionReceptionFromHIS);
            rbThongTinSangLocSoSinh.Enabled = CheckUserPermissionToAccessFunctions(
                   PhanQuyenTiepNhan,
                   UserConstant.PermissionReceptionSLSS);
            rbThongTinSangLocTruocSinh.Enabled = CheckUserPermissionToAccessFunctions(
                  PhanQuyenTiepNhan,
                  UserConstant.PermissionReceptionSLTS);

            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenTiepNhan,
                UserConstant.PermissionReceptionSearchPatientInfo))
            {
                //Tìm bệnh nhân
                rbTimKiem.Enabled = btnTimBenhNhan.Enabled = true;
            }
        }
        private void Check_Enable_QuanLy()
        {
            //QL Giá dịch vụ
            rbDoituongDichVu.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionViewCustomerObject);
            rbKhoaPhong.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionManangeLocation);
            rbNguoiDung.Enabled = CheckUserPermissionToAccessFunctions(
                         PhanQuyenQuanLy,
                         UserConstant.PermissionManangeUser);
            rbMayInBarCode.Enabled = CheckUserPermissionToAccessFunctions(
                  PhanQuyenQuanLy,
                  UserConstant.PermissionConfigBarcodeSystem);
            rbNhanVien.Enabled = CheckUserPermissionToAccessFunctions(
                  PhanQuyenQuanLy,
                  UserConstant.PermissionCategoriesEmployee);
            rbKhuVuc.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionComputer);
            rbDanhMucLoaiMau.Enabled = CheckUserPermissionToAccessFunctions(
                  PhanQuyenQuanLy,
                  UserConstant.PermissionCategoriesManagementOfSample);

            rbDmHenTraKetQua.Enabled = CheckUserPermissionToAccessFunctions(
                 PhanQuyenQuanLy,
                 UserConstant.PermissionManageReturnResultTicket);

            rbDmHenTraKetQua.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionManageReturnResultTicket);

            rbDanhMucKetNoiHIS.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionHISLISMapping);

            rbDiaChi.Enabled = rbKhoaPhong.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionLocation);

            rbCauHinhPhieuIn.Enabled = CheckUserPermissionToAccessFunctions(
               PhanQuyenQuanLy,
               UserConstant.PermissionConfigTitlePrint);

            rbTieuDeTrangIn.Enabled = CheckUserPermissionToAccessFunctions(
               PhanQuyenQuanLy,
               UserConstant.PermissionConfigTitlePrint);

            rbCauHinhHeThong.Enabled = CheckUserPermissionToAccessFunctions(
              PhanQuyenQuanLy,
              UserConstant.PermissionConfigSystem);
            rbTembarcode.Enabled = CheckUserPermissionToAccessFunctions(
              PhanQuyenQuanLy,
              UserConstant.PermissionConfigSystem);
            radNgonNgu.Enabled = rbCauHinhHeThong.Enabled;
            rbMayIn.Enabled = CheckUserPermissionToAccessFunctions(
               PhanQuyenQuanLy,
               UserConstant.PermissionCategoryPrinter);

            rbDanhMucXetNghiem.Enabled = CheckUserPermissionToAccessFunctions(
               PhanQuyenQuanLy,
               UserConstant.PermissionCategoriesManagementOfTest);
            rbBienDichDanhMuc.Enabled = CheckUserPermissionToAccessFunctions(
               PhanQuyenQuanLy,
               UserConstant.PermissionConfigSystem);
            rbTinhTrangMauLyDo.Enabled = CheckUserPermissionToAccessFunctions(
               PhanQuyenQuanLy,
               UserConstant.PermissionCategoriesReason);

            rbDanhMucMaMayXetNghiem.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);
            rbMappingMayViSinh.Enabled = CheckUserPermissionToAccessFunctions(
              PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);
            rbBienDichCo.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy, UserConstant.PermissionManagementOfAnalyzerTest);

            rbBienDichKetQua.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionManagementOfConvertTest);
            rbNhatKy.Enabled = CheckUserPermissionToAccessFunctions(
                 PhanQuyenQuanLy,
                 UserConstant.PermissionViewLog);

            rbDashboard.Enabled = CheckUserPermissionToAccessFunctions(
                 PhanQuyenXetNghiem,
                 UserConstant.PermissionViewDasboardTAT);

            rbCaiDatKetNoiHis.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionManageHISConfig);

            rbThongTinMayXN.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionManageAnalyzerInformation);
            //QL Danh Mục vi sinh
            rbDanhMucViSinh.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenQuanLy,
                UserConstant.PermissionCategoriesManagementOfVS);
        }
        private void Check_Enable_XN()
        {
            //Xem kết quả
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionTestViewResult))
            {
                rbKetQuaThuongQuy.Enabled = true;
                tsbKetQuaXN.Enabled = true;
                rbXacNhanTraKetQua.Enabled = true;
                rbXemPDF.Enabled = true;
            }
  
            rbKetQuaTuMayXN.Enabled = CheckUserPermissionToAccessFunctions(
            PhanQuyenXetNghiem, UserConstant.PermissionTestViewAnalyzerResult);

            rbChuyenKetQua.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionTestPrintResult);
            rbNhanPhieuKetQua.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionCollectResulReport);
            rbInTheoDanhSach.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionTestPrintResult);
            rbDmHenTraKetQua.Enabled = CheckUserPermissionToAccessFunctions(
               PhanQuyenXetNghiem,
               UserConstant.PermissionManangeLocation);

            rbDanhMucKetNoiHIS.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionManangeLocation);

            rbDanhMucLoaiMau.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionManangeLocation);

            rbKQSinhHocPhanTu.Enabled = CheckUserPermissionToAccessFunctions(
                  PhanQuyenXetNghiem,
                  UserConstant.PermissionMicroBiologyViewResult);

            rbDangNhapLayMau.Enabled = rbBanLayMau.Enabled = tsbLayMau.Enabled = rbLayMau.Enabled = CheckUserPermissionToAccessFunctions(
                  PhanQuyenXetNghiem,
                  UserConstant.PermissionTestCollectSample);

            tsbNhanMau.Enabled = rbNhanMau.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem, UserConstant.PermissionTestGetSample);

            tsbChuyenMau.Enabled = rbChuyenMau.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);

            rbLichSuXetNghiem.Enabled = CheckUserPermissionToAccessFunctions(
             PhanQuyenXetNghiem, UserConstant.PermissionViewHisotryTestResult);

            rbTheoDoiMau.Enabled = CheckUserPermissionToAccessFunctions(
             PhanQuyenXetNghiem, UserConstant.PermissionViewSampleTracking);

            tsbChuyenMau.Enabled = rbChuyenMau.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem, UserConstant.PermissionTransferSample);

            rbKetQuaTuiMau.Enabled = CheckUserPermissionToAccessFunctions(
                 PhanQuyenXetNghiem, UserConstant.PermissionBloodTestViewResult);

            rbKQUploadHIS.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem, UserConstant.PermissionViewUploadedHISTestResult);
            //Thống kê - Báo cáo
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionReportStatisticOfTest))
            {
                rbThongKeTongHopXn.Enabled = true;
               // mnuThongKe.Enabled = true;
            }
            //Quyền gửi mail
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionTestSendMail))
            {
                rbGuiEMailKetQua.Enabled = true;
            }

            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionTestExportResult))
            {
                rbXuatKetQua.Enabled = true;
            }
            rbLuuMau.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionViewArchiveSample);
            rbHuyMauLuu.Enabled = CheckUserPermissionToAccessFunctions(
                PhanQuyenXetNghiem,
                UserConstant.PermissionDestroyArchiveSample);
        }
        private void Check_Enable_SA()
        {
            //Xem kết quả
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenSieuAm,
                UserConstant.PermissionViewResultOfSupersonic))
            {
                rbKetQuSieuAm.Enabled = true;
            }
            //Quyền gửi mail
            if (CheckUserPermissionToAccessFunctions(
                PhanQuyenSieuAm,
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
            f.userDangNhap = UserID;
            f.Show();
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

        private void rbBienDichCo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmCauHinh_Config();
            ShowForm(f);
        }

        private void rbDiaChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmCauHinh_TinhThanhPho();
            ShowForm(f);
        }

        private void rbThongTinSangLocSoSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmThongTinSangLocSoSinh();
            ShowForm(f);
        }

        private void rbThongTinSangLocTruocSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmThongTinSangLocTruocSinh();
            ShowForm(f);
        }

        private void btnTiepNhanThuCong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new FrmTiepNhanBenhNhan();
            ShowForm(frm);
        }

        private void tsbKetQuaSHPT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new FrmSinhHocPhanTu();
            ShowForm(frm);
        }

        private void rbBienDichDanhMuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmNgonNguDanhMuc();
            ShowForm(frm);
        }

        private void radNhapTheoDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmNhapKSK();
            ShowForm(f);
        }

        private void rbKetQuaTuMayXN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmKetQuaMayXN();
            ShowForm(f);
        }

        private void rbXemPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmViewPDFSigned();
            ShowForm(f);
        }

        private void tbMappingMayViSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new frmMapping_MaMayXN_ViSinh();
            ShowForm(f); 
        }

        private void rbPhieuTienTrinhViSinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmCLSViSinh_PhieuTienTrinh();
            ShowForm(f);
        }

        private void radNgonNgu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmNgonNguPhanMem();
            ShowForm(f);
        }
    }
}