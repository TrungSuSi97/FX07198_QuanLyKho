using System;
using System.ComponentModel;
using TPH.Data.HIS.HISDataCommon;

namespace TPH.LIS.Patient.Model
{
    public class ChiDinhHISInfo
    {
        public bool LisAutoAdd = false;
        public bool LayMaCapTren = false;
        public string SoPhieuChiDinh { get; set; }
        public string MaBN { get; set; }
        public string IDDichVuChiDinh { get; set; }
        public string IdChiTiet { get; set; }
        public string TestCode { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
        public string NormalRange { get; set; }
        public string CanTren { get; set; }
        public string CanDuoi { get; set; }

        public string NormalRangeWarning { get; set; }
        public string CanTrenWarning { get; set; }
        public string CanDuoiWarning { get; set; }

        public bool Abnormal { get; set; }
        public bool AbnormalWarning { get; set; }
        public bool UPD { get; set; }
        public string ResultQualitative { get; set; }
        public string ResultQuantitative { get; set; }
        public string Unit { get; set; }
        public string Machine { get; set; }
        public DateTime DateTimeResult { get; set; }
        public string Modules { get; set; }
        public int? STT { get; set; }
        /// <summary>
        /// Trạng thái mẫu: 0: Chưa lấy - 1: Đã lấy - 2: Đã nhận - 3: Hủy nhận
        /// </summary>
        public string TrangThaiMau { get; set; }
        public string KetLuan { get; set; }
        public string BSKetLuan { get; set; }
        public string Barcode { get; set; }
        public string SoPKQ { get; set; }
        public string User { get; set; }
        public string MaXN { get; set; }
        public string MaNhomXN { get; set; }
        public string MaXN_His { get; set; }
        public string MaXNCha_His { get; set; }
        public string TenXN_His { get; set; }
        public string MaXnChaLIS { get; set; }
        public string TenXNChaLis { get; set; }
        public string MaLoaiXN_His { get; set; }
        public string Khuvucnhanid { get; set; }
        public string Khuvucguiid { get; set; }
        public DateTime? Thoigiangui { get; set; }
        public string Nguoigui { get; set; }
        public string Khuvucthuchienid { get; set; }
        public DateTime? Thoigiannhan { get; set; }
        public DateTime? Thoigianinlandau { get; set; }
        public DateTime? Thoigiantiepnhan { get; set; }
        public string Idloaichucnangcls { get; set; }
        public string Idnhomchucnangcls { get; set; }
        public string Iddmchiphi { get; set; }
        public string Bangkeid { get; set; }
        public string IDBenh { get; set; }

        string MaLoaiDichVu { get; set; }
        public string Namkt { get; set; }
        public string Thangkt { get; set; }
        public string MaNhanVienChiDinh { get; set; }
        public string MaNhanVienThucHien { get; set; }
        public bool DaXacNhan { get; set; }
        public string IDMayXn { get; set; }
        public string IDMayXnBHYT { get; set; }
        public string IDMayXnHIS { get; set; }
        public int LanUpload { get; set; }
        public bool DaInKQ { get; set; }
        public string MaTiepNhanLis { get; set; }
        public string MaBSChiDinh { get; set; }
        public string TenBSChiDinh { get; set; }
        public string MaKhoaChiDinh { get; set; }
        public string TenKhoaChiDinh { get; set; }
        public string MaKhoaHienThoi { get; set; }
        public string TenKhoaHienThoi { get; set; }
        public DateTime? NgayHetHanBHYT { get; set; }
        public string BenhKemTheo { get; set; }
        public DateTime? Thoigianxacnhan { get; set; }
        public string NhomMau { get; set; }
        public string Rh { get; set; }

        public string TTNguoiDuocLayMau { get; set; }
        public string TinhTrangMau { get; set; }
        public DateTime? ThoiGianLayMau { get; set; }
        public string NguoiLayMau { get; set; }

        public DateTime? ThoiGianGiaoMau { get; set; }
        public string NguoiGiaoMau { get; set; }
        public DateTime? NgayNhapVien { get; set; }
        public DateTime? TgVaovien { get; set; }
        public DateTime? ThoiGianInTem { get; set; }
        public string NguoiInTem { get; set; }
        public string MaXNMay { get; set; }
        public string TenMayXN { get; set; }
        public string QuyTrinhPPXN { get; set; }
        public string LowHighAlarm { get; set; }
        public string LoaiXetNghiem { get; set; }

        [Description("HIS_ Trạng thái (0,1)")]
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
        [Description("LIS_Thời gian nhận mẫu")]
        public DateTime? ThoiGianNhanMau { get; set; }
        [Description("LIS_Người nhận mẫu")]
        public string NguoiNhanMau { get; set; }
        [Description("HIS_Người lấy mẫu")]
        public string NguoiLayMauHIS { get; set; }
        [Description("HIS_Người nhận mẫu")]
        public string NguoiNhanMauHIS { get; set; }
        [Description("LIS_Lần in của xét nghiệm")]
        public int LanInCuaXN { get; set; }
        public string Chandoan { get; set; }
        public string SapXepXetNghiem { get; set; }
        public string SapXepNhom { get; set; }
        public int IDLoaiXetNghiem { get; set; }
        public int SoLuong { get; set; }
        public string Pclaymau { get; set; }
        public bool Laymaukhitiepnhan { get; set; }
        public int Soluong { get; set; } = 1;
        public string Idkhulaymau { get; set; }
        public int Solan { get; set; } = 1;
        public string Lydo { get; set; }
        public string GhiChuXN { get; set; }
        public bool XNChinh { get; set; }
        public int AbnormalFlag { get; set; }
        public string MaNguoiNhanMau { get; set; }
        public string MaNguoiLayMau { get; set; }
        public string MaNguoiTiepNhan { get; set; }
        public string NguoiTiepNhan { get; set; }
        public string NguoiDuyetKetQua { get; set; }
        public string MaNguoiDuyetKetQua { get; set; }
        public int Banlaymau { get; set; }
        public string TenNhomXetNghiem { get; set; }
        public string TenLoaiMau { get; set; }
        public string MaLoaiMau { get; set; } 
        public string Maloaimauhis { get; set; }
        public string Tenloaimauhis { get; set; }

        public ChiDinhHISInfo CopyHISInfo()
        {
            return (ChiDinhHISInfo)this.MemberwiseClone();
        }
    }
}
