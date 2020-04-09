using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.API.ScannerValidation.Controllers
{
    [Route("api/validate")]
    [ApiController]
    public class TicketValidationController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Validation");
        }
    }
}
