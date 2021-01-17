using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Trip : BaseEntity
    {
        public string DriverId { get; set; }
        public string CarId { get; set; }
        public string MovingDate { get; set; }
        public string ReturningDate { get; set; }
        public string NoteByAdmin { get; set; }
        public bool Status { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
        public List<BookingResult> BookingResults { get; set; }

    }
}
