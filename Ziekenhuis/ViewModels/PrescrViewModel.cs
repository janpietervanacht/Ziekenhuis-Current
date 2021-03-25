using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ziekenhuis.Model;

namespace Ziekenhuis.Ziekenhuis.ViewModels 
{
    public class PrescrWith5LinesViewModel
        // Opmerking: Ik heb de filenaam veranderd
        // van PrescrWith5Lines.cs naar PrescrViewModel.cs
        //
        // doe geen rename van de class hieronder.
        // Dan built de applicatie niet meer.
        // RENAMEN VAN VIEWMODELS IS GEVAARLIJK
    {
        [DisplayName("Totale naam:")]
        public string ClientFullName { get; set;  }


        [DisplayName("Naam van de arts:")]
        public string DoctorFullName { get; set;  }

        public Prescription Prescription { get; set;  }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }

    }
}
