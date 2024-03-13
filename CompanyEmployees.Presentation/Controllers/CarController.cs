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
    [Route("api/car")]
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
        [HttpPost]
        public IActionResult CreateCar([FromBody] CreateCarDto createCarDto) 
        {
          
            var car=_service.CarService.CreateCar(createCarDto);
            return CreatedAtRoute(new { id = car.Id }, car);
        }
    }
}
