using BackGround.ExportFileModels.InterfacesForExport;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Background.ExportFileModels.InvoiceModels
{
    public abstract class BaseInvoice: IAuditFields // is een abstract class, want we willen geen instantie ervan
    {

        // Reference bevat functionele klantnummer + functionele factuurnummer
        public string Reference { get; set; }
                
        public string InvoiceDescription { get; set; }

        public decimal Amount { get; set; }

        public string DueDate { get; set; } // Geformatteerde datum-string
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public string DateTimeCreated { get; set; }
    }
}
