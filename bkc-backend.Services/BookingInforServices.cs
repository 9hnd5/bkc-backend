using AutoMapper;
using bkc_backend.Data;
using bkc_backend.Data.Entities;
using bkc_backend.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services
{
    public interface IBookingInforServices : IBaseServices<BookingInfor>
    {
        public bool AddBookingInfor(BookingInforDTO bookingInfor);
        public List<BookingInforDTO> GetBookingInforsByEmployeeId(string employeeId);
        public BookingInforDTO GetBookingInforById(string id);
        public bool UpdateBookingInfor(BookingInforDTO bookingInforDTO);
    }
    public class BookingInforServices : BaseServices<BookingInfor>, IBookingInforServices
    {
        public IMapper _mapper;
        public IBookingResultServices _bookingResultServices;
        public IPickupLocationServices _pickupLocationServices;
        public IRelatePersonServices _relatePersonServices;
        public IParticipantServices _participantServices;

        public BookingInforServices(BookingCarDbContext context, IMapper mapper, IBookingResultServices bookingResultServices,
            IPickupLocationServices pickupLocationServices, IRelatePersonServices relatePersonServices,
            IParticipantServices participantServices) : base(context)
        {
            _mapper = mapper;
            _bookingResultServices = bookingResultServices;
            _pickupLocationServices = pickupLocationServices;
            _relatePersonServices = relatePersonServices;
            _participantServices = participantServices;
        }
        public bool AddBookingInfor(BookingInforDTO bookingInforDTO)
        {
            var bookingInfor = _mapper.Map<BookingInfor>(bookingInforDTO);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Add(bookingInfor);
                    var bookingInforId = bookingInfor.Id;
                    bookingInfor.BookingResult.BookingInforId = bookingInforId;
                    _bookingResultServices.Add(bookingInfor.BookingResult);
                    foreach (var relatePerson in bookingInfor.RelatePersons)
                    {
                        relatePerson.BookingInforId = bookingInforId;
                    }
                    _relatePersonServices.AddRange(bookingInfor.RelatePersons);
                    foreach (var pickupLocation in bookingInfor.PickupLocations)
                    {
                        pickupLocation.BookingInforId = bookingInforId;
                        _pickupLocationServices.Add(pickupLocation);
                        foreach (var participant in pickupLocation.Participants)
                        {
                            participant.PickupLocationId = pickupLocation.Id;
                            _participantServices.Add(participant);
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error create " + error);
                    transaction.Rollback();
                    return false;
                }
            }

        }

        public List<BookingInforDTO> GetBookingInforsByEmployeeId(string employeeId)
        {
            var bookingInfors = _context.BookingInfors.Where(x => x.EmployeeId == employeeId).ToList();
            foreach (var bookingInfor in bookingInfors)
            {
                bookingInfor.BookingResult = _bookingResultServices.GetBookingResultByBookingInforId(bookingInfor.Id);
                bookingInfor.RelatePersons = _relatePersonServices.GetRelatePersonsByBookingInforId(bookingInfor.Id);
                bookingInfor.PickupLocations = _pickupLocationServices.GetPickupLocationsByBookingInforId(bookingInfor.Id);
                foreach (var pickupLocation in bookingInfor.PickupLocations)
                {
                    pickupLocation.Participants = _participantServices.GetParticipantsByPickupLocationId(pickupLocation.Id);
                }
            }
            var bookingInforsDTO = _mapper.Map<BookingInforDTO[]>(bookingInfors).ToList();
            return bookingInforsDTO;
        }
        public BookingInforDTO GetBookingInforById(string id)
        {
            var bookingInfor = _context.BookingInfors.Where(x => x.Id == id).FirstOrDefault();
            if (bookingInfor == null) return null;
            bookingInfor.BookingResult = _bookingResultServices.GetBookingResultByBookingInforId(bookingInfor.Id);
            bookingInfor.RelatePersons = _relatePersonServices.GetRelatePersonsByBookingInforId(bookingInfor.Id);
            bookingInfor.PickupLocations = _pickupLocationServices.GetPickupLocationsByBookingInforId(bookingInfor.Id);
            foreach (var pickupLocation in bookingInfor.PickupLocations)
            {
                pickupLocation.Participants = _participantServices.GetParticipantsByPickupLocationId(pickupLocation.Id);
            }
            var bookingInforDTO = _mapper.Map<BookingInforDTO>(bookingInfor);
            return bookingInforDTO;
        }
        public bool UpdateBookingInfor(BookingInforDTO bookingInforDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var bookingInfor = GetById(bookingInforDTO.Id);
                    _mapper.Map<BookingInforDTO, BookingInfor>(bookingInforDTO, bookingInfor);
                    _context.SaveChanges();

                    var bookingResult = _bookingResultServices.GetBookingResultByBookingInforId(bookingInforDTO.Id);
                    _mapper.Map<BookingResultDTO, BookingResult>(bookingInforDTO.BookingResult, bookingResult);
                    _context.SaveChanges();

                    var pickupLocations = _pickupLocationServices.GetPickupLocationsByBookingInforId(bookingInforDTO.Id);
                    _pickupLocationServices.RemoveRange(pickupLocations);
                    _context.SaveChanges();
                    foreach(var pickupLocation in pickupLocations)
                    {
                        var participants = _participantServices.GetParticipantsByPickupLocationId(pickupLocation.Id);
                        _participantServices.RemoveRange(participants);
                    }
                    foreach(var pickupLocationDTO in bookingInfor.PickupLocations)
                    {
                        var pickupLocation = _mapper.Map<PickupLocation>(pickupLocationDTO);
                        pickupLocation.BookingInforId = bookingInforDTO.Id;
                        _pickupLocationServices.Add(pickupLocation);
                        _context.SaveChanges();
                        foreach(var participantDTO in pickupLocationDTO.Participants)
                        {
                            var participant = _mapper.Map<Participant>(participantDTO);
                            participant.PickupLocationId = pickupLocation.Id;
                            _participantServices.Add(participant);
                            _context.SaveChanges();
                        }
                    }
                    
                    var relatePersons = _relatePersonServices.GetRelatePersonsByBookingInforId(bookingInforDTO.Id);
                    _relatePersonServices.RemoveRange(relatePersons);
                    _context.SaveChanges();
                    foreach(var relatePersonDTO in bookingInforDTO.RelatePersons)
                    {
                        var relatePerson = _mapper.Map<RelatePerson>(relatePersonDTO);
                        relatePerson.BookingInforId = bookingInforDTO.Id;
                        _relatePersonServices.Add(relatePerson);
                    }
                    _context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error when update booking infor" + error);
                    transaction.Rollback();
                    return false;
                }


            }

        }

    }
}
