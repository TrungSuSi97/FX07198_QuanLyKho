using System;
using System.Windows.Forms;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmWarningMessage : Form
    {
        public FrmWarningMessage()
        {
            InitializeComponent();
        }
        public string NoiDung { get; set; }

        private void FrmWarningMessage_Load(object sender, EventArgs e)
        {
            lblNoiDung.Text = NoiDung;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWarningMessage_Shown(object sender, EventArgs e)
        {
            btnClose.Focus();
        }

        private void FrmWarningMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
