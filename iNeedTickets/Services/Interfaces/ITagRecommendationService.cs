using iNeedTickets.Models;
using System.Collections.Generic;

namespace iNeedTickets.Services
{
    public interface ITagRecommendationService
    {
        IEnumerable<Event> GetRecommendedEvents(string userId);
    }
}