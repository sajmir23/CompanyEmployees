using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/house")]
    [ApiController]

    public class HouseController:ControllerBase
    {
        private readonly IServiceManager _service;
        public HouseController(IServiceManager services) => _service = services;

        [HttpGet]

        public IActionResult Get()
        {
            var services = _service.HouseService.GetAllHouse(false);
            return Ok(services);
        }

        [HttpPost]

        public IActionResult Post([FromBody] HouseDto house)
        {

            var newhouse = _service.HouseService.AddHouse(house);
            return Ok(newhouse);
        }
    }
}
