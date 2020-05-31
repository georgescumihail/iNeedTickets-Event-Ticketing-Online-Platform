using iNeedTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public interface IEmailService
    {
        void SendRecoveryEmail(User user, string token, string url);

        void SendEmail(User user, TicketArea area, PurchaseModel purchaseData, List<string> files);
    }
}
