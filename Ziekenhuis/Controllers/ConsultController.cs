using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Model;
using Ziekenhuis.Models;
using Ziekenhuis.Ziekenhuis.Controllers.ErrorChecks;
using Ziekenhuis.Ziekenhuis.Controllers.MappingExtensions;
using Ziekenhuis.Ziekenhuis.ViewModels;

namespace Ziekenhuis.Ziekenhuis.Controllers
{
    public class ConsultController : Controller
    {
        private readonly ILogger<ConsultController> _logger;
        private readonly IConsultManager _consultManager;
        private readonly IClientManager _clientManager;
        private readonly IDoctorManager _doctorManager;

        public ConsultController(ILogger<ConsultController> logger,
                              IConsultManager consultManager,
                              IClientManager clientManager,
                              IDoctorManager doctorManager)
        {
            _logger = logger;
            _consultManager = consultManager;
            _clientManager = clientManager;
            _doctorManager = doctorManager;
        }

        // ----------------------------------------------------------------------------------------------------------------- 


        public IActionResult Index(int? doctorId, int? clientId)
        {
            List<Consult> listCons;
            var consListVM = new ConsultListViewModel(); // Deze gaat de index view in

            consListVM.ConsultList = new List<ConsultViewModel>();

            // - 1. Determine full names of client and doctor on top of the view:
            if (clientId.HasValue)
            {
                consListVM.ClientId = clientId;
                consListVM.ClientFullName = _clientManager.ClientFullName(clientId.Value);
            }

            if (doctorId.HasValue)
            {
                consListVM.DoctorId = doctorId;
                consListVM.DoctorFullName = _clientManager.DoctorFullName(doctorId.Value);
            }

            //----2. Determine list of Consults --------------------------------------- 

            if (!doctorId.HasValue && !clientId.HasValue)
            // Admin wil lijst van alle consulten zien
            {
                listCons = _consultManager.GetAll();
            }

            else if (!doctorId.HasValue && clientId.HasValue)
            // Een client logt in, ziet alle consulten van al zijn artsen
            {
                var clt = _clientManager.GetClient(clientId.Value);
                consListVM.ClientId = clt.Id;

                listCons = _consultManager.GetAllPerClient(clientId.Value);
            }

            else if (doctorId.HasValue && !clientId.HasValue)
            // Een doctor vraagt alle recepten op van al zijn clienten
            {
                listCons = _consultManager.GetAllPerDoctor(doctorId.Value);
                consListVM.DoctorId = doctorId;
            }

            else // beiden ongelijk null 
            // Als vanuit de clienten-lijst een lijst van recepten wordt opgehaald
            {
                listCons = _consultManager.GetAllPerDoctorPerClient((int)doctorId, (int)clientId);
                consListVM.ClientId = clientId;
                consListVM.DoctorId = doctorId;
            }

            for (int i = 0; i < listCons.Count; i++)
            {
                consListVM.ConsultList.Add
                    (
                        new ConsultViewModel
                        {
                            Consult = listCons[i],
                            ClientFullName = _clientManager.ClientFullName(listCons[i].ClientId),
                            DoctorFullName = _clientManager.DoctorFullName(listCons[i].DoctorId)
                        }
                    );
            }

            return View(consListVM);
        }

        // ----------------------------------------------------------------------------------------------------------------- 
        // GET voor Details

