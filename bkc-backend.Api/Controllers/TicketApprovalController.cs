using AutoMapper;
using bkc_backend.Api.ViewModel.Request;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Controllers
{
    public class TicketApprovalController: ControllerBase
    {
        public IMapper _mapper;
        public ITicketSerivces _ticketSerivces;
        public ITripServices _tripServices;
        public ITicketTripServices _ticketTripServices;
        public TicketApprovalController(IMapper mapper, ITicketSerivces ticketSerivces, ITripServices tripServices,
            ITicketTripServices ticketTripServices)
        {
            _mapper = mapper;
            _ticketSerivces = ticketSerivces;
            _tripServices = tripServices;
            _ticketTripServices = ticketTripServices;
        }

        [Route("api/ticket-approval/tickets/")]
        [HttpPost]
        public IActionResult AddTicketTrip([FromBody] TicketTripRequest ticketTripRequest)
        {
            var ticket = _mapper.Map<Ticket>(ticketTripRequest.Ticket);
            _ticketSerivces.UpdateTicket(ticket);

            var trips = _mapper.Map<List<Trip>>(ticketTripRequest.Trips);
            var tripEntities = _tripServices.GetAll();
            foreach(var trip in trips)
            {
                if(tripEntities.Any(x => x.CarId == trip.CarId))
                {
                    var tripEntity = tripEntities.Find(x => x.CarId == trip.CarId);
                    TicketTrip ticketTrip = new TicketTrip()
                    {
                        TripId = tripEntity.Id,
                        TicketId = ticket.Id
                    };
                    _ticketTripServices.Add(ticketTrip);
                    ticket.TicketTripId = ticketTrip.Id;
                }
                else
                {
                    _tripServices.Add(trip);
                    var tripId = trip.Id;
                    var ticketId = ticket.Id;
                    TicketTrip ticketTrip = new TicketTrip()
                    {
                        TicketId = ticketId,
                        TripId = tripId
                    };
                    _ticketTripServices.Add(ticketTrip);
                    ticket.TicketTripId = ticketTrip.Id;
                    
                }
                
            }

            return Ok();
        }
    }
}
