using AutoMapper;
using bkc_backend.Api.ViewModel.Request;
using bkc_backend.Api.ViewModel.Response;
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
    public class BookingCarController : ControllerBase
    {
        public BookingCarDbContext _context;
        public IMapper _mapper;
        public IEmployeeServices _employeeServices;
        public ITicketSerivces _ticketSerivces;
        public IDriverServices _driverServices;
        public BookingCarController(IMapper mapper, IEmployeeServices employeeServices, ITicketSerivces ticketSerivces,
            IDriverServices driverServices)
        {
            _mapper = mapper;
            _employeeServices = employeeServices;
            _ticketSerivces = ticketSerivces;
            _driverServices = driverServices;
        }
        [Route("api/employees/{name}")]
        [HttpGet]
        public IActionResult GetEmployeeByName(string name)
        {
            var employees = _employeeServices.GetEmployeesByName(name);
            return Ok(employees);
        }

        [Route("api/tickets")]
        [HttpPost]
        public IActionResult AddTicket([FromBody] TicketAddRequest ticketAddRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ticket = _mapper.Map<Ticket>(ticketAddRequest);
            var isSuccess = _ticketSerivces.AddTicket(ticket);
            return Ok();
        }

        [Route("api/tickets")]
        [HttpPut]
        public IActionResult UpdateTicket([FromBody] TicketUpdateRequest ticketUpdateRequest)
        {
            var ticket = _mapper.Map<Ticket>(ticketUpdateRequest);
            var isSuccess = _ticketSerivces.UpdateTicket(ticket);
            return Ok();
        }

        [Route("api/tickets/")]
        [HttpGet]
        public IActionResult GetTicketsBySelectorId(string selector, string id)
        {
            if (selector == "EMPLOYEE")
            {
                var tickets = _ticketSerivces.GetTicketsByEmployeeId(id);
                var ticketHistoriesResponse = _mapper.Map<List<TicketHistoryResponse>>(tickets);
                return Ok(ticketHistoriesResponse);
            }
            else if (selector == "BU")
            {
                var tickets = _ticketSerivces.GetTicketsByBuId(id);
                var ticketHistoriesResponse = _mapper.Map<List<TicketHistoryResponse>>(tickets);
                return Ok(ticketHistoriesResponse);
            }
            else return BadRequest();
        }

        [Route("api/tickets/{ticketId}")]
        [HttpDelete]
        public IActionResult DeleteTicketById(int ticketId)
        {
            _ticketSerivces.RemoveTicketById(ticketId);
            return Ok();
        }
    
        [Route("api/drivers/{buId}")]
        [HttpGet]
        public IActionResult GetDriverByBuId(string buId)
        {
            var drivers = _driverServices.GetDriverByBuId(buId);
            var driverResponses = _mapper.Map<List<DriverResponse>>(drivers);
            return Ok(driverResponses);
        }
    }

}
