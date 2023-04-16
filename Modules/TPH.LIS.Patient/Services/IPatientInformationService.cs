using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Log;
using TPH.LIS.Patient.Model;
using TPH.LIS.User.Enum;

namespace TPH.LIS.Patient.Services
{
    public interface IPatientInformationService
    {
        #region Thông tin bệnh nhân
        DataTable DanhSachBenhNhan(string maBn);
        int InsertBenhNhan(string maBn, string maTiepNhan);
        int DeleteBenhNhan(string maBn);
        #endregion
        #region Thông tin tiếp nhận bệnh nhân
        bool Insert_BenhNhan_TiepNhan(BENHNHAN_TIEPNHAN objInfo, bool showmMess);
        bool Insert_BenhNhan_TuMau(BENHNHAN_TIEPNHAN objInfo, bool showmMess);
        int InsUpdDelAnaPathPatient(BENHNHAN_TIEPNHAN objInfo, string actionFlag);
        bool Update_BenhNhan_TiepNhan(BENHNHAN_TIEPNHAN objInfo);
        bool UpdatePatientInfoADT(BENHNHAN_TIEPNHAN objInfo);
        bool UpdatePatientInfoADTInternal_Manual(BENHNHAN_TIEPNHAN objInfo);
        double Get_MaBnNhanGanNhat();
        bool Delete_BenhNhan_TiepNhan(string maTiepNhan, string UserAction);
        int Update_NgayChiDinh(string maTiepNhan, DateTime NgayChiDinh);
        int PatientLog(string maTiepNhan, string userAction, LogActionId action);
        DataTable Data_BenhNhan_TiepNhan(string matiepnhan, string[] condition);
        DataTable Get_Data_BenhNhan_TiepNhan(DataGridView dtg, BindingNavigator bv, string matiepnhan, string[] condition, string bophanXN = "");
        BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(string matiepnhan, string[] condition);
        BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(DataTable dtTiepNhan);
        BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(DataRow dr);
        string Get_MaTiepNhanByBarcode(string barcode);
        #endregion
        #region Bệnh nhân Dv Khác

        bool Insert_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo);

