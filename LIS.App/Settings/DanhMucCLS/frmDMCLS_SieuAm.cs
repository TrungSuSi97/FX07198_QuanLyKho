using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmDMCLS_SieuAm : FrmTemplate
    {
        public frmDMCLS_SieuAm()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        DataTable dtBieuMauSieuAm = new DataTable();
        DataTable dtNhomCLSSieuAm = new DataTable();
        SqlDataAdapter daNhomCLSSieuAm = new SqlDataAdapter();
        DataTable dtTenMaySA = new DataTable();
        SqlDataAdapter daTenMaySA = new SqlDataAdapter();
        private void Clear()
        {
            cboNhomSieuAm.DataBindings.Clear();
            cboNhomSieuAm.SelectedIndex = -1;
            txtTenBieuMau.DataBindings.Clear();
            txtTenBieuMau.Text = "";
            txtTenChiDinh.DataBindings.Clear();
            txtTenChiDinh.Text = "";
            txtTieuDePhieuIn.DataBindings.Clear();
            txtTieuDePhieuIn.Text = "";
            ricKetLuan.DataBindings.Clear();
            ricKetLuan.Rtf = "";
            txtGioiTinh.DataBindings.Clear();
            txtGioiTinh.Text = "";
            txtDeNghi.DataBindings.Clear();
            txtDeNghi.Text = "";
            txtSLHinh.DataBindings.Clear();
            txtSLHinh.Text = "";
            txtSoTrangMota.DataBindings.Clear();
            txtSoTrangMota.Text = "";
            txtGoTat.DataBindings.Clear();
            txtGoTat.Text = "";
            ricTrang1.DataBindings.Clear();
            ricTrang1.Text = "";
            ricTrang2.DataBindings.Clear();
            ricTrang2.Text = "";
        }
        private void Set_ReadOnly(bool _readonly)
        {
            cboNhomSieuAm.Enabled = !_readonly;
            txtTenBieuMau.ReadOnly = txtTenChiDinh.ReadOnly = _readonly;
            txtTieuDePhieuIn.ReadOnly = txtGioiTinh.ReadOnly = _readonly;
            txtDeNghi.ReadOnly = txtSLHinh.ReadOnly = txtSoTrangMota.ReadOnly = txtGoTat.ReadOnly = _readonly;
            ricTrang1.Enabled = ricTrang2.Enabled = ricKetLuan.Enabled  = !_readonly;
            txtTenBieuMau.BackColor = txtTenChiDinh.BackColor = txtTieuDePhieuIn.BackColor = ricKetLuan.BackColor = Color.White;
            txtGioiTinh.BackColor = txtDeNghi.BackColor = txtSLHinh.BackColor = txtSoTrangMota.BackColor = Color.White;
            ricTrang1.BackColor = ricTrang2.BackColor = Color.White;
        }
        private void BindData(BindingSource bs)
        {
            Clear();
            Set_ReadOnly(true);
            cboNhomSieuAm.DataBindings.Add("SelectedValue", bs, "MaNhomSieuAm");
            txtTenBieuMau.DataBindings.Add("Text", bs, "TenMauSieuAm");
            txtTenChiDinh.DataBindings.Add("Text", bs, "TenChiDinh");
            txtTieuDePhieuIn.DataBindings.Add("Text", bs, "TieuDePhieuKetQua");
            ricKetLuan.DataBindings.Add("Rtf", bs, "KetluanMacDinh");
            txtGioiTinh.DataBindings.Add("Text", bs, "GioiTinhSuDung");
            txtDeNghi.DataBindings.Add("Text", bs, "DeNghi");
            txtSLHinh.DataBindings.Add("Text", bs, "SoLuongHinh");
            txtSoTrangMota.DataBindings.Add("Text", bs, "SoTrangIn");
            txtGoTat.DataBindings.Add("Text", bs, "GoTat");
            ricTrang1.DataBindings.Add("Rtf", bs, "NoiDung1");
            ricTrang2.DataBindings.Add("Rtf", bs, "NoiDung2");

        }
        private void Load_BieuMau(string _filter)
        {
            sysConfig.Get_DMSieuAm(dtgBieuMau, bvBieuMau, _filter, ref dtBieuMauSieuAm);
            BindData(bvBieuMau.BindingSource);
        }

        private void frmDMCLS_SieuAm_Load(object sender, EventArgs e)
        {
            sysConfig.Get_NhomCLS_SieuAm(ref daNhomCLSSieuAm, dtgMaNhomCLS, bvMaNhomCLS, "", ref dtNhomCLSSieuAm);
            sysConfig.Get_NhomCLS_SieuAm(cboNhomSieuAm, "");
            sysConfig.Get_DMMaySA(daTenMaySA, dtgMaySA, bvMaySA, "", ref dtTenMaySA);
            Load_BieuMau("");
        }

        private void btnAddMauSieuAm_Click(object sender, EventArgs e)
        {

            Clear();
            if (btnAddMauSieuAm.Text == "Thêm mới")
            {
                btnAddMauSieuAm.Text = "Hủy thêm";
                btnAddMauSieuAm.Image = imageList1.Images[1];
                Set_ReadOnly(false);
                txtTenBieuMau.BackColor = Color.Yellow;
                cboNhomSieuAm.Focus();
                cboNhomSieuAm.DroppedDown = true;
            }
            else if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy " + (txtTenBieuMau.BackColor == Color.Yellow ? "thêm mới ?" : " sửa thông tin ?")))
            {
                btnAddMauSieuAm.Text = "Thêm mới";
                btnAddMauSieuAm.Image = imageList1.Images[0];
                Load_BieuMau("");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cboNhomSieuAm.Enabled == true)
            {
                if (cboNhomSieuAm.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK("Vui lòng chọn nhóm");
                    cboNhomSieuAm.Focus();
                    cboNhomSieuAm.DroppedDown = true;
                    return;
                }
                else
                {
                    sysConfig.Insert_Update_DMSieuAm(cboNhomSieuAm.SelectedValue.ToString(), (txtTenBieuMau.BackColor == Color.Yellow ? "" : dtgBieuMau.CurrentRow.Cells["MaSoMau"].Value.ToString().Trim()),
                        txtGoTat.Text, txtTenBieuMau.Text, txtTenChiDinh.Text, txtTieuDePhieuIn.Text, txtGioiTinh.Text, txtTenChiDinh.Text, ricKetLuan.Rtf, txtDeNghi.Text,
                        txtSLHinh.Text, txtSoTrangMota.Text, ricTrang1.Rtf,ricTrang2.Rtf, (txtTenBieuMau.BackColor == Color.Yellow ? true : false));

                    txtTenBieuMau.BackColor = Color.White;
                    Load_BieuMau("");
                    btnAddMauSieuAm.Text = "Thêm mới";
                    btnAddMauSieuAm.Image = imageList1.Images[0];
                }
            }
        }

        private void btnSuaMau_Click(object sender, EventArgs e)
        {
            if (txtTenBieuMau.ReadOnly)
            {
                Set_ReadOnly(false);
                btnAddMauSieuAm.Text = "Hủy sửa";
                btnAddMauSieuAm.Image = imageList1.Images[1];
                txtTenBieuMau.BackColor = Color.LightGreen;
                txtTenBieuMau.Focus();
            }
        }

        private void txtSLHinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void txtSoTrangMota_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {
            if (txtGioiTinh.Text == "F")
            {
                lblSex.Text = "Nữ";
            }
            else if (txtGioiTinh.Text == "M")
            {
                lblSex.Text = "Nam";
            }
            else
            {
                lblSex.Text = "Dùng chung";
            }
        }

        private void txtGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.KeyPressGender_SieuAm(e);
            LabServices_Helper.LeaveFocusNext(e, txtDeNghi);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefreshMaNhomCLS_Click(object sender, EventArgs e)
        {
            sysConfig.Get_NhomCLS_SieuAm(ref daNhomCLSSieuAm, dtgMaNhomCLS, bvMaNhomCLS, "", ref dtNhomCLSSieuAm);
        }

        private void dtgMaNhomCLS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataProvider.UpdateData(daNhomCLSSieuAm, ref dtNhomCLSSieuAm, dtgMaNhomCLS, "", ""))
            {
                sysConfig.Get_NhomCLS_SieuAm(ref daNhomCLSSieuAm, dtgMaNhomCLS, bvMaNhomCLS, "", ref dtNhomCLSSieuAm);
                sysConfig.Get_NhomCLS_SieuAm(cboNhomSieuAm, "");
            }
        }

        private void cboNhomSieuAm_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGoTat);
        }

        private void txtGoTat_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenBieuMau);
        }

        private void txtTenBieuMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTieuDePhieuIn);
        }

        private void txtTieuDePhieuIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGioiTinh);
        }

        private void txtKetLuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtDeNghi);
        }

        private void txtDeNghi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, ricKetLuan);
        }

        private void btnThemMaySA_Click(object sender, EventArgs e)
        {
            if (txtTenMaySA.Text != "")
            {
                sysConfig.Insert_MaySieuAm(Utilities.ConvertSqlString(txtTenMaySA.Text));
                sysConfig.Get_DMMaySA(daTenMaySA, dtgMaySA, bvMaySA, "", ref dtTenMaySA);
                txtTenMaySA.Focus();
                txtTenMaySA.SelectAll();
            }
        }

        private void dtgMaySA_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daTenMaySA, ref dtTenMaySA, dtgMaySA, "", "");
        }

        private void btnDeleteMayXN_Click(object sender, EventArgs e)
        {
            if (dtgMaySA.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa máy siêu âm đang chọn ?"))
                {
                    dtgMaySA.Rows.RemoveAt(dtgMaySA.CurrentRow.Index);
                }
            }
        }

        private void btnRefreshMayXN_Click(object sender, EventArgs e)
        {
            sysConfig.Get_DMMaySA(daTenMaySA, dtgMaySA, bvMaySA, "", ref dtTenMaySA);
        }

        private void txtTenMaySA_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemMaySA);
        }

        private void btnLoadBieuMau_Click(object sender, EventArgs e)
        {
            Load_BieuMau("");
        }
    }
}
