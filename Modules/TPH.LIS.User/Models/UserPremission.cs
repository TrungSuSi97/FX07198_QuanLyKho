using System;
using System.Reflection;

namespace TPH.LIS.User.Models
{
    #region ql_nguoidung_bophan
    public class QL_NGUOIDUNG_BOPHAN
    {
        string _ql_nguoidung_bophan = "ql_nguoidung_bophan";
        public string Ql_nguoidung_bophan
        {
            get { return _ql_nguoidung_bophan; }
            set { _ql_nguoidung_bophan = value; }
        }

        public string Manguoidung { get; set; }

        public string Mabophan { get; set; }
        string _maloaidichvu = "1";
        public string Maloaidichvu
        {
            get { return _maloaidichvu; }
            set { _maloaidichvu = value; }
        }
        public QL_NGUOIDUNG_BOPHAN() { }
        public QL_NGUOIDUNG_BOPHAN(string manguoidung, string mabophan, string maloaidichvu)
        {
            this.Manguoidung = manguoidung;
            this.Mabophan = mabophan;
            this.Maloaidichvu = maloaidichvu;
        }
        public QL_NGUOIDUNG_BOPHAN Copy()
        {
            return (QL_NGUOIDUNG_BOPHAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NGUOIDUNG_BOPHAN objCompare)
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
    #region ql_nguoidung_khuvuc
    public class QL_NGUOIDUNG_KHUVUC
    {
        string _ql_nguoidung_khuvuc = "ql_nguoidung_khuvuc";
        public string Ql_nguoidung_khuvuc
        {
            get { return _ql_nguoidung_khuvuc; }
            set { _ql_nguoidung_khuvuc = value; }
        }

        public string Manguoidung { get; set; }

        public string Makhuvuc { get; set; }
        public QL_NGUOIDUNG_KHUVUC() { }
        public QL_NGUOIDUNG_KHUVUC(string manguoidung, string makhuvuc)
        {
            this.Manguoidung = manguoidung;
            this.Makhuvuc = makhuvuc;
        }
        public QL_NGUOIDUNG_KHUVUC Copy()
        {
            return (QL_NGUOIDUNG_KHUVUC)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NGUOIDUNG_KHUVUC objCompare)
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
    #region ql_nguoidung_loaidichvu
    public class QL_NGUOIDUNG_LOAIDICHVU
    {
        string _ql_nguoidung_loaidichvu = "ql_nguoidung_loaidichvu";
        public string Ql_nguoidung_loaidichvu
        {
            get { return _ql_nguoidung_loaidichvu; }
            set { _ql_nguoidung_loaidichvu = value; }
        }

        public string Manguoidung { get; set; }

        public string Maloaidichvu { get; set; }
        public QL_NGUOIDUNG_LOAIDICHVU() { }
        public QL_NGUOIDUNG_LOAIDICHVU(string manguoidung, string maloaidichvu)
        {
            this.Manguoidung = manguoidung;
            this.Maloaidichvu = maloaidichvu;
        }
        public QL_NGUOIDUNG_LOAIDICHVU Copy()
        {
            return (QL_NGUOIDUNG_LOAIDICHVU)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NGUOIDUNG_LOAIDICHVU objCompare)
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
    #region ql_nguoidung_nhomdichvu
    public class QL_NGUOIDUNG_NHOMDICHVU
    {
        string _ql_nguoidung_nhomdichvu = "ql_nguoidung_nhomdichvu";
        public string Ql_nguoidung_nhomdichvu
        {
            get { return _ql_nguoidung_nhomdichvu; }
            set { _ql_nguoidung_nhomdichvu = value; }
        }

        public string Manguoidung { get; set; }

        public string Manhomdichvu { get; set; }
        string _maloaidichvu = "1";
        public string Maloaidichvu
        {
            get { return _maloaidichvu; }
            set { _maloaidichvu = value; }
        }
        public QL_NGUOIDUNG_NHOMDICHVU() { }
        public QL_NGUOIDUNG_NHOMDICHVU(string manguoidung, string manhomdichvu, string maloaidichvu)
        {
            this.Manguoidung = manguoidung;
            this.Manhomdichvu = manhomdichvu;
            this.Maloaidichvu = maloaidichvu;
        }
        public QL_NGUOIDUNG_NHOMDICHVU Copy()
        {
            return (QL_NGUOIDUNG_NHOMDICHVU)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NGUOIDUNG_NHOMDICHVU objCompare)
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
    #region ql_nguoidung_phanquyen
    public class QL_NGUOIDUNG_PHANQUYEN
    {
        string _ql_nguoidung_phanquyen = "{{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen";
        public string Ql_nguoidung_phanquyen
        {
            get { return _ql_nguoidung_phanquyen; }
            set { _ql_nguoidung_phanquyen = value; }
        }

        public string Manguoidung { get; set; }

        public string Maphanquyen { get; set; }
        string _maloaidichvu = "0";
        public string Maloaidichvu
        {
            get { return _maloaidichvu; }
            set { _maloaidichvu = value; }
        }

        public string Manhomquyen { get; set; }
        public QL_NGUOIDUNG_PHANQUYEN() { }
        public QL_NGUOIDUNG_PHANQUYEN(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {
            this.Manguoidung = manguoidung;
            this.Maphanquyen = maphanquyen;
            this.Maloaidichvu = maloaidichvu;
            this.Manhomquyen = manhomquyen;
        }
        public QL_NGUOIDUNG_PHANQUYEN Copy()
        {
            return (QL_NGUOIDUNG_PHANQUYEN)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NGUOIDUNG_PHANQUYEN objCompare)
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
    #region ql_nguoidung_nhomphanquyen
    public class QL_NGUOIDUNG_NHOMPHANQUYEN
    {

        public string Ql_nguoidung_nhomphanquyen { get; set; } = "ql_nguoidung_nhomphanquyen";

        public string Manguoidung { get; set; }

        public string Manhomphanquyen { get; set; }

        public string Nguoicap { get; set; }

        public DateTime Ngaycap { get; set; } = DateTime.Now;
        public string Hethong { get; set; }
        
        public QL_NGUOIDUNG_NHOMPHANQUYEN() { }

        public QL_NGUOIDUNG_NHOMPHANQUYEN Copy()
        {
            return (QL_NGUOIDUNG_NHOMPHANQUYEN)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NGUOIDUNG_NHOMPHANQUYEN objCompare)
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
