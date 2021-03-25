using Background.Interfaces;
using BackGround.ConstantsAndEnums;
using BackGround.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
//using System.Configuration;
using System.IO;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.DataAccess.Repositories;
namespace Background.Managers
{
    public class StartManager : IStartManager
    {
        private IIncomingPaymentManager _incomingPaymentManager;
        private IOutgoingClientManager _outgoingClientManager;
        private IOutgoingInvoiceManager _outgoingInvoiceManager;

        public void StartBackGround()
        {
            // Deze class is niet static, omdat we enkele private variabelen willen setten.
            InitialiseerDI();

            //---------------------------------------------------- 

            Console.WriteLine("Starting creating JSON file with BIG outgoing invoices");
            // Ik heb de Dependency Injection uit Program.cs gehaald
            // Omdat Main een static void method is. Main moet static zijn, anders is ie niet aanroepbaar. 
            // Dus in program.cs kan ik onderstaand statement niet uitvoeren.
            // Daarom doe ik het hier want deze method (StartBackGround) is niet static. 
            _outgoingInvoiceManager.CreateOutgInvoiceFile(SoortUitgFactuur.Big, TypeOfExport.JSON);

            Console.WriteLine("Starting creating XML file with SMALL outgoing invoices");
            _outgoingInvoiceManager.CreateOutgInvoiceFile(SoortUitgFactuur.Small, TypeOfExport.XML);

            Console.WriteLine("Starting creating CSV file with SMALL outgoing invoices");
            _outgoingInvoiceManager.CreateOutgInvoiceFile(SoortUitgFactuur.Small, TypeOfExport.CSV);

            // ------------------------------------

            Console.WriteLine("Starting creating JSON file with KLEINE clienten");
            _outgoingClientManager.CreateOutgClientFile(TypeOfClient.Small, TypeOfExport.JSON);

            Console.WriteLine("Starting creating XML file with GROTE clienten");
            _outgoingClientManager.CreateOutgClientFile(TypeOfClient.Big, TypeOfExport.XML);

            Console.WriteLine("Starting creating JSON file with CRIMINELE clienten");
            _outgoingClientManager.CreateOutgClientFile(TypeOfClient.Criminal, TypeOfExport.JSON);

            Console.WriteLine("Starting creating CSV file with CRIMINELE clienten");
            _outgoingClientManager.CreateOutgClientFile(TypeOfClient.Criminal, TypeOfExport.CSV);

            Console.WriteLine("Starting creating XML file with WITH MANY CONSULTS clienten");
            _outgoingClientManager.CreateOutgClientFile(TypeOfClient.WithManyConsults, TypeOfExport.XML);

            // Onderstaande is functioneel niet OK. Je kan geen CSV maken van een 
            // lijst van clienten, waarbij iedere client weer N consulten heeft (getest met N=3)
            //Console.WriteLine("Starting creating CSV file with WITH MANY CONSULTS clienten");
            //backgroundManager.CreateOutgClientFile(TypeOfClient.WithManyConsults, TypeOfExport.CSV);

            Console.WriteLine();

            Console.WriteLine("Starting reading file with incoming payments");
            _incomingPaymentManager.ReadAndProcessIncPaymentFile();

            // Oefening static public field in static class ClientFactory: 
            Console.WriteLine($"Aantal keer dat \'CreateListClients\' is " +
                $"aangeroepen in ClientFactory is {ClientFactory.aantalKeerCreateListClients}"); 

            Console.ReadKey();
        }

        private void InitialiseerDI()
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true);

            var config = configBuilder.Build();

            var connectionstring = config.GetConnectionString("DefaultConnection");

            //setup our DI
            var services = new ServiceCollection()
                .AddLogging()
                .AddScoped<IIncomingPaymentManager, IncomingPaymentManager>()
                .AddScoped<IOutgoingInvoiceManager, OutgoingInvoiceManager>()
                .AddScoped<IOutgoingClientManager, OutgoingClientManager>()
                .AddScoped<IInvoiceRepository, InvoiceRepository>()
                .AddScoped<IClientRepository, ClientRepository>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring))
                .BuildServiceProvider();

            _incomingPaymentManager = services.GetService<IIncomingPaymentManager>() as IncomingPaymentManager;
            _outgoingInvoiceManager = services.GetService<IOutgoingInvoiceManager>();
            _outgoingClientManager = services.GetService<IOutgoingClientManager>() as OutgoingClientManager;
            // return invoiceBGManager; 

        }
    }
}
