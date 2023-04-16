using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TPH.HIS.WebAPI.Configs;
using TPH.HIS.WebAPI.Constants;
using TPH.HIS.WebAPI.DataAccess;
using TPH.HIS.WebAPI.DataAccess.Impl;
using TPH.HIS.WebAPI.Extensions;
using TPH.HIS.WebAPI.Models;
using TPH.HIS.WebAPI.Models.HisReponses;
using TPH.HIS.WebAPI.Models.Logs;
using TPH.HIS.WebAPI.Models.Params;
using TPH.WriteLog;
using System.Linq;
using System.Diagnostics;

namespace TPH.HIS.WebAPI.Services.Impl
{
    public class WebAPIServiceImpl: IWebAPIService
    {
        private readonly ILisDataAccess _lisDataAccess;
        private readonly ILogDataAccess _logDataAccess;
        private void WriteLog_Final(string errorMessage, LisRequestParams requestParams, 
            string outputMessage, string inputMessage, string requestUrl)
        {
            var paraForUrl = (requestParams.WebMethod.ToUpper() == "GET" ? string.Format("?{0}", (requestParams.Param == null
              ? string.Empty
              : requestParams.Param.Aggregate(string.Empty,
                  (current, p) => current + (string.IsNullOrEmpty(current) ? "" : "&") +
                                  string.Format("{0}={1}", p.Key, p.Value)))) : string.Empty);
            var errMessage = string.IsNullOrEmpty(errorMessage) ? "" : string.Format("ErrorMessage:\n{0}\n", errorMessage);
            _logDataAccess.InsertHisTracking(new LogMessageModel()
            {
                Action = requestParams.WebMethod.ToUpper(),
                ErrorMessage = errorMessage,
                Username = requestParams.ClientName,
                OutputMessage = outputMessage,
                InputMessage = $"{(requestParams.WebMethod.ToUpper() == "GET" ? paraForUrl : inputMessage)}\nURL:\n{requestUrl}\nAPI:{requestParams.APIName} - Method:{requestParams.WebMethod.ToUpper()}",
                Ip = Client.Ip()
            });
            LogService.RecordLogFile(string.Format("WebAPI_HISID_{0}_", requestParams.HisId.ToString()),
                $"{errMessage}InputMessage:\n{(requestParams.WebMethod.ToUpper() == "GET" ? paraForUrl : inputMessage)}\nOutputMessage:\n{outputMessage}\nURL:\n{requestUrl}"
                 , string.Format("{0} - Phương thức: {1}", requestParams.APIName, requestParams.WebMethod.ToUpper()));
        }
        public WebAPIServiceImpl() : this(null, null)
        {

        }

        public WebAPIServiceImpl(ILisDataAccess lisDataAccess, ILogDataAccess logDataAccess)
        {
            _lisDataAccess = lisDataAccess ?? new LisDataAccessImpl();
            _logDataAccess = logDataAccess ?? new LogDataAccessImpl();
        }
        
        public ResultResponse GetListOfTest(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucXetNghiem>>(requestParams);
        }
        public ResultResponse GetListOfTestISOFH(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhSachXetNghiemISofH>>(requestParams);
        }

        public ResultResponse GetListOfDoctor(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucBacSi>>(requestParams);
        }

        public ResultResponse GetListOfDepartment(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucKhoa>>(requestParams);
        }

        public ResultResponse GetListOfRoom(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucPhong>>(requestParams);
        }

        public ResultResponse GetListOfCurrentDepartment(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucKhoaHienThoi>>(requestParams);
        }

        public ResultResponse GetListOfDiagnose(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucChanDoan>>(requestParams);
        }

        public ResultResponse GetListOfObject(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucDoiTuong>>(requestParams);
        }

        public ResultResponse GetListOfCompany(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucCongTy>>(requestParams);
        }

        public ResultResponse GetOrders(LisRequestParams requestParams)
        {
            return CallMethod<List<ChiDinh>>(requestParams);
        }

        public ResultResponse GetOrderByPatient(LisRequestParams requestParams)
        {
            return CallMethod<List<ChiDinhBenhNhan>>(requestParams);
        }

