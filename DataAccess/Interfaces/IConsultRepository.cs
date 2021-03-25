using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface IConsultRepository
    {
        List<Consult> GetAll();
        // Currency Get(Currency currency);
        void Add(Consult consult);
        void Update(Consult consult);

        void Delete(int consId);

        Consult Get(int consId);

        List<Consult> GetAllPerDoctor(int doctorId);

        List<Consult> GetAllPerDoctorAndPerClient(int doctorId, int clientId);

        List<Consult> GetAllPerClient(int clientId);
        int NumberOfConsultsPerClient(int clientId);
    }
}