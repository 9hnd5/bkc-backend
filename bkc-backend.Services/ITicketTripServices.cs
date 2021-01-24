using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface ITicketTripServices: IBaseServices<TicketTrip>
    {
        public void AddTicketTrip(TicketTrip ticketTrip);
    }
    public class TicketTripServices: BaseServices<TicketTrip>, ITicketTripServices
    {
        public TicketTripServices(BookingCarDbContext context): base(context)
        {

        }

        public void AddTicketTrip(TicketTrip ticketTrip)
        {
            throw new NotImplementedException();
        }
    }
}
