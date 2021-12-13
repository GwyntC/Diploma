using InformationSystem.Service.Core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace InformationSystem.Service.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var pathToExe = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = System.IO.Path.GetDirectoryName(pathToExe);
            return WebHost.CreateDefaultBuilder(args)
            .UseContentRoot(pathToContentRoot)
            .UseStartup<StartUp>()
            .UseUrls("http://localhost:61234/");
        }
    }
}