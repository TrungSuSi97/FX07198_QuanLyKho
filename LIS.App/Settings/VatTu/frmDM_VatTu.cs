using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.VatTu
{
    public partial class frmDM_VatTu : FrmTemplate
    {
        public frmDM_VatTu()
        {
            InitializeComponent();
        }
        C_VatTu_Config vattu = new C_VatTu_Config();
        SqlDataAdapter daVatTu = new SqlDataAdapter();
        DataTable dtVatTu = new DataTable();

        private void LockControl(bool _lock, bool addnew)
        {
            if (addnew)
            {
                txtMaVT.ReadOnly = false;
            }
            else
            {
                txtMaVT.ReadOnly = true;
            }
            txtLuongTH.ReadOnly = _lock;
            txtQuiCachDG.ReadOnly = _lock;
            txtSlDongGoi.ReadOnly = _lock;
            txtSLDung.ReadOnly = _lock;
            txtSLDGTieuHao.ReadOnly = _lock;
            txtTenVatTu.ReadOnly = _lock;

            cboDonViTinh.Enabled = !_lock;
            cboDonViTinhDG.Enabled = !_lock;
            cboDonViTinhTH.Enabled = !_lock;
            cboLoaiVT.Enabled = !_lock;
            cboNhomVT.Enabled = !_lock;
            chkCoHSD.Enabled = !_lock;
            chkXuatQCDG.Enabled = !_lock;

        }
        private void ClearControl()
        {
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            txtMaVT.BackColor = Color.LightGray;
            txtMaVT.DataBindings.Clear();
            txtMaVT.Text = "";
            txtLuongTH.DataBindings.Clear();
            txtLuongTH.Text = "";
            txtQuiCachDG.DataBindings.Clear();
            txtQuiCachDG.Text = "";
            txtSlDongGoi.DataBindings.Clear();
            txtSlDongGoi.Text = "";
            txtSLDung.DataBindings.Clear();
            txtSLDung.Text = "";
            txtSLDGTieuHao.DataBindings.Clear();
            txtSLDGTieuHao.Text = "";
            txtTenVatTu.DataBindings.Clear();
            txtTenVatTu.Text = "";
            
            cboDonViTinh.DataBindings.Clear();
            cboDonViTinh.SelectedIndex = -1;
            cboDonViTinhDG.DataBindings.Clear();
            cboDonViTinhDG.SelectedIndex = -1;
            cboDonViTinhTH.DataBindings.Clear();
            cboDonViTinhTH.SelectedIndex = -1;
            cboLoaiVT.DataBindings.Clear();
            cboLoaiVT.SelectedIndex = -1;
            cboNhomVT.DataBindings.Clear();
            cboNhomVT.SelectedIndex = -1;

            chkCoHSD.DataBindings.Clear();
            chkCoHSD.Checked = false;
            chkXuatQCDG.DataBindings.Clear();
            chkXuatQCDG.Checked = false;
        }

        private void BindData(BindingSource bs)
        {
            //MaVatTu, TenVatTu, MaLoaiVT, MaNhomVT, QuiCachDongGoi, DonViTinh, SLDongGoi, 
            //DVTDongGoi, CoHSD, XuatTheoQCDG, SLDGTieuHao, DVTTieuHao, SLCoTheDung, TieuHao
            ClearControl();
            txtMaVT.DataBindings.Add("Text", bs, "MaVatTu");
            txtLuongTH.DataBindings.Add("Text", bs, "TieuHao");
            txtQuiCachDG.DataBindings.Add("Text", bs, "QuiCachDongGoi");
            txtSlDongGoi.DataBindings.Add("Text", bs, "SLDongGoi");
            txtSLDung.DataBindings.Add("Text", bs, "SLCoTheDung");
            txtSLDGTieuHao.DataBindings.Add("Text", bs, "SLDGTieuHao");
            txtTenVatTu.DataBindings.Add("Text", bs, "TenVatTu");

            cboDonViTinh.DataBindings.Add("SelectedValue", bs, "DonViTinh");
            cboDonViTinhDG.DataBindings.Add("SelectedValue", bs, "DVTDongGoi");
            cboDonViTinhTH.DataBindings.Add("SelectedValue", bs, "DVTTieuHao");
            cboLoaiVT.DataBindings.Add("SelectedValue", bs, "MaLoaiVT");
            cboNhomVT.DataBindings.Add("SelectedValue", bs, "MaNhomVT");
            chkCoHSD.DataBindings.Add("Checked", bs, "CoHSD");
            chkXuatQCDG.DataBindings.Add("Checked", bs, "XuatTheoQCDG");
        }

        private void Load_DMVatTu()
        {
            vattu.Get_DM_DonViTinh(cboDonViTinh);
            vattu.Get_DM_DonViTinh(cboDonViTinhDG);
            vattu.Get_DM_DonViTinh(cboDonViTinhTH);
            vattu.Get_DM_NhomVT(cboNhomVT, "");
            vattu.Get_DM_LoaiVT(cboLoaiVT);
            vattu.Get_DM_VatTu(daVatTu, dtgVatTu, bvVatTu, "", ref dtVatTu);
            BindData(bvVatTu.BindingSource);
            LockControl(true, false);
        }

        private void frmDM_VatTu_Load(object sender, EventArgs e)
        {
            Load_DMVatTu();
        }

        private void Add_Update_VatTu(bool update)
        {
            string MaVatTu = "", TenVatTu = "", MaLoaiVT = "", MaNhomVT = "", QuiCachDongGoi = "",
                DonViTinh = "", SLDongGoi = "", DVTDongGoi = "", CoHSD = "", XuatTheoQCDG = "",
                SLDGTieuHao = "", DVTTieuHao = "", SLCoTheDung = "", TieuHao = "";
            MaVatTu = txtMaVT.Text;
            TenVatTu = txtTenVatTu.Text;
            MaLoaiVT = (cboLoaiVT.SelectedIndex != -1 ? cboLoaiVT.SelectedValue.ToString().Trim() : "");
            MaNhomVT = (cboNhomVT.SelectedIndex != -1 ? cboNhomVT.SelectedValue.ToString().Trim() : "");
            QuiCachDongGoi = txtQuiCachDG.Text;
            DonViTinh = (cboDonViTinhTH.SelectedIndex != -1 ? cboDonViTinhTH.SelectedValue.ToString() : "");
            SLDongGoi = txtSlDongGoi.Text;
            DVTDongGoi = (cboDonViTinhDG.SelectedIndex != -1 ? cboDonViTinhDG.SelectedValue.ToString() : "");
            CoHSD = chkCoHSD.Checked == true ? "1" : "0";
            XuatTheoQCDG = chkXuatQCDG.Checked == true ? "1" : "0";
            SLDGTieuHao = txtSLDGTieuHao.Text == "" ? "0" : txtSLDGTieuHao.Text;
            DVTTieuHao = cboDonViTinhTH.SelectedIndex != -1 ? cboDonViTinhTH.SelectedValue.ToString() : "";
            SLCoTheDung = txtSLDung.Text == "" ? "0" : txtSLDung.Text;
            TieuHao = txtLuongTH.Text == "" ? "0" : txtLuongTH.Text;

            if (update)
            {
                if (vattu.Update_VatTu(MaVatTu, TenVatTu, MaLoaiVT, MaNhomVT, QuiCachDongGoi, DonViTinh, SLDongGoi, DVTDongGoi, CoHSD,
                     XuatTheoQCDG, SLDGTieuHao, DVTTieuHao, SLCoTheDung, TieuHao))
                {
                    Load_DMVatTu();
                }
            }
            else
            {
                if (vattu.Insert_VatTu(MaVatTu, TenVatTu, MaLoaiVT, MaNhomVT, QuiCachDongGoi, DonViTinh, SLDongGoi, DVTDongGoi, CoHSD,
                    XuatTheoQCDG, SLDGTieuHao, DVTTieuHao, SLCoTheDung, TieuHao) == false)
                {
                    txtMaVT.Focus();
                    txtMaVT.SelectAll();
                }
                else
                {
                    Load_DMVatTu();
                }
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            LockControl(false, true);
            txtMaVT.Focus();
            txtMaVT.BackColor = Color.LightPink;

            btnCancel.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtMaVT.Text != "")
            {
                LockControl(false, false);
                txtMaVT.BackColor = Color.LightGreen;
                txtTenVatTu.Focus();
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtMaVT.BackColor == Color.LightPink)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy bỏ nhập mới ?")) 
                {
                    Load_DMVatTu();
                }
            }
            else if (txtMaVT.BackColor == Color.LightGreen)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy bỏ sửa vật tư ?"))
                {
                    Load_DMVatTu();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaVT.BackColor == Color.LightGreen)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu thông tin vừa sửa ?"))
                {
                    Add_Update_VatTu(true);
                }
                else
                {
                    txtTenVatTu.Focus();
                }
            }
            else if (txtMaVT.BackColor == Color.LightPink)
            {
                Add_Update_VatTu(false);
            }
        }

        private void txtMaVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenVatTu);
        }

        private void txtTenVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboNhomVT);
        }

        private void cboNhomVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboLoaiVT);
        }

        private void cboLoaiVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, chkCoHSD);
        }

        private void chkCoHSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, chkXuatQCDG);
        }

        private void chkXuatQCDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtQuiCachDG);
        }

        private void txtQuiCachDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboDonViTinh);
        }

        private void cboDonViTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtSlDongGoi);
        }

        private void txtSlDongGoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboDonViTinhDG);
        }

        private void cboDonViTinhDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtSLDGTieuHao);
        }

        private void txtSLDGTieuHao_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboDonViTinhTH);
        }

        private void cboDonViTinhTH_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtSLDung);
        }

        private void txtSLDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtLuongTH);
        }

        private void txtLuongTH_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnSave);
        }
    }
}
