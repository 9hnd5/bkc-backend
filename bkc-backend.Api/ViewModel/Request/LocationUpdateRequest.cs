using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Request
{
    public class LocationUpdateRequest
    {
        public string Place { get; set; }
        public string Time { get; set; }
        public string GuestName { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public List<ParticipantUpdateRequest> participants { get; set; }
    }
}
