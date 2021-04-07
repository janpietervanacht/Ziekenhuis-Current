using System.ComponentModel;
using Ziekenhuis.Model;
using System.Collections.Generic;
using Ziekenhuis.ConstantsAndEnums;
using Ziekenhuis.ViewModels.SubModels;

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
        // met hun omschrijvingen.
        // Omdat Country een Id bevat, kunnen we bij Update Client view
        // als initiele waarde het land van deze client tonen.
        public IList<Country> Countries { get; set; }

        // in ViewModel nemen we alle sterrenbeelden mee
        // Omdat ZodiacVM een Id bevat, kunnen we bij Update Client view
        // als initiele waarde het sterrenbeeld van deze client tonen.
        public IList<ZodiacVM> AstrologyZodiacSignList { get; set; }

        // numerieke presentatie van sterrenbeeld van deze klant:
        // is nodig om bij Update View de juiste startwaarde in de combo box te tonen
        public int ZodiacId { get; set; }  
        // Idem voor SportType
        public int SportTypeId { get; set; }  

        // in ViewModel nemen we alle sport types mee
        public IList<SportTypeVM> SportTypeList { get; set; }

        // Basisvelden: ---------------------------------------------------- 

        public Client Client { get; set;  }

    }
}
