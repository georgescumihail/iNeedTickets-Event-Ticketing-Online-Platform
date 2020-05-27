using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Areas.Admin.Models;
using iNeedTickets.Models;
using iNeedTickets.Repos;
using iNeedTickets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace iNeedTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManagerController : Controller
    {
        private IEventRepository _eventRepository;
        private ILocationService _locationService;
        private IEventService _eventService;

        public ManagerController(IEventRepository eventRepository, ILocationService locationService, IEventService eventService)
        {
            _eventRepository = eventRepository;
            _locationService = locationService;
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var eventsList = _eventRepository.GetAllUpcomingEventsSortedByDate();

            return View("ManagerMenu", eventsList.ToList());
        }

        public IActionResult EditEvent(int id)
        {
            var selectedEvent = _eventRepository.GetEventById(id);

            return View(selectedEvent);
        }

        public IActionResult AddEvent()
        {
            var locationList = _locationService.GetAllLocations();

            return View(locationList);
        }

        [HttpPost]
        public IActionResult AddEvent([FromForm] string name, string date, int location, int category, 
                                                 string description, IFormFile image, string areas)
        {
            var isSuccess = true;
            var areasList = new List<AddEventTicketArea>();

            try {
                areasList = JsonConvert.DeserializeObject<List<AddEventTicketArea>>(areas);
            }
            catch {
                isSuccess = false;
            }

            var newEventData = new AddEventData
            {
                Name = name,
                Date = date,
                Location = location,
                Category = category,
                Description = description,
                Image = image,
                Areas = areasList
            };

            isSuccess = _eventService.AddEvent(newEventData);

            return Json(new { isSuccess });
        }

        public IActionResult DeleteEvent(int id)
        {
            var isSuccess = _eventService.RemoveEvent(id);

            return Json(new { isSuccess });
        }
    }
}