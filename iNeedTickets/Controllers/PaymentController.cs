using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class PaymentController : Controller
    {
        [HttpPost]
        public IActionResult Execute()
        {
            return Json("");
        }
    }
}