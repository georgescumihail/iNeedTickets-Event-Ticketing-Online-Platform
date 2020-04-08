using iNeedTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Repos
{
    public interface IAreaRepository
    {
        TicketArea GetFullAreaInfoById(int id);
    }
}
