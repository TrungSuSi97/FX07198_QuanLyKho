using System;

namespace TPH.HIS.WebAPI.Models
{
    [Serializable]
    public class SystemConfigModel
    {
        public int HisID { get; set; }
        public string HisUrl { get; set; }
        public string HisDatabaseName { get; set; }
        public string HisUser { get; set; }
        public string HisPassword { get; set; }
        public string HisPort { get; set; }
        public string LisUrl { get; set; }
        public string LisUser { get; set; }
        public string LisPassword { get; set; }

        public bool UseToken { get; set; }
        public string Access_token { get; set; }
        public DateTime Expires_in { get; set; }
        public string Token_type { get; set; }
        public string ContentType { get; set; }
        public bool ConvertToJObject  { get; set; }
    }
}
