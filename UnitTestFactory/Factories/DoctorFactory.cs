using System;
using Ziekenhuis.Model;
using Ziekenhuis.Model.ConstantsAndEnums;

namespace UnitTestFactory.Factories
{
    public static class DoctorFactory
    {
        public static Doctor Create(int id, string firstName,
            string LastName, DateTime birthDate, DateTime dateEmployed,
            string street, int houseNumber, string postalCode, string city,
            string countryName, DoctorTypeEnum doctorType)
        {
            return new Doctor
            {
                Id = id,
                ActionCode = 'A',
                FirstName = firstName,
                LastName = LastName,
                BirthDate = birthDate,
                DateEmployed = dateEmployed,
                Street = street,
                HouseNumber = houseNumber,
                PostalCode = postalCode,
                City = city,
                Country = countryName,
                DoctorType = DoctorTypeEnum.Oogarts
            }; 
        }
    }
}
