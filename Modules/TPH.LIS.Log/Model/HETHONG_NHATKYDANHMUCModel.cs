using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Log.Model
{
    #region HeThong_NhatKyDanhMuc
    public class HETHONG_NHATKYDANHMUC
    {

        public long Id { get; set; }

        public int Idhanhdong { get; set; }

        public string Idnhatky { get; set; }

        public DateTime Thoigianthuchien { get; set; } = DateTime.Now;

        public string Nguoithuchien { get; set; }

        public string Pcthuchien { get; set; }

        public string Noidung { get; set; }

        public string Madanhmuc { get; set; }
        public HETHONG_NHATKYDANHMUC() { }
        public HETHONG_NHATKYDANHMUC(long id, int idhanhdong, string idnhatky, DateTime thoigianthuchien, string nguoithuchien, string pcthuchien, string noidung, string madanhmuc)
        {
            this.Id = id;
            this.Idhanhdong = idhanhdong;
            this.Idnhatky = idnhatky;
            this.Thoigianthuchien = thoigianthuchien;
            this.Nguoithuchien = nguoithuchien;
            this.Pcthuchien = pcthuchien;
            this.Noidung = noidung;
            this.Madanhmuc = madanhmuc;
        }
        public HETHONG_NHATKYDANHMUC Copy()
        {
            return (HETHONG_NHATKYDANHMUC)this.MemberwiseClone();
        }
        public bool Compare_Differences(HETHONG_NHATKYDANHMUC objCompare)
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
