using AutoMapper;
using bkc_backend.Api.Model;
using bkc_backend.Controller.Model;
using bkc_backend.Data;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
using bkc_backend.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Controller.Controllers
{
    public class BookingCarController : ControllerBase
    {
        public BookingCarDbContext _context;
        public IMapper _mapper;
        public IEmployeeServices _employeeServices;
        public BookingCarController(IMapper mapper, IEmployeeServices employeeServices)
        {
            _mapper = mapper;
            _employeeServices = employeeServices;
        }

        [Route("api/bkc/employees/{name}")]
        [HttpGet]
        public IActionResult GetEmployeesByName(string name)
        {
            List<Employee> employees = _employeeServices.GetEmployeesByName(name);
            if (employees.Count == 0) return NotFound("Không tìm thấy employees với name: " + name);
            List<EmployeeResponseModel> employeesResponse = new List<EmployeeResponseModel>();
            foreach(var employee in employees)
            {
                var employeeResponse = _mapper.Map<EmployeeResponseModel>(employee);
                employeesResponse.Add(employeeResponse);
            }
            //var employeesResponse = _mapper.Map<EmployeeResponseModel>(employees);
            return Ok(employeesResponse);
        }

    }
}
