using System;

namespace Ziekenhuis.WebApiClient.DTOModels
{
    // Niet alle clientgegevens zijn bekend bij de Client Applic
    // Bijv Id/DoctorId/ActionCode is alleen bij de server bekend

    // Redundante afgeleide velden bestaan niet in deze Outg Record: 
    // DoctorFullName, NrOfActiveInvoices, TotalAmountOfInvoices

    // Bij de WebAPI spreek ik over Incoming DTO
    // Die is identiek aan de Outg Record aan client zijde

    public class ClientRecordOutg
    {
        // ActionCode en DoctorId zijn interne velden, en staan nooit in een DTO

        // 1:1 velden uit Client: -------------------------------------------
        public int ClientNumber { get; set; }  // Het functionele client-nummer

        public bool IsInsured { get; set; }

        public string Gender { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string CountryCodeIso { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal BudgetAvaiable { get; set; }

        public decimal BudgetSpent { get; set; }

       
    }
}