        public ResultResponse GetBarcode(LisRequestParams requestParams)
        {
            return CallMethod<List<BarCodeChiDinh>>(requestParams);
        }

        public ResultResponse UpdateOrderStatus(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }

        public ResultResponse UploadResult(LisRequestParams requestParams, int retry = 0, string actionDescription = "")
        {
            return CallMethod<List<string>>(requestParams, retry, actionDescription);
        }

        public ResultResponse UploadResultSoiNhuom(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }

        public ResultResponse UploadResultNuoiCay(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }

        public ResultResponse UploadResultGiaiPhauBenh(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }
        public ResultResponse UpdateFinishOrderStatus(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }
        public ResultResponse PatientInfomation(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }
        public ResultResponse GetTokenKey(LisRequestParams requestParams)
        {
            return CallMethod<List<TokenKey>>(requestParams);
        }
        public ResultResponse UpdatePatientInfo(string data, string token = "")
        {
            var inputMessage = string.Empty;
            var result = new ResultResponse();
            var outputMessage = string.Empty;
            var errorMessage = string.Empty;
            var requestUrl = string.Empty;

            try
            {
                inputMessage = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}";

                var configs = GetApiConfigs(ApiConstant.HisId);
                if (!ValidApiConfigs(configs))
                {
                    return new ResultResponse()
                    {
                        Code = ApiMessageConstant.Fail,
                        Message = ApiMessageConstant.LayThongTinCauHinhHiLisThatBai
                    };
                }
                
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<JsonConverter> { new CamelCaseOnlyConverter() }
                };

                var patient = JsonConvert.DeserializeObject<PatientParams>(data, settings);
                var success = _lisDataAccess.UpdatePatientInfo(patient);
                result = new ResultResponse()
                {
                    Code = success ? ApiMessageConstant.Success : ApiMessageConstant.Fail,
                    Message = success ? ApiMessageConstant.ThanhCong : ApiMessageConstant.ThatBai
                };
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                LogService.RecordLogError(string.Empty, "WebAPI_UpdateADT_FromHIS", ex);
                result = new ResultResponse()
                {
                    Code = ApiMessageConstant.Fail,
                    Message = ex.Message
                };
            }
            finally
            {
                outputMessage = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} > {result.Message}";

