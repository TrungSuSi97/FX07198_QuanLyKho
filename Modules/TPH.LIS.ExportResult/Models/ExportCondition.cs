using System;
using System.Collections.Generic;
using TPH.LIS.ExportResult.Constants;
using static TPH.LIS.Common.TestType;

namespace TPH.LIS.ExportResult.Models
{
    public class ExportCondition
    {
        public string ServerName { get; set; }
        public EnumThoiGianXuat ThoiGianXuat { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public List<string> KhuVuc { get; set; }
        public List<string> KhoaPhong { get; set; }
        public List<string> DoiTuong { get; set; }
        public List<string> BSChiDinh { get; set; }
        public List<string> NguonNhap { get; set; }
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
        public bool XetNghiemChuaCoKetQua { get; set; }
        public EnumDieuKienXetNghiem LoaiDichVu { get; set; }
        public bool KiemTraPhanQuyenKhuVuc { get; set; }
        public bool KiemTraPhanQuyenBoPhan { get; set; }
        public bool KiemTraPhanQuyenNhom { get; set; }
        public string UserKiemTraPhanQuyen { get; set; }
        public List<EnumTestType> LoaiXetNghiem { get; set; }
        public bool XuatTheoTen { get; set; }
        public List<string> SumColumns { get; set; }
        public List<string> MaViKhuan { get; set; }
        public List<string> MaLoaiMau { get; set; }
    }
}
