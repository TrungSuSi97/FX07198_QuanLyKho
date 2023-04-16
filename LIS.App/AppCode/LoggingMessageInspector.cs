
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace TPH.LIS.App.AppCode
{
    public class LoggingEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new LoggingMessageInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new LoggingMessageInspector());
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }

    public class LoggingMessageInspector : IDispatchMessageInspector, IClientMessageInspector
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        

        private string MessageToString(Message message)
        {
            WebContentFormat messageFormat = this.GetMessageContentFormat(message);
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = null;
            switch (messageFormat)
            {
                case WebContentFormat.Default:
                case WebContentFormat.Xml:
                    writer = XmlDictionaryWriter.CreateTextWriter(ms);
                    break;
                case WebContentFormat.Json:
                    writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                    break;
                case WebContentFormat.Raw:
                    // special case for raw, easier implemented separately
                    return this.ReadRawBody(message);
            }

            message.WriteMessage(writer);
            writer.Flush();
            string messageBody = Encoding.UTF8.GetString(ms.ToArray());
            return messageBody;
        }

        private string ReadRawBody(Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            string messageBody = Encoding.UTF8.GetString(bodyBytes);

            return messageBody;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            Uri requestUri = request.Headers.To;
            WriteLog.LogService.RecordLogFileFormat("Log_", "{0} {1}", httpReq.Method, requestUri);
            foreach (var header in httpReq.Headers.AllKeys)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "{0}: {1}", header, httpReq.Headers[header]);
            }

            if (!request.IsEmpty)
            {
                WriteLog.LogService.RecordLogFile("Log_","-----------------");
                MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
                request = buffer.CreateMessage();

                Message loggingMessage = buffer.CreateMessage();
                WriteLog.LogService.RecordLogFileFormat("Log_", this.MessageToString(loggingMessage));
            }

            return requestUri;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            WriteLog.LogService.RecordLogFileFormat("Log_", "Response to request to {0}:", (Uri)correlationState);
            HttpResponseMessageProperty httpResp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
            WriteLog.LogService.RecordLogFileFormat("Log_", "{0} {1}", (int)httpResp.StatusCode, httpResp.StatusCode);
            foreach (var header in httpResp.Headers.AllKeys)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "{0}: {1}", header, httpResp.Headers[header]);
            }

            if (!reply.IsEmpty)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "-----------------");
                MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                reply = buffer.CreateMessage();

                Message loggingMessage = buffer.CreateMessage();
                WriteLog.LogService.RecordLogFileFormat("Log_", "{0}", this.MessageToString(loggingMessage));
            }
        }

        private WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
            {
                WebBodyFormatMessageProperty bodyFormat;
                bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                format = bodyFormat.Format;
            }

            return format;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            WriteLog.LogService.RecordLogFileFormat("Log_", "Response to request to {0}:", (Uri)correlationState);
            HttpResponseMessageProperty httpResp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
            WriteLog.LogService.RecordLogFileFormat("Log_", "AfterReceiveReply: {0} {1}", (int)httpResp.StatusCode, httpResp.StatusCode);

            foreach (var header in httpResp.Headers.AllKeys)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "{0}: {1}", header, httpResp.Headers[header]);
            }

            if (!reply.IsEmpty)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "-----------------");

                MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                reply = buffer.CreateMessage();

                Message loggingMessage = buffer.CreateMessage();
                WriteLog.LogService.RecordLogFileFormat("Log_", "{0}", this.MessageToString(loggingMessage));
            }
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            Uri requestUri = request.Headers.To;
            WriteLog.LogService.RecordLogFileFormat("Log_", "BeforeSendRequest:{0} {1}", httpReq.Method, requestUri);
            foreach (var header in httpReq.Headers.AllKeys)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "{0}: {1}", header, httpReq.Headers[header]);
            }

            if (!request.IsEmpty)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "-----------------");

                MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
                request = buffer.CreateMessage();

                Message loggingMessage = buffer.CreateMessage();
                WriteLog.LogService.RecordLogFileFormat("Log_", "{0}", this.MessageToString(loggingMessage));
            }

            return requestUri;
        }
    }
}
