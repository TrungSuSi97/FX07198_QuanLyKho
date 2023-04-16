using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TPH.Data.HIS.Models;

namespace TPH.Data.HIS
{
    public interface IHL7v25Service
    {
        DataTable DataOrderFromHL7Message(string HL7Message);
        DataTable DataResultFromHL7Message(string HL7Message);
        object Get_ObjectPrpertyValue(object objInfo, string propertiesName);
        string DataResultToHL7(List<HL7ResultUpload> dataUpload);
        string DataOrderStatusToHL7(List<HL7ResultUpload> dataUpload);
    }
}
