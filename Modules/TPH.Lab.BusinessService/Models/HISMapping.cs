using System;
using System.ComponentModel;

namespace TPH.Lab.BusinessService.Models
{
    public enum HisMappingCategory
    {
        [Description("Tất cả")]
        All = 0,
        [Description("Danh mục xét nghiệm")]
        DichVuXetNghiem = 1,
        [Description("Danh mục khoa phòng")]
        KhoaPhong = 2,
        [Description("Danh mục nhân viên/Bác Sĩ")]
        NhanVien = 3,
        [Description("Danh mục đối tượng")]
        DoiTuong = 4,
        [Description("Danh mục chẩn đoán")]
        ChanDoan = 5,
        [Description("Danh mục máy xét nghiệm")]
        MayXetNghiem = 6,
        [Description("Danh mục phòng")]
        Phong = 7,
        [Description("Danh mục sinh lý")]
        SinhLy = 8,
        [Description("Danh mục công ty")]
        CongTyHopDong = 9,
        [Description("Danh mục loại mẫu")]
        LoaiMau = 10
    }
    public class HISMapping
    {
        public string LISID { get; set; }
        public int CategoryID { get; set; }
        public int HisProviderID { get; set; }
        public string HISID { get; set; }
        public string ItemName { get; set; }
        public string MasterID { get; set; }
        public string NguoiNhap { get; set; }
        public DateTime? TGNhap { get; set; }
    } 
}
