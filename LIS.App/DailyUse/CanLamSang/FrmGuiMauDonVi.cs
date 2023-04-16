using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmGuiMauDonVi : FrmTemplate
    {
        public FrmGuiMauDonVi()
        {
            InitializeComponent();
        }

        private void FrmGuiMauDonVi_Load(object sender, EventArgs e)
        {
            ucGuiMauXetNghiem1.Load_CauHinh();
        }
    }
}
