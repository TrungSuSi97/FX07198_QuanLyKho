using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_tinhtoan
    public class DM_XETNGHIEM_TINHTOAN
    {
        [Description("ID")]
        public int Id { get; set; }
        [Description("Loại tính toán")]
        public string Cachtinhtoan { get; set; }
        [Description("XN tính toán")]
        public string Maxn { get; set; }
        [Description("A")]
        public string Maxn1 { get; set; } = "None";
        [Description("B")]
        public string Maxn2 { get; set; } = "None";
        [Description("C")]
        public string Maxn3 { get; set; } = "None";
        [Description("D")]
        public string Maxn4 { get; set; } = "None";
        [Description("E")]
        public string Maxn5 { get; set; } = "None";
        [Description("Giới tính")]
        public int Gioitinh { get; set; } = 2;
        [Description("Mã sinh lý")]
        public string Masinhly { get; set; }
        [Description("Công thức tính / Định tính cảnh báo")]
        public string Congthuctinh { get; set; }
        [Description("Điều kiện áp dụng")]
        public string Dieukienlaycongthuc { get; set; } = "None";
        [Description("Làm tròn")]
        public int Lamtron { get; set; } = 2;
        [Description("Lấy trong khoảng")]
        public bool Laytrongkhoang { get; set; } = false;
        [Description("Điều kiện lớn")]
        public float? Dieukienlon { get; set; }
        [Description("Giá trị thay thế lớn")]
        public string Giatrithaythelon { get; set; }
        [Description("Điều kiện nhỏ")]
        public float? Dieukiennho { get; set; }
        [Description("Giá trị thay thế nhỏ")]
        public string Giatrithaythenho { get; set; }
        [Description("Nội dung cảnh báo định tính")]
        public string Noidungthongbao { get; set; }
        [Description("Ngưỡng dưới cảnh báo")]
        public float? Sosanhcanduoi { get; set; }
        [Description("Cảnh báo dưới ngưỡng")]
        public string Thongbaocanduoi { get; set; }
        [Description("Ngưỡng trên cảnh báo")]
        public float? Sosanhcantren { get; set; }
        [Description("Cảnh báo trên ngưỡng")]
        public string Thongbaocantren { get; set; }

        
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG Nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;

        public DM_XETNGHIEM_TINHTOAN Copy()
        {
            return (DM_XETNGHIEM_TINHTOAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_TINHTOAN objCompare)
        {
            PropertyInfo[] fiCheck = objCompare.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null && this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null).Equals(this.GetType().GetProperty(f.Name).GetValue(this, null)) == false)
                        return true;
                }
                else if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null || this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
    #endregion
}
