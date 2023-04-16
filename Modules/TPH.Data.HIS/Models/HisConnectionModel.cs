using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TPH.LIS.Common.Extensions;

namespace TPH.Data.HIS.Models
{
    public class HISModelHelper
    {

        public static Dictionary<string, string> HisResultBaseConfigList()
        {
            return WorkingServices.GetPorpetiesAndDescriptionList(new HisResultBase()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
        public static Dictionary<string, string> HISResultValidConfigList()
        {
            return WorkingServices.GetPorpetiesAndDescriptionList(new HISResultValid()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
        public static Dictionary<string, string> HisParaConfigList()
        {
            return WorkingServices.GetPorpetiesAndDescriptionList(new HisParaGetList()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
        public static Dictionary<string, string> HisColumnsMappingList()
        {
            return WorkingServices.GetPorpetiesAndDescriptionList(new HISDataColumnNames()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
        public static Dictionary<string, string> HisFuntionIDList()
        {
            return WorkingServices.GetFieldAndDescriptionList(new HisFunctionID()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
        public static Dictionary<string, string> HisHL7ResultOBX()
        {
            return WorkingServices.GetPorpetiesAndDescriptionList(new HL7OBX()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
        public static Dictionary<string, string> HisHL7ResultORCOBR()
        {
            return WorkingServices.GetPorpetiesAndDescriptionList(new HL7ORC_ADT_Detail()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
        public static Dictionary<string, string> HisHL7PID_PV()
        {
            return WorkingServices.GetPorpetiesAndDescriptionList(new HL7PatientInfo()).OrderBy(v => v.Value).ToDictionary(obj => obj.Key, obj => obj.Value);
        }
    }
    public class HisResultUploadID
    {
        [Description("HIS_ Id trả kết quả")]
        public string IdTraKetQua { get; set; }
    }
    public class HisResultBase
    {
        [Description("HIS_LIS_Giá trị Null ")]
        public string NullValue { get; set; }
        [Description("HIS_ Id hành động trả kết quả")]
        public string ResultAction { get; set; }
        [Description("HIS_ Id trả kết quả")]
        public string IdTraKetQua { get; set; }
        [Description("HIS_ Số phiếu trả kết quả")]
        public string SoPhieuKetQua { get; set; }
        [Description("HIS_ Số phiếu chỉ định")]
        public string SoPhieuYeuCau { get; set; }
        [Description("LIS_Barcode")]
        public string Barcode { get; set; }
        [Description("LIS_Mã số xét nghiệm")]
        public string MaSoXetNghiem { get; set; }
        [Description("HIS_Id chỉ định dịch vụ")]
        public string IDDichVuHIS { get; set; }
        [Description("HIS_Mã dịch vụ")]
        public string MaDichVuHIS { get; set; }
        [Description("HIS_Tên dịch vụ")]
        public string TenDichVuHIS { get; set; }
        [Description("LIS_Mã xét nghiệm")]
        public string MaXetNghiemLIS { get; set; }
        [Description("HIS_Mã dịch vụ cha")]
        public string MaDichVuChaHIS { get; set; }
        [Description("LIS_Mã xét nghiệm cha")]
        public string MaXetNghiemChaLIS { get; set; }
        [Description("LIS_Ngày tiếp nhận")]
        public DateTime? NgayTiepNhan { get; set; }
        [Description("LIS_Thời gian tiếp nhận")]
        public DateTime? ThoiGianTiepNhan { get; set; }
        [Description("HIS_Thời gian chỉ định")]
        public DateTime? NgayChiDinh { get; set; }
        [Description("LIS_Thời gian có kết quả")]
        public DateTime NgayCoKetQua { get; set; }
        [Description("LIS_Thời gian xác nhận kết quả")]
        public DateTime? NgayXacNhanKetQua { get; set; }
        [Description("LIS_Thời gian in kết quả lần đầu")]
        public DateTime? NgayInKetQualanDau { get; set; }
        [Description("LIS_Kết quả")]
        public string KetQua { get; set; }
        [Description("LIS_Kết quả định lượng")]
        public string KetQuaDinhLuong { get; set; }
        [Description("LIS_Kết quả định tính")]
        public string KetQuaDinTinh { get; set; }
        [Description("LIS_Khoảng tham chiếu")]
        public string ChiSoBinhThuong { get; set; }

        [Description("LIS_Cận trên")]
        public string CanTren { get; set; }
        [Description("LIS_Cận dưới")]
        public string CanDuoi { get; set; }
        [Description("LIS_Bất thường")]
        public int BatThuong { get; set; }
        [Description("LIS_Bất thường(Bool)")]
        public bool BatThuongBool { get; set; }
        [Description("LIS_Cận trên cảnh báo")]
        public string CanTrenCanhBao { get; set; }
        [Description("LIS_Cận dưới cảnh báo")]
        public string CanDuoiCanhBao { get; set; }
        [Description("LIS_Bất thường cảnh báo")]
        public int BatThuongCanhBao { get; set; }

        [Description("HIS_Mã bệnh nhân")]
        public string MaBN { get; set; }
        [Description("HIS_Mã bệnh án/Số hồ sơ")]
        public string MaBA { get; set; }
        [Description("HIS_Nội trú (Bool)")]
        public bool NoiTru { get; set; }
        [Description("HIS_Nội trú (Char: O - I)")]
        public string NoiTruChar { get; set; }
        [Description("HIS_ID giấy tờ")]
        public string IDGiayto { get; set; }
        [Description("HIS_Mã loại dịch vụ")]
        public string MaLoaiDichVu { get; set; }
        [Description("LIS_Mã nhóm xét nghiệm")]
        public string MaNhomXetNghiem { get; set; }
        [Description("LIS_Tên nhóm xét nghiệm")]
        public string TenNhomXetNghiem { get; set; }
        [Description("HIS_Mã nhân viên chỉ định")]
        public string MaNhanVienChiDinh { get; set; }
        [Description("HIS_Mã nhân viên thực hiện")]
        public string MaNhanVienThucHien { get; set; }
        [Description("HIS_Mã BS kết luận")]
        public string MaBacSiKetLuan { get; set; }
        [Description("LIS_Kết luận")]
        public string KetLuan { get; set; }
        [Description("HIS_Tháng kế toán")]
        public string ThangKeToan { get; set; }
        [Description("HIS_Năm kế toán")]
        public string NamKeToan { get; set; }
        [Description("LIS_Tên xét nghiệm")]
        public string TenXetNghiem_Lis { get; set; }
        [Description("LIS_Tên xét nghiệm cha")]
        public string TenXetNghiemChaLIS { get; set; }
        [Description("LIS_Đơn vị tính")]
        public string DonViTinh { get; set; }
        [Description("HIS_Mã khoa CLS")]
        public string MaKhoaCLS { get; set; }
        [Description("LIS_ID máy XN")]
        public int IDMayXN { get; set; }
        [Description("LIS_User upload")]
        public string UserUpload { get; set; }
        [Description("LIS_ID BHYT (Máy XN)")]
        public string IDMayXnBHYT { get; set; }
        [Description("HIS_ID máy XN")]
        public string IDMayXNHIS { get; set; }
        [Description("LIS_Mã loại mẫu")]
        public string LIS_MaLoaiMau { get; set; }
        [Description("LIS_Tên loại mẫu")]
        public string LIS_TenLoaiMau { get; set; }
        [Description("LIS_Tình trạng mẫu")]
        public string LIS_TinhTrangMau { get; set; }
        [Description("LIS_Mã người tiếp nhận")]
        public string LIS_MaNguoiTiepNhan { get; set; }
        [Description("LIS_Người tiếp nhận")]
        public string LIS_NguoiTiepNhan { get; set; }
        [Description("LIS_Mã người lấy mẫu")]
        public string LIS_MaNguoiLayMau { get; set; }
        [Description("LIS_Người lấy mẫu")]
        public string LIS_NguoiLayMau { get; set; }
        [Description("HIS_Người lấy mẫu")]
        public string HIS_NguoiLayMau { get; set; }
        [Description("LIS_Mã người nhận mẫu")]
        public string LIS_MaNguoiNhanMau { get; set; }
        [Description("LIS_Người nhận mẫu")]
        public string LIS_NguoiNhanMau { get; set; }
        [Description("LIS_Mã người duyệt kết quả")]
        public string LIS_MaNguoiDuyetKetQua { get; set; }
        [Description("LIS_Người duyệt kết quả")]
        public string LIS_NguoiDuyetKetQua { get; set; }

        [Description("HIS_Người nhận mẫu")]
        public string HIS_NguoiNhanMau { get; set; }

        [Description("LIS_Lần in kết quả")]
        public int LIS_LanInKQ { get; set; }

        [Description("LIS_Thời gian lấy mẫu")]
        public DateTime? ThoiGianLayMau { get; set; }
        [Description("LIS_Thời gian nhận mẫu")]
        public DateTime? ThoiGianNhanMau { get; set; }

        [Description("LIS_GPB Nhận xét vi thể")]
        public string NhanXetViThe { get; set; }
        [Description("LIS_GPB Người nhập vi thể")]
        public string NguoiNhapViThe { get; set; }
        [Description("LIS_GPB Nhận xét đại thể")]
        public string NhanXetDaiThe { get; set; }
        [Description("LIS_GPB Người nhập đại thể")]
        public string NguoiNhapDaiThe { get; set; }
        [Description("LIS_GPB Bệnh phẩm ")]
        public string BenhPham { get; set; }
        [Description("LIS_GPB Marker âm tính ")]
        public string MarkerAmTinh { get; set; }
        [Description("LIS_GPB Marker dương tính ")]
        public string MarkerDuongTinh { get; set; }
        [Description("LIS_GPB Đề xuất ")]
        public string DeXuat { get; set; }
        [Description("LIS_VSNC Mã vi khuẩn ")]
        public string MaViKhuan { get; set; }
        [Description("LIS_VSNC Tên vi khuẩn ")]
        public string TenViKhuan { get; set; }
        [Description("LIS_VSNC Mã kháng sinh ")]
        public string MaKhangSinh { get; set; }
        [Description("LIS_VSNC Tên kháng sinh ")]
        public string TenKhangSinh { get; set; }
        [Description("LIS_Kết quả SRI")]
        public string KetQuaSRI { get; set; }
        [Description("LIS_Kết quả Tên kháng kháng sinh")]
        public string TenKhangKhangSinh { get; set; }
        [Description("LIS_Kết quả Kháng kháng sinh")]
        public string KetQuaKhangKhangSinh { get; set; }
        [Description("LIS_VS Kỹ thuật KSD ")]
        public string KyThuatKSD { get; set; }
        [Description("LIS_Mã XN của máy")]
        public string KetQuaMaXnMay { get; set; }
        [Description("LIS_Tên máy XN")]
        public string TenMayXn { get; set; }
        [Description("LIS_Quy trình/PPXN")]
        public string QuyTrinhPPXN { get; set; }
        [Description("LIS_Kết quả Tên: kết quả kháng kháng sinh")]
        public string TenVaKetQuaKhangKhangSinh { get; set; }
        [Description("HIS_Mã số XN của HIS")]
        public string SoTTHIS { get; set; }
        [Description("LIS_L_H_Alarm")]
        public string LowHighAlarm { get; set; }
        [Description("LIS_Sắp xếp nhóm")]
        public string SapXepNhom { get; set; }
        [Description("LIS_Sắp xếp Xét nghiệm")]
        public string SapXepXetNghiem { get; set; }

        [Description("LIS_Tên bệnh nhân")]
        public string TenBenhNhan { get; set; }
        [Description("LIS_Năm sinh")]
        public string NamSinh { get; set; }
        [Description("LIS_Giới tính")]
        public string GioiTinh { get; set; }
        [Description("LIS_Sinh nhật")]
        public DateTime SinhNhat { get; set; }
        [Description("HIS_Mã khoa chỉ định")]
        public string HISMaKhoaChiDinh { get; set; }
        [Description("LIS_Tên khoa chỉ định")]
        public string TenKhoaChiDinh { get; set; }
        [Description("HIS_Mã BS chỉ định")]
        public string HISMaBSChiDinh { get; set; }
        [Description("LIS_Tên BS chỉ định")]
        public string TenBSChiDinh { get; set; }
        [Description("LIS_Kết quả VS (Không chọn)")]
        public List<HisResultBase> lstKetQuaKhangSinh { get; set; }
        [Description("Clone data (Không chọn)")]
        public HisResultBase Copy()
        {
            return (HisResultBase)this.MemberwiseClone();
        }
        [Description("LIS_Loại xét nghiệm")]
        public string LoaiXetNghiem { get; set; }
        [Description("HIS_ID Chi tiết chỉ định")]
        public string IdChiTiet_HIS { get; set; }
        //thông tin khoa xét nghiệm
        [Description("Thông tin xác nhận của khoa")]
        public HISResultValid ThongTinXacNhanKhoa { get; set; }
        [Description("LIS_Ghi chú xét nghiệm")]
        public string GhichuXN { get; set; }
        [Description("LIS_ XN Chính")]
        public bool XNChinh { get; set; }
        [Description("LIS_Bất thường lệch (1: Dưới - 2: Trên)")]
        public int BatThuongLech { get; set; }
        [Description("LIS_Bất thường HL7 (L-N-H)")]
        public string BatThuongHL7 { get; set; }
        [Description("LIS_ID khu nhận mẫu ")]
        public string IDKhuVucNhanMau { get; set; }
        [Description("LIS_ID khu duyệt kết quả ")]
        public string IDKhuVucDuyetKetQua { get; set; }
        [Description("HIS_Tên phòng ")]
        public string TenPhong { get; set; }
        [Description("FilePDF_LIS - Base64)")]
        public string PDFBase64String { get; set; }
        [Description("FilePDF_LIS - ID")]
        public string PdfId { get; set; }
        [Description("FilePDF_LIS - Tên file HIS")]
        public string PdfTenFileHIS { get; set; }
        [Description("FilePDF_LIS - Tên file LIS")]
        public string PdfTenFileLIS { get; set; }
        [Description("FilePDF_LIS - Người ký")]
        public string PdfNguoiKy { get; set; }
        [Description("FilePDF_LIS - Lần ký")]
        public int PdfLanKy { get; set; }
        [Description("FilePDF_HIS - Report Form ID")]
        public string PdfFormID { get; set; }
        [Description("FilePDF_HIS - Mô tả")]
        public string PdfMoTa { get; set; }
        [Description("FilePDF_HIS - Số phiếu")]
        public string PdfSophieu { get; set; }
        [Description("FilePDF_LIS - Loại ký")]
        public int PdfLoaiKy { get; set; }
        [Description("FilePDF_LIS - Loại xét nghiệm")]
        public string PdfLoaiXetNghiem { get; set; }
        [Description("FilePDF_LIS - List Mã dịch vụ ký số")]
        public List<string> PdfLstIdDichVu { get; set; }
        [Description("FilePDF_HIS - Số phiếu trả kết quả")]
        public string PdfSoPhieuKetQua { get; set; }
        [Description("FilePDF_HIS - Mã bệnh nhân")]
        public string PdfMaBN { get; set; }
        [Description("FilePDF_HIS - Mã bệnh án/Số hồ sơ")]
        public string PdfMaBA { get; set; }
        [Description("FilePDF_HIS -  Id trả kết quả")]
        public string PdfIdTraKetQua { get; set; }
        [Description("FilePDF_HIS - Số phiếu chỉ định")]
        public string PdfSoPhieuYeuCau { get; set; }

    }
    public class HISResultValid
    {
        [Description("HIS_LIS_Giá trị Null ")]
        public string NullValue { get; set; }
        [Description("HIS_ Trạng thái (true,false)")]
        public bool TrangThaiXacNhanKhoa { get; set; }
        [Description("HIS_ Lý do")]
        public string LyDoBoXacNhanKhoa { get; set; }
        [Description("HIS_ ID Khoa xét nghiệm")]
        public string IDKhoaXetNghiem { get; set; }
        [Description("HIS_ Thời gian xác nhận")]
        public DateTime? ThoiGianXacNhanKhoa { get; set; }
        [Description("HIS_Người xác nhận")]
        public string NguoiXacNhanKhoa { get; set; }
        [Description("HIS_Số hồ sơ")]
        public string SoHoSo { get; set; }
        [Description("HIS_Số phiếu chỉ định")]
        public string SoPhieuChiDinh { get; set; }
    }
    public class HisLabBloodInfo
    {
    }
    public class HisParaGetList
    {
        [Description("HIS_ Id hành động trả kết quả")]
        public string ResultAction { get; set; }
        [Description("HIS_LIS_Giá trị Null ")]
        public string NullValue { get; set; }
        [Description("LIS_Mã tiếp nhận")]
        public string MaTiepNhanLIS { get; set; }
        [Description("HIS_Mã bệnh nhân")]
        public string MaBenhNhan { get; set; }
        [Description("HIS_Mã bệnh án/Số hồ sơ")]
        public string MaBenhAn { get; set; }
        [Description("HIS_ID giấy tờ")]
        public string IDGiayto { get; set; }
        [Description("HIS_Số phiếu chỉ định")]
        public string SoPhieuChiDinh { get; set; }
        [Description("HIS_ID phiếu kết quả")]
        public string IDPhieuketqua { get; set; }
        [Description("HIS_ID chỉ định dịch vụ")]
        public string IDChiDinhDichVu { get; set; }

        //[Description("HIS_ID chi tiết chỉ định dịch vụ")]
        //public string IDChiTietChiDinhDichVu { get; set; }
        [Description("HIS_ID Nơi chỉ định")]
        public string IDNoiChiDinh { get; set; }
        [Description("HIS_ID Nơi thực hiện")]
        public string IDNoiThucHien { get; set; }
        [Description("HIS_ID BS Thực hiện")]
        public string IDBSThucHien { get; set; }
        [Description("HIS_ID User Thực hiện")]
        public string IDUserThucHien { get; set; }
        [Description("HIS_ID User lấy mẫu")]
        public string IDUserLayMau { get; set; }
        [Description("LIS_ID Thời gian Thực hiện")]
        public DateTime? ThoiGianThucHien { get; set; }
        [Description("LIS_ID Thời gian lấy mẫu")]
        public DateTime? ThoiGianLayMau { get; set; }
        [Description("HIS_Ngày chỉ định")]
        public DateTime? NgayChiDinh { get; set; }
        [Description("HIS_Thời gian nhập BN")]
        public DateTime? ThoiGianNhapBN { get; set; }
        [Description("HIS_Thời gian nhận mẫu")]
        public DateTime? ThoiGianNhanMau { get; set; }
        [Description("HIS_Thời gian xác nhận")]
        public DateTime? ThoiGianXacNhan { get; set; }
        [Description("HIS_Thời gian có kết quả")]
        public DateTime? ThoiGianCoKetQua { get; set; }
        [Description("HIS_Thời gian in kết quả đầu tiên")]
        public DateTime? ThoiGianInKetQuaLanDau { get; set; }
        [Description("LIS_Ngày tiếp nhận ")]
        public DateTime? NgayTiepNhan { get; set; }
        [Description("HIS_Từ ngày chỉ định")]
        public DateTime? TimTuNgayChiDinh { get; set; }
        [Description("HIS_Đến ngày chỉ định")]
        public DateTime? TimDenNgayChiDinh { get; set; }
        [Description("HIS_Mã nhóm lấy chỉ định")]
        public string MaNhom { get; set; }
        [Description("HIS_Trạng thái định")]
        public int? TrangThai { get; set; }
        [Description("HIS_Trạng thái định (HL7)")]
        public string TrangThaiHL7 { get; set; }
        [Description("HIS_Thứ tự chỉ định")]
        public int? SoThuTu { get; set; }
        [Description("HIS_Họ tên")]
        public string HoTen { get; set; }
        [Description("LIS_Mã xét nghiệm")]
        public string MaXetNghiemLIS { get; set; }
        [Description("HIS_Mã dịch vụ")]
        public string MaDichVu { get; set; }
        [Description("HIS_Tên dịch vụ")]
        public string TenDichVu { get; set; }
        [Description("HIS_ID Chỉ định")]
        public string IDChiDinh { get; set; }
        [Description("HIS_ID Bảng kê")]
        public string IDBangKe { get; set; }
        [Description("HIS_Tham số xác định")]
        public string ParaIn { get; set; }
        [Description("HIS_Bệnh nhân nội trú")]
        public bool NoiTru { get; set; }
        [Description("HIS_Mã máy Inbarcode")]
        public string IDMayInbarcode { get; set; }
        [Description("LIS_ID Nhóm xét nghiệm")]
        public HISDataCommon.TestGroup IDNhomXN { get; set; }

        [Description("LIS_Thời gian hẹn trả KQ")]
        public DateTime? NgayHenTraKQ { get; set; }
        [Description("HIS_Tháng/năm thực hiện")]
        public string ThangNamThucHien { get; set; }
        [Description("HIS_Số lượng")]
        public int SoLuong { get; set; }
        [Description("HIS_Module")]
        public string Module { get; set; }
        [Description("LIS_ghi chú")]
        public string Ghichu { get; set; }
        [Description("HIS_Dic Mã và tên xét nghiệm")]
        public Dictionary<string, string> DicMaVaTenXetNghiem { get; set; }
        //thông tin túi máu nhap kho
        [Description("[Tủ máu] Mã phiếu nhập túi máu")]
        public string TuMau_Maphieunhaptuimau { get; set; }
        [Description("[Tủ máu] Mã túi máu")]
        public string TuMau_Matuimau { get; set; }
        [Description("[Tủ máu] Mã thành phần")]
        public string TuMau_Mathanhphan { get; set; }
        [Description("[Tủ máu] Tên thành phần")]
        public string TuMau_Tenthanhphan { get; set; }
        [Description("[Tủ máu] Thể tích túi máu")]
        public string TuMau_Thetich { get; set; }
        [Description("[Tủ máu] Số lượng")]
        public string TuMau_Soluong { get; set; }
        [Description("[Tủ máu] ABO (túi máu)")]
        public string TuMau_Nhommau { get; set; }
        [Description("[Tủ máu] Rh (túi máu)")]
        public string TuMau_Rhtuimau { get; set; }
        [Description("[Tủ máu] Người nhập kho")]
        public string TuMau_Nguoinhapkho { get; set; }
        [Description("[Tủ máu] Ngày nhập kho")]
        public string TuMau_Ngaynhapkho { get; set; }
        [Description("[Tủ máu] Ngày sản xuất(điều chế)")]
        public string TuMau_Ngaydieuche { get; set; }
        [Description("[Tủ máu] Hạn sử dung (túi máu)")]
        public string TuMau_Hansudung { get; set; }
        [Description("[Tủ máu] Mã nguồn cung cấp (ĐV bán)")]
        public string TuMau_Manguoncung { get; set; }
        [Description("[Tủ máu] Tên nguồn cung cấp")]
        public string TuMau_Tennguoncungcap { get; set; }
        [Description("HIS - ID giải phẩu bệnh")]
        public int GiaiPhauBenh { get; set; }
        [Description("LIS - Thông tin chỉ định (Không set)")]
        public HisResultBase DataTestInfo { get; set; }
    }
    public class HisConnection
    {
        public HISDataCommon.DBConnectType DbType { get; set; }
        public HISDataCommon.HisProvider HisID { get; set; }
        public string HisName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        //public string UserID { get; set; }
        public string PassWord { get; set; }
        public string PortNumber { get; set; }

        public string Internalcolumn { get; set; }
        public bool InteralByCharIndex { get; set; }
        public bool InternalContaint { get; set; }
        public bool InternalBitValue { get; set; }
        public string InternalCharValue { get; set; }
        public string InternalCharStartIndex { get; set; }
        public bool IsActive { get; set; }
        public bool DifferenceInOut { get; set; } 
        public bool NotUsePatientList { get; set; }
        public bool FindNameOnHIS { get; set; }

        //dành cho LIS
        public string LISServerName { get; set; }
        public string LISUserName { get; set; }
        public string LISPassword { get; set; }
        public string LISCallADTName { get; set; }
        public string LISDatabasename { get; set; }
        public string UserName { get; set; }
       

        public bool WriteLogToAPI = true;
    }
    public class HisFunctionID
    {
        [Category("DanhMuc")]
        [Description("DANH MỤC NHÂN VIÊN")]
        public string DanhMucNhanVien { get; } = "DanhMucNhanVien";
        [Category("DanhMuc")]
        [Description("DANH MỤC KHOA PHÒNG")]
        public string DanhMucKhoaPhong { get; } = "DanhMucKhoaPhong";
        [Category("DanhMuc")]
        [Description("DANH MỤC ĐỐI TƯỢNG")]
        public string DanhMucDoiTuong { get; } = "DanhMucDoiTuong";
        [Category("DanhMuc")]
        [Description("DANH MỤC DANH CHẨN ĐOÁN")]
        public string DanhMucChanDoan { get; } = "DanhMucChanDoan";
        [Category("DanhMuc")]
        [Description("DANH MỤC LOẠI DỊCH VỤ")]
        public string DanhMucLoaiDichVu { get; } = "DanhMucLoaiDichVu";
        [Category("DanhMuc")]
        [Description("DANH MỤC DỊCH VỤ")]
        public string DanhMucDichVu { get; } = "DanhMucDichVu";
        [Category("DanhMuc")]
        [Description("DANH MỤC MÁY XÉT NGHIỆM")]
        public string DanhMucMayXetNghiem { get; } = "DanhMucMayXetNghiem";
        [Category("DanhMuc")]
        [Description("DANH MỤC PHÒNG")]
        public string DanhMucPhong { get; } = "DanhMucPhong";
        [Category("DanhMuc")]
        [Description("DANH MỤC SINH LÝ")]
        public string DanhMucSinhLy { get; } = "DanhMucSinhLy";
        [Category("DanhMuc")]
        [Description("DANH MỤC CÔNG TY HỢP ĐỒNG")]
        public string DanhMucCongTyHopDong { get; } = "DanhMucCongTyHopDong";
        [Category("DanhMuc")]
        [Description("DANH MỤC LOẠI MẪU")]
        public string DanhMucLoaiMau { get; } = "DanhMucLoaiMau";
        [Category("ChiDinh")]
        [Description("DANH SÁCH BỆNH NHÂN CHỜ LẤY CHỈ ĐỊNH")]
        public string DanhSachCho { get; } = "DanhSachCho";
        [Category("ChiDinh")]
        [Description("THÔNG TIN BỆNH NHÂN")]
        public string ChiTietBenhNhan { get; } = "ChiTietBenhNhan";
        [Category("ChiDinh")]
        [Description("DANH SÁCH CHI TIẾT CHỈ ĐỊNH")]
        public string ChiTietChiDinh { get; } = "ChiTietChiDinh";
        [Category("ChiDinh")]
        [Description("LẤY BARCODE TỪ HIS")]
        public string LayBarcodeXetNghiem { get; } = "LayBarcodeXetNghiem";
        [Category("ChiDinh")]
        [Description("BẬT TRẠNG THÁI VỀ HIS - HL7: ORC")]
        public string BatCoTrangThaiLay { get; } = "BatCoTrangThaiLay";
        [Category("ChiDinh")]
        [Description("BẬT TRẠNG THÁI VỀ HIS - HỦY BARCODE TRUYỀN MÁU")]
        public string HuyBarcodeTruyenMau { get; } = "HuyBarcodeTruyenMau";
        [Category("ChiDinh")]
        [Description("BẬT TRẠNG THÁI VỀ HIS - CẬP NHẬT CODE CŨ")]
        public string CapNhatCodeCu { get; } = "CapNhatCodeCu";
        [Category("ChiDinh")]
        [Description("BẬT TRẠNG THÁI VỀ HIS - XÓA CHẾ PHẨM TRUYỀN MÁU")]
        public string XoaChePhamTruyenMau { get; } = "XoaChePhamTruyenMau";
        [Category("ChiDinh")]
        [Description("BẬT TRẠNG THÁI VỀ HIS - THÊM CHẾ PHẨM TRUYỀN MÁU")]
        public string ThemChePhamTruyenMau { get; } = "ThemChePhamTruyenMau";
        [Category("ChiDinh")]
        [Description("BẬT TRẠNG THÁI VỀ HIS - NHẬP KHO TÚI MÁU")]
        public string NhapKhoTuMau { get; } = "NhapKhoTuMau";
        [Category("ChiDinh")]
        [Description("HỦY KẾT QUẢ")]
        public string HuyKetQua { get; } = "HuyKetQua";
        [Category("ThongTinMau")]
        [Description("THÔNG TIN MẪU - EKIP PHẨU THUẬT")]
        public string EkipPhauThuat { get; } = "EkipPhauThuat";
        [Category("ThongTinMau")]
        [Description("THÔNG TIN MẪU - VỊ TRÍ LẤY MẪU PAP")]
        public string ViTriLayMauPap { get; } = "ViTriLayMauPap";
        [Category("ThongTinMau")]
        [Description("THÔNG TIN MẪU - VỊ TRÍ LẤY MẪU SINH THIẾT")]
        public string ViTriLayMauSinhThiet { get; } = "ViTriLayMauSinhThiet";

        [Category("TraKetQua")]
        [Description("LẤY ID LẦN TRẢ KẾT QUẢ")]
        public string LayIdPhieuTraKetQuaXetNghiem { get; } = "LayIdPhieuTraKetQuaXetNghiem";
        [Category("TraKetQua")]
        [Description("LẤY ID CHI TIẾT LẦN TRẢ KẾT QUẢ")]
        public string LayIdTraKetQuaXetNghiem { get; } = "LayIdTraKetQuaXetNghiem";
        [Category("TraKetQua_OBX")]
        [Description("UPLOAD KẾT QUẢ THƯỜNG QUY - HL7: OBX")]
        public string TraKetQuaXetNghiem { get; } = "TraKetQuaXetNghiem";
        [Category("TraKetQua_ORC")]
        [Description("UPLOAD KẾT QUẢ HL7: ORC - NTE")]
        public string TraKetQuaXetNghiemHL7ORC { get; } = "TraKetQuaXetNghiemHL7ORC";
        [Category("TraKetQua_PID")]
        [Description("UPLOAD KẾT QUẢ HL7: PID - PV1")]
        public string TraKetQuaXetNghiemHL7PID { get; } = "TraKetQuaXetNghiemHL7PID";
        [Category("TraKetQua")]
        [Description("UPLOAD KẾT QUẢ - BẬT CỜ TRẢ ĐỦ")]
        public string BatTraKetQuaXetNghiemDu { get; } = "BatTraKetQuaXetNghiemDu";

        [Category("TraKetQua")]
        [Description("UPLOAD KẾT QUẢ - VI SINH NUÔI CẤY")]
        public string TraKetQuaViSinh { get; } = "TraKetQuaViSinh";
        [Category("TraKetQua")]
        [Description("UPLOAD KẾT QUẢ - SINH HỌC PHÂN TỬ")]
        public string TraKetQuaSHPT { get; } = "TraKetQuaSHPT";
        [Category("ChiDinh")]
        [Description("CẬP NHẬT THỜI GIAN HẸN TRẢ KẾT QUẢ")]
        public string CapNhatTGHenTraKQ { get; } = "CapNhatTGHenTraKQ";
        [Category("Token")]
        [Description("LẤY TOKEN")]
        public string LayToken { get; } = "LayToken";
        [Category("TraKetQua")]
        [Description("KẾT QUẢ ANAPATH")]
        public string KetQuaAnapath { get; } = "KetQuaAnapath - SINH THIẾT";
        [Category("TraKetQua")]
        [Description("KẾT QUẢ ANAPATH - PAP")]
        public string KetQuaAnapathPAP { get; } = "KetQuaAnapathPAP";
        [Category("TraKetQua")]
        [Description("PHIẾU TRẢ KẾT QUẢ XÉT NGHIỆM")]
        public string PhieuTraKetQuaXetNghiem { get; } = "PhieuTraKetQuaXetNghiem";
        public string DanhSachChoNoiTru = "DanhSachChoNoiTru";
        public string ChiTietBenhNhanNoiTru = "ChiTietBenhNhanNoiTru";
        public string ChiTietChiDinhNoiTru = "ChiTietChiDinhNoiTru";
        public string BatCoTrangThaiLayNoiTru = "BatCoTrangThaiLayNoiTru";
        public string LayIdPhieuTraKetQuaXetNghiemNoiTru = "LayIdPhieuTraKetQuaXetNghiemNoiTru";
        public string LayIdTraKetQuaXetNghiemNoiTru = "LayIdTraKetQuaXetNghiemNoiTru";
        public string TraKetQuaXetNghiemNoiTru = "TraKetQuaXetNghiemNoiTru";
        public string BatTraKetQuaXetNghiemDuNoiTru = "BatTraKetQuaXetNghiemDuNoiTru";

    }
    public class HisFunctionConfig
    {
        public HISDataCommon.FunctionType FunctionTypeID { get; set; }
        public HISDataCommon.HisProvider HisID { get; set; }
        public string FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string FunctionParaNames { get; set; }
        public string FunctionParaValues { get; set; }
        public string FunctionValuesType { get; set; }
        public string LISColumns { get; set; }
    }
    public class HISDataColumnNames
    {


        [Description("[Danh mục] ID His")]
        public HISDataCommon.HisProvider HisID { get; set; }
        #region  TPH_His_ColumnMapping_DanhMucDichVu
        [Description("[Danh mục] Mã dịch vụ")]
        public string dmDichvuMadichvu { get; set; }  // "madichvu";
        [Description("[Danh mục] Tên dịch vụ")]
        public string dmDichvuTendichvu { get; set; }  // "Tendichvu";
        [Description("[Danh mục] Đơn vị tính")]
        public string dmDichvudonvitinh { get; set; }  // "donvitinh";
        [Description("[Danh mục] Mã dịch vụ cấp trên")]
        public string dmDichvuMaCapTren { get; set; }  // "MaCapTren";
        [Description("[Danh mục] Loại dịch vụ")]
        public string dmDichvuLoaiDichVu { get; set; }  // "LoaiDichVu";
        #endregion
        #region  TPH_His_ColumnMapping_DanhMucNhom(Loai)XetNghiem
        [Description("[Danh mục] Mã loại/nhóm xét nghiệm ")]
        public string dmLoaiXetNghiemMaLoai { get; set; }
        [Description("[Danh mục] Tên loại/nhóm xét nghiệm ")]
        public string dmLoaiXetNghiemTenLoai { get; set; }
        #endregion
        #region  TPH_His_ColumnMapping_DanhMucKhoaPhong
        [Description("[Danh mục] Mã khoa phòng/đơn vị")]
        public string dmKhoaPhongMaKhoa { get; set; }  // "makhoa";
        [Description("[Danh mục] Tên khoa phòng/đơn vị")]
        public string dmKhoaPhongTenKhoa { get; set; }  // "tenkhoa";
        [Description("[Danh mục] Khoa phòng đơn vị nội trú")]
        public string dmKhoaPhongNoiTru { get; set; }  // "nội trú";
        #endregion
        #region  TPH_His_ColumnMapping_Phong
        [Description("[Danh mục] Mã số phòng")]
        public string dmPhongMaPhong { get; set; }  // "maphong";
        [Description("[Danh mục] Tên phòng")]
        public string dmPhongTenPhong { get; set; }  // "tenphong";
        [Description("[Danh mục] Phòng - Mã khoa")]
        public string dmPhongMaKhoa { get; set; }
        #endregion
        #region TPH_His_ColumnMapping_DanhMucNhanVien
        [Description("[Danh mục] Mã nhân viên")]
        public string dmNhanVienMaNhanVien { get; set; }
        [Description("[Danh mục] Tên nhân viên")]
        public string dmNhanVienTenNhanVien { get; set; }
        #endregion
        #region TPH_His_ColumnMapping_DanhMucSinhLy
        [Description("[Danh mục] Mã sinh lý")]
        public string dmSinhLyMaSinhLy { get; set; }
        [Description("[Danh mục] Tên sinh lý")]
        public string dmSinhLyTenSinhLy { get; set; }
        #endregion       
        #region TPH_His_ColumnMapping_DanhMucLoaiMau
        [Description("[Danh mục] Mã loại mẫu")]
        public string dmLoaiMauMaLoaiMau { get; set; }
        [Description("[Danh mục] Tên loại mẫu")]
        public string dmLoaiMauTenLoaiMau { get; set; }
        #endregion
        #region TPH_His_ColumnMapping_DanhMucDoiTuongDichVu
        [Description("[Danh mục] Mã đối tượng")]
        public string dmDoiTuongDichVuMaDoiTuongDichVu { get; set; }  // "makhoa";
        [Description("[Danh mục] Tên đối tượng")]
        public string dmDoiTuongDichVuTenDoiTuongDichVu { get; set; }  // "tenkhoa";
        #endregion
        #region TPH_His_ColumnMapping_DanhMucChanDoan
        [Description("[Danh mục] Mã chẩn đoán")]
        public string dmChanDoanMaChanDoan { get; set; }  // "makhoa";
        [Description("[Danh mục] Tên chẩn đoán")]
        public string dmChanDoanTenChanDoan { get; set; }  // "tenkhoa";
        #endregion
        #region TPH_His_ColumnMapping_DanhMucCtyHopDong
        [Description("[Danh mục] Mã công ty HD")]
        public string dmMaCongTyHD { get; set; }
        [Description("[Danh mục] Tên công ty HD")]
        public string dmTenCongTyHD { get; set; }
        #endregion
        #region TPH_His_ColumnMapping_DanhMucMayXetNghiem
        [Description("[Danh mục] ID Máy xét nghiệm")]
        public string dmMayXNIdMay { get; set; }
        [Description("[Danh mục] ID máy xét nghiệm (BHYT)")]
        public string dmMayXNIdMayBHYT { get; set; }
        [Description("[Danh mục] Tên Máy xét nghiệm")]
        public string dmMayXNTenMay { get; set; }
        #endregion
        #region TPH_His_ColumnMapping_ThongTinChiDinh
        //Thông tin hành chính
        [Description("[Chỉ định] Số phiếu chỉ định")]
        public string chidinhSophieuyeucau { get; set; }  // "sophieuyeucau";
        [Description("[Chỉ định] Số phiếu chỉ định - Chi tiết")]
        public string chidinhSophieuyeucauchitiet { get; set; }  // "sophieuyeucau";
        [Description("[Chỉ định] Mã bệnh nhân")]
        public string chidinhMabenhnhan { get; set; }  // "mabenhnhan";
        [Description("[Chỉ định] Mã bệnh án/Số hồ sơ")]
        public string chidinhMabenhan { get; set; }
        [Description("[Chỉ định] Tên bệnh nhân")]
        public string chidinhTenbenhnhan { get; set; }  // "tenbenhnhan";
        [Description("[Chỉ định] Năm sinh")]
        public string chidinhNamsinh { get; set; } // "namsinh";
        [Description("[Chỉ định] Sinh nhật")]
        public string chidinhSinhnhat { get; set; } // "sinhnhat";
        [Description("[Chỉ định] Giới tính")]
        public string chidinhGioitinh { get; set; } // "gioitinh";
        [Description("[Chỉ định] Địa chỉ")]
        public string chidinhDiachi { get; set; } // "diachi";
        [Description("[Chỉ định] Mã đối tượng")]
        public string chidinhMadoituong { get; set; } // "madoituong";
        [Description("[Chỉ định] Tên đối tượng")]
        public string chidinhTendoituong { get; set; } // "tendoituong";
        [Description("[Chỉ định] Mã bác sĩ/nhân viên")]
        public string chidinhMabacsi { get; set; } // "mabacsi";
        [Description("[Chỉ định] Tên bác sĩ/nhân viên")]
        public string chidinhTenbacsi { get; set; } // "tenbacsi";
        [Description("[Chỉ định] Mã đơn vị hợp đồng")]
        public string chidinhMadvhd { get; set; }
        [Description("[Chỉ định] Tên đơn vị hợp đồng")]
        public string chidinhTendvhd { get; set; }
        [Description("[Chỉ định] Mã khoa phòng/đơn vị")]
        public string chidinhMakhoaphong { get; set; } // "makhoaphong";
        [Description("[Chỉ định] Tên khoa phòng/đơn vị")]
        public string chidinhTenkhoaphong { get; set; } // "tenkhoaphong";
        [Description("[Chỉ định] Mã chẩn đoán")]
        public string chidinhMachandoan { get; set; } // "machandoan ";
        [Description("[Chỉ định] Chẩn đoán")]
        public string chidinhChandoan { get; set; } // "chandoan";
        [Description("[Chỉ định] Ngày chỉ định")]
        public string chidinhNgaychidinh { get; set; } // "ngaychidinh";
        [Description("[Chỉ định] Thời gian chỉ định")]
        public string chidinhThoigianchidinh { get; set; } // "thoigianchidinh";
        [Description("[Chỉ định] Thời gian yêu cầu")]
        public string chidinhThoigianyeucau { get; set; } // "thoigianyeucau";
        [Description("[Chỉ định] Ngày tiếp nhận")]
        public string chidinhNgaytiepnhan { get; set; } // "ngaytiepnhan";
        [Description("[Chỉ định] Số thẻ BHYT")]
        public string chidinhSothebhyt { get; set; } // "sothebhyt";
        [Description("[Chỉ định] Số phòng")]
        public string chidinhSophong { get; set; } // "sophong";
        [Description("[Chỉ định] Số điện thoại")]
        public string chidinhSodienthoai { get; set; } // "sodienthoai";                                   
        //Thông tin dịch vụ
        [Description("[Chỉ định] Mã dịch vụ")]
        public string chidinhMadichvu { get; set; } // "madichvu";
        [Description("[Chỉ định] ID chỉ định dịch vụ")]
        public string chidinhidDichvuchidinh { get; set; } // "iddichvuchidinh";
        [Description("[Chỉ định] ID chi tiết chỉ định dịch vụ")]
        public string chidinhIdChiTietChiDinh { get; set; } // "chidinhIdChiTietChiDinh";
        [Description("[Chỉ định] ID chỉ định dịch vụ cấp trên")]
        public string chidinhidDichvuchidinhcaptren { get; set; } // "iddichvucaptren";
        [Description("[Chỉ định] Tên dịch vụ")]
        public string chidinhTendv { get; set; } // "tendv";
        //Thông tin mẫu
        [Description("[Chỉ định] Tình trạng người được lấy mẫu")]
        public string chidinhTTNguoiDuocLayMau { get; set; } // "chidinhTTNguoiDuocLayMau";
        [Description("[Chỉ định] Tình trạng mẫu")]
        public string chidinhTinhTrangMau { get; set; } // "chidinhTinhTrangMau";
        [Description("[Chỉ định] Thời gian lấy mẫu")]
        public string chidinhThoiGianLayMau { get; set; } // "chidinhThoiGianLayMau";
        [Description("[Chỉ định] Người lấy mẫu")]
        public string chidinhidNguoiLayMau { get; set; } // "chidinhidNguoiLayMau";
        [Description("[Chỉ định] Thời gian giao mẫu")]
        public string chidinhThoiGianGiaoMau { get; set; } // "chidinhThoiGianGiaoMau";
        [Description("[Chỉ định] Người giao mẫu")]
        public string chidinhNguoiGiaoMau { get; set; } // "chidinhThoiGianGiaoMau";
        [Description("[Chỉ định] Thời gian in tem")]
        public string chidinhThoiGianInTem { get; set; } // "chidinhThoiGianInTem";
        [Description("[Chỉ định] Người in tem")]
        public string chidinhNguoiInTem { get; set; } // "chidinhNguoiInTem";
        [Description("[Chỉ định] Nhóm máu")]
        public string chidinhNhomMau { get; set; } // "chidinhNhomMau";
        [Description("[Chỉ định] Rh")]
        public string chidinhRh { get; set; } // "chidinhRh";
        [Description("[Chỉ định] ID công dân")]
        public string chidinhIDCongDan { get; set; } // "chidinhIDCongDan";
        [Description("[Chỉ định] Số hộ chiếu/Passport")]
        public string chidinhSoHoChieu { get; set; } // "chidinhSoHoChieu";
        [Description("[Chỉ định] Ngày cấo hộ chiếu/Passport")]
        public string chidinhNgayCapHoChieu { get; set; } // "chidinhNgayCapHoChieu";
        [Description("[Chỉ định] Ghi chú hộ chiếu/Passport")]
        public string chidinhGhiChuHoChieu { get; set; } // "chidinhGhiChuHoChieu";
        #endregion
        #region Thông tin chỉ định của DHCanTho
        [Description("[Chỉ định] ID Đợt khám")]
        public string chidinhDotKhamID { get; set; } // "DOTKHAM_ID";
        [Description("[Chỉ định] Id Chuyên khoa")]
        public string chiDinhChuyenKhoaID { get; set; } // "CHUYENKHOA_ID";
        [Description("[Chỉ định] ID Giấy tờ")]
        public string chidinhGiayToID { get; set; } // "GIAYTO_ID";
        [Description("[Chỉ định] ID Loại chức năng CLS")]
        public string chidinhLoaiChucNangCLSID { get; set; } // "IDLOAICHUCNANGCLS";
        [Description("[Chỉ định] ID Nhóm chức năng CLS")]
        public string chidinhNhomChucNangCLSID { get; set; } // "IDNHOMCHUCNANGCLS";
        [Description("[Chỉ định] ID Bệnh nhân -> Đã bỏ chuyển qua Bệnh án/Số hồ sơ")]
        public string chidinhBNID { get; set; } // "BN_ID";
        [Description("[Chỉ định] Id Danh mục chi phí")]
        public string chidinhDMChiPhiID { get; set; } // "IDDMCHIPHI";
        [Description("[Chỉ định] Nơi cấp thẻ BHYT")]
        public string chidinhMaNoiCapTheBhyt { get; set; } // "MaNoiCapTheBhyt";
        [Description("[Chỉ định] Nơi đăng ký thẻ BHYT")]
        public string chidinhMaNoiDangKyTheBhyt { get; set; } // "MaNoiDangKyTheBhyt";
        [Description("[Chỉ định] Id Bảng kê")]
        public string chidinhIdchidinh { get; set; } // "ChiDinhID";
        [Description("[Chỉ định] Ngày nhập viện")]
        public string chidinhNgaynhapvien { get; set; }
        [Description("[Chỉ định] Ngày vào viện")]
        public string chidinhNgayvaovien { get; set; }
        [Description("[Chỉ định] Mã sinh lý")]
        public string chidinhMasinhly { get; set; }
        [Description("[Chỉ định] Tên sinh lý")]
        public string chidinhTensinhly { get; set; }
        #endregion
        #region Thông tin chỉ định của DH Hospital
        [Description("[Chỉ định] Mã loại dịch vụ")]
        public string chidinhMaloai { get; set; } // "Mã loại dịch vụ";
        [Description("[Chỉ định] Mã nhân viên chỉ định")]
        public string chiDinhManvChidinh { get; set; } // "Mã nhân viên chỉ định";
        [Description("[Chỉ định] Tháng kế toán")]
        public string chidinhThangkt { get; set; } // "Tháng kế toán";
        [Description("[Chỉ định] Năm kế toán")]
        public string chidinhNamkt { get; set; } // "Năm kế toán";
        [Description("[Chỉ định] Tình trạng [True: cấp cứu False: bình thường]")]
        public string chidinhTinhTrang { get; set; } // "Tình trạng bệnh nhân. True: cấp cứu False: bình thường";
        [Description("[Chỉ định] Buồng")]
        public string chidinhBuong { get; set; }
        [Description("[Chỉ định] Giường")]
        public string chidinhGiuong { get; set; }
        [Description("[Chỉ định] Đóng tiền")]
        public string chidinhDongTien { get; set; }
        [Description("[Chỉ định] Trạng thái chỉ định (0-1-2)")]
        public string chidinhTrangThaiChiDinh { get; set; }
        [Description("[Chỉ định] Trạng thái phiếu (S-P-T)")]
        public string chidinhTrangThaiPhieu { get; set; }
        [Description("[Chỉ định] Trạng thái kết quả (S-P-T)")]
        public string chidinhTrangThaiKetQua { get; set; }
        [Description("[Chỉ định] Ngoại trú - Nội trú (0-1)")]
        public string chidinhNoitru { get; set; }
        [Description("[Chỉ định] Ngoại trú - Nội trú (O-I)")]
        public string chidinhNoitruchu { get; set; }
        [Description("[Kết quả] Mã phiếu trả kết quả")]
        public string ketquaMaPhieuKetQua { get; set; }
        [Description("[Kết quả] ID chi tiết kết quả")]
        public string ketquaIDChiTietKetQua { get; set; }
        [Description("[Chỉ định] Barcode XN")]
        public string chidinhBarcodexn { get; set; }
        [Description("[Chỉ định] Mã phòng")]
        public string chidinhMaphong { get; set; }
        [Description("[Chỉ định] Tên phòng")]
        public string chidinhTenphong { get; set; }
        [Description("[Chỉ định] Ngày hết hạn BHYT")]
        public string chidinhnNgayhethanbhy { get; set; }
        [Description("[Chỉ định] Khám sức khỏe")]
        public string chidinhKhamsuckhoe { get; set; }
        [Description("[Chỉ định] Nơi công tác")]
        public string chidinhNoicongtac { get; set; }
        [Description("[Chỉ định] Bệnh kèm theo")]
        public string chidinhBenhkemtheo { get; set; }
        [Description("[Chỉ định] Mã khoa hiện thời")]
        public string chidinhMakhoahienthoi { get; set; }
        [Description("[Chỉ định] Tên khoa hiện thời")]
        public string chidinhTenkhoahienthoi { get; set; }
        [Description("[Chỉ định] Số lượng")]
        public string chidinhSoluong { get; set; }
        [Description("[Chỉ định] LISCode")]
        public string chidinhLISCode { get; set; }
        [Description("[Chỉ định] Ưu tiên")]
        public string chidinhUutien { get; set; }
        [Description("[Chỉ định] Mã loại mẫu")]
        public string chidinhMaLoaiMau { get; set; }
        [Description("[Chỉ định] Tên loại mẫu")]
        public string chidinhTenLoaiMau { get; set; }
        [Description("[Chỉ định] Tên BS lấy mẫu thủ thuật")]
        public string chidinhThuthuatBacsimochinh { get; set; }
        [Description("[Chỉ định] Thời gian lấy mẫu thủ thuật")]
        public string chidinhThuthuatThoigianlaymau { get; set; }
        [Description("[Chỉ định] VT mẫu PAP (Cổ trong)")]
        public string chidinhVitrimauCotrong { get; set; }
        [Description("[Chỉ định] VT mẫu PAP (Cổ ngoài)")]
        public string chidinhVitrimauCongoai { get; set; }
        [Description("[Chỉ định] VT mẫu PAP (Âm đạo)")]
        public string chidinhVitrimauAmdao { get; set; }
        [Description("[Chỉ định] VT mẫu Sinh thiết")]
        public string chidinhVitrimausinhthiet { get; set; }
        //thông tin túi máu nhap kho
        [Description("[Tủ máu] Mã phiếu nhập túi máu")]
        public string tumauMaphieunhaptuimau { get; set; }
        [Description("[Tủ máu] Mã túi máu")]
        public string tumauMatuimau { get; set; }
        [Description("[Tủ máu] Mã thành phần")]
        public string tumauMathanhphan { get; set; }
        [Description("[Tủ máu] Tên thành phần")]
        public string tumauTenthanhphan { get; set; }
        [Description("[Tủ máu] Thể tích túi máu")]
        public string tumauThetich { get; set; }
        [Description("[Tủ máu] Số lượng")]
        public string tumauSoluong { get; set; }
        [Description("[Tủ máu] ABO (túi máu)")]
        public string tumauNhommau { get; set; }
        [Description("[Tủ máu] Rh (túi máu)")]
        public string tumauRhtuimau { get; set; }
        [Description("[Tủ máu] Người nhập kho")]
        public string tumauNguoinhapkho { get; set; }
        [Description("[Tủ máu] Ngày nhập kho")]
        public string tumauNgaynhapkho { get; set; }
        [Description("[Tủ máu] Ngày sản xuất(điều chế)")]
        public string tumauNgaydieuche { get; set; }
        [Description("[Tủ máu] Hạn sử dung (túi máu)")]
        public string tumauHansudung { get; set; }
        [Description("[Tủ máu] Mã nguồn cung cấp (ĐV bán)")]
        public string tumauManguoncung { get; set; }
        [Description("[Tủ máu] Tên nguồn cung cấp")]
        public string tumauTennguoncungcap { get; set; }
        #endregion
    }
}