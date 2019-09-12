using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Models
{
    public interface IEventRepository
    {
        IQueryable<Event> events { get; }
    }
}
