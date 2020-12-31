using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Model
{
    public class BookingDetailRequest
    {
        public string BookerId { get; set; }
        [Required]
        public string PickupLocation { get; set; }
        [Required]
        public string PickupTime { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string GuestName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}
