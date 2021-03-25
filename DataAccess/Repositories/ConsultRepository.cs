using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Repositories
{

    public class ConsultRepository : IConsultRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ConsultRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Consult consult)
        {
            // Op dit punt kent consult nog geen primary key (Id)
            _dbContext.Consults.Add(consult);
            _dbContext.SaveChanges();
            // Op dit punt kent consult wel een primary key (Id)
        }

        public void Delete(int consId)
        {
            Consult cons = _dbContext.Consults.Find(consId);
            _dbContext.Consults.Remove(cons);
            _dbContext.SaveChanges();
        }

        public Consult Get(int consId)
        {
            return _dbContext.Consults.Find(consId); 
        }

        public List<Consult> GetAll()
        {
            // Deferred:
            var result = _dbContext.Consults.OrderBy(p => p.ClientId).ThenBy(p => p.DoctorId);

            // Execute
            return result.ToList();
        }

        public List<Consult> GetAllPerClient(int clientId)
        {
            // Selecteer alle Consults van één client
            // Sorteer op DoctorId, daarna op Consult Id: 
            var result = _dbContext.Consults
                .Where(p => p.ClientId == clientId)
                .OrderBy(p => p.DoctorId)
                .ThenBy(p => p.Id)
                .ToList();
            return result;
        }

        public List<Consult> GetAllPerDoctor(int doctorId)
        {
            // Sorteer op ClientId, daarna op Consult Id:
            var result1 = from s in _dbContext.Consults
                          orderby s.ClientId, s.Id
                          where s.DoctorId == doctorId
                          select s;  // Deferred

            // Dit kan ook: 
            var result2 = _dbContext.Consults
                .OrderBy(p => p.ClientId)
                .ThenBy(p => p.Id)
                .Where(p => p.DoctorId == doctorId)
                .ToList();

            return result1.ToList(); // Hier pas executie op database
        }

        public List<Consult> GetAllPerDoctorAndPerClient(int doctorId, int clientId)
        {
            var result1 = from cons in _dbContext.Consults
                         orderby cons.Id
                         where (cons.DoctorId == doctorId && cons.ClientId == clientId)
                         select cons;

            // Dit kan ook: 
            var result2 = _dbContext.Consults
                         .Where(c => c.ClientId == clientId && c.DoctorId == doctorId)
                         .OrderBy(c => c.Id).ToList();
            
            // return result1.ToList();   KAN OOK
            return result2; 

        }

        public int NumberOfConsultsPerClient(int clientId)
        {
            var result = _dbContext.Consults.Where(cons => cons.ClientId == clientId).Count();
            return result; 
        }

        public void Update(Consult cons)
        {
            _dbContext.Entry(cons).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
