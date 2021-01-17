using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class BookingResult: BaseEntity
    {
        public string BookingInforId { get; set; }
        public string MovingTripId { get; set; }
        public string ReturningTripId { get; set; }
        public string Status { get; set; }
        public BookingInfor BookingInfor { get; set; }
        public Trip Trip { get; set; }
    }
}
