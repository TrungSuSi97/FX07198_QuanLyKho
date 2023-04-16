using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_sinhly
    public class DM_SINHLY
    {
        [Description("Mã sinh lý")]
        public string Masinhly { get; set; }
        [Description("Tên sinh lý")]
        public string Tensinhly { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_SINHLY Copy()
        {
            return (DM_SINHLY)this.MemberwiseClone();
        }
    }
    #endregion
}
