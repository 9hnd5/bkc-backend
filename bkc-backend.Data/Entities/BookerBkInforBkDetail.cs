using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class BookerBkInforBkDetail
    {
        public Booker booker { get; set; }
        public BookingInfor bookingInfor { get; set; }
        public List<BookingPickupLocation> bookingDetails { get; set; }
    }
}
