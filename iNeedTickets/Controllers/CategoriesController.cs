using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class CategoriesController : Controller
    {
        private IEventRepository repository;

        public CategoriesController(IEventRepository repo)
        {
            repository = repo;
        }

        public IActionResult Concerts()
        {
            var selectedEvents = repository.Events.Where(e => e.EventType == EventType.Concerts);

            return View("CategoryView", selectedEvents);
        }

        public IActionResult Theatre()
        {
            var selectedEvents = repository.Events.Where(e => e.EventType == EventType.Theatre);

            return View("CategoryView", selectedEvents);
        }

        public IActionResult Sports()
        {
            var selectedEvents = repository.Events.Where(e => e.EventType == EventType.Sports);

            return View("CategoryView", selectedEvents);
        }

        public IActionResult Standup()
        {
            var selectedEvents = repository.Events.Where(e => e.EventType == EventType.Standup);

            return View("CategoryView", selectedEvents);
        }

        public IActionResult Art()
        {
            var selectedEvents = repository.Events.Where(e => e.EventType == EventType.Art);

            return View("CategoryView", selectedEvents);
        }
    }
}
