namespace TPH.Lab.Middleware.Helpers
{
    public class AddressHttpWebRequestHelper
    {
        public string Order_URL { get; set; }
        public string Result_URL { get; set; }
        public string OrderList_URL { get; set; }
        public string Received_URL { get; set; }
        public string Running_URL { get; set; }
        public string Release_URL { get; set; }
        public string ReleaseHostname_URL { get; set; }
    }
    public class PathShareDriverHelper
    {
        public string Order_Path { get; set; }
        public string Result_Path { get; set; }
        public string OrderBackup_Path { get; set; }
        public string ResultBackup_Path { get; set; }
        public string DownloadOrder_Path { get; set; }
        public string DownloadOrderBackup_Path { get; set; }
        public string DownloadResult_Path { get; set; }
        public string DownloadResultBackup_Path { get; set; }
       
    }
    public class MachineHelper
    {
        public int MachineID { get; set; }
        public string Protocol { get; set; }
        public string MachineName { get; set; }
        public bool AutoSendOrder { get; set; }
        public int TimerScanAutoSendOrder { get; set; }
        public int TimeSend { get; set; }
        public bool ScanDownloadOrder { get; set; }
        public int TimerScanDownloadOrder { get; set; }
        public bool ScanReceiveOrder { get; set; }
        public int TimerScanReceiveOrder { get; set; }
        public bool ScanReceiveResult { get; set; }
        public int TimerScanReceiveResult { get; set; }
    }
}
