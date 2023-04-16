namespace TPH.ViettelSignCertificate.Models.Requests
{
    public class GetCerInfoRequest: BaseSignRequest
    {
        public string SerialNumber { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ApiUrl) && 
                   !string.IsNullOrWhiteSpace(AppCode) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(SerialNumber);
        }
    }
}
