using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManagerController : Controller
    {
        private IEventRepository _eventRepository;

        public ManagerController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IActionResult Index()
        {
            var eventsList = _eventRepository.GetAllUpcomingEvents();

            return View("ManagerMenu", eventsList.ToList());
        }
    }
}