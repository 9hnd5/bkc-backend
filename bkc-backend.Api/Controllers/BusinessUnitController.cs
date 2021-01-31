using AutoMapper;
using bkc_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Controllers
{
    public class BusinessUnitController: ControllerBase
    {
        public IMapper _mapper;
        public IBusinessUnitServices _businessUnitServices;
        public BusinessUnitController(IMapper mapper, IBusinessUnitServices businessUnitServices)
        {
            _mapper = mapper;
            _businessUnitServices = businessUnitServices;
        }
        [Route("api/business-units/{buName}")]
        [HttpGet]
        public IActionResult GetBuByBuName(string buName)
        {
            var bu = _businessUnitServices.GetBusinessUnitsByName(buName);
            return Ok(bu);
        }

        [Route("api/business-units/")]
        [HttpGet]
        public IActionResult GetBusinessUnits()
        {
            var bus = _businessUnitServices.GetBusinessUnits();
            return Ok(bus);
        }
    }
}
