using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Data.HIS.Models.VNPT
{
    // Define the classes that match the structure of the JSON data
    public class XetNghiemVNPT
    {
        public int maXetNghiem { get; set; }
        public string tenXetNghiem { get; set; }
        public LoaiXetNghiemVNPT loaiXetNghiem { get; set; }
    }
    public class ChiDinhXetNghiemVNPT_LIS
    {
        public string dvtt { get; set; }
        public string benhPham { get; set; }
        public int coBHYT { get; set; }
        public int coKetQua { get; set; }
        public int daThanhToan { get; set; }
        public int soLuong { get; set; }
        public int trangThai { get; set; }
        public string soPhieuXetNghiem { get; set; }
        public int soVaoVien { get; set; }
        public int maLoaiXetNghiem { get; set; }
        public string tenLoai { get; set; }
        public int maXetNghiem { get; set; }
        public string tenXetNghiem { get; set; }
    }
    public class ChiDinhXetNghiemVNPT
    {
        public string dvtt { get; set; }
        public string benhPham { get; set; }
        public int coBHYT { get; set; }
        public int coKetQua { get; set; }
        public int daThanhToan { get; set; }
        public int soLuong { get; set; }
        public int trangThai { get; set; }
        public string soPhieuXetNghiem { get; set; }
        public int soVaoVien { get; set; }
        public LoaiXetNghiemVNPT loaiXetNghiem { get; set; }
        public XetNghiemVNPT xetNghiem { get; set; }
    }
    public class BacSiChiDinh
    {
        public int maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public PhongBan phongBan { get; set; }
        public ChucDanh chucDanh { get; set; }
    }

    public class PhongBan
    {
        public int maPhongBan { get; set; }
        public string tenPhongBan { get; set; }
        public string maKhoaCB { get; set; }
    }

    public class ChucDanh
    {
        public int maChucDanh { get; set; }
        public string tenChucDanh { get; set; }
        public string moTaChucDanh { get; set; }
    }

    public class PhongChiDinh
    {
        public int maPhongBenh { get; set; }
        public string tenPhongbenh { get; set; }
        public PhongBan phongBan { get; set; }
    }

    public class BenhNhan
    {
        public int maBenhNhan { get; set; }
        public string tenBenhNhan { get; set; }
        public string dvtt { get; set; }
        public BacSiChiDinh bacSiChiDinh { get; set; }
        public int? phongXetNghiem { get; set; }
        public string buong { get; set; }
        public string giuong { get; set; }
        public int capCuu { get; set; }
        public string chanDoan { get; set; }
        public int coBHYT { get; set; }
        public string diaChi { get; set; }
        public string gioiTinh { get; set; }
        public int namSinh { get; set; }
        public string ngaySinh { get; set; }
        public string ngayTao { get; set; }
        public string phanHe { get; set; }
        public PhongChiDinh phongChiDinh { get; set; }
        public string soDienThoai { get; set; }
        public string soPhieu { get; set; }
        public string soTheBHYT { get; set; }
        public int soVaoVien { get; set; }
        public int soVaoVienDt { get; set; }
        public string stt { get; set; }
        public int sttHangNgay { get; set; }
        public int tuoi { get; set; }
        public string ngayChiDinh { get; set; }
    }
    public class BenhNhanForLIS
    {
        public int maBenhNhan { get; set; }
        public string tenBenhNhan { get; set; }
        public string dvtt { get; set; }
        //Bác sĩ chỉ định
        public int maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public string maKhoaCB { get; set; }
        public int maChucDanh { get; set; }
        public string tenChucDanh { get; set; }
        public string moTaChucDanh { get; set; }

        public int? phongXetNghiem { get; set; }
        public string buong { get; set; }
        public string giuong { get; set; }
        public int capCuu { get; set; }
        public string chanDoan { get; set; }
        public int coBHYT { get; set; }
        public string diaChi { get; set; }
        public string gioiTinh { get; set; }
        public int namSinh { get; set; }
        public string ngaySinh { get; set; }
        public string ngayTao { get; set; }
        public string phanHe { get; set; }
        //Phòng chỉ định
        public int maPhongBenh { get; set; }
        public string tenPhongbenh { get; set; }
        public int maPhongbanchidinh { get; set; }
        public string tenPhongbanchidinh { get; set; }

        public string soDienThoai { get; set; }
        public string soPhieu { get; set; }
        public string soTheBHYT { get; set; }
        public int soVaoVien { get; set; }
        public int soVaoVienDt { get; set; }
        public string stt { get; set; }
        public int sttHangNgay { get; set; }
        public int tuoi { get; set; }
        public string ngayChiDinh { get; set; }
    }

    public class LoaiXetNghiemVNPT
    {
        public int maLoaiXetNghiem { get; set; }
        public string dvtt { get; set; }
        public string tenLoai { get; set; }
        public string moTa { get; set; }
        public int hoatDong { get; set; }
    }

    public class DanhMucXetNghiemVNPT
    {
        public int maXetNghiem { get; set; }
        public string tenXetNghiem { get; set; }
        public string maDonVi { get; set; }
        public object canDuoiNam { get; set; }
        public object canDuoiNu { get; set; }
        public object canTrenNam { get; set; }
        public object canTrenNu { get; set; }
        public int capXetNghiem { get; set; }
        public object csbtNam { get; set; }
        public object csbtNu { get; set; }
        public string donViNghiepVu { get; set; }
        public string dvt { get; set; }
        public string maXetNghiemCha { get; set; }
        public string maXetNghiemMay { get; set; }
        public int sapXep { get; set; }
        public int maLienThongDMDC { get; set; }
        public int giaThang3 { get; set; }
        public int giaThang7 { get; set; }
        public int giaThang3KBHYT { get; set; }
        public int giaThang7KBHYT { get; set; }
        public string maDichVuKyThuatDMDC { get; set; }
        public int maLoaiXetNghiem { get; set; }
        public LoaiXetNghiemVNPT loaiXetNghiem { get; set; }
    }
    public class DanhMucXetNghiemVNPTForLIS
    {
        public int maXetNghiem { get; set; }
        public string tenXetNghiem { get; set; }
        public string maDonVi { get; set; }
        public object canDuoiNam { get; set; }
        public object canDuoiNu { get; set; }
        public object canTrenNam { get; set; }
        public object canTrenNu { get; set; }
        public int capXetNghiem { get; set; }
        public object csbtNam { get; set; }
        public object csbtNu { get; set; }
        public string donViNghiepVu { get; set; }
        public string dvt { get; set; }
        public string maXetNghiemCha { get; set; }
        public string maXetNghiemMay { get; set; }
        public int sapXep { get; set; }
        public int maLienThongDMDC { get; set; }
        public int giaThang3 { get; set; }
        public int giaThang7 { get; set; }
        public int giaThang3KBHYT { get; set; }
        public int giaThang7KBHYT { get; set; }
        public string maDichVuKyThuatDMDC { get; set; }
        public int maLoaiXetNghiem { get; set; }
        public string dvtt { get; set; }
        public string tenLoai { get; set; }
        public string moTa { get; set; }
        public int hoatDong { get; set; }
    }
}
