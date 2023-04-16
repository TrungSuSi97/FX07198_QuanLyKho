using System;
using System.Collections.Generic;
using TPH.LIS.Statistic.Constants;

namespace TPH.LIS.Statistic.Models
{
    public class NormalStatisticCondit
    {
        public string ServerName { get; set; }
        public EnumThoiGianThongKe ThoiGianThongKe { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public List<string> KhuVuc { get; set; }
        public List<string> KhoaPhong { get; set; }
        public List<string> DoiTuong { get; set; }
        public List<string> BSChiDinh { get; set; }
        public List<string> NhanVienNhapThongTin { get; set; }
        public List<string> NguonNhap { get; set; }
        public List<string> NhanVienNhapChiDinh { get; set; }
        public List<string> NhanVienInKetQua { get; set; }
        public List<string> NhanVienXacNhanKetQua { get; set; }
        public List<string> BoPhanXetNghiem { get; set; }
        public List<string> NhomXetNghiem { get; set; }
        public List<string> XetNghiem { get; set; }
        public List<string> ProfileXetNghiem { get; set; }
        public List<string> MayXetNghiem { get; set; }
        public string KetQua { get; set; }
        public string GhiChu { get; set; }
        public bool XetNghiemDaXacNhan { get; set; }
        public bool XetNghiemCoKetQua { get; set; }
        public EnumDieuKienXetNghiem LoaiXetNghiem { get; set; }
        public bool KiemTraPhanQuyenKhuVuc { get; set; }
        public bool KiemTraPhanQuyenBoPhan { get; set; }
        public bool KiemTraPhanQuyenNhom { get; set; }
        public string UserKiemTraPhanQuyen { get; set; }
        public List<string> SumColumns { get; set; }
    }
    public class StatisticsCashierCondition
    {
        public string ThuNgan { get; set; }
        public string MayTinhNhap { get; set; }
        public DateTime NgayThuTien { get; set; }

        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
    }
}
