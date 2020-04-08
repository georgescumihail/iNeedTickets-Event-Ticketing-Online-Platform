using iNeedTickets.Models;
using System.Collections.Generic;

namespace iNeedTickets.Repos
{
    public interface ITicketRepository
    {
        List<Ticket> GetTicketListByUser(string userRef);

        Ticket GetTicketById(int id);
    }
}
