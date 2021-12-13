using InformationSystem.Core.Domain;
using InformationSystem.Service.Client.Contract;
using System;

namespace InformationSystem.Service.Transform
{
    public class UserTransformer
    {
        public UserInfo Transform(User user)
        {
            UserInfo userInfo = new UserInfo(user.Login);
            return userInfo;
        }
    }
}
