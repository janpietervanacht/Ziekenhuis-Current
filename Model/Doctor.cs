using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ziekenhuis.Model.ConstantsAndEnums;

namespace Ziekenhuis.Model
{
    public class Doctor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public char ActionCode { get; set; }

        [Required]
        [DisplayName("Voornaam client:")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Achternaam client:")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Straat:")]
        public string Street { get; set; }

        [Required]
        [DisplayName("Huisnummer:")]
        public int HouseNumber { get; set; }

        [Required]
        [DisplayName("Post code:")]
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("Woonplaats:")]
        public string City { get; set; }

        [Required]
        [DisplayName("Country:")]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("GeboorteDatum:")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Datum in dienst:")]
        public DateTime DateEmployed { get; set; }

        [Required]
        [DisplayName("Soort Doctor:")]
        public DoctorTypeEnum DoctorType { get; set; }  

    }
}
