using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.StringCryptography;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmPasswordActiveModule : Form
    {
        public FrmPasswordActiveModule()
        {
            InitializeComponent();
        }
       public bool Accept = false;
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtPassword.Text.Equals(EnDeCrypt.DecryptString("7/Af26BH7t1ueOn8iIOexg==")))
                {
                    Accept = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng!");
                    this.Close();
                }
            }
        }
    }
}
