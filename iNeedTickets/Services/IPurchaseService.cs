using iNeedTickets.Models;

namespace iNeedTickets.Services
{
    public interface IPurchaseService
    {
        void RegisterPurchase(PurchaseModel purchaseData, string userRef);
    }
}
