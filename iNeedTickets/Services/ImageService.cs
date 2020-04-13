using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public class ImageService : IImageService
    {
        public FileStream GetEventImage(string filename)
        {
            return File.OpenRead("../iNeedTickets/Images/Events/" + filename);
        }

        public FileStream GetTicketImage(string filename)
        {
            return File.OpenRead("../iNeedTickets/Images/Tickets/" + filename);
        }
    }
}
