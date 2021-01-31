using AutoMapper;
using bkc_backend.Api.ViewModel.Request;
using bkc_backend.Api.ViewModel.Response;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Controllers
{
    public class TicketCarController: ControllerBase
    {
        public IMapper _mapper;
        public ITicketCarServices _ticketCarServices;

        public TicketCarController(IMapper mapper, ITicketCarServices ticketCarServices)
        {
            _mapper = mapper;
            _ticketCarServices = ticketCarServices;
        }
        [Route("api/ticket-car")]
        [HttpPost]
        public IActionResult AddTicketCar([FromBody] TicketCarRequest ticketCarRequest)
        {
            var ticketCar = _mapper.Map<TicketCar>(ticketCarRequest);
            _ticketCarServices.Add(ticketCar);
            return Ok(ticketCar);
        }

        [Route("api/ticket-car")]
        [HttpPut]
        public IActionResult UpdateTicketCar([FromBody] TicketCarRequest ticketCarRequest)
        {
            var ticketCar = _mapper.Map<TicketCar>(ticketCarRequest);
            _ticketCarServices.Update(ticketCar);
            return Ok();
        }
        [Route("api/ticket-car/{ticketId}")]
        [HttpGet]
        public IActionResult GetTicketCarsByTicketId(int ticketId)
        {
            var ticketCars = _ticketCarServices.GetTicketCarsByTicketId(ticketId);
            var ticketCarResponses = _mapper.Map<List<TicketCarResponse>>(ticketCars);
            return Ok(ticketCarResponses);
        }
        [Route("api/ticket-car")]
        [HttpDelete]
        public IActionResult DeleteTicketCar([FromBody] TicketCarRequest ticketCarRequest)
        {
            var ticketCar = _mapper.Map<TicketCar>(ticketCarRequest);
            _ticketCarServices.Remove(ticketCar);
            return Ok();
        }
    }
}
