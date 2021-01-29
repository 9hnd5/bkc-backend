using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Ticket: BaseEntity
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLineManagerId { get; set; }
        public string EmployeeLineManagerName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeBuId { get; set; }
        public string EmployeeBuName { get; set; }
        public string EmployeeDepartment { get; set; }
        public string CreateDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int TotalParticipant { get; set; }
        public string ReasonBooking { get; set; }
        public string HandlerName { get; set; }
        public string HandlerId { get; set; }
        public string HandledDate { get; set; }
        public string ReasonReject { get; set; }
        public string Status { get; set; }
        public bool IsFinish { get; set; }


        public List<TicketCar> TicketCars { get; set; }
        public List<Location> Locations { get; set; }
        public List<RelatedPeople> RelatedPeoples { get; set; }

    }
}
