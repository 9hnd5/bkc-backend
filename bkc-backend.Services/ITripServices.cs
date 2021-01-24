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
    }
    public class TripServices: BaseServices<Trip>, ITripServices
    {
        public TripServices(BookingCarDbContext context): base(context)
        {

        }
    }
}
