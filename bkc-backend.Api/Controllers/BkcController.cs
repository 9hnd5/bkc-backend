using bkc_backend.Api.Model;
using bkc_backend.Controller.Model;
using bkc_backend.Data;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
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
        public BkcController(BkcDbContext context, IBookerServices bookerServices
            , IDriverCarServices driverCarServices, IBookingInforServices bookingInforServices,
            IBookingDetailServices bookingDetailServices,
            ICarServices carServices)
        {
            _context = context;
            _driverCarServices = driverCarServices;
            _bookerServices = bookerServices;
            _bookingInforServices = bookingInforServices;
            _bookingDetailServices = bookingDetailServices;
            _carServices = carServices;
        }
        [Route("api/bkc/approve")]
        [HttpPost]
        public IActionResult SaveBookingCarRequest([FromBody] BookingCarReqModel request)
        {
            if (!ModelState.IsValid) return BadRequest("Nhap Thong Tin Sai");
            Guid bookerId = Guid.NewGuid();
            Guid bookingInforId = Guid.NewGuid();
            Booker booker = new Booker()
            {
                Id = bookerId.ToString(),
                EmployeeName = request.EmployeeName,
                EmployeeId = request.EmployeeId,
                Phone = request.Phone,
                BuId = request.BuId,
                BuName = request.BuName,
                Department = request.Department,
                Status = request.Status
            };
            BookingInfor bookingInfor = new BookingInfor()
            {
                Id = bookingInforId.ToString(),
                BookerId = bookerId.ToString(),
                Destination = request.Destination,
                Location = request.Location,
                PickupTime = request.PickupTime,
                ReturnTime = request.ReturnTime,
                TotalPerson = request.TotalPerson
            };
            foreach (var item in request.BookingDetailRequests)
            {
                Guid bookingDetailId = Guid.NewGuid();
                BookingDetail bookingDetail = new BookingDetail()
                {
                    Id = bookingDetailId.ToString(),
                    BookerId = bookerId.ToString(),
                    EmployeeName = item.EmployeeName,
                    GuestName = item.GuestName,
                    Note = item.Note,
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
        
        [Route("api/bkc/decline")]
        [HttpPost]
        public IActionResult SaveDeclineBookingCarRequest([FromBody] DeclineBkcModel request)
        {
            if (!ModelState.IsValid) return BadRequest("Sai Thong Tin Decline");
            var booker = _bookerServices.getById(request.BookerId);
            booker.Status = "Decline";
            _context.SaveChanges();
            return Ok("Decline Success");
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
                List<BookingDetail> bookingDetails = _bookingDetailServices.getBkDetailsByBookerId(booker.Id);
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
        [Route("/api/bkc/approvebkc")]
        [HttpPost]
        public IActionResult approveBkc([FromBody] CarRequest carReq)
        {
            Car car = _carServices.getById(carReq.CarId);
            Booker booker = _bookerServices.getById(carReq.BookerId);
            BookingInfor bookingInfor = _bookingInforServices.getBkInforByBookerId(carReq.BookerId);
            var availableSeat = Convert.ToInt32(car.TotalSeat) - Convert.ToInt32(bookingInfor.TotalPerson);
            car.BookingDate = carReq.BookingDate;
            car.Status = "Booked";
            car.BookerId = carReq.BookerId;
            car.AvailableSeat = availableSeat.ToString();
            booker.Status = "Success";
            //Infor infor = _context.Infors.Find(carReq.InforId);
            //if (car == null || infor == null) return BadRequest();
            //car.BookingDate = carReq.BookingDate;
            //car.Status = "Booked";
            //car.BookingInforId = carReq.InforId;
            //infor.Status = "true";
            _context.SaveChanges();
            return Ok("Save Car Success");
        }
    }

}
