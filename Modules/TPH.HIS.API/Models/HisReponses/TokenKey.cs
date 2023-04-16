using System;

namespace TPH.HIS.WebAPI.Models.HisReponses
{
    public class TokenKey
    {
        public string access_token { get; set; }
        public DateTime expires_in { get; set; }
        public string token_type { get; set; }
    }
}
