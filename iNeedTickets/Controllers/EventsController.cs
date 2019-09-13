using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class EventsController : Controller
    {
        private IEventRepository repository;

        public EventsController(IEventRepository repo)
        {
            repository = repo;
        }

        public IActionResult Event(int id)
        {
            var selectedEvent = repository.events.FirstOrDefault(e => e.id == id);

            if (selectedEvent != null)
            {
                return View(selectedEvent);
            }
            else
            {
                return View("EventNotFound");
            }
        }
    }
}