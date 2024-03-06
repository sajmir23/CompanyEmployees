using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _service;
        private List<Review> reviews;

        public ReviewController(IServiceManager services) => _service = services;

        [HttpGet]
        public IEnumerable<Review> Get()
        {
            return _service.GetAllReviews();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            _service.AddReview(review);
            return CreatedAtAction(nameof(Get), new { id = review.Id }, review);
        }

    }

}
