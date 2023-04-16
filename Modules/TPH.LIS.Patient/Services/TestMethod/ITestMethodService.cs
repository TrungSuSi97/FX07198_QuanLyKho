namespace TPH.LIS.Patient.Services.TestMethod
{
    public interface ITestMethodService
    {
        void UpdatePrintedInfoOfTestResult(string reciverCode, string userId);

        void UpdatePrintedInfoOfXRayResult(string reciverCode, string userId);

        void UpdatePrintedInfoOfSupersonicResult(string reciverCode, string userId, string color);
    }
}
