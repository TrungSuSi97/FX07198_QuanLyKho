using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace UploadKetQua_HIS
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int limit = 5;
            // Get Reference to the current Process
            Process thisProc = Process.GetCurrentProcess();
            if (Process.GetProcessesByName(thisProc.ProcessName).Length > limit)
            {
                // Check how many total processes have the same name as the current one
                // If ther is more than one, than it is already running.
                MessageBox.Show(string.Format("Ứng dụng đang chạy hơn {0} ứng dụng!\nCó thể tìm dưới System Tray", limit));
                Application.Exit();
            }
            else
            {
                System.Globalization.CultureInfo cultureInfo =
                new System.Globalization.CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmUploadKEtQua { runnningCount = Process.GetProcessesByName(thisProc.ProcessName).Length });
            }
        }

        private static bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.ToLower().Contains(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
    
