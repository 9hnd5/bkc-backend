using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Model
{
    public class BookingPickupLocationModel
    {
        public int BookerId { get; set; }
        public string PickupLocation { get; set; }
        public string PickupTime { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string GuestName { get; set; }
        public int Phone { get; set; }
        public string NoteByBooker { get; set; }
        public string NoteByAdmin { get; set; }
    }
}
