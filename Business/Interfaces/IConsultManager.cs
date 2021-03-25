using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Interfaces
{
    public interface IConsultManager
    {
        Consult Get(int consId);

        // Admin can see all clients:
        List<Consult> GetAllPerClient(int cltId);

        List<Consult> GetAllPerDoctor(int doctorId);

        List<Consult> GetAllPerDoctorPerClient(int doctorId, int ClientId);

        List<Consult> GetAll(); // For ADMIN

        void Upd(Consult cons);
        void Add(Consult cons);
        void Del(int consId);
        int NumberOfConsultsPerClient(int id);
    }
}