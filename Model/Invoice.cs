using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ziekenhuis.Model
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Factuurnummer")]
        public int InvoiceNumber { get; set; }

        public char ActionCode { get; set; }
        // Waardes A, I

        // [Required]
        [DisplayName("Betaal-status factuur:")]
        public char Status { get; set; }
        // Waarden: O, P, C (Open, Partially Paid, Completely Paid) 

        // De schedular kijkt ieder uur of er facturen zijn met SendYN = N
        // en zet al deze facturen in één JSON file, status wordt dan SendYN = Y

        [DisplayName("Factuur verzonden:")]
        public char SendYN { get; set;  }

        //---------------------------------------------------------------
        public int ClientId { get; set; }  // Consult kent 1 Client Id (FK)

        public Client Client { get; set; }  // Dit is een soort Foreign Key naar de hele CLIENT tabel ??  

        //----------------------------------------------------------------

        public int DoctorId { get; set; }  // Consult kent 1 Doctor Id (FK)

        public Doctor Doctor { get; set; }

        //---------------------------------------------------------------



        [Required]
        [DisplayName("Factuuromschrijving")]
        public string InvoiceDescription { get; set; }

        [Required]
        // [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Vervaldatum:")]
        public DateTime DueDate { get; set; }


        [Required]
        [DisplayName("Betaald bedrag factuur:")]
        public decimal AmountPaid { get; set; }

        // NIET:  [Required]
        public string CommentForDoctor { get; set; }
    }
}
