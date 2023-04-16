using System;

namespace TPH.Lab.BusinessService.Models
{
    public class XetNghiemHISInfo
    {
        public int id { get; set; }
        public string madichvu { get; set; }
        public string tendichvu { get; set; }
        public string donvitinh { get; set; }
        public string macaptren { get; set; }
        public string maxn { get; set; }
        public bool isprofile { get; set; }
        public string nhomxn { get; set; }
        public string loaidvHIS { get; set; }
        public string maprofile { get; set; }
        public string thongsocon { get; set; }
        public int HisProviderID { get; set; }
        public int LoaiXetNghiem { get; set; }
        public string NguoiNhap { get; set; }
        public DateTime? TgNhap { get; set; }
    }
    public class XetNghiemMapping
    {
        public string Maxnlis { get; set; }
        public string Maprofilelis { get; set; }
        public bool Isprofile { get; set; }
        public string Nguoinhap { get; set; }
        public string Thongsocon { get; set; }
        public string Madichvu { get; set; }
        public int Hisproviderid { get; set; }
    }
}
