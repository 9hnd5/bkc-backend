using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Response
{
    public class TicketResponse
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
    }
}
