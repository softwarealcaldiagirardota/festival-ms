using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Ms.API.Controllers
{
    [ApiController]
    [Route("api/CompanySale")]
    public class CompanySaleController : Controller
    {
        private readonly ICompanySaleService _companySaleService;

        public CompanySaleController(ICompanySaleService companySaleService)
        {
            _companySaleService = companySaleService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleServiceByID(long id)
        {
            return Ok(await ApiExecution.RunAsync(_companySaleService.GetCompanySale(id)));
        }

    }
}
