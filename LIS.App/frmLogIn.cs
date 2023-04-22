using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
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
    public partial class frmLogIn : Form
    {
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly IAuthorizationService _authorizationService = new AuthorizationService();
        private readonly IUserManagementService _userManagementService = new UserManagementService();
        private readonly IPrintedFormService _printedFormService = new PrintedFormService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly IServiceSettingService _serviceSettingService = new ServiceSettingService();
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        public frmLogIn()
        {
            InitializeComponent();
        }
        Image img;
        private void btnExit_Click(object sender, EventArgs e)
        {
            //var fm = (frmMDIParent)this.TopLevelControl;
            //fm.SetCloseProgram(true);
            this.Close();
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            DoLogin();
        }
        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtPassword);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtUserID.Text) &&
                    !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    DoLogin();
                }
            }
        }

        private void txtUserID_Enter(object sender, EventArgs e)
        {
            txtUserID.SelectAll();
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            //if (File.Exists(@"Background\Background.jpg"))
            //{
            //    using (var bmpTemp = new Bitmap(@"Background\Background.jpg"))
            //    {
            //        img = new Bitmap(bmpTemp);
            //    }
            //}

        }

        private void frmLogIn_Shown(object sender, EventArgs e)
        {
            //if (img != null)
            //{
            //    this.BackgroundImageLayout = ImageLayout.Stretch;
            //    this.BackgroundImage = img;
            //}


            //MessageBox.Show("Login load");
            CheckAutoLogin();

            var password = _registryExtension.ReadRegistry(UserConstant.RegistryUserPassword);
            password = !string.IsNullOrWhiteSpace(password)
                ? TPH.Common.StringCryptography.EnDeCrypt.DecryptString(password, AuthorizationConstant.Clinic)
                : string.Empty;

            txtUserID.Text = _registryExtension.ReadRegistry(UserConstant.RegistryLoginUsername);
            txtPassword.Text = password;
            chkSave.Checked =
                !string.IsNullOrWhiteSpace(_registryExtension.ReadRegistry(UserConstant.RegistryIsSavePassword)) &&
                _registryExtension.ReadRegistry(UserConstant.RegistryIsSavePassword).Equals("1");
            pnLogin.Visible = true;
            if (!string.IsNullOrEmpty(txtUserID.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                btnLogIn.Focus();
            }
        }

        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BackgroundImage = null;
        }

        private void Load_FileInRunningFolderInfomation()
        {
            DataTable DataFileList = new DataTable("ListInformationOfFile");
            DataFileList.Columns.Add("FileName", typeof(string));
            DataFileList.Columns.Add("FileVerion", typeof(string));
            DataFileList.Columns.Add("IsReadonly", typeof(bool));
            DataFileList.Columns.Add("Attributes", typeof(string));
            DataFileList.Columns.Add("FileModifiedDate", typeof(DateTime));
            DataFileList.Columns.Add("FileCreatedDate", typeof(DateTime));
            DataFileList.Columns.Add("FileModifiedDateUTC", typeof(DateTime));
            DataFileList.Columns.Add("FileCreatedDateUTC", typeof(DateTime));
            DataFileList.Columns.Add("FileFullName", typeof(string));

            var dirInfo = new DirectoryInfo(Environment.CurrentDirectory);
            foreach (FileInfo fi in dirInfo.GetFiles())
            {
                DataRow dr = DataFileList.NewRow();
                dr["FileFullName"] = fi.FullName;
                dr["FileName"] = string.Format("{0}.{1}", fi.Name, fi.Extension);
                dr["Attributes"] = fi.Attributes.ToString();
                dr["FileVerion"] = FileVersionInfo.GetVersionInfo(fi.FullName).FileVersion;
                dr["FileModifiedDateUTC"] = fi.LastWriteTimeUtc;
                dr["FileCreatedDateUTC"] = fi.CreationTimeUtc;
                dr["FileModifiedDate"] = fi.LastWriteTime;
                dr["FileCreatedDate"] = fi.CreationTime;
                dr["IsReadonly"] = fi.IsReadOnly;
                DataFileList.Rows.Add(dr);
            }
            string result;
            using (StringWriter sw = new StringWriter())
            {
                DataFileList.WriteXml(sw);
                result = sw.ToString();
            }
            _systemConfigService.Update_PcLogin_FileInfo(Environment.MachineName, result);
        }
        private void AssignUserLoginInfoToMainForm(UserInfo userloginInfo)
        {
            CommonAppVarsAndFunctions.NhomIn = userloginInfo.Departement;
            CommonAppVarsAndFunctions.UserID = txtUserID.Text.Trim();
            CommonAppVarsAndFunctions.UserName = userloginInfo.Username;
            CommonAppVarsAndFunctions.UserPass = txtPassword.Text;
            CommonAppVarsAndFunctions.IsAdmin = userloginInfo.IsAdmin;
            CommonAppVarsAndFunctions.MaNhomNhanVien = userloginInfo.MaNhomNhanVien;
            CommonAppVarsAndFunctions.TenNhomNhanVien = userloginInfo.TenNhomNhanVien;
            CommonAppVarsAndFunctions.MaBoPhan = userloginInfo.MaBoPhan;
            CommonAppVarsAndFunctions.TenBoPhan = userloginInfo.TenBoPhan;

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
            var workplaceLst = _systemConfigService.Get_LstInfo_dm_khuvuc_maytinh(string.Empty, string.Empty, Environment.MachineName).Where(x => !string.IsNullOrEmpty(x.Makhuvucchinh));
            if (workplaceLst.FirstOrDefault() != null)
            {
                var workplace = workplaceLst.FirstOrDefault();
                CommonAppVarsAndFunctions.PCWorkPlace = workplace.Makhuvucchinh;
                CommonAppVarsAndFunctions.IDLayLoaiMau = workplace.IDLayLoaiMau;
                CommonAppVarsAndFunctions.XacNhanKhiVaoketQua = workplace.XacNhanVaoKetQua;
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
                _systemConfigService.InsertUpdateConfiguationDetail(new ConfigurationDetail());
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
            var dataPreMiss = _authorizationService.DanhSachPhanQuyen(txtUserID.Text);
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
            _registryExtension.WriteRegistry(UserConstant.RegistryLoginUsername, txtUserID.Text);
            _registryExtension.WriteRegistry(UserConstant.RegistryUserPassword, chkSave.Checked
                ? TPH.Common.StringCryptography.EnDeCrypt.EncryptString(txtPassword.Text, AuthorizationConstant.Clinic)
                : string.Empty);
            _registryExtension.WriteRegistry(UserConstant.RegistryIsSavePassword, chkSave.Checked == true ? "1" : "0");
          //  if (!txtUserID.Text.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) && !txtUserID.Text.Trim().Equals("tph", StringComparison.OrdinalIgnoreCase))
                WriteloginLog();
        }
        private void WriteloginLog()
        {
            _iLogService.WriteLog_Login(txtUserID.Text);
        }

        private void DoLogin()
        {
            //var isValid = _authorizationService.CheckLogin(txtUserID.Text, txtPassword.Text);
            var isValid = _authorizationService.CheckLogin(new LoginParams()
            {
                Username = txtUserID.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Ip = IpExtension.Ip(),
                System = CommonConstant.ApplicationName
            });

            if (!isValid)
            {
                CustomMessageBox.MSG_Waring_OK(UserErrorConstant.WrongLoginuserOrPassword);
                return;
            }

            var userloginInfo = _userManagementService.GetUserInfoByLoginName(txtUserID.Text);

            if (AssignWorkPlace(userloginInfo.IsAdmin ? "admin" : txtUserID.Text.Trim()))
            {
                AssignUserLoginInfoToMainForm(userloginInfo);
                AssignPrintedHeader(userloginInfo);
                AssignSystemConfig();
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
                //   Load_FileInRunningFolderInfomation();

                var frm = new FrmStartUp();
                var fm = (frmMDIParent)this.TopLevelControl;
                fm.Check_EnableControl(txtUserID.Text.Trim());
                fm.lblHello.Text = string.Format("{0}:", CommonConstant.Hello);
                fm.lblUserName.Text = string.IsNullOrEmpty(userloginInfo.Username) ?
                    userloginInfo.LoginName :
                    string.Format("{0} - ID: {1}", userloginInfo.Username, userloginInfo.LoginName);
                //fm.Start_StopAlarm(true);
                fm.ShowForm(frm);

                try
                {
                    this.Close();
                }
                catch
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
            }
            else if (userloginInfo.IsAdmin && string.IsNullOrEmpty(CommonAppVarsAndFunctions.PCWorkPlace))
            {
                CustomMessageBox.MSG_Information_OK("Máy tính chưa khai báo khu vực làm việc!");
                var f = new Settings.HeThong.FrmCauHinh_KhuVuc();
                f.pnMenu.Visible = true;
                f.AdjustForm();
                f.ShowDialog();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Máy tính chưa khai báo khu vực làm việc.\nHoặc tài khoản không được cấp quyền trong khu vực này.");
                Application.Exit();
            }
        }
        private void CheckAutoLogin()
        {
            if (!string.IsNullOrWhiteSpace(CommonAppVarsAndFunctions.LoginArguments))
            {
                string[] loginParams = CommonAppVarsAndFunctions.LoginArguments.Split(new string[] { "|||" }, StringSplitOptions.None);

                if (loginParams.Length == 2)
                {
                    txtUserID.Text = StringConverter.ToString(loginParams[0]).Trim();
                    txtPassword.Text = StringConverter.ToString(loginParams[1]).Trim();
                    btnLogIn.PerformClick();
                }
            }
        }

        private void txtUserID_Click(object sender, EventArgs e)
        {
            txtUserID.SelectAll();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }
    }
}