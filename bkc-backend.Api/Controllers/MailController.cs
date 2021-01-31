using AutoMapper;
using bkc_backend.Api.ViewModel.Response;
using bkc_backend.Data.Entities;
using bkc_backend.RazorEmail;
using bkc_backend.RazorEmail.ViewModels;
using bkc_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Controllers
{
    public class MailController : ControllerBase
    {
        IMapper _mapper;
        ISendMailServices _sendMailServices;
        IRelatedPeopleServices _relatedPeopleServices;
        IRazorViewToStringRenderer _razorViewToStringRenderer;
        ILocationServices _locationServices;
        IDriverServices _driverServices;
        ITicketCarServices _ticketCarServices;
        ITicketSerivces _ticketServices;
        ICarServices _carServices;
        public MailController(IMapper mapper, ISendMailServices sendMailServices, IRelatedPeopleServices relatedPeopleServices,
            IRazorViewToStringRenderer razorViewToStringRenderer, ILocationServices locationServices, IDriverServices driverServices,
            ITicketCarServices ticketCarServices, ITicketSerivces ticketSerivces, ICarServices carServices)
        {
            _mapper = mapper;
            _sendMailServices = sendMailServices;
            _relatedPeopleServices = relatedPeopleServices;
            _razorViewToStringRenderer = razorViewToStringRenderer;
            _locationServices = locationServices;
            _driverServices = driverServices;
            _ticketCarServices = ticketCarServices;
            _ticketServices = ticketSerivces;
            _carServices = carServices;
        }


        [Route("api/send-mail/{ticketId}")]
        [HttpGet]
        public async Task<IActionResult> SendMailForTicketId(int ticketId)
        {
            string pathEmailNotify = "/Views/Share/EmailNotify.cshtml";
            var mailContent = new MailContent();
            var ticket = _ticketServices.GetById(ticketId);
            var ticketCars = _ticketCarServices.GetTicketCarsByTicketId(ticketId);
            var locations = _locationServices.GetLocationsByTicketId(ticketId);
            if (ticketCars[0].CarId == ticketCars[1].CarId)
            {
                var car = _carServices.GetById(ticketCars[0].CarId);
                var driver = _driverServices.GetDriverByCarId(car.Id);
                var emailNotify = new EmailNotifyViewModel();
                emailNotify.Booker = new BookerViewModel()
                {
                    StartDate = ticket.StartDate,
                    FromLocation = ticket.FromLocation,
                    ToLocation = ticket.ToLocation,
                    TotalParticipant = ticket.TotalParticipant,
                    BookerName = ticket.EmployeeName,
                    BookerPhone = ticket.EmployeePhone,
                };
                var driverViewModels = new List<DriverViewModel>()
                {
                    new DriverViewModel(){
                        DriverName = driver.EmployeeName,
                        DriverPhone = driver.EmployeePhone,
                        CarNumber = car.Number,
                        NoteForDriver = "",
                        Locations = _mapper.Map<List<LocationViewModel>>(locations)
                    }
                };
                emailNotify.Drivers = driverViewModels;
                var bodyEmail = await _razorViewToStringRenderer.RenderViewToStringAsync(pathEmailNotify, emailNotify);
                mailContent.Body = bodyEmail;
                mailContent.To = ticket.EmployeeEmail;
                //mailContent.CCTos = new List<string>();
                //mailContent.CCTos.Add(driver.EmployeeEmail);
                mailContent.Subject = "TICKET WAS APPROVED";
                await _sendMailServices.SendMail(mailContent);

            }
            else
            {
                var driverViewModels = new List<DriverViewModel>();
                var emailNotify = new EmailNotifyViewModel();
                var ccTos = new List<string>();
                foreach (var ticketCar in ticketCars)
                {
                    var car = _carServices.GetById(ticketCar.CarId);
                    var driver = _driverServices.GetDriverByCarId(car.Id);
                    ccTos.Add(driver.EmployeeEmail);
                    emailNotify.Booker = new BookerViewModel()
                    {
                        StartDate = ticket.StartDate,
                        FromLocation = ticket.FromLocation,
                        ToLocation = ticket.ToLocation,
                        TotalParticipant = ticket.TotalParticipant,
                        BookerName = ticket.EmployeeName,
                        BookerPhone = ticket.EmployeePhone,
                    };
                    if(ticketCar.Type == "MOVE_CAR")
                    {
                        driverViewModels.Add(new DriverViewModel()
                        {
                            DriverName = driver.EmployeeName,
                            DriverPhone = driver.EmployeePhone,
                            CarNumber = car.Number,
                            NoteForDriver = "",
                            Locations = _mapper.Map<List<LocationViewModel>>(locations),
                            Type = "MOVE_CAR"
                        });
                    }
                    else if(ticketCar.Type == "RETURN_CAR")
                    {
                        driverViewModels.Add(new DriverViewModel()
                        {
                            DriverName = driver.EmployeeName,
                            DriverPhone = driver.EmployeePhone,
                            CarNumber = car.Number,
                            NoteForDriver = "",
                            Locations = _mapper.Map<List<LocationViewModel>>(locations),
                            Type = "RETURN_CAR"
                        });
                    }
                }
                emailNotify.Drivers = driverViewModels;
                var bodyEmail = await _razorViewToStringRenderer.RenderViewToStringAsync(pathEmailNotify, emailNotify);
                mailContent.Body = bodyEmail;
                mailContent.To = ticket.EmployeeEmail;
                mailContent.CCTos = ccTos;
                mailContent.Subject = "TICKET WAS APPROVED";
                await _sendMailServices.SendMail(mailContent);
            }
            return Ok();
        }
    }
}
