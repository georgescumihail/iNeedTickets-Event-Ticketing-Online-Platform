using iNeedTickets.Models;
using iNeedTickets.Scanner.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Scanner.API.Services
{
    public class TicketValidationService : ITicketValidationService
    {
        private ApplicationDbContext dbContext;

        public TicketValidationService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public TicketValidationResponseModel Check(Guid ticketCode)
        {
            var ticket = dbContext.Tickets
                .Include(t => t.TicketArea)
                .ThenInclude(a => a.Event)
                .ThenInclude(e => e.Location)
                .FirstOrDefault(t => t.EncryptionCode == ticketCode);

            var response = BuildResponse(ticket);

            if (ticket.IsActive)
            {
                ticket.IsActive = false;
                dbContext.SaveChanges();
            }

            return response;
        }

        private TicketValidationResponseModel BuildResponse(Ticket ticket)
        {
            return new TicketValidationResponseModel
            {
                IsTicketValid = ticket?.IsActive ?? false,
                HasError = ticket == null,
                ErrorMessage = ticket == null ? "The ticket was not found" : "",
                EventName = ticket?.TicketArea?.Event?.Name ?? "",
                AreaName = ticket?.TicketArea?.AreaName ?? "",
                LocationName = ticket?.TicketArea?.Event?.Location?.Name ?? "",
                EventDate = ticket?.TicketArea?.Event?.Date ?? null
            };
        }
    }
}
