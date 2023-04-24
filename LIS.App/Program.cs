using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Common.StringCryptography;
using TPH.Language;
using TPH.LIS.Common;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App
{
    static class Program
    {

        private static ISystemConfigService _systemService = new SystemConfigService();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main(string[] args)
        //{
        //    SetProcessDPIAware();

        //    LanguageExtension.AppLanguage = Configurations.AppSettings.AppLanguage;
        //    LanguageExtension.LocalizedLanguage = !LanguageExtension.AppLanguage.Equals(Configurations.AppSettings.DefaultLanguageKey);
        //    SetCulture();
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //   // DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Arial", 9);
        //    var computerName = TPHSerialKeys.GetComputerName();
        //    var applicationId = TPHSerialKeys.GetApplicationId();
        //    var applicationName = TPHSerialKeys.GetApplicationName();
        //    var serial = TPHSerialKeys.GetSerial();
        //    CommonAppVarsAndFunctions.License.Serial = serial;

        //    var validResult = _systemService.ValidSerial(computerName, applicationId, applicationName, CommonAppVarsAndFunctions.License.Serial);
        //    CommonAppVarsAndFunctions.License.PcName = validResult.Name;
        //    if (string.IsNullOrEmpty(validResult.Name))
        //        CommonAppVarsAndFunctions.License.PcName = computerName;
        //    if (args != null && args.Length > 0)
        //    {
        //        CommonAppVarsAndFunctions.LoginArguments = StringConverter.ToString(args[0]).Trim();
        //    }
        //    var langConstant = new MessageConstant();
        //    if (validResult.Id == ErrorConstant.ErrorCode0)
        //    {
        //        StartApplication();
        //    }
        //    else
        //    {
        //        if (_systemService.InsertSerialKey(computerName, applicationName, CommonAppVarsAndFunctions.License.Serial))
        //        {
        //            using (var frm = new FrmRegistryLicenseKey())
        //            {
        //                if (frm.ShowDialog() == DialogResult.OK)
        //                {
        //                    StartApplication();
        //                }
        //                else
        //                {

        //                    MessageBox.Show(langConstant.UngDungChuaDangKy, CommonConstant.ApplicationName);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show(langConstant.KhongtheketnoimaychuVuilongkiemtralaiketnoimang,
        //                CommonConstant.ApplicationName);
        //        }
        //    }
        //}

        [STAThread]
        static void Main(string[] args)
        {
            SetCulture();
            Application.EnableVisualStyles();
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Arial", 9);
            Application.SetCompatibleTextRenderingDefault(false);

            var computerName = TPHSerialKeys.GetComputerName();
            var applicationId = TPHSerialKeys.GetApplicationId();
            var applicationName = TPHSerialKeys.GetApplicationName();
            var serial = TPHSerialKeys.GetSerial();
            //frmMDIParent.License.Serial = serial;

            Run();
        }
        private static void SetCulture()
        {
            // Creating a Global culture specific to our application.
            System.Globalization.CultureInfo cultureInfo =
                new System.Globalization.CultureInfo("en-US");
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
        private static void StartApplication()
        {
            CommonAppVarsAndFunctions.License.HasLicense = false;
            var applicationName = TPHSerialKeys.GetApplicationName();
            CommonAppVarsAndFunctions.License = _systemService.ValidLicense(CommonAppVarsAndFunctions.License.PcName, applicationName, CommonAppVarsAndFunctions.License.Serial);
            if (CommonAppVarsAndFunctions.License.HasLicense)
            {
                CommonAppVarsAndFunctions.License.CustomerId = applicationName.Split('.')[2];
                CommonAppVarsAndFunctions.CustomerID = CommonAppVarsAndFunctions.License.CustomerId;
                RunApplication();
            }
            else
            {
                CheckLicense();
            }
        }

        private static void Run()
        {
            //var logIn = new FrmDangNhap();
            //logIn.ShowDialog();
            //if (logIn.DialogResult == DialogResult.OK)
            //{
            //    var f = new frmParent_old
            //    {
            //        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F),
            //        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            //    };
            //    Application.Run(f);
            //}
            //else
            //{
            //    Application.Exit();
            //}


            //DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
            //DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Blue");
            //DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2013 Light Gray");
            //DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            // DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = DevExpress.XtraEditors.ScrollUIMode.Touch;
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Arial", 9F);
            DevExpress.XtraBars.Ribbon.RibbonControl.AllowSystemShortcuts = false;

            Application.EnableVisualStyles();
            Application.Run(new frmMDIParent());
        }

        private static void RunApplication()
        {
            //DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
            //DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
            //DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2013 Light Gray");
            //DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            // DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = DevExpress.XtraEditors.ScrollUIMode.Touch;
            //DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Arial", 9.5F);
            // DevExpress.XtraBars.Ribbon.RibbonControl.AllowSystemShortcuts = false;

            Application.EnableVisualStyles();
            var fileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            var appName = new FileInfo(Application.ExecutablePath).Name.Replace(new FileInfo(Application.ExecutablePath).Extension, "");

            var checkUpdateFlat = _systemService.Check_UpdateSoftware(Environment.MachineName, fileVersion, appName);
            if (checkUpdateFlat > 0)
            {
                CommonAppVarsAndFunctions.Check_ShowUpdateSoftWare(true);
            }
            else
            {

                var logIn = new FrmDangNhap();
                logIn.ShowDialog();
                if (logIn.DialogResult == DialogResult.OK)
                {
                    var f = new frmParent_old
                    {
                        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F),
                        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
                    };
                    Application.Run(f);
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        private static void CheckLicense()
        {
            using (var frm = new FrmRegistryLicenseKey())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CommonAppVarsAndFunctions.License.ChangeLicense = false;

                    RunApplication();
                }
            }
        }

    }
}
