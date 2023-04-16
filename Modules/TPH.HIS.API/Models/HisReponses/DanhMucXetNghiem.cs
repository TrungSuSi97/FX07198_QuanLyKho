using System.Collections.Generic;

namespace TPH.HIS.WebAPI.Models.HisReponses
{
    public class DanhMucXetNghiem
    {
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public string MaDichVuCha { get; set; }
        public string MaLoaiDichVu { get; set; }
        public string TenLoaiDichVu { get; set; }
    }
    //public class DanhMucXetNghiemISofH
    //{
    //    public string MaLoaiDV { get; set; }
    //    public string TenLoaiDV { get; set; }
    //    public string MaDV { get; set; }
    //    public string TenDichVu { get; set; }
    //    public string MaLIS { get; set; }
    //}
    public class DanhSachXetNghiemISofH
    {
        public string MaLoaiDV { get; set; }
        public string TenLoaiDV { get; set; }
        public string MaDV { get; set; }
        public string TenDichVu { get; set; }
        public string MaLIS { get; set; }
        public IList<DanhSachXetNghiemISofH> ListSubService { get; set; }
    }
}
