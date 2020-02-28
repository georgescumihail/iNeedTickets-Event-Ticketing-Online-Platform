using System;
using System.Collections.Generic;
using System.Linq;
using iNeedTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Controllers
{
    public class SearchController : Controller
    {
        private IEventRepository repository;

        public SearchController(IEventRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(string query)
        {
            var searchResults = repository.Events.Where(e => e.Name.Contains(query) || e.Location.Name.Contains(query));

            return View("SearchResults", searchResults.ToList());
        }
    }
}