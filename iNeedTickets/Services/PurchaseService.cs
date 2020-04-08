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
        private IEmailService _emailService;

        public PurchaseService(ApplicationDbContext context, IQRCreatorService qrCreatorService,
                                ITicketImageService ticketImageService, IEmailService emailService)
        {
            dbContext = context;
            _qrCreatorService = qrCreatorService;
            _ticketImageService = ticketImageService;
            _emailService = emailService;
        }

        public bool RegisterPurchase(PurchaseModel purchaseData, User currentUser)
        {
            var ticketList = new List<Ticket>();

            var ticketArea = dbContext.TicketAreas
                .Include(t => t.Event)
                .ThenInclude(e => e.Location)
                .First(e => e.Id == purchaseData.TicketTypeId);

            if (ticketArea.TicketsRemaining >= purchaseData.TicketsCount)
            {
                for (var i = 0; i < purchaseData.TicketsCount; i++)
                {
                    var ticketGuid = Guid.NewGuid();

                    ticketList.Add(new Ticket {
                        TicketArea = ticketArea,
                        User = currentUser,
                        EncryptionPath = ticketGuid,
                        FileName = $"ticket-{ticketArea.Event.Name}-{ticketGuid}.jpg".Replace(" ", "-")
                    });
                }

                dbContext.Tickets.AddRange(ticketList);

                ticketArea.TicketsRemaining -= purchaseData.TicketsCount;

                dbContext.SaveChanges();

                var pathsList = new List<string>();

                foreach (var ticket in ticketList) {

                    var qrImage = _qrCreatorService.Generate(ticket);
                    _ticketImageService.DrawImage(ticket, qrImage);

                    pathsList.Add(ticket.FileName);
                }

                _emailService.SendEmail(currentUser, ticketArea, purchaseData, pathsList);

                return true;
            }

            return false;
        }
    }
}
