
namespace iNeedTickets.Models
{
    public class PaypalTransaction
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public string PayerId { get; set; }

        public string PayerName { get; set; }

        public string OrderDate { get; set; }

        public double PaymentAmount { get; set; }

        public string Currency { get; set; }
    }
}
