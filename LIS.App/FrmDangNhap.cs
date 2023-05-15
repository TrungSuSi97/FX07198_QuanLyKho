using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.Controls;
using TPH.Language;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.PrintedForm;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Models;
using TPH.LIS.User.Models.Params;
using TPH.LIS.User.Services.Authorization;
using TPH.LIS.User.Services.ServiceSetting;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App
{
    public partial class FrmDangNhap : Controls.TPHTemplateForm
    {
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly IAuthorizationService _authorizationService = new AuthorizationService();
        private readonly IUserManagementService _userManagementService = new UserManagementService();
        private readonly IPrintedFormService _printedFormService = new PrintedFormService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly IServiceSettingService _serviceSettingService = new ServiceSettingService();
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        public string LoginName { get;  set; }
        public string Pwd { get; set; }
        public FrmDangNhap()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            //this.BackColor = CommonAppColors.colorMainAppFormColor;
            //pnContent.BackColor = CommonAppColors.colorMainAppFormColor;
            //pnApp.BackColor = CommonAppColors.colorMainAppColor;
            //pnLogin.TopColor = CommonAppColors.colorMainAppFormColor;
            //pnLogin.BottomColor = CommonAppColors.colorMainAppColorSub1;
            //statusStrip1.BackColor = CommonAppColors.ColorBottomAppColor;
            //btnDangNhap.BackColor = CommonAppColors.ColorButtonBackColor;
            //btnThoat.BackColor = CommonAppColors.ColorButtonBackColor;
            //btnDangNhap.ForeColor = CommonAppColors.ColorButtonForceColor;
            //btnThoat.ForeColor = CommonAppColors.ColorButtonForceColor;
            //btnDangNhap.IconColor = CommonAppColors.ColorButtonForceColor;
            //btnThoat.IconColor = CommonAppColors.ColorButtonForceColor;
            //txtTaiKhoan.BorderColor = CommonAppColors.ColorTextBorder;
            //txtMatKhau.BorderColor = CommonAppColors.ColorTextBorder;
            LanguageExtension.LocalizeForm(this, string.Empty);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTaiKhoan.TextValue) &&
                    !string.IsNullOrWhiteSpace(txtMatKhau.TextValue))
            {
                DoLogin();
            }
        }
        private void DoLogin()
        {
            var isValid = _authorizationService.CheckLogin(new LoginParams
            {
                Username = txtTaiKhoan.TextValue.Trim(),
                Password = txtMatKhau.TextValue.Trim(),
                Ip = IpExtension.Ip(),
                System = CommonConstant.ApplicationName
            });

            if (!isValid)
            {
                CustomMessageBox.MSG_Waring_OK(CommonAppVarsAndFunctions.LangMessageConstant.WrongLoginuserOrPassword);
                return;
            }
            var userloginInfo = _userManagementService.GetUserInfoByLoginName(txtTaiKhoan.TextValue);
            if (AssignWorkPlace(userloginInfo.IsAdmin ? "admin" : txtTaiKhoan.TextValue.Trim()))
            {
                AssignUserLoginInfoToMainForm(userloginInfo);
                AssignPrintedHeader(userloginInfo);
                //AssignSystemConfig();
                AssignPermissionToUserLogin(CommonAppVarsAndFunctions.IsAdmin ? "admin" : userloginInfo.LoginName);
                CommonAppVarsAndFunctions.DefaultObject = _serviceSettingService.GetDefaultServiceCode();

                WriteUserLoginInfoToRegistry();

                if (userloginInfo.IsAdmin)
                    CommonAppVarsAndFunctions.PCWorkPlaceOfHis = CommonAppVarsAndFunctions.allWorkingHis;
                else
                {
                    var hisID = _systemConfigService.GetPCHisWorking(Environment.MachineName, CommonAppVarsAndFunctions.PCWorkPlace);
                    bool alreadSet = false;
                    if (hisID.Length > 0)
                    {
                        foreach (var hid in hisID)
                        {
                            if (hid == 0)
                            {
                                CommonAppVarsAndFunctions.PCWorkPlaceOfHis = CommonAppVarsAndFunctions.allWorkingHis;
                                alreadSet = true;
                                break;
                            }
                        }
                        if (!alreadSet)
                            CommonAppVarsAndFunctions.PCWorkPlaceOfHis = hisID;
                    }
                    else
                        CommonAppVarsAndFunctions.PCWorkPlaceOfHis = CommonAppVarsAndFunctions.allWorkingHis;
                }
                CommonAppVarsAndFunctions.HelloString = $"{CommonConstant.Hello}:";
                CommonAppVarsAndFunctions.HelloUserId = string.IsNullOrEmpty(userloginInfo.Username) ?
                    userloginInfo.LoginName : $"{userloginInfo.Username} - ID: {userloginInfo.LoginName}";
                _registryExtension.WriteRegistry(UserConstant.RegistryLoginLanguage, cboLanguage.SelectedIndex.ToString());
                //if (cboLanguage.SelectedIndex == 1)
                //{
                //    LanguageExtension.AppLanguage = "en-US";
                //}
                //else
                //    LanguageExtension.AppLanguage = "vi-VN";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (userloginInfo.IsAdmin && string.IsNullOrEmpty(CommonAppVarsAndFunctions.PCWorkPlace))
            {
                CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.PCNotCreatePlaceWork);
                var f = new Settings.HeThong.FrmCauHinh_KhuVuc {pnMenu = {Visible = true}};
                f.AdjustForm();
                f.ShowDialog();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.PCNotCreatePlaceWorkOrPermission);
                Application.Exit();
            }
        }
        private void AssignUserLoginInfoToMainForm(UserInfo userloginInfo)
        {
            CommonAppVarsAndFunctions.NhomIn = userloginInfo.Departement;
            CommonAppVarsAndFunctions.UserID = txtTaiKhoan.TextValue.Trim();
            CommonAppVarsAndFunctions.UserName = txtTaiKhoan.TextValue.Trim();
            CommonAppVarsAndFunctions.UserPass = txtMatKhau.Text;
            CommonAppVarsAndFunctions.IsAdmin = userloginInfo.IsAdmin;
        }
        private void AssignPrintedHeader(UserInfo userloginInfo)
        {
            var printedHeader =
                _printedFormService.GetPrintedHeaderByDepartement(userloginInfo.Departement);
            if (printedHeader != null)
            {
                CommonAppVarsAndFunctions.TenPhieu = printedHeader.TenPhieuIn;
                CommonAppVarsAndFunctions.TenNguoiKy = printedHeader.ChuKy;
                CommonAppVarsAndFunctions.ChucVu = printedHeader.ChucVu;
                CommonAppVarsAndFunctions.TieuDe1 = printedHeader.TieuDe1;
                CommonAppVarsAndFunctions.TieuDe2 = printedHeader.TieuDe2;
                CommonAppVarsAndFunctions.TieuDe3 = printedHeader.TieuDe3;
                CommonAppVarsAndFunctions.TieuDe4 = printedHeader.TieuDe4;
                CommonAppVarsAndFunctions.TieuDe5 = printedHeader.TieuDe5;
                CommonAppVarsAndFunctions.TieuDe6 = printedHeader.TieuDe6;
                CommonAppVarsAndFunctions.InMau = printedHeader.InMau;
            }
        }
        private bool AssignWorkPlace(string loginUsername)
        {
            var workplaceLst = _systemConfigService.Get_LstInfo_dm_khuvuc_maytinh(Environment.MachineName).Where(x => !string.IsNullOrEmpty(x.Makhuvucchinh));
            if (workplaceLst.FirstOrDefault() != null)
            {
                var workplace = workplaceLst.FirstOrDefault();
                CommonAppVarsAndFunctions.PCWorkPlace = workplace.Makhuvucchinh;
                CommonAppVarsAndFunctions.IDLayLoaiMau = workplace.IDLayLoaiMau;
                CommonAppVarsAndFunctions.XacNhanKhiVaoketQua = workplace.XacNhanVaoKetQua;
                CommonAppVarsAndFunctions.PCWorkPlaceName = workplace.Tenkhuvucchinh;
                var workplacePermission =
                    _authorizationService.GetUserWorkPlace(
                   (CommonAppVarsAndFunctions.IsAdmin ? "admin" : loginUsername),
                    ServiceType.ClsXetNghiem);
                CommonAppVarsAndFunctions.UserWorkPlace = workplacePermission.Select(x => x.Maphanquyen).ToArray();

                return CommonAppVarsAndFunctions.UserWorkPlace.Contains(CommonAppVarsAndFunctions.PCWorkPlace);
            }
            return false;
        }
        private void AssignSystemConfig()
        {
            var systemConfig = _systemConfigService.GetSystemConfigurationDetail();

            CommonAppVarsAndFunctions.sysConfig = systemConfig;
         
            if (systemConfig != null)
            {
                if (!(systemConfig.CustomerID ?? string.Empty).Equals(CommonAppVarsAndFunctions.CustomerID))
                {
                    systemConfig.CustomerID = CommonAppVarsAndFunctions.CustomerID;
                    _systemConfigService.InsertUpdateConfiguationDetail(systemConfig);
                    AssignSystemConfig();
                }
                CommonAppVarsAndFunctions.AutoconfigCapture = systemConfig.ThietBiBatHinhNapLucKhoiDong;
                //Cấu hình của tiếp nhận
                CommonAppVarsAndFunctions.AutoId = systemConfig.IsAutoId;
                //Cấu hình XN
                CommonAppVarsAndFunctions.ValidPrintXn = systemConfig.ClsXetNghiemInTuXacNhan;

                CommonAppVarsAndFunctions.clsXetNghiemDinhDangKetqua = systemConfig.ClsXetNghiemDinhDangKetqua;
                //Cấu hình siêu âm
                CommonAppVarsAndFunctions.CaptureImagePath = systemConfig.ClsSieuAmDuongDanLuuHinhAnh;
                CommonAppVarsAndFunctions.VideoOuptPath = systemConfig.ClsSieuAmDuongDanLuuVideo;
                //Cấu hình nội soi
                CommonAppVarsAndFunctions.CaptureImagePathNs = systemConfig.ClsNoiSoiDuongDanLuuHinhAnh;
                CommonAppVarsAndFunctions.VideoOuptPathNs = systemConfig.ClsNoiSoiDuongDanLuuVideo;
                CommonAppVarsAndFunctions.PreviewCaptureNs = systemConfig.ClsNoiSoiKichCoXemHinh;

                //Cấu hình điện tim
                CommonAppVarsAndFunctions.EcgInsPath = systemConfig.ClsDienTimDuongDanKetQuaMay;
                CommonAppVarsAndFunctions.EcgResultPath = systemConfig.ClsDienTimDuongDanKetQua;
                CommonAppVarsAndFunctions.EcgImageSize = systemConfig.ClsDienTimKichCoKetQua;

            }
            else
            {
                _systemConfigService.InsertUpdateConfiguationDetail(new ConfigurationDetail()
                {
                    CustomerID = CommonAppVarsAndFunctions.CustomerID
                }) ;
                AssignSystemConfig();
            }
        }

        private void AssignPermissionToUserLogin(string loginUsername)
        {
            AssignGroupPermission(loginUsername);

            AssignUserPermissions(loginUsername);
        }
        private List<string> GetlistAllow(List<UserLogInPermission> lst)
        {
            var lstRetur = new List<string>();
            foreach (var item in lst)
            {
                lstRetur.AddRange(item.DanhSachQuyen);
            }
            return lstRetur;
        }
        private void AssignUserPermissions(string loginUsername)
        {
            var dataPreMiss = _authorizationService.DanhSachPhanQuyen(txtTaiKhoan.TextValue);
            var quyenXetNghiem = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase)
            && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase)
              && x.NhomQuyen.Equals("PhanQuyen", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenXetNghiem = (quyenXetNghiem.Any() ? GetlistAllow(quyenXetNghiem.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenXetNghiem);

            var analyzerePermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase)
                && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase)
                && x.NhomQuyen.Equals("MayXetNghiem", StringComparison.OrdinalIgnoreCase)
                );
            CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem = (analyzerePermission.Any() ? GetlistAllow(analyzerePermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem);

            //khu Vực
            var lab = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase)
           && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase)
             && x.NhomQuyen.Equals("KhuVuc", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenKhuVuc = (lab.Any() ? GetlistAllow(lab.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenKhuVuc);
            //Nhóm xét nghiệm
            var testGroup = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase)
            && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase)
             && x.NhomQuyen.Equals("Nhom", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.NhomClsXetNghiem = (testGroup.Any() ? GetlistAllow(testGroup.ToList()).ToArray() : CommonAppVarsAndFunctions.NhomClsXetNghiem);
            //Bộ phận xét nghiệm
            var bophan = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase)
            && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase)
             && x.NhomQuyen.Equals("BoPhan", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.BoPhanClsXetNghiem = (bophan.Any() ? GetlistAllow(bophan.ToList()).ToArray() : CommonAppVarsAndFunctions.BoPhanClsXetNghiem);

            var supersonicPermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenSieuAm = (supersonicPermission.Any() ? GetlistAllow(supersonicPermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenSieuAm);
            var xrayPermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenXQuang = (xrayPermission.Any() ? GetlistAllow(xrayPermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenXQuang);
            var endoscopicPermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenNoiSoi = (endoscopicPermission.Any() ? GetlistAllow(endoscopicPermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenNoiSoi);
            var financePermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.TaiChinh.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenTaiChinhKeToan = (financePermission.Any() ? GetlistAllow(financePermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenTaiChinhKeToan);
            var encliticPermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenKhamBenh = (encliticPermission.Any() ? GetlistAllow(encliticPermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenKhamBenh);

            var receptionPermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.TiepNhan.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenTiepNhan = (receptionPermission.Any() ? GetlistAllow(receptionPermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenTiepNhan);

            var mamangePermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.QuanLy.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenQuanLy = (mamangePermission.Any() ? GetlistAllow(mamangePermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenQuanLy);
            
            var cashierPermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ThuNgan.ToString(), StringComparison.OrdinalIgnoreCase) && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenThuNgan = (cashierPermission.Any() ? GetlistAllow(cashierPermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenThuNgan);

            var biologyPermission = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXNViSinh.ToString(), StringComparison.OrdinalIgnoreCase)
            && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase)
            && x.NhomQuyen.Equals("PhanQuyen", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.PhanQuyenViSinh = (biologyPermission.Any() ? GetlistAllow(biologyPermission.ToList()).ToArray() : CommonAppVarsAndFunctions.PhanQuyenViSinh);

            var biologyGroup = dataPreMiss.Where(x => x.LoaiDichVu.Equals(ServiceType.ClsXNViSinh.ToString(), StringComparison.OrdinalIgnoreCase)
            && x.HeThong.Equals("TPH.LabIMS", StringComparison.OrdinalIgnoreCase)
            && x.NhomQuyen.Equals("Nhom", StringComparison.OrdinalIgnoreCase));
            CommonAppVarsAndFunctions.NhomClsViSinh = (biologyGroup.Any() ? GetlistAllow(biologyGroup.ToList()).ToArray() : CommonAppVarsAndFunctions.NhomClsViSinh);
        }

        private void AssignGroupPermission(string loginUsername)
        {
            CommonAppVarsAndFunctions.PhanQuyenKhuVuc =
              _authorizationService.GetUserWorkPlace(
                    loginUsername, ServiceType.ClsXetNghiem)
                 .Select(x => x.Maphanquyen)
                 .ToArray();

            var testingGroupPermission =
                _authorizationService.GetGroupServicePermissionByLoginUser(
                    loginUsername, ServiceType.ClsXetNghiem);
            CommonAppVarsAndFunctions.NhomClsXetNghiem =
                testingGroupPermission
                    .Select(x => x.Maphanquyen)
                    .ToArray();

            var testingDepartPermission =
             _authorizationService.GetdepartmentPermissionByLoginUser(
                 loginUsername, ServiceType.ClsXetNghiem);
            CommonAppVarsAndFunctions.BoPhanClsXetNghiem =
                testingDepartPermission
                    .Select(x => x.Maphanquyen)
                    .ToArray();

            var supersonicGroupPermission =
                _authorizationService.GetGroupServicePermissionByLoginUser(
                    loginUsername, ServiceType.ClsSieuAm);
            CommonAppVarsAndFunctions.NhomClsSieuAm = supersonicGroupPermission
                    .Select(x => x.Maphanquyen)
                    .ToArray();

            var xRayGroupPermission =
                _authorizationService.GetGroupServicePermissionByLoginUser(
                    loginUsername, ServiceType.ClsXQuang);
            CommonAppVarsAndFunctions.NhomClsxq = xRayGroupPermission
                    .Select(x => x.Maphanquyen)
                    .ToArray();

            var endoscopic =
                _authorizationService.GetGroupServicePermissionByLoginUser(
                    loginUsername, ServiceType.ClsNoiSoi);
            CommonAppVarsAndFunctions.NhomClsNoiSoi = endoscopic
                    .Select(x => x.Maphanquyen)
                    .ToArray();

            var biology =
      _authorizationService.GetGroupServicePermissionByLoginUser(
          loginUsername, ServiceType.ClsXNViSinh);
            CommonAppVarsAndFunctions.NhomClsViSinh = biology
                    .Select(x => x.Maphanquyen)
                    .ToArray();
        }

        private void WriteUserLoginInfoToRegistry()
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryLoginUsername, txtTaiKhoan.TextValue);
            _registryExtension.WriteRegistry(UserConstant.RegistryUserPassword, chkLuuThongTinDangNhap.Checked
                ? TPH.Common.StringCryptography.EnDeCrypt.EncryptString(txtMatKhau.TextValue, AuthorizationConstant.Clinic)
                : string.Empty);
            _registryExtension.WriteRegistry(UserConstant.RegistryIsSavePassword, chkLuuThongTinDangNhap.Checked ? "1" : "0");
            WriteloginLog();
        }
        private void WriteloginLog()
        {
            _iLogService.WriteLog_Login(txtTaiKhoan.TextValue);
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            cboLanguage.SelectedIndex = 0;
            //lblCopyright.Text = MessageConstant.Copyright;
            toolTip1.SetToolTip(btnAboutUs,
                LanguageExtension.GetResourceValueFromKey("Vechungtoi", LanguageExtension.AppLanguage));
            LoginName = LanguageExtension.GetResourceValueFromKey("Tendangnhap", LanguageExtension.AppLanguage);
            Pwd = LanguageExtension.GetResourceValueFromKey("Matkhau", LanguageExtension.AppLanguage);
            txtTaiKhoan.TextValue = LoginName;
            txtMatKhau.TextValue = Pwd;

            var password = _registryExtension.ReadRegistry(UserConstant.RegistryUserPassword);
            password = !string.IsNullOrWhiteSpace(password)
                ? TPH.Common.StringCryptography.EnDeCrypt.DecryptString(password, AuthorizationConstant.Clinic)
                : string.Empty;

            txtTaiKhoan.TextValue = _registryExtension.ReadRegistry(UserConstant.RegistryLoginUsername);
            if (!string.IsNullOrEmpty(password))
            {
                txtMatKhau.PassordChar = true;
                txtMatKhau.TextValue = password;
            }
            chkLuuThongTinDangNhap.Checked =
                !string.IsNullOrWhiteSpace(_registryExtension.ReadRegistry(UserConstant.RegistryIsSavePassword)) &&
                _registryExtension.ReadRegistry(UserConstant.RegistryIsSavePassword).Equals("1");
            var languageIndex = _registryExtension.ReadRegistry(UserConstant.RegistryLoginLanguage);
            if(!string.IsNullOrEmpty(languageIndex))
            {
                cboLanguage.SelectedIndex = int.Parse(languageIndex);
            }
        }

        private void FrmDangNhap_Shown(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTaiKhoan_onTextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMatKhau.Focus();
                e.Handled = true;
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrEmpty(txtTaiKhoan.TextValue) && !string.IsNullOrEmpty(txtMatKhau.TextValue))
                {
                    DoLogin();
                }
            }
        }
        private void splitContainer1_Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitleBar_MouseDown(sender, e);
        }

        private void tphIconButton6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tphPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitleBar_MouseDown(sender, e);
        }

        private void tphPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitleBar_MouseDown(sender, e);
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tphsoft.com.vn");
        }

        private void btnYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCf5IluvNrVKc63HL0FPb7lQ");
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/TPHSolutions");
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            var f = new FrmAboutUs();
            f.ShowDialog();
        }

        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.TextValue.Equals(LoginName, StringComparison.OrdinalIgnoreCase))
            {
                txtTaiKhoan.TextValue = "";
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.TextValue.Equals(Pwd, StringComparison.OrdinalIgnoreCase))
            {
                txtMatKhau.TextValue = "";
                txtMatKhau.PassordChar = true;
                txtMatKhau.PasswordChar = '●';
            }
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTaiKhoan.TextValue == "")
                txtTaiKhoan.TextValue = LoginName;

        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.TextValue == "")
            {
                //this.txtMatKhau.Font = new System.Drawing.Font("Arial", 12F);
                txtMatKhau.PassordChar = false;
                txtMatKhau.PasswordChar = '\0';
                txtMatKhau.TextValue = Pwd;

            }
        }

        private void tphPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tphPictureBoxRetangle1_Click(object sender, EventArgs e)
        {

        }
    }
}
