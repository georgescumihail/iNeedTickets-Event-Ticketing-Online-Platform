using iNeedTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public class PurchaseService : IPurchaseService
    {
        private ApplicationDbContext dbContext;

        public PurchaseService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void RegisterPurchase(PurchaseModel purchaseData, string userRef)
        {
            var ticketList = new List<Ticket>();

            var eventClass = dbContext.TicketTypes.First(e => e.Id == purchaseData.TicketTypeId);

            for (var i = 0; i < purchaseData.TicketsCount; i++)
            {
                ticketList.Add(new Ticket { TicketClassRef = eventClass, UserRef = userRef });
            }

            dbContext.Tickets.AddRange(ticketList);

            eventClass.TicketsRemaining -= purchaseData.TicketsCount;

            dbContext.SaveChanges();
        }
    }
}
