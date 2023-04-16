using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.Configuration.Models
{
    #region dm_khayluumau
    public class DM_KHAYLUUMAU
    {
        [Description("Mã khay")]
        public string Makhayluumau { get; set; }
        [Description("Mã tủ lưu")]
        public string Matuluu { get; set; }
        [Description("Tên khay mẫu")]
        public string Tenkhailuumau { get; set; }
        [Description("Ngang")]
        public int Kichthuocngang { get; set; } = 1;
        [Description("Dọc")]
        public int Kichthuocdoc { get; set; } = 1;
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Gionhap { get; set; } = DateTime.Now;
        public DM_KHAYLUUMAU() { }
        public DM_KHAYLUUMAU(string makhayluumau, string matuluu, string tenkhailuumau, int kichthuocngang, int kichthuocdoc, string nguoinhap, DateTime gionhap)
        {
            this.Makhayluumau = makhayluumau;
            this.Matuluu = matuluu;
            this.Tenkhailuumau = tenkhailuumau;
            this.Kichthuocngang = kichthuocngang;
            this.Kichthuocdoc = kichthuocdoc;
            this.Nguoinhap = nguoinhap;
            this.Gionhap = gionhap;
        }
        public DM_KHAYLUUMAU Copy()
        {
            return (DM_KHAYLUUMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_KHAYLUUMAU objCompare)
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
    #region dm_tuluumau
    public class DM_TULUUMAU
    {

        [Description("Mã tủ lưu")]
        public string Matuluu { get; set; }
        [Description("Tên tủ lưu")]
        public string Tentuluu { get; set; }
        [Description("Hãng sản xuất")]
        public string Hangcungcap { get; set; }
        [Description("Mã khoa XN")]
        public string Khoaxetnghiem { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Gionhap { get; set; } = DateTime.Now;
        public DM_TULUUMAU() { }
        public DM_TULUUMAU(string matuluu, string tentuluu, string hangcungcap, string khoaxetnghiem, string nguoinhap, DateTime gionhap)
        {
            this.Matuluu = matuluu;
            this.Tentuluu = tentuluu;
            this.Hangcungcap = hangcungcap;
            this.Khoaxetnghiem = khoaxetnghiem;
            this.Nguoinhap = nguoinhap;
            this.Gionhap = gionhap;
        }
        public DM_TULUUMAU Copy()
        {
            return (DM_TULUUMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_TULUUMAU objCompare)
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
