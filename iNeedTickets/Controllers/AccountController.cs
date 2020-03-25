using iNeedTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace iNeedTickets.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ITicketRepository _ticketRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITicketRepository ticketRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ticketRepository = ticketRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string previousUrl)
        {
            ViewBag.previousUrl = previousUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, data.Password, true, false);

                if (signInResult.Succeeded)
                {
                    return Json(new { isSuccess = true });
                }
            }

            return Json(new { isSuccess = false, message = "Invalid username or password!" });
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View("Signup");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SignupModel data)
        {
            var newUser = new User
            {
                Email = data.Email,
                UserName = data.Username
            };

            var result = await _userManager.CreateAsync(newUser, data.Password);

            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(newUser, data.Password, true, false);
                return Json(new { success = true, message = "" });
            }
            else
            {
                var errorMessage = "";
                result.Errors.ToList().ForEach(e => errorMessage += e.Description + "\n");
                return Json(new { message = errorMessage });
            }
        }

        public async Task<IActionResult> Signout()
        {
            if (User.Identity.IsAuthenticated) {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Tickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ticketList = _ticketRepository.GetTicketListByUser(userId).OrderByDescending(t => t.Id);

            return View("UserTickets", ticketList);
        }

        public IActionResult Ticket(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var selectedTicket = _ticketRepository.GetTicketById(id);

            return View(selectedTicket);
        }
    }
}