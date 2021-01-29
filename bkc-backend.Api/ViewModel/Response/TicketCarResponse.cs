using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Response
{
    public class TicketCarResponse
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CarId { get; set; }
    }
}
