using Background.ExportFileModels.InvoiceModels;
using BackGround.ConstantsAndEnums;
using BackGround.Factories;
using BackGround.Utilities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using Ziekenhuis.Model;

namespace BackGround.Handlers
{
    internal static class BigInvoiceHandler
    {
        internal static void CreateOutgInvoices(List<Invoice> listInv, SoortUitgFactuur soortUitgFactuur,
            TypeOfExport typeOfExport, IConfiguration configuration)
        {
            // Maak lijst van Big Invoices en vul de BASISVELDEN van ieder element van deze lijst: 
            var listOutgInv = InvoiceFactory<BigInvoice>.CreateListBaseInvoice(listInv);
            // Toevoegen van alle Client Gegevens aan iedere BIG factuur:
            for (int i = 0; i < listInv.Count; i++)
            {
                listOutgInv[i].Client = listInv[i].Client; // extra bovenop de basis velden (XXX)
                listOutgInv[i].OmschrijvingGroteFaktuur = $"GROTE factuur met nummer {listInv[i].InvoiceNumber}";
            };

            KindOutgoingFile soortUitgFile;

            switch (soortUitgFactuur)
            {
                case SoortUitgFactuur.Big:
                    soortUitgFile = KindOutgoingFile.BigInvoice;
                    break;
                case SoortUitgFactuur.Small:
                    soortUitgFile = KindOutgoingFile.SmallInvoice;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }; 


            PathsAndFolders.CreateFileNamesAndDirectories(
                soortUitgFile,
                typeOfExport,
                configuration,
                out string fileName,
                out string fullFileName);
            var invoiceExportFileModel = InvoiceFactory<BigInvoice>.CreateInvoiceExportFileModel(listOutgInv, fileName);

            // Onderstaande is vervangen door een extension method op klasse InvoiceExportFileModel<T>. 
            // Serializing.SerializeToFile<BigInvoice>(fullFileNameBig, invoiceBigExportFileModel);
            invoiceExportFileModel.SerializeToInvoiceFile<BigInvoice>(fullFileName, typeOfExport); 
        }

       
    }
}
