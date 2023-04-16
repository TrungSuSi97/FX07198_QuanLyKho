using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Model;
using TPH.LIS.Patient.Model;

namespace TPH.LIS.Patient.Services
{
    public interface IMicrobilogyTestResultService
    {
        bool Update_ketqua_cls_xetnghiem_visinh_kqViSinh(string maTiepNhan, string maYeuCau, string userUpdate, string ketQua
            , bool ghiLog, string ghiChu, string loaiMauNhan);
        bool Update_ketqua_cls_xetnghiem_visinh_yeucau_DaIn(string userIn, string maTiepNhan, string maYeuCau, bool daIn, string chuKy, bool xacNhanKhiIn);
        bool Update_Ketqua_Cls_XetNghiem_ViSinh_LoaiMauNhan(string loaiMauNhan, string maTiepNhan, string maYeuCau, string nguoinhap, bool ghiLog);
        int Update_ketqua_cls_xetnghiem_visinh_XacNhan(string maTiepNhan, string lstMaYeuCau, string userUpdate, bool XacNhan
            , bool xacNhanDe, bool kiemTraUser, string PCValid);
        bool Delete_ketqua_cls_xetnghiem_visinh(string maTiepNhan, string maYeuCau);
        void Search_DanhSachViSinh(DateTime dtDateFrom, DateTime dtDateTo, string serviceId, string patientName, string seq, bool fullRsult
            , bool printed, string testId, string category, bool nhapTheoDanhSach, DataGridView dtg, BindingNavigator bv);
        DataTable Data_ketqua_cls_xetnghiem_visinh(string matiepnhan, string mayeucau, bool checkDaLayMau, bool checkDaNhanMau);
        DataTable Data_ketqua_cls_xetnghiem_visinh(string matiepnhan, string mayeucau
       , bool checkDaLayMau, bool checkDaNhanMau, string lstMaNhomPhanQuyen);
        KETQUA_CLS_XETNGHIEM_VISINH Get_Info_ketqua_cls_xetnghiem_visinh(DataRow drInfo);
        KETQUA_CLS_XETNGHIEM_VISINH Get_Info_ketqua_cls_xetnghiem_visinh(string matiepnhan, string mayeucau);
        DataTable Get_DanhSachBenhNhanViSinh(DateTime fromDate, DateTime toDate, string maDonVi
            , string doiTuongDichVu, string maTiepNhan, string hoTen, int DaIn, bool checkDaLayMau, bool checkDaNhanMau);
        bool Insert_ketqua_cls_xetnghiem_vikhuan(string maTiepNhan, string maYeuCau, string maPhanLoaiViKhuan
        , string nguoiNhap, string kyThuat, int lanXetnghiem, string maBoKhangSinh);
        bool Update_KetQua_Gram(string maTiepNhan, string maYeuCau, string ketquagram);
        bool Delete_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan);
        bool Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(string matiepNhan, string maYeuCau, string maVikhuan
    , string maKhangsinh, string kyThuat, string nguoinhap);
        bool Delete_KhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat, int lanXN, string siteINF);
        DataTable Get_DanhSach_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, int lanXetNghiem);
        DataTable Get_DanhSach_KhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, int lanXN, string kyThuat);
        bool Update_KetQuaViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, bool mic, string ketQuaESBL, string KetQuaBetaLactamases);
        bool Update_KetQuaKhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat
              , string ketQuaSRI, string ketQuaDinhLuong, int coKetQua, string nguoiThucHien, int lanXN, string idCard = "", int idMay = 0
              , string SRI = "", string Site_Infection = "");
        int Update_GhiChu_QuyTrinh_PhuongPhap(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat
            , string ghiChu, string quyTrinh, string phuongPhap);
        DataTable DuLieuIn(string maTiepNhan, string maChiDinh, string maViKhuan, bool inKQSoiNhuom, bool inKQNam, bool inKQCay, bool inTatCa, string nguoiKy, string kyThuat);

        bool Insert_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo);
        bool Update_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo);
        bool Delete_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo);
        DataTable Data_ketqua_cls_xetnghiem_khaosatdaithe(string matiepnhan, string makhaosat, string mayeucau);
        DataTable Get_Data_ketqua_cls_xetnghiem_khaosatdaithe(DataGridView dtg, BindingNavigator bv, string matiepnhan, string makhaosat, string mayeucau);
        KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE Get_Info_ketqua_cls_xetnghiem_khaosatdaithe(string matiepnhan, string makhaosat, string mayeucau);
        #region ketqua_cls_xetnghiem_visinh_khangkhangsinh
        BaseModel Insert_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo);
        bool Update_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo);
        bool Delete_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo);
        DataTable Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh);
        DataTable Get_Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(DataGridView dtg, BindingNavigator bv, string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh);
        KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH Get_Info_ketqua_cls_xetnghiem_visinh_khangkhangsinh(string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh);
        bool Insert_ketqua_cls_xetnghiem_vikhuan_amtinh(string maTiepNhan, string maYeuCau,
     string maPhanLoaiViKhuan
     , string nguoiNhap, string kyThuat, int lanXetnghiem);
        bool Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(string matiepNhan, string maYeuCau
           , string maVikhuan, string maKhangsinh, string kyThuat, string nguoinhap, int lanXN);
        bool Check_Existed_dm_xetnghiem_khangsinh_bo_chitiet(string maBoKhangSinh, string maViKhuan, string kyThuat);
        DataTable DanhSach_TheDinhDanh(string maTiepNhan, string maYeuCau);
        bool CapNhat_MauViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, string maMau, int lanXN);
        int CapNhat_ThongTinMayXN_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, int idMayXn, int lanXetNghiem = 1);
        bool CapNhat_GhiChu_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, string ghiChu, string nguoiNhap, int lanXN);
        int CapNhat_ThongTinQuyTrinh_LoaiMau(string maTiepNhan, string maYeuCau, int idMayXn);
        #endregion
        #region Phiếu tiến trình
        bool Insert_Update_ViSinh_PhieuTienTrinh(string maTiepNhan, string maXN, string maSoMau, string nguoiThucHien, DateTime thoiGianThucHien, string noiDung, string nguoiSua, int AutoID = -100);
        DataTable Get_PhieuTienTrinh(string maTiepNhan, string maYeuCau, string maSoMau);
        bool Delete_PhieuTienTrinh(string ids);
        DataTable DuLieuInPhieuTienTrinh(string maTiepNhan, bool inTieuDe, string maSoMau);
        DataTable Data_ketqua_cls_xetnghiem_visinh_phieutientrinh(string matiepnhan, string mayeucau, bool checkDaLayMau, bool checkDaNhanMau);
        #endregion

    }
}
