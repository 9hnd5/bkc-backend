using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Booker
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Phone { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }

    }
}
