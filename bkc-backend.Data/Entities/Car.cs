using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class Car
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string TotalSeat { get; set; }
        public string AvailableSeat { get; set; }
        public string Status { get; set; }
        public string BookingDate { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public string BookerId { get; set; }
        public string DriverId { get; set; }
    }
}
