using InformationSystem.Core.BLL;
using InformationSystem.Core.BLL.Contract;
using InformationSystem.Service.Core.Hub;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MSSql;
using System;
using System.Diagnostics;
using System.IO;

namespace InformationSystem.Service.Core
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
            });
            RepositoryFactory repositoryFactory = new RepositoryFactory();
            IManagerFactory managerFactory = new ManagerFactory(repositoryFactory);
            services.AddSingleton<IManagerFactory>(managerFactory);
            services.AddSingleton<HubEnvironment>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<MainHub>("/notes", options =>
                {
                    // 30Kb message buffer
                    options.TransportMaxBufferSize = 0;
                    options.ApplicationMaxBufferSize = 120 * 1024;
                });
            });
        }
    }
}
