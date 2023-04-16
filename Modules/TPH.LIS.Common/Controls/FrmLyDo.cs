using System;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class FrmLyDo : Form
    {
        public FrmLyDo()
        {
            InitializeComponent();
        }
        public string NoiDung = string.Empty;
        public bool Multiline = false;
        private void txtLyDo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== (char)Keys.Enter)
            {
                if(!string.IsNullOrEmpty(txtLyDo.Text))
                {
                    SetnoiDungVaDong();
                }
            }
        }
        private void SetnoiDungVaDong()
        {
            NoiDung = txtLyDo.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLyDo.Text))
            {
                SetnoiDungVaDong();
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập lý do!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLyDo_Load(object sender, EventArgs e)
        {
            if (Multiline)
            {
                txtLyDo.Multiline = true;
                this.Height += (txtLyDo.Height * 2);
                txtLyDo.Height = txtLyDo.Height * 3;
            }
        }

        private void txtLyDo_KeyUp(object sender, KeyEventArgs e)
        {
            lblKyTu.Text = string.Format("{0}/{1} ký tự", txtLyDo.Text.Length, txtLyDo.MaxLength);
        }
    }
}
