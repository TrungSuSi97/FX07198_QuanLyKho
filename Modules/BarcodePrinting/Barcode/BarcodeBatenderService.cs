using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using TPH.LIS.BarcodePrinting.Configurations;
using Seagull.BarTender.Print;
using System.Diagnostics;
using System.Windows.Forms;

namespace TPH.LIS.BarcodePrinting.Barcode
{

    public class BarcodeBatenderService
    {
        private static System.Windows.Forms.Timer tm;
        private static Engine btnEng;
        private static BarTender.Application btApp;
      
        private static BarTender.Messages btMsgs;
        private static bool tmRunning = false;
        private static DateTime LastOpenDate = DateTime.Now;
        public static string Print(BarcodeProperties info, int cout = 0)
        {
            try
            {
                var messError = string.Empty;
                if (btApp == null)
                    OpenBartender();
                if (string.IsNullOrEmpty(messError))
                {
                    var btFormat = new BarTender.Format();
                    string fileparth = info.PrintFilePath;
                    if (info.LoaiTem == Constants.Loaibarcode.EnumLoaiBarcode.KhamSucKhoe)
                    {
                        fileparth = System.IO.Path.GetFullPath(@"Barcode\TPH.Lab.BarcodeKSK.btw");
                        btFormat = btApp.Formats.Open(fileparth, false, "");
                        foreach (var item in info.DanhSachTube)
                        {
                            btFormat.SetNamedSubStringValue("Barcode", item.Barcode);
                            btFormat.SetNamedSubStringValue("BarcodeLabel", info.TenBarcode);
                            btFormat.PrintSetup.IdenticalCopiesOfLabel = item.TubeCount;
                            btFormat.PrintOut(true, false);
                        }
                    }
                    else
                    {
                        fileparth = System.IO.Path.GetFullPath(string.Format(@"Barcode\{0}", AppSettings.BarcodeName));
                        btFormat = btApp.Formats.Open(fileparth, false, "");
                        btFormat.SetNamedSubStringValue("OrderLocationID", info.MaKhoaPhong ?? "");
                        btFormat.SetNamedSubStringValue("NameLabel", info.PatientName);
                        btFormat.SetNamedSubStringValue("DateIn", info.NgayTiepNhan.ToString("dd/MM/yy"));
                        btFormat.SetNamedSubStringValue("PatientID", info.SoPhieuChiDinh);
                        if (info.GioiTinh.Equals("nữ", StringComparison.OrdinalIgnoreCase))
                            info.GioiTinh = "F";
                        else if (info.GioiTinh.Equals("nam", StringComparison.OrdinalIgnoreCase))
                            info.GioiTinh = "M";
                        else if (info.GioiTinh.Equals("?"))
                            info.GioiTinh = "";
                        var age = string.Empty;

                        if (!string.IsNullOrEmpty(info.GioiTinh))
                            age = string.Format("{0}.{1}", info.GioiTinh, info.NamSinh);
                        btFormat.SetNamedSubStringValue("Age", age);
                        if (info.PrinterProtocol == PrintingSystemProtocolList.TIEUCHUAN2)
                        {
                            int needSubtract = 0;
                            for (int i = 0; i < info.DanhSachTube.Count; i++)
                            {
                                int countDescentding = info.DanhSachTube[i].TubeCount;
                                if (countDescentding - needSubtract > 0)
                                {
                                    countDescentding = countDescentding - needSubtract;
                                    needSubtract = 0;
                                }
                                else
                                {
                                    needSubtract = 0;
                                    continue;
                                }

                                btFormat.SetNamedSubStringValue("Barcode", info.DanhSachTube[i].Barcode);
                                btFormat.SetNamedSubStringValue("BarcodeLabel", info.TenBarcode);
                                btFormat.SetNamedSubStringValue("TubeName", info.DanhSachTube[i].Tubename);
                                btFormat.SetNamedSubStringValue("LaboDepartmentID", info.DanhSachTube[i].BoPhanXetNghiem);
                                btFormat.SetNamedSubStringValue("LaboGroupID", info.DanhSachTube[i].NhomXetNghiem);
                                needSubtract = 1;
                                if (countDescentding == 1 && (i + 1) < info.DanhSachTube.Count)
                                {
                                    btFormat.SetNamedSubStringValue("Barcode2", info.DanhSachTube[i + 1].Barcode);
                                    btFormat.SetNamedSubStringValue("BarcodeLabel2", info.TenBarcode);
                                    btFormat.SetNamedSubStringValue("TubeName2", info.DanhSachTube[i + 1].Tubename);
                                    btFormat.SetNamedSubStringValue("LaboDepartmentID2", info.DanhSachTube[i + 1].BoPhanXetNghiem);
                                    btFormat.SetNamedSubStringValue("LaboGroupID2", info.DanhSachTube[i + 1].NhomXetNghiem);
                                    needSubtract = 1;
                                }
                                else
                                {
                                    btFormat.SetNamedSubStringValue("Barcode2", info.DanhSachTube[i].Barcode);
                                    btFormat.SetNamedSubStringValue("BarcodeLabel2", info.TenBarcode);
                                    btFormat.SetNamedSubStringValue("TubeName2", info.DanhSachTube[i].Tubename);
                                    btFormat.SetNamedSubStringValue("LaboDepartmentID2", info.DanhSachTube[i].BoPhanXetNghiem);
                                    btFormat.SetNamedSubStringValue("LaboGroupID2", info.DanhSachTube[i].NhomXetNghiem);
                                    if (countDescentding > 2)
                                    {
                                        needSubtract++;
                                        i--;
                                    }
                                    else
                                        needSubtract = 0;
                                }

                                btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
                                btFormat.PrintOut(true, false);
                            }
                        }
                        else
                        {
                            foreach (var item in info.DanhSachTube)
                            {
                                btFormat.SetNamedSubStringValue("Barcode", item.Barcode);
                                btFormat.SetNamedSubStringValue("BarcodeLabel", info.TenBarcode);
                                btFormat.SetNamedSubStringValue("TubeName", item.Tubename);
                                btFormat.SetNamedSubStringValue("LaboDepartmentID", item.BoPhanXetNghiem);
                                btFormat.SetNamedSubStringValue("LaboGroupID", item.NhomXetNghiem);

                                btFormat.SetNamedSubStringValue("Barcode2", item.Barcode);
                                btFormat.SetNamedSubStringValue("BarcodeLabel2", info.TenBarcode);
                                btFormat.SetNamedSubStringValue("TubeName2", item.Tubename);
                                btFormat.SetNamedSubStringValue("LaboDepartmentID2", item.BoPhanXetNghiem);
                                btFormat.SetNamedSubStringValue("LaboGroupID2", item.NhomXetNghiem);

                                btFormat.PrintSetup.IdenticalCopiesOfLabel = item.TubeCount;
                                btFormat.PrintOut(true, false);
                            }
                        }
                    }
                    btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
                }
                else
                    return messError;
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("The RPC server is unavailable") || cout == 0)
                {
                    CloseBartender();
                    OpenBartender();
                    return Print(info, 1);
                }
                else
                {
                    WriteLog.LogService.RecordLogError("Printbarcode", "BartenderPrint", ex, 0, ex.Message, "Print");
                    return ex.Message;
                }
            }
            return string.Empty;
        }
        public static string OpenBartender(bool forceCloseApp = false)
        {
            try
            {
                if (forceCloseApp)
                    KillAllBartender();

                if (IsSoftwareInstalled("BarTender", null))
                {
                    if (LastOpenDate.Date != DateTime.Now.Date && btApp != null)
                    {
                        CloseBartender();
                    }
                    if (btApp == null)
                    {
                        LastOpenDate = DateTime.Now;
                        btApp = new BarTender.Application();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
        private static void KillAllBartender()
        {
            var allProc = Process.GetProcesses();
            foreach (Process Proc in Process.GetProcesses())
            {
                if (Proc.ProcessName.Equals("bartend"))
                {
                    if (string.IsNullOrEmpty(Proc.MainWindowTitle))
                        Proc.Kill();
                    else
                    {
                        MessageBox.Show("Ứng dụng bartender đang mở.\nHãy đảm bảo đã lưu lại thông tin cấu hình trước khi chạy ứng dụng!\nNhấn \"OK\" để tiếp tục ", "Barcode service", MessageBoxButtons.OK);
                    }
                }
            }
        }
        private static bool IsSoftwareInstalled(string applicationName, ProgramVersion? programVersion)
        {
            string[] registryKey = new[] {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

            return registryKey.Any(key => CheckApplication(key, applicationName, programVersion));
        }
        public enum ProgramVersion
        {
            x86,
            x64
        }

        private static IEnumerable<string> GetRegisterSubkeys(RegistryKey registryKey)
        {
            return registryKey.GetSubKeyNames()
                    .Select(registryKey.OpenSubKey)
                    .Select(subkey => subkey.GetValue("DisplayName") as string);
        }

        private static bool CheckNode(RegistryKey registryKey, string applicationName, ProgramVersion? programVersion)
        {
            return GetRegisterSubkeys(registryKey).Any(displayName => displayName != null
                                                                      && displayName.Contains(applicationName));
        }

        private static bool CheckApplication(string registryKey, string applicationName, ProgramVersion? programVersion)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);

            if (key != null)
            {
                if (CheckNode(key, applicationName, programVersion))
                    return true;

                key.Close();
            }

            return false;
        }

        public static string CloseBartender()
        {
            if (btApp != null)
            {
                try
                {
                    btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return string.Empty;
            }
            return string.Empty;
        }
    }
}
