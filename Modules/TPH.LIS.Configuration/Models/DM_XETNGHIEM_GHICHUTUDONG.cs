using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_ghichutudong
    public class DM_XETNGHIEM_GHICHUTUDONG
    {
        [Description("ID")]
        public int Id { get; set; }
        [Description("Mã XN")]
        public string Maxn { get; set; }
        [Description("Id máy xét nghiệm")]
        public int Idmayxn { get; set; } = 0;
        [Description("Kết quả xét nghiệm")]
        public string Ketqua { get; set; }
        [Description("So sánh tuyệt đối")]
        public bool Sosanhtuyetdoi { get; set; } = false;
        [Description("Giới tính")]
        public string Gioitinh { get; set; }
        [Description("Nội dung ghi chú")]
        public string Ghichu { get; set; }
        [Description("Loại sao sánh giá trị")]
        public int Loaigiatrisosanh { get; set; } = 1;
        [Description("Người tạo")]
        public string Nguoinhap { get; set; }
        [Description("TG tạo")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_GHICHUTUDONG() { }
        public DM_XETNGHIEM_GHICHUTUDONG Copy()
        {
            return (DM_XETNGHIEM_GHICHUTUDONG)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_GHICHUTUDONG objCompare)
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
