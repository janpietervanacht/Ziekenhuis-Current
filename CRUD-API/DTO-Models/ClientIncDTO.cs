using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_API.DTO_Models
{
    // Niet alle clientgegevens mogen worden opgestuurd
    // Slechts de belangrijkste velden
    // De API zal de overige velden uit Client automatisch aanvullen
    // met 'NOG AAN TE PASSEN'
    public class ClientIncDTO
    {
        // ActionCode en DoctorId zijn interne velden, en staan nooit in een DTO

        // ClientNumber is niet verplicht, men kan ook een client toevoegen
        public int ClientNumber { get; set; }  // Het functionele client-nummer

        [Required]
        public bool IsInsured { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")] // We gaan kijken of ErrMsg werkt bij inc DTO
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int HouseNumber { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string CountryCodeISO { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy/MM/dd}")] // We gaan kijken of dit werkt bij een inc DTO
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "\"Aanwezig budget\" is verplicht")]
        public decimal BudgetAvaiable { get; set; }

        [Required(ErrorMessage = "\"Verbruikt budget\" is verplicht")]
        public decimal BudgetSpent { get; set; }

        [Required]
        public string AstrologyZodiacSign { get; set; }

        [Required]
        public string TypeOfSporter { get; set; }

        public string CommentForDoctor { get; set; }

        [Required(ErrorMessage = "Polis-nummer is verplicht")]
        public int PolicyNumber { get; set; }
    }
}
