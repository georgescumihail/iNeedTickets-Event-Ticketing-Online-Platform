using iNeedTickets.Models;

namespace iNeedTickets.Services
{
    public interface IPurchaseService
    {
        bool RegisterPurchase(PurchaseModel purchaseData, User currentUser);
    }
}
