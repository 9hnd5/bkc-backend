using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model
{
    public class BookingInforRequest
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLineManagerId { get; set; }
        public string EmployeeLineManagerName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeBuId { get; set; }
        public string EmployeeBuName { get; set; }
        public string EmployeeDepartment { get; set; }
        public string MovingDate { get; set; }
        public string ReturningDate { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public int TotalPerson { get; set; }
        public string ReasonBooking { get; set; }
        public BookingResultRequest BookingResult { get; set; }
        public List<PickupLocationRequest> PickupLocations { get; set; }
        public List<RelatePersonRequest> RelatePersons { get; set; }
    }
}
