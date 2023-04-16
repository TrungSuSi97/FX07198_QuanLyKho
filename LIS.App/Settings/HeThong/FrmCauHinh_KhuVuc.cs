using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;
using System.Data;
using TPH.LIS.Data;
using TPH.LIS.Common.Controls;
using TPH.Data.HIS.HISDataCommon;
using System.Linq;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmCauHinh_KhuVuc : FrmTemplate
    {
        public FrmCauHinh_KhuVuc()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _iConfigurationService = new SystemConfigService();
        private SqlDataAdapter sqlDaKhuVuc = new SqlDataAdapter();
        private DataTable dataKhuVuc = new DataTable();

        private SqlDataAdapter sqlKhuLayMau = new SqlDataAdapter();
        private DataTable dataKhuLayMau = new DataTable();


        private SqlDataAdapter sqlDaMayTinhKhuVuc = new SqlDataAdapter();
        private DataTable dataMayTinhKhuVuc = new DataTable();

        private SqlDataAdapter sqlDaMayTinh = new SqlDataAdapter();
        private DataTable dataMayTinh = new DataTable();
    
        private void FrmCauHinh_KhuVuc_Load(object sender, EventArgs e)
        {
            dtgKhuLayMau.AutoResizeColumns();
            txtTenMayTinh.Text = Environment.MachineName;
            Load_HisProvider();
            Load_DanhMucKhuVuc();
            Load_KhuLayMau();
            Load_DanhMucMayTinhTheoKhuvuc();
        }
        private void Load_KhuLayMau()
        {
            dtgKhuLayMau.DataBindingComplete -= dtgKhuLayMau_DataBindingComplete;
            _iConfigurationService.Get_Data_dm_khulaymau(dtgKhuLayMau, bvKhuXetLayMau, ref sqlKhuLayMau, ref dataKhuLayMau, string.Empty, string.Empty);
            dtgKhuLayMau.DataBindingComplete += dtgKhuLayMau_DataBindingComplete;
            Load_KhulayMauToCombobox();
        }
        private void Load_KhulayMauToCombobox()
        {
            var data = dataKhuLayMau.Copy();
            var row = data.NewRow();
            row["IDKhuLayMau"] = DBNull.Value;
            row["TenKhuLayMau"] = "---Không lấy mẫu---";
            data.Rows.InsertAt(row, 0);
            data.AcceptChanges();

            colMayTinhKhuVuc_KhuLayMau.DataSource = data.Copy();
            colMayTinhKhuVuc_KhuLayMau.ValueMember = "IDKhuLayMau";
            colMayTinhKhuVuc_KhuLayMau.DisplayMember = "TenKhuLayMau";

            cboKhuLayMau.DataSource = data.Copy();
            cboKhuLayMau.ValueMember = "IDKhuLayMau";
            cboKhuLayMau.DisplayMember = "TenKhuLayMau";
            cboKhuLayMau.SelectedIndex = 0;
        }
        private void Load_HisProvider()
        {
            var list = CommonData.GetEnumValuesAndDescriptions<HisProvider>().Where(x => CommonAppVarsAndFunctions.allWorkingHis.Contains(x.Key) || x.Key == 0);
            colHisProvider.DataSource = list.ToList();
            colHisProvider.ValueMember = "Key";
            colHisProvider.DisplayMember = "Value";
        }
        #region Danh mục khu vực
        private void Load_DanhMucKhuVuc()
        {
            dgvKhuVuc.DataBindingComplete -= dgvKhuVuc_DataBindingComplete;
            _iConfigurationService.Get_Data_dm_khuvuc(dgvKhuVuc, bvKhuVuc, ref sqlDaKhuVuc, ref dataKhuVuc, string.Empty);
            dgvKhuVuc.DataBindingComplete += dgvKhuVuc_DataBindingComplete;

            Load_KhuVucToCombobox();
            Load_DSMayTinh();
        }
        private void Load_KhuVucToCombobox()
        {
            var data = dataKhuVuc.Copy();
            var row = data.NewRow();
            row["MaKhuVuc"] = DBNull.Value;
            row["TenKhuVuc"] = "--- Chọn khu vực làm việc---";
            data.Rows.InsertAt(row, 0);
            data.AcceptChanges();

            cboMayTinh_KhuLamViec.DataSource = dataKhuVuc.Copy();
            cboMayTinh_KhuLamViec.DisplayMember = "TenKhuVuc";
            cboMayTinh_KhuLamViec.ValueMember = "MaKhuVuc";
            cboMayTinh_KhuLamViec.SelectedIndex = -1;

            colMayTinhKhuVuc_MaKhuVuc.DataSource = data.Copy();
            colMayTinhKhuVuc_MaKhuVuc.DisplayMember = "TenKhuVuc";
            colMayTinhKhuVuc_MaKhuVuc.ValueMember = "MaKhuVuc";

            colMayTinh_KhuVucChinh.DataSource = data.Copy();
            colMayTinh_KhuVucChinh.DisplayMember = "TenKhuVuc";
            colMayTinh_KhuVucChinh.ValueMember = "MaKhuVuc";

            colLayMau_KhuXN.DataSource = data.Copy();
            colLayMau_KhuXN.DisplayMember = "TenKhuVuc";
            colLayMau_KhuXN.ValueMember = "MaKhuVuc";

            cboKhuLamviec.DataSource = data.Copy();
            cboKhuLamviec.DisplayMember = "TenKhuVuc";
            cboKhuLamviec.ValueMember = "MaKhuVuc";
        }
        private void dgvKhuVuc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dtAddNew = dataKhuVuc.GetChanges(DataRowState.Added);
            if (dgvKhuVuc.CurrentCell == null)
            {
                DataProvider.UpdateData(sqlDaKhuVuc, ref dataKhuVuc, string.Empty, string.Empty);
            }
            else
            {
                Point p = new Point(dgvKhuVuc.CurrentCell.RowIndex, dgvKhuVuc.CurrentCell.ColumnIndex);
                DataProvider.UpdateData(sqlDaKhuVuc, ref dataKhuVuc, string.Empty, string.Empty);
                if (dtAddNew != null)
                {
                    Load_DanhMucKhuVuc();
                    dgvKhuVuc.CurrentCell = dgvKhuVuc[p.Y, p.X];
                }
            }
        }
        private void btnKhuVucXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhuVuc.CurrentRow != null)
            {
                var obj = new Configuration.Models.DM_KHUVUC(dgvKhuVuc.CurrentRow.Cells[colMaKhuVuc.Name].Value.ToString()
                        , dgvKhuVuc.CurrentRow.Cells[colTenKhuVuc.Name].Value.ToString(),
                        0, 0, "", false, 0);
                if (string.IsNullOrEmpty(obj.Makhuvuc))
                    CustomMessageBox.MSG_Error_OK("Không có khu vực được chọn !");
                else if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa khu vực: {0} ?", obj.Tenkhuvuc)))
                {
                    _iConfigurationService.Delete_dm_khuvuc(obj);
                    Load_DanhMucKhuVuc();
                }
            }
        }
        private void btnKhuVucXemMoi_Click(object sender, EventArgs e)
        {
            Load_DanhMucKhuVuc();
        }
        #endregion
        #region Danh mục máy tính theo khu vực
        private void Load_DanhMucMayTinhTheoKhuvuc()
        {
          //  string maKhuVuc = dgvKhuVuc.CurrentRow != null ? dgvKhuVuc.CurrentRow.Cells[colMaKhuVuc.Name].Value.ToString().Trim() : string.Empty;
            string pcName = dtgMayTinh.CurrentRow != null ? dtgMayTinh.CurrentRow.Cells[colMayTinh_TenMayTinh.Name].Value.ToString() : string.Empty;
            _iConfigurationService.Get_Data_dm_khuvuc_maytinh(dgvMayTinhTheoKhuVuc, bvMayTinhTheoKhuVuc, ref sqlDaMayTinhKhuVuc, ref dataMayTinhKhuVuc, string.Empty, string.Empty, pcName);
        }

        private void btnThemMayTinhKhuVuc_Click(object sender, EventArgs e)
        {
            if (dtgMayTinh.CurrentRow != null)
            {
                var tenmaytinh = dtgMayTinh.CurrentRow.Cells[colMayTinh_TenMayTinh.Name].Value.ToString();
                if (cboKhuLamviec.SelectedIndex > 0)
                {
                    var khuvuc = cboKhuLamviec.SelectedValue.ToString();
                    var obj = new DM_KHUVUC_MAYTINH();
                    obj.Makhuvuc = khuvuc;
                    obj.Tenmaytinh = tenmaytinh;
                    obj.Idkhulaymau = cboKhuLayMau.SelectedValue.ToString();
                    if (_iConfigurationService.Insert_dm_khuvuc_maytinh(obj).Id > 0)
                        Load_DanhMucMayTinhTheoKhuvuc();
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập máy tính và chọn khu lấy mẫu.");
                    txtTenMayTinh.Focus();
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn khu vực.");
        }
        private void btnMayTinhTheoKhucVucXoa_Click(object sender, EventArgs e)
        {
            if (dgvMayTinhTheoKhuVuc.CurrentRow != null)
            {
                var obj = new DM_KHUVUC_MAYTINH();
                obj.Id = int.Parse(dgvMayTinhTheoKhuVuc.CurrentRow.Cells[colMayTinh_KhuVuc_ID.Name].Value.ToString());
                obj.Tenmaytinh = dgvMayTinhTheoKhuVuc.CurrentRow.Cells[colTenMayTinh.Name].Value.ToString();
                obj.Makhuvuc = dgvMayTinhTheoKhuVuc.CurrentRow.Cells[colMayTinhKhuVuc_MaKhuVuc.Name].Value.ToString();
                obj.Idkhulaymau = dgvMayTinhTheoKhuVuc.CurrentRow.Cells[colMayTinhKhuVuc_KhuLayMau.Name].Value.ToString();
                if (string.IsNullOrEmpty(obj.Tenmaytinh))
                    CustomMessageBox.MSG_Error_OK("Không có máy tính được chọn !");
                else if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa máy tính: {0} ?", obj.Tenmaytinh)))
                {
                    _iConfigurationService.Delete_dm_khuvuc_maytinh(obj);
                    Load_DanhMucMayTinhTheoKhuvuc();
                }
            }
        }

        private void btnMayTinhTheoKhuVucXemMoi_Click(object sender, EventArgs e)
        {
            Load_DanhMucMayTinhTheoKhuvuc();
        }
        private void dgvMayTinhTheoKhuVuc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id =  int.Parse(dgvMayTinhTheoKhuVuc.CurrentRow.Cells[colMayTinh_KhuVuc_ID.Name].Value.ToString());
            var objupdate = _iConfigurationService.Get_Info_dm_khuvuc_maytinh(id.ToString(), string.Empty, string.Empty);
            objupdate.Mota = dgvMayTinhTheoKhuVuc[colMoTa.Name, e.RowIndex].Value.ToString();
            objupdate.Hisproviderid = int.Parse(dgvMayTinhTheoKhuVuc[colHisProvider.Name, e.RowIndex].Value.ToString());
            objupdate.Idkhulaymau = dgvMayTinhTheoKhuVuc.CurrentRow.Cells[colMayTinhKhuVuc_KhuLayMau.Name].Value.ToString();
            _iConfigurationService.Update_dm_khuvuc_maytinh(objupdate);
        }
        #endregion

        private void txtSearchMayTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtSearchMayTinh.Text))
                {
                    bvMayTinh.BindingSource.Filter = null;
                }
                else
                    bvMayTinh.BindingSource.Filter = string.Format("TenMayTinh like '%{0}%'", WorkingServices.EscapeLikeValue(txtSearchMayTinh.Text));
            }
        }

        private void txtMakhulamviec_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenKhulamviec);
        }

        private void txtMaKhuLaymau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenKhulamviec);
        }

        private void txtTenKhulamviec_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnThemKhuVuc);
        }

        private void txttenKhuLaymau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnThemKhuLayMau);
        }

        private void txtTenMayTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboMayTinh_KhuLamViec);
        }

        private void cboMayTinh_KhuLamViec_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnThemMayTinh);
        }

        private void cboKhuLamviec_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboKhuLayMau);
        }

        private void cboKhuLayMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnThemmayTinhKhuVuc);
        }

        private void btnThemKhuVuc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenKhulamviec.Text) && !string.IsNullOrEmpty(txtMakhulamviec.Text))
            {
                var objKhuLamViec = new DM_KHUVUC();
                objKhuLamViec.Makhuvuc = txtMakhulamviec.Text;
                objKhuLamViec.Tenkhuvuc = txtTenKhulamviec.Text;
                _iConfigurationService.Insert_dm_khuvuc(objKhuLamViec);
                Load_DanhMucKhuVuc();
                txtMakhulamviec.Text = string.Empty;
                txtTenKhulamviec.Text = string.Empty;
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nập đủ thông tin mã và tên nơi làm việc.");
        }

        private void btnThemKhuLayMau_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKhuLaymau.Text) && !string.IsNullOrEmpty(txttenKhuLaymau.Text))
            {
                var obj = new DM_KHULAYMAU();
                obj.Makhuvuc = dgvKhuVuc.CurrentRow != null ? dgvKhuVuc.CurrentRow.Cells[colMaKhuVuc.Name].Value.ToString() : string.Empty;
                obj.Idkhulaymau = txtMaKhuLaymau.Text;
                obj.Tenkhulaymau = txttenKhuLaymau.Text;
                _iConfigurationService.Insert_dm_khulaymau(obj);
                Load_KhuLayMau();
                txtMaKhuLaymau.Text = string.Empty;
                txttenKhuLaymau.Text = string.Empty;
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nập đủ thông tin mã và tên khu lấy mẫu.");
        }

        private void dtgKhuLayMau_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(sqlKhuLayMau, ref dataKhuLayMau, string.Empty, string.Empty);
        }

        private void btnLoadKhuLayMau_Click(object sender, EventArgs e)
        {
            Load_KhuLayMau();
        }

        private void Load_DSMayTinh()
        {
            dtgMayTinh.CellEnter -= dtgMayTinh_CellEnter;
            var khulamviec = string.Empty;

            if(dgvKhuVuc.CurrentRow !=null)
            {
                khulamviec = dgvKhuVuc.CurrentRow.Cells[colMaKhuVuc.Name].Value.ToString();
            }
            dtgMayTinh.DataBindingComplete -= dtgMayTinh_DataBindingComplete;
            _iConfigurationService.Get_Data_dm_maytinh(dtgMayTinh, bvMayTinh, string.Empty, khulamviec);
            dtgMayTinh.DataBindingComplete += dtgMayTinh_DataBindingComplete;
            Load_DanhMucMayTinhTheoKhuvuc();
            dtgMayTinh.CellEnter += dtgMayTinh_CellEnter;
        }
        private void InsertMayTinh()
        {
            if (!string.IsNullOrEmpty(txtTenMayTinh.Text) && cboMayTinh_KhuLamViec.SelectedIndex > -1)
            {
                var obj = new DM_MAYTINH();
                obj.Tenmaytinh = txtTenMayTinh.Text;
                obj.Makhuvucchinh = cboMayTinh_KhuLamViec.SelectedValue.ToString();
                _iConfigurationService.Insert_dm_maytinh(obj);
                Load_DSMayTinh();
                bvMayTinh.BindingSource.Position = bvMayTinh.BindingSource.Find("TenMaytinh", obj.Tenmaytinh);
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập đủ tên máy tính và khu vực làm việc chính.");
        }
        private void DeleteMayTinh()
        {
            if(dtgMayTinh.CurrentRow != null)
            {
                if(dgvMayTinhTheoKhuVuc.RowCount >0)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy xóa các thông tin cấu hình khu vực của máy tính trước!");
                }
                else
                {
                
                    var obj = new DM_MAYTINH();
                    obj.Tenmaytinh = dtgMayTinh.CurrentRow.Cells[colMayTinh_TenMayTinh.Name].Value.ToString();
                    if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes(string.Format("Xóa máy tính: {0}", obj.Tenmaytinh)))
                    {
                        obj.Makhuvucchinh = cboKhuLamviec.SelectedValue.ToString();
                        _iConfigurationService.Delete_dm_maytinh(obj);
                        Load_DSMayTinh();
                    }
                }
            }
        }
        private void dtgMayTinh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
         //   DataProvider.UpdateData(sqlDaMayTinh, ref dataMayTinh, string.Empty, string.Empty);
        }

        private void dtgMayTinh_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_DanhMucMayTinhTheoKhuvuc();
        }

        private void btnThemMayTinh_Click(object sender, EventArgs e)
        {
            InsertMayTinh();
        }

        private void btnDSMayTinh_Click(object sender, EventArgs e)
        {
            Load_DSMayTinh();
        }

        private void btnXoaMayTinh_Click(object sender, EventArgs e)
        {
            DeleteMayTinh();
        }

        private void dtgMayTinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >-1)
            {
                var objMayTinh = _iConfigurationService.Get_Info_dm_maytinh(dtgMayTinh[colMayTinh_TenMayTinh.Name, e.RowIndex].Value.ToString());
                objMayTinh.Makhuvucchinh = dtgMayTinh[colMayTinh_KhuVucChinh.Name, e.RowIndex].Value.ToString();
                objMayTinh.Chonkhuvuc = bool.Parse(dtgMayTinh[colMayTinh_ChonKhuVuc.Name, e.RowIndex].Value.ToString());
                objMayTinh.Mota = dtgMayTinh[colMayTinh_MoTa.Name, e.RowIndex].Value.ToString();
                _iConfigurationService.Update_dm_maytinh(objMayTinh);
            }
        }

        private void btnXoaKhuLayMau_Click(object sender, EventArgs e)
        {
            if (dtgKhuLayMau.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Xóa khu lấy mẫu?"))
                {
                    var makhuLayMau = dtgKhuLayMau.CurrentRow.Cells[colLayMau_MaKhuLayMau.Name].Value.ToString();
                    _iConfigurationService.Delete_dm_khulaymau(new DM_KHULAYMAU { Idkhulaymau = makhuLayMau });
                    Load_KhuLayMau();
                }
            }
        }

        private void FrmCauHinh_KhuVuc_Shown(object sender, EventArgs e)
        {
        }
    }
}
