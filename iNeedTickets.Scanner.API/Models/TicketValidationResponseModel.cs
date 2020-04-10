using iNeedTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Scanner.API.Models
{
    public class TicketValidationResponseModel
    {
        public bool IsValid { get; set; }

        public bool HasError { get; set; }

        public string ErrorMessage { get; set; }

        public string EventName { get; set; }

        public string AreaName { get; set; }

        public string LocationName { get; set; }

        public DateTime? EventDate { get; set; }
    }
}
