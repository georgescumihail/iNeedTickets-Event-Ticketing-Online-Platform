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
        private IQRCreatorService _qrCreatorService;
        private ITicketImageService _ticketImageService;

        public PurchaseService(ApplicationDbContext context, IQRCreatorService qrCreatorService, ITicketImageService ticketImageService)
        {
            dbContext = context;
            _qrCreatorService = qrCreatorService;
            _ticketImageService = ticketImageService;
        }

        public bool RegisterPurchase(PurchaseModel purchaseData, User currentUser)
        {
            var ticketList = new List<Ticket>();

            var eventClass = dbContext.TicketTypes
                .Include(t => t.EventRef)
                .ThenInclude(e => e.Location)
                .First(e => e.Id == purchaseData.TicketTypeId);

            if (eventClass.TicketsRemaining >= purchaseData.TicketsCount)
            {
                for (var i = 0; i < purchaseData.TicketsCount; i++)
                {
                    var ticketGuid = Guid.NewGuid();

                    ticketList.Add(new Ticket {
                        TicketClassRef = eventClass,
                        UserRef = currentUser,
                        EncryptionPath = ticketGuid,
                        FileName = $"ticket-{eventClass.EventRef.Name}-{ticketGuid}.jpg".Replace(" ", "-")
                    });
                }

                dbContext.Tickets.AddRange(ticketList);

                eventClass.TicketsRemaining -= purchaseData.TicketsCount;

                dbContext.SaveChanges();

                foreach (var ticket in ticketList) {
                    var qrImage = _qrCreatorService.Generate(ticket);
                    _ticketImageService.DrawImage(ticket, qrImage);
                }

                return true;
            }

            return false;
        }
    }
}
