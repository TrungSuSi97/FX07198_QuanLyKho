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
    public partial class frmDMCLS_NoiSoi : FrmTemplate
    {
        public frmDMCLS_NoiSoi()
        {
            InitializeComponent();
        }

        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        DataTable _dtBieuMauNoiSoi = new DataTable();
        DataTable _dtNhomClsNoiSoi = new DataTable();
        readonly SqlDataAdapter _daNhomClsNoiSoi = new SqlDataAdapter();
        DataTable _dtTenMayNs = new DataTable();
        readonly SqlDataAdapter _daTenMayNs = new SqlDataAdapter();
        DataTable _dtKyThuatHp = new DataTable();
        SqlDataAdapter _daKyThuatHp = new SqlDataAdapter();
        DataTable _dtKetQuaHp = new DataTable();
        SqlDataAdapter _daKetQuaHp = new SqlDataAdapter();

        private void Clear()
        {
            cboNhomNoiSoi.DataBindings.Clear();
            cboNhomNoiSoi.SelectedIndex = -1;
            txtTenBieuMau.DataBindings.Clear();
            txtTenBieuMau.Text = string.Empty;
            txtTenChiDinh.DataBindings.Clear();
            txtTenChiDinh.Text = string.Empty;
            txtTieuDePhieuIn.DataBindings.Clear();
            txtTieuDePhieuIn.Text = string.Empty;
            ricKetLuan.DataBindings.Clear();
            ricKetLuan.Rtf = string.Empty;
            txtGioiTinh.DataBindings.Clear();
            txtGioiTinh.Text = string.Empty;
            txtDeNghi.DataBindings.Clear();
            txtDeNghi.Text = string.Empty;
            txtSLHinh.DataBindings.Clear();
            txtSLHinh.Text = string.Empty;
            txtSoTrangMota.DataBindings.Clear();
            txtSoTrangMota.Text = string.Empty;
            txtGoTat.DataBindings.Clear();
            txtGoTat.Text = string.Empty;
            ricTrang1.DataBindings.Clear();
            ricTrang1.Text = string.Empty;
            ricTrang2.DataBindings.Clear();
            ricTrang2.Text = string.Empty;
        }

        private void Set_ReadOnly(bool isReadonly)
        {
            cboNhomNoiSoi.Enabled = !isReadonly;
            txtTenBieuMau.ReadOnly = txtTenChiDinh.ReadOnly = isReadonly;
            txtTieuDePhieuIn.ReadOnly = txtGioiTinh.ReadOnly = isReadonly;
            txtDeNghi.ReadOnly = txtSLHinh.ReadOnly = txtSoTrangMota.ReadOnly = txtGoTat.ReadOnly = isReadonly;
            ricTrang1.Enabled = ricTrang2.Enabled = ricKetLuan.Enabled  = !isReadonly;
            txtTenBieuMau.BackColor =
                txtTenChiDinh.BackColor = txtTieuDePhieuIn.BackColor = ricKetLuan.BackColor = Color.White;
            txtGioiTinh.BackColor = txtDeNghi.BackColor = txtSLHinh.BackColor = txtSoTrangMota.BackColor = Color.White;
            ricTrang1.BackColor = ricTrang2.BackColor = Color.White;
        }

        private void BindData(BindingSource bs)
        {
            Clear();
            Set_ReadOnly(true);
            cboNhomNoiSoi.DataBindings.Add("SelectedValue", bs, "MaNhomNoiSoi");
            txtTenBieuMau.DataBindings.Add("Text", bs, "TenMauNoiSoi");
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

        private void Load_BieuMau(string filter)
        {
            sysConfig.Get_DMNoiSoi(dtgBieuMau, bvBieuMau, filter, ref _dtBieuMauNoiSoi);
            BindData(bvBieuMau.BindingSource);
        }

        private void frmDMCLS_NoiSoi_Load(object sender, EventArgs e)
        {
            sysConfig.Get_NhomCLS_NoiSoi(_daNhomClsNoiSoi, dtgMaNhomCLS, bvMaNhomCLS, string.Empty, ref _dtNhomClsNoiSoi);
            sysConfig.Get_NhomCLS_NoiSoi(cboNhomNoiSoi, string.Empty);
            sysConfig.Get_DMMayNS(_daTenMayNs, dtgMayNS, bvMayNS, string.Empty, ref _dtTenMayNs);
            Load_KyThuatHP();
            Load_KetQuaHP();
            Load_BieuMau(string.Empty);
        }

        private void btnAddMauNoiSoi_Click(object sender, EventArgs e)
        {

            Clear();
            if (btnAddMauNoiSoi.Text == "Thêm mới")
            {
                btnAddMauNoiSoi.Text = "Hủy thêm";
                btnAddMauNoiSoi.Image = imageList1.Images[1];
                Set_ReadOnly(false);
                txtTenBieuMau.BackColor = Color.Yellow;
                cboNhomNoiSoi.Focus();
                cboNhomNoiSoi.DroppedDown = true;
            }
            else if (
                CustomMessageBox.MSG_Question_YesNo_GetYes(
                    "Hủy " + (txtTenBieuMau.BackColor == Color.Yellow ? "thêm mới ?" : " sửa thông tin ?")))
            {
                btnAddMauNoiSoi.Text = "Thêm mới";
                btnAddMauNoiSoi.Image = imageList1.Images[0];
                Load_BieuMau(string.Empty);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cboNhomNoiSoi.Enabled)
            {
                if (cboNhomNoiSoi.SelectedIndex == -1)
                {
                   CustomMessageBox.MSG_Information_OK("Không có dữ liệu để in !");
                    cboNhomNoiSoi.Focus();
                    cboNhomNoiSoi.DroppedDown = true;
                    return;
                }
                else
                {
                    sysConfig.Insert_Update_DMNoiSoi(cboNhomNoiSoi.SelectedValue.ToString(),
                        (txtTenBieuMau.BackColor == Color.Yellow
                            ? string.Empty
                            : dtgBieuMau.CurrentRow.Cells["MaSoMau"].Value.ToString().Trim()),
                        txtGoTat.Text, txtTenBieuMau.Text, txtTenChiDinh.Text, txtTieuDePhieuIn.Text, txtGioiTinh.Text,
                        txtTenChiDinh.Text, ricKetLuan.Rtf, txtDeNghi.Text,
                        txtSLHinh.Text, txtSoTrangMota.Text, ricTrang1.Rtf, ricTrang2.Rtf,
                        (txtTenBieuMau.BackColor == Color.Yellow ? true : false));

                    txtTenBieuMau.BackColor = Color.White;
                    Load_BieuMau(string.Empty);
                    btnAddMauNoiSoi.Text = "Thêm mới";
                    btnAddMauNoiSoi.Image = imageList1.Images[0];
                }
            }
        }

        private void btnSuaMau_Click(object sender, EventArgs e)
        {
            if (txtTenBieuMau.ReadOnly)
            {
                Set_ReadOnly(false);
                btnAddMauNoiSoi.Text = "Hủy sửa";
                btnAddMauNoiSoi.Image = imageList1.Images[1];
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
            sysConfig.Get_NhomCLS_NoiSoi(_daNhomClsNoiSoi, dtgMaNhomCLS, bvMaNhomCLS, "", ref _dtNhomClsNoiSoi);
        }

        private void dtgMaNhomCLS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataProvider.UpdateData(_daNhomClsNoiSoi, ref _dtNhomClsNoiSoi, dtgMaNhomCLS, string.Empty, string.Empty))
            {
                sysConfig.Get_NhomCLS_NoiSoi(_daNhomClsNoiSoi, dtgMaNhomCLS, bvMaNhomCLS, string.Empty, ref _dtNhomClsNoiSoi);
                sysConfig.Get_NhomCLS_NoiSoi(cboNhomNoiSoi, string.Empty);
            }
        }

        private void cboNhomNoiSoi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnThemMayNS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenMayNS.Text))
            {
                sysConfig.Insert_MayNoiSoi(Utilities.ConvertSqlString(txtTenMayNS.Text));
                sysConfig.Get_DMMayNS(_daTenMayNs, dtgMayNS, bvMayNS, string.Empty, ref _dtTenMayNs);
                txtTenMayNS.Focus();
                txtTenMayNS.SelectAll();
            }
        }

        private void dtgMayNS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(_daTenMayNs, ref _dtTenMayNs, dtgMayNS, string.Empty, string.Empty);
        }

        private void btnDeleteMayXN_Click(object sender, EventArgs e)
        {
            if (dtgMayNS.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa máy nội soi đang chọn ?"))
                {
                    dtgMayNS.Rows.RemoveAt(dtgMayNS.CurrentRow.Index);
                }
            }
        }

        private void btnRefreshMayXN_Click(object sender, EventArgs e)
        {
            sysConfig.Get_DMMayNS(_daTenMayNs, dtgMayNS, bvMayNS, string.Empty, ref _dtTenMayNs);
        }

        private void txtTenMayNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemMayNS);
        }

        private void Load_KyThuatHP()
        {
            sysConfig.Get_DM_NoiSoi_KyThuatHP(dtgKyThuat, bvKyThuat, ref _daKyThuatHp, ref _dtKyThuatHp);
        }
        private void btnLamMoiKyThuatHP_Click(object sender, EventArgs e)
        {
            Load_KyThuatHP();
        }

        private void dtgKyThuat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataProvider.UpdateData(_daKyThuatHp, ref _dtKyThuatHp, dtgKyThuat, string.Empty, string.Empty))
            {
                Load_KyThuatHP();
            }
        }

        private void Load_KetQuaHP()
        {
            sysConfig.Get_DM_NoiSoi_KetQuaHP(dtgKetQua, bvKetQua, ref _daKetQuaHp, ref _dtKetQuaHp);
        }

        private void btnLamMoiKetQuaHP_Click(object sender, EventArgs e)
        {
            Load_KetQuaHP();

        }

        private void dtgKetQua_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataProvider.UpdateData(_daKetQuaHp, ref _dtKetQuaHp, dtgKetQua, string.Empty, string.Empty))
            {
                Load_KetQuaHP();
            }
        }

        private void btnXoaKyThuatHP_Click(object sender, EventArgs e)
        {
            if (dtgKyThuat.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kỹ thuật tìm HP đang chọn?"))
                {
                    bvKyThuat.BindingSource.RemoveAt(bvKyThuat.BindingSource.Position);
                }
            }
        }

        private void btnXoaKetQuaHP_Click(object sender, EventArgs e)
        {
            if (dtgKetQua.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa định nghĩa kết quả đang chọn?"))
                {
                    bvKetQua.BindingSource.RemoveAt(bvKetQua.BindingSource.Position);
                }
            }
        }
    }
}