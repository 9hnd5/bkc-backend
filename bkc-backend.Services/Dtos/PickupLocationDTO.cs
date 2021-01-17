using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services.Dtos
{
    public class PickupLocationDTO
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Guest { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public List<ParticipantDTO> Participants { get; set; }
    }
}
