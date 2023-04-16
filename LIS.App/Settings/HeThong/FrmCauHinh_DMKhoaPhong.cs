
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.Configurations;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPHResultConnector;

namespace TPH.LIS.App.CauHinh.HeThong
{
    public partial class FrmCauHinh_DMKhoaPhong : FrmTemplate
    {
        public FrmCauHinh_DMKhoaPhong()
        {
            InitializeComponent();
        }
        C_NhanVien data = new C_NhanVien();
        private LocationDepartmentModel _objLocation = new LocationDepartmentModel();
        private readonly ISystemConfigService _systemConfig = new SystemConfigService();

        
        private string DefaultHISWebServiceAddress = AppSettings.ApiUrl;
        private ChannelFactory<IServiceConnector> _factory = null;
        private IServiceConnector _webserviceClient = null;

        private DataTable dtChanged = new DataTable();
        SqlDataAdapter daKhoaPhong = new SqlDataAdapter();
        DataTable dtKhoaPhong = new DataTable();

        private DataTable dtChangedBP = new DataTable();
        SqlDataAdapter daBoPhan = new SqlDataAdapter();
        DataTable dtBoPhan = new DataTable();

        public IServiceConnector GetWebConnector()
        {
            if (_factory == null)
            {
                var webHttpBinding = new WebHttpBinding();
                webHttpBinding.MaxBufferPoolSize = 2147483647;
                webHttpBinding.MaxBufferSize = 2147483647;
                webHttpBinding.MaxReceivedMessageSize = 2147483647;
                webHttpBinding.ReaderQuotas.MaxDepth = 2147483647;
                webHttpBinding.ReaderQuotas.MaxArrayLength = 2147483647;
                webHttpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
                webHttpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                webHttpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                webHttpBinding.Security.Mode = WebHttpSecurityMode.None;

                _factory = new ChannelFactory<IServiceConnector>(webHttpBinding,
                    new EndpointAddress(DefaultHISWebServiceAddress));

                _factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
                _factory.Endpoint.Behaviors.Add(new LoggingEndpointBehavior());
            }

            if (_webserviceClient == null)
            {
                _webserviceClient = _factory.CreateChannel();
            }

            return _webserviceClient;
        }
        private void Lock_Unlock_Controls( bool isLock)
        {
            txtMaKhoaPhong.ReadOnly = isLock;
            txtTenKhoaPhong.ReadOnly = isLock;
        }

        private void Clear_Data()
        {
            txtMaKhoaPhong.BackColor = Color.Empty;
            txtMaKhoaPhong.DataBindings.Clear();
            txtMaKhoaPhong.Text = string.Empty;
            txtTenKhoaPhong.DataBindings.Clear();
            txtTenKhoaPhong.Text = string.Empty;
        }

