using iNeedTickets.Models;
using System.Collections.Generic;

namespace iNeedTickets.Services
{
    public interface ILocationService
    {
        List<Location> GetAllLocations();

        Location GetLocationById(int id);
    }
}
