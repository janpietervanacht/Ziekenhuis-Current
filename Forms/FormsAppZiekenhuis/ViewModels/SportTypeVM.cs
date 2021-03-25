using FormsAppZiekenhuis.ConstantsAndEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsAppZiekenhuis.ViewModels
{
    class SportTypeVM
    {
        public SportType SportType { get; set; }
        public string lineInComboBox  // automatisch gevuld
        {
            get
            {
                return SportType.ToString();
            }
        }
    }
}
