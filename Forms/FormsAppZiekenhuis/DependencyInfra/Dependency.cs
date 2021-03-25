using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Business.Managers;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.DataAccess.Repositories;

namespace FormsAppZiekenhuis.DependencyInfra
{
    internal static class Dependency
    {
        internal static void InitialiseerDI(out IClientManager clientManager,
                                            out ICountryManager countryManager,
                                            out IInvoiceManager invoiceManager,
                                            out IConsultManager consultManager)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true);

            var config = configBuilder.Build();

            var connectionstring = config.GetConnectionString("StandaardverBInding");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IClientManager, ClientManager>()
                .AddScoped<ICountryManager, CountryManager>()
                .AddScoped<IInvoiceManager, InvoiceManager>()
                .AddScoped<IConsultManager, ConsultManager>()
                .AddScoped<IClientRepository, ClientRepository>()
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddScoped<IConsultRepository, ConsultRepository>()

                // Onderstaande regel is nodig omdat DI voor de gehele keten moet werken: 

                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring))
                .BuildServiceProvider();

            clientManager = serviceProvider.GetService<IClientManager>();
            countryManager = serviceProvider.GetService<ICountryManager>();
            invoiceManager = serviceProvider.GetService<IInvoiceManager>();
            consultManager = serviceProvider.GetService<IConsultManager>();

        }
    }
}
