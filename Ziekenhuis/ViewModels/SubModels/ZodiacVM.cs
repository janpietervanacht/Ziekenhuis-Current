﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ziekenhuis.Model;

namespace Ziekenhuis.ViewModels.SubModels
{
    // Om bij een update client de betreffende sterrenbeeld
    // te kunnen tonen, moet de combo-box in de cshtml een Id bevatten.
    // Net zoals bij het tonen van het land van de client.
    // Vandaar de class ZodiacVM:
    public class ZodiacVM
    {
        public int Id { get; set; }
        public string AstrologyZodiacSign { get; set; }
    }
}
