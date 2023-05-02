using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Model;
using TPH.LIS.User.Models;

namespace TPH.LIS.User.Services.UserManagement
{
    public interface IUserManagementService
    {
        #region Người dùng
        DataTable DanhSachNhanVien();
        DataTable DanhSachNguoiDungNhanVien();
        UserInfo GetUserInfoByLoginName(string loginName);
        DataTable GetAllUsers();
        DataTable GetAllUsers_CoPhanQuyen(string AppCode);
        DataTable GetUsersKyTenCoPhanQuyen(string MaNguoiDung, string lstPhanQuyenBP, bool kyten,
            bool doichieuSHPT = false);
        DataTable GetUsersByConditions(string manguoidung, bool kyten = false, bool doichieuSHPT = false);
        BaseModel Insert_ql_nguoidung(QL_NGUOIDUNG objInfo);
        bool Update_ql_nguoidung(QL_NGUOIDUNG objInfo);
        bool Delete_ql_nguoidung(QL_NGUOIDUNG objInfo, string useraction);
        DataTable Get_NhanVien_NhanMau(string userLogIn);
        DataTable Data_ql_nguoidung(string manguoidung);
        DataTable Get_Data_ql_nguoidung(DataGridView dtg, BindingNavigator bv, string manguoidung);
        DataTable Get_Data_ql_nguoidung(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manguoidung);
        DataTable Get_Data_ql_nguoidung(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manguoidung);
        QL_NGUOIDUNG Get_Info_ql_nguoidung(string manguoidung);
        void Update_User_SinatureImage(string userID, Image img);
        #endregion
        #region phan quyen
        bool CopyPermissioin(string fromUser, string tosuer);
        DataTable DataDanhSachLoaiChuNang(string allowIDList);
        DataTable DataDanhSachNhom(string maNguoiDung);
        DataTable DataDanhSachMayXetNghiem();
        DataTable DataDanhSachPhanQuyen(string maNguoiDung);
        DataTable DataDanhSachKhuVuc(string maNguoiDung);
        DataTable DataDanhSachBoPhan(string maNguoiDung, bool isAdmin = false);
        DataTable DataDanhSachQuyenLoaiChucNang(string maNguoiDung);
        DataTable DataDanhSachQuyenNhom(string maNguoiDung);
        DataTable DataDanhSachQuyenMayXetNghiem(string maNguoiDung);
        DataTable DataDanhSachQuyenKhuVuc(string maNguoiDung);
        DataTable DataDanhSachQuyenBoPhan(string maNguoiDung);
        DataTable DataDanhSachQuyenChucNang(string maNguoiDung);

        #endregion
        #region ql_nguoidung_phanquyen
        BaseModel Insert_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo);
        bool Update_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo);
        bool Delete_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo);
        DataTable Data_ql_nguoidung_phanquyen(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen);
        DataTable Get_Data_ql_nguoidung_phanquyen(DataGridView dtg, BindingNavigator bv, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen);
        DataTable Get_Data_ql_nguoidung_phanquyen(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen);
        DataTable Get_Data_ql_nguoidung_phanquyen(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen);
        QL_NGUOIDUNG_PHANQUYEN Get_Info_ql_nguoidung_phanquyen(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen);
        #endregion
        #region Nhóm phân quyền
        int Insert_NhomPhanQuyen(string maNhomPhanQuyen, string tenNhomPhanQuyen, string heThong);
        int Update_NhomPhanQuyen(string maNhomPhanQuyen, string tenNhomPhanQuyen, string heThong);
        int Delete_NhomPhanQuyen(string maNhomPhanQuyen, string heThong);
        DataTable Data_NhomPhanQuyen(string heThong);
        #endregion
        #region Chi tiết nhóm phân quyền
        int Insert_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen, string maPhanQuyen, string maNhomQuyen);
        int Delete_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen, string maPhanQuyen, string maNhomQuyen);
        DataTable Data_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen);
        DataTable Data_PhanQuyen_ChuaAddNhom(string maNhomPhanQuyen);
        #endregion
        #region Phân quyền user
        DataTable Data_DanhSach_QuyenUser(string maNguoiDung);
        int Insert_PhanQuyen_QuyenUser(string maNhomPhanQuyen, string maNguoiDung);
        int Delete_PhanQuyen_QuyenUser(string maNguoiDung, string maPhanQuyen, string maNhomQuyen, string maLoaiDichVu);
        DataTable GetUsersKyTenCoPhanQuyenQC();
        #endregion
        #region ql_nguoidung_nhomphanquyen
        int Insert_ql_nguoidung_nhomphanquyen(QL_NGUOIDUNG_NHOMPHANQUYEN objInfo);
        int Delete_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen);
        DataTable Data_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen);
        QL_NGUOIDUNG_NHOMPHANQUYEN Get_Info_ql_nguoidung_nhomphanquyen(DataRow drInfo);
        QL_NGUOIDUNG_NHOMPHANQUYEN Get_Info_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen);
        bool CheckExists_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen);
        #endregion

        #region Chấm công
        bool Insert_User_ChamCong(string maNhanVien);
        bool User_ChamCongRaVe(string maNhanVien);

        DataTable DanhSachChamCong(string maNhanVien);
        DataTable DuLieuChamCong(string maNhanVien, string maBP, string maCV);

        bool Udp_TangCa(string maNhanVien);
        bool CheckTangCa5Ngay(string maNhanVien);

        #endregion

        #region Lương
        DataTable DuLieuLuong(UserLuongModel model);

        #endregion
    }

}
