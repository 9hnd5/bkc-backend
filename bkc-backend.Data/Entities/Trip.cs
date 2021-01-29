using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Trip : BaseEntity
    {
        public bool IsFinish { get; set; }
        public string StartDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string NoteForDriver { get; set; }
        public string Type { get; set; }

        public List<TicketTrip> TicketTrips { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

    }
}
