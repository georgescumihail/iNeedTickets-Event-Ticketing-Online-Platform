using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var searchResults = repository.Events.Where(e => e.Name.Contains(query));

            return View(searchResults.ToList());
        }
    }
}