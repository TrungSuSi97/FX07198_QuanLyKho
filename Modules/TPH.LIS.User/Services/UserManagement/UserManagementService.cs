using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Model;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Models;
using TPH.LIS.User.Repositories.UserManagement;

namespace TPH.LIS.User.Services.UserManagement
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagement;
        #region Người dùng
        public UserManagementService() : this(null)
        {

        }

        public UserManagementService(UserManagementRepository userManagement)
        {
            _userManagement = userManagement ?? new UserManagementRepository();
        }
        public DataTable DanhSachNhanVien()
        {
            return _userManagement.DanhSachNhanVien();
        }
        public DataTable DanhSachNguoiDungNhanVien()
        {
            return _userManagement.DanhSachNguoiDungNhanVien();
        }
        public UserInfo GetUserInfoByLoginName(string loginName)
        {
            var result = _userManagement.GetUserInfoByLoginName(loginName);
            //result.Username = string.IsNullOrWhiteSpace(result.Username)
            //    ? result.LoginName
            //    : result.Username;
            result.Departement = string.IsNullOrWhiteSpace(result.Departement)
                ? UserConstant.DefaultDepartement
                : result.Departement;

            return result;
        }

        public DataTable GetAllUsers()
        {
            return _userManagement.GetAllUsers();
        }
        public DataTable GetAllUsers_CoPhanQuyen(string AppCode)
        {
            return _userManagement.GetAllUsers_CoPhanQuyen(AppCode);
        }
        public DataTable GetUsersKyTenCoPhanQuyen(string MaNguoiDung, string lstPhanQuyenBP, bool kyten,
            bool doichieuSHPT = false)
        {
            return _userManagement.GetUsersKyTenCoPhanQuyen(MaNguoiDung, lstPhanQuyenBP, kyten, doichieuSHPT);
        }
        public DataTable GetUsersByConditions(string manguoidung, bool kyten = false, bool doichieuSHPT = false)
        {
            return _userManagement.GetUsersByConditions(manguoidung, kyten, doichieuSHPT);
        }

        public BaseModel Insert_ql_nguoidung(QL_NGUOIDUNG objInfo)
        {
            return _userManagement.Insert_ql_nguoidung(objInfo);
        }

        public bool Update_ql_nguoidung(QL_NGUOIDUNG objInfo)
        {
            return _userManagement.Update_ql_nguoidung(objInfo);
        }

        public bool Delete_ql_nguoidung(QL_NGUOIDUNG objInfo, string useraction)
        {
            return _userManagement.Delete_ql_nguoidung(objInfo, useraction);
        }
        public DataTable Get_NhanVien_NhanMau(string userLogIn)
        {
            return _userManagement.Get_NhanVien_NhanMau(userLogIn);
        }
        public DataTable Data_ql_nguoidung(string manguoidung)
        {
            return _userManagement.Data_ql_nguoidung(manguoidung);
        }

        public DataTable Get_Data_ql_nguoidung(DataGridView dtg, BindingNavigator bv, string manguoidung)
        {
            return _userManagement.Get_Data_ql_nguoidung(dtg, bv, manguoidung);
        }

        public DataTable Get_Data_ql_nguoidung(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manguoidung)
        {
            return _userManagement.Get_Data_ql_nguoidung(dtg, bv, ref sqlDataAdapter, ref dtData, manguoidung);
        }
        public DataTable Get_Data_ql_nguoidung(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manguoidung)
        {
            return _userManagement.Get_Data_ql_nguoidung(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, manguoidung);
        }

        public QL_NGUOIDUNG Get_Info_ql_nguoidung(string manguoidung)
        {
            return _userManagement.Get_Info_ql_nguoidung(manguoidung);
        }
        public void Update_User_SinatureImage(string userID, Image img)
        {
            _userManagement.Update_User_SinatureImage(userID, img);
        }
        #endregion
        #region phan quyen
        public bool CopyPermissioin(string fromUser, string tosuer)
        {
            return _userManagement.CopyPermissioin(fromUser, tosuer);
        }
        public DataTable DataDanhSachLoaiChuNang(string allowIDList)
        {
            return _userManagement.DataDanhSachLoaiChuNang(allowIDList);
        }
        public DataTable DataDanhSachNhom(string maNguoiDung)
        {
            return _userManagement.DataDanhSachNhom(maNguoiDung);
        }
        public DataTable DataDanhSachMayXetNghiem()
        {
            return _userManagement.DataDanhSachMayXetNghiem();
        }
        public DataTable DataDanhSachPhanQuyen(string maNguoiDung)
        {
            return _userManagement.DataDanhSachPhanQuyen(maNguoiDung);
        }
        public DataTable DataDanhSachKhuVuc(string maNguoiDung)
        {
            return _userManagement.DataDanhSachKhuVuc(maNguoiDung);
        }
        public DataTable DataDanhSachBoPhan(string maNguoiDung, bool isAdmin = false)
        {
            return _userManagement.DataDanhSachBoPhan(maNguoiDung, isAdmin);
        }

        public DataTable DataDanhSachQuyenLoaiChucNang(string maNguoiDung)
        {
            return _userManagement.DataDanhSachQuyenLoaiChucNang(maNguoiDung);
        }
        public DataTable DataDanhSachQuyenNhom(string maNguoiDung)
        {
            return _userManagement.DataDanhSachQuyenNhom(maNguoiDung);
        }
        public DataTable DataDanhSachQuyenMayXetNghiem(string maNguoiDung)
        {
            return _userManagement.DataDanhSachQuyenMayXetNghiem(maNguoiDung);
        }
        public DataTable DataDanhSachQuyenKhuVuc(string maNguoiDung)
        {
            return _userManagement.DataDanhSachQuyenKhuVuc(maNguoiDung);
        }
        public DataTable DataDanhSachQuyenBoPhan(string maNguoiDung)
        {
            return _userManagement.DataDanhSachQuyenBoPhan(maNguoiDung);
        }
        public DataTable DataDanhSachQuyenChucNang(string maNguoiDung)
        {
            return _userManagement.DataDanhSachQuyenChucNang(maNguoiDung);
        }

        #endregion
        #region ql_nguoidung_phanquyen
        public BaseModel Insert_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo)
        {
            return _userManagement.Insert_ql_nguoidung_phanquyen(objInfo);
        }

        public bool Update_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo)
        {

            return _userManagement.Update_ql_nguoidung_phanquyen(objInfo);
        }

        public bool Delete_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo)
        {

            return _userManagement.Delete_ql_nguoidung_phanquyen(objInfo);
        }

        public DataTable Data_ql_nguoidung_phanquyen(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {

            return _userManagement.Data_ql_nguoidung_phanquyen(manguoidung, maphanquyen, maloaidichvu, manhomquyen);
        }

        public DataTable Get_Data_ql_nguoidung_phanquyen(DataGridView dtg, BindingNavigator bv, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {

            return _userManagement.Get_Data_ql_nguoidung_phanquyen(dtg, bv, manguoidung, maphanquyen, maloaidichvu, manhomquyen);
        }

        public DataTable Get_Data_ql_nguoidung_phanquyen(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {

            return _userManagement.Get_Data_ql_nguoidung_phanquyen(dtg, bv, ref sqlDataAdapter, ref dtData, manguoidung, maphanquyen, maloaidichvu, manhomquyen);
        }

        public DataTable Get_Data_ql_nguoidung_phanquyen(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {

            return _userManagement.Get_Data_ql_nguoidung_phanquyen(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, manguoidung, maphanquyen, maloaidichvu, manhomquyen);
        }

        public QL_NGUOIDUNG_PHANQUYEN Get_Info_ql_nguoidung_phanquyen(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {

            return _userManagement.Get_Info_ql_nguoidung_phanquyen(manguoidung, maphanquyen, maloaidichvu, manhomquyen);
        }

        #endregion
        #region Nhóm phân quyền
        public int Insert_NhomPhanQuyen(string maNhomPhanQuyen, string tenNhomPhanQuyen, string heThong)
        {
            return _userManagement.Insert_NhomPhanQuyen(maNhomPhanQuyen, tenNhomPhanQuyen, heThong);
        }
        public int Update_NhomPhanQuyen(string maNhomPhanQuyen, string tenNhomPhanQuyen, string heThong)
        {
            return _userManagement.Update_NhomPhanQuyen(maNhomPhanQuyen, tenNhomPhanQuyen, heThong);
        }
        public int Delete_NhomPhanQuyen(string maNhomPhanQuyen, string heThong)
        {
            return _userManagement.Delete_NhomPhanQuyen(maNhomPhanQuyen, heThong);
        }
        public DataTable Data_NhomPhanQuyen(string heThong)
        {
            return _userManagement.Data_NhomPhanQuyen(heThong);
        }
        #endregion
        #region Chi tiết nhóm phân quyền
        public int Insert_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen, string maPhanQuyen, string maNhomQuyen)
        {
            return _userManagement.Insert_NhomPhanQuyen_ChiTiet(maNhomPhanQuyen, maPhanQuyen, maNhomQuyen);
        }
        public int Delete_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen, string maPhanQuyen, string maNhomQuyen)
        {
            return _userManagement.Delete_NhomPhanQuyen_ChiTiet(maNhomPhanQuyen, maPhanQuyen, maNhomQuyen);
        }
        public DataTable Data_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen)
        {
            return _userManagement.Data_NhomPhanQuyen_ChiTiet(maNhomPhanQuyen);
        }
        public DataTable Data_PhanQuyen_ChuaAddNhom(string maNhomPhanQuyen)
        {
            return _userManagement.Data_PhanQuyen_ChuaAddNhom(maNhomPhanQuyen);
        }
        #endregion
        #region Phân quyền user
        public DataTable Data_DanhSach_QuyenUser(string maNguoiDung)
        {
            return _userManagement.Data_DanhSach_QuyenUser(maNguoiDung);
        }
        public int Insert_PhanQuyen_QuyenUser(string maNhomPhanQuyen, string maNguoiDung)
        {
            return _userManagement.Insert_PhanQuyen_QuyenUser(maNhomPhanQuyen, maNguoiDung);
        }
        public int Delete_PhanQuyen_QuyenUser(string maNguoiDung, string maPhanQuyen, string maNhomQuyen, string maLoaiDichVu)
        {
            return _userManagement.Delete_PhanQuyen_QuyenUser(maNguoiDung, maPhanQuyen, maNhomQuyen, maLoaiDichVu);
        }
        public DataTable GetUsersKyTenCoPhanQuyenQC()
        {
            return _userManagement.GetUsersKyTenCoPhanQuyenQC();
        }
        #endregion
        #region ql_nguoidung_nhomphanquyen
        public int Insert_ql_nguoidung_nhomphanquyen(QL_NGUOIDUNG_NHOMPHANQUYEN objInfo)
        {
            return _userManagement.Insert_ql_nguoidung_nhomphanquyen(objInfo);
        }

        public int Delete_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            return _userManagement.Delete_ql_nguoidung_nhomphanquyen(manguoidung, manhomphanquyen);
        }

        public DataTable Data_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            return _userManagement.Data_ql_nguoidung_nhomphanquyen(manguoidung, manhomphanquyen);
        }

        public QL_NGUOIDUNG_NHOMPHANQUYEN Get_Info_ql_nguoidung_nhomphanquyen(DataRow drInfo)
        {
            return _userManagement.Get_Info_ql_nguoidung_nhomphanquyen(drInfo);
        }
        public QL_NGUOIDUNG_NHOMPHANQUYEN Get_Info_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            return _userManagement.Get_Info_ql_nguoidung_nhomphanquyen(manguoidung, manhomphanquyen);
        }

        public bool CheckExists_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            return _userManagement.CheckExists_ql_nguoidung_nhomphanquyen(manguoidung, manhomphanquyen);
        }

        #endregion

        #region Chấm công
        public bool Insert_User_ChamCong(string maNhanVien)
        {
            return _userManagement.Insert_User_ChamCong(maNhanVien);
        }
        public bool User_ChamCongRaVe(string maNhanVien)
        {
            return _userManagement.User_ChamCongRaVe(maNhanVien);
        }

        public DataTable DanhSachChamCong(string maNhanVien)
        {
            return _userManagement.DanhSachChamCong(maNhanVien);
        }
        public DataTable DuLieuChamCong(string maNhanVien, string maBP, string maCV)
        {
            return _userManagement.DuLieuChamCong(maNhanVien, maBP, maCV);
        }
        public bool Udp_TangCa(string maNhanVien)
        {
            return _userManagement.Udp_TangCa(maNhanVien);
        }
        public bool CheckTangCa5Ngay(string maNhanVien)
        { 
            return _userManagement.CheckTangCa5Ngay(maNhanVien);
        }

        #endregion

        #region Lương
        public DataTable DuLieuLuong(UserLuongModel model)
        {
            return _userManagement.DuLieuLuong(model);
        }

        #endregion
    }
}
