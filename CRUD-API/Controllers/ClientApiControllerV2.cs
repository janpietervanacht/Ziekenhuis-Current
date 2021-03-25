using AutoMapper;
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
    [Route("api/v{version:ApiVersion}/ClientApi")]
    [ApiVersion("2.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)] // Voor alle ActionMethods geldig

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ClientApiControllerV2 : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    {

        // De controller heeft mapper en repository nodig, gebruik DI
        private readonly IClientRepository _clientRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientApiController> _logger;

        private string doctorFullName;
        private int nrOfActiveInvoices;
        private decimal totalAmountOfInvoices;

        public ClientApiControllerV2(IClientRepository clientRepository,
            IInvoiceRepository invoiceRepository,
            IMapper mapper,
            ILogger<ClientApiController> logger)
        {
            _clientRepository = clientRepository;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // ----------------------- GetAll -------------------------------------

        [HttpGet] // Omdat hier geen parameters achter staan, wordt dit een GETALL implementatie
        [ProducesResponseType(200, Type = typeof(List<ClientOutgDTO>))]
        public IActionResult GetAllClients()
        {
            var cltList = _clientRepository.GetAll();

            // Maak omschrijvingen allemaal in uppercase
            for (int i = 0; i < cltList.Count; i++)
            {
                var clt = cltList[i];
                clt.FirstName = clt.FirstName.ToUpper();
                clt.LastName = clt.LastName.ToUpper();
                clt.Street = clt.Street.ToUpper();
                clt.City = clt.City.ToUpper();
                // clt.Country = clt.Country.ToUpper();
                if (clt.CommentForDoctor != null)
                {
                    // Enige veld dat niet [Required] is: 
                    clt.CommentForDoctor = clt.CommentForDoctor.ToUpper();
                }
            }


            // Je mag nooit je eigen objecten naar de buitenwereld sturen.
            // Stuur dus niet objList naar buiten, stuur alleen DTO's naar buiten 

            // Om didactische redenen heb ik een incomende DTO en een uitgaande DTO gemaakt
            // echter qua inhoud zijn ze gelijk aan elkaar. 
            var cltOutgDTOList = new List<ClientOutgDTO>();  // Wijst naar een geheugen stuk in heap, met 0 elementen

            for (int i = 0; i < cltList.Count; i++)
            {
                // Standard fields from Client
                cltOutgDTOList.Add(_mapper.Map<ClientOutgDTO>(cltList[i])); // de new ClientOutgDTO{} zit in de mapper gecodeerd

                // Derived fields: doctorFullName / totalAmountOfInvoices / nrOfActiveInvoices
                DetermineDerivedFieldsPerClient(cltList[i]);
                cltOutgDTOList[i].DoctorFullName = doctorFullName.ToUpper();
                cltOutgDTOList[i].TotalAmountOfInvoices = totalAmountOfInvoices;
                cltOutgDTOList[i].NrOfActiveInvoices = nrOfActiveInvoices;
            }

            return Ok(cltOutgDTOList);  // creeert een Status 200 OK response
        }


        private void DetermineDerivedFieldsPerClient(Client client)
        {
            var cltId = client.Id;
            var doctorId = client.DoctorId;
            doctorFullName = _clientRepository.DoctorFullName(doctorId);

            var invList = _invoiceRepository
                .GetAllPerClient(cltId)
                .Where(i => i.ActionCode == 'A' && i.Status == 'O');

            nrOfActiveInvoices = invList.Count();
            totalAmountOfInvoices = invList.Sum(i => i.Amount);
        }
    }
}