using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Models
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAllUpcomingEvents();

        Event GetEventById(int id);

        IQueryable<Event> GetEventsByQuery(string query);

        IQueryable<Event> GetEventsByType(EventCategory eventType, int selectionSize = 8);

        IQueryable<Event> GetClosestUpcomingEvents(int selectionSize);
    }
}
