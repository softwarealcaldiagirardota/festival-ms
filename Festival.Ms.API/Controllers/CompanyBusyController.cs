using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Ms.API.Controllers
{
    [ApiController]
    [Route("api/CompanyBusy")]
    public class CompanyBusyController : Controller
    {
        private readonly ICompanyBusyService _companyBusyService;

        public CompanyBusyController(ICompanyBusyService companyBusyService)
        {
            _companyBusyService = companyBusyService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusyServiceByID(long id)
        {
            return Ok(await ApiExecution.RunAsync(_companyBusyService.GetCompanyBusy(id)));
        }


    }
}
