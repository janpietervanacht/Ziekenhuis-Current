using BackGround.ExportFileModels.InterfacesForExport;
using Ziekenhuis.Model;

namespace Background.ExportFileModels.InvoiceModels
{
    public class BigInvoice: BaseInvoice 
        // BaseInvoice is een abstract class omdat we BaseInvoice niet willen instantieren naar een object. 
    {
        // In de grote invoice exporteren we ook alle Client velden
        // en de bijbehorende landen
        
        public Client Client { get; set; }
        public string OmschrijvingGroteFaktuur { get; set; }

    }
}
