using System;
using System.Windows.Forms;
using TPH.Authorization;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.Common.StringCryptography;
using TPH.Common.Contants;
using TPH.Language;

namespace TPH.LIS.App
{
    public partial class FrmAboutUs : Form
    {
        public FrmAboutUs()
        {
            InitializeComponent();
            lblMsg.Text = "Sản phẩm được phát triển bởi TPH Solutions";
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tphsoft.com.vn");
        }
    }
}
