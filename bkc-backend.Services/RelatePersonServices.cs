using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface IRelatePersonServices: IBaseServices<RelatePerson>
    {
        public List<RelatePerson> GetRelatePersonsByBookingInforId(string bookingInforId);
    }
    public class RelatePersonServices: BaseServices<RelatePerson>, IRelatePersonServices
    {
        public RelatePersonServices(BookingCarDbContext context): base(context)
        {

        }

        public List<RelatePerson> GetRelatePersonsByBookingInforId(string bookingInforId)
        {
            return _context.RelatePersons.Where(x => x.BookingInforId == bookingInforId).ToList();
        }
    }
}
