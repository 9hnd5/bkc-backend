using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class BookingInfor
    {
        public int Id { get; set; }
        public int BookerId { get; set; }
        public string MoveDate { get; set; }
        public string ReturnDate { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public int TotalPerson { get; set; }
        public string ReasonBooking { get; set; }
    }
}
