using System.Collections.Generic;

namespace iNeedTickets.Models
{
    public interface ITicketRepository
    {
        List<Ticket> GetTicketListByUser(string userRef);

        Ticket GetTicketById(int id);
    }
}
