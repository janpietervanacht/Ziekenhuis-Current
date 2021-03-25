using Background.ExportFileModels.InvoiceModels;
using Background.ExportFileModels.ClientModels;
using BackGround.ConstantsAndEnums;
using BackGround.ExportFileModels;
using BackGround.ExportFileModels.InterfacesForExport;
using BackGround.Utilities.CSVGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace BackGround.Utilities
{
    internal static class Serializing
    {
        // Extension Method koppelen aan Generic class InvoiceExportFileModel<T>:
        // Zo blijft InvoiceExportFileModel<T> alleen maar properties bevatten (en krijgt dit model geen methods)

        // Best practice: Gebruik bij een generic bijna altijd een Where, en maak T zo specifiek mogelijk
        // Daarmee voorkomt je dat deze generic misbruikt wordt voor andere classes dan Invoices.
        internal static void SerializeToInvoiceFile<T>(this FactuurExportFileModel<T> invoiceExportFileModel, string fullFileName, TypeOfExport typeOfExport)
            where T : BaseInvoice, IAuditFields
        {
            // Beide syntaxen hieronder zijn OK: 
            // ProcessExportFileModel<FactuurExportFileModel<T>>(invoiceExportFileModel, fullFileName, typeOfExport);

            switch (typeOfExport)
            {
                case TypeOfExport.XML:
                    ProcessExportFileModel<FactuurExportFileModel<T>>(invoiceExportFileModel, fullFileName, typeOfExport);
                    break;
                case TypeOfExport.JSON:
                    ProcessExportFileModel(invoiceExportFileModel, fullFileName, typeOfExport); // deze syntax kan ook
                    break;
                case TypeOfExport.CSV:
                    var listInvoicesExport = invoiceExportFileModel.FactuurLijst;  
                    ProcessListOfItemsToCSV(listInvoicesExport, fullFileName);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        internal static void SerializeToClientFile<T>(this KlantExportFileModel<T> klantExportFileModel,
           string fullFileName, TypeOfExport typeOfExport)
           where T : BaseClient, IAuditFields
        {
            switch (typeOfExport)
            {
                case TypeOfExport.XML:
                    ProcessExportFileModel<KlantExportFileModel<T>>(klantExportFileModel, fullFileName, typeOfExport);
                    break;
                case TypeOfExport.JSON:
                    ProcessExportFileModel(klantExportFileModel, fullFileName, typeOfExport); // deze syntax kan ook
                    break;
                case TypeOfExport.CSV:
                    var listClientsExport = klantExportFileModel.KlantLijst; 
                    ProcessListOfItemsToCSV(listClientsExport, fullFileName);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private static void ProcessExportFileModel<U>(U exportFileModel, string fullFileName, TypeOfExport typeOfExport)
        {
            StreamWriter file;
            string jsonString;

            switch (typeOfExport)
            {
                case TypeOfExport.XML:
                    using (file = new StreamWriter(fullFileName))
                    {
                        var xmlWriter = new XmlSerializer(exportFileModel.GetType());
                        xmlWriter.Serialize(file, exportFileModel);
                    }
                    break;
                case TypeOfExport.JSON:
                    using (file = new StreamWriter(fullFileName))
                    {
                        jsonString = JsonSerializer.Serialize(exportFileModel);
                        file.WriteLine(jsonString);
                    }
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        private static void ProcessListOfItemsToCSV<T>(List<T> listItems, string fullFileName)  
        {
            using (var file = new StreamWriter(fullFileName))
            {
                var csvString = CsvConverter.Serialize<T>(listItems);
                file.WriteLine(csvString);
            }
        }

    }
}
