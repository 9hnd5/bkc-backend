using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model
{
    public class TripModel
    {
        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public string CarId { get; set; }
        public string MoveDate { get; set; }
        public string MoveTime { get; set; }
        public string ReturnDate { get; set; }
        public string ReturnTime { get; set; }
        public string NoteByAdmin { get; set; }
    }
}
