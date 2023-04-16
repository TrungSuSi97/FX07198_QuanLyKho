using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Model;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Repositories;

namespace TPH.LIS.Patient.Services
{
    public class MicrobilogyTestResultService : IMicrobilogyTestResultService
    {

        public readonly IMicrobiologyTestResultRepository _microbiologyTestResultRepository;

        public MicrobilogyTestResultService(IMicrobiologyTestResultRepository informationRepository)
        {
            _microbiologyTestResultRepository = informationRepository ?? new MicrobilogyTestResultRepository();
        }

        public MicrobilogyTestResultService()
            : this(null)
        {
        }
        public bool Update_ketqua_cls_xetnghiem_visinh_kqViSinh(string maTiepNhan, string maYeuCau, string userUpdate
            , string ketQua, bool ghiLog, string ghiChu, string loaiMauNhan)
        {
            return _microbiologyTestResultRepository.Update_ketqua_cls_xetnghiem_visinh_kqViSinh(maTiepNhan, maYeuCau, userUpdate
                , ketQua, ghiLog, ghiChu, loaiMauNhan);
        }
        public bool Update_ketqua_cls_xetnghiem_visinh_yeucau_DaIn(string userIn, string maTiepNhan, string maYeuCau, bool daIn, string chuKy, bool xacNhanKhiIn)
        {
            return _microbiologyTestResultRepository.Update_ketqua_cls_xetnghiem_visinh_yeucau_DaIn(userIn, maTiepNhan, maYeuCau, daIn, chuKy, xacNhanKhiIn);
        }
        public bool Update_Ketqua_Cls_XetNghiem_ViSinh_LoaiMauNhan(string loaiMauNhan, string maTiepNhan, string maYeuCau, string nguoinhap, bool ghiLog)
        {
            return _microbiologyTestResultRepository.Update_Ketqua_Cls_XetNghiem_ViSinh_LoaiMauNhan(loaiMauNhan, maTiepNhan, maYeuCau, nguoinhap, ghiLog);
        }
        public int Update_ketqua_cls_xetnghiem_visinh_XacNhan(string maTiepNhan, string lstMaYeuCau, string userUpdate, bool XacNhan
            , bool xacNhanDe, bool kiemTraUser, string PCValid)
        {
            return _microbiologyTestResultRepository.Update_ketqua_cls_xetnghiem_visinh_XacNhan(
                maTiepNhan, lstMaYeuCau, userUpdate, XacNhan
            , xacNhanDe, kiemTraUser, PCValid);
        }
        public bool Delete_ketqua_cls_xetnghiem_visinh(string maTiepNhan, string maYeuCau)
        {
            return _microbiologyTestResultRepository.Delete_ketqua_cls_xetnghiem_visinh(maTiepNhan, maYeuCau);
        }
        public DataTable Data_ketqua_cls_xetnghiem_visinh(string maTiepNhan, string maYeuCau, bool checkDaLayMau, bool checkDaNhanMau)
        {
            return _microbiologyTestResultRepository.Data_ketqua_cls_xetnghiem_visinh(maTiepNhan, maYeuCau, checkDaLayMau, checkDaNhanMau);
        }
       public DataTable Data_ketqua_cls_xetnghiem_visinh(string matiepnhan, string mayeucau
       , bool checkDaLayMau, bool checkDaNhanMau, string lstMaNhomPhanQuyen)
        {
            return _microbiologyTestResultRepository.Data_ketqua_cls_xetnghiem_visinh(matiepnhan, mayeucau
                                                    , checkDaLayMau, checkDaNhanMau, lstMaNhomPhanQuyen);
        }
        public KETQUA_CLS_XETNGHIEM_VISINH Get_Info_ketqua_cls_xetnghiem_visinh(DataRow drInfo)
        {
            return _microbiologyTestResultRepository.Get_Info_ketqua_cls_xetnghiem_visinh(drInfo);
        }
        public KETQUA_CLS_XETNGHIEM_VISINH Get_Info_ketqua_cls_xetnghiem_visinh(string maTiepNhan, string maYeuCau)
        {
            return _microbiologyTestResultRepository.Get_Info_ketqua_cls_xetnghiem_visinh(maTiepNhan, maYeuCau);
        }
        public void Search_DanhSachViSinh(DateTime dtDateFrom, DateTime dtDateTo, string serviceId, string patientName, string seq, bool fullRsult
             , bool printed, string testId, string category, bool nhapTheoDanhSach, DataGridView dtg, BindingNavigator bv)
        {
            _microbiologyTestResultRepository.Search_DanhSachViSinh(dtDateFrom, dtDateTo, serviceId, patientName, seq, fullRsult
             , printed, testId, category, nhapTheoDanhSach, dtg, bv);
        }
        public DataTable Get_DanhSachBenhNhanViSinh(DateTime fromDate, DateTime toDate, string maDonVi, string doiTuongDichVu
            , string maTiepNhan, string hoTen, int DaIn, bool checkDaLayMau, bool checkDaNhanMau)
        {
            return _microbiologyTestResultRepository.Get_DanhSachBenhNhanViSinh(fromDate, toDate, maDonVi, doiTuongDichVu, maTiepNhan, hoTen, DaIn, checkDaLayMau, checkDaNhanMau);
        }
        public bool Insert_ketqua_cls_xetnghiem_vikhuan(string maTiepNhan, string maYeuCau, string maPhanLoaiViKhuan
          , string nguoiNhap, string kyThuat, int lanXetnghiem, string maBoKhangSinh)
        {
            return _microbiologyTestResultRepository.Insert_ketqua_cls_xetnghiem_vikhuan(maTiepNhan, maYeuCau, maPhanLoaiViKhuan
                , nguoiNhap, kyThuat, lanXetnghiem, maBoKhangSinh);
        }
        public bool Update_KetQua_Gram(string maTiepNhan, string maYeuCau, string ketquagram)
        {
            return _microbiologyTestResultRepository.Update_KetQua_Gram(maTiepNhan, maYeuCau, ketquagram);
        }
        public bool Delete_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan)
        {
            return _microbiologyTestResultRepository.Delete_ViKhuan(maTiepNhan, maYeuCau, maViKhuan);
        }
        public bool Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(string matiepNhan, string maYeuCau, string maVikhuan
    , string maKhangsinh, string kyThuat, string nguoinhap)
        {
            return _microbiologyTestResultRepository.Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(matiepNhan, maYeuCau, maVikhuan
                , maKhangsinh, kyThuat, nguoinhap);
        }
        public bool Delete_KhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat, int lanXN, string siteINF)
        {
            return _microbiologyTestResultRepository.Delete_KhangSinh(maTiepNhan, maYeuCau, maViKhuan, maKhangSinh, kyThuat, lanXN, siteINF);
        }
        public DataTable Get_DanhSach_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, int lanXetNghiem)
        {
            return _microbiologyTestResultRepository.Get_DanhSach_ViKhuan(maTiepNhan, maYeuCau, maViKhuan, lanXetNghiem);
        }
        public DataTable Get_DanhSach_KhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, int lanXN, string kyThuat)
        {
            return _microbiologyTestResultRepository.Get_DanhSach_KhangSinh(maTiepNhan, maYeuCau, maViKhuan, maKhangSinh,lanXN, kyThuat);
        }
        public bool Update_KetQuaViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, bool mic, string ketQuaESBL, string KetQuaBetaLactamases)
        {
            return _microbiologyTestResultRepository.Update_KetQuaViKhuan(maTiepNhan, maYeuCau, maViKhuan, mic, ketQuaESBL, KetQuaBetaLactamases);
        }
        public bool Update_KetQuaKhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat
             , string ketQuaSRI, string ketQuaDinhLuong, int coKetQua, string nguoiThucHien, int lanXN, string idCard = "", int idMay = 0
             , string SRI = "", string Site_Infection = "")
        {
            return _microbiologyTestResultRepository.Update_KetQuaKhangSinh(maTiepNhan, maYeuCau, maViKhuan, maKhangSinh, kyThuat
             , ketQuaSRI, ketQuaDinhLuong, coKetQua, nguoiThucHien, lanXN, idCard, idMay, SRI, Site_Infection);
        }
        public int Update_GhiChu_QuyTrinh_PhuongPhap(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat
            , string ghiChu, string quyTrinh, string phuongPhap)
        {
            return _microbiologyTestResultRepository.Update_GhiChu_QuyTrinh_PhuongPhap(maTiepNhan, maYeuCau, maViKhuan, maKhangSinh, kyThuat
            , ghiChu, quyTrinh, phuongPhap);
        }
        public DataTable DuLieuIn(string maTiepNhan, string maChiDinh, string maViKhuan, bool inKQSoiNhuom
            , bool inKQNam, bool inKQCay, bool inTatCa, string nguoiKy, string kyThuat)
        {
            return _microbiologyTestResultRepository.DuLieuIn(maTiepNhan, maChiDinh, maViKhuan, inKQSoiNhuom
            , inKQNam, inKQCay, inTatCa, nguoiKy, kyThuat);
        }

        //kết qyả khảo sát đại thể
        public bool Insert_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            return _microbiologyTestResultRepository.Insert_ketqua_cls_xetnghiem_khaosatdaithe(objInfo);
        }
        public bool Update_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            return _microbiologyTestResultRepository.Update_ketqua_cls_xetnghiem_khaosatdaithe(objInfo);
        }
        public bool Delete_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            return _microbiologyTestResultRepository.Delete_ketqua_cls_xetnghiem_khaosatdaithe(objInfo);
        }
        public DataTable Data_ketqua_cls_xetnghiem_khaosatdaithe(string matiepnhan, string makhaosat, string mayeucau)
        {
            return _microbiologyTestResultRepository.Data_ketqua_cls_xetnghiem_khaosatdaithe(matiepnhan, makhaosat, mayeucau);
        }
        public DataTable Get_Data_ketqua_cls_xetnghiem_khaosatdaithe(DataGridView dtg, BindingNavigator bv, string matiepnhan, string makhaosat, string mayeucau)
        {
            return _microbiologyTestResultRepository.Get_Data_ketqua_cls_xetnghiem_khaosatdaithe(dtg, bv, matiepnhan, makhaosat, mayeucau);
        }
        public KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE Get_Info_ketqua_cls_xetnghiem_khaosatdaithe(string matiepnhan, string makhaosat, string mayeucau)
        {
            return _microbiologyTestResultRepository.Get_Info_ketqua_cls_xetnghiem_khaosatdaithe(matiepnhan, makhaosat, mayeucau);
        }
        #region kháng kháng sinh
        public BaseModel Insert_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo)
        {
            return _microbiologyTestResultRepository.Insert_ketqua_cls_xetnghiem_visinh_khangkhangsinh(objInfo);
        }

        public bool Update_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo)
        {

            return _microbiologyTestResultRepository.Update_ketqua_cls_xetnghiem_visinh_khangkhangsinh(objInfo);
        }

        public bool Delete_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo)
        {

            return _microbiologyTestResultRepository.Delete_ketqua_cls_xetnghiem_visinh_khangkhangsinh(objInfo);
        }

        public DataTable Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh)
        {

            return _microbiologyTestResultRepository.Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(matiepnhan, mayeucau, maphanloai, makhangkhangsinh);
        }

        public DataTable Get_Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(DataGridView dtg, BindingNavigator bv, string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh)
        {

            return _microbiologyTestResultRepository.Get_Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(dtg, bv, matiepnhan, mayeucau, maphanloai, makhangkhangsinh);
        }

        public KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH Get_Info_ketqua_cls_xetnghiem_visinh_khangkhangsinh(string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh)
        {

            return _microbiologyTestResultRepository.Get_Info_ketqua_cls_xetnghiem_visinh_khangkhangsinh(matiepnhan, mayeucau, maphanloai, makhangkhangsinh);
        }
        public bool Insert_ketqua_cls_xetnghiem_vikhuan_amtinh(string maTiepNhan, string maYeuCau,
    string maPhanLoaiViKhuan
    , string nguoiNhap, string kyThuat, int lanXetnghiem)
        {
            return _microbiologyTestResultRepository.Insert_ketqua_cls_xetnghiem_vikhuan_amtinh(maTiepNhan, maYeuCau, maPhanLoaiViKhuan
                , nguoiNhap, kyThuat, lanXetnghiem);
        }
        public bool Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(string matiepNhan, string maYeuCau, string maVikhuan
       , string maKhangsinh, string kyThuat, string nguoinhap, int lanXN)
        {
            return _microbiologyTestResultRepository.Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(matiepNhan, maYeuCau, maVikhuan
                , maKhangsinh, kyThuat, nguoinhap, lanXN);
        }
        public bool Check_Existed_dm_xetnghiem_khangsinh_bo_chitiet(string maBoKhangSinh, string maViKhuan,
      string kyThuat)
        {
            return _microbiologyTestResultRepository.Check_Existed_dm_xetnghiem_khangsinh_bo_chitiet(maBoKhangSinh, maViKhuan, kyThuat);
        }
        public DataTable DanhSach_TheDinhDanh(string maTiepNhan, string maYeuCau)
        {
            return _microbiologyTestResultRepository.DanhSach_TheDinhDanh(maTiepNhan, maYeuCau);
        }
        public bool CapNhat_MauViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, string maMau, int lanXN)
        {
            return _microbiologyTestResultRepository.CapNhat_MauViKhuan(maTiepNhan, maYeuCau, maViKhuan, maMau, lanXN);
        }
        public int CapNhat_ThongTinMayXN_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, int idMayXn, int lanXetNghiem = 1)
        {
            return _microbiologyTestResultRepository.CapNhat_ThongTinMayXN_ViKhuan(maTiepNhan, maYeuCau, maViKhuan, idMayXn, lanXetNghiem);
        }
        public bool CapNhat_GhiChu_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, string ghiChu, string nguoiNhap, int lanXN)
        {
            return _microbiologyTestResultRepository.CapNhat_GhiChu_ViKhuan(maTiepNhan, maYeuCau, maViKhuan, ghiChu, nguoiNhap, lanXN);
        }
        public int CapNhat_ThongTinQuyTrinh_LoaiMau(string maTiepNhan, string maYeuCau, int idMayXn)
        {
            return _microbiologyTestResultRepository.CapNhat_ThongTinQuyTrinh_LoaiMau(maTiepNhan, maYeuCau, idMayXn); 
        }
        #endregion
        #region Phiếu tiến trình
        public bool Insert_Update_ViSinh_PhieuTienTrinh(string maTiepNhan, string maXN, string maSoMau, string nguoiThucHien
            , DateTime thoiGianThucHien, string noiDung, string nguoiSua, int AutoID = -100)
        {
            return _microbiologyTestResultRepository.Insert_Update_ViSinh_PhieuTienTrinh(maTiepNhan, maXN, maSoMau
                , nguoiThucHien, thoiGianThucHien, noiDung, nguoiSua, AutoID);
        }

        public DataTable Get_PhieuTienTrinh(string maTiepNhan, string maYeuCau, string maSoMau)
        {
            return _microbiologyTestResultRepository.Get_PhieuTienTrinh(maTiepNhan, maYeuCau, maSoMau);
        }
        public bool Delete_PhieuTienTrinh(string ids)
        {
            return _microbiologyTestResultRepository.Delete_PhieuTienTrinh(ids);
        }

        public DataTable DuLieuInPhieuTienTrinh(string maTiepNhan, bool inTieuDe, string maSoMau)
        {
            return _microbiologyTestResultRepository.DuLieuInPhieuTienTrinh(maTiepNhan, inTieuDe, maSoMau);
        }
        public DataTable Data_ketqua_cls_xetnghiem_visinh_phieutientrinh(string matiepnhan, string mayeucau, bool checkDaLayMau, bool checkDaNhanMau)
        {
            return _microbiologyTestResultRepository.Data_ketqua_cls_xetnghiem_visinh_phieutientrinh( matiepnhan,  mayeucau,  checkDaLayMau,  checkDaNhanMau); 
        }

        #endregion
    }
}
