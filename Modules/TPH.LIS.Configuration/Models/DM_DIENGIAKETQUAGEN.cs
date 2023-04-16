using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.Configuration.Models
{
    #region dm_diengiaketquagen
    public class DM_DIENGIAKETQUAGEN
    {

        public string Dm_diengiaketquagen { get; set; } = "dm_diengiaketquagen";

        public int Id { get; set; }

        public string Maxn { get; set; }

        public string Maxnthamgia { get; set; }

        public DateTime Thoigiantao { get; set; } = DateTime.Now;

        public string Nguoitao { get; set; }

        public DateTime? Thoigiansua { get; set; }

        public string Nguoisua { get; set; }

        public string Giaithich { get; set; }

        public string Tuvan { get; set; }

        public string Phuongphap { get; set; }

        public string Tailieuthamkhao { get; set; }
        public string Gioihan { get; set; }
        public int Loai { get; set; } = 0;
        public Image Hinhdiengiai1 { get; set; }
        public Image Hinhdiengiai2 { get; set; }
        public string Ghichudiengiai { get; set; }
        public DM_DIENGIAKETQUAGEN() { }
        public DM_DIENGIAKETQUAGEN Copy()
        {
            return (DM_DIENGIAKETQUAGEN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_DIENGIAKETQUAGEN objCompare)
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
