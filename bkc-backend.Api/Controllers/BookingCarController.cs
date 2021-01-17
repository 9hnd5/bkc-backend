using AutoMapper;
using bkc_backend.Api.Model;
using bkc_backend.Api.Model.ResponseModel;
using bkc_backend.Controller.Model;
using bkc_backend.Data;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
using bkc_backend.Services.Dtos;
using bkc_backend.Services.EmployeeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Controllers
{
    public class BookingCarController : ControllerBase
    {
        public BookingCarDbContext _context;
        public IMapper _mapper;
        public IEmployeeServices _employeeServices;
        public IBookingInforServices _bookingInforServices;
        public BookingCarController(IMapper mapper, IEmployeeServices employeeServices, IBookingInforServices bookingInforServices)
        {
            _mapper = mapper;
            _employeeServices = employeeServices;
            _bookingInforServices = bookingInforServices;
        }

        [Route("api/bkc/employees/{name}")]
        [HttpGet]
        public IActionResult GetEmployeesByName(string name)
        {
            List<Employee> employees = _employeeServices.GetEmployeesByName(name);
            if (employees.Count == 0) return NotFound("Không tìm thấy employees với name: " + name);
            var employeesResponse = _mapper.Map<EmployeeResponseModel[]>(employees);
            return Ok(employeesResponse);
        }


        [Route("api/bkc/bookingInfors")]
        [HttpPost]
        public IActionResult InsertBookingInfor([FromBody] BookingInforRequest request)
        {
            var bookingInforDTO = _mapper.Map<BookingInforDTO>(request);
            var isSuccess = _bookingInforServices.AddBookingInfor(bookingInforDTO);
            if (!isSuccess) return BadRequest("Error when create BookingInfor");
            return Ok("Create Booking Infor Succcess");
        }
        [Route("api/bkc/booking-infors/{employeeId}")]
        [HttpGet]
        public IActionResult GetBookingInforsByEmployeeId(string employeeId)
        {
            List<BookingInforDTO> bookingInforsDTO = _bookingInforServices.GetBookingInforsByEmployeeId(employeeId);
            if (bookingInforsDTO.Count == 0) return BadRequest("Not found any booking infor with employee id " + employeeId);
            var bookingInforResponses = _mapper.Map<BookingInforResponse[]>(bookingInforsDTO);
            return Ok(bookingInforResponses);
        }
        [Route("api/bkc/booking-infors/")]
        [HttpPut]
        public IActionResult UpdateBookingInforById([FromBody] BookingInforRequest request)
        {
            var bookingInforDTO = _mapper.Map<BookingInforDTO>(request);
            var isUpdateSuccess = _bookingInforServices.UpdateBookingInfor(bookingInforDTO);
            if (!isUpdateSuccess) return BadRequest("Update Booking Infor Fail");
            return Ok("Update Booking Infor Success");
        }
    }
}
