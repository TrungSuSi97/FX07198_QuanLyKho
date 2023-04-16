namespace TPH.LIS.Configuration.Models
{
    public class EmailConfigDetail
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string MailFrom { get; set; }
        public string MailBody { get; set; }
        public string SmptServer { get; set; }
        public string PdfPath { get; set; }
    }
}
