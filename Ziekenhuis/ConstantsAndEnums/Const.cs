using System;
using System.Collections.Generic;
using System.Text;

namespace Ziekenhuis.ConstantsAndEnums
{
    public static class Const
    {
        public static DateTime cMinBirthDate = new DateTime(1900, 01, 01);  // YY MM DD 
        public const decimal cMaxBudget = 20000.00m;
        public const decimal cMinBudget = 1000.00m;
        public const string cAuthor = "Jan-Pieter van Acht";
    }
}
