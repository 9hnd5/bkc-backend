using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Driver: BaseEntity
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeBuId { get; set; }
        public string EmployeeBuName { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
