using System;

namespace Ziekenhuis.WebApiClient.DTOModels
{
    // Niet alle clientgegevens komen de client binnen
    // Bijv Id/DoctorId/ActionCode is alleen bij de server bekend

    // Er komen redundante afgeleide velden binnen:
    // DoctorFullName, NrOfActiveInvoices, TotalAmountOfInvoices

    // Bij de WebAPI spreek ik over Outgoing DTO
    // Die is identiek aan de Incoming Record aan client zijde

    public class ClientRecordInc
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

        public string CountryDescription { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal BudgetAvaiable { get; set; }

        public decimal BudgetSpent { get; set; }

        // Afgeleide velden: ------------------------------------------------
        public int NrOfActiveInvoices { get; set; } // Als dit 0 is, laten we dit veld weg
        public decimal TotalAmountOfInvoices { get; set; } // Als dit 0.00 is, laten we dit veld weg

        public string DoctorFullName { get; set; }
    }
}
