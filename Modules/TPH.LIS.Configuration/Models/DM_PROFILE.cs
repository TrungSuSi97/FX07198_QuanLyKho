using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_profile
    public class DM_XETNGHIEM_PROFILE
    {
        [Description("Mã profile")]
        public string Profileid { get; set; }
        [Description("Tên profile")]
        public string Profilename { get; set; }
        [Description("Mã nhóm")]
        public string Manhomcls { get; set; }
        [Description("Số phút thực hiện")]
        public int Tgcoketqua { get; set; } = 0;
        public bool Tudongchon { get; set; } = false;
        [Description("Dùng cho SLSS")]
        public bool Profileslss { get; set; } = false;
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_PROFILE Copy()
        {
            return (DM_XETNGHIEM_PROFILE)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_PROFILE objCompare)
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
    #region dm_xetnghiem_profile_chitiet
    public class DM_XETNGHIEM_PROFILE_CHITIET
    {
        [Description("Mã profile")]
        public string Profileid { get; set; }
        [Description("Mã xét nghiệm")]
        public string Maxn { get; set; }
        [Description("Tên xét nghiệm")]
        public string Tenxn { get; set; }
        [Description("TG nhập")]
        public DateTime Intime { get; set; } = DateTime.Now;
        [Description("Tg có kết quả")]
        public int Tgcoketqua { get; set; } = 0;
        [Description("Số lượng xn")]
        public int Soluongxn { get; set; } = 1;
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_PROFILE_CHITIET Copy()
        {
            return (DM_XETNGHIEM_PROFILE_CHITIET)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_PROFILE_CHITIET objCompare)
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
