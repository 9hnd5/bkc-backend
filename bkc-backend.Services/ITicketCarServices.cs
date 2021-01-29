using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface ITicketCarServices: IBaseServices<TicketCar>
    {
        public List<TicketCar> GetTicketCarsByTicketId(int ticketId);
    }
    public class TicketCarServices: BaseServices<TicketCar>, ITicketCarServices
    {
        public TicketCarServices(BookingCarDbContext context): base(context)
        {

        }

        public List<TicketCar> GetTicketCarsByTicketId(int ticketId)
        {
            return _context.TicketCars.Where(x => x.TicketId == ticketId).ToList();
        }
    }
}
