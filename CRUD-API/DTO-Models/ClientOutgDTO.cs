using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_API.DTO_Models
{
    // Niet alle clientgegevens exporteren we naar buiten
    // Bijv Id blijft intern
    // Ook exporteren we de naam van de dokter van deze klant
    // En we exporteren het totaal van de facturen van deze klant

    public class ClientOutgDTO
    {
        // ActionCode en DoctorId zijn interne velden, en staan nooit in een DTO

        // 1:1 velden uit Client: -------------------------------------------
        public int ClientNumber { get; set; }  // Het functionele client-nummer

        [Required]
        public bool IsInsured { get; set; }

        public string Gender { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set;  }

        public int HouseNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string CountryDescription { get; set; }
      
        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        public decimal BudgetAvaiable { get; set; }

        public decimal BudgetSpent { get; set; }

        public string AstrologyZodiacSign { get; set; }

        public string TypeOfSporter { get; set; }


        // Afgeleide velden: ------------------------------------------------
        public int NrOfActiveInvoices { get; set; } // Als dit 0 is, laten we dit veld weg
        public decimal TotalAmountOfInvoices { get; set; } // Als dit 0.00 is, laten we dit veld weg

        public string DoctorFullName { get; set;  }
    }
}
