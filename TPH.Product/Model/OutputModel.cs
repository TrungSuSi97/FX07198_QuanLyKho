using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Model
{
    public class OutputModel
    {
        public int OutID { get; set; }
        public string OutCode { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string UserI { get; set; }
        public DateTime Intime { get; set; }
        public decimal Total { get; set; }
        public int StoreID { get; set; }
        public int ProviderID { get; set; }
        public int StorePositionID { get; set; }
        public int OrderID { get; set; }

    }

    public class OutputDetailModel
    {
        public int AutoID { get; set; }
        public int InID { get; set; }
        public int OutID { get; set; }

        public string OutCode { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public decimal Total { get; set; }
        public int OrderID { get; set; }
        public int OrderDetailid { get; set; }

    }
}
