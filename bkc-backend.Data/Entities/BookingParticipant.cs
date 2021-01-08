using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class BookingParticipant
    {
        public int Id { get; set; }
        public int BookingPickupLocationId { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
