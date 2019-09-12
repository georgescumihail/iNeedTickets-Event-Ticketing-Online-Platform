using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iNeedTickets.Models;

namespace iNeedTickets.Controllers
{
    public class HomeController : Controller
    {
        private IEventRepository repository;

        public HomeController(IEventRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {

            return View(repository.events.ToList());
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
