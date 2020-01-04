using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iNeedTickets.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string PhotoLink { get; set; }

        public virtual ICollection<TicketType> TicketTypes { get; set; }
    }
}
