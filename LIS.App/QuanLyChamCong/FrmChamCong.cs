using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;

namespace TPH.LIS.App.QuanLyChamCong
{
    public partial class FrmChamCong : FrmTemplate
    {
        public FrmChamCong()
        {
            InitializeComponent();
        }

        private void btnVaoLam_Click(object sender, EventArgs e)
        {

        }

        private void btnRaVe_Click(object sender, EventArgs e)
        {

        }

        private void Clear_BindingInformation()
        {
            ucSearchLookupEditor_BoPhan1.DataBindings.Clear();
            ucSearchLookupEditor_BoPhan1.SelectedValue = null;

            ucSearchLookupEditor_ChucVu1.DataBindings.Clear();
            ucSearchLookupEditor_ChucVu1.SelectedValue = null;

            ucSearchLookupEditor_NhanVien1.DataBindings.Clear();
            ucSearchLookupEditor_NhanVien1.SelectedValue = null;
        }

        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            Clear_BindingInformation();
            Load_NhanVien();
            Load_BoPhan();
            Load_ChucVu();
            LoadThongTinCaNhan();
        }

        private void LoadThongTinCaNhan()
        {
            txtManNV.Text = CommonAppVarsAndFunctions.UserID;
            txtTen.Text = CommonAppVarsAndFunctions.UserName;
            txtBP.Text = CommonAppVarsAndFunctions.TenBoPhan;
            txtCV.Text = CommonAppVarsAndFunctions.TenNhomNhanVien;


        }


        private void Load_NhanVien()
        {
            ucSearchLookupEditor_NhanVien1.Load_NhanVien();
            ucSearchLookupEditor_NhanVien1.CatchEnterKey = true;
            ucSearchLookupEditor_NhanVien1.CatchTabKey = true;
            //ucSearchLookupEditor_NhanVien1.ControlNext = ucSearchLookupEditor_CongTacVien;
            //ucSearchLookupEditor_NhanVien1.ControlBack = ucSearchLookupEditor_Object1;
        }
        private void Load_BoPhan()
        {
            ucSearchLookupEditor_BoPhan1.Load_BoPhan();
            ucSearchLookupEditor_BoPhan1.CatchEnterKey = true;
            ucSearchLookupEditor_BoPhan1.CatchTabKey = true;
            //ucSearchLookupEditor_NhanVien1.ControlNext = ucSearchLookupEditor_CongTacVien;
            //ucSearchLookupEditor_NhanVien1.ControlBack = ucSearchLookupEditor_Object1;
        }
        private void Load_ChucVu()
        {
            ucSearchLookupEditor_ChucVu1.Load_ChucVu();
            ucSearchLookupEditor_ChucVu1.CatchEnterKey = true;
            ucSearchLookupEditor_ChucVu1.CatchTabKey = true;
            //ucSearchLookupEditor_NhanVien1.ControlNext = ucSearchLookupEditor_CongTacVien;
            //ucSearchLookupEditor_NhanVien1.ControlBack = ucSearchLookupEditor_Object1;
        }
    }
}
