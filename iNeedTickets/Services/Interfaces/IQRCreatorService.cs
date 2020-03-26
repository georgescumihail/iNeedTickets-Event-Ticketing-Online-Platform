using iNeedTickets.Models;
using System.Drawing;

namespace iNeedTickets.Services
{
    public interface IQRCreatorService
    {
        Bitmap Generate(Ticket ticket);
    }
}
