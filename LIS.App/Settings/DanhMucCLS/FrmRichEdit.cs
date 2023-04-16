using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmRichEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmRichEdit()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRichEdit_Load(object sender, EventArgs e)
        {
         
        }
        private void FrmRichEdit_Shown(object sender, EventArgs e)
        {
        }
    }
}
