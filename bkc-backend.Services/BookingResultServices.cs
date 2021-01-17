using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface IBookingResultServices: IBaseServices<BookingResult>
    {
        public BookingResult GetBookingResultByBookingInforId(string bookingInforId);
    }
    public class BookingResultServices: BaseServices<BookingResult>, IBookingResultServices
    {
        public BookingResultServices(BookingCarDbContext context) : base(context)
        {

        }

        public BookingResult GetBookingResultByBookingInforId(string bookingInforId)
        {
            return _context.BookingResults.Where(x => x.BookingInforId == bookingInforId).FirstOrDefault();
        }
    }
}
