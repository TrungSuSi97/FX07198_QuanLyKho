using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.CauHinh.NhanVien
{
    public partial class FrmNhanVien_ChietKhau : FrmTemplate
    {
        public FrmNhanVien_ChietKhau()
        {
            InitializeComponent();
        }

        readonly ChietKhau_TienCong _chietKhauTienCong = new ChietKhau_TienCong();
        DataTable _dtNhanVien = new DataTable();
        DataTable _dtChietKhau = new DataTable();

        private void FrmNhanVien_ChietKhau_Load(object sender, EventArgs e)
        {
            var nv = new C_NhanVien();
            _dtNhanVien = nv.Get_NhanVien(dtgDNhanVien, bvDNhanVien, string.Empty);
            _chietKhauTienCong.Get_CategoryTree(treLoaiDV);
            nv.Get_NhanVien_KB(cboBSChiDinh);
        }

        private void Load_ChiTiet()
        {
            if (dtgDNhanVien == null || dtgDNhanVien.RowCount <= 0 || dtgDNhanVien.CurrentRow == null) return;

            var maNhanVien = dtgDNhanVien.CurrentRow.Cells[MaNhanVien.Name].Value.ToString().Trim();
            if (treLoaiDV == null || treLoaiDV.Nodes.Count <= 0 || treLoaiDV.SelectedNode == null) return;

            string maLoaiDv;
            string maNhom;
            if (treLoaiDV.SelectedNode.Tag != null)
            {
                maLoaiDv = treLoaiDV.SelectedNode.Tag.ToString().Trim();
                maNhom = treLoaiDV.SelectedNode.Name.Trim();
            }
            else
            {
                maLoaiDv = treLoaiDV.SelectedNode.Name.Trim();
                maNhom = string.Empty;
            }

            _dtChietKhau = _chietKhauTienCong.Get_DS_ChietKhau(dtgChietKhau, bvChietKhau, maNhanVien, maLoaiDv, maNhom);
        }

        private void dtgDNhanVien_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_ChiTiet();
        }

        private void treLoaiDV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Load_ChiTiet();
        }

        private void txtTenBacSi_KeyUp(object sender, KeyEventArgs e)
        {
            ProcessServices.Filter_BindingSource(dtgDNhanVien, bvDNhanVien, _dtNhanVien, "TenNhanVien", txtTenBacSi.Text);
        }

        private void radKhamBenh_Click(object sender, EventArgs e)
        {
            txtTenBacSi.Text = string.Empty;
            ProcessServices.Filter_BindingSource(dtgDNhanVien, bvDNhanVien, _dtNhanVien, "KhamChuaBenh", true);
        }

        private void radGui_Click(object sender, EventArgs e)
        {
            txtTenBacSi.Text = string.Empty;
            ProcessServices.Filter_BindingSource(dtgDNhanVien, bvDNhanVien, _dtNhanVien, "GuiChiDinh", true);
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            txtTenBacSi.Text = string.Empty;
            var nv = new C_NhanVien();
            _dtNhanVien = nv.Get_NhanVien(dtgDNhanVien, bvDNhanVien, string.Empty);
        }

        private void txtTenDichVu_KeyUp(object sender, KeyEventArgs e)
        {
            if (dtgChietKhau == null || dtgChietKhau.Rows.Count <= 0)
                return;

            ProcessServices.Filter_BindingSource(dtgChietKhau, 
                bvChietKhau, 
                _dtChietKhau,
                "tendichvu", 
                txtTenDichVu.Text);
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
        }

        private void btnCapNhatCK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text) || treLoaiDV.SelectedNode == null) return;

            var messageQuestion = "Cập nhật chiết khấu cho" +
                                  (chkUpdateForAllDoctor.Checked ? " tất cả " : string.Empty) +
                                  " (Bác Sĩ/nơi gửi) được chọn";
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes(messageQuestion)) return;

            if (dtgDNhanVien.CurrentRow == null) return;

            var maNhanVien = dtgDNhanVien.CurrentRow.Cells[MaNhanVien.Name].Value.ToString().Trim();
            string maLoaiDv;
            string maNhom;
            if (treLoaiDV.SelectedNode.Tag != null)
            {
                maLoaiDv = treLoaiDV.SelectedNode.Tag.ToString().Trim();
                maNhom = treLoaiDV.SelectedNode.Name.Trim();
            }
            else
            {
                maLoaiDv = treLoaiDV.SelectedNode.Name.Trim();
                maNhom = string.Empty;
            }
            
            if (chkUpdateForAllDoctor.Checked)
                maNhanVien = string.Empty;

            if (!_chietKhauTienCong.Update_ChietKhau_PhanTram(maNhanVien, maLoaiDv, maNhom, string.Empty, txtValue.Text))
                return;
            Load_ChiTiet();
            txtValue.Text = "0";
            CustomMessageBox.MSG_Information_OK("Cập nhật hoàn tất!");
        }

        private void txtValue_Enter(object sender, EventArgs e)
        {
            txtValue.SelectAll();
        }

        private void btnCapNhatTC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text) || treLoaiDV.SelectedNode == null) return;

            var messageQuestion = string.Format("Cập nhật tiền công cho {0} (Bác Sĩ/nơi gửi)  được chọn",
                (chkUpdateForAllDoctor.Checked ? "tất cả " : string.Empty));

            if (!CustomMessageBox.MSG_Question_YesNo_GetYes(messageQuestion)) return;

            if (dtgDNhanVien.CurrentRow == null) return;

            var maNhanVien = dtgDNhanVien.CurrentRow.Cells[MaNhanVien.Name].Value.ToString().Trim();
            string maLoaiDv;
            string maNhom;

            if (treLoaiDV.SelectedNode.Tag != null)
            {
                maLoaiDv = treLoaiDV.SelectedNode.Tag.ToString().Trim();
                maNhom = treLoaiDV.SelectedNode.Name.Trim();
            }
            else
            {
                maLoaiDv = treLoaiDV.SelectedNode.Name.Trim();
                maNhom = string.Empty;
            }
            if (chkUpdateForAllDoctor.Checked)
                maNhanVien = string.Empty;
            if (!_chietKhauTienCong.Update_TienCong(maNhanVien, maLoaiDv, maNhom, string.Empty, txtValue.Text)) return;
            Load_ChiTiet();
            txtValue.Text = "0";

            CustomMessageBox.MSG_Information_OK("Cập nhật hoàn tất!");
        }

        private void btnAddNewService_Click(object sender, EventArgs e)
        {
            if (_chietKhauTienCong.CapNhat_DanhMuc_ChiTiet() > -1)
            {
                Load_ChiTiet();
                CustomMessageBox.MSG_Information_OK("Cập nhật hoàn tất!");
            }
        }

        private void dtgChietKhau_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgChietKhau.RowCount <= 0 || dtgChietKhau.CurrentRow == null) return;

            var maNhanVien = dtgChietKhau.CurrentRow.Cells[MaNV.Name].Value.ToString();
            var maNhomDv = dtgChietKhau.CurrentRow.Cells[MaNhomDv.Name].Value.ToString();
            var maLoaiDv = dtgChietKhau.CurrentRow.Cells[MaLoaiDV.Name].Value.ToString();
            var maDichVu = dtgChietKhau.CurrentRow.Cells[MaDoiTuongDichVu.Name].Value.ToString();
            string value;

            if (dtgChietKhau.Columns[e.ColumnIndex].Name.Equals(ChietKhau.Name, StringComparison.OrdinalIgnoreCase))
            {
                value = dtgChietKhau.CurrentRow.Cells[ChietKhau.Name].Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                    value = "0";
                _chietKhauTienCong.Update_ChietKhau_PhanTram(maNhanVien, maLoaiDv, maNhomDv, maDichVu, value);
            }
            else if (dtgChietKhau.Columns[e.ColumnIndex].Name.Equals(TienCong.Name, StringComparison.OrdinalIgnoreCase))
            {
                value = dtgChietKhau.CurrentRow.Cells[TienCong.Name].Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                    value = "0";
                _chietKhauTienCong.Update_TienCong(maNhanVien, maLoaiDv, maNhomDv, maDichVu, value);
            }
        }

        private void txtTenDichVu_TextChanged(object sender, EventArgs e)
        {
            if (bvChietKhau.BindingSource != null)
            {
                bvChietKhau.BindingSource.Filter = string.Format(
                    "TenDichVu like '%{0}%' or MaDichVu like '%{0}%'", 
                    txtTenDichVu.Text);
            }
        }

        private void btnCopyToAll_Click(object sender, EventArgs e)
        {
            if(cboBSChiDinh == null || 
                dtgDNhanVien.CurrentRow == null ||
                treLoaiDV == null ||
                dtgChietKhau == null)
            {
                return;
            }

            var currentIndexDoctor = cboBSChiDinh.SelectedIndex;
            if(currentIndexDoctor == -1)
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn bác sĩ!");
                return;
            }
            if (treLoaiDV.SelectedNode == null)
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn Loại Dịch Vụ!");
                return;
            }

            string maLoaiDv, maNhom;
            var copyFrom = cboBSChiDinh.SelectedValue.ToString();
            var copyTo = chkCopyToAll.Checked ? string.Empty : dtgDNhanVien.CurrentRow.Cells[MaNhanVien.Name].Value.ToString().Trim();

            if (!chkCopyToAll.Checked && copyFrom.Equals(copyTo, StringComparison.OrdinalIgnoreCase))
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn bác sĩ muốn được sao chép Chiết khấu!");
                return;
            }

            var messageQuestion = string.Format("Sao chép tiền công cho {0} (Bác Sĩ/nơi gửi)  được chọn",
                (chkCopyToAll.Checked ? "tất cả " : string.Empty));

            if (!CustomMessageBox.MSG_Question_YesNo_GetYes(messageQuestion)) return;
            
            if (treLoaiDV.SelectedNode.Tag != null)
            {
                maLoaiDv = treLoaiDV.SelectedNode.Tag.ToString().Trim();
                maNhom = treLoaiDV.SelectedNode.Name.Trim();
            }
            else
            {
                maLoaiDv = treLoaiDV.SelectedNode.Name.Trim();
                maNhom = string.Empty;
            }

            if (!_chietKhauTienCong.SaoChepChietKhau(copyFrom, copyTo, maLoaiDv, maNhom, string.Empty)) return;

            Load_ChiTiet();
            txtValue.Text = "0";

            CustomMessageBox.MSG_Information_OK("Cập nhật hoàn tất!");
        }
    }
}