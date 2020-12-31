using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class UserRole
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string EmployeeId { get; set; }
        public string BusinessUnitId { get; set; }
    }
}
