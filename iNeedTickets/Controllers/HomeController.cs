using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iNeedTickets.Models;
using iNeedTickets.Repos;
using System.Security.Claims;
using iNeedTickets.Services;

namespace iNeedTickets.Controllers
{
    public class HomeController : Controller
    {
        private IEventRepository _eventsRepository;
        private ITagRecommendationService _tagRecommendationService;
        private const int UPCOMING_SIZE = 8;

        public HomeController(IEventRepository eventsRepository, ITagRecommendationService tagRecommendationService)
        {
            _eventsRepository = eventsRepository;
            _tagRecommendationService = tagRecommendationService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(new MainPageModel
            {
                UpcomingEvents = _eventsRepository.GetClosestUpcomingEvents(UPCOMING_SIZE).ToList(),
                ConcertEvents = _eventsRepository.GetEventsByType(EventCategory.Concerts).ToList(),
                TheatreEvents = _eventsRepository.GetEventsByType(EventCategory.Theatre).ToList(),
                RecommendedEvents = _tagRecommendationService.GetRecommendedEvents(userId).ToList()
            });
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
