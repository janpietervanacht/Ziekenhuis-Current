using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Ziekenhuis.DataAccess.ApplicDbContext;

namespace Ziekenhuis.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            HostingEnvironment env;
            String connectionstring = null;

            if ((args != null && args.Length > 1) && args[0].StartsWith("-c"))
            {
                connectionstring = args[1];
                env = new HostingEnvironment
                {
                    EnvironmentName = ""
                };
            }
            else
            {
                env = new HostingEnvironment
                {

                    EnvironmentName = (args != null && args.Length > 0) ? args[0] : ""
                };
            }

            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              ;

            var config = configBuilder.Build();

            if (String.IsNullOrEmpty(connectionstring))
            {
                connectionstring = config.GetConnectionString("DefaultConnection");
            }
            //services.Configure<MyOptions>(config);

            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg =>
                {
                    cfg.AddFilter("*", LogLevel.Information);
                    cfg.AddConsole();
                })
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring))
                .BuildServiceProvider();


            var logger = serviceProvider.GetService<ILogger<Program>>();
            var dbContext = serviceProvider.GetService<ApplicationDbContext>();

            logger.LogInformation(String.Join('-', args));
            logger.LogInformation(connectionstring);

            dbContext.Database.Migrate();

            logger.LogInformation("All done!");

        }
    }
}
