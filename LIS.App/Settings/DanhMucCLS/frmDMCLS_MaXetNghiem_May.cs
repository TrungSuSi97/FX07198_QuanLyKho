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
    public partial class frmDMCLS_MaXetNghiem_May : FrmTemplate
    {
        public frmDMCLS_MaXetNghiem_May()
        {
            InitializeComponent();
        }

        private void frmDMCLS_MaXetNghiem_May_Load(object sender, EventArgs e)
        {
            ucMappingMaMay1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucMappingMaMay1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucMappingMaMay1.UserId = CommonAppVarsAndFunctions.UserID;
            ucMappingMaMay1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucMappingMaMay1.LoadConfig();
        }
    }
}
