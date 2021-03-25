using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Model;
using Ziekenhuis.Models;
using Ziekenhuis.Ziekenhuis.Controllers.ErrorChecks;
using Ziekenhuis.Ziekenhuis.Controllers.MappingExtensions;
using Ziekenhuis.Ziekenhuis.ViewModels;
using Ziekenhuis.Ziekenhuis.ViewModels.SubModels;

namespace Ziekenhuis.Ziekenhuis.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly ILogger<PrescriptionController> _logger;
        private readonly IPrescrManager _prescrManager;
        private readonly IClientManager _clientManager;
        private readonly IDoctorManager _doctorManager;

        private int? gClientId;
        private int? gDoctorId;

        public PrescriptionController(ILogger<PrescriptionController> logger,
                              IPrescrManager prescrManager,
                              IClientManager clientManager,
                              IDoctorManager doctorManager)
        {
            _logger = logger;
            _prescrManager = prescrManager;
            _clientManager = clientManager;
            _doctorManager = doctorManager;
        }

        public IActionResult Index(int? doctorId, int? clientId)
        // In de index tabel staan geen Prescription Lines
        {


            List<Prescription> listPrescr;
            var prescrListVM = new PrescrListViewModel();

            // In de index tabel staan geen Prescription Lines,
            // Wel bevat iedere Prescripton de volledige cient en dokter naam
            prescrListVM.PrescrList = new List<PrescrWithNames>();

            // - Determine full names of client and doctor on top of the view:
            if (clientId.HasValue)
            {
                gClientId = clientId;
                prescrListVM.ClientId = clientId;
                prescrListVM.ClientFullName = _clientManager.ClientFullName(clientId.Value);
            }

            if (doctorId.HasValue)
            {
                gDoctorId = doctorId;
                prescrListVM.DoctorId = doctorId;
                prescrListVM.DoctorFullName = _clientManager.DoctorFullName(doctorId.Value);
            }

            //----Determine list of Prescriptions --------------------------------------- 

            if (!doctorId.HasValue && !clientId.HasValue)
            // Admin wil lijst van alle recepten zien
            {
                listPrescr = _prescrManager.GetAll();
            }

            else if (!doctorId.HasValue && clientId.HasValue)
            // Een client logt in
            {
                var clt = _clientManager.GetClient(clientId.Value);
                prescrListVM.ClientId = clt.Id;

                listPrescr = _prescrManager.GetAllPerClient(clientId.Value);
            }

            else if (doctorId.HasValue && !clientId.HasValue)
            // Een doctor vraagt alle recepten op van al zijn clienten
            {
                listPrescr = _prescrManager.GetAllPerDoctor(doctorId.Value);
                prescrListVM.DoctorId = doctorId;
            }

            else // beiden ongelijk null 
            // Als vanuit de clienten-lijst een lijst van recepten wordt opgehaald
            {
                listPrescr = _prescrManager.GetAllPerDoctorPerClient((int)doctorId, (int)clientId);
                prescrListVM.ClientId = clientId;
                prescrListVM.DoctorId = doctorId;
            }

            for (int i = 0; i < listPrescr.Count; i++)
            {
                prescrListVM.PrescrList.Add
                    (
                        new PrescrWithNames
                        {
                            Prescripton = listPrescr[i],
                            ClientFullName = _clientManager.ClientFullName(listPrescr[i].ClientId),
                            DoctorFullName = _clientManager.DoctorFullName(listPrescr[i].DoctorId)
                        }
                    );
            }

            return View(prescrListVM);

        }

        //----GET voor Detail ---------------------------------------------------- 

        public IActionResult Details(int prescrId)
        {
            var prescr = _prescrManager.GetPrescr(prescrId);
            var pLineList = _prescrManager.GetPrescrLines(prescrId);

            var pW5LinesVM = new PrescrWith5LinesViewModel
            {
                ClientFullName = _clientManager.ClientFullName(prescr.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(prescr.DoctorId),
                Prescription = prescr
            };

            if (pLineList.ElementAtOrDefault(0) != null)
            {
                pW5LinesVM.Line1 = pLineList.ElementAt(0).Line;
            }
            if (pLineList.ElementAtOrDefault(1) != null)
            {
                pW5LinesVM.Line2 = pLineList.ElementAt(1).Line;
            }
            if (pLineList.ElementAtOrDefault(2) != null)
            {
                pW5LinesVM.Line3 = pLineList.ElementAt(2).Line;
            }
            if (pLineList.ElementAtOrDefault(3) != null)
            {
                pW5LinesVM.Line4 = pLineList.ElementAt(3).Line;
            }
            if (pLineList.ElementAtOrDefault(4) != null)
            {
                pW5LinesVM.Line5 = pLineList.ElementAt(4).Line;
            }

            return View(pW5LinesVM);
        }

        // ---------------- Create-GET ------------------------------ 

        public IActionResult Create(int doctorId, int clientId)
        // Een recept kan alleen worden gecreëerd als zowel de arts
        // als de client bekend is. 
        {
            var pW5LinesVM = new PrescrWith5LinesViewModel();
            pW5LinesVM.ClientFullName = _clientManager.ClientFullName(clientId);
            pW5LinesVM.DoctorFullName = _clientManager.DoctorFullName(doctorId);

            // Vergeet onderstaande regel niet, 
            // Immers de Create View moet 2 hidden fields krijgen voor clientId en doctorId
            // Zo niet, dan zijn deze 2 sleutelwaarden verloren bij inkomende VM voor de POST CREATE
            pW5LinesVM.Prescription = new Prescription { ClientId = clientId, DoctorId = doctorId };
            pW5LinesVM.Prescription.PrescriptionDate = DateTime.Now;

            return View(pW5LinesVM);

        }

        // ---------------- Create-POST -------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult  Create(PrescrWith5LinesViewModel pW5LinesVM)
        {
            // Onderstaande werkt niet: 
            

            if (!ModelState.IsValid)
            {
                pW5LinesVM.Prescription.PrescriptionDescr = "Descr is CHANGED";
                return View(pW5LinesVM);
            }

            // Check hier de velden op correcte invoer (complexer)
            // Stop met valideren bij de eerste gevonden fout

            // Opmerking: als je spaties invult in een Line, wordt dit 
            // als een NULL string terug aan deze POST ACTION Method teruggegeven
            string errMsg = ErrorCheck.CheckForErrors(pW5LinesVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);

                // VM moet altijd in de return, ook al doet het scherm er niets mee
                // Het scherm verwacht altijd deze VM, zowel bij de Get als bij de Create
                return View(pW5LinesVM);
            }

            var prescr = pW5LinesVM.ToPrescr();
            var prescrLineList = pW5LinesVM.ToPrescrLineList();

            _prescrManager.AddPrescrAndLines(prescr, prescrLineList);

            return RedirectToAction("Index",
                new
                {
                    doctorId = pW5LinesVM.Prescription.DoctorId,
                    clientId = pW5LinesVM.Prescription.ClientId
                });

        }

        // Update - Get ------------------------------------ 
        public IActionResult Update(int prescrId)
        {
            var prescr = _prescrManager.GetPrescr(prescrId);
            var pLineList = _prescrManager.GetPrescrLines(prescrId);

            // Maak viewmodel voor 1 Prescription, inclusief
            // FullName van client en dokter en inclusief
            // max 5 lijnen
            // Preconditie: in de database komen geen lijnen voor
            // met waarde NULL

            // Algemene velden: 
            var pW5LinesVM = new PrescrWith5LinesViewModel
            {
                ClientFullName = _clientManager.ClientFullName(prescr.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(prescr.DoctorId),
                Prescription = prescr
            };

            if (pLineList.ElementAtOrDefault(0) != null)
            {
                pW5LinesVM.Line1 = pLineList.ElementAt(0).Line;
            }
            if (pLineList.ElementAtOrDefault(1) != null)
            {
                pW5LinesVM.Line2 = pLineList.ElementAt(1).Line;
            }
            if (pLineList.ElementAtOrDefault(2) != null)
            {
                pW5LinesVM.Line3 = pLineList.ElementAt(2).Line;
            }
            if (pLineList.ElementAtOrDefault(3) != null)
            {
                pW5LinesVM.Line4 = pLineList.ElementAt(3).Line;
            }
            if (pLineList.ElementAtOrDefault(4) != null)
            {
                pW5LinesVM.Line5 = pLineList.ElementAt(4).Line;
            }

            return View(pW5LinesVM);
        }

        //-----update post --------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PrescrWith5LinesViewModel pW5LinesVM)
        {

            // Check eerst de standaard fouten:
            if (!ModelState.IsValid)
            {
                return View(pW5LinesVM);
            }

            // Check hier de velden op complexere correcte invoer  
            // Stop met valideren bij de eerste gevonden fout

            string errMsg = ErrorCheck.CheckForErrors(pW5LinesVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);
                return View(pW5LinesVM);
            }

            // converteer pW5LinesVM naar PrescrWithLine via extension method
            var prescr = pW5LinesVM.ToPrescr();
            var prescrLineList = pW5LinesVM.ToPrescrLineList();

            _prescrManager.UpdPrescrAndLines(prescr, prescrLineList);

            return RedirectToAction("Index",
                new
                {
                    doctorId = pW5LinesVM.Prescription.DoctorId,
                    clientId = pW5LinesVM.Prescription.ClientId
                });

        }

        //----GET voor Delete ---------------------------------------------------- 

        public IActionResult Delete(int prescrId)
        {
            var prescr = _prescrManager.GetPrescr(prescrId);
            var pLineList = _prescrManager.GetPrescrLines(prescrId);

            var pW5LinesVM = new PrescrWith5LinesViewModel
            {
                ClientFullName = _clientManager.ClientFullName(prescr.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(prescr.DoctorId),
                Prescription = prescr
            };

            if (pLineList.ElementAtOrDefault(0) != null)
            {
                pW5LinesVM.Line1 = pLineList.ElementAt(0).Line;
            }
            if (pLineList.ElementAtOrDefault(1) != null)
            {
                pW5LinesVM.Line2 = pLineList.ElementAt(1).Line;
            }
            if (pLineList.ElementAtOrDefault(2) != null)
            {
                pW5LinesVM.Line3 = pLineList.ElementAt(2).Line;
            }
            if (pLineList.ElementAtOrDefault(3) != null)
            {
                pW5LinesVM.Line4 = pLineList.ElementAt(3).Line;
            }
            if (pLineList.ElementAtOrDefault(4) != null)
            {
                pW5LinesVM.Line5 = pLineList.ElementAt(4).Line;
            }

            return View(pW5LinesVM);

        }

        // ---- Post voor delete -------------------------------- 

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int prescrId)
        {
            // Haal ClientId en DoctorId op voor deze prescription
            // Want we willen na deze DELETE terugspringen naar
            // Het index scherm, met alle recepten voor alleen deze client / dokter
            var prescr = _prescrManager.GetPrescr(prescrId);

            // _clientManager.DeleteClient(klantId); // WERKT NIET
            _prescrManager.DelPrescr(prescrId);

            // We moeten terug naar de Index scherm, echter index scherm
            // moet beperkt zijn tot deze client en deze doktor
            return RedirectToAction("Index",
               new
               {
                   doctorId = prescr.DoctorId,
                   clientId = prescr.ClientId
               });

        }

        // -----------------------------------------------------

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
