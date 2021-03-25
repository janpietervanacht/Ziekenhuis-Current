using System.ComponentModel;
using Ziekenhuis.Model;

namespace Ziekenhuis.Ziekenhuis.ViewModels
{
    // Dit ViewModel geeft alleen de belangrijkste client-velden mee
    public class InvoiceViewModel
    {
        // Afgeleide velden: ------------------------------------------ 

        [DisplayName("Naam van de arts:")]
        public string DoctorFullName { get; set; }

        [DisplayName("Totale naam client:")]
        public string ClientFullName { get; set; }

        [DisplayName("Clientnummer")]
        public int ClientNumber { get; set; }

        // Basisvelden: ---------------------------------------------------- 

        public Invoice Invoice { get; set; }

        // Invoice lijnen:

        [DisplayName("Factuurregel 1:")]
        public string Line1 { get; set; }

        [DisplayName("Factuurregel 2:")]
        public string Line2 { get; set; }

        [DisplayName("Factuurregel 3:")]
        public string Line3 { get; set; }

    }
}