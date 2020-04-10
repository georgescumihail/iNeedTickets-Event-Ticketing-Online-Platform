using iNeedTickets.Scanner.API.Models;
using System;

namespace iNeedTickets.Scanner.API.Services
{
    public interface ITicketValidationService
    {
        TicketValidationResponseModel Check(Guid ticketCode);
    }
}
