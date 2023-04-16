using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmChonNhomNhanMau : Form
    {
        public FrmChonNhomNhanMau()
        {
            InitializeComponent();
        }
        public List<string> lstNhomNhanMau = new List<string>();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();

        private void Load_DSNhomTheoPhanQuyen()
        {
            ucDanhSachNhom1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhSachNhom1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhSachNhom1.Load_DanhSach(null);
            ucDanhSachNhom1.LuoiSelectedItemChanged += UcDanhSachNhom1_LuoiSelectedItemChanged;
        }

        private void UcDanhSachNhom1_LuoiSelectedItemChanged(object sender, EventArgs e)
        {
            GetSelectedList();
        }

        private void GetSelectedList()
        {
            if (ucDanhSachNhom1.IsSelectAll)
            {
                lblDaCHon.Text = "TẤT CẢ NHÓM";
            }
            else
                lblDaCHon.Text = string.Join(",", ucDanhSachNhom1.LstMaNhomChon);
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            lstNhomNhanMau = ucDanhSachNhom1.LstMaNhomChon;
            if (ucDanhSachNhom1.IsSelectAll)
            {
                lstNhomNhanMau = new List<string>();
                this.Close();
            }
            else if (lstNhomNhanMau.Count == 0)
                CustomMessageBox.MSG_Information_OK("Hãy chọn nhóm xét nghiệm!");
            else
                this.Close();
        }

        private void FrmChonNhomNhanMau_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
            Load_DSNhomTheoPhanQuyen();
        }

        private void chlViewWithCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedList();
        }

    }
}
