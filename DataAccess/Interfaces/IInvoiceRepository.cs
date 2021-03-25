using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAll(); // voor ADMIN only
        List<Invoice> GetAllPerDoctor(int doctorId);
        List<Invoice> GetAllPerClient(int clientId);

        int NumberOfInvoicesPerClient(int clientId);

        List<Invoice> GetAllPerDoctorAndPerClient(int doctorId, int clientId);

        void Add(Invoice invoice, List<InvoiceLine> invLineList);

        void Upd(Invoice invoice, List<InvoiceLine> invLineList);

        void Delete(int invoiceId);
        void DeleteAllLines(int invoiceId);  // Alle lijnen van 1 recept

        Invoice Get(int invoiceId);

        Invoice GetByInvoiceNumber(int invoiceNumber); 

        List<InvoiceLine> GetInvLines(int invoiceId);

        int GetAndUpdateCurrentInvoiceNumber();

        List<Invoice> GetAllNotSend();

        void UpdateInvoiceOnly(Invoice invoice); // Geen update van de lijnen nodig

    }
}