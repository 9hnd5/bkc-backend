using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Model
{
    public class BookingCarReqModel
    {
        [Required]
        [StringLength(50)]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string BuId { get; set; }
        [Required]
        [StringLength(50)]
        public string BuName { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }


        public string BookerId { get; set; }
        [Required]
        public string PickupTime { get; set; }
        [Required]
        public string ReturnTime { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string TotalPerson { get; set; }

        public List<BookingDetailRequest> BookingDetailRequests { get; set; }
    }
}
