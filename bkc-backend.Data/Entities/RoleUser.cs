using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class RoleUser: BaseEntity
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeBuId { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
