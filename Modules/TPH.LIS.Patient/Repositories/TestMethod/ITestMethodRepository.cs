namespace TPH.LIS.Patient.Repositories.TestMethod
{
    public interface ITestMethodRepository
    {
        void UpdatePrintedInfoOfTestResult(string reciverCode, string userId);

        void UpdatePrintedInfoOfXRayResult(string reciverCode, string userId);

        void UpdatePrintedInfoOfSupersonicResult(string reciverCode, string userId, string color);
    }
}
