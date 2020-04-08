using System;
using System.Collections.Generic;
namespace iNeedTickets.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public EventCategory EventType { get; set; }

        public string PhotoLink { get; set; }

        public ICollection<TicketArea> TicketAreas { get; set; }
    }
}
