using AutoMapper;
using Ziekenhuis.CRUD_API.ConstantsAndEnums;
using Ziekenhuis.CRUD_API.DTO_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.CRUD_API.Controllers
{
    [Route("api/v{version:ApiVersion}/clientapi")]
    // [ApiVersion("1.0")]  // Afgesterd, deze versie wordt default 1.0

    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)] // Voor alle ActionMethods geldig
        
    // Warning XML zegt dat er geen XML documentatie is voor objecten, die publiek zichtbaar zijn.
    // Dit geeft vele onnodige warnings.

    // Via intellisense heb ik warning CS1591 uitgeschakeld voor de class ClientApiController
    // Zie de #pragma disable en #pragma restore

    // Je kan de gehele warning CS1591 ook uitschakelen via
    // Project -> Properties -> Build -> Suppress warnings : zet "1591;" er achteraan
    // En doe een Save All

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ClientApiController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    {

        // De controller heeft mapper en repository nodig, gebruik DI
        private readonly IClientRepository _clientRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientApiController> _logger;

        private string doctorFullName;
        private int nrOfActiveInvoices;
        private decimal totalAmountOfInvoices;
        private string countryDescription;

        public ClientApiController(IClientRepository clientRepository,
            IInvoiceRepository invoiceRepository,
            ICountryRepository countryRepository,
            IMapper mapper,
            ILogger<ClientApiController> logger)
        {
            _clientRepository = clientRepository;
            _invoiceRepository = invoiceRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // ----------------------- GetAll -------------------------------------

        [HttpGet] // Omdat hier geen parameters achter staan, wordt dit een GETALL implementatie
        [ProducesResponseType(200, Type = typeof(List<ClientOutgDTO>))]
        public IActionResult GetAllClients()
        {
            var cltList = _clientRepository.GetAll();

            // Je mag nooit je eigen objecten naar de buitenwereld sturen.
            // Stuur dus niet objList naar buiten, stuur alleen DTO's naar buiten 

            // Om didactische redenen heb ik een incomende DTO en een uitgaande DTO gemaakt
            // echter qua inhoud zijn ze gelijk aan elkaar. 
            var cltOutgDTOList = new List<ClientOutgDTO>();  // Wijst naar een geheugen stuk in heap, met 0 elementen

            for (int i = 0; i < cltList.Count; i++)
            {
                var clt = cltList[i]; 
                // Standard fields from Client
                cltOutgDTOList.Add(_mapper.Map<ClientOutgDTO>(clt)); // de new ClientOutgDTO{} zit in de mapper gecodeerd

                // Derived fields: doctorFullName / totalAmountOfInvoices / nrOfActiveInvoices
                DetermineDerivedFieldsPerClient(clt);
                cltOutgDTOList[i].DoctorFullName = doctorFullName;
                cltOutgDTOList[i].TotalAmountOfInvoices = totalAmountOfInvoices;
                cltOutgDTOList[i].NrOfActiveInvoices = nrOfActiveInvoices;
                cltOutgDTOList[i].CountryDescription = countryDescription; 
            }

            return Ok(cltOutgDTOList);  // creeert een Status 200 OK response
        }




        // ----------------------- GetOneClient -------------------------------------
        // Retrieve op basis van functioneel klantnummer, dus niet op Id

        // [HttpGet("{clientNumber:int}", Name="GetByClientNr")]
        [HttpGet("{clientNumber}")]
        [ProducesResponseType(200, Type = typeof(ClientOutgDTO))]
        [ProducesResponseType(404)] // not found
        [ProducesDefaultResponseType] // Als bovenstaande niet van toepassing, dan deze
        public IActionResult GetByClientNr(int clientNumber)
        {
            var clt = _clientRepository.GetByClientNumber(clientNumber);

            if (clt == null)
            {
                return NotFound();  // 404
            }
            else
            // Stuur altijd een DTO naar de buitenwereld, nooit het object zelf
            {
                // Map eerst de Client Velden 1:1
                var cltDto = _mapper.Map<ClientOutgDTO>(clt);

                // Derived fields: doctorFullName / totalAmountOfInvoices / nrOfActiveInvoices
                DetermineDerivedFieldsPerClient(clt);
                cltDto.TotalAmountOfInvoices = totalAmountOfInvoices;
                cltDto.NrOfActiveInvoices = nrOfActiveInvoices;
                cltDto.DoctorFullName = doctorFullName;
                cltDto.CountryDescription = countryDescription;

                return Ok(cltDto);
            }
        }

        // ---------------------- toevoegen (POST) ------------------------------------------- 

        [HttpPost]  // Aan de 'Post' zie je dat het toevoegen betreft
        [ProducesResponseType(201, Type = typeof(ClientOutgDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrtClient([FromBody] ClientIncDTO clientIncDTO)
        {

            if (clientIncDTO == null)
            {
                return BadRequest(ModelState);
            }

            // Converteer Data Transfer Object naar intern Client Object: 
            var client = _mapper.Map<Client>(clientIncDTO);

            client.DoctorId = 1; // Dokter Bernard
            client.ActionCode = 'A';

            //  Haal het land op
            var country = _countryRepository.GetCountryByIsoCode(clientIncDTO.CountryCodeISO); 

            if (country != null)  // land niet gevonden op basis van ISO code
            {
                client.CountryId = country.Id; 
            }
            else  // Nederland toekennen als land
            {
                client.CountryId = Const.cCountryIdNederland; 
            }

            // Zorg ervoor dat alle niet-nullable velden gevuld zijn voordat
            // je het record aan de database toevoegt
            try
            {
                // Tabel met nummer-reeksen kent maar 1 record: 
                var newClientNumber = _clientRepository.GetAndUpdateCurrentClientNumber();
                client.ClientNumber = newClientNumber;
                _clientRepository.Add(client);
            }
            catch(Exception errMsg)
            {
                ModelState.AddModelError("", $"Er is iets fout gegaan \n {errMsg}");
                return StatusCode(500, ModelState);
            }

            // Best practice bij een [HttpPost]: gebruik CreatedAtAction en 
            // geef het hele Outg record terug aan Postman. 

            var clientOutgDto = _mapper.Map<ClientOutgDTO>(client);

            // Derived fields: doctorFullName / totalAmountOfInvoices / nrOfActiveInvoices
            DetermineDerivedFieldsPerClient(client);
            clientOutgDto.TotalAmountOfInvoices = totalAmountOfInvoices;
            clientOutgDto.NrOfActiveInvoices = nrOfActiveInvoices;
            clientOutgDto.DoctorFullName = doctorFullName;
            clientOutgDto.CountryDescription = countryDescription;

            // Stuur een outgoing DTO terug, daarin staan niet de technische velden DoctorId, ClientId, ActionCode 
            //return CreatedAtAction("GetByClientNr", "ClientApi", 
            //    new { clientNumber = client.ClientNumber }, clientOutgDto);

            // return CreatedAtRoute(nameof(GetByClientNr), new { id = 1, version = ApiVersion.ToString() }, "test");

            // return CreatedAtRoute("GetByClientNr", new { clientNumber = clientOutgDto.ClientNumber }, clientOutgDto);

            return CreatedAtAction("GetByClientNr", "ClientApi",
                new { clientNumber = client.ClientNumber }, clientOutgDto);
        }

        // ---- Update (PUT) -------------------------------- 

        [HttpPut("{clientNumber}")]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdClient(int clientNumber, [FromBody] ClientIncDTO clientIncDTO)
        {

            if (clientIncDTO == null)
            {
                return BadRequest(ModelState);
            }
            // Eerst Id ophalen, en daarna de client via Id te updaten, werkt niet.
            // Als je een Update op Id doet NA een lees-aktie op Id, krijg je de volgende melding:

            // 'The instance of entity type 'Client' cannot be tracked because 
            // another instance with the same key value for {'Id'} is already being tracked. 

            var client = _mapper.Map<Client>(clientIncDTO);

            // De landencode kan zijn veranderd. Haal het land op
            var country = _countryRepository.GetCountryByIsoCode(clientIncDTO.CountryCodeISO);

            if (country != null)  // land niet gevonden op basis van ISO code
            {
                client.CountryId = country.Id;
            }
            else  // Nederland toekennen als land
            {
                client.CountryId = Const.cCountryIdNederland;
            }

            // Tabel met nummer - reeksen kent maar 1 record:
            var success = _clientRepository.UpdateByClientNumber(client);
            if (!success)
            {
                ModelState.AddModelError("", $"Er is iets foutgegaan bij update voor {clientIncDTO.FirstName}");
                return StatusCode(500, ModelState);
            }

            // Best practice bij een [HttpPost]: gebruik CreatedAtAction en geef het hele record terug aan Postman
            // De aanvrager kan bijv 3 velden sturen, en een record van 10 velden terug krijgen 

            var clientOutgDto = _mapper.Map<ClientOutgDTO>(client);
            return CreatedAtAction("GetByClientNr", "ClientApi", 
                new { clientNumber = client.ClientNumber }, clientOutgDto);

        }

        //------------------------ delete ------------------------------------------- 

        [HttpDelete("{clientNumber}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteClient(int clientNumber)
        {
            var success = _clientRepository.DeleteByClientNumber(clientNumber);
            if (success)
            {
                return NoContent();  // 204
            }
            else
            {
                return NotFound(); // 404
            }
        }

        // ----------------------- Determine derived fields -------------------------------------

        private void DetermineDerivedFieldsPerClient(Client client)
        {
            var cltId = client.Id;
            var doctorId = client.DoctorId;
            doctorFullName = _clientRepository.DoctorFullName(doctorId);

            if (client.CountryId.HasValue)
            {
                countryDescription = _countryRepository
                    .GetCountryById(client.CountryId.Value)
                    .CountryDescription;
            }

            var invList = _invoiceRepository
                .GetAllPerClient(cltId)
                .Where(i => i.ActionCode == 'A' && i.Status == 'O');

            nrOfActiveInvoices = invList.Count();
            totalAmountOfInvoices = invList.Sum(i => i.Amount);
        }

    }
}
