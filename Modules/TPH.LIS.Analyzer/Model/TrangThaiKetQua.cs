using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.Analyzer.Model
{
    public class TrangThaiKetQua
    {
        public string MaXN { get; set; }
        public string MaTiepNhan { get; set; }
        public string TrangThai { get; set; }
        public string Ketqua { get; set; }
        public bool XacNhanKQ { get; set; }
        public DateTime? ThoiGianNhapKQ { get; set; }
        public string DinhTinhCanhBao { get; set; }
        public string KetQuaDinhLuong { get; set; }
        public float? NguongTren { get; set; }
        public float? NguongDuoi { get; set; }
        public string csbt { get; set; }
        public string DonVi { get; set; }
        public string DKDanhGia { get; set; }
        public string KetQuaDinhLuongGen { get; set; }
        public string KetQuaDinhTinhGen { get; set; }
        public int? LamTron { get; set; }
        public float? CanTrenCanhBao { get; set; }
        public float? CanDuoiCanhBao { get; set; }
        public string GioiHanCanhBao { get; set; }
        public float Hesoquidoi { get; set; } = 0;

        public string Donviquidoi { get; set; }

        public string Csbtquidoi { get; set; }

        public int Lamtronsauquidoi { get; set; } = 2;
    }
    public class ThongTinHienTaiCuaXetNghiem
    {
        public string MaTiepNhan { get; set; }
        public string MaXn { get; set; }
        public float? CanTren { get; set; }
        public float? CanDuoi { get; set; }
        public int TrangThai { get; set; }
        public string DieuKienBatThuong { get; set; }
        public string DVTinh { get; set; }
        public int? LamTron { get; set; }
        public string CSBinhThuong { get; set; }
        public string IDMay { get; set; }
        public string ModuleName { get; set; }
        public bool ToolAuto { get; set; }
        public float? CanDuoiCanhBao { get; set; }
        public float? CanTrenCanhBao { get; set; }
        public string GioiHanCanhBao { get; set; }
        public string DieuKienCanhBaoDinhTinh { get; set; }
        public float Hesoquidoi { get; set; }
        public int Lamtronsauquidoi { get; set; }
        public string Donviquidoi { get; set; }
        public string Csbtquidoi { get; set; }
    }
}
