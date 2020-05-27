using iNeedTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Repos
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAllUpcomingEvents();

        IQueryable<Event> GetAllUpcomingEventsSortedByDate();

        Event GetEventById(int id);

        IQueryable<Event> GetEventsByQuery(string query);

        IQueryable<Event> GetEventsByType(EventCategory eventType, int selectionSize = 8);

        IQueryable<Event> GetClosestUpcomingEvents(int selectionSize);
    }
}
