using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bkc_backend.Api.Model;
using bkc_backend.Api.Model.ResponseModel;
using bkc_backend.Data.Entities;
using bkc_backend.Services.Dtos;
using bkc_backend.Services.EmployeeServices;

namespace bkc_backend.Api.Helpers
{
    public class AutoMappingController: Profile
    {
        public AutoMappingController()
        {
            CreateMap<BookingInforRequest, BookingInforDTO>().ReverseMap();
            CreateMap<BookingInforResponse, BookingInforDTO>().ReverseMap();

            CreateMap<PickupLocationRequest, PickupLocationDTO>().ReverseMap();
            CreateMap<PickupLocationResponse, PickupLocationDTO>().ReverseMap();

            CreateMap<RelatePersonRequest, RelatePersonDTO>().ReverseMap();
            CreateMap<RelatePersonResponse, RelatePersonDTO>().ReverseMap();

            CreateMap<ParticipantRequest, ParticipantDTO>().ReverseMap();
            CreateMap<ParticipantResponse, ParticipantDTO>().ReverseMap();

            CreateMap<BookingResultRequest, BookingResultDTO>().ReverseMap();
            CreateMap<BookingResultResponse, BookingResultDTO>().ReverseMap();


            CreateMap<Employee, EmployeeResponseModel>();
            CreateMap<PickupLocationRequest, PickupLocation>();
            CreateMap<ParticipantRequest, Participant>();
            CreateMap<RelatePersonRequest, RelatePerson>();
            CreateMap<BookingResultRequest, BookingResult>();
            CreateMap<BookingInfor, BookingInforResponse>();
            CreateMap<BookingResult, BookingResultResponse>();
            CreateMap<RelatePerson, RelatePersonResponse>();
            CreateMap<PickupLocation, PickupLocationResponse>();
            CreateMap<Participant, ParticipantResponse>();
        }
    }
}
