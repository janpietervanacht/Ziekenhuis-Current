using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface IInvoiceLineRepository
    {
        List<InvoiceLine> GetAll(); 
        void Add(InvoiceLine prescription);
        void Update(InvoiceLine prescription);

        void Delete(int id);

        InvoiceLine Get(int Id);

    }
}