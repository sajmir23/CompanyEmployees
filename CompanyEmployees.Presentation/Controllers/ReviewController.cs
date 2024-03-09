using Entities.Models;
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
    [Route("api/review")]
    [ApiController]

    
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ReviewController(IServiceManager services) => _service = services;

        [HttpGet]
        public IActionResult Get()
        {
            var services = _service.ReviewService.GetAllReviews();
            return Ok(services);
        }


        [HttpPost]
        public IActionResult Post([FromBody] ReviewDto review)
        {
            var createdCompany = _service.ReviewService.AddReview(review);
            return Ok(createdCompany);
        }

    }

}
