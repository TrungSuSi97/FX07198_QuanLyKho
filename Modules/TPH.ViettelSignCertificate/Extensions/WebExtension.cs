using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using log4net;
using Newtonsoft.Json;
using TPH.ViettelSignCertificate.Models;

namespace TPH.ViettelSignCertificate.Extensions
{
    public class WebExtension
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly LogExtension LogExtension = new LogExtension(_logger);
        private const string SslError = "Could not create SSL/TLS secure channel.";
        private const int MaxRetryTimes = 3;

        public static BaseResult PostXml(string url, string xmlContent)
        {
            try
            {
                var request = CreateRequestingHeader(url);
                request.Method = "POST";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(xmlContent);
                    streamWriter.Flush();
                }
                var response = request.GetResponse() as HttpWebResponse;

                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var content = streamReader.ReadToEnd();
                    return new BaseResult(0, content);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Web API Error: [POST]\n {0}", ex.Message));
                return HandleException(ex);
            }
        }

        private static HttpWebRequest CreateRequestingHeader(string finalUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create(finalUrl);
            //request.Accept = "application/json;q=0.9,*/*;q=0.8";
            request.ContentType = "text/xml;charset=UTF-8";
            request.Timeout = 10000;

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

            return request;
        }

        private static BaseResult HandleException(Exception ex)
        {
            _logger.DebugFormat("Call API Error:\n{0}", ex.ToString());
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
                        return new BaseResult((int)HttpStatusCode.BadRequest, string.Format("[{0}] 400 Bad Request", httpResponse.ResponseUri));
                    case HttpStatusCode.Unauthorized:
                        return new BaseResult((int)HttpStatusCode.Unauthorized, string.Format("[{0}] 401 Unauthorized", httpResponse.ResponseUri));
                    case HttpStatusCode.Forbidden:
                        return new BaseResult((int)HttpStatusCode.Forbidden, string.Format("[{0}] 403 Forbidden", httpResponse.ResponseUri));
                    case HttpStatusCode.NotFound:
                        return new BaseResult((int)HttpStatusCode.NotFound, string.Format("[{0}] 404 Not Found, Invalid Uri", httpResponse.ResponseUri));
                    case HttpStatusCode.MethodNotAllowed:
                        return new BaseResult((int)HttpStatusCode.MethodNotAllowed, string.Format("[{0}] 405 Method Not Allowed, Invalid Method", httpResponse.ResponseUri));
                    case HttpStatusCode.InternalServerError:
                        return new BaseResult((int)HttpStatusCode.InternalServerError, string.Format("[{0}] 500 Internal Server Error, please report to the service provider", httpResponse.ResponseUri));
                    case HttpStatusCode.ServiceUnavailable:
                        return new BaseResult((int)HttpStatusCode.ServiceUnavailable, string.Format("[{0}] 503 Service Unavailable, probably in maintenance", httpResponse.ResponseUri));
                    default:
                        return new BaseResult((int)httpResponse.StatusCode, string.Format("[{0}]UnexpectedError", httpResponse.ResponseUri));
                }
            }
        }
    }
}