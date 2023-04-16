namespace TPH.HIS.WebAPI.Models.Logs
{
    public class LogMessageModel
    {
        public string MessageId { get; set; }
        public string Action { get; set; }
        public string InputMessage { get; set; }
        public string OutputMessage { get; set; }
        public string Ip { get; set; }
        public string ErrorMessage { get; set; }
        public string Username { get; set; }
        public string LogDate { get; set; }
    }
}
