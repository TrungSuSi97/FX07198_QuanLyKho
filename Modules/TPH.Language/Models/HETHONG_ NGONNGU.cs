using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Language.Models
{
    #region HeThong_NgonNgu
    public class HETHONG_NGONNGU
    {
        public int? Id{ get; set; }
        public string Idtungu { get; set; }

        public string Defaultlang { get; set; }

        public string Vn { get; set; }

        public string Eng { get; set; }
        public HETHONG_NGONNGU Copy()
        {
            return (HETHONG_NGONNGU)this.MemberwiseClone();
        }
     
    }
    #endregion
}
