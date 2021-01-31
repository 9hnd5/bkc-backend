using AutoMapper;
using bkc_backend.Api.ViewModel.Request;
using bkc_backend.Api.ViewModel.Response;
using bkc_backend.Data.Entities;
using bkc_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Controllers
{
    public class DriverController: ControllerBase
    {
        public IMapper _mapper;
        public IDriverServices _driverServices;
        public DriverController(IMapper mapper, IDriverServices driverServices)
        {
            _mapper = mapper;
            _driverServices = driverServices;
        }
        [Route("api/drivers/")]
        [HttpGet]
        public IActionResult GetDriversWasBooked([FromQuery] string buId, [FromQuery] bool isFinish)
        {
            var drivers = _driverServices.GetDriversWasBooked(buId, isFinish);
            var driverResponses = _mapper.Map<List<DriverResponse>>(drivers);
            return Ok(driverResponses);
        }
        [Route("api/drivers/{buId}")]
        [HttpGet]
        public IActionResult GetDriversByBuId(string buId)
        {
            var drivers = _driverServices.GetDriversByBuId(buId);
            var driverResponse = _mapper.Map<List<DriverResponse>>(drivers);
            return Ok(driverResponse);
        }
        [Route("api/drivers")]
        [HttpPost]
        public IActionResult AddDriver([FromBody] DriverRequest driverRequest)
        {
            var driver = _mapper.Map<Driver>(driverRequest);
            _driverServices.Add(driver);
            var driverResponse = _mapper.Map<DriverResponse>(driver);
            return Ok(driverResponse);
        }
        
        [Route("api/drivers")]
        [HttpPut]
        public IActionResult UpdateDriver([FromBody] DriverRequest driverRequest)
        {
            var driver = _mapper.Map<Driver>(driverRequest);
            _driverServices.UpdateDriver(driver);
            return Ok();
        }
        [Route("api/drivers")]
        [HttpDelete]
        public IActionResult DeleteDriver([FromBody] DriverRequest driverRequest)
        {
            var driver = _mapper.Map<Driver>(driverRequest);
            _driverServices.Remove(driver);
            return Ok();
        }
    }
}
