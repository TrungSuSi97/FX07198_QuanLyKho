using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Model
{
    public class InputModel
    {
        public int InID { get; set; }
        public string InCode { get; set; }
        public DateTime DateIn { get; set; }
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
        public string StoreID { get; set; }
        public string ProviderID { get; set; }
        public string StorePositionID { get; set; }


    }

    public class InputDetailModel
    {
        public int AutoID { get; set; }
        public int InID { get; set; }
        public string InCode { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int QuantityOut { get; set; }

        public decimal Cost { get; set; }

        public decimal Total { get; set; }

    }
}
