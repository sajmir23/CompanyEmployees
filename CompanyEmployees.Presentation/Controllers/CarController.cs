using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/car/{carId}")]
    [ApiController]
    public class CarController:ControllerBase
    {
        private readonly IServiceManager _service;
        public CarController(IServiceManager services) => _service = services;


        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars=_service.CarService.GetAllCars(trackChanges:false);
            return Ok(cars);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetCar(Guid Id) 
        {
            var car = _service.CarService.GetCar(Id, trackChanges: false);
           return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody] CreateCarDto createCarDto) 
        {
          
            var car=_service.CarService.CreateCar(createCarDto);
            return CreatedAtRoute(new { id = car.Id }, car);
        }
        
        [HttpDelete]
        public IActionResult DeleteCar(Guid id)
        {
            _service.CarService.DeleteCar(id,trackChanges:false);
            return NoContent(); 
        }
        
    }
}
