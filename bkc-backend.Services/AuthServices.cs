using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace bkc_backend.Services.AuthServices
{
    public interface IAuthServices
    {
        public object Authenticate(string email, string password);
    }
    public class AuthServices : IAuthServices
    {
        private IConfiguration _config;
        public AuthServices(IConfiguration config)
        {
            _config = config;
        }
        public object Authenticate(string email, string password)
        {
            return "";
        }

        
    }
}
