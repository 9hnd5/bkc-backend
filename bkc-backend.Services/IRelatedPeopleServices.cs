using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface IRelatedPeopleServices: IBaseServices<RelatedPeople>
    {
        public List<RelatedPeople> GetRelatedPeoplesByTicketId(int ticketId);
    }
    public class RelatedPeopleServices : BaseServices<RelatedPeople>, IRelatedPeopleServices
    {
        public RelatedPeopleServices(BookingCarDbContext context) : base(context)
        {

        }

        public List<RelatedPeople> GetRelatedPeoplesByTicketId(int ticketId)
        {
            return _context.RelatedPeoples.Where(x => x.TicketId == ticketId).ToList();
        }
    }
}
