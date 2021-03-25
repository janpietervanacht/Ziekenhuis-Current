using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Model;
using Ziekenhuis.Ziekenhuis.Controllers.ErrorChecks;
using Ziekenhuis.Ziekenhuis.Controllers.MappingExtensions;
using Ziekenhuis.Ziekenhuis.ViewModels;

namespace Ziekenhuis.Ziekenhuis.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceManager _invoiceManager;
        private readonly IClientManager _clientManager;
        private readonly IDoctorManager _doctorManager;

        public InvoiceController(ILogger<InvoiceController> logger,
                              IInvoiceManager invoiceManager,
                              IClientManager clientManager,
                              IDoctorManager doctorManager)
        {
            _logger = logger;
            _invoiceManager = invoiceManager;
            _clientManager = clientManager;
            _doctorManager = doctorManager;
        }

        public IActionResult Index(int? doctorId, int? clientId)
        // In de index tabel staan geen Prescription Lines
        {
            List<Invoice> listInvoiceDb;
            var invoiceListVM = new InvoiceListViewModel
            {
                // In de index tabel staan geen Invoice Lines, maar ze worden wel
                // meegegeven in deze ViewModel. 
                InvoiceList = new List<InvoiceViewModel>()
            }; // Deze gaat de index view in

            // - Determine full names of client and doctor on top of the view:
            if (clientId.HasValue)
            {
                invoiceListVM.ClientId = clientId;
                invoiceListVM.ClientFullName = _clientManager.ClientFullName(clientId.Value);
                var clt = _clientManager.GetClient(clientId.Value);
                invoiceListVM.ClientNumber = clt.ClientNumber;
                invoiceListVM.NumberOfInvoices = _invoiceManager.NumberOfInvoicesPerClient(clientId.Value); 
            }

            if (doctorId.HasValue)
            {
                invoiceListVM.DoctorId = doctorId;
                invoiceListVM.DoctorFullName = _clientManager.DoctorFullName(doctorId.Value);
            }

            //----Determine list of invoices --------------------------------------- 

            if (!doctorId.HasValue && !clientId.HasValue)
            // Admin wil lijst van alle recepten zien
            {
                listInvoiceDb = _invoiceManager.GetAll();
            }

            else if (!doctorId.HasValue && clientId.HasValue)
            // Een client logt in
            {
                var clt = _clientManager.GetClient(clientId.Value);
                invoiceListVM.ClientId = clt.Id;

                listInvoiceDb = _invoiceManager.GetAllPerClient(clientId.Value);
            }

            else if (doctorId.HasValue && !clientId.HasValue)
            // Een doctor vraagt alle recepten op van al zijn clienten
            {
                listInvoiceDb = _invoiceManager.GetAllPerDoctor(doctorId.Value);
                invoiceListVM.DoctorId = doctorId;
            }

            else // beiden ongelijk null 
            // Als vanuit de clienten-lijst een lijst van recepten wordt opgehaald
            {
                listInvoiceDb = _invoiceManager.GetAllPerDoctorPerClient((int)doctorId, (int)clientId);
                invoiceListVM.ClientId = clientId;
                invoiceListVM.DoctorId = doctorId;
            }

            for (int i = 0; i < listInvoiceDb.Count; i++)
            {
                invoiceListVM.InvoiceList.Add
                    (
                        new InvoiceViewModel
                        {
                            Invoice = listInvoiceDb[i],
                            ClientFullName = _clientManager.ClientFullName(listInvoiceDb[i].ClientId),
                            DoctorFullName = _clientManager.DoctorFullName(listInvoiceDb[i].DoctorId),
                            // We tonen geen factuur-lijnen in het index-lijst-scherm
                            // Onderstaande regels kan je ook weglaten
                            Line1 = null,
                            Line2 = null,
                            Line3 = null
                        }
                    ); ;
            }

            return View(invoiceListVM);

        }


        //----GET voor Detail ---------------------------------------------------- 

        public IActionResult Details(int invoiceId)
        {
            var invoiceDb = _invoiceManager.GetInvoice(invoiceId); // wijst naar new object in heap

            // niet meer nodig,dankzij Include in Repository wordt achterliggende Client en Land opgehaald:
            // var clientDb = _clientManager.GetClient(invoiceDb.ClientId); 

            //------------------------------------------------------------------------------
            // Opmerking: als er geen invoice-lijnen zijn
            // dan zal invLineList naar een bestaande lijst in de heap met 0 elementen
            // wijzen - maw: invLineList is dan NIET gelijk aan NULL
            // Dit kan je checken met IntelliSense.

            // Als invLineList NULL zou zijn, dan klapt de code op (*)

            var invLineListDB = _invoiceManager.GetInvoiceLines(invoiceId);

            //------------------------------------------------------------------------------

            var invVM = new InvoiceViewModel
            {
                ClientFullName = _clientManager.ClientFullName(invoiceDb.Client.Id),
                DoctorFullName = _clientManager.DoctorFullName(invoiceDb.Client.DoctorId),
                ClientNumber = invoiceDb.Client.ClientNumber,
                Invoice = invoiceDb
            };

            if (invLineListDB.ElementAtOrDefault(0) != null)
            {
                //  (*) klapt als invLineList == null
                //   Melding wordt: System.ArgumentNullException: 'Value cannot be null. '
                //  Klapt niet als invLineList naar een lege lijst in de heap wijst (Count = 0)

                invVM.Line1 = invLineListDB.ElementAt(0).Line;
            }
            if (invLineListDB.ElementAtOrDefault(1) != null)
            {
                invVM.Line2 = invLineListDB.ElementAt(1).Line;
            }
            if (invLineListDB.ElementAtOrDefault(2) != null)
            {
                invVM.Line3 = invLineListDB.ElementAt(2).Line;
            }

            return View(invVM);
        }

        // ----------------------------------------------------------------------------------------------------------------- 
        // Create GET

        public IActionResult Create(int doctorId, int clientId)  // Beiden altijd ingevuld
        // Een factuur kan alleen worden gecreëerd als zowel de arts
        // als de client bekend is. 
        {

            var clientDB = _clientManager.GetClient(clientId);

            var invVM = new InvoiceViewModel();
            invVM.ClientFullName = _clientManager.ClientFullName(clientId);
            invVM.DoctorFullName = _clientManager.DoctorFullName(doctorId);
            invVM.ClientNumber = clientDB.ClientNumber; 

            // Vergeet onderstaande regel niet, 
            // Immers de Create View moet 2 hidden fields krijgen voor clientId en doctorId
            // Zo niet, dan zijn deze 2 sleutelwaarden verloren bij inkomende VM voor de POST CREATE
            invVM.Invoice = new Invoice { ClientId = clientId, DoctorId = doctorId };
            invVM.Invoice.Status = 'O';  /* Open */
            invVM.Invoice.SendYN = 'N';  /* Nog niet verstuurd */
            invVM.Invoice.ActionCode = 'A';

            // Zet due date op einde van de volgende maand
            DateTime add1Month = DateTime.Today.Add(new TimeSpan(31, 0, 0, 0));
            // x = aantal dagen in een bepaalde maand (bijv 29 voor februari 2020). 
            var x = DateTime.DaysInMonth(add1Month.Year, add1Month.Month);

            invVM.Invoice.DueDate = new DateTime(add1Month.Year, add1Month.Month, x);

            // Zet InvoiceNumber even op 1, zodat ModelState.IsValid op TRUE komt
            // in de Post Create. Het echte invoicenumber wordt pas bepaald na succesvolle
            // invoer van de invoice, onderin de CREATE POST ACTIONMETHOD. 
            invVM.Invoice.InvoiceNumber = 1; // 

            return View(invVM);
        }

        // ----------------------------------------------------------------------------------------------------------------- 
        // CREATE POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InvoiceViewModel invVM)
        {
            if (!ModelState.IsValid)
            {
                // Geef de ViewModel terug:

                // Het viewmodel moet altijd in de return, ook al doet het scherm er niets mee
                // Het scherm verwacht namelijk altijd deze VM, zowel bij de Get als bij de Post
                return View(invVM);
            }

            // Check hier de velden op correcte invoer (complexer)
            // Stop met valideren bij de eerste gevonden fout

            // Opmerking: als je spaties invult in een Line, wordt dit 
            // als een NULL string terug aan deze POST ACTION Method teruggegeven
            string errMsg = ErrorCheck.CheckForErrors(invVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);

                // VM moet altijd in de return, ook al doet het scherm er niets mee
                // Het scherm verwacht altijd deze VM, zowel bij de Get als bij de Create
                return View(invVM);
            }

            var invoiceDb = invVM.ToInvoice();
            var invoiceLineListDb = invVM.ToInvoiceLineList();

            // Genereer nieuw invoicenummer uit de stamtabel met reeksen
            invoiceDb.InvoiceNumber = _invoiceManager.RtvNewInvoiceNumber();
            _invoiceManager.AddInvoiceAndLines(invoiceDb, invoiceLineListDb);

            return RedirectToAction("Index",
                new
                {
                    doctorId = invVM.Invoice.DoctorId,
                    clientId = invVM.Invoice.ClientId
                });

        }

        //----GET voor Delete ---------------------------------------------------- 

        public IActionResult Delete(int invoiceId)
        {
            var invoiceDb = _invoiceManager.GetInvoice(invoiceId);
            var clientDb = _clientManager.GetClient(invoiceDb.ClientId);

            //------------------------------------------------------------------------------
            // Opmerking: als er geen invoice-lijnen zijn
            // dan zal invLineList naar een bestaande lijst in de heap met 0 elementen
            // wijzen - maw: invLineList is dan NIET gelijk aan NULL
            // Dit kan je checken met IntelliSense.

            // Als invLineList NULL zou zijn, dan klapt de code op (*)

            var invLineListDb = _invoiceManager.GetInvoiceLines(invoiceId);

            //------------------------------------------------------------------------------

            var invVM = new InvoiceViewModel
            {
                ClientFullName = _clientManager.ClientFullName(invoiceDb.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(invoiceDb.DoctorId),
                ClientNumber = clientDb.ClientNumber,
                Invoice = invoiceDb
            };

            if (invLineListDb.ElementAtOrDefault(0) != null)
            {
                //  (*) klapt als invLineList == null
                //   Melding wordt: System.ArgumentNullException: 'Value cannot be null. '
                //  Klapt niet als invLineList naar een lege lijst in de heap wijst (Count = 0)

                invVM.Line1 = invLineListDb.ElementAt(0).Line;
            }
            if (invLineListDb.ElementAtOrDefault(1) != null)
            {
                invVM.Line2 = invLineListDb.ElementAt(1).Line;
            }
            if (invLineListDb.ElementAtOrDefault(2) != null)
            {
                invVM.Line3 = invLineListDb.ElementAt(2).Line;
            }

            return View(invVM);
        }

        //---- POST voor Delete ---------------------------------------------------- 

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int invoiceId)
        {
            // Haal ClientId en DoctorId op voor deze prescription
            // Want we willen na deze DELETE terugspringen naar
            // Het index scherm, met alle recepten voor alleen deze client / dokter
            var invoiceDb = _invoiceManager.GetInvoice(invoiceId);

            // _clientManager.DeleteClient(klantId); // WERKT NIET
            _invoiceManager.DelInvoice(invoiceId);

            // We moeten terug naar de Index scherm, echter index scherm
            // moet beperkt zijn tot deze client en deze doktor
            return RedirectToAction("Index",
               new
               {
                   doctorId = invoiceDb.DoctorId,
                   clientId = invoiceDb.ClientId
               });

        }

        // Update - GET 
        public IActionResult Update(int invoiceId)
        {
            var invoiceDb = _invoiceManager.GetInvoice(invoiceId);
            var clientDb = _clientManager.GetClient(invoiceDb.ClientId);
            var invLineListDb = _invoiceManager.GetInvoiceLines(invoiceId);

            // Maak viewmodel voor 1 Invoice, inclusief
            // FullName van client en dokter en inclusief
            // max 3 lijnen
            // Preconditie: in de database komen geen lijnen voor
            // met waarde NULL

            // Algemene velden: 
            var invVM = new InvoiceViewModel
            {
                ClientFullName = _clientManager.ClientFullName(invoiceDb.ClientId),
                DoctorFullName = _clientManager.DoctorFullName(invoiceDb.DoctorId),
                ClientNumber = clientDb.ClientNumber,
                Invoice = invoiceDb
            };

            if (invLineListDb.ElementAtOrDefault(0) != null)
            {
                invVM.Line1 = invLineListDb.ElementAt(0).Line;
            }

            if (invLineListDb.ElementAtOrDefault(1) != null)
            {
                invVM.Line2 = invLineListDb.ElementAt(1).Line;
            }

            if (invLineListDb.ElementAtOrDefault(2) != null)
            {
                invVM.Line3 = invLineListDb.ElementAt(2).Line;
            }

            return View(invVM);
        }

        //-----update post --------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(InvoiceViewModel invVM)
        {

            // Check eerst de standaard fouten:
            // Standaard (data-annotation) fouten worden bij het veld zelf getoond
            if (!ModelState.IsValid)
            {
                return View(invVM);
            }

            // Check hier de velden op complexere correcte invoer  
            // Stop met valideren bij de eerste gevonden fout
            // Deze complexere fouten worden in de message-box getoond

            string errMsg = ErrorCheck.CheckForErrors(invVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);
                return View(invVM);
            }

            // converteer InvVM naar InvoiceViewModel via extension method
            var invoiceDb = invVM.ToInvoice();
            var invLineListDb = invVM.ToInvoiceLineList();
            _invoiceManager.UpdInvoiceAndLines(invoiceDb, invLineListDb);

            return RedirectToAction("Index",
                new
                {
                    doctorId = invVM.Invoice.DoctorId,
                    clientId = invVM.Invoice.ClientId
                });

        }

    }
}
