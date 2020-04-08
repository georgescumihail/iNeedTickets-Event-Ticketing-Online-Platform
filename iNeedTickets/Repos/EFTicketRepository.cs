using iNeedTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Repos
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
                .Where(t => t.User.Id == userRef)
                .Include(t => t.TicketArea)
                .ThenInclude(c => c.Event)
                .ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return dbContext.Tickets
                .Where(t => t.Id == id)
                .Include(t => t.TicketArea)
                .ThenInclude(c => c.Event)
                .ThenInclude(e => e.Location)
                .FirstOrDefault();
        }
    }
}
