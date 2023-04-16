using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.Patient.Model
{
    #region xetnghiem_ghichu_laymau
    public class XETNGHIEM_GHICHU_LAYMAU
    {

        public string Xetnghiem_ghichu_laymau { get; set; } = "xetnghiem_ghichu_laymau";

        public string Maxn { get; set; }

        public string Matiepnhan { get; set; }

        public string Noidungghichu { get; set; }

        public string Maghichu { get; set; }

        public string Nguoighichu { get; set; }

        public DateTime Thoigianghichu { get; set; } = DateTime.Now;

        public string Pcthuchien { get; set; }
        public XETNGHIEM_GHICHU_LAYMAU() { }
        public XETNGHIEM_GHICHU_LAYMAU(string maxn, string matiepnhan, string noidungghichu, string maghichu, string nguoighichu, DateTime thoigianghichu, string pcthuchien)
        {
            this.Maxn = maxn;
            this.Matiepnhan = matiepnhan;
            this.Noidungghichu = noidungghichu;
            this.Maghichu = maghichu;
            this.Nguoighichu = nguoighichu;
            this.Thoigianghichu = thoigianghichu;
            this.Pcthuchien = pcthuchien;
        }
        public XETNGHIEM_GHICHU_LAYMAU Copy()
        {
            return (XETNGHIEM_GHICHU_LAYMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(XETNGHIEM_GHICHU_LAYMAU objCompare)
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
