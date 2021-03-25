using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Repositories
{

    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Country GetCountryById(int countryId)
        {
            return (_dbContext.Countries.Find(countryId));
        }

        public List<Country> GetAllCountries()
        {
            var countryList = _dbContext.Countries.ToList();
            return countryList;
        }

        public Country GetCountryByIsoCode(string isoCountryCode)
        {
            var result = _dbContext.Countries
                .Where(c => c.CountryCodeISO == isoCountryCode)
                .SingleOrDefault(); // klapt eruit als er 2 of meer bestaan
            return result; 
        }
    }
}
