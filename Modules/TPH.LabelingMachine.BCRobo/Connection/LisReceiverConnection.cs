using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using TPH.LabelingMachine.BCRobo.Extensions;
using TPH.LabelingMachine.BCRobo.Models;
using TPH.LabelingMachine.BCRobo.Services;
namespace TPH.LabelingMachine.BCRobo.Connection
{
    public class LisReceiverConnection
    {
        private static LogExtension _logExtension = new LogExtension();

        private ChannelFactory<ILisReceiver> _factory = null;

        private ILisReceiver _webserviceClient = null;

        private static LisReceiverConnection _instance = null;
        private static string _receiverUrl = string.Empty;

        public static LisReceiverConnection GetInstance(string receiverUrl)
        {
            return _instance ?? (_instance = new LisReceiverConnection(receiverUrl));
        }

        private LisReceiverConnection(string roboIp)
        {
            _receiverUrl = roboIp;
        }
        
        public ILisReceiver GetLisReceiver()
        {
            if (_factory == null)
            {
                var webHttpBinding = new WebHttpBinding
                {
                    MaxBufferPoolSize = 2147483647,
                    MaxBufferSize = 2147483647,
                    MaxReceivedMessageSize = 2147483647,
                    ReaderQuotas =
                    {
                        MaxDepth = 2147483647,
                        MaxArrayLength = 2147483647,
                        MaxStringContentLength = 2147483647,
                        MaxBytesPerRead = 2147483647,
                        MaxNameTableCharCount = 2147483647
                    }
                };

                _factory = new ChannelFactory<ILisReceiver>(webHttpBinding, _receiverUrl);

                _factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
                _factory.Endpoint.Behaviors.Add(new LoggingEndpointBehavior());
            }

            return _webserviceClient ?? (_webserviceClient = _factory.CreateChannel());
        }

        public string SavePatientInfo(PatientInfo patientInfo)
        {
            var errorMessage = string.Empty;
            try
            {
                WriteLog.LogService.RecordLogFile("BCRoboInsert", string.Format("Try to save PatientInfo: {0}", patientInfo));
                errorMessage = GetLisReceiver().SavePatientInfo(patientInfo);
                WriteLog.LogService.RecordLogFile("BCRoboInsert", errorMessage);
                WriteLog.LogService.RecordLogFile("BCRoboInsert", string.Format("Succeed in saving PatientInfo: {0}", patientInfo));
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogError("", "BCRoboInsert", ex);
                errorMessage = ex.Message;
            }

            return errorMessage;
        }
        
        public string CancelPatientByOrderId(string orderId)
        {
            var errorMessage = string.Empty;
            try
            {
                WriteLog.LogService.RecordLogFile("BCRoboInsert", string.Format("Try to save CancelPatientByOrderId: orderId:{0}", orderId));
                errorMessage = GetLisReceiver().CancelPatientByOrderId(orderId);
                WriteLog.LogService.RecordLogFile("BCRoboInsert", errorMessage);
                WriteLog.LogService.RecordLogFile("BCRoboInsert", string.Format("Succeed in saving CancelPatientByOrderId: orderId:{0}", orderId));
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogError("", "BCRoboInsert", ex);
                errorMessage = ex.Message;
            }

            return errorMessage;
        }

        public string CancelPatient(CancelPatientReceiverRequest request)
        {
            var errorMessage = string.Empty;
            try
            {
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", string.Format("Try to save CancelPatient: {0}", request));
                errorMessage = GetLisReceiver().CancelPatient(request);
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", errorMessage);
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", string.Format("Succeed in saving CancelPatient: {0}", request));
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogError("", "BCRoboInsert", ex);
                errorMessage = ex.Message;
            }

            return errorMessage;
        }

        public string CancelTest(CancelTestReceiverRequest request)
        {
            var errorMessage = string.Empty;
            try
            {
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", string.Format("Try to save CancelTest: {0}", request));
                errorMessage = GetLisReceiver().CancelTest(request);
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", errorMessage);
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", string.Format("Succeed in saving CancelTest: {0}", request));
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogError("", "BCRoboInsert", ex);
                errorMessage = ex.Message;
            }

            return errorMessage;
        }

        public string UpdateTestStatus(UpdateStatusReceiverRequest request)
        {
            var errorMessage = string.Empty;
            try
            {
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", string.Format("Try to save UpdateTestStatus: {0}", request));
                errorMessage = "Chức năng chưa được mở!";
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", errorMessage);
                WriteLog.LogService.RecordLogFile("BCRoboInsert_Cancel", string.Format("Succeed in saving UpdateTestStatus: {0}", request));
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogError("", "BCRoboInsert", ex);
                errorMessage = ex.Message;
            }

            return errorMessage;
        }
    }
}