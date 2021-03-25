using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Managers
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepository _countryRepository;

        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository; // DI
        }

        public List<Country> GetAllCountries()
        {
            // Admin selects all clients
            var countryList = _countryRepository.GetAllCountries();
            return countryList; 
        }
    }
}
