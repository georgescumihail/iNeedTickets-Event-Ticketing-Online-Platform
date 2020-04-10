using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Scanner.API.Models;
using iNeedTickets.Scanner.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.API.ScannerValidation.Controllers
{
    [Route("api/validate/")]
    [ApiController]
    public class TicketValidationController : ControllerBase
    {
        private ITicketValidationService _ticketValidationService;

        public TicketValidationController(ITicketValidationService ticketValidationService)
        {
            _ticketValidationService = ticketValidationService;
        }

        [HttpPost]
        public ActionResult<TicketValidationResponseModel> Post([FromBody] TicketValidationRequestModel request)
        {
            var ticketGuid = Guid.Parse(request.TicketCode);

            var response = _ticketValidationService.Check(ticketGuid);

            return response;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Validation API");
        }
    }
}
