using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Log;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Repositories;
using TPH.LIS.User.Enum;

namespace TPH.LIS.Patient.Services
{
    public class PatientInformationService : IPatientInformationService
    {
        public readonly IPatientInformationRepository InformationRepository;

        #region Thông tin bệnh nhân
        public DataTable DanhSachBenhNhan(string maBn)
        {
            return InformationRepository.DanhSachBenhNhan(maBn);
        }
        public int InsertBenhNhan(string maBn, string maTiepNhan)
        {
            return InformationRepository.InsertBenhNhan(maBn, maTiepNhan);
        }
        public int DeleteBenhNhan(string maBn)
        {
            return InformationRepository.DeleteBenhNhan(maBn);
        }
        #endregion
        #region Thông tin tiếp nhận bệnh nhân

        public PatientInformationService(IPatientInformationRepository informationRepository)
        {
            InformationRepository = informationRepository ?? new PatientInformationRepository();
        }

        public PatientInformationService() : this(null)
        {
        }

        public bool Insert_BenhNhan_TiepNhan(BENHNHAN_TIEPNHAN objInfo, bool showmMess)
        {
            return InformationRepository.Insert_BenhNhan_TiepNhan(objInfo, showmMess);
        }
        public bool Insert_BenhNhan_TuMau(BENHNHAN_TIEPNHAN objInfo, bool showmMess)
        {
            return InformationRepository.Insert_BenhNhan_TuMau(objInfo, showmMess);
        }
        public int InsUpdDelAnaPathPatient(BENHNHAN_TIEPNHAN objInfo, string actionFlag)
        {
            return InformationRepository.InsUpdDelAnaPathPatient(objInfo, actionFlag);
        }
        public bool Update_BenhNhan_TiepNhan(BENHNHAN_TIEPNHAN objInfo)
        {
            return InformationRepository.Update_BenhNhan_TiepNhan(objInfo);
        }
        public bool UpdatePatientInfoADT(BENHNHAN_TIEPNHAN objInfo)
        {
            return InformationRepository.UpdatePatientInfoADT(objInfo);
        }
        public bool UpdatePatientInfoADTInternal_Manual(BENHNHAN_TIEPNHAN objInfo)
        {
            return InformationRepository.UpdatePatientInfoADTInternal_Manual(objInfo);
        }
        public double Get_MaBnNhanGanNhat()
        {
            return InformationRepository.Get_MaBnNhanGanNhat();
        }
        public bool Delete_BenhNhan_TiepNhan(string maTiepNhan, string UserAction)
        {
            return InformationRepository.Delete_BenhNhan_TiepNhan(maTiepNhan, UserAction);
        }

        public int Update_NgayChiDinh(string maTiepNhan, DateTime NgayChiDinh)
        {
            return InformationRepository.Update_NgayChiDinh(maTiepNhan, NgayChiDinh);
        }
        public int PatientLog(string maTiepNhan, string userAction, LogActionId action)
        {
            return InformationRepository.PatientLog(maTiepNhan, userAction, action);
        }
        public DataTable Data_BenhNhan_TiepNhan(string matiepnhan, string[] condition)
        {
            return InformationRepository.Data_BenhNhan_TiepNhan(matiepnhan, condition);
        }

        public DataTable Get_Data_BenhNhan_TiepNhan(DataGridView dtg, BindingNavigator bv, string matiepnhan, string[] condition, string bophanXN = "")
        {
            return InformationRepository.Get_Data_BenhNhan_TiepNhan(dtg, bv, matiepnhan, condition, bophanXN);
        }

        public BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(string matiepnhan, string[] condition)
        {
            return InformationRepository.Get_Info_BenhNhan_TiepNhan(matiepnhan, condition);
        }
        public BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(DataTable dtTiepNhan)
        {
            return InformationRepository.Get_Info_BenhNhan_TiepNhan(dtTiepNhan);
        }
        public BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(DataRow dr)
        {
            return InformationRepository.Get_Info_BenhNhan_TiepNhan(dr);
        }
        public string Get_MaTiepNhanByBarcode(string barcode)
        {
            return InformationRepository.Get_MaTiepNhanByBarcode(barcode);
        }
        #endregion

        #region Bệnh nhân Dv Khác

        public bool Insert_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo)
        {
            return InformationRepository.Insert_BenhNhan_CLS_DVKhac(objInfo);
        }

