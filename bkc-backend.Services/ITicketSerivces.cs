using bkc_backend.Data;
using bkc_backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface ITicketSerivces : IBaseServices<Ticket>
    {
        public bool AddTicket(Ticket ticket);
        public bool UpdateTicket(Ticket ticket);
        public List<Ticket> GetTicketsByEmployeeId(string employeeId);
        public bool RemoveTicketById(int ticketId);
        public List<Ticket> GetTicketsByBuId(string buId);
    }

    public class TicketServices : BaseServices<Ticket>, ITicketSerivces
    {
        public IRelatedPeopleServices _relatedPeopleServices;
        public ILocationServices _locationServices;
        public IParticipantServices _participantServices;
        public TicketServices(BookingCarDbContext context, IRelatedPeopleServices relatedPeopleServices,
            ILocationServices locationServices, IParticipantServices participantServices) : base(context)
        {
            _relatedPeopleServices = relatedPeopleServices;
            _locationServices = locationServices;
            _participantServices = participantServices;
        }

        public bool AddTicket(Ticket ticket)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var locations = ticket.Locations;
                    var relatedPeoples = ticket.RelatedPeoples;
                    Add(ticket);
                    _context.SaveChanges();
                    foreach (var relatedPeople in relatedPeoples)
                    {
                        relatedPeople.TicketId = ticket.Id;
                        _relatedPeopleServices.Add(relatedPeople);
                        _context.SaveChanges();
                    }
                    foreach (var location in locations)
                    {
                        location.TicketId = ticket.Id;
                        _locationServices.Add(location);
                        _context.SaveChanges();
                        foreach (var participant in location.Participants)
                        {
                            participant.LocationId = location.Id;
                            _participantServices.Add(participant);
                        }
                    }
                    _context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception error)
                {
                    transaction.Rollback();
                    Console.WriteLine(error);
                    return false;
                }
            }
        }

        public bool RemoveTicketById(int ticketId)
        {
            var ticket = GetById(ticketId);
            Remove(ticket);
            var locations = _locationServices.GetLocationsByTicketId(ticketId);
            foreach(var location in locations)
            {
                _locationServices.Remove(location);
                foreach(var participant in location.Participants)
                {
                    _participantServices.Remove(participant);
                }
            }
            var relatedPeoples = _relatedPeopleServices.GetRelatedPeoplesByTicketId(ticketId);
            _relatedPeopleServices.RemoveRange(relatedPeoples);
            _context.SaveChanges();
            return true;
        }

        public List<Ticket> GetTicketsByEmployeeId(string employeeId)
        {
            var tickets = _context.Tickets.Where(x => x.EmployeeId == employeeId).ToList();
            foreach (var ticket in tickets)
            {
                var relatedPeoples = _relatedPeopleServices.GetRelatedPeoplesByTicketId(ticket.Id);
                ticket.RelatedPeoples = relatedPeoples;
                var locations = _locationServices.GetLocationsByTicketId(ticket.Id);
                ticket.Locations = locations;
            }
            return tickets;
        }

        public bool UpdateTicket(Ticket ticket)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var ticketEntity = GetById(ticket.Id);
                    ticketEntity.StartDate = ticket.StartDate;
                    ticketEntity.EndDate = ticket.EndDate;
                    ticketEntity.FromLocation = ticket.FromLocation;
                    ticketEntity.ToLocation = ticket.ToLocation;
                    ticketEntity.TotalParticipant = ticket.TotalParticipant;
                    ticketEntity.ReasonBooking = ticket.ReasonBooking;
                    ticketEntity.Status = ticket.Status;


                    var locationsEntity = _locationServices.GetLocationsByTicketId(ticket.Id);
                    _locationServices.RemoveRange(locationsEntity);
                    foreach (var location in locationsEntity)
                    {
                        var participantsEntity = _participantServices.GetParticipantsByLocationId(location.Id);
                        _participantServices.RemoveRange(participantsEntity);
                    }
                    foreach (var location in ticket.Locations)
                    {
                        location.TicketId = ticket.Id;
                        _locationServices.Add(location);
                        _context.SaveChanges();
                        foreach(var participant in location.Participants)
                        {
                            participant.LocationId = location.Id;
                            _participantServices.Add(participant);
                        }
                    }
                    var relatedPeoplesEntity = _relatedPeopleServices.GetRelatedPeoplesByTicketId(ticket.Id);
                    _relatedPeopleServices.RemoveRange(relatedPeoplesEntity);
                    foreach(var relatedPeople in ticket.RelatedPeoples)
                    {
                        relatedPeople.TicketId = ticket.Id;
                        _relatedPeopleServices.Add(relatedPeople);
                    }
                    _context.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception error)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByBuId(string buId)
        {
            var tickets = _context.Tickets.Where(x => x.EmployeeBuId == buId && x.Status != "DRAFT").ToList();
            foreach(var ticket in tickets)
            {
                var relatedPeoples = _relatedPeopleServices.GetRelatedPeoplesByTicketId(ticket.Id);
                ticket.RelatedPeoples = relatedPeoples;
                var locations = _locationServices.GetLocationsByTicketId(ticket.Id);
                ticket.Locations = locations;
                foreach(var location in locations)
                {
                    var participants = _participantServices.GetParticipantsByLocationId(location.Id);
                    location.Participants = participants;
                }
            }
            return tickets;
        }
    }
}
