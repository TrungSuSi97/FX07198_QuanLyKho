using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Model
{
    public class CongNoModel
    {
        public int AutoID { get; set; }

        public string MaCongNo { get; set; }

        public string LoaiHoaDon { get; set; }
        public string MaHoaDon { get; set; }
        public string ThongTinKhachHang { get; set; }
        public decimal CongNoPhaiTra { get; set; }
        public DateTime ThoiHanTra { get; set; }



    }
}
