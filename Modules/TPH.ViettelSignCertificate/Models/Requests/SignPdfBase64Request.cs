namespace TPH.ViettelSignCertificate.Models.Requests
{
    public class SignPdfBase64Request: BaseSignRequest
    {
        public string SerialNumber { get; set; }
        public string FileContent { get; set; }
        public string DigestAlgorithm { get; set; } = "SHA-1";

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ApiUrl) &&
                   !string.IsNullOrWhiteSpace(AppCode) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(SerialNumber) &&
                   !string.IsNullOrWhiteSpace(FileContent);
        }
    }
}
