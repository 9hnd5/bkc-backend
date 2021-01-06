using System;
using System.Collections.Generic;
using System.Text;

namespace bkc_backend.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Department { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
