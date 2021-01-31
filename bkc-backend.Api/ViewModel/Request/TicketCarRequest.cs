using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.ViewModel.Request
{
    public class TicketCarRequest
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CarId { get; set; }
        public bool IsFinish { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string NoteForDriver { get; set; }
    }
}
