using System.Collections.Generic;
using System.ComponentModel;
using Ziekenhuis.Ziekenhuis.ViewModels.SubModels;

namespace Ziekenhuis.Ziekenhuis.ViewModels
{

    public class PrescrListViewModel
    {
        // Basisvelden: ---------------------------------------------------- 

        // Er wordt een clientId / doctorId als master weergegeven
        // Daarna volgt een lijst van actieve recepten, recept-lijnen zijn niet nodig 

        public int? ClientId { get; set; }
        public int? DoctorId { get; set; }

        [DisplayName("Naam client")]
        [ReadOnly(true)]
        public string ClientFullName { get; set; }

        [DisplayName("Naam arts:")]
        [ReadOnly(true)]
        public string DoctorFullName { get; set; }

        // ----------------------------------------------------------------- 

        public List <PrescrWithNames> PrescrList { get; set; }


    }
}
