using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace Ziekenhuis.Ziekenhuis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * Build(): Builds the required services and an IWebHost which hosts a web application.
             */
            CreateHostBuilder(args).Build().Run();
        }

        // Voor Nlog(): installeer de volgende NuGetPackages:
        // Nlog.Appsettings.Standard
        // Nlog.Web.AspNetCore
        // System.Data.SqlClient

        // Als de logging niet werkt (programma doet het wel, geen knaller
        // maar de log-tabel in SQL server wordt niet gevuld
        // Kijk dan in de interne-logging van NLog

        // ConfigureWebHostDefaults: Configures a IHostBuilder with defaults for hosting a web app.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseNLog();
                });
    }
}
