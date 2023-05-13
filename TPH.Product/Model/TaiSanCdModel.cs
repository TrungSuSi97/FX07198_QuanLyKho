using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Model
{
    public class TaiSanCdModel
    {
        public int AutoID { get; set; }

        public string MaTaiSan { get; set; }

        public string TenTaiSan { get; set; }
        public int Quantity { get; set; }
        public string TinhTrang { get; set; }
        public string DonViSuDung { get; set; }

    }
}
