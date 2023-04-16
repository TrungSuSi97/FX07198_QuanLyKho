using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_doituongbenhnhan
    public class DM_DOITUONGBENHNHAN
    {
        string _dm_doituongbenhnhan = "dm_doituongbenhnhan";
        public string Dm_doituongbenhnhan
        {
            get { return _dm_doituongbenhnhan; }
            set { _dm_doituongbenhnhan = value; }
        }

        public string Madoituongbn { get; set; }

        public string Tendoituongbn { get; set; }
        public DM_DOITUONGBENHNHAN() { }
        public DM_DOITUONGBENHNHAN(string madoituongbn, string tendoituongbn)
        {
            this.Madoituongbn = madoituongbn;
            this.Tendoituongbn = tendoituongbn;
        }
        public DM_DOITUONGBENHNHAN Copy()
        {
            return (DM_DOITUONGBENHNHAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_DOITUONGBENHNHAN objCompare)
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
