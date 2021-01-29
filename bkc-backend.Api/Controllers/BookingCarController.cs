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
        public ICarServices _carServices;
        public IBusinessUnitSerivces _businessUnitServices;
        public ITripServices _tripServices;
        public BookingCarController(IMapper mapper, IEmployeeServices employeeServices, ITicketSerivces ticketSerivces,
            IDriverServices driverServices, ICarServices carServices, IBusinessUnitSerivces businessUnitSerivces,
            ITripServices tripServices)
        {
            _mapper = mapper;
            _employeeServices = employeeServices;
            _ticketSerivces = ticketSerivces;
            _driverServices = driverServices;
            _carServices = carServices;
            _businessUnitServices = businessUnitSerivces;
            _tripServices = tripServices;
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
    
        [Route("api/cars")]
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carServices.GetAll();
            var carResponses = _mapper.Map<List<CarResponse>>(cars);
            return Ok(carResponses);
        }

        [Route("api/cars/{id}")]
        [HttpGet]
        public IActionResult GetCarById(int id)
        {
            var car = _carServices.GetById(id);
            if(car == null)
            {
                return NotFound("Load Car Fail");
            }
            var carResponse = _mapper.Map<CarResponse>(car);
            return Ok(carResponse);
        }

        [Route("api/cars/")]
        [HttpPost]
        public IActionResult AddCar([FromBody]CarRequest carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            _carServices.Add(car);
            var carResponse = _mapper.Map<CarResponse>(car);
            return Ok(carResponse);
        }
        [Route("api/cars/")]
        [HttpPut]
        public IActionResult UpdateCar([FromBody] CarRequest carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            _carServices.UpdateCar(car);
            return Ok();
        }
        [Route("api/cars/")]
        [HttpDelete]
        public IActionResult DeleteCar([FromBody] CarRequest carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            _carServices.Remove(car);
            return Ok();
        }

        [Route("api/drivers")]
        [HttpGet]
        public IActionResult GetDrivers()
        {
            var drivers = _driverServices.GetDrivers();
            var driverResponse = _mapper.Map<List<DriverResponse>>(drivers);
            return Ok(driverResponse);
        }
        [Route("api/drivers")]
        [HttpPost]
        public IActionResult AddDriver([FromBody] DriverRequest driverRequest)
        {
            var driver = _mapper.Map<Driver>(driverRequest);
            _driverServices.Add(driver);
            var driverResponse = _mapper.Map<DriverResponse>(driver);
            return Ok(driverResponse);
        }
        [Route("api/drivers")]
        [HttpPut]
        public IActionResult UpdateDriver([FromBody] DriverRequest driverRequest)
        {
            var driver = _mapper.Map<Driver>(driverRequest);
            _driverServices.UpdateDriver(driver);
            return Ok();
        }
        [Route("api/drivers")]
        [HttpDelete]
        public IActionResult DeleteDriver([FromBody] DriverRequest driverRequest)
        {
            var driver = _mapper.Map<Driver>(driverRequest);
            _driverServices.Remove(driver);
            return Ok();
        }

        [Route("api/business-units/{buName}")]
        [HttpGet]
        public IActionResult GetBuByBuName(string buName)
        {
            var bu = _businessUnitServices.GetBusinessUnitsByName(buName);
            return Ok(bu);
        }

        [Route("api/business-units/")]
        [HttpGet]
        public IActionResult GetBusinessUnits()
        {
            var bus = _businessUnitServices.GetBusinessUnits();
            return Ok(bus);
        }

        [Route("api/trips/{isFinish}")]
        [HttpGet]
        public IActionResult GetTripsByIsFinish(bool isFinish)
        {
            var trips = _tripServices.GetTripsByIsFinish(isFinish);
            var tripResponses = _mapper.Map<List<TripResponse>>(trips);
            return Ok(tripResponses);
        }

    }

}
