using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.Lab.BusinessService.Models;
using TPH.LIS.Common;
using TPH.LIS.Log;
using TPH.LIS.Patient.Model;
using TPH.LIS.TestResult.Constants;
using TPH.LIS.TestResult.Model;

namespace TPH.LIS.TestResult.Repositories
{
    public interface ITestReultRepository
    {
        void ResultLog(string maTiepNhan, LogActionId action, List<string> maXn, string maProfile, string userAction);
        bool InsertTest(BENHNHAN_TIEPNHAN objBn, XetNghiemInfo objxn);
        bool UpdateProfileID(string matiepNhan, string profileId);
        int InsertTestFromHis(BenhNhanInfoForHIS info, List<ChiDinhHISInfo> item, List<XetNghiemHISInfo> xetnghiem);
        int Update_ThongTinChiDinh(string matiepnhan, string maXn, DateTime ngayChiDinh);
        bool CheckExistsTest(string matiepnhan, string maxn);
        int InsertCategoryOfTest(string matiepnhan);
        int UpdateHISInfoForAutoInsertTest(string matiepnhan, string maxn, string maxnChinh);
        int DeleteCategoryOfTest(string matiepnhan);
        DataTable DataCategoryOrTest(string matiepnhan, int loaiThoiGian, string inNhom);
        DataTable DataDepartmentOrTest(string matiepnhan, int loaiThoiGian, string inBoPhan);
        int UpdateFullAndValidResultCategory(string matiepnhan);
        int UpdatePrintOutCategory(string matiepnhan, string manhom, bool daIn, string userIn);
        int UpdatePrintOutPatientAndCategoryAndDeparment(string matiepnhan, string manhom
            , bool daIn, string userIn, bool isSigned, string userSignDigital
            , string pcName, DateTime? dateSignDigital, int reportType);
        int UpdateDownloadPatient(string maTiepNhan);
        int UpdateAllowDownload(string maTiepNhan);
        int UpdateGiaDichVuXN(string maTiepNhan);
        int UpdateDiscountDoctor(string maTiepNhan, string maDichVu, bool isProfile);
        int SoLuongMau(string maTiepNhan, int kieuLay, bool maudaLay = false);
        DataTable SoLuongMau_Data(string maTiepNhan, bool mauDaLay, int idLayLoaiMau, bool dulieuChuyenMau = false, bool danhDauCong = false);
        DataTable Get_Patient_XN_Theobarcode(string maTiepNhan, string dateIn, enumThucHien dainKQ
                 , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
                 , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
                 , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
                 , string lstNhomXN);
        DataTable Get_Patient_XN_TheoNgayNhanMau(string maTiepNhan, string dateIn, enumThucHien dainKQ
                , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
                , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
                , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
                , string lstNhomXN);
        DataTable Get_Patient_XN_TheoNgayTiepNhan(string maTiepNhan, string dateIn, enumThucHien dainKQ
                , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
                , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
                , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
                , string lstNhomXN);
        DataTable Get_Patient_XNViSinh(string maTiepNhan, string dateIn, enumThucHien dainKQ
                , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
                , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
                , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
                , string lstNhomXN);
        DataTable GetValueConfig(int idConfig);
        void UpdateABOForFBlood(BloodInfo bloodInfo);
        DataTable Load_ChiDinhXetNghiem(string _MaTiepNhan);
        bool CheckTonTaiChiDinh(string _MaTiepNhan, string _maxn, bool _profile);
        bool Get_MaBN_XNTruoc(string maBn, string maTiepNhan, string ngayNhap, ref string tenBangTn, ref string tenBangXn);
        int CapNhat_CSBT(string maTiepNhan, string maXN, string IdMay, bool withUpdateFlat = false, bool capnhatGhichu = true);
        int CapNhat_BSKyten(string maTiepNhan, string lstMaXn, string BsKyTenMoi
            , string NguoiThucHien, string PcThucHien, bool CapNhatUpload);
        void CapNhat_DuKQ_XN(string _MaTiepNhan);
        bool CapNhatValid_WithReportType(string maTiepnhan, string reportType, bool isValid, string nguoiValid, string category);
        bool CapNhatValid_WithCondit(string maTiepnhan, string lisMaXN, bool isValid, string nguoiValid);
        void CapNhat_Valid_XN(string maTiepNhan, string uservalid);
        void InsertNATToInfinity(string maTiepNhan, DateTime date);
        int DownloadTest(string sid, int value);
        int DeleteNAT(string sid, int value);
        void UpdateDownload(string maTiepNhan, string maXN, bool download);
        void CapNhat_KQ_XN_TuyDo(KetQuaHuyetTuyDo objInfo);
        void CapNhat_MayChay_Ketqua(string maTiepNhan, string maXN, string IdMay, string userNhap, bool capNhatGhiChu = true);
        void CapNhat_Co_Ketqua(string maTiepNhan, string maXN, string co, string userNhap);
        void CapNhat_GhiChuKQ_XN(string maTiepNhan, string maXN, string ghiChu, string userNhap, string userUpdate);
        string CapNhat_KQ_XN(UpdateResultNormalInfo info);
        int UpdateNguoiDoiChieu(string maTiepNhan, string maXn, string nguoiDoiChieu, string tgDoichieu);
        int UpdateDienGiai_DeNghi_XN(string maTiepNhan, string maXn, string diengiai, string denghi);
        string CapNhat_ThongTinMayXn_XnChinh(string maTiepNhan, bool forAnalyzer = false);
        void XacNhan_KQ_XN(string maTiepNhan, string maXn, string trangThai, bool valid
            , string nguoiXn, bool xacNhanDe, int layNguoiThucHien);
        bool CapNhatIDMauKetQua(string matiepnhan, string maXn);
        DataTable DataIDMauKetQua(string matiepnhan, string maBoPhan);
        bool CapNhatPrintOut_WithoutReportType(string maTiepnhan, string someTestIn
            , string categoryPrint, bool isPrint, string nguoiIn, string boPhan
            , bool tuXacNhan, bool xacNhanDe, string kyTen, int idLayNguoiThucHien);
        bool CapNhatPrintOut_WithReportType(string maTiepnhan, string reportType
            , bool isPrint, string nguoiIn, bool tuXacNhan, string someTestIn, bool xacNhanDe, string kyTen, int idLayNguoiThucHien);
        bool CapNhat_GhiChuHenTraKQ(string matTiepNhan, string maNhom, string maXn, bool cotKetQua, string noidung, DateTime tgtraKQ, string TGCoKQ);
        int CapNhat_In_KQ_XN(string maTiepNhan, string nguoiXN, bool xacNhanketqua);
        DataTable Load_ChiDinhXetNghiem(string _MaTiepNhan, string maXn = "");
        bool Ins_KetQua_LabBlood(string maTiepNhan, string lstXN);
        bool Del_KetQua_LabBlood(string maTiepNhan, string lstXN);
        bool Update_BnTruyenMau_KQNhomMau(string sid, string abo, string rh, string userU);
        DataTable DuLieuIn_XN(DataTable dtThongTin, int index, bool layMailTheoBn, string userSign, string xnIn, bool title, DateTime? ngayInKQ
            , string[] userWorkPlace, string reportType, bool reprint, TestType.EnumTestType[] testType, string inCategory
            , bool TgInDauTien = false, bool sinhHocPhanTu = false, string maCaptren = "", bool dulieuIn = false
            , string inBoPhan = "", bool chiInCoKetQua = false, string userPermision = "", bool huyetDo = false
            , TestType.EnumTestType idLoaiXnHuyetDo = TestType.EnumTestType.HuyetDo, string soPhieuChiDinh = "", bool layTienSu = false);
        DataTable DuLieuKetQua_XN(DataTable dtThongTin, int index, bool layMailTheoBn, string userSign, string xnIn, bool title, DateTime? ngayInKQ
          , string[] userWorkPlace, string reportType, bool reprint, TestType.EnumTestType[] testType, string inCategory
          , bool TgInDauTien = false, bool sinhHocPhanTu = false, string maCaptren = "", bool dulieuIn = false
          , string inBoPhan = "", bool chiInCoKetQua = false, string userPermision = "", bool huyetDo = false
          , TestType.EnumTestType idLoaiXnHuyetDo = TestType.EnumTestType.HuyetDo, string soPhieuChiDinh = "");
        DataTable DuLieuXetNghiemCanhBao(string maTiepNhan);
        void CapNhat_KetLuan_XN(string maTiepNhan, string ketLuan, string ghiChu);
        
