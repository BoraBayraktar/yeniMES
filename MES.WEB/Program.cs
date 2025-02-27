using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MES.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = WebHost.CreateDefaultBuilder(args)
            //                .UseStartup<Startup>()
            //                .CaptureStartupErrors(true)
            //                .UseSetting("detailedErrors", "true")
            //                .Build();
            //host.Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
