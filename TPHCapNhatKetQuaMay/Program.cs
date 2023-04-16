using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace TPHCapNhatKetQuaMay
{
    static class Program
    {
       static int count = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            // Get Reference to the current Process
            if (NotCheckAllowRun())
            {
                // Check how many total processes have the same name as the current one
                // If ther is more than one, than it is already running.
                if (count > 1)
                {
                    MessageBox.Show("Ứng dụng đang chạy!\nCó thể tìm dưới System Tray");
                    Application.Exit();
                }
                else
                {
                    count++;
                    System.Threading.Thread.Sleep(2500);
                    Main();
                }
            }
            else
            {
                StartApp();
            }

        }
        private static void StartApp()
        {
            System.Globalization.CultureInfo cultureInfo =
                 new System.Globalization.CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAnalyerResult());
        }
        private static bool NotCheckAllowRun()
        {
            // Get Reference to the current Process
            Process thisProc = Process.GetCurrentProcess();
          return  Process.GetProcessesByName(thisProc.ProcessName).Length > 1;
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
