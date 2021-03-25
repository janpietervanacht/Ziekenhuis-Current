using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface IClientRepository
    {

        List<Client> GetAll(); // For Admin

        List<Client> GetAllWithConsults();

        List<Client> GetAllClientsForOneDoctor(int doctorId); // For 1 doctor
         
        void Add(Client client);
        void Update(Client client);

        void Delete(int id);

        Client Get(int Id);

        Client GetByClientNumber(int clientNumber); // functioneel clientnummer

        int GetNrOfPrescrPerClient(int clientId);
        string DoctorFullName(int doctorId);
        string ClientFullName(int clientId);
        int GetAndUpdateCurrentClientNumber();

        bool UpdateByClientNumber(Client client);
        bool DeleteByClientNumber(int clientNumber);
        int SumOfClientNumbers();
    }
}