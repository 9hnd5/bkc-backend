using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bkc_backend.Api.Model;
using bkc_backend.Services.UserServices;

namespace bkc_backend.Api.Helpers
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeResponseModel>();
        }
    }
}
