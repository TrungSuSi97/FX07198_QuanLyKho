using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;

namespace TPH.LabIMS.Updater
{
    public partial class FrmDownloadUpdate : Form
    {
        public FrmDownloadUpdate()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //if (CustomMessageBox.MSG_Question_YesNo_GetYes("Thực hiện cập nhật ứng dụng?"))
            //{
                lblThuMuc.Visible = true;
                lblFile.Visible = true;
                lblThuMuc.Refresh();
                lblFile.Refresh();

                string updateTimeString = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                var icount = ActionFileWithDatabase.DownloadUpdate(updateTimeString, lblFolderStatus, lblFileStatus);
                if (icount > 0)
                {
                        Check_RemindeRunningApp();
                }
            //}
        }
        private void Check_RemindeRunningApp()
        {
            string AppNamelist = ActionFileWithDatabase.AppName;
            var runningApp = IsProcessOpen(AppNamelist.ToLower());
            if (string.IsNullOrEmpty(runningApp))
            {
                ActionFileWithDatabase.Update_FinishUpdate();
                var proc = new Process();
                proc.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                proc.StartInfo.FileName = "FinalUpdate.bat";
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                Application.Exit();
            }
            else
            {
                var result = CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Hãy đóng tất cả ứng dụng:\n{0} \ntrước khi tiếp tục!", runningApp));
                if (result)
                {
                    Check_RemindeRunningApp();
                }
                else
                    Application.Exit();
            }
        }

        public string IsProcessOpen(string AppNamelist)
        {
            string appRunning = string.Empty;
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (AppNamelist.Contains(clsProcess.ProcessName.ToLower()))
                {
                    if (clsProcess.StartInfo.WorkingDirectory == Environment.CurrentDirectory)
                    {
                        appRunning += (string.IsNullOrEmpty(appRunning) ? "" : " | ") + clsProcess.ProcessName;
                    }
                }
            }
            return appRunning;
        }

        private void FrmDownloadUpdate_Shown(object sender, EventArgs e)
        {
            lblThuMuc.Visible = true;
            lblFile.Visible = true;
            this.Refresh();

            this.Text = this.Text + " - " + ActionFileWithDatabase.AppName;
            string updateTimeString = DateTime.Now.ToString("ddMMyyyy_HHmmss");
            var icount = ActionFileWithDatabase.DownloadUpdate(updateTimeString, lblFolderStatus, lblFileStatus);
            if (icount > 0)
            {
                Check_RemindeRunningApp();
            }
        }

        private void FrmDownloadUpdate_Load(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(IsProcessOpen(string.Format("TPH.{0}.Updater", ActionFileWithDatabase.AppName.Replace("TPH.","").Replace(".exe","")))))
            {
                Application.Exit();
            }
        }
    }
}
