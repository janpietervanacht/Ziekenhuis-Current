using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

namespace Ziekenhuis.Ziekenhuis.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientManager _clientManager;
        private readonly ICountryManager _countryManager;

        public ClientController(ILogger<ClientController> logger,
                              IClientManager clientManager,
                              ICountryManager countryManager)
        {
            _logger = logger;
            _clientManager = clientManager;
            _countryManager = countryManager;
        }

        public IActionResult Index(int? doctorId, string prefixString,
              string subString, bool sortOnClientNumber, bool sortOnFirstName)
        {

            /* Prefix:  (sortOnClientNumber != null XOR sortOnFirstName != null)
                                XOR
                        (prefixString != null XOR subString != null) 
            */

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

            var countryList = _countryManager.GetAllCountries();

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
                // Voeg alle landen toe aan de individuele client
                c2.Countries = countryList;

                result.ClientVMList.Add(c2);

            };

            // Als de buttons sortOnClientNumber of sortOnFirstName zijn geklikt, hebben deze voorrang
            // Negeer de teksten in prefixString en subString
            if (sortOnClientNumber || sortOnFirstName)
            {
                prefixString = null;
                subString = null;
            }

            // Als prefixString is ingevuld: Toon dan alle clienten wiens voornaam begint met deze prefix
            // Als subString is ingevuld: Toon dan alle clienten met deze substring ergens in voor-achternaam, of zelfs 
            // de substring in de concat voornaam-achternaam

            // sorteer result.ClientVMList op ClientFullName

            if (prefixString == null && subString == null)
            {
                if (sortOnFirstName)
                {
                    result.ClientVMList = result
                        .ClientVMList
                        .OrderBy(c => c.ClientFullName)
                        .ToList();
                }
                if (sortOnClientNumber)
                {
                    result.ClientVMList = result
                        .ClientVMList
                        .OrderBy(c => c.Client.ClientNumber)
                        .ToList();
                }
            }
            else if (subString != null)
            {
                result.ClientVMList = result
                .ClientVMList.
                Where(c => c.Client.FirstName.ToLower()
                            .Contains(subString.ToLower())
                            ||
                            c.Client.LastName.ToLower()
                            .Contains(subString.ToLower())
                    )
                .OrderBy(c => c.ClientFullName)
                .ToList();
            }
            else if (prefixString != null)
            {
                result.ClientVMList = result
                .ClientVMList.
                Where(c => c.Client.FirstName.ToLower()
                            .StartsWith(prefixString.ToLower())
                            ||
                            c.Client.LastName.ToLower()
                            .StartsWith(prefixString.ToLower())
                    )
                .OrderBy(c => c.ClientFullName)
                .ToList();
            }

            if (subString != null)
            {
                _logger.LogDebug($"DEBUG INFO VAN JPVA - De lijst van clienten is opgevraagd " +
              $"met substring \"{subString}\" ");
                _logger.LogDebug($"DEBUG INFO VAN JPVA - Er werden {result.ClientVMList.Count} cliënten getoond");


                _logger.LogInformation($"INFORMATION INFO VAN JPVA - De lijst van clienten is opgevraagd " +
               $"met substring \"{subString}\" ");
                _logger.LogInformation($"INFORMATION INFO VAN JPVA - Er werden {result.ClientVMList.Count} cliënten getoond");

                //------------------------------------------ 

                _logger.LogWarning($"WARNING INFO VAN JPVA - De lijst van clienten is opgevraagd " +
            $"met substring \"{subString}\" ");
                _logger.LogWarning($"WARNING INFO VAN JPVA - Er werden {result.ClientVMList.Count} cliënten getoond");


                _logger.LogError($"ERROR INFO VAN JPVA - De lijst van clienten is opgevraagd " +
               $"met substring \"{subString}\" ");
                _logger.LogError($"ERROR INFO VAN JPVA - Er werden {result.ClientVMList.Count} cliënten getoond");
            }
           

            result.PrefixString = null;
            result.SubString = null;

            // ModelState.Clear:
            // Anders worden de input teksten (prefix en substring) niet geschoond
            // Bij redisplay

            ModelState.Clear();
            return View(result);

        }

        //------------------- POST INDEX ActionMethod -----------------------------------------------

        // Als je de clienten wil sorteren op substring of prefixString: via de SUBMIT button (post form)
        // Als je de clienten wil sorteren op FirstName of ClientNumber, dan gaat dia via
        // de button in de view (dit leidt niet tot een POST). 

        // Er zitten 2 forms in de view, ieder gekoppeld aan één Post Action Method

        [HttpPost]
        public IActionResult Post1ClientIndex(int? doctorId, string prefixString)
        {
            string subString = null;
            return RedirectToAction("Index", new
            {
                doctorId,
                prefixString, // toon lijst opnieuw, select: prefixString
                subString // is null
            });
        }

        //-------------------------------------- 

        [HttpPost]
        public IActionResult Post2ClientIndex(int? doctorId, string subString)
        {
            string prefixString = null;
            return RedirectToAction("Index", new
            {
                doctorId,
                prefixString, // is null
                subString // toon lijst opnieuw, select: subString
            });
        }

        // Create Get ------------------------------------------------------------ 

        public IActionResult Create(int? doctorId)
        {
            var cltVM = new ClientViewModel();

            // Onderstaande is nodig, want ActionCode staat niet in het scherm (wèl als HiddenFor) 
            // In de viewmodel wordt ActionCode verplicht gesteld op A/I middels een reg.expr. 
            // Zonder onderstaande regel kan je geen client toevoegen (ModelState.Isvalid wordt false)

            cltVM.Client = new Client { ActionCode = 'A' };

            // Alle landen toevoegen aan CREATE scherm, ivm dropdownlist
            cltVM.Countries = _countryManager.GetAllCountries();

            // Neem doctorId mee als hidden field in de view
            // Immers als we de Terug knop aanraken willen we weer de clienten lijst zien voor deze dokter
            if (doctorId.HasValue)
            {
                cltVM.Client.DoctorId = doctorId.Value;
                cltVM.DoctorFullName = _clientManager.DoctorFullName(doctorId.Value);
            }

            // cltVM.Client.Country = "Nederland";

            // We geven toch een ClientViewModel object aan de view
            // Omdat we dan in de view Lambda expressies
            // kunnen gebruiken in o.a. Html.LabelFor en Html.EditorFor

            // Vul de doctor's comment alvast met een templaat:

            cltVM.Client.CommentForDoctor =
                "Eerste indruk client: XXXXXX \n\n" +
                "Overgewicht:          XXXXXX \n\n" +
                "Familiegegevens:      XXXXXX ";
            // Initialiseer geboortedatum
            cltVM.Client.BirthDate = new DateTime(1970, 01, 01);
            cltVM.Client.Gender = "Man"; // Dan is er zeker één radiobutton ingevuld

            return View(cltVM);

        }

        //------------------------------------------------------------------- 

        // POST is altijd het gevolg van een SUBMIT op FORM niveau. 
        // POST: Client/Create: Als je op Save Button drukt, POST je de nieuwe 
        // gegevens terug naar de controller. 


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientViewModel cltVM)
        {
            if (!ModelState.IsValid)
            {
                // Geef de ViewModel terug:

                // Opmerking: onderstaande werkt niet.
                // "FirstNameChanged" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                cltVM.Client.FirstName = "FirstNamechanged";

                // Geef de lijst van landen weer terug aan de view
                // Zo niet, dan klapt de applicatie en werkt de dropdownlist niet
                cltVM.Countries = _countryManager.GetAllCountries(); // deze werkt wel 

                return View(cltVM);
            }

            // Check hier de velden op correcte invoer (complexer)
            // Stop met valideren bij de eerste gevonden fout


            string errMsg = ErrorCheck.CheckForErrors(cltVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);

                // Opmerking: onderstaande werkt niet.
                // "LastNameChanged" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                cltVM.Client.LastName = "LastNamechanged";

                // Geef de lijst van landen weer terug aan de view
                // Zo niet, dan klapt de applicatie en werkt de dropdownlist niet
                cltVM.Countries = _countryManager.GetAllCountries();
                return View(cltVM);
            }

            var clt = cltVM.ToClient();
            // clt.Id: geen waarde geven bij Create
            clt.DoctorId = 1;  // NTD idereen krijgt doctor 1: de doctor die inlogt bepaalt deze waarde
            clt.ActionCode = 'A';

            // Pas hier het clientnummer aan
            clt.ClientNumber = _clientManager.GetAndUpdateCurrentClientNumber();
            _clientManager.AddClient(clt);

            return RedirectToAction("Index", new
            {
                doctorId = cltVM.Client.DoctorId
            });

        }

        //-------------------------------------------------------------------
        // Details kent alleen een GET

        // Opmerking: parameter hieronder MOET clientIdNr heten (conform de ActionLink in index.cshtml)
        public IActionResult Details(int clientId)
        {
            var clt = _clientManager.GetClient(clientId);
            var cltVM = clt.ToClientVM();

            // 2. Map all derived fields ---------
            cltVM.ClientFullName = clt.FirstName + " " + clt.LastName;

            cltVM.AgeInDays = (int)(DateTime.Today.Subtract(clt.BirthDate)).TotalDays;
            cltVM.NrofPrescriptions = _clientManager.GetNrOfPrescrPerClient(clt.Id);
            cltVM.DoctorFullName = _clientManager.DoctorFullName(clt.DoctorId);
            // Voeg alle landen toe aan dit detail record. 
            // Ook al is de dropdownlist uitgeschakeld, is dit toch nodig
            cltVM.Countries = _countryManager.GetAllCountries();

            return View(cltVM);
        }

        //-------------------------------------------------------------------
        // Delete GET: tonen read-only scherm voor DELETE
        // Opmerking: parameter hieronder MOET "clientId" heten (conform de ActionLink in index.cshtml)
        public IActionResult Delete(int clientId)
        {
            var clt = _clientManager.GetClient(clientId);
            var cltVM = clt.ToClientVM();

            // 2. Map all derived fields ---------
            cltVM.ClientFullName = clt.FirstName + " " + clt.LastName;

            cltVM.AgeInDays = (int)(DateTime.Today.Subtract(clt.BirthDate)).TotalDays;
            cltVM.NrofPrescriptions = _clientManager.GetNrOfPrescrPerClient(clt.Id);
            cltVM.DoctorFullName = _clientManager.DoctorFullName(clt.DoctorId);

            // Voeg alle landen toe aan dit Delete record. 
            // Ook al is de dropdownlist uitgeschakeld, is dit toch nodig
            cltVM.Countries = _countryManager.GetAllCountries();

            return View(cltVM);
        }

        //-------------------------------------------------------------------


        // POST: Client/Delete/5
        // Delete() is GET /  DeleteConfirmed() is POST 

        // Delete() is GET /  DeleteConfirmed() is POST 
        // GET en POST action methods bij Delete moeten verschillende 
        // namen hebben, want ze hebben 
        // beiden een int  als parameter, overloading kan dus niet. 
        // DAAROM De ActionName "Delete" is dus nodig om aan te geven
        // Dat methode DeleteConfirmed hoort bij de (Post) Action Method "Delete" 

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        // ATTENTIE: parameter hieronder moet exact dezelfde naam hebben
        // als in de GET actie voor Delete. Namelijk: "clientIdentificatie".
        // Als deze parameter een andere naam heeft, wordt deze parameter 0. 
        // Er wordt dan geen client verwijderd.

        // public IActionResult DeleteConfirmed(int klantId) // WERKT NIET
        public IActionResult DeleteConfirmed(int clientId)

        {
            // _clientManager.DeleteClient(klantId); // WERKT NIET
            _clientManager.DeleteClient(clientId);
            return RedirectToAction("Index");
        }


        //-------------------------------------------------------------------
        // Update GET (ook actief / inactief maken hoort hierbij)  
        public IActionResult Update(int clientId)
        {
            var clt = _clientManager.GetClient(clientId);
            var cltVM = clt.ToClientVM();

            // 2. Map all derived fields ---------
            cltVM.ClientFullName = clt.FirstName + "  " + clt.LastName;
            cltVM.AgeInDays = (int)(DateTime.Today.Subtract(clt.BirthDate)).TotalDays;
            cltVM.NrofPrescriptions = _clientManager.GetNrOfPrescrPerClient(clt.Id);
            cltVM.DoctorFullName = _clientManager.DoctorFullName(clt.DoctorId);
            // Alle landen toevoegen aan CREATE scherm, ivm dropdownlist
            cltVM.Countries = _countryManager.GetAllCountries();

            return View(cltVM);
        }

        //-------------------------------------------------------------------

        // POST: Client/Update/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ClientViewModel cltVM)
        {

            if (!ModelState.IsValid)
            {
                // Geef de ViewModel terug:

                // Opmerking: onderstaande werkt niet.
                // "FirstNameVeranderd" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                cltVM.Client.FirstName = "FirstNameVeranderd";

                // Geef opnieuw alle countries mee terug, zodat de dropdownlist blijft werken
                // Anders klapt de applicatie eruit
                cltVM.Countries = _countryManager.GetAllCountries();

                return View(cltVM);
            }

            // Check hier de velden op correcte invoer (complexer)
            // Stop met valideren bij de eerste gevonden fout

            string errMsg = ErrorCheck.CheckForErrors(cltVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);

                // Opmerking: onderstaande werkt niet.
                // "LastNameVeranderd" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                cltVM.Client.LastName = "LastNameVeranderd";

                // Geef opnieuw alle countries mee terug, zodat de dropdownlist blijft werken
                // Anders klapt de applicatie eruit
                cltVM.Countries = _countryManager.GetAllCountries();

                return View(cltVM);
            }

            // converteer cltVM naar clt via extension method
            var clt = cltVM.ToClient();
            _clientManager.UpdateClient(clt);
            return RedirectToAction("Index");
        }

        //----------------------------------------------------- 

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
