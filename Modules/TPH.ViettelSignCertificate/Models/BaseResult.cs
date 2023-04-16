namespace TPH.ViettelSignCertificate.Models
{
    public class BaseResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public BaseResult() : this(0, null)
        {
        }

        public BaseResult(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
