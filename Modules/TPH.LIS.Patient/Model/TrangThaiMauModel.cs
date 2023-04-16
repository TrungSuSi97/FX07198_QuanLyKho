using System;
using System.Collections.Generic;
using TPH.LIS.Common;
using TPH.LIS.User.Enum;

namespace TPH.LIS.Patient.Model
{
    public class KiemSoatChayMau
    {
        public string MaNguoiDung { get; set; }
        public List<string> DanhSachCode = new List<string>();
        public DateTime TGGianBatDau = DateTime.Now;
        public DateTime TGKhoa = DateTime.Now;
        public bool DangKhoa = false;
    }
    public class LayMauInfo
    {
        public string MaTiepNhan { get; set; }
        public enumThucHien TrangThai { get; set; }
        public string MaNhomLoaiMau { get; set; }
        public string MaKhoaPhong { get; set; }
        public string NguoiThucHien { get; set; }
        public string Pcthuchien { get; set; }
        public bool CheckXacNhanHis { get; set; }
        public string Maxn { get; set; }
        public string IDKhuLayMau { get; set; }
        public DateTime ThoiGianLayMau { get; set; }
        public int LoaiXetNghiem { get; set; }
        public int IdLayLoaiMau { get; set; }
        public int BanLayMau { get; set; }
        public string MaCapTren { get; set; }
        public string ProfileId { get; set; }
        public string NoiSinh { get; set; }
    }
    public class NhanMauInfo
    {
        public string MaTiepNhan { get; set; }
        public string NguoiThucHien { get; set; }
        public string NguoiThucHienNhanMau { get; set; }
        public string Pcthuchien { get; set; }
        public enumThucHien TrangThaiNhan { get; set; }
        public string LyDoTuChoi { get; set; }
        public string TinhTrangMau { get; set; }
        public string MaLoaiMau { get; set; }
        public bool CheckXacNhanHis { get; set; }
        public string Maxn { get; set; }
        public bool DeleteOrder { get; set; }
        public DateTime ThoiGianNhanMau { get; set; }
        public string MaLoaiMauNhan { get; set; }
        public int LoaiXetNghiem { get; set; }
        public int IdLayLoaiMau { get; set; }
        public string MaCapTren { get; set; }
        public string ProfileId { get; set; }
        public string KhuThucHienID { get; set; }
        public string MaBenhPhamGui { get; set; }
    }
    public class TuChoiMauInfo
    {
        public string MaTiepNhan { get; set; }
        public string NguoiThucHien { get; set; }
        public string Pcthuchien { get; set; }
        public bool TuChoi { get; set; }
        public string LyDoTuChoi { get; set; }
        public string MaLoaiMau { get; set; }
        public string Maxn { get; set; }
        public int LoaiXetNghiem { get; set; }
        public DateTime? ThoiGianThucHien { get; set; }
        public int IdLayLoaiMau { get; set; }
        public string MaCapTren { get; set; }
        public string ProfileId { get; set; }

    }
    public class CapNhatThaoTacMau
    {
        public string Matiepnhan { get; set; }
        public string Maxn { get; set; }
        public DateTime Tgcu { get; set; }
        public DateTime Tgmoi { get; set; }
        public string Nguoithuchiencu { get; set; }
        public string Pcthuchiencu { get; set; }
        public string Nguoithuchienmoi { get; set; }
        public string Pcthuchienmoi { get; set; }
        public int Idthaotac { get; set; }
    }

    public class DieuKienTimDanhSachBNTheoTrangThaiMau
    {
        public DateTime? tungay { get; set; }
        public DateTime? denngay { get; set; }
        public string maDoiTuong { get; set; }
        public string tenBN { get; set; }
        public string barcode { get; set; }
        public string maBN { get; set; }
        public string sdt { get; set; }
        public string idCongDan { get; set; }
        public enumThucHien daNhanMau = enumThucHien.TatCa;
        public enumThucHien daLayMauTatCa = enumThucHien.TatCa;
        public enumThucHien daTraKQ = enumThucHien.TatCa;
        public enumThucHien daDuKQ = enumThucHien.TatCa;
        public enumThucHien dainKQ = enumThucHien.TatCa;
        public enumThucHien daXacNhanKQ = enumThucHien.TatCa;
        public ServiceType loaiDichVu = ServiceType.All;
        public enumThucHien coLayMau = enumThucHien.TatCa;
        public enumThucHien daNhanMauTatCa = enumThucHien.TatCa;
        public enumThucHien daTuChoiMau = enumThucHien.TatCa;
        public enumThucHien daHoanDichVu = enumThucHien.TatCa;
        public enumTacVu tacvu = enumTacVu.TatCa;
        public string pcName = "";
        public string sophieuHis = "";
        public string nguoiLayMau = "";
        public string nguoiNhanMau = "";
        public string maKhuVuc = "";
        public List<string> quyennhomXn;
        public bool CheckDaLayMau = false;
        public bool CheckSoHoSo = false;
        public int IDChuyenMau = 0;
        public string SampleCode = string.Empty;
    }

    public class TaoMoiChuyenMau
    {
        public string PCName { get; set; }
        public string UserTao { get; set; }
        public long IDChuyenMau { get; set; }
    }
    public class ThemChuyenMauChiTiet
    {
        public string MaTiepNhan { get; set; }
        public long idChuyenMau { get; set; }
        public string Barcode { get; set; }
        public string MaLoaiMau { get; set; }
        public int SoLuong { get; set; }
        public string PcTao { get; set; }
        public string UserTao { get; set; }
    }
    public class CapNhatChuyenMau
    {
        public long IDChuyenMau { get; set; }
        public string UserChuyen { get; set; }
        public string PcChuyen { get; set; }
        public bool ChiCapNhatGhiChu { get; set; }
        public string GhiChu { get; set; }
        public DateTime? TgThucHien { get; set; }
    }
}
