using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bkc_backend.Data.Entities;
using bkc_backend.Services.EmployeeServices;

namespace bkc_backend.Api.ViewModel.Response
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public Employee Employee { get; set; }
    }
}
