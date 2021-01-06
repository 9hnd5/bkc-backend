using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int TotalSeat { get; set; }
        public int AvailableSeat { get; set; }
        public string Status { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public int DriverId { get; set; }
    }
}
