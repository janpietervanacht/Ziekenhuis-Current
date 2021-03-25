using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Managers
{
    public class InvoiceManager : IInvoiceManager
    {

        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceManager(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }


        public void AddInvoiceAndLines(Invoice invoice, List<InvoiceLine> invLineList)
        {
            _invoiceRepository.Add(invoice, invLineList);
        }

        public void DelInvoice(int invoiceId)
        {
            // Verwijder eerst de lijnen, daarna de header
            // Als je het andersom doet: dan is de database tijdelijk niet integer
            _invoiceRepository.DeleteAllLines(invoiceId);
            _invoiceRepository.Delete(invoiceId);
        }

        public List<Invoice> GetAll()
        {
            var result = _invoiceRepository.GetAll();
            return result;
        }

        public List<Invoice> GetAllPerClient(int clientId)
        {
            return _invoiceRepository.GetAllPerClient(clientId);
        }

        public List<Invoice> GetAllPerDoctor(int doctorId)
        {
            var result = _invoiceRepository.GetAllPerDoctor(doctorId);
            return result;
        }

        public List<Invoice> GetAllPerDoctorPerClient(int doctorId, int clientId)
        {
            var result = _invoiceRepository.GetAllPerDoctorAndPerClient(doctorId, clientId);
            return result;
        }

        public Invoice GetInvoice(int invoiceId)
        {
            var result = _invoiceRepository.Get(invoiceId);
            return result;
        }

        public List<InvoiceLine> GetInvoiceLines(int invoiceId)
        {
            var result = _invoiceRepository.GetInvLines(invoiceId);
            return result;
        }

        public int NumberOfInvoicesPerClient(int clientId)
        {
            var result = _invoiceRepository.NumberOfInvoicesPerClient(clientId);
            return result;
        }

        public int RtvNewInvoiceNumber()
        {
            var newInvoiceNumber = _invoiceRepository.GetAndUpdateCurrentInvoiceNumber();
            return newInvoiceNumber;
        }

        public void UpdInvoiceAndLines(Invoice invoice, List<InvoiceLine> invLineList)
        {
            _invoiceRepository.Upd(invoice, invLineList);
        }
    }
}
