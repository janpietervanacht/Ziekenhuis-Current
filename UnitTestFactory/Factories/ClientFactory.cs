using System;
using Ziekenhuis.Model;

namespace UnitTestFactory.Factories
{
    public static class ClientFactory
    // Een factory is de plek waar het NEW statement wordt gebruikt om 
    // een nieuwe entiteit aan te maken. 
    {
        public static Client Create(
            DateTime birthDate, string city, int clientNumber, Country country, Doctor doctor, string gender,
            string firstname, int houseNumber, int id, string lastName, int policyNumber,
            string postalCode, string street, string astrologyZodiacSign, string typeOfSporter)
        {
            return new Client
            {
                ActionCode = 'A',
                BirthDate = birthDate,
                BudgetAvaiable = 0,
                BudgetSpent = 0,
                City = city,
                ClientNumber = clientNumber,
                CommentForDoctor = "Toets uw doctor mening in",
                CountryId = 1,
                Country = country,
                Doctor = doctor,
                DoctorId = 1,
                Gender = gender,
                FirstName = firstname,
                HouseNumber = houseNumber,
                Id = id,
                IsInsured = true,
                LastName = lastName,
                PolicyNumber = policyNumber,
                PostalCode = postalCode,
                Street = street,
                ListOfConsults = null,
                AstrologyZodiacSign = astrologyZodiacSign,
                TypeOfSporter = typeOfSporter
            };

        }
    }
}