        int CapNhat_GhiChu_XNTheoBoPhan(string maTiepNhan, string maBoPhan, string ghiChu, string userNhap);
        void CapNhat_SauChiDinh_XetNghiem(string maTiepNhan, string tenTruong, bool co, string user);
        void CapNhat_PhatHanhKQXN(string maTiepNhan, bool bPhatHanh, string user);
        bool CapNhatKetQuaXN_TheoLoaiXN(string maTiepNhan, string ketQua, int enumLoaiXN);
        int CapNhat_NoiKiemTraChatLuong(string maTiepNhan, string maXN, string noikiemTraChatLuong);
        DataTable Data_DanhSach_HuyXacNhanHIS(string maTiepNhan, string lstXN, string userID);
        bool Check_HaveResult_XN(string maTiepNhan, string maXn);
        bool Check_HaveResult_For_XNChinh(string maTiepNhan, string profileId);
        string Get_GhiChuCuaXetNghiem(string maTiepNhan, string maXn);
        ThongTinKetQua Info_ThongTinKetQua(string maTiepNhan, string maXn);
        bool Delete_ChiDinhCLS_XN(string maTiepNhan, string maXn, string profileId, string userDelete, bool delPatient = false);
        DataTable DanhSachBenhNhanInTuDong(DieuKienInTuDong dieuKien);
        DataTable DanhSachBenhNhanInHangLoat(DieuKienInTuDong dieuKien);
        void Search_PatientXN(DateTime dtDateFrom, DateTime dtDateTo, string serviceId, string patientName
             , string seq, bool fullRsult, bool printed, string testId, string category, bool isTestProfile, bool nhapTheoDanhSach
             , DataGridView dtg, BindingNavigator bv, string maBN = "", string sdt = "");
        void CapNhat_ThuTien(string maTiepNhan, string chiDinh, bool daThu);
        void Get_DanhSachChiDinh(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt, bool defaultChecked);
        DataTable DataAllwayShowTest(string maMauIn, string matiepnhan, string conditSomeTestPrint);
        DataTable ConvertDataResultPrintFrom_RowToColumn(DataTable dtSource, string conditSomeTestPrint);
        DataTable DataPrintList_NotAutoSplit(DataTable dataIn, bool CategoryOrDepartment,
            bool coTachPhieu = false, bool showGhiChuTheoXn = false
            , bool ghepTenXnghiChu = false, bool ghepGhiChuKhoa = false
            , string dinhdangGhepDuyet = "", string dinhdangGhepNhapKQ = "");
        DataTable DataPrintList_AutoSplit(DataTable dataIn, int rowLimit, int rowForSign, int testLenghtLimt, int testResultLenghtLimt
     , int addressLenghtLimt, int diagnostictLenghtLimt, bool printWithConvert);
        string XuLytenMayChay(DataTable dataResultIn);
        string XuLyTenBS(DataTable dataResultIn);
        string XuLyTenKhoa(DataTable dataResultIn);
        string XuLytenLoaiMau(DataTable dataResultIn);
        string XuLyNguoiDuyetYKhoa(DataTable dataResultIn, bool tacnhNhom, string dinhdangGhep);
        string XuLyNguoiNhapKetQua(DataTable dataResultIn, bool tacnhNhom, string dinhdangGhep);
        string XulyCommnetChung(DataTable dataResultIn, bool ghiChuTheoXn = false, bool gheptenXnghiChu = false, bool ghepCghiChuKhoa = false);
        #region Sinh học phân tử
        int LuuKetQua_SHPT(KETQUA_CLS_XETNGHIEM_SPHT obj);
        int LuuKetQua_SHPT_KhongUpdateKetQua(KETQUA_CLS_XETNGHIEM_SPHT obj);
        int CapNhat_Hinhanh_SHPT(KETQUA_CLS_XETNGHIEM_SPHT obj);
        bool Delete_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn);
        DataTable Data_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn);
        KETQUA_CLS_XETNGHIEM_SPHT Get_Info_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn);
        bool Check_ExistsSHPT_Gen(string matiepnhan, string maxn, string magen);
        int Insert_Update_SHPT_Gen(KETQUA_CLS_XETNGHIEM_SHPT_GEN obj);
        int Delete_SHPT_Gen(KETQUA_CLS_XETNGHIEM_SHPT_GEN obj);
        KETQUA_CLS_XETNGHIEM_SHPT_GEN Get_Info_SHPT_Gen(string matiepnhan, string maxn, string magen);
        DataTable Data_SHPT_Gen(string matiepnhan, string maxn, string magen);
        DataTable Data_SHPT_Gen_In(string matiepnhan, string maxn, string magen);
        int LuuIdDienGiai(string matiepnhan, string maxn, int id, string nguoiThuchien);
        DataTable DataThongTinDienGiai(string matiepnhan, string maxn);
        void CapNhat_KieuGen_XN(string maTiepNhan, string maXN, string kieugen, string userNhap, string userUpdate);
        #endregion
        #region Danh sách chỉ định xet nghiem
        DataTable Load_ChiDinhXetNghiemDichVuTheoOngMau(List<string> lstMaTiepNhan, string manhomloaiMau);
        List<KETQUA_CLS_XETNGHIEM> lstXetnghiem(List<string> lstMaTiepNhan, string maOngMau);
        #endregion
        #region Hinh anh may huyet do
        int CapNhat_HinhAnh_MayXN(string maTiepNhan, string idMay, string maXnMay, string chuoiHinhAnh, Image hinhAnh);
        int Xoa_HinhAnh_MayXn(string maTiepNhan, string idMay);
        DataTable Data_HinhAnh_TuMay(string maTiepNhan, string IdMay);
        #endregion
        #region Cap nhat dang xu ly
        int CapNhat_TrangThaiDangXuLy_ChoNhom(string maTiepNhan, List<string> lstNhom, bool dangXuly);
        int CapNhat_TrangThaiDangXuLy_ChoBoPhan(string maTiepNhan, List<string> lstBoPhan, bool dangXuly);
        #endregion
        #region XetNghiem_LayMauThuThuat
        int InsUpdDel_XetNghiem_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo, string flag);
        int Delete_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo);
        int Insert_Update_XetNghiem_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo);
        DataTable Data_LayMauThuThuat(string matiepnhan, string maxn);
        KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT GetInfo_XetNghiem_LayMauThuThuat(string matiepnhan, string maxn);
        KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT GetInfo_XetNghiem_LayMauThuThuatByRow(DataRow dr);
        #endregion
        #region Nhận xét - Đề nghị - Kết luận => Nhóm
        int Update_NhanXetDeNghi_Nhom(string maTiepNhan, string maNhomCLS, string nhanXet
            , string nguoiNhanXet, string deNghi, string nguoiDeNghi
            , string ketLuan, string nguoiKetLuan, bool nguyCoCao, bool xetNghiemLan2
            , bool thamgiachandoan, bool chandoancobenh);
        #endregion
    }
}
