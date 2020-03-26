using System;

namespace iNeedTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public Guid EncryptionPath { get; set; }

        public User UserRef { get; set; }

        public TicketClass TicketClassRef { get; set; }

        public string FileName { get; set; }
    }
}
