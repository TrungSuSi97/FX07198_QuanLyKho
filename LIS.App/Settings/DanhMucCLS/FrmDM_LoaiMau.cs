using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmDM_LoaiMau : FrmTemplate
    {
        public FrmDM_LoaiMau()
        {
            InitializeComponent();
        }

        private void FrmDM_LoaiMau_Load(object sender, EventArgs e)
        {
            ucLoaiMau1.UserId = CommonAppVarsAndFunctions.UserID;
            ucLoaiMau1.Load_Config();
        }
    }
}