        public bool Update_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo)
        {
            return InformationRepository.Update_BenhNhan_CLS_DVKhac(objInfo);
        }

        public bool Delete_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo)
        {
            return InformationRepository.Delete_BenhNhan_CLS_DVKhac(objInfo);
        }

        public DataTable Data_BenhNhan_CLS_DVKhac(string matiepnhan)
        {
            return InformationRepository.Data_BenhNhan_CLS_DVKhac(matiepnhan);
        }

        public DataTable Get_Data_BenhNhan_CLS_DVKhac(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            return InformationRepository.Get_Data_BenhNhan_CLS_DVKhac(dtg, bv, matiepnhan);
        }

        public BENHNHAN_CLS_DVKHAC Get_Info_BenhNhan_CLS_DVKhac(string matiepnhan)
        {
            return InformationRepository.Get_Info_BenhNhan_CLS_DVKhac(matiepnhan);
        }

        #endregion

        #region Thông tin bệnh nhân nội soi

        public bool Insert_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo)
        {
            return InformationRepository.Insert_BenhNhan_CLS_NoiSoi(objInfo);
        }

        public bool Update_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo)
        {
            return InformationRepository.Update_BenhNhan_CLS_NoiSoi(objInfo);
        }

        public bool Delete_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo)
        {
            return InformationRepository.Delete_BenhNhan_CLS_NoiSoi(objInfo);
        }

        public DataTable Data_BenhNhan_CLS_NoiSoi(string matiepnhan)
        {
            return InformationRepository.Data_BenhNhan_CLS_NoiSoi(matiepnhan);
        }

        public DataTable Get_Data_BenhNhan_CLS_NoiSoi(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            return InformationRepository.Get_Data_BenhNhan_CLS_NoiSoi(dtg, bv, matiepnhan);
        }

        #endregion

        #region Thông tin bệnh nhân siêu âm

        public BENHNHAN_CLS_NOISOI Get_Info_BenhNhan_CLS_NoiSoi(string matiepnhan)
        {
            return InformationRepository.Get_Info_BenhNhan_CLS_NoiSoi(matiepnhan);
        }

        public bool Insert_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo)
        {
            return InformationRepository.Insert_BenhNhan_CLS_SieuAm(objInfo);
        }

        public bool Update_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo)
        {
            return InformationRepository.Update_BenhNhan_CLS_SieuAm(objInfo);
        }

        public bool Delete_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo)
        {
            return InformationRepository.Delete_BenhNhan_CLS_SieuAm(objInfo);
        }

        public DataTable Data_BenhNhan_CLS_SieuAm(string matiepnhan)
        {
            return InformationRepository.Data_BenhNhan_CLS_SieuAm(matiepnhan);
        }

        public DataTable Get_Data_BenhNhan_CLS_SieuAm(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            return InformationRepository.Get_Data_BenhNhan_CLS_SieuAm(dtg, bv, matiepnhan);
        }

        public BENHNHAN_CLS_SIEUAM Get_Info_BenhNhan_CLS_SieuAm(string matiepnhan)
        {
            return InformationRepository.Get_Info_BenhNhan_CLS_SieuAm(matiepnhan);
        }

        #endregion

        #region Thông tin bệnh nhân xét nghiệm

        public bool Insert_BenhNhan_CLS_XetNghiem(string maTiepNhan)
        {
            return InformationRepository.Insert_BenhNhan_CLS_XetNghiem(maTiepNhan);
        }

        public bool Update_BenhNhan_CLS_XetNghiem(BENHNHAN_CLS_XETNGHIEM objInfo)
        {
            return InformationRepository.Update_BenhNhan_CLS_XetNghiem(objInfo);
        }

        public bool Delete_BenhNhan_CLS_XetNghiem(BENHNHAN_CLS_XETNGHIEM objInfo)
        {
            return InformationRepository.Delete_BenhNhan_CLS_XetNghiem(objInfo);
        }

        public DataTable Data_BenhNhan_CLS_XetNghiem(string matiepnhan)
        {
            return InformationRepository.Data_benhnhan_cls_xetnghiem(matiepnhan);
        }

        public DataTable Get_Data_BenhNhan_CLS_XetNghiem(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            return InformationRepository.Get_Data_benhnhan_cls_xetnghiem(dtg, bv, matiepnhan);
        }
        public BENHNHAN_CLS_XETNGHIEM Get_Info_BenhNhan_CLS_XetNghiem(string matiepnhan)
        {
            return InformationRepository.Get_Info_benhnhan_cls_xetnghiem(matiepnhan);
        }

        #endregion

        #region Thông tin bệnh nhân xquang

        public bool Insert_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo)
        {
            return InformationRepository.Insert_BenhNhan_CLS_XQuang(objInfo);
        }

        public bool Update_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo)
        {
            return InformationRepository.Update_BenhNhan_CLS_XQuang(objInfo);
        }

        public bool Delete_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo)
        {
            return InformationRepository.Delete_BenhNhan_CLS_XQuang(objInfo);
        }

        public DataTable Data_BenhNhan_CLS_XQuang(string matiepnhan)
        {
            return InformationRepository.Data_BenhNhan_CLS_XQuang(matiepnhan);
        }

        public DataTable Get_Data_BenhNhan_CLS_XQuang(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            return InformationRepository.Get_Data_BenhNhan_CLS_XQuang(dtg, bv, matiepnhan);
        }

        public BENHNHAN_CLS_XQUANG Get_Info_BenhNhan_CLS_XQuang(string matiepnhan)
        {
            return InformationRepository.Get_Info_BenhNhan_CLS_XQuang(matiepnhan);
        }

        #endregion
        #region Chỉ định dịch vụ
        public List<SeviceOrderedInformation> GetOrderServiceDetail(string condit, bool checkGia, string idPhieuIn, bool Xngui, bool sapXepTheoThuTuInNhom)
        {
            return InformationRepository.GetOrderServiceDetail(condit, checkGia, idPhieuIn, Xngui, sapXepTheoThuTuInNhom);
        }
        public List<SeviceOrderedInformation> OrderedServices(string condit, bool sapXepTheoThuTuInNhom)
        {
            return InformationRepository.OrderedServices(condit, sapXepTheoThuTuInNhom);
        }
        #endregion
        #region  Thao tác thông tin bệnh nhân
        public bool Check_TonTai_MaTiepNhan(string matiepNhan)
        {
            return InformationRepository.Check_TonTai_MaTiepNhan(matiepNhan);
        }
        public DataTable LayThongtin_TiepNhan_TheoMaBN(string _MaBN)
        {
            return InformationRepository.LayThongtin_TiepNhan_TheoMaBN(_MaBN);
        }
        public DataTable LayThongtin_TiepNhan_TheoSoDienThoai(string sodienThoai)
        {
            return InformationRepository.LayThongtin_TiepNhan_TheoSoDienThoai(sodienThoai);
        }
        public DataTable LayThongtin_TiepNhan_IdCongDan(string idCongDan)
        {
            return InformationRepository.LayThongtin_TiepNhan_IdCongDan(idCongDan);
        }
        public DataTable LayDanhSach_TiepNhan_TheoMaBN(string _MaBN)
        {
            return InformationRepository.LayDanhSach_TiepNhan_TheoMaBN(_MaBN);
        }
        public DataTable LayDanhSach_NoiTru(string _MaBN, string _Name)
        {
            return InformationRepository.LayDanhSach_NoiTru(_MaBN, _Name);
        }
        public DataTable LayDanhSach_LichSuNoiTru(string _MaBN, string _Name)
        {
            return InformationRepository.LayDanhSach_LichSuNoiTru(_MaBN, _Name);
        }
        public bool Insert_BenhNhan_ThongTinChiTiet(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec
                     , string _quoctich)
        {
            return InformationRepository.Insert_BenhNhan_ThongTinChiTiet(_dantoc, _hinhbn, _hocvan, _mabn, _nghenghiep, _noilamviec
                     , _quoctich);
        }
        public bool Update_BENHNHAN_THONGTINCHITIET(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec
                                   , string _quoctich)
        {
            return InformationRepository.Update_BENHNHAN_THONGTINCHITIET(_dantoc, _hinhbn, _hocvan, _mabn, _nghenghiep, _noilamviec
                                   , _quoctich);
        }
        public bool Delete_BENHNHAN_THONGTINCHITIET(string _mabn)
        {
            return InformationRepository.Delete_BENHNHAN_THONGTINCHITIET(_mabn);
        }
        public DataTable TimBenhNhan(SearchPatientCondit objCondit)
        {
            return InformationRepository.TimBenhNhan(objCondit);
        }
        public DataTable TimBenhNhanXetNghiem(SearchPatientCondit_XN objCondit)
        {
            return InformationRepository.TimBenhNhanXetNghiem(objCondit);
        }
        public bool Update_KetQua_huyetTuyDo(BENHNHAN_CLS_XETNGHIEM objInfo)
        {
            return InformationRepository.Update_KetQua_huyetTuyDo(objInfo);
        }
        public bool Update_DaNhanMau_Mau(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            return InformationRepository.Update_DaNhanMau_Mau(maTiepNhan, trangThai, nguoiThucHien);
        }
        public bool Update_DaNhanMau_NT(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            return InformationRepository.Update_DaNhanMau_NT(maTiepNhan, trangThai, nguoiThucHien);
        }
        public bool Update_DaNhanMau_ViSinh(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            return InformationRepository.Update_DaNhanMau_ViSinh(maTiepNhan, trangThai, nguoiThucHien);
        }

        public bool Update_DaLayMau_Mau(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            return InformationRepository.Update_DaLayMau_Mau(maTiepNhan, trangThai, nguoiThucHien);
        }
        public bool Update_DaLayMau_NT(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            return InformationRepository.Update_DaLayMau_NT(maTiepNhan, trangThai, nguoiThucHien);
        }
        public bool Update_DaLayMau_ViSinh(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            return InformationRepository.Update_DaLayMau_ViSinh(maTiepNhan, trangThai, nguoiThucHien);
        }
        public bool Update_GhiChuHenTraKQ(string matTiepNhan, string maXn, string maNhom, bool cotKetQua, string noidung, DateTime tgtraKQ)
        {
            return InformationRepository.Update_GhiChuHenTraKQ(matTiepNhan, maXn, maNhom, cotKetQua, noidung, tgtraKQ);
        }
        public DataTable Calculate_TraKetQua(string maTiepNhan, string soHoSo, DateTime? ngayTiepNhan, string barcode
            , string GioLamViec, string GioNghiTrua, string GioLamChieu, string GioNghiChieu, int NghiCuoiTuan, ServiceType[] arrLoaiDichVu, bool traTheoXnNghiem)
        {
            return InformationRepository.Calculate_TraKetQua(maTiepNhan, soHoSo, ngayTiepNhan, barcode, GioLamViec, GioNghiTrua, GioLamChieu
                , GioNghiChieu, NghiCuoiTuan, arrLoaiDichVu, traTheoXnNghiem);
        }
        #endregion
        #region Trả kết quả
        public DataTable DanhSach_ChoTraKetQua(bool TheoNgayHen, bool ThuongQuy, string KhoaPhong, int soPhut)
        {
            return InformationRepository.DanhSach_ChoTraKetQua(TheoNgayHen, ThuongQuy, KhoaPhong, soPhut);
        }
        public int Update_TraKetqua(string matiepnhan, string userThucHien, string nguoiNhan, string noiNhan, bool thucHienTra)
        {
            return InformationRepository.Update_TraKetqua(matiepnhan, userThucHien, nguoiNhan, noiNhan, thucHienTra);
        }

        public DataTable Calculate_TraKetQuaXN(string maTiepNhan, string GioLamViec, string GioNghiTrua, string GioLamChieu, string GioNghiChieu, int NghiCuoiTuan, int cachTinhThoigian)
        {
            return InformationRepository.Calculate_TraKetQuaXN(maTiepNhan, GioLamViec, GioNghiTrua, GioLamChieu, GioNghiChieu, NghiCuoiTuan, cachTinhThoigian);
        }
        public int Update_ThoiGianThucHienXN(string matiepnhan)
        {
            return InformationRepository.Update_ThoiGianThucHienXN(matiepnhan);
        }
        public int Update_ThoiGianThucHienXN_Nhom(string matiepnhan, int loaiThoigian)
        {
            return InformationRepository.Update_ThoiGianThucHienXN_Nhom(matiepnhan, loaiThoigian);
        }
        public DateTime NgayTiepNhan_TheoBarcode(string barcode)
        {
            return InformationRepository.NgayTiepNhan_TheoBarcode(barcode);
        }
        #endregion

        #region Trạng thái mẫu
        public bool KiemTraCoKetQua(string maTiepNhan, string maNhomLoaiMau)
        {
            return InformationRepository.KiemTraCoKetQua(maTiepNhan, maNhomLoaiMau);
        }
        public bool KiemTraKetQuaDaGuiHis(string maTiepNhan, string maNhomLoaiMau)
        {
            return InformationRepository.KiemTraKetQuaDaGuiHis(maTiepNhan, maNhomLoaiMau);
        }
        public bool Update_MauXn_LayMau(List<LayMauInfo> info)
        {
            return InformationRepository.Update_MauXn_LayMau(info);
        }

        public bool Update_TG_Khoa_User_LayMau(List<LayMauInfo> info)
        {
            return InformationRepository.Update_TG_Khoa_User_LayMau(info);
        }

        public bool Update_MauXn_NhanMau(List<NhanMauInfo> lstNhanMau)
        {
            return InformationRepository.Update_MauXn_NhanMau(lstNhanMau);
        }

        public bool Update_IDChuyenMau(List<NhanMauInfo> lstNhanMau)
        {
            return InformationRepository.Update_IDChuyenMau(lstNhanMau);
        }
        public int Update_TrangThaiLayMau_NhanMau(string matiepnhan, bool fromNhanmau, bool daNhanMau)
        {
            return InformationRepository.Update_TrangThaiLayMau_NhanMau(matiepnhan, fromNhanmau, daNhanMau);
        }
        public int Update_TrangThaiLayMau(string matiepnhan)
        {
            return InformationRepository.Update_TrangThaiLayMau(matiepnhan);
        }
        public bool Update_MauXn_HoanDichVu_TuChoiMau(List<TuChoiMauInfo> lstNhanMau)
        {
            return InformationRepository.Update_MauXn_HoanDichVu_TuChoiMau(lstNhanMau);
        }
        public bool Insert_nhatky_mauxetnghiem(List<NHATKY_MAUXETNGHIEM> lstObjInfo)
        {
            return InformationRepository.Insert_nhatky_mauxetnghiem(lstObjInfo);
        }
        public DataTable Data_nhatky_mauxetnghiem(string id, string matiepnhan, string nguoithuchien, DateTime? tungay, DateTime? dengay, bool xemChiTiet, string allowNhom)
        {
            return InformationRepository.Data_nhatky_mauxetnghiem(id, matiepnhan, nguoithuchien, tungay, dengay, xemChiTiet, allowNhom);
        }
        public DataTable Data_NhatKy_DoiGioThaoTacMau(DateTime? tungay, DateTime? denngay, string matiepNhan, string nguoiThucHien)
        {
            return InformationRepository.Data_NhatKy_DoiGioThaoTacMau(tungay, denngay, matiepNhan, nguoiThucHien);
        }
        public DataTable DanhSach_MaTiepNhan_TheoSHS(string soHoSo)
        {
            return InformationRepository.DanhSach_MaTiepNhan_TheoSHS(soHoSo);
        }
        public DataTable DanhSach_MaTiepNhan_TheoBarcode(string barcode)
        {
            return InformationRepository.DanhSach_MaTiepNhan_TheoBarcode(barcode);
        }
        public DataTable DanhSach_BenhNhan_TheoTrangThaiMau(DieuKienTimDanhSachBNTheoTrangThaiMau condit)
        {
            return InformationRepository.DanhSach_BenhNhan_TheoTrangThaiMau(condit);
        }
        public DataTable DanhSachOngMau(string maTiepNhan, enumThucHien daLayMau, enumThucHien daNhanMau
            , enumThucHien daTuChoi, bool checkPhanQuyenNhom, string userCheckQuyenNhom, int idLayLoaiMau)
        {
            return InformationRepository.DanhSachOngMau(maTiepNhan, daLayMau, daNhanMau, daTuChoi, checkPhanQuyenNhom, userCheckQuyenNhom, idLayLoaiMau);
        }
        public DataTable DanhSachChiDinh_OngMau(string maTiepNhan, int idLayLoaiMau)
        {
            return InformationRepository.DanhSachChiDinh_OngMau(maTiepNhan, idLayLoaiMau);
        }
        public int Update_TinhTrangMau(string maTiepNhan, string lstMaXn, string tinhtrangmau, bool checkXacNhanHis)
        {
            return InformationRepository.Update_TinhTrangMau(maTiepNhan, lstMaXn, tinhtrangmau, checkXacNhanHis);
        }
        public int Update_ThoigianThaoTacMau(CapNhatThaoTacMau objInfo)
        {
            return InformationRepository.Update_ThoigianThaoTacMau(objInfo);
        }
        public int Update_TrangThaiNhanMau(string matiepnhan, bool nhanMau)
        {
            return InformationRepository.Update_TrangThaiNhanMau(matiepnhan, nhanMau);
        }
        public int Update_XetNghiem_MaSoBenhPhamGui(string maTiepNhan, string maXN, string maBenhPham)
        {
            return InformationRepository.Update_XetNghiem_MaSoBenhPhamGui(maTiepNhan, maXN, maBenhPham);
        }
        public bool update_XN_TGChuyen_BNCLSXN(string matiepnhan)
        {
            return InformationRepository.update_XN_TGChuyen_BNCLSXN(matiepnhan);
        }

        public bool Check_OpenOrder(string matiepnhan)
        {
            return InformationRepository.Check_OpenOrder(matiepnhan);
        }
        public int Update_OpenOrder(string matiepnhan, string nguoithuchien, string userid, string pcname)
        {
            return InformationRepository.Update_OpenOrder(matiepnhan, nguoithuchien, userid, pcname);
        }
        public DataTable Data_ChiDinhDaNhanMau(string maTiepNhan)
        {
            return InformationRepository.Data_ChiDinhDaNhanMau(maTiepNhan);
        }
        public DataTable Data_ChiDinhDaLayMau(string maTiepNhan)
        {
            return InformationRepository.Data_ChiDinhDaLayMau(maTiepNhan);
        }
        public int Insert_Update_KiemSoatLayMau(string userID, List<string> lstDnMau, DateTime TGGianBatDau, DateTime TGKhoa, bool dangKhoa)
        {
            return InformationRepository.Insert_Update_KiemSoatLayMau(userID, lstDnMau, TGGianBatDau, TGKhoa, dangKhoa);
        }
        public KiemSoatChayMau ThongKiemSoatLayMau(string userId)
        {
            return InformationRepository.ThongKiemSoatLayMau(userId);
        }
        //Thông tin chuyển mẫu
        public TaoMoiChuyenMau Create_ChuyenMau_IdChuyenMau(TaoMoiChuyenMau obj)
        {
            return InformationRepository.Create_ChuyenMau_IdChuyenMau(obj);
        }
        public bool Insert_ChuyenMau_ChiTiet(ThemChuyenMauChiTiet obj)
        {
            return InformationRepository.Insert_ChuyenMau_ChiTiet(obj);
        }
        public bool Update_ChuyenMau_XacNhanChuyen(CapNhatChuyenMau obj)
        {
            return InformationRepository.Update_ChuyenMau_XacNhanChuyen(obj);
        }
        public bool Update_ChuyenMau_SoLuong(long IDChuyenMau, string Barcode, string maOngMau, bool tang)
        {
            return InformationRepository.Update_ChuyenMau_SoLuong(IDChuyenMau, Barcode, maOngMau, tang);
        }
        public DataTable Data_ChuyenMau(long? IDChuyenMau, DateTime? TuNgay, DateTime? DenNgay, string userTao = "")
        {
            return InformationRepository.Data_ChuyenMau(IDChuyenMau, TuNgay, DenNgay, userTao);
        }
        public DataTable Data_ChuyenMau_ChiTiet(long? IDChuyenMau, string Barcode
            , DateTime? TuNgay, DateTime? DenNgay, string userTao = "")
        {
            return InformationRepository.Data_ChuyenMau_ChiTiet(IDChuyenMau, Barcode, TuNgay, DenNgay, userTao);
        }
        public bool Delete_ChuyenMau(long IDChuyenMau)
        {
            return InformationRepository.Delete_ChuyenMau(IDChuyenMau);
        }
        public bool Delete_ChuyenMau_ChiTiet(long IDChuyenMau)
        {
            return InformationRepository.Delete_ChuyenMau_ChiTiet(IDChuyenMau);
        }
        #endregion
        public DataTable Data_ChiDInhTheoSoHoSo(string soHoSo, string sophieuChiDinh, string maBenhNhan)
        {
            return InformationRepository.Data_ChiDInhTheoSoHoSo(soHoSo, sophieuChiDinh, maBenhNhan);
        }
        public DataTable Data_TheoDoiMau(string maBenhNhan, string maTiepNhan, string barcode, string maHosSo
            , string allowBophan, DateTime? ngayKiemTra)
        {
            return InformationRepository.Data_TheoDoiMau(maBenhNhan, maTiepNhan, barcode, maHosSo
            , allowBophan, ngayKiemTra);
        }
        public bool DuaVaoDanhSachUploadHIS(string maTiepNhan)
        {
            return InformationRepository.DuaVaoDanhSachUploadHIS(maTiepNhan);
        }
        #region Quản lý phân phối bàn
        public bool Insert_LayMauDangKyBan(string maNguoiDung, int soBan, string maKhuLayMau, string pcName)
        {
            return InformationRepository.Insert_LayMauDangKyBan(maNguoiDung, soBan, maKhuLayMau, pcName);
        }
        public bool Update_LayMauLogOut(string maNguoiDung, int soBan, string maKhuLayMau, string pcName)
        {
            return InformationRepository.Update_LayMauLogOut(maNguoiDung, soBan, maKhuLayMau, pcName);
        }
        public bool Update_LayMauTamDung(string maNguoiDung, int soBan, string maKhuLayMau, bool tamDung)
        {
            return InformationRepository.Update_LayMauTamDung(maNguoiDung, soBan, maKhuLayMau, tamDung);
        }
        public DataTable DanhSach_LayMau_DaDangKySoBan(string maNguoiDung, int soBan, string maKhuLayMau, bool checkChuaDangXuat)
        {
            return InformationRepository.DanhSach_LayMau_DaDangKySoBan(maNguoiDung, soBan, maKhuLayMau, checkChuaDangXuat);
        }
        public DataTable LayMau_LaySoBan(string maKhuLayMau)
        {
            return InformationRepository.LayMau_LaySoBan(maKhuLayMau);
        }
        #endregion
        #region Quản lý đăng nhập lấy mẫu
        public bool Insert_LayMauThuCong_DangNhap(string maNguoiDung, string maKhuLayMau)
        {
            return InformationRepository.Insert_LayMauThuCong_DangNhap(maNguoiDung, maKhuLayMau);
        }
        public bool Update_LayMauThuCong_LogOut(int idDangNhap)
        {
            return InformationRepository.Update_LayMauThuCong_LogOut(idDangNhap);
        }
        public DataTable DanhSach_LayMau_DangNhap(string maKhuLayMau)
        {
            return InformationRepository.DanhSach_LayMau_DangNhap(maKhuLayMau);
        }
        #endregion
        #region Chuyển kết quả
        public long Insert_PhieuChuyenKQ(string nguoiChuyen, string pcChuyen)
        {
            return InformationRepository.Insert_PhieuChuyenKQ(nguoiChuyen, pcChuyen);
        }
        public int Delete_PhieuChuyenKQ(long idChuyenMau)
        {
            return InformationRepository.Delete_PhieuChuyenKQ(idChuyenMau);
        }
        public DataTable DanhSach_PhieuChuyenKetQua(DateTime ngayChuyen, string barcode)
        {
            return InformationRepository.DanhSach_PhieuChuyenKetQua(ngayChuyen, barcode);
        }
        public int Insert_PhieuChuyenMau_ChiTiet(CHUYENPHIEUKETQUA_CHITIET objInfo)
        {
            return InformationRepository.Insert_PhieuChuyenMau_ChiTiet(objInfo);
        }
        public int Update_PhieuChuyenKQ_XacNhanChuyen(long idChuyenKetQua, string nguoiXacNhan, string tenMayTinhXacNhan, bool thucHienChuyen)
        {
            return InformationRepository.Update_PhieuChuyenKQ_XacNhanChuyen(idChuyenKetQua, nguoiXacNhan, tenMayTinhXacNhan, thucHienChuyen);
        }
        public int Update_PhieuChuyenKQ_DaNhanKetQua(long idCHiTiet, long idChuyenKetQua, string nguoiNhan, string tenMayTinhNhan, string maTiepNhan)
        {
            return InformationRepository.Update_PhieuChuyenKQ_DaNhanKetQua(idCHiTiet, idChuyenKetQua, nguoiNhan, tenMayTinhNhan, maTiepNhan);
        }
        public DataTable DanhSach_ThongTinChuyenChuyenKQ_TheoID(int idChuyenKetQua)
        {
            return InformationRepository.DanhSach_ThongTinChuyenChuyenKQ_TheoID(idChuyenKetQua);
        }
        public DataTable DanhSach_ChuyenChuyenKQ_TheoID(int idChuyenKetQua)
        {
            return InformationRepository.DanhSach_ChuyenChuyenKQ_TheoID(idChuyenKetQua);
        }
        public DataTable DanhSach_ChuyenChuyenKQ_TheoBarcode(string barcode)
        {
            return InformationRepository.DanhSach_ChuyenChuyenKQ_TheoBarcode(barcode);
        }
        public int Xoa_ChuyenChuyenK_ChiTiet(long idChitiet)
        {
            return InformationRepository.Xoa_ChuyenChuyenK_ChiTiet(idChitiet);
        }
        public DataTable DanhSach_ChuyenKQ_InPhieu(long idChuyen)
        {
            return InformationRepository.DanhSach_ChuyenKQ_InPhieu(idChuyen);
        }
        public DataTable DanhSach_NhanKetQQua_InPhieu(long idChuyen)
        {
            return InformationRepository.DanhSach_NhanKetQQua_InPhieu(idChuyen);
        }
        #endregion
        #region Lưu mẫu
        public int ThemOngMauLuu(ArchiveSample tubeInfo)
        {
            return InformationRepository.ThemOngMauLuu(tubeInfo);
        }
        public long GetIDLuuMau(ArchiveSample tubeInfo)
        {
            return InformationRepository.GetIDLuuMau(tubeInfo);
        }
        public int XoaOngMauLuu(long Idluumau, string nguoiXoa, string PCXoa)
        {
            return InformationRepository.XoaOngMauLuu(Idluumau, nguoiXoa, PCXoa);
        }
        public int HuyOngMauLuu(long Idluumau, string nguoiHuy, string PCHuy)
        {
            return InformationRepository.HuyOngMauLuu(Idluumau, nguoiHuy, PCHuy);
        }
        public DataTable DanhSach_OngMauLuu(string Barcode, string MaSoHop, string MaSoTu)
        {
            return InformationRepository.DanhSach_OngMauLuu(Barcode, MaSoHop, MaSoTu);
        }
        public int DuyetMauLuu(long Idluumau, string nguoiduyet, string PCHuy, bool thuchienDuyet)
        {
            return InformationRepository.DuyetMauLuu(Idluumau, nguoiduyet, PCHuy, thuchienDuyet);
        }
        public DataTable DanhSach_OngMauLuuTheoNgay(DateTime? TuNgay, DateTime? DenNgay, string Barcode, string MaSoHop, string MaSoTu)
        {
            return InformationRepository.DanhSach_OngMauLuuTheoNgay(TuNgay, DenNgay, Barcode, MaSoHop, MaSoTu);
        }
        public DataTable DanhSach_OngMauHuyTheoNgay(DateTime? TuNgay, DateTime? DenNgay, string Barcode, string MaSoHop, string MaSoTu)
        {
            return InformationRepository.DanhSach_OngMauHuyTheoNgay(TuNgay, DenNgay, Barcode, MaSoHop, MaSoTu);
        }
        public DataTable ChiTiet_OngMauLuuTheoViTri(string MaSoHop, string MaSoTu, int viTri)
        {
            return InformationRepository.ChiTiet_OngMauLuuTheoViTri(MaSoHop, MaSoTu, viTri);
        }
        public DataTable OngMau_LoaiMauChinh(string barcode, string manhom)
        {
            return InformationRepository.OngMau_LoaiMauChinh(barcode, manhom);
        }
        public ArchiveSample Get_Info_mauxetnghiem_luumau(long idLuuMau)
        {
            return InformationRepository.Get_Info_mauxetnghiem_luumau(idLuuMau);
        }
        public ArchiveSample Get_Info_mauxetnghiem_luumau_FromDatarow(DataRow dr)
        {
            return InformationRepository.Get_Info_mauxetnghiem_luumau_FromDatarow(dr);
        }
        #endregion
        #region Thông tin sàn lọc sơ sinh 
        public int Insert_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj)
        {
            return InformationRepository.Insert_ThongTinSLSoSinh(obj);
        }
        public int Update_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj)
        {
            return InformationRepository.Update_ThongTinSLSoSinh(obj);
        }
        public int Delete_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj)
        {
            return InformationRepository.Delete_ThongTinSLSoSinh(obj);
        }
        public DataTable Data_ThongTinSLSoSinh(string maTiepNhan)
        {
            return InformationRepository.Data_ThongTinSLSoSinh(maTiepNhan);
        }
        public BENHNHAN_MAUSANGLOC Get_ThongTinSLSoSinh(string maTiepNhan)
        {
            return InformationRepository.Get_ThongTinSLSoSinh(maTiepNhan);
        }
        public BENHNHAN_MAUSANGLOC Get_ThongTinSLSoSinh_ByRow(DataRow dr)
        {
            return InformationRepository.Get_ThongTinSLSoSinh_ByRow(dr);
        }
        public DataTable Data_DSTreSoSinhSangLoc(DateTime fromDate, DateTime toDate)
        {
            return InformationRepository.Data_DSTreSoSinhSangLoc(fromDate, toDate);
        }
        public DataTable Data_DSSangLocTruocSinh(DateTime fromDate, DateTime toDate)
        {
            return InformationRepository.Data_DSSangLocTruocSinh(fromDate, toDate);
        }
        public int Update_NhanXetDeNghi_SangLoc(string maTiepNhan, string nhanXet, string nguoiNhanXet, string deNghi, string nguoiDeNghi, string ketLuan, string nguoiKetLuan)
        {
            return InformationRepository.Update_NhanXetDeNghi_SangLoc(maTiepNhan, nhanXet, nguoiNhanXet, deNghi, nguoiDeNghi, ketLuan, nguoiKetLuan);
        }
        public DataTable Data_PhieuHen_SLSS(string matiepNhan)
        {
            return InformationRepository.Data_PhieuHen_SLSS(matiepNhan);
        }
        #endregion
        #region Chi dinh tu mau
        public int DeleteOrderOfElement(string sid, string elementId, string userDel, string pcDel)
        {
            return InformationRepository.DeleteOrderOfElement(sid, elementId, userDel, pcDel);
        }
        public int DeletePatientWithoutElement(string sid, string userDel, string pcDel)
        {
            return InformationRepository.DeletePatientWithoutElement(sid, userDel, pcDel);
        }
        #endregion
        #region Chi dinh GPB
        public int DeleteOrderOfGPB(string sid, string testcodeLis, string userDel, string pcDel)
        {
            return InformationRepository.DeleteOrderOfGPB(sid, testcodeLis, userDel, pcDel);
        }
        public int DeletePatientWithoutGPB(string sid, string userDel, string pcDel)
        {
            return InformationRepository.DeletePatientWithoutGPB(sid, userDel, pcDel);
        }
        #endregion
        #region xetnghiem_ghichu_laymau
        public int Insert_xetnghiem_ghichu_laymau(XETNGHIEM_GHICHU_LAYMAU objInfo)
        {
            return InformationRepository.Insert_xetnghiem_ghichu_laymau(objInfo);
        }
        public int Delete_xetnghiem_ghichu_laymau(XETNGHIEM_GHICHU_LAYMAU objInfo)
        {
            return InformationRepository.Delete_xetnghiem_ghichu_laymau(objInfo);
        }

        public DataTable Data_xetnghiem_ghichu_laymau(string maxn, string matiepnhan)
        {
            return InformationRepository.Data_xetnghiem_ghichu_laymau(maxn, matiepnhan);
        }

        public XETNGHIEM_GHICHU_LAYMAU Get_Info_xetnghiem_ghichu_laymau(DataRow drInfo)
        {
            return InformationRepository.Get_Info_xetnghiem_ghichu_laymau(drInfo);
        }
        public XETNGHIEM_GHICHU_LAYMAU Get_Info_xetnghiem_ghichu_laymau(string maxn, string matiepnhan)
        {
            return InformationRepository.Get_Info_xetnghiem_ghichu_laymau(maxn, matiepnhan);
        }

        public bool CheckExists_xetnghiem_ghichu_laymau(string maxn, string matiepnhan)
        {
            return InformationRepository.CheckExists_xetnghiem_ghichu_laymau(maxn, matiepnhan);
        }

        #endregion
        #region Quản lý gửi mẫu nội bộ
        public int Insert_GuimauNoiBo(GuiMauNoiBoModel info)
        {
            return InformationRepository.Insert_GuimauNoiBo(info);
        }
        public int Insert_NhatKyGuiMauNoiBo(GuiMauNoiBoModel info)
        {
            return InformationRepository.Insert_NhatKyGuiMauNoiBo(info);
        }
        public int Delete_XetNghiem_GuiMau(GuiMauNoiBoModel info)
        {
            return InformationRepository.Delete_XetNghiem_GuiMau(info);
        }
        public int Update_XetNghiem_NhanMauGui(GuiMauNoiBoModel info)
        {
            return InformationRepository.Update_XetNghiem_NhanMauGui(info);
        }
        public DataTable Data_XetNghiem_GuiMau(string lstMaTiepNhan, int trangThaiNhan, string[] arrPhanQuyenNhom)
        {
            return InformationRepository.Data_XetNghiem_GuiMau(lstMaTiepNhan, trangThaiNhan, arrPhanQuyenNhom);
        }
        public int Update_TrangThaiGuiMau_Nhom(string maTiepNhan, string maNhomCLS)
        {
            return InformationRepository.Update_TrangThaiGuiMau_Nhom(maTiepNhan, maNhomCLS);
        }
        public int Update_TrangThaiNhanMauGui_Nhom(string maTiepNhan, string maNhomCLS)
        {
            return InformationRepository.Update_TrangThaiNhanMauGui_Nhom(maTiepNhan, maNhomCLS);
        }
        public int Update_TrangThaiGuiMau_BoPhan(string maTiepNhan)
        {
            return InformationRepository.Update_TrangThaiGuiMau_BoPhan(maTiepNhan);
        }
        #endregion
        #region Gửi mẫu cho đơn vị khác
  
        public int Insert_xetnghiem_guimau(XETNGHIEM_GUIMAU objInfo)
        {
            return InformationRepository.Insert_xetnghiem_guimau(objInfo);
        }
        public int Update_xetnghiem_guimau_donvinhan(XETNGHIEM_GUIMAU objInfo)
        {
            return InformationRepository.Update_xetnghiem_guimau_donvinhan(objInfo);
        }
        public int Update_xetnghiem_guimau_xacnhangui(XETNGHIEM_GUIMAU objInfo)
        {
            return InformationRepository.Update_xetnghiem_guimau_Xacnhangui(objInfo);
        }
        public int Delete_xetnghiem_guimau(string matiepnhan, string maxn, string NguoiXoa, string PCXoa)
        {
            return InformationRepository.Delete_xetnghiem_guimau(matiepnhan, maxn, NguoiXoa, PCXoa);
        }
        public DataTable Data_xetnghiem_guimau(string matiepnhan, string maxn, string donvinhan, DateTime? ngaytao)
        {
            return InformationRepository.Data_xetnghiem_guimau(matiepnhan, maxn, donvinhan, ngaytao);
        }
        public DataTable Data_xetnghiem_guimau_daxoa(string matiepnhan, string maxn, string donvinhan, DateTime? ngaytao)
        {
            return InformationRepository.Data_xetnghiem_guimau_daxoa(matiepnhan, maxn, donvinhan, ngaytao);
        }
        public XETNGHIEM_GUIMAU Get_Info_xetnghiem_guimau(DataRow drInfo)
        {
            return InformationRepository.Get_Info_xetnghiem_guimau(drInfo);
        }
        public XETNGHIEM_GUIMAU Get_Info_xetnghiem_guimau(string matiepnhan, string maxn)
        {
            return InformationRepository.Get_Info_xetnghiem_guimau(matiepnhan, maxn);
        }
        public bool CheckExists_xetnghiem_guimau(string matiepnhan, string maxn)
        {
            return InformationRepository.CheckExists_xetnghiem_guimau(matiepnhan, maxn);
        }

        public int Insert_xetnghiem_guimau_ketqua(XETNGHIEM_GUIMAU_KETQUA objInfo)
        {
            return InformationRepository.Insert_xetnghiem_guimau_ketqua(objInfo);
        }

        public int Update_xetnghiem_guimau_ketqua(XETNGHIEM_GUIMAU_KETQUA objInfo)
        {
            return InformationRepository.Update_xetnghiem_guimau_ketqua(objInfo);
        }

        public int Delete_xetnghiem_guimau_ketqua(int id)
        {
            return InformationRepository.Delete_xetnghiem_guimau_ketqua(id);
        }

        public DataTable Data_xetnghiem_guimau_ketqua(int id)
        {
            return InformationRepository.Data_xetnghiem_guimau_ketqua(id);
        }

        public XETNGHIEM_GUIMAU_KETQUA Get_Info_xetnghiem_guimau_ketqua(DataRow drInfo)
        {
            return InformationRepository.Get_Info_xetnghiem_guimau_ketqua(drInfo);
        }

        public XETNGHIEM_GUIMAU_KETQUA Get_Info_xetnghiem_guimau_ketqua(int id)
        {
            return InformationRepository.Get_Info_xetnghiem_guimau_ketqua(id);
        }

        public bool CheckExists_xetnghiem_guimau_ketqua(int id)
        {
            return InformationRepository.CheckExists_xetnghiem_guimau_ketqua(id);
        }


        #endregion
    }
}