        private void BindData()
        {
            Clear_Data();
            txtMaKhoaPhong.DataBindings.Add("Text", _objLocation,
                ControlExtension.PropertyName<LocationDepartmentModel>(x => x.Makhoaphong), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtMaKhoaPhong.DataBindings.Add("Tag", _objLocation,
                ControlExtension.PropertyName<LocationDepartmentModel>(x => x.Makhoaphong), true,
                DataSourceUpdateMode.Never, string.Empty);
            txtTenKhoaPhong.DataBindings.Add("Text", _objLocation,
                ControlExtension.PropertyName<LocationDepartmentModel>(x => x.Tenkhoaphong), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            Lock_Unlock_Controls(true);
        }

        private void Load_LocationInfo(string locationId)
        {
            _objLocation = _systemConfig.Get_Info_LocationDepartment(locationId);
            BindData();
        }

        private void Load_LocationList()
        {
            //_systemConfig.GetLocation(dtgKhoaPhong, bvKhoaPhong, string.Empty, string.Empty);
            string filter = "";
            if (dgvBoPhan.RowCount > 0)
            {
                if (chkByBoPhan.Checked)
                {
                    filter = "mabophan='" + dgvBoPhan.CurrentRow.Cells[MaBoPhan.Name].Value.ToString() + "'";
                }
                else
                {
                    filter = "";
                }
            }
            data.Get_KhoaPhong(daKhoaPhong, dtgKhoaPhong, bvKhoaPhong, filter, ref dtKhoaPhong);
            SearchKhoaPhong();
        }
        private void Load_BoPhan()
        {
            data.Get_BoPhan(daBoPhan, dgvBoPhan, bvBoPhan, "", ref dtBoPhan);
        }
        private void DanhSach_LoaiDieuTri()
        {
            var bs = new BindingSource();
            bs.DataSource = LoaiDieuTri.ListLoaiDieuTri();
            colLoaiBoPhan.DataSource = bs;
            colLoaiBoPhan.ValueMember = "Id";
            colLoaiBoPhan.DisplayMember = "NoiDung";
            colPhong_LoaiDieuTri.DataSource = bs;
            colPhong_LoaiDieuTri.ValueMember = "Id";
            colPhong_LoaiDieuTri.DisplayMember = "NoiDung";
        }
        private void ThemKhoaPhong()
        {
            Load_LocationInfo("-1"); 
            BindData();
            Lock_Unlock_Controls(false);
            txtMaKhoaPhong.BackColor = Color.Yellow;
            txtMaKhoaPhong.Focus();
        }
        private void SuaKhoaPhong()
        {
            Lock_Unlock_Controls(false);
            txtMaKhoaPhong.BackColor = Color.LightGreen;
            txtTenKhoaPhong.Focus();
        }

        private void XoaKhoaPhong()
        {
            if (_objLocation != null)
            {
                if (dtgKhoaPhong.CurrentRow != null)
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa khoa phòng đang chọn ?"))
                    {
                        _objLocation.Makhoaphong = dtgKhoaPhong.CurrentRow.Cells[MaKhoaPhong.Name].Value.ToString();
                        Load_LocationInfo(_objLocation.Makhoaphong);
                        _systemConfig.DeleteLocation(_objLocation);
                        Load_LocationList();
                    }
            }
        }
        private void XoaBoPhan()
        {
            try
            {
                if (dgvBoPhan.RowCount > 0)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa bộ phận đang chọn?"))
                    {
                        dgvBoPhan.Rows.RemoveAt(dgvBoPhan.CurrentRow.Index);
                    }
                }
            }
            catch(Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.ToString());
            }
        }
        private void HuyLenh()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy thao tác ?"))
            {
                Load_LocationList();
            }
        }

