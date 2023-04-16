using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_congty
    public class DM_CONGTY
    {
        [Description("Mã công ty")]
        public string Macongty { get; set; }
        [Description("Tên công ty")]
        public string Tencongty { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TGN Nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_CONGTY() { }
        public DM_CONGTY Copy()
        {
            return (DM_CONGTY)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_CONGTY objCompare)
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
