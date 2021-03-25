using System.Collections.Generic;
using System.ComponentModel;
using Ziekenhuis.Model;
using Ziekenhuis.Ziekenhuis.ViewModels.SubModels;

namespace Ziekenhuis.Ziekenhuis.ViewModels
{

    public class InvoiceListViewModel
    {
        // Basisvelden: ---------------------------------------------------- 

        // Er wordt een clientId / doctorId als master weergegeven
        // Daarna volgt een lijst van facturen 

        public int? ClientId { get; set; }

        public int? ClientNumber { get; set; } // functionele clientnummer
        public int? DoctorId { get; set; }

        [DisplayName("Totale naam:")]
        public string ClientFullName { get; set; }

        [DisplayName("Naam van de arts:")]
        public string DoctorFullName { get; set; }

        [DisplayName("Aantal facturen")]
        public int NumberOfInvoices { get; set; }


        // ----------------------------------------------------------------- 

        public List <InvoiceViewModel> InvoiceList { get; set; }


    }
}
