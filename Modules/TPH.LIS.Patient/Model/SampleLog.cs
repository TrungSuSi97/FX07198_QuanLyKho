using System;
using System.Reflection;

namespace TPH.LIS.Patient.Model
{
    #region nhatky_mauxetnghiem
    public class NHATKY_MAUXETNGHIEM
    {
        string _nhatky_mauxetnghiem = "nhatky_mauxetnghiem";
        public string Nhatky_mauxetnghiem
        {
            get { return _nhatky_mauxetnghiem; }
            set { _nhatky_mauxetnghiem = value; }
        }

        public int Id { get; set; }

        public string Matiepnhan { get; set; }

        public string Maxn { get; set; }

        public string Tenxn { get; set; }

        public string Maloaimau { get; set; }

        public string Tenloaimau { get; set; }

        public string Lydo { get; set; }
        public string NoiDungLydo { get; set; }

        public string Nguoithuchien { get; set; }

        public DateTime? Thoigianthuchien { get; set; }

        public string Pcthuchien { get; set; }
        int _idthuchien = 0;
        public int IdLayLoaiMau { get; set; }

        public int Idthuchien
        {
            get { return _idthuchien; }
            set { _idthuchien = value; }
        }

        public string Maphanloaidichvu { get; set; }
        public string nguoithuchiennhanmau { get; set; }

        public string nguoinhanmau { get; set; }
        public NHATKY_MAUXETNGHIEM() { }
        public NHATKY_MAUXETNGHIEM Copy()
        {
            return (NHATKY_MAUXETNGHIEM)this.MemberwiseClone();
        }
        public bool Compare_Differences(NHATKY_MAUXETNGHIEM objCompare)
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
