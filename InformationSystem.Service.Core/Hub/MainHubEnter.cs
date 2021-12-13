using InformationSystem.Service.Client.Contract;
using InformationSystem.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem.Service.Core.Hub
{
  partial  class MainHub
    {
        public virtual async Task<OperationStatusInfo> enter(string login, string password)
        {
            var connectionId = this.Context.ConnectionId;
            return await Task.Run(
            async () =>
            {
                string clientIp = this.GetIpAddress();
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(operationStatus: OperationStatus.Done);
                try
                {
                    UserInfo userInfo = await this.hubEnvironment.userController.GetUserInfoAsync(login,password);
                    operationStatusInfo.AttachedObject = userInfo;
                    this.AddConnection(connectionId);
                    this.JoinGroup("shouldBeNotified");
                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = "User is not defined. Check your login and password.";
                }
                return operationStatusInfo;
            });
        }
        public async Task<OperationStatusInfo> Exit()//was nothing
        {


            var connectionId = this.Context.ConnectionId;
            return await Task.Run(
            () =>
            {
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                string clientIp = this.GetIpAddress();
                try
                {
                    if (this.IsUserEntered)
                    {
                        operationStatusInfo.OperationStatus = OperationStatus.Done;
                        this.RemoveConnection(connectionId);
                        this.LeaveGroup("shouldBeNotified");
                    }
                    else
                    {
                        operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                        operationStatusInfo.AttachedInfo = "User is not entered";
                    }
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }
                return operationStatusInfo;
            });
        }
    }
}
