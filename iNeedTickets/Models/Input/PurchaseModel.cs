
namespace iNeedTickets.Models
{
    public class PurchaseModel
    {
        public int TicketTypeId { get; set; }

        public int TicketsCount { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
