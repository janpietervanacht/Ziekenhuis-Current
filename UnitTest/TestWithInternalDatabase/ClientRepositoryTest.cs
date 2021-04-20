using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.ApplicDbContextInMemory;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.DataAccess.Repositories;
using UnitTest.FillInternalDatabase;

// Hier wordt WEL gebruik gemaakt van intern-memory database

namespace UnitTest.TestWithInternalDatabase
{
    [TestClass]
    public class ClientRepositoryTest  // TEST MET INTERNAL MEMORY!!
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientRepository> _loggerClientRepository;

        public ClientRepositoryTest()
        {
            // Maak de initiele in memory database aan
            _dbContext = InitIntDb.CreateDbContext(); // creeert nieuw heap object

            _clientRepository = new ClientRepository(_dbContext, _loggerClientRepository);
            FillIntDb.FillDbContext(_dbContext);  // Vul de in-memory database
        }

        [TestMethod]
        public void Test1Client()
        {
            // Act
            var clt = _clientRepository.GetByClientNumber(100001);  // Zie Setups1.cs voor deze klant

            // Assert
            Assert.AreEqual(clt.City, "Veldhoven");
            Assert.AreEqual(clt.FirstName.Substring(0, 10).ToUpper(), "JAN-PIETER");

            clt = _clientRepository.GetByClientNumber(100002);
            Assert.IsTrue(clt.LastName.ToUpper().Contains("GROOT"));

        }

        [TestMethod]
        public void TestSumOfClientNumbers()
        {
            // De method die we testen in class ClientRepository is: CalculateSumOfClientNumbers();
            // Deze methode wordt niet door de Hospital applicatie gebruikt, maar is toegevoegd
            // om de unit-testen met intern-memory te kunnen oefenen hieronder

            var total = _clientRepository.SumOfClientNumbers(); // 500015
            Assert.AreEqual(total, 300006);

        }
    }
}
