using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.Analyzer.Model
{
    #region dm_maytinh_mayxetnghiem
    public class DM_MAYTINH_MAYXETNGHIEM
    {
        public string Dm_maytinh_mayxetnghiem { get; set; } = "dm_maytinh_mayxetnghiem";

        public string Makhuvuc { get; set; }

        public string Tenmaytinh { get; set; }

        public int Idmayxetnghiem { get; set; }

        public DateTime Thoigiannhap { get; set; } = DateTime.Now;

        public string Nguoinhap { get; set; }
        public DM_MAYTINH_MAYXETNGHIEM() { }
        public DM_MAYTINH_MAYXETNGHIEM(string makhuvuc, string tenmaytinh, int idmayxetnghiem, DateTime thoigiannhap, string nguoinhap)
        {
            this.Makhuvuc = makhuvuc;
            this.Tenmaytinh = tenmaytinh;
            this.Idmayxetnghiem = idmayxetnghiem;
            this.Thoigiannhap = thoigiannhap;
            this.Nguoinhap = nguoinhap;
        }
        public DM_MAYTINH_MAYXETNGHIEM Copy()
        {
            return (DM_MAYTINH_MAYXETNGHIEM)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_MAYTINH_MAYXETNGHIEM objCompare)
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
