using System.ComponentModel;
using Ziekenhuis.Model;
using System.Collections.Generic; 

namespace Ziekenhuis.Ziekenhuis.ViewModels
{
    // Dit ViewModel geeft alleen de belangrijkste client-velden mee
    public class ClientViewModel
    {
        // Afgeleide velden: ------------------------------------------ 

        [DisplayName("Naam van de arts:")]
        public string DoctorFullName { get; set; }

        [DisplayName("Totale naam client:")]
        public string ClientFullName { get; set; }

        [DisplayName("Leeftijd in dagen:")]
        public int AgeInDays { get; set; }

        [DisplayName("Aantal recepten:")]
        public int NrofPrescriptions { get; set; }

        // in ViewModel nemen we alle landen mee
        // zodat we in de CREATE en EDIT dropdownlist alle landen kunnen tonen
        // met hun omschrijvingen
        public IList<Country> Countries { get; set; }

        // Basisvelden: ---------------------------------------------------- 

        public Client Client { get; set;  }

    }
}
