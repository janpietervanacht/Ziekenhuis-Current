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
    internal static class SmallInvoiceHandler
    {
        internal static void CreateOutgInvoices(List<Invoice> listInv, SoortUitgFactuur soortUitgFactuur,
            TypeOfExport typeOfExport, IConfiguration configuration)
        {
            // Maak lijst van Small Invoices en vul de BASISVELDEN van ieder element van deze lijst: 
            var listOutgInv = InvoiceFactory<SmallInvoice>.CreateListBaseInvoice(listInv);
            // Toevoegen van een paar klant-naw gegevens aan iedere SMALL factuur:
            for (int i = 0; i < listInv.Count; i++)
            {
                listOutgInv[i].OmschrijvingKleineFactuur = $"KLEINE factuur met nummer {listInv[i].InvoiceNumber}"; 
            };



            KindOutgoingFile soortUitgFile;

#pragma warning disable IDE0066 // Convert switch statement to expression
            switch (soortUitgFactuur)
#pragma warning restore IDE0066 // Convert switch statement to expression
            {
                case SoortUitgFactuur.Big:
                    soortUitgFile = KindOutgoingFile.BigInvoice;
                    break;
                case SoortUitgFactuur.Small:
                    soortUitgFile = KindOutgoingFile.SmallInvoice;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            PathsAndFolders.CreateFileNamesAndDirectories
                (soortUitgFile,
                typeOfExport,
                configuration,
                out string fileName,
                out string fullFileName);

            var invoiceExportFileModel = InvoiceFactory<SmallInvoice>.CreateInvoiceExportFileModel(listOutgInv, fileName);

            // Onderstaande is vervangen door een extension method op klasse InvoiceExportFileModel<T>. 
            // Serializing.SerializeToFile<SmallInvoice>(fullFileNameSmall, invoiceSmallExportFileModel);
            invoiceExportFileModel.SerializeToInvoiceFile<SmallInvoice>(fullFileName, typeOfExport);
        }

    }
}
