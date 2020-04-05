using System;

namespace iNeedTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public Guid EncryptionPath { get; set; }

        public User User { get; set; }

        public TicketArea TicketArea { get; set; }

        public string FileName { get; set; }
    }
}
