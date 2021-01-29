using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Request
{
    public class TicketTripRequest
    {
        public TripRequest Trip { get; set; }
        public TicketUpdateRequest Ticket { get; set; }
    }
}
