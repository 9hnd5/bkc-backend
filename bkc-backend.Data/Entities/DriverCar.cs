using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class DriverCar
    {
        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string DriverEmail { get; set; }

        public string CarId { get; set; }
        public string CarNumber { get; set; }
        public string CarTotalSeat { get; set; }
        public string CarAvailableSeat { get; set; }
        public string CarStatus { get; set; }
        public string CarBookingDate { get; set; }
        public string CarBuId { get; set; }
        public string CarBuName { get; set; }
    }
}
