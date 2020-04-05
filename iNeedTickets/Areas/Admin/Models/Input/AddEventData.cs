using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Areas.Admin.Models
{
    public class AddEventData
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public int Location { get; set; }

        public int Category { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public List<AddEventTicketArea> Areas { get; set; }
    }
}
