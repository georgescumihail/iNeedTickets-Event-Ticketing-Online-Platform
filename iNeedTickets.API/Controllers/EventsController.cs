using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Models;
using iNeedTickets.Repos;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("API");
        }
    }
}