        private void LuuKhoaPhong()
        {
            if (!string.IsNullOrEmpty(txtMaKhoaPhong.Text))
                if (txtMaKhoaPhong.BackColor == Color.Yellow)
                {
                    if (_systemConfig.AddNewLocation(_objLocation).Id > 0)
                    {
                        Load_LocationList();
                        bvKhoaPhong.BindingSource.Position =
                            bvKhoaPhong.BindingSource.Find("MaKhoaPhong","'" + txtMaKhoaPhong.Text + "'");
                    }
                }
                else if (txtMaKhoaPhong.BackColor == Color.LightGreen)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin khoa phòng?"))
                        if (_systemConfig.UpdateLocation(_objLocation, txtMaKhoaPhong.Tag.ToString()).Id > 0)
                        {
                            Load_LocationList();
                        }
                }
        }

        private void btn_Add_Click(object sendr, EventArgs e)
        {
            ThemKhoaPhong();
        }
        private void btn_Edit_Click(object sendr, EventArgs e)
        {
            SuaKhoaPhong();
        }
        private void btn_Delete_Click(object sendr, EventArgs e)
        {
            XoaKhoaPhong();
        }
        private void btn_Cancel_Click(object sendr, EventArgs e)
        {
            HuyLenh();
        }
        private void btn_Save_Click(object sendr, EventArgs e)
        {
            LuuKhoaPhong();
        }
        private void txtMaKhoaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenKhoaPhong);
        }

        private void FrmCauHinh_DMKhoaPhong_Load(object sender, EventArgs e)
        {
            ucDanhMucCongTy1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucCongTy1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucCongTy1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucCongTy1.Load_Config();

            DanhSach_LoaiDieuTri();
            Load_LocationList();
            Load_BoPhan();
            DanhSachKhoaPhong_Phong();
            DanhSachPhong();
            LoadMaDoiTuong();
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            Load_LocationList();
        }
        private string makhoaPhongOld = "";
        private void dtgKhoaPhong_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtgKhoaPhong.CurrentRow != null)
            //{
            //    Load_LocationInfo(dtgKhoaPhong[MaKhoaPhong.Name, e.RowIndex].Value.ToString().Trim());
            //}
            makhoaPhongOld = dtgKhoaPhong.Rows[e.RowIndex].Cells[MaKhoaPhong.Name].Value.ToString();
        }

        private void ucAddEditControl_Load(object sender, EventArgs e)
        {

        }
        private void dtgKhoaPhong_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataProvider.UpdateData(daKhoaPhong, ref dtKhoaPhong, dtgKhoaPhong, "", "", ref dtChanged);
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.ToString());
            }
            //if (dtChanged != null)
            //{
            //    if (dtChanged.Rows.Count > 0)
            //    {
            //        dtChanged.Rows[0]["KhongSuDung"] = false;
            //        //string tendonvi = dtChanged.Rows[0]["TenKhoaPhong"].ToString();
            //        //bool b = PostWebserviceExcuteData(madonvi, tendonvi, makhoaPhongOld);
            //        dtChanged.Clear();
            //    }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XoaKhoaPhong();
        }
        void SearchKhoaPhong()
        {
            if (bvKhoaPhong.BindingSource != null)
            {
                bvKhoaPhong.BindingSource.Filter = string.Format("MaKhoaPhong like '%{0}%' or TenKhoaPhong like '%{0}%' or DienThoai like '%{0}%' or WebSite like '%{0}%' or Email like '%{0}%' or DiaChi like '%{0}%'", txtTimKiem.Text);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            SearchKhoaPhong();
        }

        private void btnResetpassword_Click(object sender, EventArgs e)
        {
            if (dtgKhoaPhong.RowCount == 0) return;
            using (var f = new FrmInputPasswordToReset())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(f.Password))
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Reset lại mật khẩu mặc định là: {0} cho khoa phòng đang chọn?", f.Password)))
                        {
                            string madonvi = dtgKhoaPhong.CurrentRow.Cells[MaKhoaPhong.Name].Value.ToString();
                            if (PostWebserviceResetPassword(madonvi, f.Password))
                            {
                                CustomMessageBox.MSG_Information_OK("Reset mật khẩu thành công!");
                            }
                            else
                            {
                                CustomMessageBox.MSG_Information_OK("Reset mật khẩu thất bại!");
                            }
                        }
                    }
                }
            }
                
        }
        bool PostWebserviceResetPassword(string madonvi, string password)
        {
            IServiceConnector client = GetWebConnector();

            return client.ResetPasswordLocation(madonvi, password);
        }
        bool PostWebserviceExcuteData(string madonvi, string tendonvi, string madonvicu)
        {
            IServiceConnector client = GetWebConnector();

            return client.PostLocationData(madonvi, tendonvi, madonvicu);
        }

        private void dtgKhoaPhong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgKhoaPhong.Rows[e.RowIndex].Cells[KhongSuDung.Name].Value.ToString() == "")
                    dtgKhoaPhong.Rows[e.RowIndex].Cells[KhongSuDung.Name].Value = false;
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.ToString());
            }
        }

        private void dgvBoPhan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBoPhan.Rows[e.RowIndex].Cells[colLoaiBoPhan.Name].Value.ToString() == "")
                    dgvBoPhan.Rows[e.RowIndex].Cells[colLoaiBoPhan.Name].Value = 0;
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.ToString());
            }
        }

        private void dgvBoPhan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataProvider.UpdateData(daBoPhan, ref dtBoPhan, dgvBoPhan, "", "", ref dtChangedBP);
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.ToString());
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Load_BoPhan();
        }

        private void btnSetMaBoPhan_Click(object sender, EventArgs e)
        {
            if (dgvBoPhan.RowCount == 0)
            {
                CustomMessageBox.MSG_Information_OK("Chưa có bộ phận nào, vui lòng khai bộ phận và tích chọn mã khoa phòng cần gán mã bộ phận");
                return;
            }
            bindingNavigatorPositionItem.Focus();
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Gán mã bộ phận cho khoa phòng đang chọn?"))
            {
                var _maBoPhan = dgvBoPhan.CurrentRow.Cells[MaBoPhan.Name].Value.ToString();
                for (int i = 0; i < dtgKhoaPhong.RowCount; i++)
                {
                    if (dtgKhoaPhong.Rows[i].Cells[Checked.Name].Value != null && (bool)dtgKhoaPhong.Rows[i].Cells[Checked.Name].Value)
                    {
                        dtgKhoaPhong.Rows[i].Cells[SetMaBoPhan.Name].Value = _maBoPhan;
                        dtgKhoaPhong.Rows[i].Cells[Checked.Name].Value = false;
                    }
                }
            }
        }

        private void dgvBoPhan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (chkByBoPhan.Checked)
                Load_LocationList();
        }

        private void chkByBoPhan_CheckedChanged(object sender, EventArgs e)
        {
            Load_LocationList();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        #region Danh mục phòng
        //Phòng
        DataTable dataDSPhong = new DataTable();
        SqlDataAdapter daPhong = new SqlDataAdapter();
        private void DanhSachKhoaPhong_Phong()
        {
            dtgPhong_KhoaPhong.CellEnter -= DtgPhong_KhoaPhong_CellEnter;
            var data = _systemConfig.GetLocation(string.Empty, string.Empty, string.Empty);
            ControlExtension.BindDataToGrid(data, ref dtgPhong_KhoaPhong, bvPhong_KhoaPhong);
            dtgPhong_KhoaPhong.CellEnter += DtgPhong_KhoaPhong_CellEnter;
            DanhSachPhong();
        }

        private void DtgPhong_KhoaPhong_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DanhSachPhong();
        }

        private void DanhSachPhong()
        {
            dtgPhong.DataBindingComplete -= dtgPhong_DataBindingComplete;
            dtgPhong.DataSource = null;
            bvDSPhong.BindingSource = null;
            if (dtgPhong_KhoaPhong.CurrentRow != null)
            {
                var maKhoa = (chkXemTatCaPhong.Checked ? string.Empty : dtgPhong_KhoaPhong.CurrentRow.Cells[colDSKhoa_Phong_MaKhoa.Name].Value.ToString());
                _systemConfig.Get_Data_dm_phong(dtgPhong, bvDSPhong, ref daPhong, ref dataDSPhong, string.Empty, maKhoa, string.Empty);
            }
            dtgPhong.DataBindingComplete += dtgPhong_DataBindingComplete;
        }


        private void dtgPhong_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataProvider.UpdateData(daPhong, ref dataDSPhong, dtgPhong, "", "");
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.ToString());
            }
        }

        private void btnDSNhomPhong_Click(object sender, EventArgs e)
        {
            DanhSachKhoaPhong_Phong();
        }

        private void btnDSPhong_Click(object sender, EventArgs e)
        {
            DanhSachPhong();
        }
        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (dtgPhong.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa phòng đang chọn?"))
                    dtgPhong.Rows.RemoveAt(dtgPhong.CurrentRow.Index);
            }
        }
        #endregion

        private void chkXemTatCaPhong_CheckedChanged(object sender, EventArgs e)
        {
            DanhSachPhong();
        }

        private void btnDSPhong_Click_1(object sender, EventArgs e)
        {
            DanhSachPhong();
        }

        private void btnLuuDT_Click(object sender, EventArgs e)
        {
            if (txtMaDoiTuong.BackColor == Color.Green)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Cập nhật thông tin đối tượng: {0}", txtMaDoiTuong.Text)))
                {
                    _systemConfig.Update_dm_doituongbenhnhan(new DM_DOITUONGBENHNHAN { Madoituongbn = txtMaDoiTuong.Text, Tendoituongbn = txtTenDoiTuong.Text });
                }
            }
            else 
            {
                _systemConfig.Insert_dm_doituongbenhnhan(new DM_DOITUONGBENHNHAN { Madoituongbn = txtMaDoiTuong.Text, Tendoituongbn = txtTenDoiTuong.Text });
            }
            LoadMaDoiTuong();
        }
        private void LoadMaDoiTuong()
        {
            var data = _systemConfig.Data_dm_doituongbenhnhan(string.Empty);
            ControlExtension.BindDataToGrid(data, ref dtgDoiTuongBN, ref bvDoiTuongBN);
        }

        private void dtgDoiTuongBN_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDoiTuong.BackColor = txtTenDoiTuong.BackColor;
            txtMaDoiTuong.ReadOnly = true;
            txtTenDoiTuong.ReadOnly = true;
            if(dtgDoiTuongBN.CurrentRow != null)
            {
                txtMaDoiTuong.Text = dtgDoiTuongBN.CurrentRow.Cells[colMaDoiTuong.Name].Value.ToString();
                txtTenDoiTuong.Text = dtgDoiTuongBN.CurrentRow.Cells[colTenDoiTuong.Name].Value.ToString();
            }
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDoiTuong.Text))
            {
                txtMaDoiTuong.BackColor = Color.Green;
                txtTenDoiTuong.ReadOnly = false;
                txtTenDoiTuong.Focus();
            }
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            txtMaDoiTuong.ReadOnly = false;
            txtTenDoiTuong.ReadOnly = false;
            txtMaDoiTuong.Text = string.Empty;
            txtTenDoiTuong.Text = string.Empty;
            txtMaDoiTuong.Focus();
        }

        private void btnLamMoiDSDT_Click(object sender, EventArgs e)
        {
            LoadMaDoiTuong();
        }
    }
}
