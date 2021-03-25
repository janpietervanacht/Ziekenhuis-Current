using System.ComponentModel;
using Ziekenhuis.Model;

namespace Ziekenhuis.Ziekenhuis.ViewModels
{
    // Dit ViewModel geeft alleen de belangrijkste client-velden mee
    public class ConsultViewModel
    {
        // Afgeleide velden: ------------------------------------------ 

        [DisplayName("Naam van de arts:")]
        public string DoctorFullName { get; set; }

        [DisplayName("Totale naam:")]
        public string ClientFullName { get; set; }

        // Basisvelden: ---------------------------------------------------- 

        public Consult Consult { get; set; }

    }
}