using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.Lab.Middleware.LISConnect.Models
{
    #region dm_mappingHIS
    public class DM_MAPPINGHIS
    {

        public string Dm_mappinghis { get; set; } = "dm_mappingHIS";

        public string Lisid { get; set; }

        public int Hisproviderid { get; set; }

        public int Categoryid { get; set; }

        public string Hisid { get; set; }

        public string Nguoinhap { get; set; }

        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_MAPPINGHIS() { }
        public DM_MAPPINGHIS(string lisid, int hisproviderid, int categoryid, string hisid, string nguoinhap, DateTime tgnhap)
        {
            this.Lisid = lisid;
            this.Hisproviderid = hisproviderid;
            this.Categoryid = categoryid;
            this.Hisid = hisid;
            this.Nguoinhap = nguoinhap;
            this.Tgnhap = tgnhap;
        }
        public DM_MAPPINGHIS Copy()
        {
            return (DM_MAPPINGHIS)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_MAPPINGHIS objCompare)
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
