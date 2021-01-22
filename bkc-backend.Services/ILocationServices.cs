using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface ILocationServices: IBaseServices<Location>
    {
        public List<Location> GetLocationsByTicketId(int ticketId);
    }
    public class LocationServices: BaseServices<Location>, ILocationServices
    {
        public IParticipantServices _participantServices;
        public LocationServices(BookingCarDbContext context, IParticipantServices participantServices) :base(context)
        {
            _participantServices = participantServices;
        }

        public List<Location> GetLocationsByTicketId(int ticketId)
        {
            var locations = _context.Locations.Where(x => x.TicketId == ticketId).ToList();
            foreach(var location in locations)
            {
                var participants = _participantServices.GetParticipantsByLocationId(location.Id);
                location.Participants = participants;
            }
            return locations;
        }
    }
}
