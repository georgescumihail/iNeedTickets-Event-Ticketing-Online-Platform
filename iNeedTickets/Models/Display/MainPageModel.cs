using System.Collections.Generic;

namespace iNeedTickets.Models
{
    public class MainPageModel
    {
        public List<Event> RecommendedEvents { get; set; }

        public List<Event> UpcomingEvents { get; set; }

        public List<Event> ConcertEvents { get; set; }

        public List<Event> TheatreEvents { get; set; }
    }
}
