using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetngnghiem_phuongphap
    public class DM_XETNGNGHIEM_PHUONGPHAP
    {
        [Description("ID")]
        public int Autoid { get; set; }
        [Description("Mã XN")]
        public string Maxn { get; set; }
        [Description("Id máy xét nghiệm")]
        public int Idmayxn { get; set; } = -1;
        [Description("Quy trình")]
        public string Quitrinh { get; set; }
        [Description("Phương pháp")]
        public string Phuongphap { get; set; }
        [Description("Đạt chứng nhận")]
        public bool Datchungnhan { get; set; } = false;
        [Description("Nội kiểm tra chất lượng")]
        public string Noikiemtrachatluong { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;

        public string Nguoisua { get; set; }

        public DateTime? Tgsua { get; set; } = DateTime.Now;

        public DM_XETNGNGHIEM_PHUONGPHAP() { }
        public DM_XETNGNGHIEM_PHUONGPHAP(int autoid, string maxn, int idmayxn, string quitrinh, string phuongphap, string nguoinhap, DateTime tgnhap, string nguoisua, DateTime? tgsua, bool datchungnhan
        , string noikiemtrachatluong)
        {
            this.Autoid = autoid;
            this.Maxn = maxn;
            this.Idmayxn = idmayxn;
            this.Quitrinh = quitrinh;
            this.Phuongphap = phuongphap;
            this.Nguoinhap = nguoinhap;
            this.Tgnhap = tgnhap;
            this.Nguoisua = nguoisua;
            this.Tgsua = tgsua;
            this.Datchungnhan = datchungnhan;
            this.Noikiemtrachatluong = noikiemtrachatluong;
        }
        public DM_XETNGNGHIEM_PHUONGPHAP Copy()
        {
            return (DM_XETNGNGHIEM_PHUONGPHAP)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGNGHIEM_PHUONGPHAP objCompare)
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
