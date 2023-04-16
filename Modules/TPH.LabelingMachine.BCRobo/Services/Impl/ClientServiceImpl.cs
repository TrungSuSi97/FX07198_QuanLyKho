using TPH.LabelingMachine.BCRobo.Connection;
using TPH.LabelingMachine.BCRobo.Models;

namespace TPH.LabelingMachine.BCRobo.Services.Impl
{
    public class ClientServiceImpl : IClientService
    {
        private static LisReceiverConnection _client =null;
        public ClientServiceImpl(string receiverUrl)
        {
            _client = LisReceiverConnection.GetInstance(receiverUrl);
        }
        public string CancelPatientByOrderId(string OrderID)
        {
            return _client.CancelPatientByOrderId(OrderID);
        }
        public string SavePatientInfo( PatientInfo patientInfo)
        {
            return _client.SavePatientInfo(patientInfo);
        }
    }
}
