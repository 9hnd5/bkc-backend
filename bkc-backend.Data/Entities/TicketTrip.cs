using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class TicketTrip: BaseEntity
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
