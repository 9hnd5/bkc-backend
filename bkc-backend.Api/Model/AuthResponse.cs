using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bkc_backend.Data.Entities;
using bkc_backend.Services.UserServices;

namespace bkc_backend.Api.Model
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public Employee User { get; set; }
    }
}
