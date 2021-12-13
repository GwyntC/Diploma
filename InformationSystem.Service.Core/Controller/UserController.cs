using InformationSystem.Core.BLL.Contract;
using InformationSystem.Core.Domain;
using InformationSystem.Service.Client.Contract;
using InformationSystem.Service.Core.Hub;
using InformationSystem.Service.Transform;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem.Service.Core.Controller
{
 public   class UserController
    {
        private readonly IHubContext<MainHub> hubContext;
        private readonly IUserManager userManager;
        private readonly UserTransformer userTransformer;
        public UserController(IHubContext<MainHub> hubContext, IUserManager userManager)
        {
            this.hubContext = hubContext;
            this.userManager = userManager;
            this.userTransformer = new UserTransformer();
        }
        public async Task<UserInfo> GetUserInfoAsync(string login,string password)
        {
            User user = this.userManager.GetUserByLogin(login,password);
            return this.userTransformer.Transform(user);
        }
    }
}
