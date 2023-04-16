using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Cashier.Model
{
    #region p_payment_lock
    public class P_PAYMENT_LOCK
    {
        string _p_payment_lock = "p_payment_lock";
        public string P_payment_lock
        {
            get { return _p_payment_lock; }
            set { _p_payment_lock = value; }
        }

        public decimal Idketchuyen { get; set; }
        DateTime _thoigianketchuyen = DateTime.Now;
        public DateTime Thoigianketchuyen
        {
            get { return _thoigianketchuyen; }
            set { _thoigianketchuyen = value; }
        }

        public string Maytinh { get; set; }

        public string Thungan { get; set; }
        decimal _tongtienthu = 0;
        public decimal Tongtienthu
        {
            get { return _tongtienthu; }
            set { _tongtienthu = value; }
        }
        decimal _tongno = 0;
        public decimal Tongno
        {
            get { return _tongno; }
            set { _tongno = value; }
        }
        decimal _tongtienhoan = 0;
        public decimal Tongtienhoan
        {
            get { return _tongtienhoan; }
            set { _tongtienhoan = value; }
        }
        decimal _tongthucthu = 0;
        public decimal Tongthucthu
        {
            get { return _tongthucthu; }
            set { _tongthucthu = value; }
        }
        public DateTime Ngaythutien { get; set; }
        int _tongsobienlaithu = 0;
        public int Tongsobienlaithu
        {
            get { return _tongsobienlaithu; }
            set { _tongsobienlaithu = value; }
        }
        int _tongsobienlaihoan = 0;
        public int Tongsobienlaihoan
        {
            get { return _tongsobienlaihoan; }
            set { _tongsobienlaihoan = value; }
        }
        public P_PAYMENT_LOCK() { }
        public P_PAYMENT_LOCK(decimal idketchuyen, DateTime thoigianketchuyen, string maytinh, string thungan, decimal tongtienthu, decimal tongno, decimal tongtienhoan, decimal tongthucthu, DateTime ngaythutien, int tongsobienlaithu
        , int tongsobienlaihoan)
        {
            this.Idketchuyen = idketchuyen;
            this.Thoigianketchuyen = thoigianketchuyen;
            this.Maytinh = maytinh;
            this.Thungan = thungan;
            this.Tongtienthu = tongtienthu;
            this.Tongno = tongno;
            this.Tongtienhoan = tongtienhoan;
            this.Tongthucthu = tongthucthu;
            this.Ngaythutien = ngaythutien;
            this.Tongsobienlaithu = tongsobienlaithu;
            this.Tongsobienlaihoan = tongsobienlaihoan;
        }

        public P_PAYMENT_LOCK Copy()
        {
            return (P_PAYMENT_LOCK)this.MemberwiseClone();
        }
        public bool Compare_Differences(P_PAYMENT_LOCK objCompare)
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
