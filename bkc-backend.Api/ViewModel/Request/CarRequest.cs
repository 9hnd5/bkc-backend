using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Request
{
    public class CarRequest
    {
        public int Id { get; set; }
        public string Manufactured { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int TotalSeat { get; set; }
        public int AvalableSeat { get; set; }
        public string BuId { get; set; }
        public string BuName { get; set; }
        public string Status { get; set; }
        public bool IsBooked { get; set; }
        public string CurrentLocation { get; set; }
    }
}
