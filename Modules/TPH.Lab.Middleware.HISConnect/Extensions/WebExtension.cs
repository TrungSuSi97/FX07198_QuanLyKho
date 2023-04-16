using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using TPH.Lab.Middleware.HISConnect.Constant;
using TPH.LIS.Common.Model;

namespace TPH.Lab.Middleware.HISConnect.Extensions
{
    public class WebExtension
    {
        public static BaseModel Post(string url, Dictionary<string, dynamic> parameters)
        {
            try
            {
                var request = CreateRequestingHeader(url);
                request.Method = "POST";

                var jsonParams = JsonConvert.SerializeObject(parameters);
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonParams);
                    streamWriter.Flush();
                }
                var response = request.GetResponse() as HttpWebResponse;

                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseModel(MessageCodeConst.SuccessCode, content);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public static BaseModel Get(string url, Dictionary<string, dynamic> parameters)
        {
            try
            {
                var queryString = parameters.Aggregate(string.Empty, (current, p) => current + string.Format("&{0}={1}", p.Key, p.Value));
                var finalUrl = string.Format("{0}?{1}", url, queryString);
                var request = CreateRequestingHeader(finalUrl);
                request.Method = "GET";
                var response = request.GetResponse() as HttpWebResponse;
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();

                    return new BaseModel(MessageCodeConst.SuccessCode, content);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public static BaseModel Put(string url, Dictionary<string, dynamic> parameters)
        {
            try
            {
                var request = CreateRequestingHeader(url);
                request.Method = "PUT";

                var jsonParams = JsonConvert.SerializeObject(parameters);
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonParams);
                    streamWriter.Flush();
                }

                var response = request.GetResponse() as HttpWebResponse;
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseModel(MessageCodeConst.SuccessCode, content);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }
        public static BaseModel Delete(string url, Dictionary<string, dynamic> parameters)
        {
            try
            {
                var request = CreateRequestingHeader(url);
                request.Method = "Delete";

                var jsonParams = JsonConvert.SerializeObject(parameters);
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonParams);
                    streamWriter.Flush();
                }

                var response = request.GetResponse() as HttpWebResponse;
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseModel(MessageCodeConst.SuccessCode, content);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        private static HttpWebRequest CreateRequestingHeader(string finalUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create(finalUrl);
            request.Accept = "application/json;q=0.9,*/*;q=0.8";
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers["uuid"] = "";
            return request;
        }

        private static BaseModel HandleException(Exception ex)
        {
            if (!(ex is WebException))
            {
                throw ex;
            }

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
                        return new BaseModel((int)HttpStatusCode.BadRequest, "400 Bad Request");
                    case HttpStatusCode.Unauthorized:
                        return new BaseModel((int)HttpStatusCode.Unauthorized, "401 Unauthorized");
                    case HttpStatusCode.Forbidden:
                        return new BaseModel((int)HttpStatusCode.Forbidden, "403 Forbidden");
                    case HttpStatusCode.NotFound:
                        return new BaseModel((int)HttpStatusCode.NotFound, "404 Not Found, Invalid Uri");
                    case HttpStatusCode.MethodNotAllowed:
                        return new BaseModel((int)HttpStatusCode.MethodNotAllowed, "405 Method Not Allowed, Invalid Method");
                    case HttpStatusCode.InternalServerError:
                        return new BaseModel((int)HttpStatusCode.InternalServerError, "500 Internal Server Error, please report to the service provider");
                    case HttpStatusCode.ServiceUnavailable:
                        return new BaseModel((int)HttpStatusCode.ServiceUnavailable, "503 Service Unavailable, probably in maintenance");
                    default:
                        return new BaseModel((int)httpResponse.StatusCode, "UnexpectedError");
                }
            }
        }
    }
}
