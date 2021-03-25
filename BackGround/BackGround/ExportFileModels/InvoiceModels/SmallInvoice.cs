using BackGround.ExportFileModels.InterfacesForExport;

namespace Background.ExportFileModels.InvoiceModels
{
    public class SmallInvoice : BaseInvoice 
    {
        // BaseInvoice is een abstract class omdat we BaseInvoice niet willen instantieren naar een object. 

        // In de kleine invoice exporteren we per factuur
        // als EXTRA (zie hieronder) een omschrijving die herkenbaar is (didactisch)
        public string OmschrijvingKleineFactuur { get; set; } // vergeet NOOIT de get/set
    }
}
