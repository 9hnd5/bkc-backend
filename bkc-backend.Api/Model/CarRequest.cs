using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model
{
    public class CarRequest
    {
        public string CarId { get; set; }
        public string BookerId { get; set; }
        public string BookingDate { get; set; }
    }
}
