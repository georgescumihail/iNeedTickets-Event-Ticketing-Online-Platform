using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iNeedTickets.Models;

namespace iNeedTickets.Services
{
    public class LocationService : ILocationService
    {
        private ApplicationDbContext dbContext;

        public LocationService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<Location> GetAllLocations()
        {
            return dbContext.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return dbContext.Locations.FirstOrDefault(l => l.Id == id);
        }
    }
}
