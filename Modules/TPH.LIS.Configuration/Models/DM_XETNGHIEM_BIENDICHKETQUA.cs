using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_biendichketqua
    public class DM_XETNGHIEM_BIENDICHKETQUA
    {
        [Description("ID")]
        public int Autoid { get; set; }
        [Description("Id máy xét nghiệm")]
        public int Idmay { get; set; }
        [Description("Mã xét nghiệm máy")]
        public string Maxnmay { get; set; } = "NONE";
        [Description("Loại biên dịch")]
        public int Loaibiendich { get; set; } = 0;
        [Description("Kết quả máy")]
        public string Kqmay { get; set; }
        [Description("Kết quả biên dịch")]
        public string Kqbiendich { get; set; }
        [Description("So sánh tuyệt đối")]
        public bool Sosanhtuyetdoi { get; set; } = true;
        [Description("Điều kiện cận dưới")]
        public float? Dieukiencanduoi { get; set; }
        [Description("Giá trị thay thế cận dưới")]
        public string Giatricanduoi { get; set; }
        [Description("Điều kiện cận trên")]
        public float? Dieukiencantren { get; set; }
        [Description("Giá trị thay thế cận trên")]
        public string Giatricantren { get; set; }
        [Description("Biên dịch trong khoảng")]
        public bool Laykhoangtrong { get; set; } = false;
        [Description("Làm tròn")]
        public int? Lamtron { get; set; } = 2;
        [Description("Giá trị tính")]
        public float? Giatritinh { get; set; }
        [Description("Phép tính")]
        public string Pheptinh { get; set; }
        [Description("Định dạng kết quả")]
        public string Dinhdang { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_BIENDICHKETQUA() { }
        public DM_XETNGHIEM_BIENDICHKETQUA Copy()
        {
            return (DM_XETNGHIEM_BIENDICHKETQUA)this.MemberwiseClone();
        }
    }
    #endregion
}
