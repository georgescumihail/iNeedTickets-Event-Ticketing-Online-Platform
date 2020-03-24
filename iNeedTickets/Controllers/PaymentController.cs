using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iNeedTickets.Models;
using iNeedTickets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private IPurchaseService _purchaseService;
        private UserManager<User> _userManager;

        public PaymentController(IPurchaseService purchaseService, UserManager<User> userManager)
        {
            _purchaseService = purchaseService;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Execute([FromBody] PurchaseModel purchaseData)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _purchaseService.RegisterPurchase(purchaseData, userId);

            return Json("");
        }
    }
}