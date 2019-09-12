using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Models
{
    public class Event
    {

        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string category { get; set; }
    }
}
