using AutoMapper;
using bkc_backend.Api.ViewModel.Request;
using bkc_backend.Data;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using bkc_backend.RazorEmail;

namespace bkc_backend.Api.Controllers
{
    public class TemModel
    {
        public string Name { get; set; }
    }
    public class TicketApprovalController : ControllerBase
    {
        public IMapper _mapper;
        public ITicketSerivces _ticketSerivces;
        public ITripServices _tripServices;
        public ITicketTripServices _ticketTripServices;
        public BookingCarDbContext _context;
        public ISendMailServices _sendMailServices;
        public IRazorViewToStringRenderer _razorViewToStringRenderer;
        public TicketApprovalController(IMapper mapper, ITicketSerivces ticketSerivces, ITripServices tripServices,
            ITicketTripServices ticketTripServices, BookingCarDbContext context,
            ISendMailServices sendMailServices, IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _mapper = mapper;
            _ticketSerivces = ticketSerivces;
            _tripServices = tripServices;
            _ticketTripServices = ticketTripServices;
            _context = context;
            _sendMailServices = sendMailServices;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        [Route("api/ticket-approval/ticket-trips")]
        [HttpPost]
        public IActionResult AddTicketTrip([FromBody] TicketTripListRequest ticketTripListRequest)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var ticketTripRequests = ticketTripListRequest.TicketTripRequests;
                    var trips = _context.Trips.Where(x => x.IsFinish == false).ToList();
                    foreach (var item in ticketTripRequests)
                    {
                        var ticket = _context.Tickets.FirstOrDefault(x => x.Id == item.Ticket.Id);
                        ticket.ApprovedDate = item.Ticket.ApprovedDate;
                        ticket.ApproverId = item.Ticket.ApproverId;
                        ticket.ApproverName = item.Ticket.ApproverName;
                        ticket.Status = item.Ticket.Status;
                        _context.SaveChanges();
                        var trip = trips.FirstOrDefault(x => x.CarId == item.Trip.CarId);
                        if (trip == null)
                        {
                            Trip newTrip = new Trip()
                            {
                                CarId = item.Trip.CarId,
                                DriverId = item.Trip.DriverId,
                                FromLocation = item.Trip.FromLocation,
                                ToLocation = item.Trip.ToLocation,
                                IsFinish = item.Trip.IsFinish,
                                NoteForDriver = item.Trip.NoteForDriver,
                                StartDate = item.Trip.StartDate,
                                Type = item.Trip.Type
                            };
                            _context.Trips.Add(newTrip);
                            _context.SaveChanges();
                            TicketTrip ticketTrip = new TicketTrip()
                            {
                                TicketId = ticket.Id,
                                TripId = newTrip.Id
                            };
                            _context.TicketTrips.Add(ticketTrip);
                            _context.SaveChanges();

                        }
                        else
                        {
                            TicketTrip ticketTrip = new TicketTrip()
                            {
                                TicketId = ticket.Id,
                                TripId = trip.Id
                            };
                            _context.TicketTrips.Add(ticketTrip);
                            _context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception error)
                {
                    transaction.Rollback();
                }
            }
            return Ok();
        }

