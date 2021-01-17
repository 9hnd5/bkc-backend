using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services.Dtos
{
    public class BookingResultDTO
    {
        public string Status { get; set; }
        public string MovingTripId { get; set; }
        public string ReturningTripId { get; set; }
    }
}
