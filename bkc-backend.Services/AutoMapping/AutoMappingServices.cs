using AutoMapper;
using bkc_backend.Data.Entities;
using bkc_backend.Services.Dtos;
using bkc_backend.Services.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Services.AutoMapping
{
    public class AutoMappingServices: Profile
    {
        public AutoMappingServices()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<BookingInfor, BookingInforDTO>().ReverseMap();
            CreateMap<BookingResult, BookingResultDTO>().ReverseMap();
            CreateMap<Participant, ParticipantDTO>().ReverseMap();
            CreateMap<PickupLocation, PickupLocationDTO>().ReverseMap();
            CreateMap<RelatePerson, RelatePersonDTO>().ReverseMap();
        }
    }
}
