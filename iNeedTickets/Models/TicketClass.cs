
namespace iNeedTickets.Models
{
    public class TicketClass
    {
        public int Id { get; set; }

        public string AreaName { get; set; }

        public float Price { get; set; }

        public int Capacity { get; set; }

        public Event EventRef { get; set; }
    }
}
