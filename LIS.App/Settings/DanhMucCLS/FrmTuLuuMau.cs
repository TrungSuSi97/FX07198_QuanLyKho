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
    public partial class FrmTuLuuMau : FrmTemplate
    {
        public FrmTuLuuMau()
        {
            InitializeComponent();
        }

        private void FrmTuLuuMau_Load(object sender, EventArgs e)
        {
            ucDanhMucKhayLuuMau1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucTuLuuMau1.Load_Config();
            ucDanhMucTuLuuMau1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucKhayLuuMau1.Load_Config(ucDanhMucTuLuuMau1.CurrentDataSource);
            HightLightButton(btnTuLuu);
        }

        private void ucDanhMucTuLuuMau1_BuutonThemMoiClick(object sender, EventArgs e)
        {
            ucDanhMucKhayLuuMau1.Load_TuLuuMau(ucDanhMucTuLuuMau1.CurrentDataSource);
        }

        private void ucDanhMucTuLuuMau1_BuutonXoaClick(object sender, EventArgs e)
        {
            ucDanhMucKhayLuuMau1.Load_TuLuuMau(ucDanhMucTuLuuMau1.CurrentDataSource);
        }

        private void ucDanhMucTuLuuMau1_LuoiChinhSua(object sender, EventArgs e)
        {
            ucDanhMucKhayLuuMau1.Load_TuLuuMau(ucDanhMucTuLuuMau1.CurrentDataSource);
        }

        private void btnTuLuu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            HightLightButton((Button)sender);
        }

        private void btnKhayMau_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            HightLightButton((Button)sender);
        }
    }
}
