using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class BookingPickupLocation
    {
        public int Id { get; set; }
        public int BookerId { get; set; }
        public string PickupLocation { get; set; }
        public string PickupTime { get; set; }
        public string GuestName { get; set; }
        public int Phone { get; set; }
        public string NoteByBooker { get; set; }
        public string NoteByAdmin { get; set; }

    }
}
