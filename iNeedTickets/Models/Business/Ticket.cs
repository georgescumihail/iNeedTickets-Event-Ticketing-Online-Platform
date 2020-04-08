using System;

namespace iNeedTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public Guid EncryptionCode { get; set; }

        public User User { get; set; }

        public TicketArea TicketArea { get; set; }

        public string FileName { get; set; }

        public bool IsActive { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
