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
    [ApiVersion("3.0")]
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
    public class ClientApiControllerV3 : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    {

        // De controller heeft mapper en repository nodig, gebruik DI
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientApiController> _logger;

        private string doctorFullName;
        private int nrOfActiveInvoices;
        private decimal totalAmountOfInvoices;
        private string countryDescription;

        public ClientApiControllerV3(IInvoiceRepository invoiceRepository,
            IMapper mapper,
            ILogger<ClientApiController> logger)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // ----------------------- GetByInvoiceNumber -------------------------------------
        // Retrieve op basis van functioneel invoicenummer 
        // Deze is gemaakt om in de repository een .include te oefenen in LINQ
        // en in SQL tool van Peter te kijken

        [HttpGet("{invoiceNumber}")]
        [ProducesResponseType(200, Type = typeof(InvoiceOutgDTO))]   // TODO
        [ProducesResponseType(404)] // not found
        [ProducesDefaultResponseType] // Als bovenstaande niet van toepassing, dan deze
        public IActionResult GetByInvoiceNumber(int invoiceNumber)
        {
            var inv = _invoiceRepository.GetByInvoiceNumber(invoiceNumber);  
            // De repository bevat een Include, dus het bevat
            // de nesting Invoice.Client.Country:
            if (inv == null)
            {
                return NotFound();  // 404
            }
            else
            // Stuur altijd een DTO naar de buitenwereld, nooit het object zelf
            {
                // Map eerst de Client Velden 1:1
                var invDto = _mapper.Map<InvoiceOutgDTO>(inv);
                return Ok(invDto);
            }
        }

    }
}
