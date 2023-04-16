using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using TPH.HIS.WebAPI.Models;
using TPH.HIS.WebAPI.Configs;
using TPH.HIS.WebAPI.Constants;
using TPH.WriteLog;
using Newtonsoft.Json.Linq;

namespace TPH.HIS.WebAPI.Extensions
{
    public class WebExtension
    {
        private static readonly LogExtension LogExtension;
        private const string SslError = "Could not create SSL/TLS secure channel."; private const int MaxRetryTimes = 3;
        private static readonly string AuthenKey = "Authorization";
        private static readonly string BasicAuthen = "Basic";

        public static BaseResult Call(string url, Dictionary<string, dynamic> parameters,
            int currentRetryTimes = 0, string method = "GET", SystemConfigModel configs = null)
        {
            method = method.ToUpper();
            if (method.Equals("GET"))
            {
                return Get(url, parameters, currentRetryTimes, configs);
            }
            //else if (method.Equals("POST"))
            //{
            //    return Post(url, parameters, currentRetryTimes, configs);
            //}
            else
            {
                return ActionWithJsonBody(url, parameters, method, currentRetryTimes, configs);
            }
        }
        public static BaseResult Call(string url, List<Dictionary<string, dynamic>> parameters,
         int currentRetryTimes = 0, string method = "GET", SystemConfigModel configs = null)
        {
            method = method.ToUpper();
            if (method.Equals("GET"))
            {
                return Get(url, parameters.FirstOrDefault(), currentRetryTimes, configs);
            }
            //else if (method.Equals("POST"))
            //{
            //    return Post(url, parameters, currentRetryTimes, configs);
            //}
            else 
            {
                return ActionWithJsonBody(url, parameters, method, currentRetryTimes, configs);
            }
        }
        #region Action with json body
        public static BaseResult ActionWithJsonBody(string url, Dictionary<string, dynamic> parameters, string method,  int currentRetryTimes = 0, SystemConfigModel configs = null)
        {
            try
            {
                #region add token - user - password
                parameters = CreateAuthenParam(parameters, configs);
                #endregion

                var request = CreateRequestingHeader(url, configs);
                request.Method = method.ToUpper();
                if (request.ContentType.ToLower().Equals("application/x-www-form-urlencoded"))
                {
                    var dataPost = "";
                    foreach (var item in parameters)
                    {
                        dataPost += (string.IsNullOrEmpty(dataPost) ? "" : "&") + string.Format("{0}={1}", item.Key, item.Value);
                    }
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(dataPost);
                        streamWriter.Flush();
                    }
                }
                else
                {
                    if (configs.ConvertToJObject)
                    {
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(JObject.Parse(JsonConvert.SerializeObject(parameters)));
                            streamWriter.Flush();
                        }
                    }
                    else
                    {
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(JsonConvert.SerializeObject(parameters));
                            streamWriter.Flush();
                        }
                    }
                }
                var response = request.GetResponse() as HttpWebResponse;

                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseResult(ApiMessageConstant.Success, content);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(SslError) && currentRetryTimes <= MaxRetryTimes)
                {
                    return ActionWithJsonBody(url, parameters, method, (currentRetryTimes += 1));
                }
                LogService.RecordLogError($"Web API Error: [{method.ToUpper()}]\n {ex.Message}");
                return HandleException(ex, $"[{method.ToUpper()}]\n {url}");
            }
        }
        public static BaseResult ActionWithJsonBody(string url, List<Dictionary<string, dynamic>> parameters, string method, int currentRetryTimes = 0, SystemConfigModel configs = null)
        {
            try
            {
                #region add token - user - password

                parameters.Add(CreateAuthenParam(parameters.FirstOrDefault(), configs));
                #endregion

                var request = CreateRequestingHeader(url, configs);
                request.Method = method.ToUpper();
                if (configs.ConvertToJObject)
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(JObject.Parse(JsonConvert.SerializeObject(parameters)));
                        streamWriter.Flush();
                    }
                }
                else
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(parameters));
                        streamWriter.Flush();
                    }
                }
                var response = request.GetResponse() as HttpWebResponse;

                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseResult(ApiMessageConstant.Success, content);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(SslError) && currentRetryTimes <= MaxRetryTimes)
                {
                    return ActionWithJsonBody(url, parameters, method, (currentRetryTimes += 1));
                }

                LogService.RecordLogError($"Web API Error: [{method.ToUpper()}]\n {ex.Message}");
                return HandleException(ex, $"[{method.ToUpper()}]\n {url}");
            }
        }
        #endregion
        public static BaseResult Post(string url, Dictionary<string, dynamic> parameters,
            int currentRetryTimes = 0, SystemConfigModel configs = null)
        {
            try
            {
                #region add token - user - password

                parameters = CreateAuthenParam(parameters, configs);
                #endregion

                var request = CreateRequestingHeader(url, configs);
                request.Method = "POST";
                if (request.ContentType.ToLower().Equals("application/x-www-form-urlencoded"))
                {
                    var dataPost = "";
                    foreach (var item in parameters)
                    {
                        dataPost += (string.IsNullOrEmpty(dataPost) ? "" : "&") + string.Format("{0}={1}", item.Key, item.Value);
                    }
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(dataPost);
                        streamWriter.Flush();
                    }
                }
                else
                {
                    if (configs.ConvertToJObject)
                    {
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(JObject.Parse(JsonConvert.SerializeObject(parameters)));
                            streamWriter.Flush();
                        }
                    }
                    else
                    {
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(JsonConvert.SerializeObject(parameters));
                            streamWriter.Flush();
                        }
                    }
                }
                var response = request.GetResponse() as HttpWebResponse;

                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseResult(ApiMessageConstant.Success, content);
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(SslError) && currentRetryTimes <= MaxRetryTimes)
                {
                    return Post(url, parameters, (currentRetryTimes += 1));
                }
                LogService.RecordLogError($"Web API Error: [POST]\n {ex.Message}");
                return HandleException(ex, $"[POST]\n {url}");
            }
        }
      
        public static BaseResult Post(string url, List<Dictionary<string, dynamic>> parameters, int currentRetryTimes = 0, SystemConfigModel configs = null)
        {
            try
            {
                #region add token - user - password

                parameters.Add(CreateAuthenParam(parameters.FirstOrDefault(), configs));
                #endregion

                var request = CreateRequestingHeader(url, configs);
                request.Method = "POST";

                if (configs.ConvertToJObject)
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(JObject.Parse(JsonConvert.SerializeObject(parameters)));
                        streamWriter.Flush();
                    }
                }
                else
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(parameters));
                        streamWriter.Flush();
                    }
                }
                var response = request.GetResponse() as HttpWebResponse;

                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseResult(ApiMessageConstant.Success, content);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(SslError) && currentRetryTimes <= MaxRetryTimes)
                {
                    return Post(url, parameters, (currentRetryTimes += 1));
                }

                LogService.RecordLogError($"Web API Error: [POST]\n {ex.Message}");
                return HandleException(ex, $"[POST]\n {url}");
            }
        }
      
        public static BaseResult Get(string url, Dictionary<string, dynamic> parameters,
            int currentRetryTimes = 0, SystemConfigModel configs = null)
        {
            try
            {
                #region add token - user - password
                parameters = CreateAuthenParam(parameters, configs);
                #endregion

                var queryString = parameters.Aggregate(string.Empty,
                    (current, p) => current + (string.IsNullOrEmpty(current) ? string.Empty : "&") +
                                    $"{p.Key}={p.Value}");
                //string.Format($"p.Key=p.Value", p.Key, p.Value)
                var finalUrl = string.Empty;

                finalUrl = $"{url}?{queryString}";

                var request = CreateRequestingHeader(finalUrl, configs);
                request.Method = "GET";

                //LogExtension.WriteLogOnServer(string.Format("GET: {0}", finalUrl));
                //LogExtension.WriteHisTrackingOnServer("", "", finalUrl, string.Empty);

                var response = request.GetResponse() as HttpWebResponse;
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();

                    return new BaseResult(ApiMessageConstant.Success, content);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(SslError) && currentRetryTimes <= MaxRetryTimes)
                {
                    return Get(url, parameters, (currentRetryTimes += 1));
                }
                LogService.RecordLogError($"Web API Error: [GET]\n {ex.Message}");

                return HandleException(ex, $"[GET]\n {url}");
            }
        }
        private static HttpWebRequest CreateRequestingHeader(string finalUrl, SystemConfigModel configs = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(finalUrl);
            request.Accept = "application/json;q=0.9,*/*;q=0.8";
            if (finalUrl.ToLower().Contains("token"))
                request.ContentType = "application/x-www-form-urlencoded";
            else
                request.ContentType = "application/json; charset=UTF-8";
            request.KeepAlive = true;
            request.Timeout = HisApiCommonConfigs.HisSendRequestTimeoutAfterSeconds;
            CreateAuthenRequestHeader(configs, request);

            if (new Uri(finalUrl).Scheme == Uri.UriSchemeHttps)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol =
                    (SecurityProtocolType)192 |
                    (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            }
            else
            {
                ServicePointManager.Expect100Continue = false;
            }

            LogService.RecordLogFile("TPH.HIS.WebAPI",
                $"Web API [finalUrl=  {finalUrl}]\n ",
                (new StackTrace()).GetFrame(0).GetMethod().Name);
            return request;
        }
        private static void CreateAuthenRequestHeader(SystemConfigModel configs, HttpWebRequest request)
        {
            if (configs != null)
            {
                if (configs.UseToken && !string.IsNullOrEmpty(configs.Access_token) && !string.IsNullOrEmpty(configs.Token_type))
                {
                    //if (configType.Equals(ApiConstant.HeaderKey))
                    //{
                    //    request.Headers.Add(configs.Token_type, configs.authenCode);
                    //}
                    //else if (configType.Equals(ApiConstant.BaseAuthenKey))
                    //{
                    var authenCode = configs.Access_token;
                        request.Headers.Add(AuthenKey, $"{configs.Token_type} {configs.Access_token}");
                    //}
                }
                else
                {
                    if(!string.IsNullOrEmpty(configs.HisDatabaseName))
                    {
                        var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisDatabaseName);
                        var configType = configDetail.Type.ToLower();
                        if (configType.Equals(ApiConstant.HeaderKey))
                        {
                            request.Headers.Add(configDetail.Key, configDetail.Value);
                        }
                        else if (configType.Equals(ApiConstant.BaseAuthenKey))
                        {
                            //authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                            var authenCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(configDetail.Value));
                            request.Headers.Add(AuthenKey, $"{BasicAuthen} {authenCode}");
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(configs.HisUser))
                    {
                        try
                        {
                            var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisUser);
                            var configType = configDetail.Type.ToLower();
                            if (configType.Equals(ApiConstant.HeaderKey))
                            {
                                request.Headers.Add(configDetail.Key, configDetail.Value);
                            }
                            else if (configType.Equals(ApiConstant.BaseAuthenKey))
                            {
                                var authenCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(configDetail.Value));
                                request.Headers.Add(AuthenKey, $"{BasicAuthen} {authenCode}");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog.LogService.RecordLogFile("WebAPI_CreateAuthenParam_Error", ex.Message, "CreateAuthenParam_HisUser");
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(configs.HisPassword))
                    {
                        try
                        {
                            var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisPassword);
                            var configType = configDetail.Type.ToLower();
                            if (configType.Equals(ApiConstant.HeaderKey))
                            {
                                request.Headers.Add(configDetail.Key, configDetail.Value);
                            }
                            else if (configType.Equals(ApiConstant.BaseAuthenKey))
                            {
                                var authenCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(configDetail.Value));
                                request.Headers.Add(AuthenKey, $"{BasicAuthen} {authenCode}");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog.LogService.RecordLogFile("WebAPI_CreateAuthenParam_Error", ex.Message, "CreateAuthenParam_HisPassword");
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(configs.HisPort))
                    {
                        try
                        {
                            var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisPort);
                            var configType = configDetail.Type.ToLower();
                            if (configType.Equals(ApiConstant.HeaderKey))
                            {
                                request.Headers.Add(configDetail.Key, configDetail.Value);
                            }
                            else if (configType.Equals(ApiConstant.BaseAuthenKey))
                            {
                                var authenCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(configDetail.Value));
                                request.Headers.Add(AuthenKey, $"{BasicAuthen} {authenCode}");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog.LogService.RecordLogFile("WebAPI_CreateAuthenParam_Error", ex.Message, "CreateAuthenParam_HisPort");
                        }
                    }
                }
            }
        }
        private static Dictionary<string, dynamic> CreateAuthenParam(Dictionary<string, dynamic> parameters, SystemConfigModel configs)
        {
            if (configs != null)
            {
                if (parameters == null)
                {
                    parameters = new Dictionary<string, dynamic>();
                }

                if (!string.IsNullOrWhiteSpace(configs.HisDatabaseName))
                {
                    var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisDatabaseName);
                    var configType = configDetail.Type.ToLower();
                    if (configType.Equals(ApiConstant.ParamKey))
                    {
                        parameters.Add(configDetail.Key, configDetail.Value);
                    }
                }

                if (!string.IsNullOrWhiteSpace(configs.HisUser))
                {
                    try
                    {
                        var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisUser);
                        var configType = configDetail.Type.ToLower();
                        if (configType.Equals(ApiConstant.ParamKey))
                        {
                            parameters.Add(configDetail.Key, configDetail.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog.LogService.RecordLogFile("WebAPI_CreateAuthenParam_Error", ex.Message, "CreateAuthenParam_HisUser");
                    }
                }

                if (!string.IsNullOrWhiteSpace(configs.HisPassword))
                {
                    try
                    {
                        var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisPassword);
                        var configType = configDetail.Type.ToLower();
                        if (configType.Equals(ApiConstant.ParamKey))
                        {
                            parameters.Add(configDetail.Key, configDetail.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog.LogService.RecordLogFile("WebAPI_CreateAuthenParam_Error", ex.Message, "CreateAuthenParam_HisPassword");
                    }
                }

                if (!string.IsNullOrWhiteSpace(configs.HisPort))
                {
                    try
                    {
                        var configDetail = JsonConvert.DeserializeObject<AuthenConfigModel>(configs.HisPort);
                        var configType = configDetail.Type.ToLower();
                        if (configType.Equals(ApiConstant.ParamKey))
                        {
                            parameters.Add(configDetail.Key, configDetail.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog.LogService.RecordLogFile("WebAPI_CreateAuthenParam_Error", ex.Message, "CreateAuthenParam_HisPort");
                    }
                }
            }

            return parameters;
        }
        private static BaseResult HandleException(Exception ex, string url = "")
        {
            if (!(ex is WebException))
            {
                LogService.RecordLogFile("TPH.HIS.WebAPI",
                    (string.IsNullOrEmpty(url) ? "" : $"URL:{url}\n") + ex.Message,
                    (new StackTrace()).GetFrame(0).GetMethod().Name);
                return new BaseResult(-1, $"[{ex.Message}]");
            }
            else
            {
                var wEx = (WebException)ex;
                using (var response = wEx.Response)
                {
                    var httpResponse = (HttpWebResponse)response;
                    if (httpResponse == null)
                    {
                        throw ex;
                    }

                    switch (httpResponse.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            return new BaseResult((int)HttpStatusCode.BadRequest,
                                $"[{httpResponse.ResponseUri}] 400 Bad Request");
                        case HttpStatusCode.Unauthorized:
                            return new BaseResult((int)HttpStatusCode.Unauthorized,
                                $"[{httpResponse.ResponseUri}] 401 Unauthorized");
                        case HttpStatusCode.Forbidden:
                            return new BaseResult((int)HttpStatusCode.Forbidden,
                                $"[{httpResponse.ResponseUri}] 403 Forbidden");
                        case HttpStatusCode.NotFound:
                            return new BaseResult((int)HttpStatusCode.NotFound,
                                $"[{httpResponse.ResponseUri}] 404 Not Found, Invalid Uri");
                        case HttpStatusCode.MethodNotAllowed:
                            return new BaseResult((int)HttpStatusCode.MethodNotAllowed,
                                $"[{httpResponse.ResponseUri}] 405 Method Not Allowed, Invalid Method");
                        case HttpStatusCode.InternalServerError:
                            return new BaseResult((int)HttpStatusCode.InternalServerError,
                                $"[{httpResponse.ResponseUri}] 500 Internal Server Error, please report to the service provider");
                        case HttpStatusCode.ServiceUnavailable:
                            return new BaseResult((int)HttpStatusCode.ServiceUnavailable,
                                $"[{httpResponse.ResponseUri}] 503 Service Unavailable, probably in maintenance");
                        default:
                            return new BaseResult((int)httpResponse.StatusCode,
                                $"[{httpResponse.ResponseUri}]UnexpectedError");
                    }
                }
            }
        }
    }
}