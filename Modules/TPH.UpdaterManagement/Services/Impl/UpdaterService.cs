using Microsoft.AspNet.SignalR.Client;
using System.Net.Http;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.UpdaterManagement.Models;

namespace TPH.UpdaterManagement.Services.Impl
{
    public class UpdaterService: IUpdaterService
    {

        /// <summary>
        /// This name is simply added to sent messages to identify the user; this 
        /// sample does not include authentication.
        /// </summary>
        private String UserName { get; set; }
        private IHubProxy HubProxy { get; set; }
        private string ServerURI = "http://localhost:8080/signalr";
        private HubConnection Connection { get; set; }

        public void CloseConnect()
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }
        public void LeftGroup(string groupName)
        {
            if (Connection == null || HubProxy == null)
            {
                return;
            }
            HubProxy.Invoke("Disconnect", groupName);
        }
        public async Task JoinGroup(string groupName)
        {
            if (Connection == null || HubProxy == null)
            {
                return;
            }
            await HubProxy.Invoke("JoinGroup", groupName);
        }
        public void SendMessage(string autoMessage)
        {
            if (Connection == null || HubProxy == null)
            {
                return;
            }
            try
            {
                HubProxy.Invoke("Send", UserName, autoMessage);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Data cannot be sent because the connection is in the disconnected state. Call start before sending any data."))
                {
                    Connection.Stop();
                    Connection.Start();
                }
            }
        }
        public void SendMessage(string autoMessage, string groupName)
        {
            if (Connection == null || HubProxy == null)
            {
                return;
            }
            try
            {
                HubProxy.Invoke("Send", UserName, autoMessage, groupName);
            }
            catch (Exception ex)
            {
                if(ex.Message.Equals("Data cannot be sent because the connection is in the disconnected state. Call start before sending any data."))
                {
                    Connection.Stop();
                    Connection.Start();
                }
            }
        }
        public async void CreateServiceConnect(UpdateServiceHostInfo hostInfo)
        {
            if (!hostInfo.HostName.ToLower().Contains("http://"))
            {
                hostInfo.HostName = "http://" + hostInfo.HostName;
            }
            ServerURI = string.Format("{0}:{1}", hostInfo.HostName, hostInfo.Port);
            Connection = new HubConnection(ServerURI);
            UserName = hostInfo.UserName;
            // Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy(hostInfo.HubName);
            ////Handle incoming event from server: use Invoke to write to console from SignalR's thread
            //HubProxy.On<string, string>("AddMessage", (name, message) =>
            //    this.Invoke((Action)(() =>
            //        RichTextBoxConsole.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
            //  ))
            //);
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException ex)
            {
                WriteLog.LogService.RecordLogError("SignalR", "UpdaterService", msg: (ex.InnerException.ToString()));
                Connection = null;
                HubProxy = null;
                //No connection: Don't enable Send button or show chat UI
                return;
            }
            WriteLog.LogService.RecordLogError("SignalR", "UpdaterService", msg: "Connected to server at " + ServerURI);
        }
        public IHubProxy GetHubProxy()
        {
            return HubProxy;
        }
        public bool IsReady()
        {
            return Connection != null && HubProxy != null;
        }
    }
}
