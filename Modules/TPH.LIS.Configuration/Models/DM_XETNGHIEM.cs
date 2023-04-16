using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem
    public class DM_XETNGHIEM
    {
        public int Autoid { get; set; }
        [Description("Mã xét nghiệm")]
        public string Maxn { get; set; }
        [Description("Mã gõ tắt")]
        public string Magotat { get; set; }
        [Description("Tên xét nghiệm")]
        public string Tenxn { get; set; }
        [Description("Tên theo Bộ y tế")]
        public string Byttenxn { get; set; }
        [Description("Loại xét nghiệm")]
        public int Loaixetnghiem { get; set; } = 0;
        [Description("Mã nhóm")]
        public string Manhomcls { get; set; }
        [Description("Giới hạn tham chiếu")]
        public string Csbt { get; set; }
        [Description("Đơn vị tính")]
        public string Donvi { get; set; }
        [Description("Ngưỡng dưới")]
        public float? Nguongduoi { get; set; }
        [Description("Ngưỡng trên")]
        public float? Nguongtren { get; set; }
        [Description("Sắp xếp")]
        public int Sapxep { get; set; } = 1;
        [Description("Thứ tự in nhóm")]
        public int Thutuin { get; set; } = 1;
        [Description("XN dịch vụ")]
        public bool Khongsd { get; set; } = false;
        [Description("XN chính")]
        public bool Xnchinh { get; set; } = false;
        [Description("Kiểm tra máy khi in")]
        public bool Kiemtramaychay { get; set; } = false;
        [Description("Không sử dụng")]
        public bool Khongsudung { get; set; } = false;
        [Description("Loại mẫu 1")]
        public string Loaimau { get; set; }
        [Description("Loại mẫu 2")]
        public string Loaimau2 { get; set; }
        [Description("Loại mẫu phụ")]
        public string Loaimauphu { get; set; }
        [Description("Ký tự đánh dấu tem")]
        public string Kytudanhdau { get; set; }
        [Description("Mã cấp trên")]
        public string Macaptren { get; set; }
        [Description("Kết quả mặc định")]
        public string Ketquamacdinh { get; set; }
        [Description("Điều kiện bất thường")]
        public string Dkdanhgia { get; set; }
        [Description("Không xuất KQ")]
        public bool Khongxuatkq { get; set; } = false;
        [Description("In đậm tên")]
        public bool Indam { get; set; } = false;
        [Description("In đậm kết quả")]
        public bool Indamkq { get; set; } = false;
        [Description("Cỡ chữ tên")]
        public int Kichcochu { get; set; } = 12;
        [Description("Cỡ chữ kết quả")]
        public int Kichcokq { get; set; } = 12;
        [Description("Canh lề (1: trái, 2:giữa, 3:phải)")]
        public int Canhle { get; set; } = 1;
        [Description("Giá chuẩn")]
        public decimal Giachuan { get; set; } = 0;
        public string Loaixn { get; set; } = "T";
        [Description("Số phút thực hiện")]
        public int Tgcoketqua { get; set; } = 0;
        [Description("Hệ số XN")]
        public int Hesoxn { get; set; } = 1;
        [Description("Mã vật tư")]
        public string Mavattu { get; set; }
        [Description("Hệ số quy đổi")]
        public float Hesoquidoi { get; set; } = 0;
        public float? Ketquaquidoi { get; set; }
        [Description("Đơn vị tính quy đổi")]
        public string Donviquidoi { get; set; }
        [Description("Giá trị tham chiếu quy đổi")]
        public string Csbtquidoi { get; set; }
        [Description("Làm tròn")]
        public int? Lamtron { get; set; }
        [Description("Không in")]
        public bool Khongin { get; set; } = false;
        public decimal Giabenhnhan { get; set; } = 0;
        [Description("Phương pháp")]
        public string Phuongphap { get; set; }
        [Description("Quy trình")]
        public string Quitrinh { get; set; }
        [Description("Thêm tem")]
        public bool Themtem { get; set; } = false;
        [Description("Ghi TG hẹn vào kết quả")]
        public bool Hentravaoketqua { get; set; } = false;
        [Description("Không đánh giá")]
        public bool Khongdanhgia { get; set; } = false;
        [Description("Ân kết quả khi in")]
        public bool Anketquakhiin { get; set; } = false;
        [Description("Đạt chứng nhận ISO")]
        public bool Datchungnhan { get; set; } = false;
        [Description("Bật cảnh báo bất thường")]
        public bool Batcanhbaobatthuong { get; set; } = false;
        [Description("In hẹn trả")]
        public bool Hentrakq { get; set; } = false;
        [Description("Có hình ảnh")]
        public bool Cohinhanh { get; set; } = false;
        [Description("Màu tên XN khi KQ bất thường trên")]
        public string Mautenbatthuongtren { get; set; }
        [Description("Màu tên XN khi KQ bất thường dưới")]
        public string Mautenbatthuongduoi { get; set; }
        [Description("Tính tem")]
        public bool Tinhtem { get; set; } = false;
        [Description("XN cờ")]
        public bool Xnco { get; set; } = false;
        [Description("Mã XN đánh giá")]
        public string Maxndanhgia { get; set; }
        [Description("Xét nghiệm gửi")]
        public bool Xngui { get; set; } = false;
        public string Loaiongmau2 { get; set; }
        [Description("Đánh dấu trên form nhận mẫu")]
        public bool Danhdaunhanmau { get; set; } = false;
        [Description("Xét nghiệm đặc biệt")]
        public bool Xndacbiet { get; set; } = false;
        [Description("Cận trên cảnh báo")]
        public float? Cantrencanhbao { get; set; }
        [Description("Cận dưới cảnh báo")]
        public float? Canduoicanhbao { get; set; }
        [Description("Giới hạn cảnh báo")]
        public string Gioihancanhbao { get; set; }
        [Description("Định tính cảnh báo")]
        public string Dinhtinhcanhbao { get; set; }
        [Description("Ký hiệu XN")]
        public string Kyhieu { get; set; }
        [Description("Cuối trang in SHPT")]
        public string Cuoitrangin { get; set; }
        [Description("Tên xét nghiệm SHPT")]
        public string Tenxnshpt { get; set; }
        [Description("Tên xét nghiệm SHPT - Nhân hệ số")]
        public string Tenxnshptheso { get; set; }
        [Description("ID mẫu in SHPT")]
        public int Mauinshpt { get; set; } = 0;
        [Description("Tên gen/type SHPT")]
        public string Shptgenname { get; set; }
        [Description("Nội kiểm tra chất lượng SHPT")]
        public string Noikiemtrachatluong { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("Thời gian nhập")]
        public DateTime Thoigiannhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM Copy()
        {
            return (DM_XETNGHIEM)this.MemberwiseClone();
        }
    }
    #endregion
}
