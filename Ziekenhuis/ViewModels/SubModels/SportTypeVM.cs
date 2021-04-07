using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ziekenhuis.Model;

namespace Ziekenhuis.ViewModels.SubModels
{
    // Om bij een update client de betreffende type sporter
    // te kunnen tonen, moet de combo-box in de cshtml een Id bevatten.
    // Net zoals bij het tonen van het land van de client.
    // Vandaar de class SportTypeVM:
    public class SportTypeVM
    {
        public int Id { get; set; }
        public string TypeOfSporter { get; set; }
    }
}