        [Route("api/ticket-approval/tickets/{ticketId}/trip/{tripId}")]
        [HttpPut]
        public IActionResult UpdateTicket(int ticketId, int tripId, [FromBody]TripUpdateRequest tripUpdateRequest)
        {

            var ticketTripEntity = (from ticket in _context.Tickets
                               where ticket.Id == ticketId
                               join ticketTrip in _context.TicketTrips on ticket.Id equals ticketTrip.TicketId
                               where ticketTrip.TripId == tripId
                               join trip in _context.Trips on ticketTrip.TripId equals trip.Id
                               where trip.IsFinish == false
                               select ticketTrip).FirstOrDefault(); ;
            ticketTripEntity.TripId = tripId;
            _context.SaveChanges();

            var trips = _context.Trips.Where(x => x.Id == tripId && x.IsFinish == false).ToList();
            if(trips.Count == 0)
            {
                Trip newTrip = new Trip()
                {
                    IsFinish = tripUpdateRequest.IsFinish,
                    StartDate = tripUpdateRequest.StartDate,
                    FromLocation = tripUpdateRequest.FromLocation,
                    ToLocation = tripUpdateRequest.ToLocation,
                    NoteForDriver = tripUpdateRequest.NoteForDriver,
                    Type = tripUpdateRequest.Type,
                    CarId = tripUpdateRequest.CarId,
                    DriverId = tripUpdateRequest.DriverId,
                };
                _context.Trips.Add(newTrip);
            }
            return Ok();
        }


        [Route("api/ticket-approval/tickets")]
        [HttpPatch]
        public IActionResult UpdateReasonRejectTicket([FromBody] TicketUpdateRequest ticketUpdateRequest)
        {
            var ticketEntity = _context.Tickets.FirstOrDefault(x => x.Id == ticketUpdateRequest.Id);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    var ticketTrips = (from ticket in _context.Tickets
                                       where ticket.Id == ticketUpdateRequest.Id
                                       join ticketTrip in _context.TicketTrips on ticket.Id equals ticketTrip.TicketId
                                       join trip in _context.Trips on ticketTrip.TripId equals trip.Id
                                       where trip.IsFinish == false
                                       select ticketTrip).ToList();
                    foreach (var ticketTrip in ticketTrips)
                    {
                        _context.TicketTrips.Remove(ticketTrip);
                        _context.SaveChanges();
                    }
                    var a = (from ticketTrip in _context.TicketTrips
                             join trip in _context.Trips on ticketTrip.TripId equals trip.Id
                             where trip.IsFinish == false
                             select ticketTrip).ToList();
                    foreach (var ticketTrip in ticketTrips)
                    {
                        if (a.Any(x => x.TripId == ticketTrip.TripId))
                        {

                        }
                        else
                        {
                            var trip = _context.Trips.FirstOrDefault(x => x.Id == ticketTrip.TripId);
                            _context.Trips.Remove(trip);
                        }
                    }
                    ticketEntity.ReasonReject = ticketUpdateRequest.ReasonReject;
                    ticketEntity.Status = ticketUpdateRequest.Status;
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception error)
                {
                    transaction.Rollback();
                }
            }

            return Ok(ticketEntity);
        }

        [Route("api/ticket-approval/tickets/{ticketId}/trips")]
        [HttpGet]
        public IActionResult GetTripsByIsfinishAndDriverId(int ticketId)
        {
            var trips = (from ticket in _context.Tickets
                         where ticket.Id == ticketId
                         join ticketTrip in _context.TicketTrips on ticket.Id equals ticketTrip.TicketId
                         join trip in _context.Trips on ticketTrip.TripId equals trip.Id
                         where trip.IsFinish == false
                         select trip).ToList();
            return Ok(trips);
        }

        [Route("api/test-send-mail")]
        [HttpGet]
        public async Task<IActionResult> TestSendMail()
        {
            string body = string.Empty;
            //string path = Path.Combine(Environment.CurrentDirectory, "\\Project\\bkc-backend\\bkc-backend.Api\\Views\\EmailTemplate\\EmailNoti.cshtml");
            string path = "/Views/Share/EmailNotify.cshtml";
            //using (StreamReader reader = new StreamReader(path))
            //{
            //    body = reader.ReadToEnd();
            //}
            body = await _razorViewToStringRenderer.RenderViewToStringAsync(path, new TemModel());
            var mailContent = new MailContent();
            mailContent.To = "ng.d.huy95@gmail.com";
            mailContent.Subject = "Test Email";
            mailContent.Body = body;
            await _sendMailServices.SendMail(mailContent);
            return Ok();
        }
    }
}
