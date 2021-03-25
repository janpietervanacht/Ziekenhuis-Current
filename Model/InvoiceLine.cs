using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ziekenhuis.Model
{
    public class InvoiceLine
        // deze tabel bevat niet meer dan 4 records per Factuur 
    {
        [Required]
        public int Id { get; set; }

        // Invoice Id wordt géén foreign key 
        // Dit is een master-slave constructie
        [Required]
        public int InvoiceId { get; set; }

        [Required]
        [DisplayName("Factuur-regel")]
        public string  Line { get; set; }
         
    }
}
