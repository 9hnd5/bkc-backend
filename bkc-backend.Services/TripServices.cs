using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data;
using bkc_backend.Data.Entities;

namespace bkc_backend.Services
{
    public interface ITripServices: IBaseServices<Trip>
    {

    }
    public class TripServices: BaseServices<Trip>, ITripServices
    {
        public TripServices(BkcDbContext context): base(context)
        {

        }
    }
}
