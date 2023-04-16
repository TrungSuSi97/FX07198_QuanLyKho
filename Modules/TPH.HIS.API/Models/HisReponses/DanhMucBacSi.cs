using System;
using System.Collections.Generic;

namespace TPH.HIS.WebAPI.Models.HisReponses
{
    public class DanhMucBacSi
    {
        public string MaBacSi { get; set; }
        public string TenBacSi { get; set; }
        public byte[] ChuKy { get; set; }
    }
    public class ChucVu
    {
        public int id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
    }

    public class ChuyenKhoa
    {
        public int id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
    }

    public class DanhMucBacSiISOFH
    {
        public int id { get; set; }
        public bool active { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public string ngaySinh { get; set; }
        public string taiKhoan { get; set; }
        public string email { get; set; }
        public int? chucVuId { get; set; }
        public ChucVu chucVu { get; set; }
        public int? khoaId { get; set; }
        public Khoa khoa { get; set; }
        public int? chuyenKhoaId { get; set; }
        public ChuyenKhoa chuyenKhoa { get; set; }
        public string soDienThoai { get; set; }
        public int? hocHamHocViId { get; set; }
        public HocHamHocVi hocHamHocVi { get; set; }
        public int? vanBangId { get; set; }
        public VanBang vanBang { get; set; }
        public string chungChi { get; set; }
        public bool? datKhamOnline { get; set; }
        public string avatar { get; set; }
        public List<KhoaPhuTrach> khoaPhuTrach { get; set; }
        public List<Phong> phong { get; set; }
    }

    public class HocHamHocVi
    {
        public int? id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
    }

    public class Khoa
    {
        public int id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
    }

    public class KhoaPhuTrach
    {
        public int id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
    }

    public class Phong
    {
        public int id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public int khoaId { get; set; }
        public string khoa { get; set; }
        public string diaDiem { get; set; }
        public string toaNha { get; set; }
    }
    public class VanBang
    {
        public int? id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
    }
}
