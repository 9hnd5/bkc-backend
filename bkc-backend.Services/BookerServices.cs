using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Data;
using bkc_backend.Data.Entities;

namespace bkc_backend.Services
{
    public interface IBookerServices: IBaseServices<Booker>
    {
        public List<Booker> getBookersByBuId(string buId);
        //public List<Booker> getBookersByBuIdAndStatus(string buId, string status);
    }
    public class BookerServices: BaseServices<Booker>, IBookerServices
    {
        public BookerServices(BkcDbContext context): base(context)
        {

        }

        public List<Booker> getBookersByBuId(string buId)
        {
            var result = _context.Bookers.Where(b => b.BuId == buId).Select(b => b).ToList();
            return result;
        }

        //public List<Booker> getBookersByBuIdAndStatus(string buId, string status)
        //{
        //    var result = _context.Bookers.Where(b => b.BuId == buId && b.Status == status).Select(b => b).ToList();
        //    return result;
        //}
    }
}
