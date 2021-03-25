using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Repositories
{

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Invoice invoice, List<InvoiceLine> invLineList)
        {
            // Op dit punt kent invoice nog geen primary key (Id)
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();
            // Op dit punt kent invoice wel een primary key (Id)

            foreach (var invLine in invLineList)
            {
                invLine.InvoiceId = invoice.Id;
                _dbContext.InvoiceLines.Add(invLine);
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int invoiceId)
        {
            Invoice invoice = _dbContext.Invoices.Find(invoiceId);
            _dbContext.Invoices.Remove(invoice);
            _dbContext.SaveChanges();
        }

        public void DeleteAllLines(int invoiceId)
        {
            // VERGEET DE TOLIST() NIET UIT ONDERSTAAND COMMANDO
            // ANDERS LUKT DE SaveChanges() bij (*) niet vanwege locking.

            var invLineListDb = (from i1 in _dbContext.InvoiceLines
                                 where i1.InvoiceId == invoiceId
                                 select i1)
                               .ToList();  // ToList() niet vergeten 

            foreach (var i in invLineListDb)
            {
                // InvoiceLine invoiceLine =_dbContext.InvoiceLines.Find(invLine.Id);  // NEE, NIET DOEN
                _dbContext.InvoiceLines.Remove(i);
                _dbContext.SaveChanges();  // (*)
            }
        }

        public Invoice Get(int invoiceId)
        {
            // var result = _dbContext.Invoices.Find(invoiceId);  // Client niet gevuld

            var result = _dbContext.Invoices
                .Where(i => i.Id == invoiceId).Include(i => i.Doctor).Include(i => i.Client).ThenInclude(c => c.Country)
                .SingleOrDefault();

            return result;
        }

        public List<Invoice> GetAll()
        {
            // 1. Deferred: result is van type IOrderedQueryable<Invoice> - een verzameling Invoice elementen, die queryable is
            var result1 = _dbContext.Invoices
                .OrderBy(i => i.DoctorId)
                .ThenBy(i => i.ClientId)
                .Include(i => i.Doctor)
                .Include(i => i.Client).ThenInclude(c => c.Country); // FK Country kan null zijn bij een client

            // 2. Execute in database (FirstOrDefault, SingleOrDefault, Count, ToList ... wellicht nog meer)
            // Variabele result is van type List<Invoice> 
            var result = result1.ToList();

            // Execute
            return result;
        }

        public List<Invoice> GetAllNotSend()
        {
            var result = _dbContext.Invoices
               .Where(i => i.SendYN == 'N')
               .Include(i => i.Doctor)
               .Include(i => i.Client).ThenInclude(c => c.Country) // Country mag leeg zijn voor een client
               .ToList();
            return result;
        }

        public List<Invoice> GetAllPerClient(int clientId)
        {
            var result = _dbContext.Invoices
                .Where(i => i.ClientId == clientId)
                .Include(i => i.Doctor)
                .Include(i => i.Client).ThenInclude(c => c.Country) // Country mag leeg zijn voor een client
                .OrderBy(i => i.DoctorId)
                .ThenBy(i => i.Id).ToList();
            return result;
        }

        public List<Invoice> GetAllPerDoctor(int doctorId)
        {
            // Sorteer op ClientId, daarna op Invoice Id:
            var result1 = from i in _dbContext.Invoices
                          orderby i.ClientId, i.Id
                          where i.DoctorId == doctorId
                          select i;  // Deferred

            // Dit kan ook: 
            var result2 = _dbContext.Invoices
                .OrderBy(i => i.ClientId)
                .ThenBy(i => i.Id)
                .Where(i => i.DoctorId == doctorId)
                .Include(i => i.Doctor)
                .Include(i => i.Client).ThenInclude(c => c.Country) // Country mag leeg zijn voor een client
                .ToList();

            return result2.ToList(); // Hier pas executie op database 
        }

        public List<Invoice> GetAllPerDoctorAndPerClient(int doctorId, int clientId)
        {
            var result = from i in _dbContext.Invoices
                         where (i.DoctorId == doctorId && i.ClientId == clientId)
                         orderby i.Id
                         select i;
            return result.ToList();
        }

        public int GetAndUpdateCurrentInvoiceNumber()
        {
            // tabel NumberRanges bevat maar één record
            var numberRange = _dbContext.NumberRanges.Find(1);
            numberRange.CurrentInvoiceNumber++;
            if (numberRange.CurrentInvoiceNumber >= numberRange.MaxInvoiceNumber)
            {
                numberRange.CurrentInvoiceNumber = 1;
            }
            _dbContext.Entry(numberRange).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return numberRange.CurrentInvoiceNumber;
        }

        public Invoice GetByInvoiceNumber(int invoiceNumber)
        {
            //  Nesting is Invoice.Client.Country 
            //  Invoice id = 1046 =  100000043:  heeft client id = 1011, clientnumber = 100002, kent geen country
            var result = _dbContext.Invoices
                .Where(i => i.InvoiceNumber == invoiceNumber)
                .Include(i => i.Doctor)
                .Include(i => i.Client)
                .ThenInclude(c => c.Country) // Country mag leeg zijn voor een client
                .SingleOrDefault();
            return result;
        }

        public List<InvoiceLine> GetInvLines(int invoiceId)
        {
            var result1 = _dbContext.InvoiceLines
                .Where(i => i.InvoiceId == invoiceId)
                .OrderBy(i => i.Id); // deferred

            // Executie in database:
            var result = result1.ToList();

            return result.ToList();
        }

        public int NumberOfInvoicesPerClient(int clientId)
        {
            var nrOfInvoices = _dbContext.Invoices
                .Where(i => i.ClientId == clientId).Count();

            return nrOfInvoices;

            // Het ophalen van een OUTPUT parameter uit een stored procedure was niet gelukt
            // een gevecht van 2 uur. NIET MEER DOEN
            // HIERONDER STAAT DE POGING, DIE NIET WERKT

            ////   https://erikej.github.io/efcore/2020/08/03/ef-core-call-stored-procedures-out-parameters.html

            //var _clientId = new SqlParameter
            //{
            //    ParameterName = "clientId",
            //    SqlDbType = System.Data.SqlDbType.Int,
            //    Value = clientId,
            //    Direction = System.Data.ParameterDirection.Input
            //};

            //var _nrOfInvoices = new SqlParameter  // output variabele
            //{
            //    ParameterName = "nrOfInvoices",
            //    SqlDbType = System.Data.SqlDbType.Int,
            //    Direction = System.Data.ParameterDirection.Output,
            //};

            //// https://stackoverflow.com/questions/45252959/entity-framework-core-using-stored-procedure-with-output-parameters

            //var result = _dbContext.Database.ExecuteSqlRaw("exec uspNumberOfInvoicesPerClient @clientId, @nrOfInvoices OUT"
            //    , _clientId, _nrOfInvoices); 

            //int numberOfInvoices = (int)_nrOfInvoices.Value; 
            //return numberOfInvoices;
        }

        public void Upd(Invoice invoice, List<InvoiceLine> invLineList)
        {
            _dbContext.Entry(invoice).State = EntityState.Modified;
            _dbContext.SaveChanges();

            // Verwijder eerst alle invLines uit de database
            // VERGEET DE TOLIST() NIET UIT ONDERSTAAND COMMANDO
            // ANDERS LUKT DE SaveChanges() bij (*) niet vanwege locking.

            var invLineListDB = (from invLine in _dbContext.InvoiceLines
                                 where invLine.InvoiceId == invoice.Id
                                 select invLine).ToList();  // ToList() niet vergeten 

            foreach (var invLine in invLineListDB)
            {
                // PrescriptionLine prescrLine =_dbContext.PrescriptionLines.Find(p.Id);  // NEE, NIET DOEN
                _dbContext.InvoiceLines.Remove(invLine);
                _dbContext.SaveChanges();  // (*)
            }

            // Voeg alle invLines uit het scherm toe aan de database 
            foreach (var invLine in invLineList)
            {
                _dbContext.InvoiceLines.Add(invLine);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateInvoiceOnly(Invoice invoice)
        {
            _dbContext.Entry(invoice).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
