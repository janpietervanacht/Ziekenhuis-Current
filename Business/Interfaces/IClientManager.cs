using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Interfaces
{
    public interface IClientManager
    {
        Client GetClient(int clientId);

        // Admin can see all clients:
        List<Client> SelectAllClientsAdmin(out int nrOfClients);

        // Doctor can only see his own clients:
        List<Client> SelectAllClientsPerDoctor(int doctorId, out int nrOfClients);

        void UpdateClient(Client client);
        void AddClient(Client client);
        void DeleteClient(int clientId);
        int GetNrOfPrescrPerClient(int id);
        string DoctorFullName(int doctorId);
        string ClientFullName(int clientId);

        int GetAndUpdateCurrentClientNumber(); // Maak nieuw clientnummer (functioneel) aan
    }
}