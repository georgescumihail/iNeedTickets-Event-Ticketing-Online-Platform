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
        private ITransactionService _transactionService;
        private UserManager<User> _userManager;

        public PurchaseController(IPurchaseService purchaseService,
                                ITransactionService transactionService,
                                UserManager<User> userManager)
        {
            _purchaseService = purchaseService;
            _transactionService = transactionService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] PurchaseModel purchaseData)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = _purchaseService.RegisterPurchase(purchaseData, user);

            await _userManager.UpdateAsync(user);

            return Json(new { isSuccess = result.IsSuccess, message = result.Message });
        }

        [HttpPost]
        public IActionResult SaveDetails([FromBody] PaypalTransaction transaction)
        {
            _transactionService.Save(transaction);

            return Ok();
        }
    }
}