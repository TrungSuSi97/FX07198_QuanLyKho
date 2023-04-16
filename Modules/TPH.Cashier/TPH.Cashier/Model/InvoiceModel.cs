using System;
using System.Reflection;

namespace TPH.Cashier.Model
{
    #region p_payment
    public class P_PAYMENT
    {
        string _p_payment = "p_payment";
        public string P_payment
        {
            get { return _p_payment; }
            set { _p_payment = value; }
        }

        public Int64 Id { get; set; }

        public string Matiepnhan { get; set; }
        DateTime _ngaythanhtoan = DateTime.Now;
        public DateTime Ngaythanhtoan
        {
            get { return _ngaythanhtoan; }
            set { _ngaythanhtoan = value; }
        }
        decimal _thanhtoan = 0;
        public decimal Thanhtoan
        {
            get { return _thanhtoan; }
            set { _thanhtoan = value; }
        }
        decimal _conlai = 0;
        public decimal Conlai
        {
            get { return _conlai; }
            set { _conlai = value; }
        }

        public string Ghichu { get; set; }
        int _thaotac = 0;
        public int Thaotac
        {
            get { return _thaotac; }
            set { _thaotac = value; }
        }
        int _hinhthucthanhtoan = 0;
        public int Hinhthucthanhtoan
        {
            get { return _hinhthucthanhtoan; }
            set { _hinhthucthanhtoan = value; }
        }
        decimal _tongtien = 0;
        public decimal Tongtien
        {
            get { return _tongtien; }
            set { _tongtien = value; }
        }

        public int? Idblhoan { get; set; }

        public string Maytinh { get; set; }

        public string Thungan { get; set; }
        public P_PAYMENT() { }
        public P_PAYMENT(int id, string matiepnhan, DateTime ngaythanhtoan, decimal thanhtoan, decimal conlai, string ghichu, int thaotac, int hinhthucthanhtoan, decimal tongtien, int? idblhoan
        , string maytinh, string thungan)
        {
            this.Id = id;
            this.Matiepnhan = matiepnhan;
            this.Ngaythanhtoan = ngaythanhtoan;
            this.Thanhtoan = thanhtoan;
            this.Conlai = conlai;
            this.Ghichu = ghichu;
            this.Thaotac = thaotac;
            this.Hinhthucthanhtoan = hinhthucthanhtoan;
            this.Tongtien = tongtien;
            this.Idblhoan = idblhoan;
            this.Maytinh = maytinh;
            this.Thungan = thungan;
        }
        public P_PAYMENT Copy()
        {
            return (P_PAYMENT)this.MemberwiseClone();
        }
        public bool Compare_Differences(P_PAYMENT objCompare)
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
        #endregion
    }
}

