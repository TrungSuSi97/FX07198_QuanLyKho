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
    public partial class Frm_DM_BienDichKetQua : FrmTemplate
    {
        public Frm_DM_BienDichKetQua()
        {
            InitializeComponent();
        }

        private void Frm_DM_BienDichKetQua_Load(object sender, EventArgs e)
        {
            ucDanhMucBienDichKetQuaMay1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucBienDichKetQuaMay1.arrPhanQuyenMayXN = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucDanhMucBienDichKetQuaMay1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucBienDichKetQuaMay1.DinhDang = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangKetqua;
            ucDanhMucBienDichKetQuaMay1.Load_Config();
        }
    }
}
