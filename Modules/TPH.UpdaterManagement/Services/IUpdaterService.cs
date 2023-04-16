
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.UpdaterManagement.Models;

namespace TPH.UpdaterManagement.Services
{
    public interface IUpdaterService
    {
        bool IsReady();
        void CloseConnect();
        void LeftGroup(string groupName);
        Task JoinGroup(string groupName);
        void SendMessage(string autoMessage, string groupName);
        void SendMessage(string autoMessage);
        void CreateServiceConnect(UpdateServiceHostInfo hostInfo);
        IHubProxy GetHubProxy();
    }
}
