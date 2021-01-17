using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface IPickupLocationServices: IBaseServices<PickupLocation>
    {
        public List<PickupLocation> GetPickupLocationsByBookingInforId(string bookingInforId);
    }
    public class PickupLocationServices: BaseServices<PickupLocation>, IPickupLocationServices
    {
        public PickupLocationServices(BookingCarDbContext context) : base(context)
        {

        }

        public List<PickupLocation> GetPickupLocationsByBookingInforId(string bookingInforId)
        {
            return _context.PickupLocations.Where(x => x.BookingInforId == bookingInforId).ToList();
        }
    }
}
