using System.Collections.Generic;
using System.Data;

namespace TPH.Lab.Middleware.HISConnect.Models
{
    public class HISReturnBase
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public DataTable Data { get; set; }
    }
    public class InsertPatientFromHISBase
    {
        public List<string> lstBarcodeFinish { get; set; }
    }
}
