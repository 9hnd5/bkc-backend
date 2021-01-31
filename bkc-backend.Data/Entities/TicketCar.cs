using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class TicketCar: BaseEntity
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public bool IsFinish { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string NoteForDriver { get; set; }

    }
}
