using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ziekenhuis.Model
{
    public class Consult
    {
       
        public int Id { get; set; }

        public char ActionCode { get; set; }
        // A or I

        //--------------------------------------------------------
        public int ClientId { get; set; }  // Consult kent 1 Client Id (FK)

        // Leg een N:1 relatie met Client, zie ook omgekeerde bij Client: 
        public Client Client { get; set; }  // Dit is een Foreign Key naar de HELE CLIENT tabel  

        //----------------------- onderstaande 2 velden creëren een FK in database-------- 
        public int DoctorId { get; set; }  // Consult kent 1 Doctor Id (FK)

        public Doctor Doctor { get; set; }  // Dit is een soort Foreign Key naar de hele Doctor tabel    

        //--------------------------------------------------------------------------------
        [Required(ErrorMessage = "Datum consult mag niet leeg zijn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Datum consult:")]
        public DateTime ConsultDate { get; set; }

        [DisplayName("Omschrijving consult:")]
        [Required(ErrorMessage = "Omschrijving consult mag niet leeg zijn")]
        public string ConsultDescr { get; set; }

        [Required(ErrorMessage = "Bedrag moet ingevuld zijn")]
        [DisplayName("Kosten van consult:")]
        public decimal Price { get; set; }

        //  NIET  [Required] - in de UI niet verplicht 
        [DisplayName("Dokter\'s commentaar:")]
        public string CommentForDoctor { get; set; }

    }
}
