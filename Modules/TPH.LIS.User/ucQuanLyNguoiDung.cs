using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.User.Services.UserManagement;
using TPH.LIS.Common.Controls;
using TPH.LIS.User.Enum;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Models;
using TPH.Common.StringCryptography;
using TPH.LIS.Log.Services.WorkingLog;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace TPH.LIS.User
{
    public partial class ucQuanLyNguoiDung : UserControl
    {
        public ucQuanLyNguoiDung()
        {
            InitializeComponent();
        }
        public string HeThong = "TPH.LabIMS";
        public string UserIdAction = "";
        private IWorkingLogService _logService = new WorkingLogService();
        private readonly IUserManagementService _userManagement = new UserManagementService();
       
        private void Insert_NhomPhanQuyen()
        {
            if (!string.IsNullOrEmpty(txtMaNhomPhanQuyen.Text))
            {
                if (_userManagement.Insert_NhomPhanQuyen(txtMaNhomPhanQuyen.Text, txtTenNhomPhanQuyen.Text, HeThong) > 0)
                {
                    Load_DanhSach_NhomPhanQuyen();
                    txtMaNhomPhanQuyen.Text = string.Empty;
                    txtTenNhomPhanQuyen.Text = string.Empty;
                    txtMaNhomPhanQuyen.Focus();
                }
            }
        }
        public void Load_Data()
        {
            Load_DanhSach_NhomPhanQuyen();
            Load_DSNhanVien();
            Load_GridTaiKhoan();
            Load_DSNguoiDung();
            Load_DanhSach_TaiKhoan_TheoNhomPhanQuyen();
        }
        private void Load_DanhSach_NhomPhanQuyen()
        {
            gvNhomQuyen_NhomQuyenUser.FocusedRowChanged -= GvNhomQuyen_NhomQuyenUser_FocusedRowChanged;
            gvNhomQuyen_NhomQuyenUser.FocusedColumnChanged -= GvNhomQuyen_NhomQuyenUser_FocusedColumnChanged;
            gvDanhSachNhomPhanQuyen.CellValueChanged -= gvDanhSachNhomPhanQuyen_CellValueChanged;
            gvDanhSachNhomPhanQuyen.FocusedRowChanged -= gvDanhSachNhomPhanQuyen_FocusedRowChanged;
            gvDanhSachNhomPhanQuyen.FocusedColumnChanged -= gvDanhSachNhomPhanQuyen_FocusedColumnChanged;
               var data = _userManagement.Data_NhomPhanQuyen(HeThong);
            gcDanhSachNhomPhanQuyen.DataSource = data;
            gcCapQuyen_NhomPhanQuyen.DataSource = data.Copy();
            gcNhomQuyen_NhomQuyenUser.DataSource = data.Copy();
            gvDanhSachNhomPhanQuyen.CellValueChanged += gvDanhSachNhomPhanQuyen_CellValueChanged;
            gvDanhSachNhomPhanQuyen.FocusedRowChanged += gvDanhSachNhomPhanQuyen_FocusedRowChanged;
            gvDanhSachNhomPhanQuyen.FocusedColumnChanged += gvDanhSachNhomPhanQuyen_FocusedColumnChanged;
            gvNhomQuyen_NhomQuyenUser.FocusedRowChanged += GvNhomQuyen_NhomQuyenUser_FocusedRowChanged;
            gvNhomQuyen_NhomQuyenUser.FocusedColumnChanged += GvNhomQuyen_NhomQuyenUser_FocusedColumnChanged;
            Load_DanhSachNhomPhanQuyen_ChiTiet(); 
        }

        private void GvNhomQuyen_NhomQuyenUser_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DanhSach_TaiKhoan_TheoNhomPhanQuyen();
        }

        private void GvNhomQuyen_NhomQuyenUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSach_TaiKhoan_TheoNhomPhanQuyen();
        }

        private void Delete_NhomPhanQuyen()
        {
            if (gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen) != null)
            {
                var maNhomPhanQuyen = gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen).ToString();
                if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes(string.Format("Xóa nhóm phân quyền:{0}?", maNhomPhanQuyen)))
                {
                    if (_userManagement.Delete_NhomPhanQuyen(maNhomPhanQuyen, HeThong) > 0)
                    {
                        Load_DanhSach_NhomPhanQuyen();
                    }
                }
            }
        }
        private void Insert_NhomPhanQuyen_ChiTet()
        {
            if (gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen) != null)
            {
                if (gvNhomPhanQuyen_DanhSachQuyen.SelectedRowsCount > 0)
                {
                    foreach (int i in gvNhomPhanQuyen_DanhSachQuyen.GetSelectedRows())
                    {
                        if (gvNhomPhanQuyen_DanhSachQuyen.GetRowCellValue(i, colNhomPhanQuyen_DanhSachQuyen_MaPhanQuyen) != null)
                        {
                            var maNhomPhanQuyen = gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen).ToString();
                            var maPhanQuyen = gvNhomPhanQuyen_DanhSachQuyen.GetRowCellValue(i, colNhomPhanQuyen_DanhSachQuyen_MaPhanQuyen).ToString();
                            var maNhomQuyen = gvNhomPhanQuyen_DanhSachQuyen.GetRowCellValue(i, colNhomPhanQuyen_DanhSachQuyen_MaNhomQuyen).ToString();
                            _userManagement.Insert_NhomPhanQuyen_ChiTiet(maNhomPhanQuyen, maPhanQuyen, maNhomQuyen);
                        }
                    }
                    Load_DanhSachNhomPhanQuyen_ChiTiet();
                }
            }
        }
        private void Delete_NhomPhanQuyen_ChiTiet()
        {
            if (gvNhomPhanQuyen_ChiTiet.SelectedRowsCount > 0)
            {
                foreach (int i in gvNhomPhanQuyen_ChiTiet.GetSelectedRows())
                {
                    if (gvNhomPhanQuyen_ChiTiet.GetRowCellValue(i, colNhomPhanQuyen_ChiTiet_MaPhanQuyen) != null)
                    {
                        var maNhomPhanQuyen = gvNhomPhanQuyen_ChiTiet.GetRowCellValue(i, colNhomPhanQuyen_ChiTiet_MaNhomPhanQuyen).ToString();
                        var maPhanQuyen = gvNhomPhanQuyen_ChiTiet.GetRowCellValue(i, colNhomPhanQuyen_ChiTiet_MaPhanQuyen).ToString();
                        var maNhomQuyen = gvNhomPhanQuyen_ChiTiet.GetRowCellValue(i, colNhomPhanQuyen_ChiTiet_MaNhomQuyen).ToString();
                        _userManagement.Delete_NhomPhanQuyen_ChiTiet(maNhomPhanQuyen, maPhanQuyen, maNhomQuyen);
                    }
                }
                Load_DanhSachNhomPhanQuyen_ChiTiet();
            }
        }
        private void Load_DanhSachNhomPhanQuyen_ChiTiet()
        {
            Load_DanhSach_Quyen();
            gcNhomPhanQuyen_ChiTiet.DataSource = null;
            if (gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen) != null)
            {
                var maNhomPhanQuyen = gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen).ToString();
                gcNhomPhanQuyen_ChiTiet.DataSource = _userManagement.Data_NhomPhanQuyen_ChiTiet(maNhomPhanQuyen);
                gvNhomPhanQuyen_ChiTiet.ExpandAllGroups();
            }
        }
        private void Load_DanhSach_TaiKhoan_TheoNhomPhanQuyen()
        {
            gcTaiKhoanTheoNhom.DataSource = null;
            if (gvNhomQuyen_NhomQuyenUser.FocusedRowHandle > -1)
            {
                var maNhomPhanQuyen = gvNhomQuyen_NhomQuyenUser.GetFocusedRowCellValue(colNhomQuyen_NhomQuyenUser_MaNhomPhanQuyen).ToString();
                var data = _userManagement.Data_ql_nguoidung_nhomphanquyen(String.Empty, maNhomPhanQuyen);
                data = WorkingServices.SearchResult_OnDatatable(data, string.Format("HeThong = '{0}'", HeThong));
                gcTaiKhoanTheoNhom.DataSource = data;
            }
        }
        private void Load_DanhSach_Quyen()
        {
            gcNhomPhanQuyen_DanhSachQuyen.DataSource = null;
            if (gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen) != null)
            {
                var maNhomPhanQuyen = gvDanhSachNhomPhanQuyen.GetFocusedRowCellValue(colNhomPhanQuyen_MaNhomPhanQuyen).ToString();
                var data = _userManagement.Data_PhanQuyen_ChuaAddNhom(maNhomPhanQuyen);
                data = WorkingServices.SearchResult_OnDatatable(data, string.Format("HeThong = '{0}'", HeThong));
                gcNhomPhanQuyen_DanhSachQuyen.DataSource = data;
                gvNhomPhanQuyen_DanhSachQuyen.ExpandAllGroups();
            }
        }
        private void Add_QuyenChoUser()
        {
            if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
            {
                var userId = NguoiDungdangChon();
                if (gvCapQuyen_NhomPhanQuyen.SelectedRowsCount > 0)
                {
                    foreach (var i in gvCapQuyen_NhomPhanQuyen.GetSelectedRows())
                    {
                        if (gvCapQuyen_NhomPhanQuyen.GetRowCellValue(i, colCapQuyen_NhomPhanQuyen_MaNhomPhanQuyen) != null)
                        {
                            var maNhomPhanQuyen = gvCapQuyen_NhomPhanQuyen.GetRowCellValue(i, colCapQuyen_NhomPhanQuyen_MaNhomPhanQuyen).ToString();
                            _userManagement.Insert_ql_nguoidung_nhomphanquyen( new QL_NGUOIDUNG_NHOMPHANQUYEN { Manguoidung = userId, Manhomphanquyen = maNhomPhanQuyen, Nguoicap = UserIdAction, Hethong = HeThong
                            });
                        }
                    }
                    Load_DanhSach_QuyenDaCap();
                    Load_DanhSach_TaiKhoan_TheoNhomPhanQuyen();
                }
            }
        }
        private void Delete_QuyenChoUsern()
        {
            if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
            {
                var userId = NguoiDungdangChon();
                if (gvNhomQuyenDaCap.SelectedRowsCount > 0)
                {
                    foreach (var i in gvNhomQuyenDaCap.GetSelectedRows())
                    {
                        if (gvNhomQuyenDaCap.GetRowCellValue(i, colNhomQuyenDaCap_MaNhomPhanQuyen) != null)
                        {
                            var maNhomPhanQuyen = gvNhomQuyenDaCap.GetRowCellValue(i, colNhomQuyenDaCap_MaNhomPhanQuyen).ToString();
                            var maNguoiDung = gvNhomQuyenDaCap.GetRowCellValue(i, colNhomQuyenDaCap_MaNguoiDung).ToString();

                            _userManagement.Delete_ql_nguoidung_nhomphanquyen(maNguoiDung, maNhomPhanQuyen);
                        }
                    }
                }
                Load_DanhSach_QuyenDaCap();
            }
        }
        private void Load_DSNhanVien()
        {
            lueBSChiDinh.EditValueChanged -= LueBSChiDinh_EditValueChanged; 
            lueBSChiDinh.Properties.DataSource = _userManagement.DanhSachNhanVien();
            lueBSChiDinh.Properties.ValueMember = "MaNhanVien";
            lueBSChiDinh.Properties.DisplayMember = "TenNhanVien";
            lueBSChiDinh.EditValueChanged += LueBSChiDinh_EditValueChanged;
        }

        private void LueBSChiDinh_EditValueChanged(object sender, EventArgs e)
        {
            txtUserID.Text = (lueBSChiDinh.EditValue??string.Empty).ToString();
        }

        private void Them_NguoiDung()
        {
            if (lueBSChiDinh.EditValue != null)
            {
                if (!string.IsNullOrEmpty(txtUserID.Text))
                {
                    QL_NGUOIDUNG objuser = new QL_NGUOIDUNG();
                    objuser.Manguoidung = txtUserID.Text;
                    objuser.Manhanvien = lueBSChiDinh.EditValue.ToString();
                    objuser.Matkhau = EnDeCrypt.EncryptString((string.IsNullOrEmpty(txtPassword.Text) ? "123456" : txtPassword.Text), "clinic");
                    objuser.Nguoitao = UserIdAction;
                    if (_userManagement.Insert_ql_nguoidung(objuser).Id > -1)
                    {
                        Load_DSNguoiDung();
                    }
                }
                else
                    CustomMessageBox.MSG_Error_OK("Hãy nhập mã tài khoản!");
            }
            else
                CustomMessageBox.MSG_Error_OK("Hãy chọn nhân viên!");
        }
        private void Load_FucntionList_FromUserList()
        {
            if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
            {
                var userId = NguoiDungdangChon();
                var objUserInfo = _userManagement.Get_Info_ql_nguoidung(userId);
                lueBSChiDinh.EditValue  = objUserInfo.Manhanvien ?? string.Empty;
                //pbSignature.Image = objUserInfo.Signpicture;
                //load quyền đã cấp cho user
                Load_DanhSach_QuyenDaCap();
            }
            else
            {
                gcNhomQuyenDaCap.DataSource = null;
            }
        }
        private void Load_DanhSach_QuyenDaCap()
        {
            if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
            {
                var userId = NguoiDungdangChon();
                var data = _userManagement.Data_ql_nguoidung_nhomphanquyen(userId, string.Empty);
                data = WorkingServices.SearchResult_OnDatatable(data, string.Format("HeThong = '{0}'", HeThong));
                gcNhomQuyenDaCap.DataSource = data;
            }
            else
                gcNhomQuyenDaCap.DataSource = null;
        }
        private void gvDanhSachNhomPhanQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvDanhSachNhomPhanQuyen.GetRowCellValue(e.RowHandle, colNhomPhanQuyen_MaNhomPhanQuyen) != null)
            {
                var maNhomPhanQuyen = gvDanhSachNhomPhanQuyen.GetRowCellValue(e.RowHandle, colNhomPhanQuyen_MaNhomPhanQuyen).ToString();
                var tenNhomPhanQuyen = gvDanhSachNhomPhanQuyen.GetRowCellValue(e.RowHandle, colNhomPhanQuyen_TenNhomPhanQuyen).ToString();
                _userManagement.Update_NhomPhanQuyen(maNhomPhanQuyen, tenNhomPhanQuyen, HeThong);
            }
        }
        private void gvDanhSachNhomPhanQuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSachNhomPhanQuyen_ChiTiet();
        }
        private void gvDanhSachNhomPhanQuyen_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DanhSachNhomPhanQuyen_ChiTiet();
        }
        private void Save_UserSignature(string userId)
        {
          //  _userManagement.Update_User_SinatureImage(userId, pbSignature.Image);
        }
       
        private void btnLoadDanhSach_NhomPhanQuyen_Click(object sender, EventArgs e)
        {
            Load_DanhSach_NhomPhanQuyen();
        }
        private void btnXoaNhomPhanQuen_Click(object sender, EventArgs e)
        {
            Delete_NhomPhanQuyen();
        }

        private void btnThemNhomPhanQuyen_Click(object sender, EventArgs e)
        {
            Insert_NhomPhanQuyen();
        }

        private void btnChiTietNhom_ThemQuyen_Click(object sender, EventArgs e)
        {
            Insert_NhomPhanQuyen_ChiTet();
        }

        private void btnChiTietNhom_XoaQuyen_Click(object sender, EventArgs e)
        {
            Delete_NhomPhanQuyen_ChiTiet();
        }

        private void btnAddSignature_Click(object sender, EventArgs e)
        {
            //if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
            //{
            //    ControlExtension.LoadImage_ToPicturebox(pbSignature);
            //    string userId = NguoiDungdangChon();
            //    Save_UserSignature(userId);
            //}
        }

        private void btnRemoveSignature_Click(object sender, EventArgs e)
        {
            //if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
            //{
            //    pbSignature.Image = null;
            //    string userId = NguoiDungdangChon();
            //    Save_UserSignature(userId);
            //}
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            Add_QuyenChoUser();
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            Delete_QuyenChoUsern();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var f = new FrmCopyPhanQuyen();
            f.ShowDialog();
        }

        #region Tài khoản người dùng
        public void Load_GridTaiKhoan()
        {
            ControlExtension.CreateGridColumnWithObject(new QL_NGUOIDUNG(), gvDanhSachNguoiDung, "colNguoiDung", true, true, true, true, true, true
                , new string[] { ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Manguoidung)
                    , ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Manhanvien)
                    , ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Tennhanvien)
                    , ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Tgsua)
                    , ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Tgtao)
                    , ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Nguoisua)
                    , ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Nguoitao)});
            var gridCol2 = gvDanhSachNguoiDung.Columns[ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Signpicture)];
            var reItem2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            reItem2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            reItem2.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            gridCol2.ColumnEdit = reItem2;
            gvDanhSachNguoiDung.BestFitColumns();
            gvDanhSachNguoiDung.Columns[ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Tennhanvien)].Width = 200;
            gvDanhSachNguoiDung.CellValueChanged += gvDanhSachNguoiDung_CellValueChanged;
            if (!UserIdAction.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                gvDanhSachNguoiDung.Columns[ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Isadmin)].OptionsColumn.AllowEdit = false;
            }
        }
        private void Load_DSNguoiDung()
        {
            gvDanhSachNguoiDung.FocusedRowChanged -= GvDanhSachNguoiDung_FocusedRowChanged;
            var dataAllUser = _userManagement.GetAllUsers();
            dataAllUser = WorkingServices.ConvertColumnNameToLower_Upper(WorkingServices.SearchResult_OnDatatable(dataAllUser, string.Format("MaNguoiDung <> 'admin'")), true);
            gcDanhSachNguoiDung.DataSource = dataAllUser;
            gvDanhSachNguoiDung.ExpandAllGroups();
            gvDanhSachNguoiDung.FocusedRowChanged += GvDanhSachNguoiDung_FocusedRowChanged;
            Load_FucntionList_FromUserList();
        }

        private void GvDanhSachNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_FucntionList_FromUserList();
        }
        private void gvDanhSachNguoiDung_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var userId = gvDanhSachNguoiDung.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Manguoidung)).ToString();
            var obj = _userManagement.Get_Info_ql_nguoidung(userId);
            var objSource = obj.Copy();
            DataRow row = gvDanhSachNguoiDung.GetDataRow(e.RowHandle);
            obj.Tgtao = objSource.Tgtao;
            obj = (QL_NGUOIDUNG)WorkingServices.Get_InfoForObject(obj, row);
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("MaNguoiDung_{0}", userId),
                Nguoithuchien = UserIdAction,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Ql_nguoidungID,
                Pcthuchien = Environment.MachineName
            });
            _userManagement.Update_ql_nguoidung(obj);
        }
        private string NguoiDungdangChon()
        {
            if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
                return gvDanhSachNguoiDung.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Manhanvien)).ToString();
            return string.Empty;
        }
     private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (gvDanhSachNguoiDung.FocusedRowHandle > -1)
            {
                var userId = NguoiDungdangChon();
                var tenNV = gvDanhSachNguoiDung.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<QL_NGUOIDUNG>(x => x.Tennhanvien)).ToString();
                var objUserInfo = _userManagement.Get_Info_ql_nguoidung(userId);
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa tài khoản: {0} ?", objUserInfo.Manguoidung)))
                {
                    var dataPhanQuyen = _userManagement.Data_ql_nguoidung_phanquyen(userId, string.Empty, string.Empty, string.Empty);
                    if (dataPhanQuyen.Rows.Count == 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = string.Format("MaNguoiDung_{0}", userId),
                            Nguoithuchien = UserIdAction,
                            Noidung = string.Format("Xóa tài khoản: {0} - {1}", userId, tenNV),
                            Idnhatky = Log.LogTableIds.Ql_nguoidungID,
                            Pcthuchien = Environment.MachineName
                        });
                        _userManagement.Delete_ql_nguoidung(objUserInfo, UserIdAction);
                        Load_DSNguoiDung();
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Tài khoản đã được cấp quyền.\nKhông thể xóa.");
                }
            }
        }
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            Them_NguoiDung();
        }
        private void btnLamMoiTaiKHoan_Click(object sender, EventArgs e)
        {
            Load_DSNguoiDung();
        }
        #endregion
    }
}
