using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface ITripServices: IBaseServices<Trip>
    {
        public List<Trip> GetTripsByIsFinish(bool isFinish);
    }
    public class TripServices: BaseServices<Trip>, ITripServices
    {
        public TripServices(BookingCarDbContext context): base(context)
        {

        }

        public List<Trip> GetTripsByIsFinish(bool isFinish)
        {
            return _context.Trips.Where(x => x.IsFinish == isFinish).ToList();
        }
    }
}
