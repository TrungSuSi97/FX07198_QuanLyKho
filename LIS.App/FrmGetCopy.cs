using System;
using System.Windows.Forms;

namespace TPH.LIS.App
{
    public partial class FrmGetCopy : Form
    {
        public FrmGetCopy()
        {
            InitializeComponent();
        }
        public string copyFrom = string.Empty;
        public string copyTo = string.Empty;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCopyFrom.Text) && !string.IsNullOrEmpty(txtCopyTo.Text))
            {
                copyFrom = txtCopyFrom.Text.Trim();
                copyTo = txtCopyTo.Text;
                this.Close();
            }
            else
                MessageBox.Show("Hãy nhập đủ thông tin nguồn và đích đến để copy.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
