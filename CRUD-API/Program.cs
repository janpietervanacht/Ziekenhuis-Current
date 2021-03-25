// Zet in Project CRUD-API -> properties -> debug -> 
// Profile = CRUD-API (mag ook iets anders zijn)
// Launch: Project (ook niet echt spannend vermoed ik )
// Lunch browser: LEEGMAKEN (WEL belangrijk)

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ziekenhuis.CRUD_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseNLog(); 
                });
    }
}
