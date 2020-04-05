using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Areas.Admin.Models
{
    public class AddEventTicketArea
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Capacity { get; set; }
    }
}
