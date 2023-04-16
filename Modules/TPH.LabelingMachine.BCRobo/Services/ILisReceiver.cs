using System.ServiceModel;
using System.ServiceModel.Web;
using TPH.LabelingMachine.BCRobo.Models;

namespace TPH.LabelingMachine.BCRobo.Services
{
    /// <summary>
    /// Contract kết nối với LIS
    /// </summary>
    [ServiceContract]
    public interface ILisReceiver
    {
        /// <summary>
        /// Lưu thông tin bệnh nhân khám để LIS xử lý
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string SavePatientInfo(PatientInfo result);

        /// <summary>
        /// Cancel toàn bộ phiếu
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
            ResponseFormat = WebMessageFormat.Json, UriTemplate = "CancelPatientByOrderId?orderId={orderId}")]
        string CancelPatientByOrderId(string orderId);

        /// <summary>
        /// Cancel toàn bộ phiếu
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string CancelPatient(CancelPatientReceiverRequest request);

        /// <summary>
        /// Cancel chỉ định trong phiếu
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="madv"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string CancelTest(CancelTestReceiverRequest request);

        /// <summary>
        /// Cập nhật trạng thái chỉ định
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="madv"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdateTestStatus(UpdateStatusReceiverRequest request);

        /// <summary>
        /// Lấy kết quả xét nghiệm với sampleId định sẵn
        /// </summary>
        /// <param name="sampleId">Mã xét nghiệm của bệnh nhân</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetSamplingResult?sampleId={sampleId}")]
        SamplingResultResponse GetSamplingResult(string sampleId);

        /// <summary>
        /// Lấy kết quả xét nghiệm với sampleId định sẵn
        /// </summary>
        /// <param name="sampleId">Mã xét nghiệm của bệnh nhân</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetSamplingRequest?sampleId={sampleId}")]
        SamplingTestResponse GetSamplingRequest(string sampleId);

        /// <summary>
        /// Lấy danh sách các sampleId của một bệnh nhân với ngày định sẵn, chỉ trong khoảng lưu của hệ thống. Quá thời gian archive sẽ không được trả về
        /// </summary>
        /// <param name="patientId">Mã bệnh nhân</param>
        /// <param name="dateRequestFrom">Ngày bắt đầu yêu cầu format yyyyMMdd</param>
        /// <param name="dateRequestTo">Ngày kết thúc yêu cầu format yyyyMMdd</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetSamplingHistory?patientId={patientId}&dateRequestFrom={dateRequestFrom}&dateRequestTo={dateRequestTo}")]
        SamplingHistoryResponse GetSamplingHistory(string patientId, string dateRequestFrom, string dateRequestTo);

        /// <summary>
        /// Lấy thông tin user
        /// </summary>
        /// <param name="userId">userid</param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetUserInfo?userId={userId}")]
        UserInfoResponse GetUserInfo(string userId);
    }
}
