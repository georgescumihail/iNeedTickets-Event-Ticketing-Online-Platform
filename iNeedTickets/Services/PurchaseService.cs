using iNeedTickets.Models;
using iNeedTickets.Repos;
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
        private ITicketImageService _ticketImageService;
        private IEmailService _emailService;
        private IAreaRepository _areaRepository;

        public PurchaseService(ApplicationDbContext context, ITicketImageService ticketImageService,
                            IEmailService emailService, IAreaRepository areaRepository)
        {
            dbContext = context;
            _ticketImageService = ticketImageService;
            _emailService = emailService;
            _areaRepository = areaRepository;
        }

        public bool RegisterPurchase(PurchaseModel purchaseData, User currentUser)
        {
            var ticketArea = _areaRepository.GetFullAreaInfoById(purchaseData.TicketTypeId);

            if (ticketArea != null && ticketArea.TicketsRemaining >= purchaseData.TicketsCount)
            {
                var ticketList = new List<Ticket>();

                for (var i = 0; i < purchaseData.TicketsCount; i++)
                {
                    ticketList.Add(BuildTicket(ticketArea, currentUser));
                    ticketArea.TicketsRemaining--;
                }

                dbContext.Tickets.AddRange(ticketList);
                dbContext.SaveChanges();

                var paths = GenerateTickets(ticketList);
                _emailService.SendEmail(currentUser, ticketArea, purchaseData, paths);

                return true;
            }

            return false;
        }

        private Ticket BuildTicket(TicketArea area, User user)
        {
            var ticketGuid = Guid.NewGuid();
            int? seatNr;

            if (area.Event.IsSeated)
            {
                seatNr = area.TicketsCapacity - area.TicketsRemaining + 1;
            }
            else
            {
                seatNr = null;
            }

            return new Ticket
            {
                TicketArea = area,
                User = user,
                EncryptionCode = ticketGuid,
                FileName = $"ticket-{area.Event.Name}-{ticketGuid}.jpg".Replace(" ", "-"),
                IsActive = true,
                SeatNumber =  seatNr,
                PurchaseDate = DateTime.Now
            };
        }

        private List<string> GenerateTickets(List<Ticket> ticketList)
        {
            var pathsList = new List<string>();

            foreach (var ticket in ticketList)
            {
                _ticketImageService.DrawImage(ticket);

                pathsList.Add(ticket.FileName);
            }

            return pathsList;
        }
    }
}
