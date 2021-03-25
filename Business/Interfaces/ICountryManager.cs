using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Interfaces
{
    public interface ICountryManager
    {
        List<Country> GetAllCountries();
    }
}