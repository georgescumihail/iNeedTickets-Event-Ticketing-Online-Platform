using Microsoft.ML.Data;

namespace iNeedTickets.ML.Models
{
    public class EventPurchaseModel
    {
        [LoadColumn(0)]
        public float EventId { get; set; }

        [LoadColumn(1)]
        public float CombinedEventId { get; set; }
    }
}
