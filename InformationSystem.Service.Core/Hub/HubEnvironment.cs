using InformationSystem.Core.BLL.Contract;
using InformationSystem.Service.Core.Controller;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem.Service.Core.Hub
{
    public class HubEnvironment
    {
        public UserController userController;
        public HubEnvironment(IHubContext<MainHub> hubContext, IManagerFactory managerFactory)
        {
            IUserManager userManager = managerFactory.Create<IUserManager>();
            this.userController = new UserController(hubContext, userManager);
        }
    }
}
