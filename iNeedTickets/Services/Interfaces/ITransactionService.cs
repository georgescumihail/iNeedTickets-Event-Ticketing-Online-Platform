using iNeedTickets.Models;

namespace iNeedTickets.Services
{
    public interface ITransactionService
    {
        void Save(PaypalTransaction transaction);
    }
}
