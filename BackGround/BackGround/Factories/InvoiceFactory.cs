using Background.ExportFileModels;
using BackGround.ExportFileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using BackGround.ExportFileModels.InterfacesForExport;
using Ziekenhuis.Model;
using Background.ExportFileModels.InvoiceModels;

namespace BackGround.Factories
{
    // Keyword new() moet je achteraan zetten, dus achteraan de WHERE CLAUSE 
    // Let op: IGeneric wordt vermeld zowel in BigInvoice, SmallInvoice en ook hier
    // Want anders zijn de velden CompanyName, CreatedBy en DateTimeCreated onbekend in de code hieronder. 

    // Hieronder een generic class met 2 niet-generieke methods
    // Als je een generieke methode in een generic class wil gebruiken, 
    // gebruik dan niet nog een keer T in de method, maar bijvoorbeeld een U 

    public static class InvoiceFactory<T> where T : BaseInvoice, IAuditFields, new()
    {
        public static List<T> CreateListBaseInvoice(List<Invoice> listInv)
        {
            // Kopiëren lijst met objecten van class A naar een lijst van objecten met type T: 
            var result = listInv
                            .Select(i => new T 
                            { 
                                // Stap 1: vullen typische factuur-velden uit de base class:  
                                Amount = i.Amount,
                                DueDate = i.DueDate.ToString(),
                                InvoiceDescription = i.InvoiceDescription,
                                Reference = i.Client.ClientNumber + "-" + i.InvoiceNumber,
                                // Stap 2: vullen velden uit de IGenericFields interface
                                // Dit zijn velden die voor meer soorten entiteiten zinvol zijn
                                // Dus niet alleen voor facturen
                                CompanyName = "Jan-PieterBV",
                                CreatedBy = "USERJPVANACHT",
                                DateTimeCreated = DateTime.Now.ToString()
                            }
                            ) 
                            .ToList(); 
            return result;
        }

        public static FactuurExportFileModel<T> CreateInvoiceExportFileModel(List<T> listOutgInv, string fileName)
        {
            return new FactuurExportFileModel<T>()
            {
                HeaderRecord = new Header()
                {
                    FileName = fileName,
                    DateTimeExported = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                },
                FactuurLijst = listOutgInv, // generic
                FooterRecord = new Footer()
                {
                    NrofRecords = listOutgInv.Count()
                }
            };
        }

    }
}
