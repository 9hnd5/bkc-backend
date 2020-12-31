using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data;
using bkc_backend.Data.Entities;

namespace bkc_backend.Services
{
    public interface IBookingDetailServices : IBaseServices<BookingDetail>
    {
        public List<BookingDetail> getBkDetailsByBookerId(string bookerId);
    }
    public class BookingDetailServices : BaseServices<BookingDetail>, IBookingDetailServices
    {
        public BookingDetailServices(BkcDbContext context) : base(context)
        {

        }

        public List<BookingDetail> getBkDetailsByBookerId(string bookerId)
        {
            var result = _context.BookingDetails.Where(bkd => bkd.BookerId == bookerId).Select(bkd => bkd).ToList();
            return result;
        }
    }
}
