using System;
using System.Windows.Forms;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmNhapID : FrmTemplate
    {
        public FrmNhapID()
        {
            InitializeComponent();
        }
        public string Result = string.Empty;
        public string MessTitle = string.Empty;
        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                Result = txtID.Text;
                this.Close();
            }
            else
                MessageBox.Show("Hãy nhập giá trị!");
        }

        private void FrmNhapID_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MessTitle))
            {
                lblTitle.Text = MessTitle;
                this.Text = MessTitle;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNhapID_Shown(object sender, EventArgs e)
        {
            txtID.Focus();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(!string.IsNullOrEmpty(txtID.Text))
                {
                    Result = txtID.Text;
                    e.Handled = true;
                    this.Close();
                }
            }
        }
    }
}
