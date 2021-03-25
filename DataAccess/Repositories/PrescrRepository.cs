using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Repositories
{

    public class PrescrRepository : IPrescrRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PrescrRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Prescription prescr, List<PrescriptionLine> pLineList)
        {
            // Op dit punt kent prescr nog geen primary key (Id)
            _dbContext.Prescriptions.Add(prescr);
            _dbContext.SaveChanges();
            // Op dit punt kent prescr wel een primary key (Id)

            foreach (var pLine in pLineList)
            {
                pLine.PrescriptionId = prescr.Id; 
                _dbContext.PrescriptionLines.Add(pLine);
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int prescrId)
        {
            Prescription prescr = _dbContext.Prescriptions.Find(prescrId);
            _dbContext.Prescriptions.Remove(prescr);
            _dbContext.SaveChanges();
        }

        public void DeleteAllLines(int prescrId)
        {
            // VERGEET DE TOLIST() NIET UIT ONDERSTAAND COMMANDO
            // ANDERS LUKT DE SaveChanges() bij (*) niet vanwege locking.

            var pLineListDb = (from p3 in _dbContext.PrescriptionLines
                               where p3.PrescriptionId == prescrId
                               select p3).ToList();  // ToList() niet vergeten 

            foreach (var p in pLineListDb)
            {
                // PrescriptionLine prescrLine =_dbContext.PrescriptionLines.Find(p.Id);  // NEE, NIET DOEN
                _dbContext.PrescriptionLines.Remove(p);
                _dbContext.SaveChanges();  // (*)
            }

        }

        public Prescription Get(int id)
        {
            var result = _dbContext.Prescriptions.Find(id);
            return result;
        }

        public List<Prescription> GetAll()
        {
            // Deferred:
            var result = _dbContext.Prescriptions.OrderBy(p => p.ClientId).ThenBy(p => p.DoctorId);

            // Execute
            return result.ToList();
        }


        public List<Prescription> GetAllPerClient(int clientId)
        {
            // Selecteer alle Prescriptions van één client
            // Sorteer op DoctorId, daarna op Prescr Id: 
            var result = _dbContext.Prescriptions.Where(p => p.ClientId == clientId).
                OrderBy(p => p.DoctorId).ThenBy(p => p.Id).ToList();
            return result;
        }

        public List<Prescription> GetAllPerDoctor(int doctorId)
        {
            // Sorteer op ClientId, daarna op Prescr Id:
            var result1 = from s in _dbContext.Prescriptions
                          orderby s.ClientId, s.Id
                          where s.DoctorId == doctorId
                          select s;  // Deferred

            // Dit kan ook: 
            var result2 = _dbContext.Prescriptions.OrderBy(p => p.ClientId).
                ThenBy(p => p.Id).Where(p => p.DoctorId == doctorId).ToList();

            return result1.ToList(); // Hier pas executie op database
        }

        public List<Prescription> GetAllPerDoctorAndPerClient(int doctorId, int clientId)
        {
            var result = from p in _dbContext.Prescriptions
                         where (p.DoctorId == doctorId && p.ClientId == clientId)
                         orderby p.Id
                         select p;
            return result.ToList();  
        }

        public List<PrescriptionLine> GetPLines(int prescrId)
        {
            var result = _dbContext.PrescriptionLines
                .Where(pl => pl.PrescriptionId == prescrId)
                .OrderBy(pl => pl.Id);

            return result.ToList();
        }

        public void Upd(Prescription prescr, List<PrescriptionLine> pLineList)
        {
            _dbContext.Entry(prescr).State = EntityState.Modified;
            _dbContext.SaveChanges();

            // Verwijder eerst alle pLines uit de database
            // VERGEET DE TOLIST() NIET UIT ONDERSTAAND COMMANDO
            // ANDERS LUKT DE SaveChanges() bij (*) niet vanwege locking.

            var pLineListDb = (from p3 in _dbContext.PrescriptionLines
                             where p3.PrescriptionId == prescr.Id
                              select p3).ToList();  // ToList() niet vergeten 

            foreach (var p in pLineListDb)
            {
                // PrescriptionLine prescrLine =_dbContext.PrescriptionLines.Find(p.Id);  // NEE, NIET DOEN
                _dbContext.PrescriptionLines.Remove(p);    
                _dbContext.SaveChanges();  // (*)
            }

            // Voeg alle pLines uit het scherm toe aan de database 

            foreach (var p in pLineList)
            {
                _dbContext.PrescriptionLines.Add(p); 
                _dbContext.SaveChanges();
            }

        }
    }
}
