using System;
using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Interfaces
{
    public interface IInvoiceManager
    {
        Invoice  GetInvoice(int invoiceId);

        List<InvoiceLine> GetInvoiceLines(int invoiceId);

        void UpdInvoiceAndLines(Invoice invoice, List<InvoiceLine> invLineList);

        void AddInvoiceAndLines(Invoice invoice, List<InvoiceLine> invLineList);

        void DelInvoice(int invoiceId); // verwijdert impliciet ook de lijnen

        List<Invoice> GetAllPerClient(int cltId);

        List<Invoice> GetAllPerDoctor(int doctorId);

        List<Invoice> GetAllPerDoctorPerClient(int doctorId, int ClientId);

        List<Invoice> GetAll(); // For ADMIN

        int RtvNewInvoiceNumber(); // Maak nieuw factuurnummer aan

        int NumberOfInvoicesPerClient(int clientId); 

    }
}