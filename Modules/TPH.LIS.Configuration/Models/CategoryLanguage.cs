using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_ngonngu
    public class DM_NGONNGU
    {
        string _dm_ngonngu = "dm_ngonngu";
        public string Dm_ngonngu
        {
            get { return _dm_ngonngu; }
            set { _dm_ngonngu = value; }
        }

        public string Idngonngu { get; set; }

        public string Mota { get; set; }
        public DM_NGONNGU() { }
        public DM_NGONNGU(string idngonngu, string mota)
        {
            this.Idngonngu = idngonngu;
            this.Mota = mota;
        }
        public DM_NGONNGU Copy()
        {
            return (DM_NGONNGU)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_NGONNGU objCompare)
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
    #region dm_ngonngu_danhmuc
    public class DM_NGONNGU_DANHMUC
    {
        string _dm_ngonngu_danhmuc = "dm_ngonngu_danhmuc";
        public string Dm_ngonngu_danhmuc
        {
            get { return _dm_ngonngu_danhmuc; }
            set { _dm_ngonngu_danhmuc = value; }
        }

        public string Iddanhmuc { get; set; }

        public string Madanhmuc { get; set; }

        public string Idngonngu { get; set; }

        public string Noidung { get; set; }
        public DM_NGONNGU_DANHMUC() { }
        public DM_NGONNGU_DANHMUC(string iddanhmuc, string madanhmuc, string idngonngu, string noidung)
        {
            this.Iddanhmuc = iddanhmuc;
            this.Madanhmuc = madanhmuc;
            this.Idngonngu = idngonngu;
            this.Noidung = noidung;
        }
        public DM_NGONNGU_DANHMUC Copy()
        {
            return (DM_NGONNGU_DANHMUC)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_NGONNGU_DANHMUC objCompare)
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
