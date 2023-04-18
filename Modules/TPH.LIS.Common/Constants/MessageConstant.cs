using System;
using TPH.Language;

namespace TPH.LIS.Common
{
    public class MessageConstant
    {

        public const string ClinicManagement = "TPH.LabIMS";
        /// <summary>
        /// THÔNG BÁO LỖI
        /// </summary>
        public const string MessageBoxTitleError = "THÔNG BÁO LỖI"; //LanguageExtension.GetResourceValueFromKey("THONGBAOLOI_Upper", LanguageExtension.AppLanguage);
        /// <summary>
        /// License: Unregistered
        /// </summary>
        public const string LicenseUnRegister = "License: Unregistered";
        /// <summary>
        /// License: Full License
        /// </summary>
        public const string LicenseFull = "License: Full License";
        /// <summary>
        /// License: Expired
        /// </summary>
        public const string LicenseExpired = "License: Expired";
        /// <summary>
        /// Dòng
        /// </summary>
        public string Closed => LanguageExtension.GetResourceValueFromKey("Dong", LanguageExtension.AppLanguage);
        /// <summary>
        /// Chi tiết
        /// </summary>
        public string Detail =>
            LanguageExtension.GetResourceValueFromKey("Chitiet", LanguageExtension.AppLanguage);
        /// <summary>
        /// Ẩn C.tiết
        /// </summary>
        public string HideDetail =>
            LanguageExtension.GetResourceValueFromKey("AnCCHAMtiet", LanguageExtension.AppLanguage);
        /// <summary>
        /// Bạn có chắc muốn thoát ứng dụng?
        /// </summary>
        public static string ExitProgram => LanguageExtension.GetResourceValueFromKey("BancochacmuonthoatungdungHOI", LanguageExtension.AppLanguage);
        /// <summary>
        /// Bạn có chắn muốn Xoá các chỉ định được chọn?
        /// </summary>
        public string DeleteOrderQuestion =>
            LanguageExtension.GetResourceValueFromKey("BancochanmuonXoacacchidinhduocchonHOI",
                LanguageExtension.AppLanguage);
        /// <summary>
        /// Ngày làm việc
        /// </summary>
        public static string NgayLamViec => LanguageExtension.GetResourceValueFromKey("NgayLamViec",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Phần mềm chưa đăng ký ngày sử dụng, vui lòng nhập mã đăng ký để sử dụng.
        /// </summary>
        public string PhanMemChuaDangKyNgaySuDung => LanguageExtension.GetResourceValueFromKey(
            "PhanmemchuadangkyngaysudungPHAYvuilongnhapmadangkydesudungCHAM",
            LanguageExtension.AppLanguage);
        
        /// <summary>
        /// License cấp theo Server
        /// </summary>
        public string LicenseOnServer => LanguageExtension.GetResourceValueFromKey(
            "LicensecaptheoServer",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// License cấp theo Máy trạm
        /// </summary>
        public string LicenseOnClient  => LanguageExtension.GetResourceValueFromKey(
            "LicensecaptheoMaytram",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Đây là phiên bản đầy đủ không giới hạn ngày sử dụng.
        /// </summary>
        public string PhienBanDayDuKhongGioiHan  => LanguageExtension.GetResourceValueFromKey(
            "DaylaphienbandaydukhonggioihanngaysudungCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Phần mềm đã hết hạn sử dụng từ ngày {0:dd/MM/yyyy}, vui lòng nhập mã đăng ký mới để tiếp tục sử dụng.
        /// </summary>
        public string PhanMemDaHetHanSuDungTuNgay => LanguageExtension.GetResourceValueFromKey(
            "PhanmemdahethansudungtungayMONGOACNHONKHONGLAddTRENMMTRENyyyyDONGNGOACNHONPHAYvuilongnhapmadangkymoidetieptucsudungCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// License: Trial ({0} days)
        /// </summary>
        public string LicenseTrial => "License: Trial ({0} days)";
        /// <summary>
        /// Đây là phiên bản có giới hạn ngày sử dụng, sử dụng đến hết ngày {0: dd/MM/yyyy}
        /// </summary>
        public string PhienBanDungThuDenHetNgay => LanguageExtension.GetResourceValueFromKey(
            "DaylaphienbancogioihanngaysudungPHAYsudungdenhetngayMONGOACNHONKHONGLAddTRENMMTRENyyyyDONGNGOACNHON",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Xin vui lòng nhập mã đăng ký!
        /// </summary>
        public string VuiLongNhapMaDangKy => LanguageExtension.GetResourceValueFromKey(
            "XinvuilongnhapmadangkyCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Xin chúc mừng, bạn đã đăng ký thành công!
        /// </summary>
        public string XinChucMungBanDangKyThanhCong => LanguageExtension.GetResourceValueFromKey(
            "XinchucmungPHAYbandadangkythanhcongCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Mã đăng ký không đúng, vui lòng kiểm tra lại.
        /// </summary>
        public string MaDangKyKhongDung => LanguageExtension.GetResourceValueFromKey(
            "MadangkykhongdungPHAYvuilongkiemtralaiCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Ứng dụng chưa được đăng ký. Vui lòng liên hệ với Kỹ thuật TPH để hỗ trợ!
        /// </summary>
        public string UngDungChuaDangKy => LanguageExtension.GetResourceValueFromKey(
            "UngdungchuaduocdangkyCHAMVuilonglienhevoiKythuatTPHdehotroCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// {0}: Đã hết thời gian dùng thử ({1} ngày từ: {2:dd/MM/yyyy} đến: {3:dd/MM/yyyy})
        /// </summary>
        public static string PhanMemDaHetHanSuDung => LanguageExtension.GetResourceValueFromKey(
            "MONGOACNHONKHONGDONGNGOACNHONLADahetthoigiandungthuMONGOACDONMONGOACNHONMOTDONGNGOACNHONngaytuLAMONGOACNHONHAILAddTRENMMTRENyyyyDONGNGOACNHONdenLAMONGOACNHONBALAddTRENMMTRENyyyyDONGNGOACNHONDONGNGOACDON",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// {0}: Đã hết thời gian dùng thử ({1} ngày). Vui lòng liên hệ với Kỹ thuật TPH để được hổ trợ!
        /// </summary>
        public static  string PhanMemDaHetHanSuDungVuiLongLienHe => LanguageExtension.GetResourceValueFromKey(
            "MONGOACNHONKHONGDONGNGOACNHONLADahetthoigiandungthuMONGOACDONMONGOACNHONMOTDONGNGOACNHONngayDONGNGOACDONCHAMVuilonglienhevoiKythuatTPHdeduochotroCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// {0}: Phiên bản dùng thử (Bạn còn {1} ngày sử dụng)
        /// </summary>
        public static string PhanMemConNgayDungThu => LanguageExtension.GetResourceValueFromKey(
            "MONGOACNHONKHONGDONGNGOACNHONLAPhienbandungthuMONGOACDONBanconMONGOACNHONMOTDONGNGOACNHONngaysudungDONGNGOACDON",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Bạn còn {0} ngày sử dùng. Vui lòng liên hệ với TPH để không bị gián đoạn công việc!
        /// </summary>
        /// 
        //public  string BanConNgayLamViecVuiLongLienHeTph => LanguageExtension.GetResourceValueFromKey(
        //    "BanconMONGOACNHONKHONGDONGNGOACNHONngaysudungCHAMVuilonglienhevoiTPHdekhongbigiandoancongviecCHAMCAM",
        //    LanguageExtension.AppLanguage);
        public const string BanConNgayLamViecVuiLongLienHeTph = "Bạn còn {0} ngày sử dùng. Vui lòng liên hệ với TPH để không bị gián đoạn công việc!";

        /// <summary>
        /// Máy tính chưa khai báo khu vực làm việc!
        /// </summary>
        public string PCNotCreatePlaceWork => LanguageExtension.GetResourceValueFromKey(
            "MaytinhchuakhaibaokhuvuclamviecCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Máy tính chưa khai báo khu vực làm việc hoặc tài khoản không được cấp quyền trong khu vực này.
        /// </summary>
        public string PCNotCreatePlaceWorkOrPermission => LanguageExtension.GetResourceValueFromKey(
            "MaytinhchuakhaibaokhuvuclamviechoactaikhoankhongduoccapquyentrongkhuvucnayCHAM",
            LanguageExtension.AppLanguage);

        /// <summary>
        /// Copyright © {DateTime.Now:yyyy} TPH Solutions All Rights Reserved.
        /// </summary>
        public static string Copyright = $@"Copyright © {DateTime.Now:yyyy} TPH Solutions All Rights Reserved.";
        /// <summary>
        /// Sai tên đăng nhập hoặc mật khẩu
        /// </summary>
        public string WrongLoginuserOrPassword => LanguageExtension.GetResourceValueFromKey(
            "SaitendangnhaphoacmatkhauCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Đang đọc cấu hình kết nối HIS!
        /// </summary>
        public string LoadingConfigHIS => LanguageExtension.GetResourceValueFromKey(
            "DangdoccauhinhketnoiHISCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hãy lưu thông tin tiếp nhận trước khi nhập chỉ định.
        /// </summary>
        public string ChiDinh_Error => LanguageExtension.GetResourceValueFromKey(
            "HayluuthongtintiepnhantruockhinhapchidinhCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Bạn đang trong chế độ nhập mới!
        /// </summary>
        public string Bandangtrongchedonhapmoi => LanguageExtension.GetResourceValueFromKey(
            "BandangtrongchedonhapmoiCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// NHẤN LƯU ĐỂ CẬP NHẬT
        /// </summary>
        public string NHANLUUDECAPNHAT_Upper => LanguageExtension.GetResourceValueFromKey(
            "BandangtrongchedonhapmoiCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hãy nhập barcode.
        /// </summary>
        public string Haynhapbarcode => LanguageExtension.GetResourceValueFromKey(
            "HaynhapbarcodeCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hãy nhập tuổi.
        /// </summary>
        public string Haynhaptuoi => LanguageExtension.GetResourceValueFromKey(
            "HaynhaptuoiCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hãy nhập giới tính.
        /// </summary>
        public string Haynhapgioitinh => LanguageExtension.GetResourceValueFromKey(
            "HaynhapgioitinhCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hãy nhập đối tượng dịch vụ.
        /// </summary>
        public string Haynhapdoituongdichvu => LanguageExtension.GetResourceValueFromKey(
            "HaynhapdoituongdichvuCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Bệnh nhân đã có KQ.\nBạn không thể xóa bệnh nhân này!
        /// </summary>
        public string BenhnhandacoKQ => LanguageExtension.GetResourceValueFromKey(
            "BenhnhandacoKQCHAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Xoá bệnh nhân
        /// </summary>
        public string XoabenhnhanLA => LanguageExtension.GetResourceValueFromKey(
            "XoabenhnhanLA",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hãy lưu thông tin bệnh nhân trước khi nhập chỉ định!
        /// </summary>
        public string Hayluuthongtinbenhnhantruockhinhapchidinh => LanguageExtension.GetResourceValueFromKey(
            "HayluuthongtinbenhnhantruockhinhapchidinhCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// đã được nhập
        /// </summary>
        public string Daduocnhap => LanguageExtension.GetResourceValueFromKey(
            "daduocnhap",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Chỉ định
        /// </summary>
        public string Chidinh => LanguageExtension.GetResourceValueFromKey(
            "Chidinh",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hãy nhập số lượng!
        /// </summary>
        public string Haynhapsoluong => LanguageExtension.GetResourceValueFromKey(
            "HaynhapsoluongCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Hủy thao tác chỉnh sửa thông tin?
        /// </summary>
        public string Huythaotacchinhsuathongtin => LanguageExtension.GetResourceValueFromKey(
            "HuythaotacchinhsuathongtinHOI",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Bạn đang trong chế độ nhập mới! Lưu dữ liệu trước khi thêm chỉ định!
        /// </summary>
        public string BandangtrongchedonhapmoiPlsSaveBefore => LanguageExtension.GetResourceValueFromKey(
            "BandangtrongchedonhapmoiCHAMCAMLuudulieutruockhithemchidinhCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Bạn đang trong chế độ chỉnh sửa! Lưu dữ liệu trước khi thêm chỉ định!
        /// </summary>
        public string Bandangtrongchedochinhsua => LanguageExtension.GetResourceValueFromKey(
            "BandangtrongchedochinhsuaCHAMCAMLuudulieutruockhithemchidinhCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Không thể xóa bệnh nhân tiếp nhận từ HIS, hãy thực hiện hủy tiếp nhận!
        /// </summary>
        public string KhongthexoabenhnhantiepnhantuHIS => LanguageExtension.GetResourceValueFromKey(
            "KhongthexoabenhnhantiepnhantuHISPHAYhaythuchienhuytiepnhanCHAMCAM",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// ĐANG CHẾ ĐỘ NHẬP MỚI
        /// </summary>
        public string DANGCHEDONHAPMOI_Upper => LanguageExtension.GetResourceValueFromKey(
            "DANGCHEDONHAPMOI_Upper",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// ĐÃ THÊM MỚI THÀNH CÔNG.
        /// </summary>
        public string DATHEMMOITHANHCONGCHAM_Upper => LanguageExtension.GetResourceValueFromKey(
            "DATHEMMOITHANHCONGCHAM_Upper",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// THÔNG TIN ĐÃ ĐƯỢC LƯU
        /// </summary>
        public string THONGTINDADUOCLUU_Upper => LanguageExtension.GetResourceValueFromKey(
            "THONGTINDADUOCLUU_Upper",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// ĐANG CHẾ ĐỘ CHỈNH SỬA
        /// </summary>
        public string DANGCHEDOCHINHSUA_Upper => LanguageExtension.GetResourceValueFromKey(
            "DANGCHEDOCHINHSUA_Upper",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Không thể tiếp nhận các chỉ định có LISCode => 0
        /// </summary>
        public string KhongthetiepnhancacchidinhcoLISCode => LanguageExtension.GetResourceValueFromKey(
            "KhongthetiepnhancacchidinhcoLISCode=>KHONG",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// BARCODE LIS IN SẴN
        /// </summary>
        public string BARCODELISINSAN_Upper => LanguageExtension.GetResourceValueFromKey(
            "BARCODELISINSAN_Upper",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// BARCODE TỪ HIS
        /// </summary>
        public string BARCODETUHIS_Upper => LanguageExtension.GetResourceValueFromKey(
            "BARCODETUHIS_Upper",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// BARCODE LIS TỰ ĐỘNG
        /// </summary>
        public string BARCODELISTUDONG_Upper => LanguageExtension.GetResourceValueFromKey(
            "BARCODELISTUDONG_Upper",
            LanguageExtension.AppLanguage);
        /// <summary>
        /// Đang lấy danh sách từ HIS\nVui lòng chờ trong giây lát.....
        /// </summary>
        public string DanglaydanhsachtuHIS => LanguageExtension.GetResourceValueFromKey(
            "DanglaydanhsachtuHIS",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đang xử lý danh sách từ HIS...
        ///</summary>
        public string DangxulydanhsachtuHIS => LanguageExtension.GetResourceValueFromKey(
        "DangxulydanhsachtuHISCHAMCHAMCHAM",
        LanguageExtension.AppLanguage);
        ///<summary>
        /// Dữ liệu khi lấy về
        ///</summary>
        public string Dulieukhilayve => LanguageExtension.GetResourceValueFromKey(
            "Dulieukhilayve",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Dữ liệu sau khi xử lý hiển thị
        ///</summary>
        public string Dulieusaukhixulyhienthi => LanguageExtension.GetResourceValueFromKey(
            "Dulieusaukhixulyhienthi",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// KHÔNG TÌM THẤY THÔNG TIN TỪ HIS TRẢ VỀ\nVui lòng kiểm tra lại kết nối HIS.\nHoặc liên hệ phòng CNTT để được hỗ trợ.
        ///</summary>
        public string KHONGTIMTHAYTHONGTINTUHISTRAVE_Upper => LanguageExtension.GetResourceValueFromKey(
            "KHONGTIMTHAYTHONGTINTUHISTRAVE_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Lấy chi tiết chỉ định
        ///</summary>
        public string Laychitietchidinh => LanguageExtension.GetResourceValueFromKey(
            "Laychitietchidinh",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Số phiếu {0} vừa nhập không tìm thấy dữ liệu từ HIS trả về!
        ///</summary>
        public string OrderNotFoundFromHis=> LanguageExtension.GetResourceValueFromKey(
            "SophieuMONGOACNHONKHONGDONGNGOACNHONvuanhapkhongtimthaydulieutuHIStraveCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// HIS phản hồi: 
        ///</summary>
        public string HISResponse => LanguageExtension.GetResourceValueFromKey(
            "HISphanhoiLAMONGOACNHONKHONGDONGNGOACNHON",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đã lấy mẫu"
        ///</summary>
        public string Dalaymau => LanguageExtension.GetResourceValueFromKey(
            "Dalaymau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Chờ lấy mẫu
        ///</summary>
        public string Cholaymau => LanguageExtension.GetResourceValueFromKey(
            "Cholaymau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đã có kết quả
        ///</summary>
        public string Dacoketqua2 => LanguageExtension.GetResourceValueFromKey(
            "Dacoketqua-2",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Barcode trả về {0} -> không hợp lệ
        ///</summary>
        public string Barcodetrave => LanguageExtension.GetResourceValueFromKey(
            "BarcodetraveMONGOACNHONKHONGDONGNGOACNHONTRULONHONkhonghople",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Phản hồi từ HIS:
        ///</summary>
        public string PhanhoituHISLA => LanguageExtension.GetResourceValueFromKey(
            "PhanhoituHISLA",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Số hồ sơ
        ///</summary>
        public string SohosoLA => LanguageExtension.GetResourceValueFromKey(
            "SohosoLA",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Không có số phiếu nào được map
        ///</summary>
        public string Khongcosophieunaoduocmap => LanguageExtension.GetResourceValueFromKey(
            "Khongcosophieunaoduocmap",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Vui lòng nhập số barcode xét nghiệm
        ///</summary>
        public string Vuilongnhapsobarcodexetnghiem => LanguageExtension.GetResourceValueFromKey(
            "Vuilongnhapsobarcodexetnghiem",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Barcode tự động [{0}] không hợp lệ, vui lòng kiểm tra lại
        ///</summary>
        public string Barcodetudongkhonghoplevuilongkiemtralai => LanguageExtension.GetResourceValueFromKey(
            "BarcodetudongMONGOACVUONGMONGOACNHONKHONGDONGNGOACNHONDONGNGOACVUONGkhonghoplePHAYvuilongkiemtralai",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Các chỉ định chưa đóng tiền
        ///</summary>
        public string Cacchidinhchuadongtien => LanguageExtension.GetResourceValueFromKey(
            "Cacchidinhchuadongtien",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Barcode {0} đã sử dụng!
        ///</summary>
        public string Barcodedasudung => LanguageExtension.GetResourceValueFromKey(
            "BarcodeMONGOACNHONKHONGDONGNGOACNHONdasudungCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Barcode {0} đã sử dụng cho bệnh nhân khác!
        ///</summary>
        public string Barcodedasudungchobenhnhankhac => LanguageExtension.GetResourceValueFromKey(
            "BarcodeMONGOACNHONKHONGDONGNGOACNHONdasudungchobenhnhankhacCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Thêm chỉ định cho bệnh nhân: [{0}] - Barcode:{1}
        ///</summary>
        public string ThemchidinhchobenhnhanBarcode => LanguageExtension.GetResourceValueFromKey(
            "ThemchidinhchobenhnhanLAMONGOACVUONGMONGOACNHONKHONGDONGNGOACNHONDONGNGOACVUONGBarcodeLAMONGOACNHONMOTDONGNGOACNHON",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Thực hiện tiếp nhận.....
        ///</summary>
        public string Thuchientiepnhan => LanguageExtension.GetResourceValueFromKey(
            "ThuchientiepnhanCHAMCHAMCHAMCHAMCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// BÀN LẤY MẪU: {0} - Số TT: {1}
        ///</summary>
        public string BANLAYMAULA => LanguageExtension.GetResourceValueFromKey(
            "BANLAYMAULAMONGOACNHONKHONGDONGNGOACNHONTRUSoTTLAMONGOACNHONMOTDONGNGOACNHON",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Không tìm thấy số phiếu! Hãy nhấn \"{0}\" để làm mới danh sách
        ///</summary>
        public string Khongtimthaysophieulammoidanhsach => LanguageExtension.GetResourceValueFromKey(
            "KhongtimthaysophieuCHAMCAMHaynhanDauXiecNgangMONGOACNHONKHONGDONGNGOACNHONDauXiecNgangdelammoidanhsach",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Hãy chọn lý do!
        ///</summary>
        public string Haychonlydo => LanguageExtension.GetResourceValueFromKey(
            "HaychonlydoCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Bạn chắc chắn hủy chỉ định đang chọn?
        ///</summary>
        public string Banchacchanhuychidinhdangchon => LanguageExtension.GetResourceValueFromKey(
            "BanchacchanhuychidinhdangchonHOI",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đang thực hiện hủy tiếp nhận....
        ///</summary>
        public string Dangthuchienhuytiepnhan => LanguageExtension.GetResourceValueFromKey(
            "DangthuchienhuytiepnhanCHAMCHAMCHAMCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Chỉ định '{0}' đã có KQ. Bạn không thể hủy!
        ///</summary>
        public string ChidinhdacoketquaBankhongthehuy => LanguageExtension.GetResourceValueFromKey(
            "ChidinhNHAYDONMONGOACNHONKHONGDONGNGOACNHONNHAYDONdacoKQCHAMBankhongthehuyCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Chỉ định '{0}' đã nhận mẫu.\nBạn không thể hủy!
        ///</summary>
        public string ChidinhdanhanmauBankhongthehuy => LanguageExtension.GetResourceValueFromKey(
            "ChidinhNHAYDONMONGOACNHONKHONGDONGNGOACNHONNHAYDONdanhanmauCHAMBankhongthehuyCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đang hoàn tất hủy tiếp nhận....
        ///</summary>
        public string Danghoantathuytiepnhan => LanguageExtension.GetResourceValueFromKey(
            "DanghoantathuytiepnhanCHAMCHAMCHAMCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đã thực hiện hủy tiếp nhận!
        ///</summary>
        public string MsgDathuchienhuytiepnhan => LanguageExtension.GetResourceValueFromKey(
            "DathuchienhuytiepnhanCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Bệnh nhân không đúng với HIS đang kết nối!
        ///</summary>
        public string BenhnhankhongdungvoiHISdangketnoi=> LanguageExtension.GetResourceValueFromKey(
            "BenhnhankhongdungvoiHISdangketnoiCHAMCAM",
            LanguageExtension.AppLanguage);

        ///<summary>
        /// Chỉ định [{0}] đã được nhập
        ///</summary>
        public string Chidinhdaduocnhap => LanguageExtension.GetResourceValueFromKey(
            "ChidinhMONGOACVUONGMONGOACNHONKHONGDONGNGOACNHONDONGNGOACVUONGdaduocnhap",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// SẴN SÀNG!
        ///</summary>
        public string SanSang =>
            LanguageExtension.GetResourceValueFromKey(
                "SANSANGCHAMCAM_Upper",
                LanguageExtension.AppLanguage);
        ///<summary>
        /// Barcode tiêu chuẩn
        ///</summary>
        public string Barcodetieuchuan => LanguageExtension.GetResourceValueFromKey(
            "Barcodetieuchuan",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Chưa có bàn đăng ký lấy mẫu.
        ///</summary>
        public string Chuacobandangkylaymau=> LanguageExtension.GetResourceValueFromKey(
            "ChuacobandangkylaymauCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Không thể tiếp nhận các chỉ định của số phiếu
        ///</summary>
        public string Khongthetiepnhancacchidinhcuasophieu => LanguageExtension.GetResourceValueFromKey(
            "Khongthetiepnhancacchidinhcuasophieu",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///  - KHU LẤY MẪU
        ///</summary>
        public string MsgTRUKHULAYMAU_Upper => LanguageExtension.GetResourceValueFromKey(
            "TRUKHULAYMAU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// - CHƯA KHAI BÁO KHU LẤY MẪU
        ///</summary>
        public string TRUCHUAKHAIBAOKHULAYMAU_Upper => LanguageExtension.GetResourceValueFromKey(
            "TRUCHUAKHAIBAOKHULAYMAU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Không thể kết nối máy chủ. Vui lòng kiểm tra lại kết nối mạng.
        ///</summary>
        public string KhongtheketnoimaychuVuilongkiemtralaiketnoimang => LanguageExtension.GetResourceValueFromKey(
            "KhongtheketnoimaychuCHAMVuilongkiemtralaiketnoimangCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Năm sinh: {0} Không hợp lệ
        ///</summary>
        public string NamsinhKhonghople => LanguageExtension.GetResourceValueFromKey(
            "NamsinhLAMONGOACNHONKHONGDONGNGOACNHONKhonghople",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Ghi chú lấy mẫu
        ///</summary>
        public string Ghichulaymau => LanguageExtension.GetResourceValueFromKey(
            "Ghichulaymau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Ống mẫu
        ///</summary>
        public string Ongmau => LanguageExtension.GetResourceValueFromKey(
            "Ongmau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// SL Mẫu
        ///</summary>
        public string SLMau => LanguageExtension.GetResourceValueFromKey(
            "SLMau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Thực hiện duyệt lấy mẫu.....
        ///</summary>
        public string Thuchienduyetlaymau => LanguageExtension.GetResourceValueFromKey(
            "ThuchienduyetlaymauCHAMCHAMCHAMCHAMCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Không có thông tin mẫu nào được chọn!
        ///</summary>
        public string Khongcothongtinmaunaoduocchon => LanguageExtension.GetResourceValueFromKey(
            "KhongcothongtinmaunaoduocchonCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// TÌM KIẾM: THEO BARCODE XÉT NGHIỆM
        ///</summary>
        public string TIMKIEMLATHEOBARCODEXETNGHIEM => LanguageExtension.GetResourceValueFromKey(
            "TIMKIEMLATHEOBARCODEXETNGHIEM_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// TÌM KIẾM: THEO SỐ HỒ SƠ VÀ THỜI GIAN NHẬP
        ///</summary>
        public string TIMKIEMLATHEOSOHOSOVATHOIGIANNHAP => LanguageExtension.GetResourceValueFromKey(
            "TIMKIEMLATHEOSOHOSOVATHOIGIANNHAP_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Tìm
        ///</summary>
        public string Tim => LanguageExtension.GetResourceValueFromKey(
            "Tim",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Xóa chọn
        ///</summary>
        public string Xoachon => LanguageExtension.GetResourceValueFromKey(
            "Xoachon",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đưa vào danh sách
        ///</summary>
        public string Duavaodanhsach => LanguageExtension.GetResourceValueFromKey(
            "Duavaodanhsach",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Hủy đưa vào danh sách
        ///</summary>
        public string Huyduavaodanhsach => LanguageExtension.GetResourceValueFromKey(
            "Huyduavaodanhsach",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Xác nhận chuyển mẫu
        ///</summary>
        public string Xacnhanchuyenmau => LanguageExtension.GetResourceValueFromKey(
            "Xacnhanchuyenmau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// MẪU ĐƯỢC YÊU CẦU LẤY LẠI
        ///</summary>
        public string MAUDUOCYEUCAULAYLAI => LanguageExtension.GetResourceValueFromKey(
            "MAUDUOCYEUCAULAYLAI_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// CHƯA DUYỆT LẤY MẪU ĐỦ
        ///</summary>
        public string CHUADUYETLAYMAUDU => LanguageExtension.GetResourceValueFromKey(
            "CHUADUYETLAYMAUDU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// CHƯA DUYỆT LẤY MẪU
        ///</summary>
        public string CHUADUYETLAYMAU => LanguageExtension.GetResourceValueFromKey(
            "CHUADUYETLAYMAU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// ĐÃ DUYỆT LẤY ĐỦ MẪU
        ///</summary>
        public string DADUYETLAYDUMAU => LanguageExtension.GetResourceValueFromKey(
            "DADUYETLAYDUMAU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// CHƯA DUYỆT NHẬN MẪU ĐỦ
        ///</summary>
        public string CHUADUYETNHANMAUDU => LanguageExtension.GetResourceValueFromKey(
            "CHUADUYETNHANMAUDU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// CHƯA DUYỆT NHẬN MẪU
        ///</summary>
        public string CHUADUYETNHANMAU => LanguageExtension.GetResourceValueFromKey(
            "CHUADUYETNHANMAU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// ĐÃ DUYỆT NHẬN ĐỦ MẪU
        ///</summary>
        public string DADUYETNHANDUMAU => LanguageExtension.GetResourceValueFromKey(
            "DADUYETNHANDUMAU_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// TQ: {0}\nVS: {1}
        ///</summary>
        public string TQVS => LanguageExtension.GetResourceValueFromKey(
            "TQLAMONGOACNHONKHONGDONGNGOACNHONVSLAMONGOACNHONMOTDONGNGOACNHON_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Tự nhận mẫu của ngày lấy
        ///</summary>
        public string Tunhanmaucuangaylay => LanguageExtension.GetResourceValueFromKey(
            "Tunhanmaucuangaylay",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Tự nhận mẫu khi có 1 Barcode
        ///</summary>
        public string TunhanmaukhicoMOTBarcode => LanguageExtension.GetResourceValueFromKey(
            "TunhanmaukhicoMOTBarcode",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// DUYỆT NHẬN MẪU XÉT NGHIỆM - NHÓM: {0}
        ///</summary>
        public string DUYETNHANMAUXETNGHIEM => LanguageExtension.GetResourceValueFromKey(
            "DUYETNHANMAUXETNGHIEMTRUNHOMLAMONGOACNHONKHONGDONGNGOACNHON_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// DUYỆT NHẬN MẪU XÉT NGHIỆM - NHÓM: TẤT CẢ
        ///</summary>
        public string DUYETNHANMAUXETNGHIEMALL => LanguageExtension.GetResourceValueFromKey(
            "DUYETNHANMAUXETNGHIEMTRUNHOMLATATCA_Upper",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Thực hiện tự nhận mẫu khi quét code!
        ///</summary>
        public string Thuchientunhanmaukhiquetcode => LanguageExtension.GetResourceValueFromKey(
            "ThuchientunhanmaukhiquetcodeCHAMCAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// \nChỉ nhận mẫu có ngày lấy: {0}
        ///</summary>
        public string Chinhanmaucongaylay => LanguageExtension.GetResourceValueFromKey(
            "ChinhanmaucongaylayLAMONGOACNHONKHONGDONGNGOACNHON",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// --- Tất cả ---
        ///</summary>
        public string Tatca => LanguageExtension.GetResourceValueFromKey(
            "TRUTRUTRUTatcaTRUTRUTRU",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Chưa nhận mẫu
        ///</summary>
        public string ChuaNhanMau => LanguageExtension.GetResourceValueFromKey(
            "ChuaNhanMau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Đã nhận mẫu
        ///</summary>
        public string Danhanmau => LanguageExtension.GetResourceValueFromKey(
            "Danhanmau",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Chưa nhận mẫu đủ
        ///</summary>
        public string ChuaNhanMauDu => LanguageExtension.GetResourceValueFromKey(
            "ChuaNhanMauDu",
            LanguageExtension.AppLanguage);
        ///<summary>
        /// Yêu cầu lấy lại
        ///</summary>
        public string Yeucaulaylai => LanguageExtension.GetResourceValueFromKey(
            "Yeucaulaylai",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///Đang nạp cấu hình hệ thống....
        ///</summary>
        public string Dangnapcauhinhhethong => LanguageExtension.GetResourceValueFromKey(
            "DangnapcauhinhhethongCHAMCHAMCHAMCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///Đang nạp cấu hình quản lý kết quả....
        ///</summary>
        public string Dangnapcauhinhquanlyketqua => LanguageExtension.GetResourceValueFromKey(
            "DangnapcauhinhquanlyketquaCHAMCHAMCHAMCHAM",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///Chưa có kết quả
        ///</summary>
        public string Chuacoketqua => LanguageExtension.GetResourceValueFromKey(
            "Chuacoketqua",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///Đã có kết quả
        ///</summary>
        public string Dacoketqua => LanguageExtension.GetResourceValueFromKey(
            "Dacoketqua-2",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///Đã đủ kết quả
        ///</summary>
        public string Daduketqua => LanguageExtension.GetResourceValueFromKey(
            "Daduketqua",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///Đã duyệt kết quả
        ///</summary>
        public string Daduyetketqua => LanguageExtension.GetResourceValueFromKey(
            "Daduyetketqua",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///Đã in kết quả
        ///</summary>
        public string Dainketqua => LanguageExtension.GetResourceValueFromKey(
            "Dainketqua",
            LanguageExtension.AppLanguage);
        ///<summary>
        ///| In tự động: {0}...
        ///</summary>
        public string Intudong => LanguageExtension.GetResourceValueFromKey(
            "HOACIntudongLAMONGOACNHONKHONGDONGNGOACNHONCHAMCHAMCHAM",
            LanguageExtension.AppLanguage);
    }
}
