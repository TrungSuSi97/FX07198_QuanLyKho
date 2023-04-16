using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucKhamBenh
{
    public partial class FrmDanhMuc_DichVu_KhamBenh : FrmTemplate
    {
        public FrmDanhMuc_DichVu_KhamBenh()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        DataTable dtNhom = new DataTable();
        SqlDataAdapter daNhom = new SqlDataAdapter();
        DataTable dtDichVu = new DataTable();
        SqlDataAdapter daDichVu = new SqlDataAdapter();
        private void FrmDanhMuc_DichVu_KhamBenh_Load(object sender, EventArgs e)
        {
            Load_DSNhom();
        }

        private void Add_Nhom()
        {
            if (txtMaNhom.Text.Trim() == "")
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã nhóm !");
                txtMaNhom.Focus();
            }
            else if (txtTenNhom.Text.Trim() == "")
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập tên nhóm !");
                txtTenNhom.Focus();
            }
            else
            {
                if (txtThuTuInNhom.Text == "")
                    txtThuTuInNhom.Text = "0";
                if (sysConfig.Insert_DM_KhamBenh_NhomDichVu(txtMaNhom.Text.Trim(), txtTenNhom.Text.Trim(), txtThuTuInNhom.Text.Trim()))
                {
                    Load_DSNhom();
                    LabServices_Helper.Select_FoundRow(dtgDichVu, MaNhomDichVu.Name, txtMaNhom.Text);
                    txtMaNhom.Text = "";
                    txtTenNhom.Text = "";
                    txtThuTuInNhom.Text = "0";
                }
            }
        }
        private void Load_DSNhom()
        {
            sysConfig.Get_DM_KhamBenh_NhomDichVu(daNhom, dtgNhom, bvNhom, "", ref dtNhom);
        }

        private void Load_DSDichVu()
        {
            string _MaNhom = "";
            if (dtgNhom.RowCount > 0)
            {
                _MaNhom = dtgNhom.CurrentRow.Cells[MaNhomDichVu.Name].Value.ToString();
            }
            sysConfig.Get_DM_KhamBenh_DichVu(daDichVu, dtgDichVu, bvDichVu, "", _MaNhom, ref dtDichVu);
        }

        private void dtgNhom_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_DSDichVu();
        }

        private void txtMaNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtThuTuInNhom);
        }

        private void txtThuTuInNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            LabServices_Helper.LeaveFocusNext(e, txtTenNhom);
        }

        private void txtTenNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnAddNhom);
        }

        private void btnAddNhom_Click(object sender, EventArgs e)
        {
            Add_Nhom();
        }

        private void dtgNhom_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daNhom, ref dtNhom, dtgNhom, "", "");
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (dtgNhom.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa nhóm dịch vụ đang chọn?\nLưu ý: Các dịch vụ của nhóm sẽ bị xóa theo."))
                {
                    bvNhom.BindingSource.RemoveCurrent();
                    Load_DSNhom();
                }
            }
        }

        //Dịch vụ
        private void Insert_DichVu()
        {
            if (dtgNhom.RowCount > 0)
            {
                if (txtmaDichVu.Text.Trim() == "")
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập mã dịch vụ !");
                    txtMaNhom.Focus();
                }
                else if (txtTenDichVu.Text.Trim() == "")
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập tên dịch vụ !");
                    txtMaNhom.Focus();
                }
                else
                {
                    if (txtGiaChuan.Text == "")
                        txtGiaChuan.Text = "0";
                   string _MaNhom = dtgNhom.CurrentRow.Cells[MaNhomDichVu.Name].Value.ToString();
                   if (sysConfig.Insert_KhamBenh_DichVu(_MaNhom, txtmaDichVu.Text, txtTenDichVu.Text, txtGhiChu.Text, txtDeNghi.Text, txtGiaChuan.Text))
                   {
                       Load_DSDichVu();
                       txtmaDichVu.Text = txtTenDichVu.Text = txtDeNghi.Text = txtGhiChu.Text = "";
                       txtGiaChuan.Text = "0";
                   }

                }
            }
        }

        private void txtGiaChuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            LabServices_Helper.LeaveFocusNext(e, txtDeNghi);
        }

        private void btnRefreshDichVu_Click(object sender, EventArgs e)
        {
            Load_DSDichVu();
        }

        private void btnRefreshNhom_Click(object sender, EventArgs e)
        {
            Load_DSNhom();
        }

        private void dtgDichVu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daDichVu, ref dtDichVu, dtgDichVu, "", "");
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (dtgDichVu.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa dịch vụ đang chọn?\nLưu ý: Việc xóa có thể ảnh hưởng thống kê"))
                {
                    bvDichVu.BindingSource.RemoveCurrent();
                    Load_DSDichVu();
                }
            }
        }

        private void txtmaDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenDichVu);
        }

        private void txtTenDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGhiChu);
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGiaChuan);
        }

        private void txtDeNghi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnAddDichVu);
        }

        private void btnAddDichVu_Click(object sender, EventArgs e)
        {
            Insert_DichVu();
        }
    }
}
