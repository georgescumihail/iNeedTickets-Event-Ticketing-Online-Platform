using iNeedTickets.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public interface ITicketImageService
    {
        void DrawImage(Ticket ticket, Bitmap qrCodeImage);
    }
}
