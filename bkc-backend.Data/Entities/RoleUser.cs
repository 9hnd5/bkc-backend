using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class RoleUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public string BuId { get; set; }
    }
}
