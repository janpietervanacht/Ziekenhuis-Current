using Background.Interfaces;
using BackGround.ConstantsAndEnums;
using BackGround.Handlers;
using Microsoft.Extensions.Configuration;
using System;
using Ziekenhuis.DataAccess.Interfaces;

namespace Background.Managers
{
    public class OutgoingInvoiceManager : IOutgoingInvoiceManager
    {

        // Uitsturen van factuur-gegevens:

        // Grote facturen    BigInvoice
        // Kleine facturen   SmallInvoice

        // In deze class  werken we met een generic class / generic method
        // Waarin <T> kan bestaan uit BigInvoice en SmallInvoice
        // EN
        // Waarbij BigInvoice en SmallInvoice beiden erven van BaseInvoice voor de basis-faktuur-velden
        // EN
        // Waarbij BigInvoice en SmallInvoice voldoen aan interface IGenericFields

        // Partial class: Zet de readonly variabelen en de ctor altijd in de eerste van de 3 source files
        // Je mag ze niet nog een keer definieren in de andere source files
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IConfiguration _configuration;

        public OutgoingInvoiceManager(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
        }
        //------------------------------------------------- 

        public void CreateOutgInvoiceFile(SoortUitgFactuur soortUitgFactuur, TypeOfExport typeOfExport)
        {
            Console.WriteLine("Retrieving all NotSend Invoices from database ---");
            var listInv = _invoiceRepository.GetAllNotSend(); // Dankzij include in repos hebben we ook client en country

            switch (soortUitgFactuur)
            {
                case SoortUitgFactuur.Big:
                    BigInvoiceHandler.CreateOutgInvoices(listInv, soortUitgFactuur, typeOfExport, _configuration);
                    break;

                case SoortUitgFactuur.Small:
                    SmallInvoiceHandler.CreateOutgInvoices(listInv, soortUitgFactuur, typeOfExport, _configuration);
                    break;
                default:
                    break;
            }
             
        }


    }
}
