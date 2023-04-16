namespace TPH.ViettelSignCertificate.Models.Requests
{
    public class SignTimestampConfigRequest
    {
        public string TsaAccount { get; set; }
        public string TsaPassword { get; set; }
        public string TsaUrl { get; set; }
        public string UseTimestamp { get; set; }
    }
}
