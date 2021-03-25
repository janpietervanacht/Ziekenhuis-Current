using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Model;
using Ziekenhuis.Ziekenhuis.Controllers;
using Ziekenhuis.Ziekenhuis.ViewModels;

// Hier wordt géén gebruik gemaakt van intern-memory database

namespace UnitTest
{
    [TestClass]
    public class ClientControllerTest  // Testen van methods in class ClientController
    {
        // Mock alle objecten, gebruikt in ClientController

        private readonly Mock<IClientManager> _clientManager;
        private readonly Mock<ICountryManager> _countryManager;
        private readonly Mock<ILogger<ClientController>> _logger;


        // _ zelf niet mocken, maar wel naar interface (DI) laten wijzen: 
        private readonly ClientController _clientController;

        private List<Client> mockedClientList;

        public ClientControllerTest()
        {
            _clientManager = new Mock<IClientManager>();
            _countryManager = new Mock<ICountryManager>();
            _logger = new Mock<ILogger<ClientController>>();

            _clientController = new ClientController(
              _logger.Object,
              _clientManager.Object,
                _countryManager.Object);
        }

        [TestMethod]
        public void TestIndexSubstring()
        {
            // Arrange: 
            CreateGeneralSetupsForIndex();

            //Act: test de substring, clienten met Id=1 en Id=2 worden opgehaald: 
            var result = _clientController.Index(1, null, "ZubStRING", false, false);

            // Assert: 
            var viewResult = (ViewResult)result;

            // viewResult.Model is hier een object, kent alleen generieke properties 
            // zie onderstaande code, met intellisense:  
            // viewResult.Model.     // intellisense lijstje toont alleen generieke properties

            // viewResult.Model.   --- intellisense lijstje van model bevat nu wel 
            // properties van ClientListViewModel
            var model = (ClientListViewModel)viewResult.Model;

            // Controleer dat er 2 clienten in zitten, Id = 1 en Id = 2
           
            Assert.AreEqual(model.ClientVMList.Exists(c => c.Client.Id == 1), true);
            Assert.IsTrue(model.ClientVMList.Any(c => c.Client.Id == 1));  // Vergeet LINQ niet in USINGS!!
            Assert.AreEqual(model.ClientVMList.Exists(c => c.Client.Id == 2), true);
            Assert.AreEqual(model.ClientVMList.Count, 2);

            //------------------------------------------------------------------- 
            result = _clientController.Index(1, null, "PETER", false, false);

            // Assert: 
            viewResult = (ViewResult)result;
            model = (ClientListViewModel)viewResult.Model;

            // Test dat er 2 klanten zijn die hieraan voldoen namelijk Id=3 en 4

            Assert.IsTrue(model.ClientVMList.Any(c => c.Client.Id == 3));  // Vergeet LINQ niet in USINGS
            Assert.IsTrue(model.ClientVMList.Any(c => c.Client.Id == 4));  // Vergeet LINQ niet in USINGS
            Assert.AreEqual(model.ClientVMList.Count, 2);

            result = _clientController.Index(1, null, "SubStringBestaatNiet", false, false);
            // Assert: 
            viewResult = (ViewResult)result;
            model = (ClientListViewModel)viewResult.Model;

            Assert.AreEqual(model.ClientVMList.Count, 0);

        }

        [TestMethod]
        public void TestIndexPrefixString()
        {
            // Arrange: 
            CreateGeneralSetupsForIndex();

            //Act: test de prefixtring 
            var result = _clientController.Index(1, "JAN", null, false, false);

            // Assert: 
            var viewResult = (ViewResult)result;
            var model = (ClientListViewModel)viewResult.Model;

            // Controleer dat er 3 clienten in zitten, Id = 1,2 en 5 
            Assert.AreEqual(model.ClientVMList.Exists(c => c.Client.Id == 1), true); // EXISTS: geen LINQ
            Assert.IsTrue(model.ClientVMList.Any(c => c.Client.Id == 1)); // Gebruik LINQ voor ANY
            Assert.IsTrue(model.ClientVMList.Any(c => c.Client.Id == 2));
            Assert.IsTrue(model.ClientVMList.Any(c => c.Client.Id == 5));
            Assert.AreEqual(model.ClientVMList.Count, 3);

            //----------------------------------------------------------------- 

            result = _clientController.Index(1, "PrefixBestaatNiet", null, false, false);
            // Assert: 
            viewResult = (ViewResult)result;
            model = (ClientListViewModel)viewResult.Model;

            Assert.AreEqual(model.ClientVMList.Count, 0); 

        }


        [TestMethod]
        public void TestIndexTestSort()
        {
            // Arrange: 
            CreateGeneralSetupsForIndex();

            //Act: test sortering op clientnummer
            var result = _clientController.Index(1, null, null, true, false);

            // Assert: 
            var viewResult = (ViewResult)result;
            var model = (ClientListViewModel)viewResult.Model;

            // Controleer dat er 5 clienten in zitten, in volgorde van clientNumber
            Assert.AreEqual(model.ClientVMList[0].Client.ClientNumber, 100001);
            Assert.AreEqual(model.ClientVMList[1].Client.ClientNumber, 100002);
            Assert.AreEqual(model.ClientVMList[2].Client.ClientNumber, 100003);
            Assert.AreEqual(model.ClientVMList[3].Client.ClientNumber, 100004);
            Assert.AreEqual(model.ClientVMList[4].Client.ClientNumber, 100005);
            Assert.AreEqual(model.ClientVMList.Count, 5);

            // Controleer dat er goed gesorteerd is op client nummer:

            for (int i = 0; i < model.ClientVMList.Count - 1; i++)
            {
                int cltNr1 = model.ClientVMList[i].Client.ClientNumber;
                int cltNr2 = model.ClientVMList[i + 1].Client.ClientNumber;
                Assert.IsTrue(cltNr1 < cltNr2); 
            }


            //----------------------------------------------------------------- 

            //Act: test sortering op FirstName
            result = _clientController.Index(1, null, null, false, true);

            // Assert: 
            viewResult = (ViewResult)result;
            model = (ClientListViewModel)viewResult.Model;
            Assert.AreEqual(model.ClientVMList.Count, 5);

            string str1, str2;

            for (int i = 0; i < model.ClientVMList.Count - 1; i++)
            {
                str1 = model.ClientVMList[i].Client.FirstName;
                str2 = model.ClientVMList[i+1].Client.FirstName;
                Assert.AreEqual(string.Compare(str1, str2), -1);
            }

        }


        private void CreateGeneralSetupsForIndex()
        {
            // Setup van clientManager.SelectAllClientsAdmin
            // Maw: simuleren hiervan door een zelfgekozen lijst van clienten. 

            // Als een class alleen maar methods heeft, en verder niets hoeft
            // te onthouden (properties), maak hem dan Static: 
            mockedClientList = Setups.RtvMockedClientList();

            // Mock (Stub) clientenlijst
            int nrClients;
            _clientManager.Setup(x => x.SelectAllClientsAdmin(out nrClients)).Returns(mockedClientList);
            _clientManager.Setup(x => x.SelectAllClientsPerDoctor(It.IsAny<int>(), out nrClients)).Returns(mockedClientList);
            // Mock de volledige naam van de dokter
            _clientManager.Setup(x => x.DoctorFullName(It.IsAny<int>())).Returns("Doctor Bernard van Jankerds");
            // Mock het aantal recepten per client
            _clientManager.Setup(x => x.GetNrOfPrescrPerClient(It.IsAny<int>())).Returns(5);

        }

    }
}
