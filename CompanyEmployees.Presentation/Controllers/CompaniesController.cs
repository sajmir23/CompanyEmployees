using CompanyEmployees.Presentation.ModelBinders;
using Entities.Responses;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/companies")]
    [ApiController]
    [ResponseCache(CacheProfileName = "120SecondsDuration")]
    [ApiExplorerSettings(GroupName = "v1")]

    public class CompaniesController : ApiControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager services) => _service = services;

        /// <summary>
        /// Gets the list of all companies
        /// </summary>
        /// <returns>The companies list</returns>
        [HttpGet(Name = "GetCompanies")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]
        //[ResponseCache(Duration =60)]
        public async Task<IActionResult> GetCompany(Guid Id)
        {
            var company = await _service.CompanyService.GetCompanyAsync(Id, trackChanges: false);
            return Ok(company);
        }

        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType =typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var companies = await _service.CompanyService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(companies);
        }

        /// <summary>
        /// Creates a newly created company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>A newly created company</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        
        [HttpPost(Name = "CreateCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company is null)
                return BadRequest("CompanyForCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdCompany = await _service.CompanyService.CreateCompanyAsync(company);
            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId,Guid id) 
        {
             _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId,id,trackChanges: false);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            if (company is null)
                return BadRequest("CompanyForUpdateDto object is null");

            await _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,DELETE");

            return Ok();

        }


        [HttpGet("test")]
        public IActionResult GetCompanies2()
        {
            var baseResult = _service.CompanyService.GetAllCompanies(trackChanges:
            false);
            var companies =
            ((ApiOkResponse<IEnumerable<CompanyDto>>)baseResult).Result;
            return Ok(companies);
        }


    }
}