                Task.Factory.StartNew(() => {
                    _logDataAccess.InsertHisTracking(new LogMessageModel()
                    {
                        Action = requestUrl,
                        InputMessage = inputMessage,
                        OutputMessage = outputMessage,
                        Ip = Client.Ip(),
                        ErrorMessage = errorMessage,
                        Username = string.Empty
                    });
                });
            }

            return result;
        }
        public ResultResponse GetListOfPartner(LisRequestParams requestParams)
        {
            return CallMethod<List<DanhMucDonViGuiMau>>(requestParams);
        }
        public ResultResponse AddReception(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }

        public ResultResponse GetResult(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }
        public ResultResponse AddAssignation(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }

        public ResultResponse DeleteAssgnation(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }
        public ResultResponse UploadResultFile(LisRequestParams requestParams)
        {
            return CallMethod<List<string>>(requestParams);
        }
        private ResultResponse CallMethod<T>(LisRequestParams requestParams, int retry = 0, string actionDescription = "")
        {
            var inputMessage = string.Empty;
            var outputMessage = string.Empty;
            var errorMessage = string.Empty;
            var requestUrl = string.Empty;
            var response = new ResultResponse()
            {
                Code = ApiMessageConstant.Fail,
                Message = ApiMessageConstant.ErrorUnknow,
                Data = null
            };

            try
            {
                var configs = GetApiConfigs(requestParams.HisId);
                if (!ValidApiConfigs(configs))
                {
                    return new ResultResponse()
                    {
                        Code = ApiMessageConstant.Fail,
                        Message = ApiMessageConstant.LayThongTinCauHinhHiLisThatBai
                    };
                }
                var arrURL = requestParams.APIName.Split('|');
                if(arrURL.Length > 1)
                {
                    requestParams.APIName = arrURL[0].Trim();
                    configs.ContentType = arrURL[1].Trim();
                }
                if (requestParams.UseToken && !string.IsNullOrEmpty(requestParams.Token_type) && !string.IsNullOrEmpty(requestParams.Access_token))
                {
                    configs.UseToken = requestParams.UseToken;
                    configs.Access_token = requestParams.Access_token;
                    configs.Token_type = requestParams.Token_type;
                }
                configs.ConvertToJObject = requestParams.ConvertJObject;
                var jsonParams = string.Empty;
                var drawData = new BaseResult();
                if (requestParams.Param != null)
                {
                    jsonParams = $"{DateTime.Now} > {JsonConvert.SerializeObject(requestParams.Param)}";
                    inputMessage = $"{jsonParams}";
                    requestUrl = $"{configs.HisUrl}/{requestParams.APIName}";
                    drawData = WebExtension.Call(requestUrl, requestParams.Param,
                   0, requestParams.WebMethod,
                   configs);
                }
                else if (requestParams.lstParam != null)
                {
                    jsonParams = $"{DateTime.Now} > {JsonConvert.SerializeObject(requestParams.lstParam)}";
                    inputMessage = (string.IsNullOrEmpty(actionDescription) ? $"{jsonParams}" : $"Action:{actionDescription}{Environment.NewLine}{jsonParams}");
                    requestUrl = $"{configs.HisUrl}/{requestParams.APIName}";
                    drawData = WebExtension.Call(requestUrl, requestParams.lstParam,
                   0, requestParams.WebMethod,
                   configs);
                }

                outputMessage = $"{DateTime.Now} > {drawData.Message}";
                var drawMessage = drawData.Message;
                if (requestParams.HisId == 22 || requestParams.HisId == 25)
                {
                    if (drawMessage != null)
                    {
                        if (drawMessage != "[]")
                        {
                            if (!drawMessage.Contains("\"Data\"") && !drawMessage.Contains("\"data\""))
                            {
                                drawMessage = "{" + String.Format("\"Data\":{0}", drawMessage) + "}"; ;
                            }
                        }
                    }
                }
                else if (requestParams.HisId != 10)
                {
                    if (drawMessage != null)
                    {
                        //Không phải là isofh
                        if (drawMessage.Contains("\"ketqua\""))
                        {
                            outputMessage += " => Auto change \"ketqua\" => \"Data\"";
                            drawMessage = drawMessage.Replace("\"ketqua\"", "\"Data\"");
                        }
                        else if (drawMessage.Contains("\"access_token\"") && !drawMessage.ToLower().Contains("{\"data\":"))
                        {
                            outputMessage += " => Auto add \"access_token\" => \"Data\"";
                            drawMessage = drawMessage.Replace("{\"access_token\"", "{\"Data\":[{\"access_token\"") + "]}";
                        }
                    }
                }
                 
                response.Code = drawData.Code;
                response.Message = drawMessage;

                if (drawData.Code != ApiMessageConstant.Success || 
                    string.IsNullOrEmpty(drawData.Message) || drawData.Message == "[]")
                {
                    return response;
                }
                JObject jobject = JObject.Parse(drawMessage);
                response = JsonConvert.DeserializeObject<ResultResponse>(jobject.ToString());
                if (response.Data != null && !(response.Data is string))
                {
                    if (!(response.Data is bool))
                    {
                        if (response.Data.Count <= 0)
                            response.Data = JsonConvert.DeserializeObject<dynamic>(response.Data);
                    }
                }
            }
            catch (Exception ex)
            {
               LogService.WriteException(ex);
                errorMessage = ex.Message;
            }
            finally
            {
                WriteLog_Final(errorMessage, requestParams, outputMessage, inputMessage, requestUrl);
            }

            return response;
        }
        private SystemConfigModel GetApiConfigs(int hisId)
        {
            var configs = CachingExtension.Get<SystemConfigModel>(HisApiCommonConfigs.SystemConfigCacheKey);
            if (configs != null)
            {
                if (configs.HisID.Equals(hisId))
                    return configs;
            }
            return _lisDataAccess.GetSystemConfig(hisId);
        }

        private bool ValidApiConfigs(SystemConfigModel configs)
        {
            return configs != null && !string.IsNullOrEmpty(configs.HisUrl);
        }

    }
}