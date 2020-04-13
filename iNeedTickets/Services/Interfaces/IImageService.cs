using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public interface IImageService
    {
        FileStream GetEventImage(string filename);

        FileStream GetTicketImage(string filename);
    }
}
