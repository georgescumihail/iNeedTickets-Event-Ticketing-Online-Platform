using iNeedTickets.Models;

namespace iNeedTickets.Services
{
    public class TransactionService : ITransactionService
    {
        public ApplicationDbContext dbContext;

        public TransactionService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Save(PaypalTransaction transaction)
        {
            dbContext.Transactions.Add(transaction);

            dbContext.SaveChanges();
        }
    }
}
