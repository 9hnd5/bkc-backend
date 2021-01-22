using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bkc_backend.Api.ViewModel.Request;
using bkc_backend.Api.ViewModel.Response;
using bkc_backend.Data.Entities;
using bkc_backend.Services.EmployeeServices;

namespace bkc_backend.Api.Helpers
{
    public class AutoMappingController: Profile
    {
        public AutoMappingController()
        {
            CreateMap<Ticket, TicketAddRequest>().ReverseMap();
            CreateMap<Location, LocationAddRequest>().ReverseMap();
            CreateMap<RelatedPeople, RelatedPeopleAddRequest>().ReverseMap();
            CreateMap<Participant, ParticipantAddRequest>().ReverseMap();

            CreateMap<Ticket, TicketHistoryResponse>().ReverseMap();
            CreateMap<Location, LocationHistoryResponse>().ReverseMap();
            CreateMap<RelatedPeople, RelatedPeopleHistoryResponse>().ReverseMap();
            CreateMap<Participant, ParticipantHistoryResponse>().ReverseMap();

            CreateMap<Ticket, TicketUpdateRequest>().ReverseMap();
            CreateMap<Location, LocationUpdateRequest>().ReverseMap();
            CreateMap<RelatedPeople, RelatedPeopleUpdateRequest>().ReverseMap();
            CreateMap<Participant, ParticipantUpdateRequest>().ReverseMap();

            CreateMap<Driver, DriverResponse>().ReverseMap();
            CreateMap<Car, CarResponse>().ReverseMap();


        }
    }
}
