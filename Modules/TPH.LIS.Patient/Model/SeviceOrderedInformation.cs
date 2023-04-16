using System;

namespace TPH.LIS.Patient.Model
{
    public class SeviceOrderedInformation
    {
        public bool isChecked { get; set; }
        public bool chon { get; set; }
        public int stt { get; set; }
        public int SapXep { get; set; }
        public int ThuTuIn { get; set; }
        public string MaTiepNhan { get; set; }
        public string MaBenhNhan { get; set; }
        public string SoBHYT { get; set; }
        public DateTime? NgayHetHanBHYT { get; set; }
        public string TenBenhNhan { get; set; }
        public int NamSinh { get; set; }
        public DateTime? SinhNhat { get; set; }
        public bool CoNgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public DateTime ThoiGianNhap { get; set; }
        public string UserNhap { get; set; }
        public string MaDoiTuongDichVu { get; set; }
        public string TenDoiTuongDichVu { get; set; }
        public string SoNha { get; set; }
        public string PhuongXa { get; set; }
        public string MaHuyen { get; set; }
        public string MaTinh { get; set; }
        public string DiaChi { get; set; }
        public string RSoPhieuYeuCau { get; set; }
        public string MaChiDinh { get; set; }
        public string TenChiDinh { get; set; }
        public string MaNhomChiDinh { get; set; }
        public string TenNhomChiDinh { get; set; }
        public string MaPhanLoai { get; set; }
        public string TenPhanLoai { get; set; }
        public int ThuTuPhanLoai { get; set; }
        public double GiaRieng { get; set; }
        public double GiaBenhNhan { get; set; }
        public bool DaKkoa { get; set; }
        public string MaProfile { get; set; }
        public bool ChiDinhCha { get; set; }
        public string LoaiMau { get; set; }
        public double TienCong { get; set; }
        public bool DaThuTien { get; set; }
        public int SoLuong { get; set; }
        public string IDBienLai { get; set; }
        public string DonViTinh { get; set; }
        public string KetQua { get; set; }
        public int Flat { get; set; }
        public string SDT { get; set; }
        public string Seq { get; set; }
        public int LoaiXetNghiem { get; set; }
        public string DoiTacNhanMauXN { get; set; }
        public bool XacNhanKQ { get; internal set; }
        public DateTime? ThoiGianInKQ { get; internal set; }
        public DateTime? ThoiGianNhanMau { get; internal set; }
        public DateTime? ThoiGianLayMau { get; internal set; }
        public DateTime? ThoiGianNhapKQ { get; internal set; }
        public bool DaCoKQ { get; internal set; }
        public bool MauGui { get; internal set; }
        public string MaCapTren { get; internal set; }
        public string KhuDieuTri { get; set; }
        public string TenKhoa { get; set; }
        public string TenPhong { get; set; }
        public string TenBSChiDinh { get; set; }
    }
}
