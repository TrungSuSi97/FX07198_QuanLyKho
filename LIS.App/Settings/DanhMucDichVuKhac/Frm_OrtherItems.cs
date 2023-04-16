using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucDichVuKhac
{
    public partial class Frm_OrtherItems : FrmTemplate
    {
        public Frm_OrtherItems()
        {
            InitializeComponent();
        }
        
        SqlDataAdapter daNhom = new SqlDataAdapter();
        SqlDataAdapter daDichVu = new SqlDataAdapter();
        DataTable dtNhom = new DataTable();
        DataTable dtDichVu = new DataTable();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        #region Nhom
        private void Load_Nhom()
        {
            sysConfig.Get_DM_NHOMCLS_DVKHAC(daNhom, dtgNhom, bvNhom, "", ref dtNhom);
        }
        private void Insert_Nhom()
        {
            if (txtMaNhom.Text == "")
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã nhóm !");
            }
            else if (cboMauKQ.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn mẫu phiếu kết quả !");
            }
            else
            {
                if (sysConfig.Insert_DM_NhomCLS_DVKhac(txtMaNhom.Text.Trim(), txtTenNhom.Text.Trim(), cboMauKQ.SelectedValue.ToString().Trim()))
                {
                    Load_Nhom();
                    CustomMessageBox.MSG_Information_OK("Thêm mới hoàn tất !");
                }
            }
        }

        private void Delete_Nhom()
        {
            if (dtgNhom.RowCount > 0)
            {
                string _MaNhomCLS = dtgNhom.CurrentRow.Cells[MaNhomCLS.Name].Value.ToString();

                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa nhóm \"" + _MaNhomCLS + "\" đang chọn?"))
                {
                    if (LabServices_Helper.Check_NotExits("select * from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac where MaNhomCLS ='" + _MaNhomCLS + "'"))
                    {
                       dtgNhom.Rows.RemoveAt(bvNhom.BindingSource.Position);
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Nhóm đang sử dụng !\nKhông thể xóa.");
                    }
                }
            }
        }

        private void dtgNhom_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daNhom, ref dtNhom, dtgNhom, "", "");
        }

        private void txtThemNhom_Click(object sender, EventArgs e)
        {
            Insert_Nhom();
        }
        private void btnMaNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenNhom);
        }

        private void txtTenNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboMauKQ);
        }

        private void cboMauKQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemNhom);
        }   
        private void Load_MauKQ()
        {
            sysConfig.GET_DS_MAU_KQ(cboMauKQ, txtMauKetQua);
            sysConfig.GET_DS_MAU_KQ(MauKQ);
        }

        private void btnDeleteNhom_Click(object sender, EventArgs e)
        {
            Delete_Nhom();
        }
        #endregion

        private void Start_AddMode()
        {
            Clear_DetailControl();
            Lock_DetailControl(false);
            btnLuuDV.Enabled = true;
            txtMaDichVu.BackColor = Color.Yellow;
            txtMaDichVu.Focus();
        }
        private void Insert_New_Detail()
        {
            if (dtgNhom.RowCount > 0)
            {
                string _maNhomCLS = dtgNhom.CurrentRow.Cells[MaNhomCLS.Name].Value.ToString().Trim();
                if (txtMaDichVu.Text == "")
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập mã dịch vụ");
                }
                else
                {
                    if (sysConfig.Insert_DM_DichVuKhac(txtDeNghi.Text, txtGhiChu.Text, txtGiaChuan.Text, txtMaDichVu.Text, _maNhomCLS, rchMauKetQua.Rtf, txtTenDichVu.Text, txtThuTuIn.Text))
                    {
                        string _maDV = txtMaDichVu.Text.Trim();
                        Load_DM_ChiTiet();
                        LabServices_Helper.Select_Row(dtgDichVu, bvDichVu, madvkhac.Name, _maDV);

                        CustomMessageBox.MSG_Information_OK("Thêm mới hoàn tất !");
                    }
                }
            }
        }

        private void Start_EditMode()
        {
            Lock_DetailControl(false); 
            txtMaDichVu.ReadOnly = true;
            btnLuuDV.Enabled = true;
            txtMaDichVu.BackColor = Color.LightGreen;
            txtTenDichVu.Focus();
        }
        private void SaveEdit_Detail()
        {
            if (dtgNhom.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu thông tin đã sửa?"))
                {
                    string _maNhomCLS = dtgNhom.CurrentRow.Cells[MaNhomCLS.Name].Value.ToString().Trim();
                    if (sysConfig.Update_DM_DICHVUKHAC(txtDeNghi.Text, txtGhiChu.Text, txtGiaChuan.Text, txtMaDichVu.Text, _maNhomCLS, rchMauKetQua.Rtf, CommonAppVarsAndFunctions.UserID, txtTenDichVu.Text, txtThuTuIn.Text))
                    {
                        string _maDV = txtMaDichVu.Text.Trim();
                        Load_DM_ChiTiet();
                        LabServices_Helper.Select_Row(dtgDichVu, bvDichVu, madvkhac.Name, _maDV);

                        CustomMessageBox.MSG_Information_OK("Cập nhật hoàn tất !");
                    }
                }
            }
        }
        private void Delete_DichVu(string _MaDichVu)
        {
            if (LabServices_Helper.Check_NotExits("Select * from KetQua_CLS_DVKhac where [MaDVKhac] ='" + _MaDichVu.Trim() + "'"))
            {
                if (sysConfig.Delete_DM_DICHVUKHAC(_MaDichVu))
                {
                    Load_DM_ChiTiet();
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Dịch vụ đang sử dụng !\nKhông thể xóa.");
            }
        }
        private void Load_DM_ChiTiet()
        {
            string _Manhom = "";
            if (dtgNhom.RowCount > 0)
            {
                _Manhom = dtgNhom.CurrentRow.Cells[MaNhomCLS.Name].Value.ToString();
            }
            sysConfig.Get_DM_DICHVUKHAC(daDichVu, dtgDichVu, bvDichVu, " and MaNhomCLS ='" + _Manhom + "'", ref dtDichVu);
            Bind_Data(bvDichVu.BindingSource);
            Lock_DetailControl(true);

            btnSuaDV.Enabled = btnXoaDV.Enabled = (dtgDichVu.RowCount > 0);
            btnLuuDV.Enabled = false;
        }

        private void Clear_DetailControl()
        {
            txtMaDichVu.BackColor = SystemColors.Control;
            txtMaDichVu.DataBindings.Clear();
            txtMaDichVu.Text = "";

            txtTenDichVu.DataBindings.Clear();
            txtTenDichVu.Text = "";

            txtDeNghi.DataBindings.Clear();
            txtDeNghi.Text = "";

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.Text = "";

            txtGiaChuan.DataBindings.Clear();
            txtGiaChuan.Text = "0";

            rchMauKetQua.DataBindings.Clear();
            rchMauKetQua.Rtf = "";

            txtThuTuIn.DataBindings.Clear();
            txtThuTuIn.Text = "0";
            
        }
        private void Bind_Data(BindingSource bs)
        {
            Clear_DetailControl();

            txtMaDichVu.DataBindings.Add("Text", bs, "MaDVKhac");
            txtTenDichVu.DataBindings.Add("Text", bs, "TenDVKhac");
            txtDeNghi.DataBindings.Add("Text", bs, "DeNghi");
            txtGhiChu.DataBindings.Add("Text", bs, "GhiChu");
            txtGiaChuan.DataBindings.Add("Text", bs, "GiaChuan");
            txtThuTuIn.DataBindings.Add("Text", bs, "ThuTuIn");
            rchMauKetQua.DataBindings.Add("Rtf", bs, "MauKetQua");
        }
        private void Lock_DetailControl(bool _isLock)
        {
            txtMaDichVu.ReadOnly = _isLock;
            txtTenDichVu.ReadOnly = _isLock;

            txtDeNghi.ReadOnly = _isLock;
            txtGhiChu.ReadOnly = _isLock;
            txtGiaChuan.ReadOnly = _isLock;
            txtThuTuIn.ReadOnly = _isLock;
            rchMauKetQua.Enabled = !_isLock;
        }
        private void Frm_OrtherItems_Load(object sender, EventArgs e)
        {
            Load_MauKQ();
            Load_Nhom();
        }

        private void btnLuuDV_Click(object sender, EventArgs e)
        {
            if (dtgNhom.RowCount > 0)
            {
                if (txtMaDichVu.BackColor == Color.Yellow)
                {
                    Insert_New_Detail();
                }
                else if (txtMaDichVu.BackColor == Color.LightGreen)
                {
                    SaveEdit_Detail();
                }
            }
        }

        private void dtgNhom_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_DM_ChiTiet();
        }

        private void btnThemMoiDV_Click(object sender, EventArgs e)
        {
            if (dtgNhom.RowCount > 0)
                Start_AddMode();
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (dtgDichVu.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa dịch vụ đang chọn?"))
                {
                    Delete_DichVu(dtgDichVu.CurrentRow.Cells[madvkhac.Name].Value.ToString().Trim());
                }
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            Start_EditMode();
        }

        private void txtMaDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenDichVu);
        }

        private void txtTenDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGhiChu);
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtDeNghi);
        }

        private void txtDeNghi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGiaChuan);
        }

        private void txtGiaChuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtThuTuIn);
        }

        private void txtThuTuIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtMauKetQua);
        }
    }
}
