using System;

namespace TPH.HIS.WebAPI.Models.HisReponses
{
    public class ChiDinhBenhNhan
    {
        public int SoPhieuYeuCau { get; set; }
        public int? BarcodeXN { get; set; }
        public int MaBenhNhan { get; set; }
        public int SoHoSo { get; set; }
        public string TenBenhNhan { get; set; }
        public int NamSinh { get; set; }
        public DateTime SinhNhat { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public int MaDoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public string MaBacSi { get; set; }
        public string TenBacSi { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string MaChanDoan { get; set; }
        public string ChanDoan { get; set; }
        public DateTime NgayChiDinh { get; set; }
        public string SoTheBhyt { get; set; }
        public DateTime? NgayHetHanBHY { get; set; }
        public int SoPhong { get; set; }
        public int SoGiuong { get; set; }
        public string ABO { get; set; }
        public string RH { get; set; }
        public string MaKhoaHienThoi { get; set; }
        public string TenKhoaHienThoi { get; set; }
        public string IdDichVuChiDinh { get; set; }
        public string MaDichVu { get; set; }
        public string MaDichVuCha { get; set; }
        public string TenDV { get; set; }
        public int? SoLuong { get; set; }
        public int Trangthai { get; set; }
        public string Macongty { get; set; }
        public string Tencongty { get; set; }
        public bool khamsuckhoe { get; set; }
        public string noicongtac { get; set; }
        public string benhkemtheo { get; set; }
        public int UuTien { get; set; }
    }
}