        bool Update_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo);

        bool Delete_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo);

        DataTable Data_BenhNhan_CLS_DVKhac(string matiepnhan);

        DataTable Get_Data_BenhNhan_CLS_DVKhac(DataGridView dtg, BindingNavigator bv, string matiepnhan);

        BENHNHAN_CLS_DVKHAC Get_Info_BenhNhan_CLS_DVKhac(string matiepnhan);

        #endregion
        #region Thông tin bệnh nhân nội soi

        bool Insert_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo);

        bool Update_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo);

        bool Delete_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo);

        DataTable Data_BenhNhan_CLS_NoiSoi(string matiepnhan);

        DataTable Get_Data_BenhNhan_CLS_NoiSoi(DataGridView dtg, BindingNavigator bv, string matiepnhan);

        #endregion
        #region Thông tin bệnh nhân siêu âm

        BENHNHAN_CLS_NOISOI Get_Info_BenhNhan_CLS_NoiSoi(string matiepnhan);

        bool Insert_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo);

        bool Update_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo);

        bool Delete_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo);

        DataTable Data_BenhNhan_CLS_SieuAm(string matiepnhan);
        DataTable Get_Data_BenhNhan_CLS_SieuAm(DataGridView dtg, BindingNavigator bv, string matiepnhan);

        BENHNHAN_CLS_SIEUAM Get_Info_BenhNhan_CLS_SieuAm(string matiepnhan);

        #endregion
        #region Thông tin bệnh nhân xét nghiệm
        bool Insert_BenhNhan_CLS_XetNghiem(string maTiepNhan);
        bool Update_BenhNhan_CLS_XetNghiem(BENHNHAN_CLS_XETNGHIEM objInfo);
        bool Delete_BenhNhan_CLS_XetNghiem(BENHNHAN_CLS_XETNGHIEM objInfo);
        DataTable Data_BenhNhan_CLS_XetNghiem(string matiepnhan);
        DataTable Get_Data_BenhNhan_CLS_XetNghiem(DataGridView dtg, BindingNavigator bv, string matiepnhan);
        BENHNHAN_CLS_XETNGHIEM Get_Info_BenhNhan_CLS_XetNghiem(string matiepnhan);
        #endregion
        #region Thông tin bệnh nhân xquang

        bool Insert_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo);

        bool Update_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo);
        bool Delete_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo);
        DataTable Data_BenhNhan_CLS_XQuang(string matiepnhan);

        DataTable Get_Data_BenhNhan_CLS_XQuang(DataGridView dtg, BindingNavigator bv, string matiepnhan);
        BENHNHAN_CLS_XQUANG Get_Info_BenhNhan_CLS_XQuang(string matiepnhan);

        #endregion
        #region Chỉ định dịch vụ
        List<SeviceOrderedInformation> GetOrderServiceDetail(string condit, bool checkGia, string idPhieuIn, bool Xngui, bool sapXepTheoThuTuInNhom);
        List<SeviceOrderedInformation> OrderedServices(string condit, bool sapXepTheoThuTuInNhom);
        #endregion
        #region  Thao tác thông tin bệnh nhân
        bool Check_TonTai_MaTiepNhan(string matiepNhan);
        DataTable LayThongtin_TiepNhan_TheoMaBN(string _MaBN);
        DataTable LayThongtin_TiepNhan_TheoSoDienThoai(string sodienThoai);
        DataTable LayThongtin_TiepNhan_IdCongDan(string idCongDan);
        DataTable LayDanhSach_TiepNhan_TheoMaBN(string _MaBN);
        DataTable LayDanhSach_NoiTru(string _MaBN, string _Name);
        DataTable LayDanhSach_LichSuNoiTru(string _MaBN, string _Name);
        bool Insert_BenhNhan_ThongTinChiTiet(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec
                     , string _quoctich);
        bool Update_BENHNHAN_THONGTINCHITIET(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec
                                   , string _quoctich);
        bool Delete_BENHNHAN_THONGTINCHITIET(string _mabn);
        DataTable TimBenhNhan(SearchPatientCondit objCondit);
        DataTable TimBenhNhanXetNghiem(SearchPatientCondit_XN objCondit);
        bool Update_KetQua_huyetTuyDo(BENHNHAN_CLS_XETNGHIEM objInfo);
        bool Update_DaNhanMau_Mau(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien);
        bool Update_DaNhanMau_NT(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien);
        bool Update_DaNhanMau_ViSinh(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien);

        bool Update_DaLayMau_Mau(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien);
        bool Update_DaLayMau_NT(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien);
        bool Update_DaLayMau_ViSinh(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien);
        DataTable Calculate_TraKetQua(string maTiepNhan, string soHoSo, DateTime? ngayTiepNhan, string barcode
            , string GioLamViec, string GioNghiTrua, string GioLamChieu, string GioNghiChieu, int NghiCuoiTuan, ServiceType[] arrLoaiDichVu, bool traTheoXnNghiem);
        bool Update_GhiChuHenTraKQ(string matTiepNhan, string maXn, string maNhom, bool cotKetQua, string noidung, DateTime tgtraKQ);
        #endregion
        #region Trả kết quả
        DataTable DanhSach_ChoTraKetQua(bool TheoNgayHen, bool ThuongQuy, string KhoaPhong, int soPhut);
        int Update_TraKetqua(string matiepnhan, string userThucHien, string nguoiNhan, string noiNhan, bool thucHienTra);
        DataTable Calculate_TraKetQuaXN(string maTiepNhan, string GioLamViec, string GioNghiTrua, string GioLamChieu, string GioNghiChieu, int NghiCuoiTuan, int cachTinhThoigian);
        int Update_ThoiGianThucHienXN(string matiepnhan);
        int Update_ThoiGianThucHienXN_Nhom(string matiepnhan, int loaiThoigian);

        DateTime NgayTiepNhan_TheoBarcode(string barcode);
        #endregion
        #region Trạng thái mẫu
        bool KiemTraCoKetQua(string maTiepNhan, string maNhomLoaiMau);
        bool KiemTraKetQuaDaGuiHis(string maTiepNhan, string maNhomLoaiMau);
        bool Update_MauXn_LayMau(List<LayMauInfo> info);
        bool Update_TG_Khoa_User_LayMau(List<LayMauInfo> info);
        bool Update_MauXn_NhanMau(List<NhanMauInfo> lstNhanMau);
        bool Update_IDChuyenMau(List<NhanMauInfo> lstNhanMau);
        int Update_TrangThaiLayMau_NhanMau(string matiepnhan, bool fromNhanmau, bool daNhanMau);
        int Update_TrangThaiLayMau(string matiepnhan);
        bool Update_MauXn_HoanDichVu_TuChoiMau(List<TuChoiMauInfo> lstNhanMau);
        bool Insert_nhatky_mauxetnghiem(List<NHATKY_MAUXETNGHIEM> lstObjInfo);
        DataTable Data_nhatky_mauxetnghiem(string id, string matiepnhan, string nguoithuchien, DateTime? tungay, DateTime? dengay, bool xemChiTiet, string allowNhom);
        DataTable Data_NhatKy_DoiGioThaoTacMau(DateTime? tungay, DateTime? denngay, string matiepNhan, string nguoiThucHien);
        DataTable DanhSach_MaTiepNhan_TheoSHS(string soHoSo);
        DataTable DanhSach_MaTiepNhan_TheoBarcode(string barcode);
        DataTable DanhSach_BenhNhan_TheoTrangThaiMau(DieuKienTimDanhSachBNTheoTrangThaiMau condit);
        DataTable DanhSachOngMau(string maTiepNhan, enumThucHien daLayMau, enumThucHien daNhanMau
            , enumThucHien daTuChoi, bool checkPhanQuyenNhom, string userCheckQuyenNhom, int idLayLoaiMau);
        DataTable DanhSachChiDinh_OngMau(string maTiepNhan, int idLayLoaiMau);
        int Update_TinhTrangMau(string maTiepNhan, string lstMaXn, string tinhtrangmau, bool checkXacNhanHis);
        int Update_ThoigianThaoTacMau(CapNhatThaoTacMau objInfo);
        int Update_TrangThaiNhanMau(string matiepnhan, bool nhanMau);
        int Update_XetNghiem_MaSoBenhPhamGui(string maTiepNhan, string maXN, string maBenhPham);
        bool update_XN_TGChuyen_BNCLSXN(string matiepnhan);
        bool Check_OpenOrder(string matiepnhan);
        int Update_OpenOrder(string matiepnhan, string nguoithuchien, string userid, string pcname);
        DataTable Data_ChiDinhDaNhanMau(string maTiepNhan);
        DataTable Data_ChiDinhDaLayMau(string maTiepNhan);
        int Insert_Update_KiemSoatLayMau(string userID, List<string> lstDnMau, DateTime TGGianBatDau, DateTime TGKhoa, bool dangKhoa);
        KiemSoatChayMau ThongKiemSoatLayMau(string userId);
        //Thông tin chuyển mẫu
        TaoMoiChuyenMau Create_ChuyenMau_IdChuyenMau(TaoMoiChuyenMau obj);
        bool Insert_ChuyenMau_ChiTiet(ThemChuyenMauChiTiet obj);
        bool Update_ChuyenMau_XacNhanChuyen(CapNhatChuyenMau obj);
        bool Update_ChuyenMau_SoLuong(long IDChuyenMau, string Barcode, string maOngMau, bool tang);
        DataTable Data_ChuyenMau(long? IDChuyenMau, DateTime? TuNgay, DateTime? DenNgay, string userTao = "");
        DataTable Data_ChuyenMau_ChiTiet(long? IDChuyenMau, string Barcode
            , DateTime? TuNgay, DateTime? DenNgay, string userTao = "");
        bool Delete_ChuyenMau(long IDChuyenMau);
        bool Delete_ChuyenMau_ChiTiet(long IDChuyenMau);
        #endregion
        DataTable Data_ChiDInhTheoSoHoSo(string soHoSo, string sophieuChiDinh, string maBenhNhan);
        DataTable Data_TheoDoiMau(string maBenhNhan, string maTiepNhan, string barcode, string maHosSo
            , string allowBophan, DateTime? ngayKiemTra);
        bool DuaVaoDanhSachUploadHIS(string maTiepNhan);
        #region Quản lý phân phối bàn
        bool Insert_LayMauDangKyBan(string maNguoiDung, int soBan, string maKhuLayMau, string pcName);
        bool Update_LayMauLogOut(string maNguoiDung, int soBan, string maKhuLayMau, string pcName);
        bool Update_LayMauTamDung(string maNguoiDung, int soBan, string maKhuLayMau, bool tamDung);
        DataTable DanhSach_LayMau_DaDangKySoBan(string maNguoiDung, int soBan, string maKhuLayMau, bool checkChuaDangXuat);
        DataTable LayMau_LaySoBan(string maKhuLayMau);
        #endregion
        #region Quản lý đăng nhập lấy mẫu
        bool Insert_LayMauThuCong_DangNhap(string maNguoiDung, string maKhuLayMau);
        bool Update_LayMauThuCong_LogOut(int idDangNhap);
        DataTable DanhSach_LayMau_DangNhap(string maKhuLayMau);
        #endregion
        #region Chuyển kết quả
        long Insert_PhieuChuyenKQ(string nguoiChuyen, string pcChuyen);
        int Delete_PhieuChuyenKQ(long idChuyenMau);
        DataTable DanhSach_PhieuChuyenKetQua(DateTime ngayChuyen, string barcode);
        int Insert_PhieuChuyenMau_ChiTiet(CHUYENPHIEUKETQUA_CHITIET objInfo);
        int Update_PhieuChuyenKQ_XacNhanChuyen(long idChuyenKetQua, string nguoiXacNhan, string tenMayTinhXacNhan, bool thucHienChuyen);
        int Update_PhieuChuyenKQ_DaNhanKetQua(long idCHiTiet, long idChuyenKetQua, string nguoiNhan, string tenMayTinhNhan, string maTiepNhan);
        DataTable DanhSach_ThongTinChuyenChuyenKQ_TheoID(int idChuyenKetQua);
        DataTable DanhSach_ChuyenChuyenKQ_TheoID(int idChuyenKetQua);
        DataTable DanhSach_ChuyenChuyenKQ_TheoBarcode(string barcode);
        int Xoa_ChuyenChuyenK_ChiTiet(long idChitiet);
        DataTable DanhSach_ChuyenKQ_InPhieu(long idChuyen);
        DataTable DanhSach_NhanKetQQua_InPhieu(long idChuyen);
        #endregion
        #region Lưu mẫu
        int ThemOngMauLuu(ArchiveSample tubeInfo);
        long GetIDLuuMau(ArchiveSample tubeInfo);
        int XoaOngMauLuu(long Idluumau, string nguoiXoa, string PCXoa);
        int HuyOngMauLuu(long Idluumau, string nguoiHuy, string PCHuy);
        DataTable DanhSach_OngMauLuu(string Barcode, string MaSoHop, string MaSoTu);
        int DuyetMauLuu(long Idluumau, string nguoiduyet, string PCHuy, bool thuchienDuyet);
        DataTable DanhSach_OngMauLuuTheoNgay(DateTime? TuNgay, DateTime? DenNgay, string Barcode, string MaSoHop, string MaSoTu);
        DataTable DanhSach_OngMauHuyTheoNgay(DateTime? TuNgay, DateTime? DenNgay, string Barcode, string MaSoHop, string MaSoTu);
        DataTable ChiTiet_OngMauLuuTheoViTri(string MaSoHop, string MaSoTu, int viTri);
        DataTable OngMau_LoaiMauChinh(string barcode, string manhom);
        ArchiveSample Get_Info_mauxetnghiem_luumau(long idLuuMau);
        ArchiveSample Get_Info_mauxetnghiem_luumau_FromDatarow(DataRow dr);
        #endregion
        #region Thông tin sàn lọc sơ sinh 
        int Insert_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj);
        int Update_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj);
        int Delete_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj);
        DataTable Data_ThongTinSLSoSinh(string maTiepNhan);
        BENHNHAN_MAUSANGLOC Get_ThongTinSLSoSinh(string maTiepNhan);
        BENHNHAN_MAUSANGLOC Get_ThongTinSLSoSinh_ByRow(DataRow dr);
        DataTable Data_DSTreSoSinhSangLoc(DateTime fromDate, DateTime toDate);
        DataTable Data_DSSangLocTruocSinh(DateTime fromDate, DateTime toDate);
        int Update_NhanXetDeNghi_SangLoc(string maTiepNhan, string nhanXet, string nguoiNhanXet, string deNghi, string nguoiDeNghi, string ketLuan, string nguoiKetLuan);
        DataTable Data_PhieuHen_SLSS(string matiepNhan);
        #endregion
        #region Chi dinh tu mau
        int DeleteOrderOfElement(string sid, string elementId, string userDel, string pcDel);
        int DeletePatientWithoutElement(string sid, string userDel, string pcDel);
        #endregion
        #region Chi dinh GPB
        int DeleteOrderOfGPB(string sid, string testcodeLis, string userDel, string pcDel);
        int DeletePatientWithoutGPB(string sid, string userDel, string pcDel);
        #endregion
        #region xetnghiem_ghichu_laymau
        int Insert_xetnghiem_ghichu_laymau(XETNGHIEM_GHICHU_LAYMAU objInfo);
        int Delete_xetnghiem_ghichu_laymau(XETNGHIEM_GHICHU_LAYMAU objInfo);
        DataTable Data_xetnghiem_ghichu_laymau(string maxn, string matiepnhan);
        XETNGHIEM_GHICHU_LAYMAU Get_Info_xetnghiem_ghichu_laymau(DataRow drInfo);
        XETNGHIEM_GHICHU_LAYMAU Get_Info_xetnghiem_ghichu_laymau(string maxn, string matiepnhan);
        bool CheckExists_xetnghiem_ghichu_laymau(string maxn, string matiepnhan);
        #endregion
        #region Quản lý gửi mẫu nội bộ
        int Insert_GuimauNoiBo(GuiMauNoiBoModel info);
        int Insert_NhatKyGuiMauNoiBo(GuiMauNoiBoModel info);
        int Delete_XetNghiem_GuiMau(GuiMauNoiBoModel info);
        int Update_XetNghiem_NhanMauGui(GuiMauNoiBoModel info);
        DataTable Data_XetNghiem_GuiMau(string lstMaTiepNhan, int trangThaiNhan, string[] arrPhanQuyenNhom);
        int Update_TrangThaiGuiMau_Nhom(string maTiepNhan, string maNhomCLS);
        int Update_TrangThaiNhanMauGui_Nhom(string maTiepNhan, string maNhomCLS);
        int Update_TrangThaiGuiMau_BoPhan(string maTiepNhan);
        #endregion
        #region Gửi mẫu cho đơn vị khác
        int Insert_xetnghiem_guimau(XETNGHIEM_GUIMAU objInfo);
        int Update_xetnghiem_guimau_donvinhan(XETNGHIEM_GUIMAU objInfo);
        int Update_xetnghiem_guimau_xacnhangui(XETNGHIEM_GUIMAU objInfo);
        int Delete_xetnghiem_guimau(string matiepnhan, string maxn, string NguoiXoa, string PCXoa);
        DataTable Data_xetnghiem_guimau(string matiepnhan, string maxn, string donvinhan, DateTime? ngaytao);
        DataTable Data_xetnghiem_guimau_daxoa(string matiepnhan, string maxn, string donvinhan, DateTime? ngaytao);
        XETNGHIEM_GUIMAU Get_Info_xetnghiem_guimau(DataRow drInfo);
        XETNGHIEM_GUIMAU Get_Info_xetnghiem_guimau(string matiepnhan, string maxn);
        bool CheckExists_xetnghiem_guimau(string matiepnhan, string maxn);

        int Insert_xetnghiem_guimau_ketqua(XETNGHIEM_GUIMAU_KETQUA objInfo);
        int Update_xetnghiem_guimau_ketqua(XETNGHIEM_GUIMAU_KETQUA objInfo);
        int Delete_xetnghiem_guimau_ketqua(int id);
        DataTable Data_xetnghiem_guimau_ketqua(int id);
        XETNGHIEM_GUIMAU_KETQUA Get_Info_xetnghiem_guimau_ketqua(DataRow drInfo);
        XETNGHIEM_GUIMAU_KETQUA Get_Info_xetnghiem_guimau_ketqua(int id);
        bool CheckExists_xetnghiem_guimau_ketqua(int id);
        #endregion
    }
}
