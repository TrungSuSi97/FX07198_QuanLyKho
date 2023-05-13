using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Model
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string UserI { get; set; }
        public DateTime Intime { get; set; }
        public decimal Total { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string GhiChu { get; set; }
        public string DiaChi { get; set; }
        public string TenKhachHang { get; set; }
        public string DienThoai { get; set; }


    }

    public class OrderDetailModel
    {
        public int AutoID { get; set; }
        public int OrderID { get; set; }
        public string OrderCode { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public decimal Total { get; set; }

    }
}
