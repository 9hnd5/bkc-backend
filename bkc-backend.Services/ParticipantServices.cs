using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface IParticipantServices: IBaseServices<Participant>
    {
        public List<Participant> GetParticipantsByPickupLocationId(string pickupLocationId);
    }
    public class ParticipantServices: BaseServices<Participant>, IParticipantServices
    {
        public ParticipantServices(BookingCarDbContext context): base(context)
        {

        }

        public List<Participant> GetParticipantsByPickupLocationId(string pickupLocationId)
        {
            return _context.Participants.Where(x => x.PickupLocationId == pickupLocationId).ToList();
        }
    }
}
