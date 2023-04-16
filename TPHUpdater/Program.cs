using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.LabIMS.Updater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ActionFileWithDatabase.AppName = "TPH.LabIMS";
            if (args != null && args.Length > 0)
            {
                if (args[0] == "1")
                    Application.Run(new FrmDownloadUpdate());
            }
            else
            {
                var f = new FrmLogin();
                f.ShowDialog();
                if (f.Accept)
                    Application.Run(new frmChonFile());
                else
                    Application.Exit();
            }
        }
    }
}
