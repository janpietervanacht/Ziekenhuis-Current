using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface IPrescrRepository
    {
        List<Prescription> GetAll(); // voor ADMIN only
        List<Prescription> GetAllPerDoctor(int DoctorId); 
        List<Prescription> GetAllPerClient(int ClientId);
        List<Prescription> GetAllPerDoctorAndPerClient(int doctorId, int clientId);

        void Add(Prescription prescr, List<PrescriptionLine> pLineList);

        void Upd(Prescription prescription, List<PrescriptionLine> pLineList);

        void Delete(int id);
        void DeleteAllLines(int id);  // Alle lijnen van 1 recept

        Prescription Get(int Id);
        List<PrescriptionLine> GetPLines(int id);
        
    }
}