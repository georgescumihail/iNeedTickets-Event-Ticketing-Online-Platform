using System;
using System.Collections.Generic;
using System.Linq;
using iNeedTickets.Models;
using iNeedTickets.Repos;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class SearchController : Controller
    {
        private IEventRepository _eventsRepository;

        public SearchController(IEventRepository repo)
        {
            _eventsRepository = repo;
        }

        public IActionResult Index(string query)
        {
            var searchResults = _eventsRepository.GetEventsByQuery(query);

            return View("SearchResults", searchResults.ToList());
        }
    }
}