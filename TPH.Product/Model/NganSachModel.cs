using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Model
{
    public class NganSachModel
    {
        public int AutoID { get; set; }
        public string MaNganSach { get; set; }

        public decimal TienMatHienCo { get; set; }
        public decimal NguonVonBank { get; set; }
        public decimal TienHangKho { get; set; }
        public decimal DoanhThuDaBan { get; set; }
        public decimal NganSachNhapHang { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime InTime { get; set; }


    }
}
