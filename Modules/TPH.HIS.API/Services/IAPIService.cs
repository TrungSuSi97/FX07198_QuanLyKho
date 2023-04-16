using TPH.HIS.WebAPI.Models.HisReponses;
using TPH.HIS.WebAPI.Models.Params;

namespace TPH.HIS.WebAPI.Services
{
    public interface IWebAPIService
    {
        ResultResponse GetListOfTest(LisRequestParams requestParams);
        ResultResponse GetListOfTestISOFH(LisRequestParams requestParams);
        ResultResponse GetListOfDoctor(LisRequestParams requestParams);
        ResultResponse GetListOfDepartment(LisRequestParams requestParams);
        ResultResponse GetListOfRoom(LisRequestParams requestParams);
        ResultResponse GetListOfCurrentDepartment(LisRequestParams requestParams);
        ResultResponse GetListOfDiagnose(LisRequestParams requestParams);
        ResultResponse GetListOfObject(LisRequestParams requestParams);
        ResultResponse GetListOfCompany(LisRequestParams requestParams);

        ResultResponse GetOrders(LisRequestParams requestParams);
        ResultResponse GetOrderByPatient(LisRequestParams requestParams);
        ResultResponse GetBarcode(LisRequestParams requestParams);
        ResultResponse UpdateOrderStatus(LisRequestParams requestParam);
        ResultResponse UploadResult(LisRequestParams requestParams, int retry = 0, string actionDescription = "");
        ResultResponse UploadResultSoiNhuom(LisRequestParams requestParams);
        ResultResponse UploadResultNuoiCay(LisRequestParams requestParams);
        ResultResponse UploadResultGiaiPhauBenh(LisRequestParams requestParams);

        ResultResponse UpdatePatientInfo(string data, string token = "");
        ResultResponse PatientInfomation(LisRequestParams requestParams);
        ResultResponse UpdateFinishOrderStatus(LisRequestParams pararequest);
        ResultResponse GetTokenKey(LisRequestParams requestParams);
        ResultResponse GetListOfPartner(LisRequestParams requestParams);
        ResultResponse AddReception(LisRequestParams requestParams);
        ResultResponse GetResult(LisRequestParams requestParams);
        ResultResponse AddAssignation(LisRequestParams requestParams);
        ResultResponse DeleteAssgnation(LisRequestParams requestParams);
        ResultResponse UploadResultFile(LisRequestParams requestParams);
    }
}