using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Models
{
    public class EFTicketRepository : ITicketRepository
    {
        private ApplicationDbContext dbContext;

        public EFTicketRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<Ticket> GetTicketListByUser(string userRef)
        {
            return dbContext.Tickets
                .Where(t => t.UserRef.Id == userRef)
                .Include(t => t.TicketClassRef)
                .ThenInclude(c => c.EventRef)
                .ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return dbContext.Tickets
                .Where(t => t.Id == id)
                .Include(t => t.TicketClassRef)
                .ThenInclude(c => c.EventRef)
                .ThenInclude(e => e.Location)
                .FirstOrDefault();
        }
    }
}
