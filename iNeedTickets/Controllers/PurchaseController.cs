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
    public class PurchaseController : Controller
    {
        private IPurchaseService _purchaseService;
        private UserManager<User> _userManager;

        public PurchaseController(IPurchaseService purchaseService, UserManager<User> userManager)
        {
            _purchaseService = purchaseService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] PurchaseModel purchaseData)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = _purchaseService.RegisterPurchase(purchaseData, user);

            return Json(new { isSuccess = result });
        }
    }
}