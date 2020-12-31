using bkc_backend.Services;
using bkc_backend.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Controllers
{
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeServices _empServices;
        public EmployeeController(IEmployeeServices empServices)
        {
            _empServices = empServices;
        }
        [Route("api/employee/{email}")]
        [HttpGet]
        public IActionResult GetEmployeeByEmail(string email)
        {
            var emp = _empServices.GetEmployeeByEmail(email);
            if(emp == null)
            {
                return BadRequest();
            }
            return Ok(emp);
        }
    }
}
