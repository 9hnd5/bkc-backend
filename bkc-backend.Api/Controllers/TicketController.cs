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
    public class TicketController: ControllerBase
    {
        public IMapper _mapper;
        public ITicketSerivces _ticketServices;
        public TicketController(IMapper mapper, ITicketSerivces ticketSerivces)
        {
            _mapper = mapper;
            _ticketServices = ticketSerivces;
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
            var isSuccess = _ticketServices.AddTicket(ticket);
            return Ok();
        }

        [Route("api/tickets")]
        [HttpPut]
        public IActionResult UpdateTicket([FromBody] TicketUpdateRequest ticketUpdateRequest)
        {
            var ticket = _mapper.Map<Ticket>(ticketUpdateRequest);
            var isSuccess = _ticketServices.UpdateTicket(ticket);
            return Ok(ticket);
        }

        [Route("api/tickets/")]
        [HttpGet]
        public IActionResult GetTicketsBySelectorId(string selector, string id)
        {
            if (selector == "EMPLOYEE")
            {
                var tickets = _ticketServices.GetTicketsByEmployeeId(Convert.ToString(id));
                var ticketHistoriesResponse = _mapper.Map<List<TicketHistoryResponse>>(tickets);
                return Ok(ticketHistoriesResponse);
            }
            else if (selector == "BU")
            {
                var tickets = _ticketServices.GetTicketsByBuId(Convert.ToString(id));
                var ticketHistoriesResponse = _mapper.Map<List<TicketHistoryResponse>>(tickets);
                return Ok(ticketHistoriesResponse);
            }
            else if (selector == "TICKETID")
            {
                var ticket = _ticketServices.GetTicketById(Convert.ToInt32(id));
                var ticketResponse = _mapper.Map<TicketHistoryResponse>(ticket);
                return Ok(ticketResponse);
            }
            else return BadRequest();
        }

        [Route("api/cars/{carId}/tickets")]
        [HttpGet]
        public IActionResult GetTicksByDriverId(int carId)
        {
            var tickets = _ticketServices.GetTicksByCarId(carId);
            var ticketResponse = _mapper.Map<List<TicketResponse>>(tickets);
            return Ok(ticketResponse);
        }

        [Route("api/tickets/{ticketId}")]
        [HttpDelete]
        public IActionResult DeleteTicketById(int ticketId)
        {
            _ticketServices.RemoveTicketById(ticketId);
            return Ok();
        }
    }
}
