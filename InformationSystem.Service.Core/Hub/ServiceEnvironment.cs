using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem.Service.Core.Hub
{
   public  class ServiceEnvironment
    {
        public string HubName { get; set; } = "notes";
        public TimeSpan ConnectionTimeout { get; set; } = new TimeSpan(0, 0, 30);
        public TimeSpan OperationTimeout { get; set; } = new TimeSpan(0, 0, 30);
        public HubConnection Connection { get; set; }
    }
}
