using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.ApplicDbContextInMemory;
using UnitTestSetupMockedData.SetUpsMockedData;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Business.Managers;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.DataAccess.Repositories;
using Ziekenhuis.Model;

namespace UnitTest.Tests
{

    // Hier wordt WEL gebruik gemaakt van intern-memory database

    // Onderstaande is geen unit test, want we testen
    // hier 2 units tegelijkertijd: manager / repository methodes
    // Bij een echte unit test van Manager moet je Repository mocken

    [TestClass]
    public class ClientManagerTest
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IClientRepository _clientRepository;
        private readonly IClientManager _clientManager;
        private readonly ILogger<ClientRepository> _loggerClientRepository;


        public ClientManagerTest()
        {
            // Maak de interne database aan
            _dbContext = InitIntDb.CreateDbContext(); // creeert nieuw heap object
            FillDbContext();

            // Maak een nieuwe clientRepository die de interne database gebruikt
            _clientRepository = new ClientRepository(_dbContext, _loggerClientRepository);

            // Maak een nieuwe clientmanager die de nieuwe ClientRepository gebruikt
            _clientManager = new ClientManager(_clientRepository); 
            
        }

        private void FillDbContext()
        {
            Doctor doctor = SetupMockedData.RtvDoctor();  // we werken maar met één doctor
            Country country = SetupMockedData.RtvCountry(); // een paar landen

            var clientList = SetupMockedData.RtvMockedClientList(); // Haal een aantal clienten op
            foreach (var clt in clientList)
            {
                _dbContext.Clients.Add(clt);
                _dbContext.SaveChanges();
            }
        }


        [TestMethod]
        public void TestClientFullName()
        {
            // Act
            var fullName = _clientManager.ClientFullName(3).ToLower();

            /*
              You can use the Regex.Replace method, which replaces 
              all matches defined by a regular expression with a replacement string.  
              In this case, use the regular expression pattern “s”, 
              which matches any whitespace character including the 
              space, tab, linefeed and newline.

             */
            // Assert
            Assert.AreEqual(fullName, "vriend peter moors");

        }

    }
}
