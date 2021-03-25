using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ziekenhuis.Model.ConstantsAndEnums;

namespace Ziekenhuis.Model
{
    // Client kan geen static class zijn
    // Want we zijn continue bezig om new Client{} te gebruiken, bijvoorbeeld in lijsten
    // Static classes bevatten nooit geen instance fields
    // Static classes hoeven geen gegevens vast te houden
    public class Client
    {
        public int Id { get; set; }

        //----------------------------------
        // Leg een 1:N relatie met Consult, zie ook omgekeerde bij Consult: 
        public List<Consult> ListOfConsults { get; set; }
        //----------------------------------

        public int DoctorId { get; set; }  // Consult kent 1 Doctor Id (FK)
        public Doctor Doctor { get; set; }  // Dit is een soort Foreign Key naar de hele Doctor tabel   
        //----------------------------------

        public int ClientNumber { get; set; }  // Het functionele client-nummer

        [Required]
        [RegularExpression("^[AI]$", ErrorMessage = "Waarde moet A/I zijn")]
        public char ActionCode { get; set; }

        [Required]
        public bool IsInsured { get; set; }  // Tbv checkbox in _ClientFieldsPartial.cshtml

        //-----------------------------------------------------------------
        // Gender: Man / Vrouw / Onzijdig - afgedwongen via radio-buttons
        // OPMERKING: als je hier [Required] plaatst, klapt de applicatie

        /*
         * The error message indicates that EF Core is trying 
         * to read string value for a required property, i.e. a property 
         * which should never has null value in the database, but instead 
         * the underlying data reader reports null value for 
         * that property in some record{s).
         * 
         */
        // [Required]  AFGESTERD! 
        public string Gender { get; set; }  // Tbv radiobuttons in _ClientFieldsPartial.cshtml
        //----------------------------------------------------------------- 

        [Required(ErrorMessage = "Voornaam is verplicht")]
        [DisplayName("Voornaam client:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht")]
        [DisplayName("Achternaam client:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Straat is verplicht")]
        [DisplayName("Straat:")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Huisnummer is verplicht")]
        [DisplayName("Huisnummer:")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "Post code is verplicht")]
        [DisplayName("Post code:")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Woonplaats is verplicht")]
        [DisplayName("Woonplaats:")]
        public string City { get; set; }

        //[Required(ErrorMessage = "Land is verplicht")]
        //[DisplayName("Land:")]
        // public string Country { get; set; }

        //----------------------------------
        public int? CountryId { get; set; }  // Client kent 1 land of géén land!!
        public Country Country { get; set; }  // Dit is een soort Foreign Key naar de hele country tabel   
        //----------------------------------


        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Geboortedatum:")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "\"Aanwezig budget\" is verplicht")]
        [DisplayName("Aanwezig budget:")]
        public decimal BudgetAvaiable { get; set; }

        [Required(ErrorMessage = "\"Verbruikt budget\" is verplicht")]
        [DisplayName("Verbruikt budget:")]
        public decimal BudgetSpent { get; set; }

        [DisplayName("Comment (Doctor only):")]
        public string CommentForDoctor { get; set; }

        [Required(ErrorMessage = "Polis-nummer is verplicht")]
        [DisplayName("Polis-nummer:")]
        public int PolicyNumber { get; set; }

        [Required] // dankzij deze data-annotation is tabel-veld not-null
        public string AstrologyZodiacSign { get; set; }

        [Required]
        public string TypeOfSporter { get; set; }

    }
}
