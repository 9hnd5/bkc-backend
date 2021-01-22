using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Location: BaseEntity
    {
        public string Place { get; set; }
        public string Time { get; set; }
        public string GuestName { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
