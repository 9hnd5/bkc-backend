using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Response
{
    public class CarResponse
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int TotalSeat { get; set; }
        public int AvailableSeat { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public bool Status { get; set; }
        public string CurrentLocation { get; set; }
    }
}
