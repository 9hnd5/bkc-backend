using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public int BookerId { get; set; }
        public string BookerName { get; set; }
        public int CarId { get; set; }
        public string MoveTime { get; set; }
        public string ReturnTime { get; set; }
        public string MoveDate { get; set; }
        public string ReturnDate { get; set; }
        public string NoteByAdmin { get; set; }


    }
}
