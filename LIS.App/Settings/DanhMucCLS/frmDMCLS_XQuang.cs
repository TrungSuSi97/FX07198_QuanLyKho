using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmDMCLS_XQuang : FrmTemplate
    {
        public frmDMCLS_XQuang()
        {
            InitializeComponent();
        }

        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        DataTable dtKyThuatChup = new DataTable();
        SqlDataAdapter daKyThuatChup = new SqlDataAdapter();

        DataTable dtVungChup = new DataTable();
        SqlDataAdapter daVungChup = new SqlDataAdapter();

        DataTable dtVungChup_ChiTiet = new DataTable();


        DataTable dtChiTiet = new DataTable();
        SqlDataAdapter daChiTiet = new SqlDataAdapter();

        DataTable dtTenMayXQuang = new DataTable();
        SqlDataAdapter daTenMayXQuang = new SqlDataAdapter();

        

        private void dtgKyThuatChupHinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDMCLS_XQuang_Load(object sender, EventArgs e)
        {
            Load_MayXQuang();
            Load_KyThuat();
            Load_DM_HCXQuang_FilmXQuang();
            Load_VungChup((dtgKyThuatChupHinh.CurrentRow != null
                ? dtgKyThuatChupHinh.CurrentRow.Cells[IDKyThuat.Name].Value.ToString()
                : ""));
            Load_VungChup_ChiTiet();
        }
        private void Load_KyThuat()
        {
            sysConfig.Get_DM_XQuang_KyThuat(daKyThuatChup, dtgKyThuatChupHinh, bvKyThuatChupHinh, "", ref dtKyThuatChup);
            sysConfig.Get_DM_XQuang_KyThuat(cboKyThuat);
        }
        private void Load_VungChup(string _filter)
        {
            Clear_VungKS();
            SetReadonly_VungKS(true, false);
            txtMaVungKS.BackColor = Color.Ivory;
            sysConfig.Get_DM_XQuang_VungChup(daVungChup, dtgVungChup, bvVungChup, " and MaKyThuatChup = '" + _filter + "' \n", ref dtVungChup);
            BindData_VungKS(bvVungChup.BindingSource);

            if (dtgVungChup_ChiTiet.RowCount > 0)
            {
                pnChiTiet.Enabled = true;
            }
            else
            {
                pnChiTiet.Enabled = true;
            }
        }
        private void Load_VungChup_ChiTiet()
        {
            sysConfig.Get_DM_XQuang_VungChup(dtgVungChup_ChiTiet, bvVungChup_ChiTiet, (cboKyThuat.SelectedIndex == -1 ? "" : " and MaKyThuatChup = '" + cboKyThuat.SelectedValue.ToString().Trim() + "' \n"), ref dtVungChup_ChiTiet);
            BindData_VungKhaoSat_KetQua(bvVungChup_ChiTiet.BindingSource);
        }
        private void Load_DM_HCXQuang_FilmXQuang()
        {
            C_VatTu_Config vattu = new C_VatTu_Config();
            vattu.Get_DM_VatTu(cboFiImChup, " and MaLoaiVT  = 'FILMXRAY' \n");
            vattu.Get_DM_VatTu(cboThuocXQuang, " and  MaLoaiVT= 'HCXRAY' \n");
        }

        private void dtgKyThuatChupHinh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daKyThuatChup, ref dtKyThuatChup, dtgKyThuatChupHinh, "", "");
            if (dtgKyThuatChupHinh.RowCount > 0)
            {
                pnVungKhaoSat.Enabled = true;
            }
            else
            {
                pnVungKhaoSat.Enabled = false;
                Load_VungChup("");
            }
        }

        private void btnThemMoiKyThuat_Click(object sender, EventArgs e)
        {
            if (txtMaKyThuatChup.Text != "")
            {
                sysConfig.Insert_KyThuat(txtMaKyThuatChup.Text, txtTenKyThuatChup.Text, "1");
                Load_KyThuat();
            }
        }

        private void bvXoaKyThuatChup_Click(object sender, EventArgs e)
        {
            if (dtgKyThuatChupHinh.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kỹ thuật chụp đang chọn ?"))
                {
                    sysConfig.Delete_KyThuat(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim());
                    Load_KyThuat();
                }
            }
        }

        private void btnAddVungKS_Click(object sender, EventArgs e)
        {
            Add_VungChup();
            btnVungChupCancel.Enabled = true;
            btnLuuVungChup.Enabled = true;
        }

        private void SetReadonly_VungKS(bool _readonly, bool _edit)
        {
            if (_edit)
            {
                txtMaVungKS.ReadOnly = true;
                btnVungChupCancel.Enabled = true;
                btnLuuVungChup.Enabled = true;
            }
            else
            {
                txtMaVungKS.ReadOnly = _readonly;
            }
            cboThuocXQuang.Enabled = !_readonly;
            cboFiImChup.Enabled = !_readonly;

            txtTenVungKS.ReadOnly = _readonly;
            txtSLPhim.ReadOnly = _readonly;
            txtSLThuoc.ReadOnly = _readonly;
            txtVungChupGiaChuan.ReadOnly = _readonly;
            txtVungChupThuTuIn.ReadOnly = _readonly;
            txtVungChupDeNghi.ReadOnly = _readonly;
            txtVungChupKetLuan.ReadOnly = _readonly;
            
        }

        private void Clear_VungKS()
        {
            btnVungChupCancel.Enabled = false;

            txtMaVungKS.DataBindings.Clear();
            txtTenVungKS.DataBindings.Clear();
            txtVungChupDeNghi.DataBindings.Clear();
            txtVungChupKetLuan.DataBindings.Clear();
            cboFiImChup.DataBindings.Clear();
            cboThuocXQuang.DataBindings.Clear();

            txtMaVungKS.Text = "";
            txtTenVungKS.Text = "";
            txtVungChupDeNghi.Text = "";
            txtVungChupKetLuan.Text = "";
            cboFiImChup.SelectedIndex = -1;
            cboThuocXQuang.SelectedIndex = -1;
        }

        private void BindData_VungKS(BindingSource bs)
        {
            SetReadonly_VungKS(true, false);
            Clear_VungKS();

            txtMaVungKS.DataBindings.Add("Text", bs, "MaVungChup");
            txtTenVungKS.DataBindings.Add("Text", bs, "TenVungChup");
            txtVungChupDeNghi.DataBindings.Add("Text", bs, "DeNghiMacDinh");
            txtVungChupKetLuan.DataBindings.Add("Text", bs, "KetLuanMacDinh");
            cboFiImChup.DataBindings.Add("SelectedValue", bs, "Phim");
            cboThuocXQuang.DataBindings.Add("SelectedValue", bs, "Thuoc");

        }
        private void Lock_VungKhaoSat_KetQua(bool isLock)
        {
            ricNoiDung.Enabled = !isLock;
        }
        private void Clear_VungKhaoSat_KetQua()
        {
            ricNoiDung.DataBindings.Clear();
            ricNoiDung.Rtf = null;
        }
        private void BindData_VungKhaoSat_KetQua(BindingSource bs)
        {
            Clear_VungKhaoSat_KetQua();
            ricNoiDung.DataBindings.Add("Rtf", bs, "MauKetQua");
            Lock_VungKhaoSat_KetQua(true);
        }
        private void Add_VungChup()
        {
            Clear_VungKS();
            SetReadonly_VungKS(false, false);

            btnVungChupCancel.Enabled = true;
            btnLuuVungChup.Enabled = true;

            txtMaVungKS.Focus();
            txtMaVungKS.BackColor = Color.Yellow;
        }

        private void Edit_VungChup()
        {
            SetReadonly_VungKS(false, true);
            txtMaVungKS.BackColor = Color.LightPink;

            txtTenVungKS.Focus();
            txtTenVungKS.SelectAll();

        }

        private void btnSuaVungChup_Click(object sender, EventArgs e)
        {
            Edit_VungChup();
        }


        private void Save_VungChup()
        {
            if (txtMaVungKS.BackColor == Color.Yellow)
            {
                //màu vàng là chế độ lưu mới
                sysConfig.Insert_VungChup(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim(),
                    txtMaVungKS.Text.Trim(),
                    txtTenVungKS.Text.Trim(),
                    txtVungChupThuTuIn.Text,
                    (cboFiImChup.SelectedIndex != -1 ? cboFiImChup.SelectedValue.ToString().Trim() : "Null"),
                    txtSLPhim.Text,
                    (cboThuocXQuang.SelectedIndex != -1 ? cboThuocXQuang.SelectedValue.ToString().Trim() : "Null"),
                    txtSLThuoc.Text,
                    txtVungChupKetLuan.Text.Trim(),
                    txtVungChupDeNghi.Text.Trim(),
                    txtVungChupGiaChuan.Text);
                Load_VungChup(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim());
            }
            else if(txtMaVungKS.BackColor == Color.LightPink)
            {
                //hồng nhạt là chỉnh sửa
                sysConfig.Update_VungChup(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim(),
                                  txtMaVungKS.Text.Trim(),
                                  txtTenVungKS.Text.Trim(),
                                  txtVungChupThuTuIn.Text,
                                  (cboFiImChup.SelectedIndex != -1 ? cboFiImChup.SelectedValue.ToString().Trim() : "Null"),
                                  txtSLPhim.Text,
                                  (cboThuocXQuang.SelectedIndex != -1 ? cboThuocXQuang.SelectedValue.ToString().Trim() : "Null"),
                                  txtSLThuoc.Text,
                                  txtVungChupKetLuan.Text.Trim(),
                                  txtVungChupDeNghi.Text.Trim(),
                                  txtVungChupGiaChuan.Text);
                Load_VungChup(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim());
            }
        }

        private void btnXoaVungChup_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa vùng chụp đang chọn ?"))
            {
                sysConfig.Delete_VungChup(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim(), txtMaVungKS.Text.Trim());
                Load_VungChup(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim());
            }
        }

        private void btnVungChupCancel_Click(object sender, EventArgs e)
        {
            string _Message = "Bạn muốn hủy " + (txtMaVungKS.BackColor == Color.Yellow ? "thêm mới ?" : "chỉnh sửa ?");
            if (CustomMessageBox.MSG_Question_YesNo_GetYes(_Message))
             {
                 Load_VungChup(dtgKyThuatChupHinh.CurrentRow.Cells["IDKyThuat"].Value.ToString().Trim());
             }
        }

        private void txtVungChupGiaChuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            LabServices_Helper.LeaveFocusNext(e, txtVungChupThuTuIn);
        }

        private void txtVungChupThuTuIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            LabServices_Helper.LeaveFocusNext(e, cboFiImChup);
        }

        private void cboFiImChup_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboThuocXQuang);
        }

        private void cboThuocXQuang_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnLuuVungChup);
        }

        private void txtMaVungKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenVungKS);
        }

        private void txtTenVungKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtVungChupKetLuan);
        }

        private void txtVungChupKetLuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtVungChupDeNghi);
        }

        private void txtVungChupDeNghi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtVungChupGiaChuan);
        }

        private void txtMaKyThuatChup_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenKyThuatChup);
        }

        private void txtTenKyThuatChup_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemMoiKyThuat);
        }

        private void cboKyThuat_SelectionChangeCommitted(object sender, EventArgs e)
        {

            sysConfig.Get_DM_XQuang_VungChup(dtgVungChup_ChiTiet, bvVungChup_ChiTiet, (cboKyThuat.SelectedIndex == -1 ? "" : " and MaKyThuatChup = '" + cboKyThuat.SelectedValue.ToString().Trim() + "' \n"), ref dtVungChup_ChiTiet);
            if (dtgVungChup_ChiTiet.RowCount > 0)
            {
                pnChiTiet.Enabled = true;
            }
            else
            {
                pnChiTiet.Enabled = true;
            }
        }

        private void btnLuuVungChup_Click(object sender, EventArgs e)
        {
            Save_VungChup();
        }

        private void txtDetailID_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenVungKS);
        }

        private void chkInDamKQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnEdit);
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {

        }
        private void dtgKyThuatChupHinh_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgKyThuatChupHinh.RowCount > 0)
            {
                Load_VungChup(dtgKyThuatChupHinh["IDKyThuat", dtgKyThuatChupHinh.CurrentRow.Index].Value.ToString());
            }
        }

        private void ricNoiDung_Load(object sender, EventArgs e)
        {
            ricNoiDung.Font = new Font("Roboto Condensed", 12);
        }

        private void btnrefreshVungChup_ChiTiet_Click(object sender, EventArgs e)
        {
            Load_VungChup_ChiTiet();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Lock_VungKhaoSat_KetQua(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtgVungChup_ChiTiet.RowCount > 0)
            {
                string _MaVungChup = dtgVungChup_ChiTiet.CurrentRow.Cells[MaVungChup_ChiTiet.Name].Value.ToString().Trim();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu thông tin mẫu kết quả ?"))
                {
                    if (sysConfig.Update_MauKetQua(_MaVungChup, ricNoiDung.Rtf))
                    {
                        Lock_VungKhaoSat_KetQua(true);
                    }
                }
            }
        }

        private void Load_MayXQuang()
        {
            sysConfig.Get_DMMayXQuang(daTenMayXQuang, dtgMayXQuang, bvMayXQuang, "", ref dtTenMayXQuang);
        }
        private void btnThemMaySA_Click(object sender, EventArgs e)
        {
            if (txtTenMayXQuang.Text != "")
            {
                sysConfig.Insert_MayXQuang(Utilities.ConvertSqlString(txtTenMayXQuang.Text));
                sysConfig.Get_DMMayXQuang(daTenMayXQuang, dtgMayXQuang, bvMayXQuang, "", ref dtTenMayXQuang);
                txtTenMayXQuang.Focus();
                txtTenMayXQuang.SelectAll();
            }
        }

        private void btnRefreshMayXQuang_Click(object sender, EventArgs e)
        {
            Load_MayXQuang();
        }

        private void dtgMayXQuang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daTenMayXQuang, ref dtTenMayXQuang, dtgMayXQuang, "", "");
        }

        private void btnDeleteMayXQuang_Click(object sender, EventArgs e)
        {
            if (dtgMayXQuang.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa máy X-Quang đang chọn ?"))
                {
                    dtgMayXQuang.Rows.RemoveAt(bvMayXQuang.BindingSource.Position);
                }
            }
        }

    }
}
