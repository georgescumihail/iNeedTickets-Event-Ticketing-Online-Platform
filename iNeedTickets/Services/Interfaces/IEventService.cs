using iNeedTickets.Areas.Admin.Models;

namespace iNeedTickets.Services
{
    public interface IEventService
    {
        bool AddEvent(AddEventData eventData);

        bool EditEvent(EditEventData editData);

        bool RemoveEvent(int id);
    }
}
