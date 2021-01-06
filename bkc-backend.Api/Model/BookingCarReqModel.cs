using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Model
{
    public class BookingCarReqModel
    {
     
        public int EmployeeId { get; set; }
      
        public string EmployeeName { get; set; }
        public int LineManagerId { get; set; }
        public string LineManagerName { get; set; }
      
        public int Phone { get; set; }
        
        public string BuId { get; set; }
        
        public string BuName { get; set; }
        
        public string Department { get; set; }
       
    


        public int BookerId { get; set; }
        public string PickupTime { get; set; }
        public string ReturnTime { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public int TotalPerson { get; set; }
        public List<string> MailToRelatingPersons { get; set; }

        public List<BookingPickupLocationModel> BookingPickupLocations { get; set; }
    }
}
