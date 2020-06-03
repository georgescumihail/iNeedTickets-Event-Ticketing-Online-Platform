using iNeedTickets.Models;

namespace iNeedTickets.Services
{
    public interface IPurchaseService
    {
        PurchaseResponse RegisterPurchase(PurchaseModel purchaseData, User currentUser);
    }
}
