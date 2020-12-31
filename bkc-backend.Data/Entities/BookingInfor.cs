using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class BookingInfor
    {
        public string Id { get; set; }
        public string BookerId { get; set; }
        public string PickupTime { get; set; }
        public string ReturnTime { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public string TotalPerson { get; set; }
    }
}
