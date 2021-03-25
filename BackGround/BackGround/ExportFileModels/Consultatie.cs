
using System;

namespace Background.ExportFileModels
{
    public class Consultatie
    {
        // Velden specifiek voor kleine klant: 
        public DateTime ConsultDatum { get; set; }

        public string ConsultOmschrijving { get; set; }
        public decimal PrijsVanConsult { get; set; }
    }
}
