using iNeedTickets.Models;
using iNeedTickets.Repos;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class EventsController : Controller
    {
        private IEventRepository _eventsRepository;

        public EventsController(IEventRepository repo)
        {
            _eventsRepository = repo;
        }

        public IActionResult Event(int id)
        {
            var selectedEvent = _eventsRepository.GetEventById(id);

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