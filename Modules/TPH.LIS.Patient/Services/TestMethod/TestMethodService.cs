using TPH.LIS.Patient.Repositories.TestMethod;

namespace TPH.LIS.Patient.Services.TestMethod
{
    public class TestMethodService : ITestMethodService
    {
        private readonly ITestMethodRepository _testMethodRepository;

        public TestMethodService(): this(null)
        {
            
        }

        public TestMethodService(TestMethodRepository testMethodRepository)
        {
            _testMethodRepository = testMethodRepository ?? new TestMethodRepository();
        }

        public void UpdatePrintedInfoOfTestResult(string reciverCode, string userId)
        {
            _testMethodRepository.UpdatePrintedInfoOfTestResult(reciverCode, userId);
        }

        public void UpdatePrintedInfoOfXRayResult(string reciverCode, string userId)
        {
            _testMethodRepository.UpdatePrintedInfoOfXRayResult(reciverCode, userId);
        }

        public void UpdatePrintedInfoOfSupersonicResult(string reciverCode, string userId, string color)
        {
            _testMethodRepository.UpdatePrintedInfoOfSupersonicResult(reciverCode, userId, color);
        }
    }
}
