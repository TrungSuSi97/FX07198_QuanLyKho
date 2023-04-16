using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.Configuration.Models
{
    #region dm_khuvuc_xnkhongthuchien
    public class DM_KHUVUC_XNKHONGTHUCHIEN
    {

        public string Dm_khuvuc_xnkhongthuchien { get; set; } = "dm_khuvuc_xnkhongthuchien";

        public string Makhuvuc { get; set; }

        public string Maxn { get; set; }

        public string Makhuvucnhan { get; set; }

        public string Nguoinhap { get; set; }

        public DateTime Tgnhap { get; set; } = DateTime.Now;

        public string Pcnhap { get; set; }
        public string Tenkhuvuc { get; set; }
        public string Tenkhuvucnhan { get; set; }
        
        public DM_KHUVUC_XNKHONGTHUCHIEN() { }
        public DM_KHUVUC_XNKHONGTHUCHIEN(string makhuvuc, string maxn, string makhuvucnhan, string nguoinhap, DateTime tgnhap, string pcnhap)
        {
            this.Makhuvuc = makhuvuc;
            this.Maxn = maxn;
            this.Makhuvucnhan = makhuvucnhan;
            this.Nguoinhap = nguoinhap;
            this.Tgnhap = tgnhap;
            this.Pcnhap = pcnhap;
        }
        public DM_KHUVUC_XNKHONGTHUCHIEN Copy()
        {
            return (DM_KHUVUC_XNKHONGTHUCHIEN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_KHUVUC_XNKHONGTHUCHIEN objCompare)
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
