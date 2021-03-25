using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Managers
{
    public class ClientManager : IClientManager
    {

        private readonly IClientRepository _clientRepository;

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 

        public ClientManager(IClientRepository clientRepository)
        {
            // Bij Dependency Injection in startup.cs is geregeld
            // dat IClientRepository slechts één keer (lifetime) een 
            // instantie van ClientRepository aanwijst. 
            _clientRepository = clientRepository; 
        }

        public void AddClient(Client client)
        {
            _clientRepository.Add(client); 
        }

        public string ClientFullName(int clientId)
        {
            return _clientRepository.ClientFullName(clientId);
        }

        public void DeleteClient(int clientId)
        {
            _clientRepository.Delete(clientId); 
        }

        public string DoctorFullName(int doctorId)
        {
            return _clientRepository.DoctorFullName(doctorId);
        }

        public Client GetClient(int clientId)
        {
            return _clientRepository.Get(clientId); 
        }

        public int GetNrOfPrescrPerClient(int clientId)
        {
            // Haal het aantal recepten op van deze klant
            return _clientRepository.GetNrOfPrescrPerClient(clientId); 

        }

        public int GetAndUpdateCurrentClientNumber()
        {
            var newClientNumber = _clientRepository.GetAndUpdateCurrentClientNumber(); 
            return newClientNumber; 
        }

        public List<Client> SelectAllClientsAdmin(out int nrOfClients)
        {
            // Admin selects all clients
            var clientList = _clientRepository.GetAll();
            nrOfClients = clientList.Count();
            return clientList; 
        }

        public List<Client> SelectAllClientsPerDoctor(int doctorId, out int nrOfClients)
        {
            // Doctor selects his own clients
            var clientList = _clientRepository.GetAllClientsForOneDoctor(doctorId);
            nrOfClients = clientList.Count;
            return clientList; 
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.Update(client); 
        }
    }
}
