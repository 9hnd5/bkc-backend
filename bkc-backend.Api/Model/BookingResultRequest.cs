using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model
{
    public class BookingResultRequest
    {
        public string Status { get; set; }
        public string MovingTripId { get; set; }
        public string ReturningTripId { get; set; }
    }
}
