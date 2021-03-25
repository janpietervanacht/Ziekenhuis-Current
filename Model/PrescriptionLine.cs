using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ziekenhuis.Model
{
    public class PrescriptionLine
        // deze tabel bevat niet meer dan 5 records per Prescription 
        // We introduceren geen schermen voor alleen Prescription lines, 
        // Dus is er geen PrescriptionLineController
    {
        [Required]
        public int Id { get; set; }

        // Prescription Id wordt géén foreign key 
        // Dit is een master-slave constructie
        [Required]
        public int PrescriptionId { get; set; }

        [Required]
        [DisplayName("Recept-regel:")]
        public string  Line { get; set; }
         
    }
}
