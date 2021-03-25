using System.Collections.Generic;
using System.ComponentModel;

namespace Ziekenhuis.Ziekenhuis.ViewModels
{
    public class ClientListViewModel
    {
        // Basisvelden: ---------------------------------------------------- 

        // Er wordt een DoctorId als master weergegeven (kan leeg zijn, igv ADMIN) 
        // Daarna volgt een lijst van clienten

        public int? DoctorId { get; set; }

        [DisplayName("Naam van de arts:")]
        public string DoctorFullName { get; set; }

        // Dankzij deze substring kunnen we clienten op substring selecteren op zowel voor als achternaam 
        [DisplayName("Selecteer op sub-string:")]
        public string SubString { get; set; }

        [DisplayName("Selecteer op prefix-string:")]
        // Dankzij deze prefixstring kunnen we clienten met voornaam die begint met... selecteren
        public string PrefixString { get; set; } 

        // ----------------------------------------------------------------- 

        public List<ClientViewModel> ClientVMList { get; set; }
    }
}
