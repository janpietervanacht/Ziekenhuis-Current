using System.Collections.Generic;
using System.ComponentModel;
using Ziekenhuis.Model;
using Ziekenhuis.Ziekenhuis.ViewModels.SubModels;

namespace Ziekenhuis.Ziekenhuis.ViewModels
{

    public class ConsultListViewModel
    {
        // Basisvelden: ---------------------------------------------------- 

        // Er wordt een clientId / doctorId als master weergegeven
        // Daarna volgt een lijst van consulten  

        public int? ClientId { get; set; }
        public int? DoctorId { get; set; }

        [DisplayName("Totale naam:")]
        public string ClientFullName { get; set; }
        [DisplayName("Naam van de arts:")]
        public string DoctorFullName { get; set; }

        // ----------------------------------------------------------------- 

        public List<ConsultViewModel> ConsultList { get; set; }

    }
}
