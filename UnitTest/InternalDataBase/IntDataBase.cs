using System;
using System.Collections.Generic;
using UnitTest.Factories;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.Model;
using Ziekenhuis.Model.ConstantsAndEnums;

namespace Ziekenhuis.UnitTest.InternalDataBase
{
    static internal class IntDataBase
    {
        static Country _country1, _country2, _country3, _country4;
        static Doctor _doctor1, _doctor2; 

        public static void FillDbContext(ApplicationDbContext dbContext)
        {
            CreateCountryInternalDatabase(dbContext);
            CreateDoctorInternalDatabase(dbContext);
            CreateClientInternalDatabase(dbContext);
        }

        private static void CreateDoctorInternalDatabase(ApplicationDbContext dbContext)
        {
            _doctor1 = DoctorFactory.Create(
               1, "Bernard", "Verdriet", new DateTime(1964, 03, 21),
               new DateTime(2004, 10, 31), "Doctorlaan", 23, "5502HK", "Los Doctores",
               "Canada", DoctorTypeEnum.KNOarts);

            _doctor2 = DoctorFactory.Create(
                2, "Philip", "McGraw", new DateTime(1955, 06, 12),
                new DateTime(2014, 11, 08), "Fill-avenue", 23, "8000AB", "New York",
                "NewYork State", DoctorTypeEnum.Oorarts);

            var doctorList = new List<Doctor> { _doctor1, _doctor2 };
            foreach (var doctor in doctorList)
            {
                dbContext.Doctors.Add(doctor); // voeg toe aan intern-memory DB
                dbContext.SaveChanges();
            }
        }

        //------------------------------------------------------ 

        private static void CreateCountryInternalDatabase(ApplicationDbContext dbContext)
        {
            _country1 = CountryFactory.Create(
               "NL",
               "Nederland",
               1,
               10);

            _country2 = CountryFactory.Create(
                "BE",
                "België",
                2,
                20);

            _country3 = CountryFactory.Create(
                "US",
                "United States",
                3,
                30);

            _country4 = CountryFactory.Create(
               "DE",
               "Duitsland",
               4,
               44);

            var countryList = new List<Country> { _country1, _country2, _country3, _country4 };
            foreach (var country in countryList)
            {
                dbContext.Countries.Add(country); // voeg toe aan intern-memory DB
                dbContext.SaveChanges();
            }
        }

        //------------------------------------------------------- 

        private static void CreateClientInternalDatabase(ApplicationDbContext dbContext)
        {
            var client1 = ClientFactory.Create(
                new DateTime(1967, 11, 07),
                "Veldhoven",
                100001,
                _country1,
                _doctor1,
                "Man",
                "Jan-Pieter",
                113,
                1,
                "Van Acht",
                10020014,
                "5262BC",
                "Esschestraat"
               );

            var client2 = ClientFactory.Create(
                 new DateTime(1968, 04, 11),
                 "Oss",
                 100002,
                 _country1,
                 _doctor2,
                 "Vrouw",
                 "Natasja",
                 71,
                 2,
                 "De Groot",
                 100700,
                 "5000GH",
                 "Harnas"
                );

            var client3 = ClientFactory.Create(
                 new DateTime(1948, 12, 22),
                 "New York",
                 100003,
                 _country3,
                 _doctor2,
                 "Man",
                 "Donald",
                 500,
                 3,
                 "Trump",
                 10078123,
                 "6000AB",
                 "Trump Avenue"
                );

            var clientList = new List<Client> { client1, client2, client3 };
            foreach (var client in clientList)
            {
                dbContext.Clients.Add(client); // voeg toe aan intern-memory DB
                dbContext.SaveChanges();
            }

        }
    }
}
