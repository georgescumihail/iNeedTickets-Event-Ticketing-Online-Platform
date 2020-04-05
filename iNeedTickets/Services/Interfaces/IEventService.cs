using iNeedTickets.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public interface IEventService
    {
        bool AddEvent(AddEventData eventData);
        bool RemoveEvent(int id);
    }
}
