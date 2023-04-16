using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.Lab.BusinessService.Models;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log;
using TPH.LIS.Patient.Model;
using TPH.LIS.TestResult.Constants;
using TPH.LIS.TestResult.Model;
using TPH.LIS.TestResult.Repositories;

namespace TPH.LIS.TestResult.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly ITestReultRepository _iTestresult = new TestReultRepository();
        public void ResultLog(string maTiepNhan, LogActionId action, List<string> maXn, string maProfile, string userAction)
        {
            _iTestresult.ResultLog(maTiepNhan, action, maXn, maProfile, userAction);
        }
        public bool InsertTest(BENHNHAN_TIEPNHAN objBn, XetNghiemInfo objxn)
        {
            return _iTestresult.InsertTest(objBn, objxn);
        }
        public bool UpdateProfileID(string matiepNhan, string profileId)
        {
            return _iTestresult.UpdateProfileID(matiepNhan, profileId);
        }
        public int Update_ThongTinChiDinh(string matiepnhan, string maXn, DateTime ngayChiDinh)
        {
            return _iTestresult.Update_ThongTinChiDinh(matiepnhan, maXn, ngayChiDinh);
        }
        public int InsertTestFromHis(BenhNhanInfoForHIS info, List<ChiDinhHISInfo> item, List<XetNghiemHISInfo> xetnghiem)
        {
            return _iTestresult.InsertTestFromHis(info, item, xetnghiem);
        }
        public bool CheckExistsTest(string matiepnhan, string maxn)
        {
            return _iTestresult.CheckExistsTest(matiepnhan, maxn);
        }
        public int InsertCategoryOfTest(string matiepnhan)
        {
            return _iTestresult.InsertCategoryOfTest(matiepnhan);
        }
        public int UpdateHISInfoForAutoInsertTest(string matiepnhan, string maxn, string maxnChinh)
        {
            return _iTestresult.UpdateHISInfoForAutoInsertTest(matiepnhan, maxn, maxnChinh);
        }
        public int DeleteCategoryOfTest(string matiepnhan)
        {
            return _iTestresult.DeleteCategoryOfTest(matiepnhan);
        }
        public DataTable DataCategoryOrTest(string matiepnhan, int loaiThoiGian, string inNhom)
        { return _iTestresult.DataCategoryOrTest(matiepnhan, loaiThoiGian, inNhom); }
        public DataTable DataDepartmentOrTest(string matiepnhan, int loaiThoiGian, string inBoPhan)
        { return _iTestresult.DataDepartmentOrTest(matiepnhan, loaiThoiGian, inBoPhan); }
        public int UpdateFullAndValidResultCategory(string matiepnhan)
        { return _iTestresult.UpdateFullAndValidResultCategory(matiepnhan); }
        public int UpdatePrintOutCategory(string matiepnhan, string manhom, bool daIn, string userIn)
        {
            return _iTestresult.UpdatePrintOutCategory(matiepnhan, manhom, daIn, userIn);
        }
        public int UpdatePrintOutPatientAndCategoryAndDeparment(string matiepnhan, string manhom
            , bool daIn, string userIn, bool isSigned, string userSignDigital
            , string pcName, DateTime? dateSignDigital, int reportType)
        {
            return _iTestresult.UpdatePrintOutPatientAndCategoryAndDeparment(matiepnhan, manhom, daIn, userIn, isSigned
                , userSignDigital, pcName, dateSignDigital, reportType); 
        }
        public int UpdateDownloadPatient(string maTiepNhan)
        {
            return _iTestresult.UpdateDownloadPatient(maTiepNhan);
        }
        public int UpdateAllowDownload(string maTiepNhan)
        {
            return _iTestresult.UpdateAllowDownload(maTiepNhan);
        }
        public int UpdateGiaDichVuXN(string maTiepNhan)
        {
            return _iTestresult.UpdateGiaDichVuXN(maTiepNhan);
        }
        public int UpdateDiscountDoctor(string maTiepNhan, string maDichVu, bool isProfile)
        {
            return _iTestresult.UpdateDiscountDoctor(maTiepNhan, maDichVu, isProfile);
        }
        public int UpdateNguoiDoiChieu(string maTiepNhan, string maXn, string nguoiDoiChieu, string tgDoichieu)
        {

            return _iTestresult.UpdateNguoiDoiChieu(maTiepNhan, maXn, nguoiDoiChieu, tgDoichieu);
        }
        public int UpdateDienGiai_DeNghi_XN(string maTiepNhan, string maXn, string diengiai, string denghi)
        {
            return _iTestresult.UpdateDienGiai_DeNghi_XN(maTiepNhan, maXn, diengiai, denghi);
        }
        public int SoLuongMau(string maTiepNhan, int kieuLay, bool maudaLay = false)
        {
            return _iTestresult.SoLuongMau(maTiepNhan, kieuLay, maudaLay);
        }
        public DataTable SoLuongMau_Data(string maTiepNhan, bool mauDaLay, int idLayLoaiMau, bool dulieuChuyenMau = false, bool danhDauCong = false)
        {
            return _iTestresult.SoLuongMau_Data(maTiepNhan, mauDaLay, idLayLoaiMau, dulieuChuyenMau, danhDauCong);
        }
      public  DataTable Get_Patient_XN_TheoBarcode(string maTiepNhan, string dateIn, enumThucHien dainKQ
                , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
                , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
                , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
                , string lstNhomXN)
        {
            return _iTestresult.Get_Patient_XN_Theobarcode(maTiepNhan, dateIn, dainKQ, duKetQua, daXacNhan, khuvuc
            , lstTestType, checkmauDaLay, checkMauDaNhan, maBN, lstBoPhan, lstKhoaPhong, maKhuDieuTri, lstNhomXN);
        }
        public DataTable Get_Patient_XN_TheoNgayNhanMau(string maTiepNhan, string dateIn, enumThucHien dainKQ
               , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
               , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
               , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
               , string lstNhomXN)
        {
            return _iTestresult.Get_Patient_XN_TheoNgayNhanMau(maTiepNhan, dateIn, dainKQ, duKetQua, daXacNhan, khuvuc
            , lstTestType, checkmauDaLay, checkMauDaNhan, maBN, lstBoPhan, lstKhoaPhong, maKhuDieuTri, lstNhomXN);
        }
        public DataTable Get_Patient_XN_TheoNgayTiepNhan(string maTiepNhan, string dateIn, enumThucHien dainKQ
           , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
           , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
           , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
           , string lstNhomXN)
        {
            return _iTestresult.Get_Patient_XN_TheoNgayTiepNhan(maTiepNhan, dateIn, dainKQ, duKetQua, daXacNhan, khuvuc
            , lstTestType, checkmauDaLay, checkMauDaNhan, maBN, lstBoPhan, lstKhoaPhong, maKhuDieuTri, lstNhomXN);
        }
        public DataTable Get_Patient_XNViSinh(string maTiepNhan, string dateIn, enumThucHien dainKQ
                 , enumThucHien duKetQua, enumThucHien daXacNhan, string[] khuvuc
                 , List<TestType.EnumTestType> lstTestType, bool checkmauDaLay, bool checkMauDaNhan
                 , string maBN, string lstBoPhan, string lstKhoaPhong, string maKhuDieuTri
                 , string lstNhomXN)
        {
            return _iTestresult.Get_Patient_XNViSinh(maTiepNhan, dateIn, dainKQ, duKetQua, daXacNhan, khuvuc
            , lstTestType, checkmauDaLay, checkMauDaNhan, maBN, lstBoPhan, lstKhoaPhong, maKhuDieuTri, lstNhomXN);
        }
        public DataTable GetValueConfig(int idConfig)
        {
            return _iTestresult.GetValueConfig(idConfig);
        }
        public void UpdateABOForFBlood(BloodInfo bloodInfo)
        {
            _iTestresult.UpdateABOForFBlood(bloodInfo);
        }
        public DataTable Load_ChiDinhXetNghiem(string _MaTiepNhan)
        {
            return _iTestresult.Load_ChiDinhXetNghiem(_MaTiepNhan);
        }
        public bool CheckTonTaiChiDinh(string _MaTiepNhan, string _maxn, bool _profile)
        {
            return _iTestresult.CheckTonTaiChiDinh(_MaTiepNhan, _maxn, _profile);
        }
        public bool Get_MaBN_XNTruoc(string maBn, string maTiepNhan, string ngayNhap, ref string tenBangTn, ref string tenBangXn)
        {
            return _iTestresult.Get_MaBN_XNTruoc(maBn, maTiepNhan, ngayNhap, ref tenBangTn, ref tenBangXn);
        }
        public int CapNhat_CSBT(string maTiepNhan, string maXN, string IdMay, bool withUpdateFlat = false, bool capnhatGhichu = true)
        {
            return _iTestresult.CapNhat_CSBT(maTiepNhan, maXN, IdMay, withUpdateFlat, capnhatGhichu);
        }
        public int CapNhat_BSKyten(string maTiepNhan, string lstMaXn, string BsKyTenMoi
            , string NguoiThucHien, string PcThucHien, bool CapNhatUpload)
        {
            return _iTestresult.CapNhat_BSKyten(maTiepNhan, lstMaXn, BsKyTenMoi
            , NguoiThucHien, PcThucHien, CapNhatUpload);
        }
        public void CapNhat_DuKQ_XN(string _MaTiepNhan)
        {
            _iTestresult.CapNhat_DuKQ_XN(_MaTiepNhan);
        }
        public bool CapNhatValid_WithReportType(string maTiepnhan, string reportType, bool isValid, string nguoiValid, string category)
        {
            return _iTestresult.CapNhatValid_WithReportType(maTiepnhan, reportType, isValid, nguoiValid, category);
        }
        public bool CapNhatValid_WithCondit(string maTiepnhan, string lisMaXN, bool isValid, string nguoiValid)
        {
            return _iTestresult.CapNhatValid_WithCondit(maTiepnhan, lisMaXN, isValid, nguoiValid);
        }
        public void CapNhat_Valid_XN(string maTiepNhan, string uservalid)
        {
            _iTestresult.CapNhat_Valid_XN(maTiepNhan, uservalid);
        }
        public void InsertNATToInfinity(string maTiepNhan, DateTime date)
        {
            _iTestresult.InsertNATToInfinity(maTiepNhan, date);
        }
        public int DownloadTest(string sid, int value)
        {
            return _iTestresult.DownloadTest(sid, value);
        }
        public int DeleteNAT(string sid, int value)
        {
            return _iTestresult.DeleteNAT(sid, value);
        }
        public void UpdateDownload(string maTiepNhan, string maXN, bool download)
        {
            _iTestresult.UpdateDownload(maTiepNhan, maXN, download);
        }
        public void CapNhat_KQ_XN_TuyDo(KetQuaHuyetTuyDo objInfo)
        {
            _iTestresult.CapNhat_KQ_XN_TuyDo(objInfo);
        }
        public string CapNhat_KQ_XN(UpdateResultNormalInfo info)
        {
            return _iTestresult.CapNhat_KQ_XN(info);
        }
        public string CapNhat_ThongTinMayXn_XnChinh(string maTiepNhan, bool forAnalyzer = false)
        {
            return _iTestresult.CapNhat_ThongTinMayXn_XnChinh(maTiepNhan, forAnalyzer);
        }
        public void CapNhat_MayChay_Ketqua(string maTiepNhan, string maXN, string IdMay, string userNhap, bool capNhatGhiChu = true)
        {
            _iTestresult.CapNhat_MayChay_Ketqua(maTiepNhan, maXN, IdMay, userNhap, capNhatGhiChu);
        }
        public void CapNhat_Co_Ketqua(string maTiepNhan, string maXN, string co, string userNhap)
        {
            _iTestresult.CapNhat_Co_Ketqua(maTiepNhan, maXN, co, userNhap);
        }
        public void CapNhat_GhiChuKQ_XN(string maTiepNhan, string maXN, string ghiChu, string userNhap, string userUpdate)
        {
            _iTestresult.CapNhat_GhiChuKQ_XN(maTiepNhan, maXN, ghiChu, userNhap, userUpdate);
        }
        public void XacNhan_KQ_XN(string maTiepNhan, string maXn, string trangThai, bool valid
            , string nguoiXn, bool xacNhanDe, int layNguoiThucHien)
        {
            _iTestresult.XacNhan_KQ_XN(maTiepNhan, maXn, trangThai, valid, nguoiXn, xacNhanDe, layNguoiThucHien);
        }
        public bool CapNhatIDMauKetQua(string matiepnhan, string maXn)
        {
            return _iTestresult.CapNhatIDMauKetQua(matiepnhan, maXn);
        }

        public DataTable DataIDMauKetQua(string matiepnhan, string maBoPhan)
        {
            return _iTestresult.DataIDMauKetQua(matiepnhan, maBoPhan);
        }
        public bool CapNhatPrintOut_WithoutReportType(string maTiepnhan, string someTestIn
            , string categoryPrint, bool isPrint, string nguoiIn, string boPhan
            , bool tuXacNhan, bool xacNhanDe, string kyTen, int idLayNguoiThucHien)
        {
            return _iTestresult.CapNhatPrintOut_WithoutReportType(maTiepnhan, someTestIn
                , categoryPrint, isPrint, nguoiIn, boPhan, tuXacNhan, xacNhanDe, kyTen, idLayNguoiThucHien);
        }
        public bool CapNhatPrintOut_WithReportType(string maTiepnhan, string reportType
            , bool isPrint, string nguoiIn, bool tuXacNhan, string someTestIn, bool xacNhanDe, string kyTen, int idLayNguoiThucHien)
        {
            return _iTestresult.CapNhatPrintOut_WithReportType(maTiepnhan, reportType, isPrint
                , nguoiIn, tuXacNhan, someTestIn, xacNhanDe, kyTen, idLayNguoiThucHien);
        }
        public bool CapNhat_GhiChuHenTraKQ(string matTiepNhan, string maXn, string maNhom, bool cotKetQua, string noidung, DateTime tgtraKQ, string TGCoKQ)
        {
            return _iTestresult.CapNhat_GhiChuHenTraKQ(matTiepNhan, maNhom, maXn, cotKetQua, noidung, tgtraKQ, TGCoKQ);
        }
        public int CapNhat_In_KQ_XN(string maTiepNhan, string nguoiXN, bool xacNhanketqua)
        {
            return _iTestresult.CapNhat_In_KQ_XN(maTiepNhan, nguoiXN, xacNhanketqua);
        }
        public DataTable Load_ChiDinhXetNghiem(string _MaTiepNhan, string maXn = "")
        {
            return _iTestresult.Load_ChiDinhXetNghiem(_MaTiepNhan, maXn);
        }
        public bool Ins_KetQua_LabBlood(string maTiepNhan, string lstXN)
        {
            return _iTestresult.Ins_KetQua_LabBlood(maTiepNhan, lstXN);
        }
        public bool Del_KetQua_LabBlood(string maTiepNhan, string lstXN)
        {
            return _iTestresult.Del_KetQua_LabBlood(maTiepNhan, lstXN);
        }
        public bool Update_BnTruyenMau_KQNhomMau(string sid, string abo, string rh, string userU)
        {
            return _iTestresult. Update_BnTruyenMau_KQNhomMau(sid, abo, rh, userU);
        }
        public void Get_CLS_KetQua_XN(DataTable dtInfo, int index, DataGridView dtg, BindingNavigator bv,
             ref DataTable dt, string userSign, DateTime ngayInKQ, string[] userWorkPlace, string reportType
            , bool reprint, TestType.EnumTestType[] testType, string inCategory, bool sinhHocPhanTu = false, string maCaptren = ""
            , bool dulieuIn = false, string inBoPhan = "", bool chiInCoKetQua = false, string userPermision = ""
            , bool huyetDo = false
            , TestType.EnumTestType idLoaiXnHuyetDo = TestType.EnumTestType.HuyetDo)
        {
            dt = DuLieuIn_XN(dtInfo, index, false, userSign, string.Empty, false, ngayInKQ, userWorkPlace
               , reportType, reprint, testType, inCategory, true, sinhHocPhanTu, maCaptren, dulieuIn, inBoPhan
               , chiInCoKetQua, userPermision, huyetDo, idLoaiXnHuyetDo);
            if (dtg != null && bv != null)
                ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public DataTable DuLieuIn_XN(DataTable dtThongTin, int index, bool layMailTheoBn, string userSign, string xnIn, bool title, DateTime? ngayInKQ
            , string[] userWorkPlace, string reportType, bool reprint, TestType.EnumTestType[] testType, string inCategory
            , bool TgInDauTien = false, bool sinhHocPhanTu = false, string maCaptren = "", bool dulieuIn = false
            , string inBoPhan = "", bool chiInCoKetQua = false, string userPermision = "", bool huyetDo = false
            , TestType.EnumTestType idLoaiXnHuyetDo = TestType.EnumTestType.HuyetDo, string soPhieuChiDinh = "", bool layTienSu = false)
        {
            return _iTestresult.DuLieuIn_XN(dtThongTin, index, layMailTheoBn, userSign, xnIn, title, ngayInKQ
             , userWorkPlace, reportType, reprint, testType, inCategory, TgInDauTien, sinhHocPhanTu, maCaptren
             , dulieuIn, inBoPhan, chiInCoKetQua, userPermision, huyetDo, idLoaiXnHuyetDo, soPhieuChiDinh, layTienSu);
        }
        public DataTable DuLieuKetQua_XN(DataTable dtThongTin, int index, bool layMailTheoBn, string userSign, string xnIn, bool title, DateTime? ngayInKQ
            , string[] userWorkPlace, string reportType, bool reprint, TestType.EnumTestType[] testType, string inCategory
            , bool TgInDauTien = false, bool sinhHocPhanTu = false, string maCaptren = "", bool dulieuIn = false
            , string inBoPhan = "", bool chiInCoKetQua = false, string userPermision = "", bool huyetDo = false
            , TestType.EnumTestType idLoaiXnHuyetDo = TestType.EnumTestType.HuyetDo, string soPhieuChiDinh = "")
        {
            return _iTestresult.DuLieuKetQua_XN(dtThongTin, index, layMailTheoBn, userSign, xnIn, title, ngayInKQ
             , userWorkPlace, reportType, reprint, testType, inCategory, TgInDauTien, sinhHocPhanTu, maCaptren
             , dulieuIn, inBoPhan, chiInCoKetQua, userPermision, huyetDo, idLoaiXnHuyetDo, soPhieuChiDinh);
        }
        public DataTable DuLieuXetNghiemCanhBao(string maTiepNhan)
        {
            return _iTestresult.DuLieuXetNghiemCanhBao(maTiepNhan);
        }
        public void CapNhat_KetLuan_XN(string maTiepNhan, string ketLuan, string ghiChu)
        {
            _iTestresult.CapNhat_KetLuan_XN(maTiepNhan, ketLuan, ghiChu);
        }
 
        public int CapNhat_GhoChu_XNTheoBoPhan(string maTiepNhan, string maBoPhan, string ghiChu, string userNhap)
        {
            return _iTestresult.CapNhat_GhiChu_XNTheoBoPhan(maTiepNhan, maBoPhan, ghiChu, userNhap);
        }
        public void CapNhat_SauChiDinh_XetNghiem(string maTiepNhan, string tenTruong, bool co, string user)
        {
            _iTestresult.CapNhat_SauChiDinh_XetNghiem(maTiepNhan, tenTruong, co, user);
        }
        public int CapNhat_NoiKiemTraChatLuong(string maTiepNhan, string maXN, string noikiemTraChatLuong)
        {
            return _iTestresult.CapNhat_NoiKiemTraChatLuong(maTiepNhan, maXN, noikiemTraChatLuong);
        }
        public void CapNhat_PhatHanhKQXN(string maTiepNhan, bool bPhatHanh, string user)
        {
            _iTestresult.CapNhat_PhatHanhKQXN(maTiepNhan, bPhatHanh, user);
        }
        public bool CapNhatKetQuaXN_TheoLoaiXN(string maTiepNhan, string ketQua, int enumLoaiXN)
        {
            return _iTestresult.CapNhatKetQuaXN_TheoLoaiXN(maTiepNhan, ketQua, enumLoaiXN);
        }

        public DataTable Data_DanhSach_HuyXacNhanHIS(string maTiepNhan, string lstXN, string userID)
        {
            return _iTestresult.Data_DanhSach_HuyXacNhanHIS(maTiepNhan, lstXN, userID);
        }
        public bool Check_HaveResult_XN(string maTiepNhan, string maXn)
        {
            return _iTestresult.Check_HaveResult_XN(maTiepNhan, maXn);
        }
        public string Get_GhiChuCuaXetNghiem(string maTiepNhan, string maXn)
        {
            return _iTestresult.Get_GhiChuCuaXetNghiem(maTiepNhan, maXn);
        }
        public ThongTinKetQua Info_ThongTinKetQua(string maTiepNhan, string maXn)
        {
            return _iTestresult.Info_ThongTinKetQua(maTiepNhan, maXn);
        }
        public bool Check_HaveResult_For_XNChinh(string maTiepNhan, string profileId)
        {
            return _iTestresult.Check_HaveResult_For_XNChinh(maTiepNhan, profileId);
        }
        public bool Delete_ChiDinhCLS_XN(string maTiepNhan, string maXn, string profileId, string userDelete, bool delPatient = false)
        {
            return _iTestresult.Delete_ChiDinhCLS_XN(maTiepNhan, maXn, profileId, userDelete, delPatient);
        }
        public DataTable DanhSachBenhNhanInTuDong(DieuKienInTuDong dieuKien)
        {
            return _iTestresult.DanhSachBenhNhanInTuDong(dieuKien);
        }
        public DataTable DanhSachBenhNhanInHangLoat(DieuKienInTuDong dieuKien)
        {
            return _iTestresult.DanhSachBenhNhanInHangLoat(dieuKien);
        }
        public void Search_PatientXN(DateTime dtDateFrom, DateTime dtDateTo, string serviceId, string patientName
             , string seq, bool fullRsult, bool printed, string testId, string category, bool isTestProfile, bool nhapTheoDanhSach
             , DataGridView dtg, BindingNavigator bv, string maBN = "", string sdt = "")
        {
            _iTestresult.Search_PatientXN(dtDateFrom, dtDateTo, serviceId, patientName
                , seq, fullRsult, printed, testId, category, isTestProfile, nhapTheoDanhSach
                , dtg, bv, maBN, sdt);
        }
        public void CapNhat_ThuTien(string maTiepNhan, string chiDinh, bool daThu)
        {
            _iTestresult.CapNhat_ThuTien(maTiepNhan, chiDinh, daThu);
        }
        public void Get_DanhSachChiDinh(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt, bool defaultChecked)
        {
            _iTestresult.Get_DanhSachChiDinh(dtg, bv, filter, ref dt, defaultChecked);
        }
        public DataTable DataAllwayShowTest(string maMauIn, string matiepnhan, string conditSomeTestPrint)
        {
            return _iTestresult.DataAllwayShowTest(maMauIn, matiepnhan, conditSomeTestPrint);
        }
        public DataTable ConvertDataResultPrintFrom_RowToColumn(DataTable dtSource, string conditSomeTestPrint)
        {
            return _iTestresult.ConvertDataResultPrintFrom_RowToColumn(dtSource, conditSomeTestPrint);
        }
        public DataTable DataPrintList_NotAutoSplit(DataTable dataIn, bool CategoryOrDepartment,
            bool coTachPhieu = false, bool showGhiChuTheoXn = false
            , bool ghepTenXnghiChu = false, bool ghepGhiChuKhoa = false
            , string dinhdangGhepDuyet = "", string dinhdangGhepNhapKQ = "")
        {
            return _iTestresult.DataPrintList_NotAutoSplit(dataIn, CategoryOrDepartment,
            coTachPhieu, showGhiChuTheoXn
            , ghepTenXnghiChu, ghepGhiChuKhoa
            , dinhdangGhepDuyet, dinhdangGhepNhapKQ);
        }
        public DataTable DataPrintList_AutoSplit(DataTable dataIn, int rowLimit, int rowForSign, int testLenghtLimt, int testResultLenghtLimt
      , int addressLenghtLimt, int diagnostictLenghtLimt, bool printWithConvert)
        {
            return _iTestresult.DataPrintList_AutoSplit(dataIn, rowLimit, rowForSign, testLenghtLimt, testResultLenghtLimt, addressLenghtLimt, diagnostictLenghtLimt, printWithConvert);
        }
        public string XuLytenMayChay(DataTable dataResultIn)
        {
            return _iTestresult.XuLytenMayChay(dataResultIn);
        }
        public string XuLyTenBS(DataTable dataResultIn)
        {
            return _iTestresult.XuLyTenBS(dataResultIn);
        }
        public string XuLyTenKhoa(DataTable dataResultIn)
        {
            return _iTestresult.XuLyTenKhoa(dataResultIn);
        }
        public string XuLytenLoaiMau(DataTable dataResultIn)
        {
            return _iTestresult.XuLytenLoaiMau(dataResultIn);
        }
        public string XuLyNguoiDuyetYKhoa(DataTable dataResultIn, bool tacnhNhom, string dinhdangGhep)
        {
            return _iTestresult.XuLyNguoiDuyetYKhoa(dataResultIn, tacnhNhom, dinhdangGhep);
        }
        public string XuLyNguoiNhapKetQua(DataTable dataResultIn, bool tacnhNhom, string dinhdangGhep)
        {
            return _iTestresult.XuLyNguoiNhapKetQua(dataResultIn, tacnhNhom, dinhdangGhep);
        }
        public string XulyCommnetChung(DataTable dataResultIn, bool ghiChuTheoXn = false, bool gheptenXnghiChu = false, bool ghepCghiChuKhoa = false)
        {
            return _iTestresult.XulyCommnetChung(dataResultIn, ghiChuTheoXn, gheptenXnghiChu, ghepCghiChuKhoa);
        }
        #region Sinh học phân tử
        public int LuuKetQua_SHPT(KETQUA_CLS_XETNGHIEM_SPHT obj)
        {
            return _iTestresult.LuuKetQua_SHPT(obj);
        }
        public int LuuKetQua_SHPT_KhongUpdateKetQua(KETQUA_CLS_XETNGHIEM_SPHT obj)
        {
            return _iTestresult.LuuKetQua_SHPT_KhongUpdateKetQua(obj);
        }

        public int CapNhat_Hinhanh_SHPT(KETQUA_CLS_XETNGHIEM_SPHT obj)
        {
            return _iTestresult.CapNhat_Hinhanh_SHPT(obj);
        }
        public bool Delete_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn)
        {
            return _iTestresult.Delete_ketqua_cls_xetnghiem_spht(matiepnhan, maxn);
        }
        public DataTable Data_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn)
        {
            return _iTestresult.Data_ketqua_cls_xetnghiem_spht(matiepnhan, maxn);
        }

        public KETQUA_CLS_XETNGHIEM_SPHT Get_Info_ketqua_cls_xetnghiem_spht(string matiepnhan, string maxn)
        {
            return _iTestresult.Get_Info_ketqua_cls_xetnghiem_spht(matiepnhan, maxn);
        }
        public bool Check_ExistsSHPT_Gen(string matiepnhan, string maxn, string magen)
        {
            return _iTestresult.Check_ExistsSHPT_Gen(matiepnhan, maxn, magen);
        }
        public int Insert_Update_SHPT_Gen(KETQUA_CLS_XETNGHIEM_SHPT_GEN obj)
        {
            return _iTestresult.Insert_Update_SHPT_Gen(obj);
        }
        public int Delete_SHPT_Gen(KETQUA_CLS_XETNGHIEM_SHPT_GEN obj)
        {
            return _iTestresult.Delete_SHPT_Gen(obj);
        }
        public KETQUA_CLS_XETNGHIEM_SHPT_GEN Get_Info_SHPT_Gen(string matiepnhan, string maxn, string magen)
        {
            return _iTestresult.Get_Info_SHPT_Gen(matiepnhan, maxn, magen);
        }
        public DataTable Data_SHPT_Gen(string matiepnhan, string maxn, string magen)
        {
            return _iTestresult.Data_SHPT_Gen(matiepnhan, maxn, magen);
        }
        public DataTable Data_SHPT_Gen_In(string matiepnhan, string maxn, string magen)
        {
            return _iTestresult.Data_SHPT_Gen_In(matiepnhan, maxn, magen);
        }
        public int LuuIdDienGiai(string matiepnhan, string maxn, int id, string nguoiThuchien)
        {
            return _iTestresult.LuuIdDienGiai(matiepnhan, maxn, id, nguoiThuchien);
        }
        public DataTable DataThongTinDienGiai(string matiepnhan, string maxn)
        {
            return _iTestresult.DataThongTinDienGiai(matiepnhan, maxn);
        }
        public void CapNhat_KieuGen_XN(string maTiepNhan, string maXN, string kieugen, string userNhap, string userUpdate)
        {
            _iTestresult.CapNhat_KieuGen_XN(maTiepNhan, maXN, kieugen, userNhap, userUpdate);
        }
        #endregion
        #region Danh sách chỉ định xet nghiem
        public DataTable Load_ChiDinhXetNghiemDichVuTheoOngMau(List<string> lstMaTiepNhan, string manhomloaiMau)
        {
            return _iTestresult.Load_ChiDinhXetNghiemDichVuTheoOngMau(lstMaTiepNhan, manhomloaiMau);
        }
        public List<KETQUA_CLS_XETNGHIEM> lstXetnghiem(List<string> lstMaTiepNhan, string maOngMau)
        {
            return _iTestresult.lstXetnghiem(lstMaTiepNhan, maOngMau);
        }
        #endregion
        #region Hinh anh may huyet do
        public int CapNhat_HinhAnh_MayXN(string maTiepNhan, string idMay, string maXnMay, string chuoiHinhAnh, Image hinhAnh)
        {
            return _iTestresult.CapNhat_HinhAnh_MayXN(maTiepNhan, idMay, maXnMay, chuoiHinhAnh, hinhAnh);
        }
        public int Xoa_HinhAnh_MayXn(string maTiepNhan, string idMay)
        {
            return _iTestresult.Xoa_HinhAnh_MayXn(maTiepNhan, idMay);
        }
        public DataTable Data_HinhAnh_TuMay(string maTiepNhan, string IdMay)
        {
            return _iTestresult.Data_HinhAnh_TuMay(maTiepNhan, IdMay);
        }
        #endregion
        #region Cap nhat dang xu ly
        public int CapNhat_TrangThaiDangXuLy_ChoNhom(string maTiepNhan, List<string> lstNhom, bool dangXuly)
        {
            return _iTestresult.CapNhat_TrangThaiDangXuLy_ChoNhom(maTiepNhan, lstNhom, dangXuly);
        }
        public int CapNhat_TrangThaiDangXuLy_ChoBoPhan(string maTiepNhan, List<string> lstBoPhan, bool dangXuly)
        {
            return _iTestresult.CapNhat_TrangThaiDangXuLy_ChoBoPhan(maTiepNhan, lstBoPhan, dangXuly);
        }
        #endregion
        #region XetNghiem_LayMauThuThuat
      public  int InsUpdDel_XetNghiem_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo, string flag)
        {
            return _iTestresult.InsUpdDel_XetNghiem_LayMauThuThuat(objInfo, flag);
        }
        public int Delete_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo)
        {
            return _iTestresult.Delete_LayMauThuThuat(objInfo);
        }
        public int Insert_Update_XetNghiem_LayMauThuThuat(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objInfo)
        {
            return _iTestresult.Insert_Update_XetNghiem_LayMauThuThuat(objInfo);
        }
        public DataTable Data_LayMauThuThuat(string matiepnhan, string maxn)
        {
            return _iTestresult.Data_LayMauThuThuat(matiepnhan, maxn);
        }
        public KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT GetInfo_XetNghiem_LayMauThuThuat(string matiepnhan, string maxn)
        {
            return _iTestresult.GetInfo_XetNghiem_LayMauThuThuat(matiepnhan, maxn);
        }
        public KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT GetInfo_XetNghiem_LayMauThuThuatByRow(DataRow dr)
        {
            return _iTestresult.GetInfo_XetNghiem_LayMauThuThuatByRow(dr);
        }
        #endregion
        #region Nhận xét - Đề nghị - Kết luận => Nhóm
        public int Update_NhanXetDeNghi_Nhom(string maTiepNhan, string maNhomCLS
            , string nhanXet, string nguoiNhanXet, string deNghi, string nguoiDeNghi
            , string ketLuan, string nguoiKetLuan, bool nguyCoCao, bool xetNghiemLan2, bool thamgiachandoan, bool chandoancobenh)
        {
            return _iTestresult.Update_NhanXetDeNghi_Nhom(maTiepNhan, maNhomCLS, nhanXet, nguoiNhanXet, deNghi, nguoiDeNghi
                , ketLuan, nguoiKetLuan, nguyCoCao, xetNghiemLan2, thamgiachandoan, chandoancobenh);
        }
        #endregion
    }
}
