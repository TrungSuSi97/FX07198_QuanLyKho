using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_csbt
    public class DM_XETNGHIEM_CSBT
    {
        [Description("ID")]
        public int Autoid { get; set; }
        [Description("Mã xét nghiệm")]
        public string Maxn { get; set; }
        [Description("Máy xét nghiệm")]
        public int Idmayxn { get; set; } = 0;
        [Description("ID Loại tuổi")]
        public int Loaituoi { get; set; } = 0;
        [Description("Giới tính")]
        public string Gioitinh { get; set; } = "A";
        [Description("Từ tuổi")]
        public int Tutuoi { get; set; } = 0;
        [Description("Đến tuổi")]
        public int Dentuoi { get; set; } = 1000;
        [Description("Từ cân nặng")]
        public float Csbttucannang { get; set; } = 0;
        [Description("Đến cân nặng")]
        public float Csbtdencannang { get; set; } = 0;
        [Description("Mã sinh lý")]
        public string Masinhly { get; set; }
        [Description("Khoảng tham chiếu")]
        public string Csbt { get; set; }
        [Description("Ngưỡng dưới")]
        public float? Nguongduoi { get; set; }
        [Description("Ngưỡng trên")]
        public float? Nguongtren { get; set; }
        [Description("Định tính bất thường")]
        public string Dieukiendanhgia { get; set; }
        [Description("Đơn vị tính")]
        public string Donvi { get; set; }
        [Description("Hệ số quy đổi")]
        public float Hesoquidoi { get; set; } = 0;
        [Description("Đơn vị tính quy đổi")]
        public string Donviquidoi { get; set; }
        [Description("Khoảng tham chiếu quy đổi")]
        public string Csbtquidoi { get; set; }
        [Description("Làm tròn quy đổi")]
        public int Lamtronsauquidoi { get; set; } = 2;
        [Description("Giới hạn cảnh báo")]
        public string Gioihancanhbao { get; set; }
        [Description("Cận trên cảnh báo")]
        public float? Cantrencanhbao { get; set; }
        [Description("Cận dưới cảnh báo")]
        public float? Canduoicanhbao { get; set; }
        [Description("Định tính cảnh báo")]
        public string Dinhtinhcanhbao { get; set; }
        public float Csbtcannang { get; set; } = 0;
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;

        public DM_XETNGHIEM_CSBT Copy()
        {
            return (DM_XETNGHIEM_CSBT)this.MemberwiseClone();
        }
    }
    #endregion
}
