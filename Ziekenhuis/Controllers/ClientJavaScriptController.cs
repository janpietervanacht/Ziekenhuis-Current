using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Model;
using Ziekenhuis.Ziekenhuis.Controllers.MappingExtensions;
using Ziekenhuis.Ziekenhuis.ViewModels;

namespace Ziekenhuis.Ziekenhuis.Controllers
{
    public class ClientJavaScriptController : Controller

        // Deze kopie van de lijst van clienten is bedoeld om JavaScript en JQ te oefenen. 

    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientManager _clientManager;

        public ClientJavaScriptController(ILogger<ClientController> logger,
                              IClientManager clientManager)
        {
            _logger = logger;
            _clientManager = clientManager;
        }

        public IActionResult Index(int? doctorId)
        {

            var result = new ClientListViewModel();
            result.ClientVMList = new List<ClientViewModel>();

            List<Client> cltList;

            //----Determine list of Clients --------------------------------------- 

            if (!doctorId.HasValue) // Admin vraagt lijst op van alle clienten
            {
                cltList = _clientManager.SelectAllClientsAdmin(out int nrOfClients);
            }
            else  // Doctor vraagt lijst op van zijn eigen clienten
            {
                result.DoctorId = doctorId.Value;
                result.DoctorFullName = _clientManager.DoctorFullName(doctorId.Value);
                cltList = _clientManager.SelectAllClientsPerDoctor((int)doctorId, out int nrOfClients);
            }

            // Copy clientList to clientListViewModel.
            for (int i = 0; i < cltList.Count; i++)
            {
                // Map Client naar ClientVM via extension method: 
                var c1 = cltList[i];
                var c2 = cltList[i].ToClientVM(); // Vul de basisvelden van c2

                // Voeg afgeleide velden toe aan c2
                c2.AgeInDays = (int)(DateTime.Today.Subtract(c1.BirthDate)).TotalDays;
                c2.ClientFullName = c1.FirstName + "  " + c1.LastName;

                c2.NrofPrescriptions = _clientManager.GetNrOfPrescrPerClient(c1.Id);
                c2.DoctorFullName = _clientManager.DoctorFullName(c1.DoctorId);

                result.ClientVMList.Add(c2);

            };

            // sorteer result.ClientVMList op ClientFullName

            result.ClientVMList = result
                .ClientVMList
                .OrderBy(c => c.ClientFullName)
                .ToList();

            return View(result);

        }


    }
}
