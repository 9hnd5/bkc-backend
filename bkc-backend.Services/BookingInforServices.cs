using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data;
using bkc_backend.Data.Entities;

namespace bkc_backend.Services
{
    public interface IBookingInforServices : IBaseServices<BookingInfor>
    {
        public BookingInfor getBkInforByBookerId(int bookerId);
    }
    public class BookingInforServices : BaseServices<BookingInfor>, IBookingInforServices
    {
        public BookingInforServices(BkcDbContext context) : base(context)
        {

        }

        public BookingInfor getBkInforByBookerId(int bookerId)
        {
            var result = _context.BookingInfors.Where(bki => bki.BookerId == bookerId).Select(bki => bki).FirstOrDefault();
            return result;
        }
    }
}