        public IActionResult Details(int consId)
        {
            // De consultManager maakt een nieuw object in de heap van class Consult aan
            // cons wijst naar dit object. 
            var cons = _consultManager.Get(consId); 

            // Maak viewmodel voor 1 Consult, inclusief
            // FullName van client en dokter  

            var consVM = new ConsultViewModel
            {
                ClientFullName = _clientManager.ClientFullName(cons.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(cons.DoctorId),
                Consult = cons 
            };
            return View(consVM);
        }

        // ----------------------------------------------------------------------------------------------------------------- 
        // Create GET

        public IActionResult Create(int doctorId, int clientId)
        // Een consult kan alleen worden gecreëerd als zowel de arts
        // als de client bekend is. 
        {
            var consVM = new ConsultViewModel();
            consVM.ClientFullName = _clientManager.ClientFullName(clientId);
            consVM.DoctorFullName = _clientManager.DoctorFullName(doctorId);

            // Vergeet onderstaande regel niet, 
            // Immers de Create View moet 2 hidden fields krijgen voor clientId en doctorId
            // Zo niet, dan zijn deze 2 sleutelwaarden verloren bij inkomende VM voor de POST CREATE
            consVM.Consult = new Consult { ClientId = clientId, DoctorId = doctorId };
            consVM.Consult.ConsultDate = DateTime.Now; // Zet de datum alvast op vandaag

            return View(consVM);
        }

        // ----------------------------------------------------------------------------------------------------------------- 
        // CREATE POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConsultViewModel consVM)
        {
            if (!ModelState.IsValid)
            {
                // Geef de ViewModel terug:

                // Opmerking: onderstaande werkt niet.
                // "Descr is CHANGED" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                consVM.Consult.ConsultDescr = "Descr is CHANGED";

                // Het viewmodel moet altijd in de return, ook al doet het scherm er niets mee
                // Het scherm verwacht altijd deze VM, zowel bij de Get als bij de Post
                return View(consVM);
            }

            // Check hier de velden op correcte invoer (complexer)
            // Stop met valideren bij de eerste gevonden fout

            // Opmerking: als je spaties invult in een Line, wordt dit 
            // als een NULL string terug aan deze POST ACTION Method teruggegeven
            string errMsg = ErrorCheck.CheckForErrors(consVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);

                // VM moet altijd in de return, ook al doet het scherm er niets mee
                // Het scherm verwacht altijd deze VM, zowel bij de Get als bij de Create
                return View(consVM);
            }

            var cons = consVM.ToCons();

            _consultManager.Add(cons); 

            return RedirectToAction("Index",
                new
                {
                    doctorId = consVM.Consult.DoctorId,
                    clientId = consVM.Consult.ClientId
                });

        }


        // Update - GET ---------------------------------------------------------------------------------------
        public IActionResult Update(int consId)
        {
            var cons = _consultManager.Get(consId); 

            // Maak viewmodel voor 1 Consult, inclusief
            // FullName van client en dokter 

            // Algemene velden: 
            var ConsVM = new ConsultViewModel
            {
                ClientFullName = _clientManager.ClientFullName(cons.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(cons.DoctorId),
                Consult = cons
            };
            
            return View(ConsVM);
        }

        //-----update post --------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ConsultViewModel consVM)
        {

            // Check eerst de standaard fouten:
            if (!ModelState.IsValid)
            {
                return View(consVM);
            }

            // Check hier de velden op complexere correcte invoer  
            // Stop met valideren bij de eerste gevonden fout

            string errMsg = ErrorCheck.CheckForErrors(consVM);

            if (errMsg != null) // Specifieke, complexe fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);
                return View(consVM);
            }

            // converteer pW5LinesVM naar PrescrWithLine via extension method
            var cons = consVM.ToCons();

            _consultManager.Upd(cons); 

            return RedirectToAction("Index",
                new
                {
                    doctorId = cons.DoctorId,
                    clientId = cons.ClientId
                });

        }

        // ----------------------------------------------------------------------------------------------------------------- 
        // GET voor Delete  

        public IActionResult Delete(int consId)
        {
            var cons = _consultManager.Get(consId); 

            var consVM = new ConsultViewModel
            {
                ClientFullName = _clientManager.ClientFullName(cons.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(cons.DoctorId),
                Consult = cons
            };

            return View(consVM);

        }

        // ----------------------------------------------------------------------------------------------------------------- 
        // Post voor Delete  

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int consId)
        {
            // Haal ClientId en DoctorId op voor deze prescription
            // Want we willen na deze DELETE terugspringen naar
            // Het index scherm, met alle consults voor alleen deze client / dokter
            var cons = _consultManager.Get(consId);

            _consultManager.Del(consId); 

            // We moeten terug naar de Index scherm, echter index scherm
            // moet beperkt zijn tot deze client en deze doktor
            return RedirectToAction("Index",
               new
               {
                   doctorId = cons.DoctorId,
                   clientId = cons.ClientId
               });

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
