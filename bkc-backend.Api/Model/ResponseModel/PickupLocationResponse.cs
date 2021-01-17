﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model.ResponseModel
{
    public class PickupLocationResponse
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Guest { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public List<ParticipantResponse> Participants { get; set; }
    }
}
