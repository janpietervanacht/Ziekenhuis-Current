using System;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ziekenhuis.Model;

namespace Ziekenhuis.Ziekenhuis.ViewModels.SubModels
{
    public class PrescrWithNames
    {
        public string ClientFullName { get; set;  }
        public string DoctorFullName { get; set;  }
        public Prescription Prescripton { get; set;  }
    }
}
