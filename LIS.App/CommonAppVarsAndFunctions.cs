using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.Data.HIS.HISDataCommon;
using TPH.Data.HIS.Models;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.UpdaterManagement.Services;
using TPH.UpdaterManagement.Services.Impl;

namespace TPH.LIS.App
{
    public class CommonAppVarsAndFunctions
    {
        public static readonly IUpdaterService updateService = new UpdaterService();
        public static ISystemConfigService _iConfig;
        public static Dictionary<string, List<string>> dicWorkingTest = new Dictionary<string, List<string>>();
        public static string DefaultObject { get; internal set; }
        public static int[] PCWorkPlaceOfHis { get; internal set; }
        // public static int[] allWorkingHis = new int[] {};
        public static int[] allWorkingHis = new int[] { (int)HisProvider.TPHLabIMS_Web_API, (int)HisProvider.ISofH
            , (int)HisProvider.DH_API, (int)HisProvider.ECOCLINIC, (int)HisProvider.PKTDK_IT, (int)HisProvider.VNPTMN };
        public static ConfigurationDetail sysConfig;
        public static string clsXetNghiemDinhDangKetqua;
        //Biến cho regedit
        public static readonly RegistryExtension RegistryExt = new RegistryExtension(0, UserConstant.RegistrySubKey);
        public static bool IsAdmin { get; internal set; }
        public static string PCWorkPlace { get; internal set; }
        public static string NhomIn { get; internal set; }
        public static string UserID { get; internal set; }
        public static string UserName { get; internal set; }
        public static string MaNhomNhanVien { get; internal set; }
        public static string TenNhomNhanVien { get; internal set; }
        public static string MaBoPhan { get; internal set; }
        public static string TenBoPhan { get; internal set; }

        public static bool RefreshReport { get; internal set; }


        public static string HelloString { get; internal set; }
        public static string HelloUserId { get; internal set; }
        public static string UserPass { get; internal set; }
        public static string TenPhieu { get; internal set; }
        public static string TenNguoiKy { get; internal set; }
        public static string ChucVu { get; internal set; }
        public static string TieuDe1 { get; internal set; }
        public static string TieuDe2 { get; internal set; }
        public static string TieuDe3 { get; internal set; }
        public static string TieuDe4 { get; internal set; }
        public static string TieuDe5 { get; internal set; }
        public static string TieuDe6 { get; internal set; }
        public static bool InMau { get; internal set; }
        public static int IDLayLoaiMau { get; internal set; }
        public static bool XacNhanKhiVaoketQua { get; internal set; }
        public static string[] UserWorkPlace { get; internal set; }
        public static bool AutoconfigCapture { get; internal set; }
        public static bool AutoId { get; internal set; }
        public static bool ValidPrintXn { get; internal set; }
        public static string CaptureImagePath { get; internal set; }
        public static string VideoOuptPath { get; internal set; }
        public static string CaptureImagePathNs { get; internal set; }
        public static string VideoOuptPathNs { get; internal set; }
        public static string PreviewCaptureNs { get; internal set; }
        public static string EcgInsPath { get; internal set; }
        public static string EcgResultPath { get; internal set; }
        public static string EcgImageSize { get; internal set; }
        public static string[] PhanQuyenXetNghiem { get; internal set; }
        public static string[] PhanQuyenMayXetNghiem { get; internal set; }
        public static string[] PhanQuyenKhuVuc { get; internal set; }
        public static string[] NhomClsXetNghiem { get; internal set; }
        public static string[] BoPhanClsXetNghiem { get; internal set; }
        public static string[] PhanQuyenSieuAm { get; internal set; }
        public static string[] PhanQuyenXQuang { get; internal set; }
        public static string[] PhanQuyenNoiSoi { get; internal set; }
        public static string[] PhanQuyenTaiChinhKeToan { get; internal set; }
        public static string[] PhanQuyenKhamBenh { get; internal set; }
        public static string[] PhanQuyenTiepNhan { get; internal set; }
        public static string[] PhanQuyenQuanLy { get; internal set; }
        public static string[] PhanQuyenThuNgan { get; set; }
        public static string[] PhanQuyenViSinh { get; internal set; }
        public static string[] NhomClsViSinh { get; internal set; }
        public static string[] NhomClsSieuAm { get; internal set; }
        public static string[] NhomClsxq { get; internal set; }
        public static string[] NhomClsNoiSoi { get; internal set; }
        public static LicenseModel License { get; set; } = new LicenseModel();
        public static MessageConstant LangMessageConstant { get; set; } = new MessageConstant();
        public static string TempSignIdXetNghiemSHPT { get; internal set; }
        public static string TempSignNameXetNghiemSHPT { get; internal set; }
        public static bool IsLogOut { get; set; } = false;
        //Danh sach card do hoa da kich hoạt
        public static string[] ArrayVideoCardActive = new string[5];
        public static string TempSignIdXetNghiemViSinh;
        public static string TempSignNameXetNghiemViSinh;

