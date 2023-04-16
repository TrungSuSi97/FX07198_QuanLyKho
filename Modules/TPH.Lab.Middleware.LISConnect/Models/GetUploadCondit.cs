using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Lab.Middleware.LISConnect.Models
{
    public class GetUploadCondit
    {
        public string userID { get; set; }
        public string matiepnhan { get; set; }
        public bool onlyValid { get; set; }
        public bool onlyPrinted { get; set; }
        public string[] arrCatePrint { get; set; }
        public string[] arrtestCodePrint { get; set; }
        public string[] arrTestTypeID { get; set; }
        public bool frombackup { get; set; }
        public bool manualUpload { get; set; }
        public bool forStatus { get; set; }
    }
}
