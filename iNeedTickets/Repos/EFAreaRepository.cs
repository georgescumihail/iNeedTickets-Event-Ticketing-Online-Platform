using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace iNeedTickets.Repos
{
    public class EFAreaRepository : IAreaRepository
    {
        private ApplicationDbContext dbContext;

        public EFAreaRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public TicketArea GetFullAreaInfoById(int id)
        {
            return dbContext.TicketAreas
                .Include(t => t.Event)
                .ThenInclude(e => e.Location)
                .First(e => e.Id == id);
        }
    }
}
