using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Ms.API.Controllers
{
    [ApiController]
    [Route("api/Company")]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyByID(long id)
        {
            return Ok(await ApiExecution.RunAsync(_companyService.GetCompany(id)));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }


    }
}
