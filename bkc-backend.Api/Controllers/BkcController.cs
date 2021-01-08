using bkc_backend.Api.Model;
using bkc_backend.Controller.Model;
using bkc_backend.Data;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
using bkc_backend.Services.EmployeeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Controllers
{
    public class BkcController : ControllerBase
    {
        public BkcDbContext _context;

        public IDriverCarServices _driverCarServices;
        public IBookerServices _bookerServices;
        public IBookingInforServices _bookingInforServices;
        public IBookingDetailServices _bookingDetailServices;
        public ICarServices _carServices;
        public IEmployeeServices _employeeServices;
        public ITripServices _tripservices;
        public BkcController(BkcDbContext context, IBookerServices bookerServices
            , IDriverCarServices driverCarServices, IBookingInforServices bookingInforServices,
            IBookingDetailServices bookingDetailServices,
            ICarServices carServices, IEmployeeServices employeeServices,
            ITripServices tripServices)
        {
            _context = context;
            _driverCarServices = driverCarServices;
            _bookerServices = bookerServices;
            _bookingInforServices = bookingInforServices;
            _bookingDetailServices = bookingDetailServices;
            _carServices = carServices;
            _employeeServices = employeeServices;
            _tripservices = tripServices;
        }
        [Route("api/bkc/bookers")]
        [HttpPost]
        public IActionResult SaveBookingCarRequest([FromBody] BookingCarReqModel request)
        {
            if (!ModelState.IsValid) return BadRequest("Sai Dinh Dang");
            Random rnd = new Random();
            int bookerId = rnd.Next(100);
            int bookingInforId = rnd.Next(200);
            Booker booker = new Booker()
            {
                Id = bookerId,
                EmployeeName = request.EmployeeName,
                EmployeeId = request.EmployeeId,
                Phone = request.Phone,
                BuId = request.BuId,
                BuName = request.BuName,
                Department = request.Department,
            };
            BookingInfor bookingInfor = new BookingInfor()
            {
                Id = bookingInforId,
                BookerId = bookerId,
                Destination = request.Destination,
                Location = request.Location,
                MoveDate = request.PickupTime,
                ReturnDate = request.ReturnTime,
                TotalPerson = request.TotalPerson
            };
            foreach (var item in request.BookingPickupLocations)
            {
                int id = rnd.Next(300);
                BookingPickupLocation bookingDetail = new BookingPickupLocation()
                {
                    Id = id,
                    BookerId = bookerId,
                    GuestName = item.GuestName,
                    NoteByBooker = item.NoteByBooker,
                    Phone = item.Phone,
                    PickupLocation = item.PickupLocation,
                    PickupTime = item.PickupTime
                };
                _bookingDetailServices.insert(bookingDetail);

            }
            _bookerServices.insert(booker);
            _bookingInforServices.insert(bookingInfor);
            _context.SaveChanges();
            return Ok("Success");
        }
        
        [Route("api/bkc/reject")]
        [HttpPost]
        public IActionResult SaveDeclineBookingCarRequest([FromBody] RejectBkcModel request)
        {
            if (!ModelState.IsValid) return BadRequest("Xin nhập lý do từ chối");
            var booker = _bookerServices.getById(request.BookerId);
            _context.SaveChanges();
            return Ok("Từ Chối Thành Công");
        }
        
        
        
        
        [Route("api/bkc/{buID}")]
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetBkcRequest(string buId)
        {
            //var inforDetails = _inforDetailServices.getAllByBuId(buId);
            ////var user = User.Claims.Where(c => c.Type == "name").FirstOrDefault()?.Value;
            //return new OkObjectResult(new { inforDetails });
            List<Booker> bookers = _bookerServices.getBookersByBuId(buId);
            if(bookers == null)
            {
                return BadRequest("Booker not exist");
            }
            List<BookerBkInforBkDetail> bookerBkInforBkDetails = new List<BookerBkInforBkDetail>();
            foreach (var booker in bookers)
            {
                BookingInfor bookingInfor = _bookingInforServices.getBkInforByBookerId(booker.Id);
                List<BookingPickupLocation> bookingDetails = _bookingDetailServices.getBkDetailsByBookerId(booker.Id);
                if(bookingDetails == null)
                {
                    return BadRequest("Not have booking detail with current booker");
                }
                bookerBkInforBkDetails.Add(new BookerBkInforBkDetail() { booker = booker, bookingInfor = bookingInfor, bookingDetails = bookingDetails });
            }
            return Ok(bookerBkInforBkDetails);
        }
        [Route("/api/bkc/drivercar/{buId}")]
        [HttpGet]
        public IActionResult GetBkcDriverCarRequest(string buId)
        {
            var driverCars = _driverCarServices.getByBuId(buId);
            return new OkObjectResult(new { driverCars });
        }
        [Route("/api/bkc/approve")]
        [HttpPost]
        public IActionResult approveBkc([FromBody] CarRequest carReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Sai Định Dạng");
            }
            Car car = _carServices.getById(carReq.CarId);
            Booker booker = _bookerServices.getById(carReq.BookerId);
            BookingInfor bookingInfor = _bookingInforServices.getBkInforByBookerId(carReq.BookerId);
            var availableSeat = Convert.ToInt32(car.AvailableSeat) - Convert.ToInt32(bookingInfor.TotalPerson);
            car.Status = "Booked";
            car.AvailableSeat = availableSeat;

            int tripId = new Random().Next(400);
            Trip trip = new Trip()
            {
                Id = tripId,
                CarId = carReq.CarId,
                DriverId = carReq.DriverId,
                DriverName = carReq.DriverName,
                MoveDate = carReq.MoveDate,
                ReturnDate = carReq.ReturnDate,
                NoteByAdmin = carReq.NoteByAdmin,
                BookerId=carReq.BookerId,
                BookerName = carReq.BookerName
            };
            _tripservices.insert(trip);
            _context.SaveChanges();
            return Ok("Duyệt Yêu Cầu Thành Công");
        }
        [Route("/api/bkc/search/{key}")]
        [HttpGet]
        public IActionResult getEmployeeByFilterKeyEmail(string key)
        {
            var employees = _employeeServices.GetEmployeeByFilterKeyEmail(key);
            if (employees == null) return BadRequest("Khong Tim Duoc Employee voi email: " + key);
            return Ok(employees);
        }
        [Route("/api/bkc/search-by-employee-name/{employeeName}")]
        [HttpGet]
        public IActionResult getEmployeeByName(string employeeName)
        {
            var employees = _employeeServices.getEmployeeByName(employeeName);
            
            return Ok(employees);
        }
    }

}
