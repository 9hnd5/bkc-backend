using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class BookingDetail
    {
        public string Id { get; set; }
        public string BookerId { get; set; }
        public string PickupLocation { get; set; }
        public string PickupTime { get; set; }
        public string EmployeeName { get; set; }
        public string GuestName { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }

    }
}
