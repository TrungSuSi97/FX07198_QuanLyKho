using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Model
{
    public class HopDongModel
    {
        public int AutoID { get; set; }

        public string MaHopDong { get; set; }

        public string NoiDung { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime InTime { get; set; }
        public DateTime ThoiGianKyKet { get; set; }
        public DateTime ThoiGianThucHien { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }


    }
}
