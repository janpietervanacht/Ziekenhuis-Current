using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ziekenhuis.Model
{
    public class Country
    {
        public int Id { get; set; }

        public int SortNumber { get; set; }
        // Sortering 10, 20, 30 etc evt met tussenliggende waarden

        //--------------------------------------------------------
        public string CountryCodeISO { get; set; }  // NL, GB, US etc

        public string CountryDescription { get; set; }

    }
}
