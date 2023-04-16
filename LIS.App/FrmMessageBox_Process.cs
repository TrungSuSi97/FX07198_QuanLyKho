using System;
using System.Windows.Forms;
using TPH.LIS.Common;

namespace TPH.LIS.App
{
    public partial class FrmMessageBox_Process : Form
    {
        public FrmMessageBox_Process()
        {
            InitializeComponent();
        }
        public string Msg
        {
            get;
            set;
        }

        public string FormCaption
        {
            get;
            set;
        }

        public int Max
        {
            get;
            set;
        }

        DateTime _dtenable = DateTime.Now;

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            _dtenable = DateTime.Now;
            lblMsg.Text = Msg;
            this.Text = string.IsNullOrWhiteSpace(FormCaption) ? 
                MessageConstant.ClinicManagement : 
                FormCaption;
            proBar.Maximum = Max;
        }

        public void Perform()
        {
            proBar.PerformStep();
        }

        public void Perform_Percent(string working)
        {
            proBar.PerformStep();
            lblStepWorking.Text = working;
            var percent = (int)(((double)proBar.Value / (double)proBar.Maximum) * 100);
            lblPercent.Text = string.Format("{0}%", percent);
            timer1_Tick();
            this.Refresh();
        }

        public void PerFormDoing(string textdo)
        {
            if (!string.IsNullOrWhiteSpace(textdo))
                lblDoing.Text = textdo;
        }

        public void SetVisible(bool st)
        {
            lblDoing.Visible = st;
            proBar.Visible = st;
            lblPercent.Visible = st;
            lblStepWorking.Visible = st;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimumsize_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
                this.TopMost = false;
            this.WindowState = FormWindowState.Minimized;
        }

        public void _isErr(string errDescription)
        {
            btnOK.Visible = true;
            lblMsg.Text = errDescription;
            proBar.Visible = false;
            lblPercent.Visible = false;
        }

        private void timer1_Tick()
        {
            TimeSpan ts = DateTime.Now - _dtenable;
            lblTime.Text = string.Format("{0} : {1}", ts.Minutes, ts.Seconds);
            this.Refresh();
        }

        private void FrmMessageBox_Process_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FrmMessageBox_Process_Shown(object sender, EventArgs e)
        {
           
        }
    }
}