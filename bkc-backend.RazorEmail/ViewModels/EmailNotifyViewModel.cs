using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.RazorEmail.ViewModels
{
    public class LocationViewModel
    {
        public string Place { get; set; }
        public string Time { get; set; }
    }
    public class BookerViewModel
    {
        public string StartDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string Type { get; set; }
        public string BookerName { get; set; }
        public string BookerPhone { get; set; }
        public int TotalParticipant { get; set; }
    }
    public class DriverViewModel
    {
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string CarNumber { get; set; }
        public string Type { get; set; }
        public string NoteForDriver { get; set; }
        public List<LocationViewModel> Locations { get; set; }
    }

    public class EmailNotifyViewModel
    {
        public BookerViewModel Booker { get; set; }
        public List<DriverViewModel> Drivers { get; set; }

    }
}
