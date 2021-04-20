using System;
using System.Collections.Generic;
using System.Text;
using Ziekenhuis.Model;
using Ziekenhuis.Model.ConstantsAndEnums;

namespace UnitTestSetupMockedData.SetUpsMockedData
{
    public static partial class SetupMockedData
    {

        public static List<Client> RtvMockedClientList() 
            // Hier wordt géén gebruik gemaakt van intern-memory database
        {
            Doctor doctor = RtvDoctor();  // we werken maar met één doctor
            Country country = RtvCountry();

            var listClient = new List<Client>
            {
                new Client
                {
                    ActionCode = 'A',
                    BirthDate = new DateTime(67, 11, 7),
                    BudgetAvaiable = 1000.00m,
                    BudgetSpent = 500.00m,
                    City = "Veldhoven",
                    ClientNumber = 100001,
                    CommentForDoctor = "Klant nummer 100001",
                    CountryId = 1,
                    Country = country,
                    Doctor = doctor,
                    DoctorId = 1,
                    Gender = "Man",
                    FirstName = "Jan-Pieter met zubstrinG erin",
                    HouseNumber = 115,
                    Id = 1,
                    IsInsured = true,
                    LastName = "van Acht",
                    PolicyNumber = 10001,
                    PostalCode = "5262BC",
                    Street = "Esschestraat",
                    ListOfConsults = null,
                    AstrologyZodiacSign = "Leeuw",
                    TypeOfSporter = "Geen"
                },
                new Client
                {
                    ActionCode = 'A',
                    BirthDate = new DateTime(64, 03, 21),
                    BudgetAvaiable = 1000.00m,
                    BudgetSpent = 600.00m,
                    City = "Eindhoven",
                    ClientNumber = 100003,
                    CommentForDoctor = "Klant nummer 100003",
                    CountryId = 1,
                    Country = country,
                    Doctor = doctor,
                    DoctorId = 1,
                    Gender = "Man",
                    FirstName = "Jan met ZUBString erin",
                    HouseNumber = 63,
                    Id = 2,
                    IsInsured = true,
                    LastName = "Roggeband",
                    PolicyNumber = 10004522,
                    PostalCode = "5503AB",
                    Street = "Hoogoorddreef",
                    ListOfConsults = null,
                    AstrologyZodiacSign = "Maagd",
                    TypeOfSporter = "Denk"
                },
                 new Client
                {
                    ActionCode = 'A',
                    BirthDate = new DateTime(69, 08, 18),
                    BudgetAvaiable = 2000.00m,
                    BudgetSpent = 400.00m,
                    City = "Rosmalen",
                    ClientNumber = 100005,
                    CommentForDoctor = "Klant nummer 100005",
                    CountryId = 1,
                    Country = country,
                    Doctor = doctor,
                    DoctorId = 1,
                    Gender = "Man",
                    FirstName = "Vriend Peter",
                    HouseNumber = 23,
                    Id = 3,
                    IsInsured = true,
                    LastName = "Moors",
                    PolicyNumber = 20014234,
                    PostalCode = "5245BH",
                    Street = "Tertsweg",
                    ListOfConsults = null,
                    AstrologyZodiacSign = "Schorpioen",
                    TypeOfSporter = "Team"
                },
                  new Client
                {
                    ActionCode = 'A',
                    BirthDate = new DateTime(65, 06, 18),
                    BudgetAvaiable = 2000.00m,
                    BudgetSpent = 400.00m,
                    City = "Vught",
                    ClientNumber = 100004,
                    CommentForDoctor = "Klant nummer 100004",
                    CountryId = 1,
                    Country = country,
                    Doctor = doctor,
                    DoctorId = 1,
                    Gender = "Man",
                    FirstName = "Peter Paul",
                    HouseNumber = 23,
                    Id = 4,
                    IsInsured = true,
                    LastName = "van de Boomen",
                    PolicyNumber = 20014234,
                    PostalCode = "1033BH",
                    Street =  "Hoge Dreef",
                    ListOfConsults = null,
                    AstrologyZodiacSign = "Boogschutter",
                    TypeOfSporter = "Team"
                },
                  new Client
                  {
                    ActionCode = 'A',
                    BirthDate = new DateTime(1980, 06, 18),
                    BudgetAvaiable = 2000.00m,
                    BudgetSpent = 400.00m,
                    City = "New York",
                    ClientNumber = 100002,
                    CommentForDoctor = "Klant nummer 100002",
                    CountryId = 1,
                    Country = country,
                    Doctor = doctor,
                    DoctorId = 1,
                    Gender = "Man",
                    FirstName = "Jan Papperazi",
                    HouseNumber = 500,
                    Id = 5,
                    IsInsured = false,
                    LastName = "van de Papieren Razia",
                    PolicyNumber = 20014238,
                    PostalCode = "4500AH",
                    Street =  "Paper Street",
                    ListOfConsults = null,
                    AstrologyZodiacSign = "Stier",
                    TypeOfSporter = "Denk"
                }

            };

            return listClient;
        }

        // --------------------------------------------- 
        public static Country RtvCountry()
        {
            var country = new Country
            {
                CountryCodeISO = "NL",
                CountryDescription = "Nederland",
                Id = 1,
                SortNumber = 10
            };

            return country;
        }

        public static Doctor RtvDoctor()
        {
            var doctor = new Doctor
            {
                ActionCode = 'A',
                City = "Veldhoven",
                BirthDate = new DateTime(1968, 03, 28),
                Country = "DoctorLand",
                DateEmployed = new DateTime(2020, 4, 26), // bevrijdingsdag
                DoctorType = DoctorTypeEnum.KNOarts,
                FirstName = "Huilende dokter Bernard",
                HouseNumber = 100,
                Id = 1,
                LastName = "Jankerd",
                PostalCode = "5502HK",
                Street = "De Trog"
            };

            return doctor;
        }
    }
}
