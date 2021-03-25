using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Repositories
{

    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        private readonly string dbgPref = "Debug level from JPVA: ";
        private readonly string infoPref = "Info level from JPVA: ";
        private readonly string warnPref = "Warning level from JPVA: ";
        private readonly string errPref = "Error level from JPVA: ";


        public ClientRepository(ApplicationDbContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

            // Opmerking: onderstaande code zal een database entry en een txtfile entry aanmaken
            // in de interactieve Ziekenhuis applicatie, omdat er daar een NLog.config bestaat
            // die dit regelt.

            // Echter als je via de CRUD-API / Postman / Swagger deze method aanroept 
            // zal een andere NLog.config geldig zijn

            // In de WebAPi (CRUD-API) heb ik via NLog.config errors gelogd in database tabel dbo.LogApiError
            // In de WebAPI (CRUD-API) heb ik via NLog.config  warnings gelogd in de Windows Event logger

            // In de Nlog.Config van Ziekenhuis zijn er weer andere logs vastgelegd. 

            var txt = $"Client \"{client.FirstName} {client.LastName}\" " +
             $"met clientnummer {client.ClientNumber} toegevoegd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);
        }

        public string ClientFullName(int clientId)
        {
            var client = _dbContext.Clients.Find(clientId);

            //var txt = $"Method ClientFullName: Client \"{client.FirstName} {client.LastName}\" " +
             // $"met clientnummer {client.ClientNumber}";

            //_logger.LogDebug(dbgPref + txt);
            //_logger.LogInformation(infoPref + txt);
            //_logger.LogWarning(warnPref + txt);
            //_logger.LogError(errPref + txt);

            return client.FirstName + " " + client.LastName;
        }

        public void Delete(int id)
        {
            Client clt = _dbContext.Clients.Find(id);
            _dbContext.Clients.Remove(clt);
            _dbContext.SaveChanges();

            var txt = $"Method Delete: Client \"{clt.FirstName} {clt.LastName}\" " +
               $"met clientnummer {clt.ClientNumber} verwijderd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

        }


        public string DoctorFullName(int id)
        {
            var doctor = _dbContext.Doctors.Find(id);
            return doctor.FirstName + " " + doctor.LastName;
        }

        public Client Get(int Id)
        {
            //  var client = _dbContext.Clients.Find(Id); werkt
            // Opmerking: "Include"  gaat ook goed bij Country. Immers de FK CountryId is nullable in tabel Clients.
            var client = _dbContext.Clients
                .Where(c => c.Id == Id)
                .Include(c => c.Country)
                .Include(c => c.Doctor)
                .FirstOrDefault();
            // client zal nooit NULL zijn, omdat de Id moet bestaan bij aanroep. 

            //--------------------------------------------------
            // Oefening NULL propagation:
            // Client 100002 (eerste in de lijst) kent géén Country Id

            var y = client.Country?.CountryDescription; // y wordt NULL bij klant 100002
            int? x = client.Country?.Id; // x wordt 0 bij klant 100002. 
            //--------------------------------------------------


            return client; 
            // return (_dbContext.Clients.Find(Id));  // kan ook 
        }

        // Swagger retrieves all clients
        public List<Client> GetAll()
        {
            // Let op: Country mag NULL zijn (foreign key mag null zijn). Geeft geen exception
            var clientList = _dbContext.Clients
                .Include(c=>c.Doctor)
                .Include(c=>c.Country)
                .ToList();

            var txt = $"Method GetAll: {clientList.Count} clienten gevonden ";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

            return clientList;
        }
        public List<Client> GetAllWithConsults()
        {
            // Let op: Dankzij de ListOfConsults is er een 1:N relatie tussen Client en Consult
            var clientList = _dbContext.Clients
                .Include(c=>c.ListOfConsults)
                .Include(c=>c.Doctor)
                .Include(c=>c.Country)
                .ToList();

            var txt = $"Method GetAll: {clientList.Count} clienten gevonden ";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

            return clientList;
        }




        public int GetNrOfPrescrPerClient(int clientId)
        {
            var nrOfPrescr = _dbContext.Prescriptions.Where(p => p.ClientId == clientId).Count();

            return nrOfPrescr;
        }

        public void Update(Client client)
        {
            // var clt = _dbContext.Clients.Find(client.Id);
            _dbContext.Entry(client).State = EntityState.Modified;
            _dbContext.SaveChanges();

            var txt = $"Method Update: Client \"{client.FirstName} {client.LastName}\" " +
               $"met clientnummer {client.ClientNumber} veranderd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

        }

        public List<Client> GetAllClientsForOneDoctor(int doctorId)
        {
            var clientListPerDoctor = _dbContext.Clients
                .Where(c => c.DoctorId == doctorId)
                .Include(c=>c.Doctor)
                .Include(c=>c.Country)  // Let op de FK CountryId mag NULL zijn, gaat altijd goed, Subclass Country wordt dan NULL
                .OrderBy(c => c.Id)
                .ToList();

            var txt = $"Method GetAllClientsForOneDoctor: {clientListPerDoctor.Count} clienten gevonden ";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);


            return clientListPerDoctor;
        }

        public int SumOfClientNumbers()
        {
            var sum = _dbContext.Clients.Sum(c => c.ClientNumber);

            return sum;
        }

        public int GetAndUpdateCurrentClientNumber()
        {
            // tabel NumberRanges bevat maar één record
            var numberRange = _dbContext.NumberRanges.Find(1);
            numberRange.CurrentClientNumber++;
            if (numberRange.CurrentClientNumber >= numberRange.MaxClientNumber)
            {
                numberRange.CurrentClientNumber = 1;
            }
            _dbContext.Entry(numberRange).State = EntityState.Modified;
            _dbContext.SaveChanges();


            return numberRange.CurrentClientNumber;
        }
        /// <summary>
        ///   Ophalen client via Swagger of Postman op basis 
        ///   van functioneel clientnummer = geimplementeerd met
        ///   een stored procedure in database
        /// </summary>
        /// <param name="clientNumber"></param>
        /// <returns></returns>
        public Client GetByClientNumber(int clientNumber)
        {

            // Dit gingen we via een stored procedure doen 

            // Lijst bevat maar één element: 

            //-----------------------------------------------
            // Stored procedure werkt niet als je een in-memory database gebruikt
            // Onderstaande code werkt correct bij een gewone SQL database
            // Afgesterde code niet weghalen, om educatieve redenen!! 

            //var clientList = _dbContext.Clients
            //        .FromSqlRaw($"EXECUTE dbo.uspGetClientByClientNumber {clientNumber}")
            //        .AsEnumerable();  
            // var client = clientList.SingleOrDefault();
            //-----------------------------------------------

            //var client = _dbContext.Clients
            //    .SingleOrDefault(c => c.ClientNumber == clientNumber); 

            // Onderstaande kan null opleveren voor client, immers aanroep vanuit Swagger 
            var client = _dbContext.Clients
                .Where(c => c.ClientNumber == clientNumber)
                .Include(c => c.Doctor).Include(c => c.Country).FirstOrDefault(); 

            //--------------------------------------------------
            // Oefening NULL propagation:
            // Client 100002 (eerste in de lijst) kent géén Country Id
            // Deze routine wordt aangeroepen door Swagger, klant 999999
            // bestaat niet
            // Andere clienten kennen weer wel een CountryId
            // Dus een vraagteken achter client en Country zetten (null propagation). 

            string y = client?.Country?.CountryDescription; // y wordt NULL bij klant 100002
            int? x = client?.Country?.Id; // x wordt 0 bij klant 100002. 
            //--------------------------------------------------


            var txt = $"Method GetByClientNumber: " +
               $"is client {client?.FirstName} {client?.LastName} opgehaald";  // Let op client kan null zijn

            return client;

            // OUDE CODE (ZONDER STORED PROCEDURE): 

            //var result = _dbContext.Clients
            //    .Where(c => c.ClientNumber == clientNumber)
            //    .SingleOrDefault(); // klapt eruit als er 2 of meer bestaan
            // return result; 

        }

        public bool UpdateByClientNumber(Client client)
        {
            var dbClient = _dbContext.Clients.FirstOrDefault(c => c.ClientNumber.Equals(client.ClientNumber));
            // MAG OOK: var clt = _dbContext.Clients.FirstOrDefault(c => c.ClientNumber == (client.ClientNumber));

            // Zet alle velden van client naar clt, behalve Id, DoctorId, ActionCode, ClientNumber
            // Via de mapper kan dit volgens mij niet, ook niet via Clone, want beide methodes maken zelf een
            // nieuwe Client aan (en clt moet blijven wijzen naar het record in _dbContext). 

            // De Indiër gebruikt ook geen Clone. 

            // ALLE velden van client moeten worden gevuld bij een Update

            bool success;
            if (dbClient == null)
            {
                success = false;
                return success;
            }

            client.Id = dbClient.Id;
            client.ActionCode = dbClient.ActionCode;
            client.DoctorId = dbClient.DoctorId;

            _dbContext.Entry(dbClient).CurrentValues.SetValues(client);
            _dbContext.SaveChanges();

            var txt = $"Method UpdateByClientNumber: Client \"{client.FirstName} {client.LastName}\" " +
             $"met clientnummer {client.ClientNumber} veranderd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

            success = true;
            return success;
        }

        public bool DeleteByClientNumber(int clientNumber)
        {
            bool success;
            Client clt = _dbContext.Clients.SingleOrDefault(c => c.ClientNumber == clientNumber);
            if (clt != null)
            {

                //-------------------------------------------- 
                // Onderstaande werkt ook goed (NIET VERWIJDEREN):

                //_dbContext.Clients.Remove(clt);
                //_dbContext.SaveChanges();
                //success = true;
                //--------------------------------------------

                // Gebruik niet _dbContext.Clients.FromSqlRaw maar onderstaande: _dbContext.Database.ExecuteSqlRaw
                // want je retourneert geen clienten 
                
                var result = _dbContext.Database.ExecuteSqlRaw($"EXECUTE dbo.uspDeleteClientByClientNumber {clientNumber}");
                success = true;

                var txt = $"Method DeleteByClientNumber: Client \"{clt.FirstName} {clt.LastName}\" " +
                         $"met clientnummer {clt.ClientNumber} verwijderd";

                _logger.LogDebug(dbgPref + txt);
                _logger.LogInformation(infoPref + txt);
                _logger.LogWarning(warnPref + txt);
                _logger.LogError(errPref + txt);
            }
            else
            {
                success = false;
            }
            return success;
        }
    }
}
