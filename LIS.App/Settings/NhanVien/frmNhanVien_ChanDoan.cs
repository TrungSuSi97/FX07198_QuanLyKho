using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.NhanVien
{
    public partial class frmNhanVien_ChanDoan : FrmTemplate
    {
        public frmNhanVien_ChanDoan()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService iConfig = new SystemConfigService();
        C_NhanVien data = new C_NhanVien();
        private void btnRefreshBacSi_Click(object sender, EventArgs e)
        {
            Load_BacSi();
        }

        private void btnAddBacSi_Click(object sender, EventArgs e)
        {
            if (txtMaBacSi.Text != "")
            {
                if (!string.IsNullOrEmpty(txtBacSi.Text))
                {
                    if (cboNhomNhanVien.SelectedIndex > -1)
                    {
                        var obj = new QL_NHANVIEN() { Manhanvien = txtMaBacSi.Text, Tennhanvien = txtBacSi.Text, Nhomnhanvien = (cboNhomNhanVien.SelectedValue ?? (object)string.Empty).ToString() };
                        var i = iConfig.Insert_ql_nhanvien(obj);
                        if (i.Id > -1)
                        {
                            txtMaBacSi.Text = "";
                            txtBacSi.Text = "";
                            Load_BacSi();
                        }
                        else
                            CustomMessageBox.MSG_Information_OK(i.Name);
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Hãy chọn nhóm.");
                }
            }
        }
        private void Load_BacSi()
        {
            var data = iConfig.Data_ql_nhanvien(string.Empty, string.Empty);
            WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcNhanVien.DataSource = data;
            gvNhanVien.ExpandAllGroups();
        }

        private void LoadDSNhomNhanVien()
        {
            var data = iConfig.Data_dm_nhomnhanvien();
            ControlExtension.BindDataToCobobox(data, ref cboNhomNhanVien, "MaNhomNhanVien", "MaNhomNhanVien", "MaNhomNhanVien, TenNhomNhanVien", "50,150");
        }
        private void frmBacSi_ChanDoan_Load(object sender, EventArgs e)
        {
            ControlExtension.SetLowerCaseForXGridColumns(gvNhanVien);
            Load_BoPhan();
            Load_Phong();
            LoadDSNhomNhanVien();
            Load_BacSi();
            Load_DSCTV();
        }
        private void Load_BoPhan()
        {
            repositoryItemGridLookUpEditDonVi.DataSource = iConfig.Data_dm_bophan(string.Empty, string.Empty);
        }
        private void Load_Phong()
        {
            repositoryItemGridLookUpEditPhong.DataSource = iConfig.Data_dm_nhomnhanvien();
            gridView1.ExpandAllGroups();
        }
        private void txtMaBacSi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtBacSi);
        }

        private void txtBacSi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboNhomNhanVien);
        }

        private void btnXoaBacSi_Click(object sender, EventArgs e)
        {
            if (gvNhanVien.FocusedRowHandle > -1)
            {
                var maNv = gvNhanVien.GetFocusedRowCellValue(colMaNhanVien).ToString();
                if (!string.IsNullOrEmpty(maNv))
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes($"Xóa nhân viên \"{maNv}\" đang chọn?"))
                    {
                        iConfig.Delete_ql_nhanvien(new QL_NHANVIEN() { Manhanvien = maNv });
                        Load_BacSi();
                    }
                }
            }
        }
        private void Load_DSCTV()
        {
            //    var data = iConfig.Data_dm_congtacvien(string.Empty);
            //    ControlExtension.BindDataToGrid(data, ref dtgDSCongTacVien, ref bvDSCongTacVien);
        }
        private void ThemCTV()
        {
            //if (string.IsNullOrEmpty(txtMaCTV.Text))
            //    CustomMessageBox.MSG_Information_OK("Hãy nhập mã CTV");
            //else if (string.IsNullOrEmpty(txtTenCTV.Text))
            //    CustomMessageBox.MSG_Information_OK("Hãy nhập tên CTV");
            //else
            //{
            //    var obj = new DM_CONGTACVIEN()
            //    {
            //        Macongtacvien = txtMaCTV.Text,
            //        Tencongtacvien = txtTenCTV.Text,
            //        Nguoinhap = CommonAppVarsAndFunctions.UserID
            //    };
            //    if (iConfig.Insert_dm_congtacvien(obj) > -1)
            //    {
            //        txtMaCTV.Text = string.Empty;
            //        txtTenCTV.Text = string.Empty;

            //        Load_DSCTV();
            //        txtMaCTV.Focus();
            //    }
            //}
        }
        private void CapNhatCTV()
        {
            //if(dtgDSCongTacVien.CurrentRow != null)
            //{
            //    var obj = iConfig.Get_Info_dm_congtacvien(dtgDSCongTacVien.CurrentRow.Cells[colMaCongTacVien.Name].ToString());
            //    obj.Tencongtacvien = dtgDSCongTacVien.CurrentRow.Cells[colTenCongTacVien.Name].ToString();
            //    obj.Diachicongtacvien = dtgDSCongTacVien.CurrentRow.Cells[colDiaChiCongTacVien.Name].ToString();
            //    obj.Emailcongtacvien = dtgDSCongTacVien.CurrentRow.Cells[colEmailCongTacVien.Name].ToString();
            //    obj.Dienthoaicongtacvien = dtgDSCongTacVien.CurrentRow.Cells[colDiaChiCongTacVien.Name].ToString();
            //    obj.Congtacvienchietkhau = float.Parse(string.IsNullOrEmpty(dtgDSCongTacVien.CurrentRow.Cells[colCongTacVienChietKhau.Name].ToString()) ? "0" : (dtgDSCongTacVien.CurrentRow.Cells[colCongTacVienChietKhau.Name].ToString()));
            //    obj.Ngungcongtac = bool.Parse(dtgDSCongTacVien.CurrentRow.Cells[colNgungCongTac.Name].ToString());
            //    obj.Nguoisua = CommonAppVarsAndFunctions.UserID;
            //    iConfig.Update_dm_congtacvien(obj);
            //}
        }
        private void XoaCTV()
        {
            //if (dtgDSCongTacVien.CurrentRow != null)
            //{
            //    if(CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa cộng tác viên đang chọn?"))
            //    {
            //        var mactv = dtgDSCongTacVien.CurrentRow.Cells[colMaCongTacVien.Name].ToString();
            //        iConfig.Delete_dm_congtacvien(mactv);
            //        Load_DSCTV();
            //    }
            //}
        }
        private void btnLamMoiCTV_Click(object sender, EventArgs e)
        {
            Load_DSCTV();
        }

        private void btnThemCTV_Click(object sender, EventArgs e)
        {
            ThemCTV();
        }

        private void btnXoaCTV_Click(object sender, EventArgs e)
        {
            XoaCTV();
        }

        private void dtgDSCongTacVien_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CapNhatCTV();
        }

        private void btnTimCTV_KeyUp(object sender, KeyEventArgs e)
        {
            //if (bvDSCongTacVien.BindingSource != null)
            //{
            //    if (string.IsNullOrEmpty(btnTimCTV.Text))
            //    {
            //        bvDSCongTacVien.BindingSource.Filter = string.Empty;
            //    }
            //    else
            //        bvDSCongTacVien.BindingSource.Filter = string.Format("MaCongTacVien  = '{0}' or TenCongTacVien like '%{0}%'", WorkingServices.EscapeLikeValue(btnTimCTV.Text));
            //}
        }

        private void gvNhanVien_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                var obj = iConfig.Get_Info_ql_nhanvien(gvNhanVien.GetRowCellValue(e.RowHandle, colMaNhanVien).ToString(), string.Empty);
                obj.Tennhanvien = gvNhanVien.GetRowCellValue(e.RowHandle, colTenNhanVien).ToString();
                obj.Danghi = bool.Parse(gvNhanVien.GetRowCellValue(e.RowHandle, colDaNghi).ToString());
                obj.Diachi = gvNhanVien.GetRowCellValue(e.RowHandle, colDiaChi).ToString();
                obj.Dienthoai = gvNhanVien.GetRowCellValue(e.RowHandle, colDienThoai).ToString();
                obj.MaBoPhan = StringConverter.ToString(gvNhanVien.GetRowCellValue(e.RowHandle, colBoPhan));
                obj.Maphong = gvNhanVien.GetRowCellValue(e.RowHandle, colChucVu).ToString();
                obj.Nguoisua = CommonAppVarsAndFunctions.UserID;
                iConfig.Update_ql_nhanvien(obj);
            }
        }

        private void repositoryItemGridLookUpEditPhong_Popup(object sender, EventArgs e)
        {
            var gridLookUp = (GridLookUpEdit)sender;
            if (gvNhanVien.FocusedRowHandle > -1)
            {
                //var makhoa = StringConverter.ToString(gvNhanVien.GetRowCellValue(gvNhanVien.FocusedRowHandle, colBoPhan)) ;
                //if (!string.IsNullOrEmpty(makhoa))
                //    gridLookUp.Properties.View.Columns[lukPhong_makhoaphong.VisibleIndex].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("{0} = '{1}'", lukPhong_makhoaphong.FieldName, makhoa));
                //else
                //    gridLookUp.Properties.View.Columns[lukPhong_makhoaphong.VisibleIndex].ClearFilter();
            }
            gridLookUp.Properties.View.ExpandAllGroups();
        }
    }
}
