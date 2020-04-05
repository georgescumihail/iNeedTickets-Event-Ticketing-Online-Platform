using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Areas.Admin.Models;
using iNeedTickets.Models;

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

        public bool RemoveEvent(int id)
        {
            var removedEvent = dbContext.Events.FirstOrDefault(e => e.Id == id);
            var removedAreas = dbContext.TicketAreas.Where(a => a.Event.Id == id);

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

            bool areAreasValid = false;

            foreach (var area in eventData.Areas)
            {
                if (area.Name != null && area.Price > 0 && area.Capacity > 0)
                {
                    areAreasValid = true;
                }
            }

            return isEventValid && areAreasValid;
        }
    }
}
