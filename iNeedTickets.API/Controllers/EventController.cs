﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Models;
using iNeedTickets.Repos;
using Microsoft.AspNetCore.Mvc;

namespace iNeedTickets.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var eventsList = _eventRepository.GetAllUpcomingEvents().ToList();

            return Ok(eventsList);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var selectedEvent = _eventRepository.GetEventById(id);

            return Ok(selectedEvent);
        }
    }
}