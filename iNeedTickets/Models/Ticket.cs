
namespace iNeedTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string UserRef { get; set; }

        public TicketClass TicketClassRef { get; set; }
    }
}
