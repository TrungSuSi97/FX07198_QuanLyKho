using System.Collections.Generic;

namespace TPH.HIS.WebAPI.Models.HisReponses
{
    public class BaseHisResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
     public class ResultResponse: BaseHisResponse
    {
        public ResultResponse():this(null)
        {
        }

        public ResultResponse(dynamic obj)
        {
        //    Data = new List<dynamic>();
        }
    }
   
}
