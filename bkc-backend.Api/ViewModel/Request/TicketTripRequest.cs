﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Request
{
    public class TicketTripRequest
    {
        public List<TripRequest> Trips { get; set; }
        public TicketUpdateRequest Ticket { get; set; }
    }
}