        public static ServiceType[] arrLoaiDichVu = {
            ServiceType.ClsXetNghiem
            //, ServiceType.ClsNoiSoi
            //, ServiceType.ClsSieuAm
            , ServiceType.ClsXNViSinh
            //, ServiceType.ClsXQuang
            //, ServiceType.KhamBenh
            //, ServiceType.DvKhac
            , ServiceType.TiepNhan };

        public static enumGioTinhThucHien gioTinhTgThucHien = enumGioTinhThucHien.ThoiGianNhapCD;
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
        public static List<IMSModule> IMSModuleAllow
        {
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
            }
        }

        public static bool CheckExist_IMSModule(IMSModule module)
        {
            return IMSModuleAllow.Where(x => x.Equals(module)).Any();
        }
        public static string ListEnumLoaiDichVu()
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
            if (lst.Length > 0)
            {
                foreach (string s in lst)
                {
                    if (s.Equals(idCheck))
                        return true;
                }
            }
            return false;
        }

        private static List<HISDataColumnNames> hisDataClumnsList;
        private static List<HisFunctionConfig> hisFunctionConfigList;
        private static List<HisConnection> hisConnectList;
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

        public static string LoginArguments { get; internal set; }
        public static string DonViGui { get; internal set; }
        public static bool formLoading { get; internal set; }
        public static DateTime ServerTime { get; internal set; }
        public static string UserIDTamSieuAm { get; internal set; }
        public static string TenNguoiKyTamSieuAm { get; internal set; }
        public static string TempSignIdXetNghiem = "";
        public static string TempSignNameXetNghiem = "";
        public static string TempSignIdNoiSoi = "";
        public static string TempSignNameNoiSoi = "";
        public static string TempSignIdXQuang = "";
        public static string TempSignNameXQuang = "";
        public static string CustomerID { get; set; }

        //Danh sách máy in
        private static ListBox _lstPrinter = new ListBox();
        public static ListBox LstPrinter
        {
            get { return _lstPrinter; }
            set { _lstPrinter = value; }
        }
        public static HisProvider WorkingHis { get; internal set; }
        public static string TPHFBlood_DB { get; internal set; }
        public static string PCWorkPlaceName { get; internal set; }

        public static bool _askWhenClose = true;
        public static bool _forceClose = false;
        public static bool _updating = false;
        public static bool _active = false;
        public static bool closeApp = false;
        public static bool forceUpdateRequest = false;
        public static bool IsFinishShow = false;

        public static bool _haveAlarm = false;
        public static string fileVersion = string.Empty;
        public static string appName = string.Empty;
        public static void RefreshHisConfigData()
        {
            Lab.Middleware.LISConnect.DataAccesses.IConnectHISDataAccess _iHisConfig = new Lab.Middleware.LISConnect.DataAccesses.ConnectHISDataAccess();
            hisFunctionConfigList = _iHisConfig.DataHisThongTinHam();
            hisDataClumnsList = _iHisConfig.DataHisThongTinMappingCot();
        }
        public static void Check_ShowUpdateSoftWare(bool isAuto = false)
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
                        CustomMessageBox.MSG_Information_OK("Ứng dụng sẽ tự động cập nhật phiên bản mới!");
                        forceUpdateRequest = false;
                        allow = true;
                    }
                    else
                        allow = CustomMessageBox.MSG_Question_YesNo_GetYes((isAuto ? "Đã có phiên bản mới bạn muốn cập nhật ứng dụng?" : "Thực hiện cập nhật ứng dụng?"));
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
                        CommonAppVarsAndFunctions._askWhenClose = false;
                        CommonAppVarsAndFunctions.closeApp = true;
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
    }
}
