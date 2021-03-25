using Background.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.Json;
using Ziekenhuis.Background.ImportFileModels;
using Ziekenhuis.BackGround.ImportFileModels;
using Ziekenhuis.DataAccess.Interfaces;


// Incoming payments partial class

namespace Background.Managers
{
    enum ErrIncPaym
    {
        InvNotParsable, InvNotFound, InvAlreadyPaid
    }

    public class IncomingPaymentManager : IIncomingPaymentManager
    {
        // Onderstaande readonly variabelen staan al in InvoiceBGManager1.cs

        //private readonly IInvoiceRepository _invoiceRepository;
        //private readonly IConfiguration _configuration;

        private PaymentImportFileModel impFileModel;
        private int invNumber;
        private string fullFileName;

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IConfiguration _configuration;
        public IncomingPaymentManager(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
        }

        public void ReadAndProcessIncPaymentFile()
        {
            ReadImportFile();
            ProcessImportFile(); 
            ShowImportResultToConsole();
        }

        //-------------------------------------------------- 
        /// <summary>
        /// Lees de import file
        /// </summary>
        /// <returns></returns>
        private string ReadImportFile()
        {

            var importFolder = _configuration.GetSection("AppSettings")["ImportFolder"];
            var subFolderPayments = _configuration.GetSection("AppSettings")["SubFolderPayments"];

            var fileName = "ABNAMRO.txt";

            // Combine zorgt ervoor dat er geen verwarring ontstaat
            // bij het verbinden van folder-paden (soms zijn er wel of geen extra slashes aanwezig)

            var pathString = Path.Combine(importFolder, subFolderPayments);
            fullFileName = Path.Combine(pathString, fileName);

            Console.WriteLine($"\n\n-------------- Inlezen van importfile {fullFileName}: ------------- \n\n"); 

            // Prec: folder-pad bestaat.  

            string jsonString;
            using ( var file = new StreamReader(fullFileName))
            {
                jsonString = file.ReadToEnd();
            }
            impFileModel = JsonSerializer.Deserialize<PaymentImportFileModel>(jsonString);

            return "00";
        }



        //---------------------------------------------------------------------------------------  

        /// <summary>
        /// Verwerk de importfile
        /// </summary>
        /// <returns></returns>
        private string ProcessImportFile()
        {
            Console.WriteLine($"\n\n-------------- Verwerking van importfile {fullFileName}: ------------- \n\n"); 
            foreach (var paym in impFileModel.PaymentList)
            {
                bool isParsable = int.TryParse(paym.PaymentReference, out invNumber);

                if (isParsable)
                {
                    var inv = _invoiceRepository.GetByInvoiceNumber(invNumber);
                    if (inv != null)
                    {
                        // Dankzij include in GetByInvoiceNumber hebben we ook de Client al helemaal opgehaald: 
                        // var clientFullName = _clientRepository.ClientFullName(inv.ClientId);
                        var clientFullName = inv.Client.FirstName + " " + inv.Client.LastName; 
                        if (inv.Status == 'O')
                        {
                            inv.Status = 'C';
                            _invoiceRepository.UpdateInvoiceOnly(inv);
                            Console.Write($"Factuur {invNumber} voor klant {clientFullName} op Completed (C) gezet");
                        }
                        else
                        {
                            ReportErrorIncPaym(paym, ErrIncPaym.InvAlreadyPaid);
                        }
                    }
                    else // inv == null
                    {
                        ReportErrorIncPaym(paym, ErrIncPaym.InvNotFound);
                    }
                }
                else  // Not Parsable payment
                {
                    ReportErrorIncPaym(paym, ErrIncPaym.InvNotParsable);
                }
                Console.WriteLine();
            };

            return "00";
        }
        /// <summary>
        /// Toon resultaten van de import op de console
        /// </summary>
        private void ShowImportResultToConsole()
        {
            Console.WriteLine();

            foreach (var paym in impFileModel.PaymentList)
            {
                Console.WriteLine($"Ink betaling met ref {paym.PaymentReference}, " +
                    $"bedrag {paym.Amount}, " +
                    $"van rek.nr {paym.DebtorIBAN} ingelezen");
            }

            Console.WriteLine($"\nEr zijn {impFileModel.PaymentList.Count} betalingen ingelezen\n");
        }


        /// <summary>
        ///  Rapporteer de foute inkomende betalingen
        /// </summary>
        /// <param name="paym">Payment param</param>
        /// <param name="errorCode">Error code param</param>

        private void ReportErrorIncPaym(IncomingPayment paym, ErrIncPaym errorCode)
        {
            Console.WriteLine("\n\n--- Error Report ------------------------------------------ ");
            Console.WriteLine($"Incoming file                  : {fullFileName} ");
            Console.WriteLine($"BIC of bank                    : {impFileModel.HeaderRecord.BICOfBank} ");
            Console.WriteLine($"Bank\'s reference of payment    : {paym.ReferenceFromBank}");
            Console.WriteLine($"Debtor\'s reference of payment  : {paym.PaymentReference}"); 
            Console.WriteLine($"Debtor\'s IBAN                  : {paym.DebtorIBAN}");
            Console.WriteLine($"Payment amount                 : {paym.Amount}");

            if (errorCode == ErrIncPaym.InvNotParsable)
            {
                Console.WriteLine($"Factuurnummer niet kunnen afleiden uit " +
                        $"import betalingen file, referentie uit import file is {paym.PaymentReference}");
            }
            else if (errorCode == ErrIncPaym.InvNotFound)
            {
                bool isParsable = int.TryParse(paym.PaymentReference, out invNumber);
                Console.WriteLine($"Factuur met nummer {invNumber} niet gevonden");
            }
            else if (errorCode == ErrIncPaym.InvAlreadyPaid)
            {
                bool isParsable = int.TryParse(paym.PaymentReference, out invNumber);
                Console.WriteLine($"Factuur {invNumber} al afgeboekt. Betaling genegeerd.");
            }

            Console.WriteLine("--- End of Error report ----------------------------------- ");

        }
    }
}
