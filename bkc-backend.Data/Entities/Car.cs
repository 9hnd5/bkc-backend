using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Car: BaseEntity
    {
        public string DriverId { get; set; }
        public string Number { get; set; }
        public int TotalSeat { get; set; }
        public int AvailableSeat { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public bool Status { get; set; }
    }
}
