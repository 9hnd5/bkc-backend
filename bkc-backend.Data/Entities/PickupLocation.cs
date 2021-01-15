using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class PickupLocation: BaseEntity
    {
        public string BookingInforId { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Guest { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}
