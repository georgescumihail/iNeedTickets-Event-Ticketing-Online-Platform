using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Areas.Admin.Models;
using iNeedTickets.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace iNeedTickets.Services
{
    public class EventService : IEventService
    {
        private ILocationService _locationService;
        private ApplicationDbContext dbContext;

        public EventService(ILocationService locationService, ApplicationDbContext context)
        {
            _locationService = locationService;
            dbContext = context;
        }

        public bool AddEvent(AddEventData eventData)
        {
            if (IsEventDataValid(eventData))
            {
                var eventLocation = _locationService.GetLocationById(eventData.Location);

                var fileName = $"{eventData.Name}-{eventData.Location}-{eventData.Date}.jpg".Replace(" ", "-");

                var image = Image.FromStream(eventData.Image.OpenReadStream());

                image.Save("./Images/Events/" + fileName, ImageFormat.Jpeg);

                var newEvent = new Event
                {
                    Name = eventData.Name,
                    Date = DateTime.Parse(eventData.Date),
                    Location = eventLocation,
                    EventType = (EventCategory)eventData.Category,
                    Description = eventData.Description,
                    Tags = eventData.Tags,
                    IsSeated = eventData.IsSeated,
                    PhotoLink = fileName
                };

                dbContext.Events.Add(newEvent);
                dbContext.SaveChanges();

                var ticketAreas = new List<TicketArea>();

                foreach (var area in eventData.Areas)
                {
                    ticketAreas.Add(new TicketArea
                    {
                        AreaName = area.Name,
                        Price = area.Price,
                        TicketsCapacity = area.Capacity,
                        TicketsRemaining = area.Capacity,
                        Event = newEvent
                    });
                }

                dbContext.TicketAreas.AddRange(ticketAreas);
                dbContext.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditEvent(EditEventData editData)
        {
            var editedEvent = dbContext.Events.Include(e => e.TicketAreas).FirstOrDefault(e => e.Id == editData.Id);
            var areasList = new List<EditEventTicketArea>();

            try
            {
                areasList = JsonConvert.DeserializeObject<List<EditEventTicketArea>>(editData.Areas);
            }
            catch { return false; }

            if (IsEventEditDataValid(editData, areasList) && editedEvent != null)
            {
                editedEvent.Name = editData.Name;
                editedEvent.Description = editData.Description;
                editedEvent.Date = DateTime.Parse(editData.Date);
                editedEvent.Tags = editData.Tags;

                foreach (var newArea in areasList)
                {
                    var oldArea = editedEvent.TicketAreas.First(a => a.Id == newArea.Id);

                    oldArea.AreaName = newArea.Name;
                    oldArea.Price = newArea.Price;
                    oldArea.TicketsRemaining += newArea.Capacity - oldArea.TicketsCapacity;
                    oldArea.TicketsCapacity = newArea.Capacity;
                }

                dbContext.SaveChanges();

                return true;
            }


            return false;
        }

        public bool RemoveEvent(int id)
        {
            var removedEvent = dbContext.Events.FirstOrDefault(e => e.Id == id);
            var removedAreas = dbContext.TicketAreas.Where(a => a.Event.Id == id);
            var removedTickets = dbContext.Tickets.Where(t => t.TicketArea.Event.Id == id);

            dbContext.Tickets.RemoveRange(removedTickets);
            dbContext.TicketAreas.RemoveRange(removedAreas);
            dbContext.Events.Remove(removedEvent);

            var changes = dbContext.SaveChanges();

            return changes > 0;
        }

        private bool IsEventDataValid(AddEventData eventData)
        {
            bool isEventValid = !string.IsNullOrWhiteSpace(eventData.Name)
                && !string.IsNullOrWhiteSpace(eventData.Date)
                && eventData.Image != null;

            bool areAreasValid = true;

            foreach (var area in eventData.Areas)
            {
                if (area.Name == null && area.Price < 0 && area.Capacity < 0)
                {
                    areAreasValid = false;
                }
            }

            return isEventValid && areAreasValid;
        }


        private bool IsEventEditDataValid(EditEventData eventData, List<EditEventTicketArea> ticketAreas)
        {
            bool isEventValid = !string.IsNullOrWhiteSpace(eventData.Name)
                && !string.IsNullOrWhiteSpace(eventData.Date);

            bool areAreasValid = true;

            foreach (var area in ticketAreas)
            {
                if (area.Name == null && area.Price < 0 && area.Capacity < 0)
                {
                    areAreasValid = false;
                }
            }

            return isEventValid && areAreasValid;
        }
    }
}
