namespace TPH.ViettelSignCertificate.Models.Responses
{
    public class CerInfoResponse: BaseResult
    {
        public string Company { get; set; }
        public string ISSUER { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
    }
}
