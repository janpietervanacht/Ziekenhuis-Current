using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace Ziekenhuis.Ziekenhuis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Voor Nlog(): installeer de volgende NuGetPackages:
        // Nlog.Appsettings.Standard
        // Nlog.Web.AspNetCore
        // System.Data.SqlClient

        // Als de logging niet werkt (programma doet het wel, geen knaller
        // maar de log-tabel in SQL server wordt niet gevuld
        // Kijk dan in de interne-logging van NLog

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseNLog();
                });
    }
}
