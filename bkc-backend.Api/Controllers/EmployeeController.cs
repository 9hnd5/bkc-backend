using AutoMapper;
using bkc_backend.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace bkc_backend.Controller.Controllers
{
    public class EmployeeController : ControllerBase
    {
        public IMapper _mapper;
        public IEmployeeServices _employeeServices;
        public EmployeeController(IMapper mapper, IEmployeeServices employeeServices)
        {
            _mapper = mapper;
            _employeeServices = employeeServices;
        }
        [Route("api/employees/{name}")]
        [HttpGet]
        public IActionResult GetEmployeeByName(string name)
        {
            var employees = _employeeServices.GetEmployeesByName(name);
            return Ok(employees);
        }

      
        
       
    }

}
