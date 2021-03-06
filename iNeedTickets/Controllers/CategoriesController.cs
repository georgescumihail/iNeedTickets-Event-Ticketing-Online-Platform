﻿using iNeedTickets.Models;
using iNeedTickets.Repos;
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
            var selectedEvents = _eventsRepository.GetEventsByType(EventCategory.Concerts);

            ViewData.Add("CategoryName", "Concerts");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Theatre()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventCategory.Theatre);

            ViewData.Add("CategoryName", "Theatre");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Sports()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventCategory.Sports);

            ViewData.Add("CategoryName", "Sports");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Standup()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventCategory.Standup);

            ViewData.Add("CategoryName", "Standup");
            return View("CategoryView", selectedEvents);
        }

        public IActionResult Art()
        {
            var selectedEvents = _eventsRepository.GetEventsByType(EventCategory.Art);

            ViewData.Add("CategoryName", "Art");
            return View("CategoryView", selectedEvents);
        }
    }
}
