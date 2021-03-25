using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Ziekenhuis.Model;

namespace UnitTest.Factories
{
    public static class CountryFactory
    {
        public static Country Create(string countryCodeIso,
            string countryDescription, int id, int sortNumber)
        {
            return new Country
            {
                CountryCodeISO = countryCodeIso,
                CountryDescription = countryDescription,
                Id = id,
                SortNumber = sortNumber
            }; 
        }
    }
}
