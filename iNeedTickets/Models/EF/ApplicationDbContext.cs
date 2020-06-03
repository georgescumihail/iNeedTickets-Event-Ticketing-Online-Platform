using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iNeedTickets.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<TicketArea> TicketAreas { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<PaypalTransaction> Transactions { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
