using iNeedTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class CategoriesController : Controller
    {
        private IEventRepository _eventsRepository;

        public CategoriesController(IEventRepository repo)
        {
            _eventsRepository = repo;
        }

        public IActionResult Concerts()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventType.Concerts);

            ViewData.Add("CategoryName", "Concerts");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Theatre()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventType.Theatre);

            ViewData.Add("CategoryName", "Theatre");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Sports()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventType.Sports);

            ViewData.Add("CategoryName", "Sports");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Standup()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventType.Standup);

            ViewData.Add("CategoryName", "Standup");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Art()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventType.Art);

            ViewData.Add("CategoryName", "Art");
            return View("CategoryView", selectedEvents);
        }
    }
}
