using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Request
{
    public class TripRequest
    {
        public int Id { get; set; }
        public bool IsFinish { get; set; }
        public string StartDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int DriverId { get; set; }
        public int CarId { get; set; }
        public string NoteForDriver { get; set; }
        public string Type { get; set; }
    }
}
