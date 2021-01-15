using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class RoleUser: BaseEntity
    {
        //public string Id { get; set; }
        public string RoleId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeBuId { get; set; }
    }
}
