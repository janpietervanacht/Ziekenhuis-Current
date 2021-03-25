using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ziekenhuis.Model
{
    public class Prescription
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public char ActionCode { get; set; }


        //---------------------------------------------------------------
        [Required]
        public int ClientId { get; set; }  // Consult kent 1 Client Id (FK)

        public Client Client { get; set; }  // Dit is een soort Foreign Key naar de hele CLIENT tabel ??  

        //----------------------------------------------------------------
        [Required]
        public int DoctorId { get; set; }  // Consult kent 1 Doctor Id (FK)

         
        public Doctor Doctor { get; set; }

        //---------------------------------------------------------------


        [Required(ErrorMessage = "Datum recept mag niet leeg zijn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Datum recept:")]
        public DateTime PrescriptionDate { get; set; }

        [Required  (ErrorMessage = "Omschrijving recept mag niet leeg zijn")]
        [DisplayName("Omschrijving recept:")]
        public string  PrescriptionDescr { get; set; }

        [Required(ErrorMessage = "Bedrag moet ingevuld zijn")]
        [DisplayName("Prijs van recept:")]
        public decimal Price { get; set; }

        // NIET:  [Required]
        [DisplayName("Dokter\'s commentaar:")]
        public string CommentForDoctor { get; set; }
    }
}
