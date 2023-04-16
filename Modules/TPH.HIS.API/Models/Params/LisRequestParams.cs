using System;
using System.Collections.Generic;

namespace TPH.HIS.WebAPI.Models.Params
{
    public class LisRequestParams
    {
        public string APIName { get; set; }
        public int HisId { get; set; }
        public string ClientName { get; set; }
        public string WebMethod { get; set; }

        public Dictionary<string, dynamic> Param { get; set; }
        public List<Dictionary<string, dynamic>> lstParam { get; set; }
        public string HisUrl { get; set; }
        public string HisUser { get; set; }
        public string HisPassword { get; set; }
        public string LisUrl { get; set; }
        public string LisPassword { get; set; }
        public string LisUser { get; set; }
        public bool UseToken { get; set; }
        public string Access_token { get; set; }
        public DateTime Expires_in { get; set; }
        public string Token_type { get; set; }
        public bool ConvertJObject { get; set; }
    }
}
