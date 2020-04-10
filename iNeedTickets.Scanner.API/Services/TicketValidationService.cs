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

            if (ticket != null)
            {
                if (ticket.IsActive)
                {
                    var response = new TicketValidationResponseModel
                    {
                        IsValid = true,
                        HasError = false,
                        ErrorMessage = "",
                        EventName = ticket.TicketArea.Event.Name,
                        AreaName = ticket.TicketArea.AreaName,
                        LocationName = ticket.TicketArea.Event.Location.Name,
                        EventDate = ticket.TicketArea.Event.Date
                    };

                    ticket.IsActive = false;
                    dbContext.SaveChanges();

                    return response;
                }
                else
                {
                    return new TicketValidationResponseModel
                    {
                        IsValid = false,
                        HasError = false,
                        ErrorMessage = "",
                        EventName = ticket.TicketArea.Event.Name,
                        AreaName = ticket.TicketArea.AreaName,
                        LocationName = ticket.TicketArea.Event.Location.Name,
                        EventDate = ticket.TicketArea.Event.Date
                    };
                }
            }
            else
            {
                return new TicketValidationResponseModel
                {
                    IsValid = false,
                    HasError = true,
                    ErrorMessage = "The ticket was not found",
                    EventName = "",
                    AreaName = "",
                    LocationName = "",
                    EventDate = null
                };
            }
        }
    }
}
