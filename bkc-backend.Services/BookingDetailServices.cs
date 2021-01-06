using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data;
using bkc_backend.Data.Entities;

namespace bkc_backend.Services
{
    public interface IBookingDetailServices : IBaseServices<BookingPickupLocation>
    {
        public List<BookingPickupLocation> getBkDetailsByBookerId(int bookerId);
    }
    public class BookingDetailServices : BaseServices<BookingPickupLocation>, IBookingDetailServices
    {
        public BookingDetailServices(BkcDbContext context) : base(context)
        {

        }

        public List<BookingPickupLocation> getBkDetailsByBookerId(int bookerId)
        {
            var result = _context.BookingPickupLocations.Where(bkd => bkd.BookerId == bookerId).Select(bkd => bkd).ToList();
            return result;
        }
    }
}
