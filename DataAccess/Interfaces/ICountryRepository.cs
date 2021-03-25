using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries(); // For Admin

        Country GetCountryById(int countryId);

        Country GetCountryByIsoCode(string isoCountryCode);
    }
}