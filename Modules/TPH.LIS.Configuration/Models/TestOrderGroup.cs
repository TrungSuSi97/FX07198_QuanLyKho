using System;
using System.ComponentModel;
using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_bo
    public class DM_XETNGHIEM_BO
    {
        [Description("Mã bộ XN")]
        public string Maboxetnghiem { get; set; }
        [Description("Tên bộ XN")]
        public string Tenboxetnghiem { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_BO() { }
       
        public DM_XETNGHIEM_BO Copy()
        {
            return (DM_XETNGHIEM_BO)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_BO objCompare)
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
    #region dm_xetnghiem_bo_chitiet
    public class DM_XETNGHIEM_BO_CHITIET
    {
        [Description("Mã bộ XN")]
        public string Maboxetnghiem { get; set; }
        [Description("Mã chỉ định")]
        public string Machidinh { get; set; }
        [Description("Tên chỉ định")]
        public string Tenxn { get; set; }
        [Description("Profile")]
        public bool Xnprofile { get; set; } = false;
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_BO_CHITIET() { }
    
        public DM_XETNGHIEM_BO_CHITIET Copy()
        {
            return (DM_XETNGHIEM_BO_CHITIET)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_BO_CHITIET objCompare)
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
