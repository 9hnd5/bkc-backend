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
    public class CarController: ControllerBase
    {
        public IMapper _mapper;
        public ICarServices _carServices;
        public CarController(IMapper mapper, ICarServices carServices)
        {
            _mapper = mapper;
            _carServices = carServices;
        }
        [Route("api/cars")]
        [HttpGet]
        public IActionResult GetCarsByBuId([FromQuery] string buId)
        {
            var cars = _carServices.GetCarsByBuId(buId);
            var carResponses = _mapper.Map<List<CarResponse>>(cars);
            return Ok(carResponses);
        }

        [Route("api/all-car/{buId}")]
        [HttpGet]
        public IActionResult GetALlCarByBuId(string buId)
        {
            var cars = _carServices.GetAllCarByBuId(buId);
            var carResponses = _mapper.Map<List<CarResponse>>(cars);
            return Ok(carResponses);
        }

        [Route("api/cars/{id}")]
        [HttpGet]
        public IActionResult GetCarById(int id)
        {
            var car = _carServices.GetById(id);
            if (car == null)
            {
                return NotFound("Load Car Fail");
            }
            var carResponse = _mapper.Map<CarResponse>(car);
            return Ok(carResponse);
        }

        [Route("api/cars/")]
        [HttpPost]
        public IActionResult AddCar([FromBody] CarRequest carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            _carServices.Add(car);
            var carResponse = _mapper.Map<CarResponse>(car);
            return Ok(carResponse);
        }
        [Route("api/cars/")]
        [HttpPut]
        public IActionResult UpdateCar([FromBody] CarRequest carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            //_carServices.UpdateCar(car);
            _carServices.Update(car);
            return Ok();
        }
        [Route("api/cars/")]
        [HttpDelete]
        public IActionResult DeleteCar([FromBody] CarRequest carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            _carServices.Remove(car);
            return Ok();
        }

    }
}
