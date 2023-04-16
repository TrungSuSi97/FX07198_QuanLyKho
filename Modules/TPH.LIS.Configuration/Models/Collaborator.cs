using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_congtacvien
    public class DM_CONGTACVIEN
    {
        string _dm_congtacvien = "dm_congtacvien";
        public string Dm_congtacvien
        {
            get { return _dm_congtacvien; }
            set { _dm_congtacvien = value; }
        }

        public string Macongtacvien { get; set; }

        public string Tencongtacvien { get; set; }

        public string Diachicongtacvien { get; set; }

        public string Dienthoaicongtacvien { get; set; }

        public string Emailcongtacvien { get; set; }
        float _congtacvienchietkhau = 0;
        public float Congtacvienchietkhau
        {
            get { return _congtacvienchietkhau; }
            set { _congtacvienchietkhau = value; }
        }
        bool _ngungcongtac = false;
        public bool Ngungcongtac
        {
            get { return _ngungcongtac; }
            set { _ngungcongtac = value; }
        }

        public string Nguoinhap { get; set; }
        DateTime _gionhap = DateTime.Now;
        public DateTime Gionhap
        {
            get { return _gionhap; }
            set { _gionhap = value; }
        }

        public string Nguoisua { get; set; }

        public DateTime? Giosua { get; set; }
        public DM_CONGTACVIEN() { }
        public DM_CONGTACVIEN(string macongtacvien, string tencongtacvien, string diachicongtacvien, string dienthoaicongtacvien, string emailcongtacvien, float congtacvienchietkhau, bool ngungcongtac, string nguoinhap, DateTime gionhap, string nguoisua
        , DateTime? giosua)
        {
            this.Macongtacvien = macongtacvien;
            this.Tencongtacvien = tencongtacvien;
            this.Diachicongtacvien = diachicongtacvien;
            this.Dienthoaicongtacvien = dienthoaicongtacvien;
            this.Emailcongtacvien = emailcongtacvien;
            this.Congtacvienchietkhau = congtacvienchietkhau;
            this.Ngungcongtac = ngungcongtac;
            this.Nguoinhap = nguoinhap;
            this.Gionhap = gionhap;
            this.Nguoisua = nguoisua;
            this.Giosua = giosua;
        }
        public DM_CONGTACVIEN Copy()
        {
            return (DM_CONGTACVIEN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_CONGTACVIEN objCompare)
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
