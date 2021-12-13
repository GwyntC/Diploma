using InformationSystem.Core.BLL;
using InformationSystem.Core.BLL.Contract;
using InformationSystem.Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSSql;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositoryFactory repositoryFactory = new RepositoryFactory();
            IManagerFactory managerFactory = new ManagerFactory(repositoryFactory);
            UserManager userManager = (UserManager)managerFactory.Create<IUserManager>();
            User user = userManager.GetUserByLogin("admin","password");
            Assert.AreEqual("admin", user.Login);
        }
    }
}
