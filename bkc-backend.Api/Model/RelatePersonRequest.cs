using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model
{
    public class RelatePersonRequest
    {
        public string EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
    }
}
