using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem.Service.Core.Hub
{
  public partial  class MainHub: Microsoft.AspNetCore.SignalR.Hub
    {
        protected readonly static List<string> connectionCollection = new List<string>();
        protected static readonly object locker = new object();
        private HubEnvironment hubEnvironment;
        public MainHub(HubEnvironment hubEnvironment)
        {
            this.hubEnvironment = hubEnvironment;
        }
        protected virtual bool IsUserEntered
        {
            get
            {
                return connectionCollection.Contains(this.Context.ConnectionId);
            }
        }
        protected void AddConnection(string connectionId)
        {
            lock (locker)
            {
                if (!connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Add(connectionId);
                }
            }
        }
        protected void RemoveConnection(string connectionId)
        {
            lock (locker)
            {
                if (connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Remove(connectionId);
                }
            }
        }
        protected void JoinGroup(string groupName)
        {
            this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        }
        protected void LeaveGroup(string groupName)
        {
            this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, groupName);
        }
        protected string GetIpAddress()
        {
            var ipAddress = Context.GetHttpContext().Connection.RemoteIpAddress.ToString();
            return ipAddress;
        }
    }
}
