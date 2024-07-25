using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Festival.Ms.API.Controllers
{
    public class FestivalController : ControllerBase
    {
        private readonly IFestivalService _festivalService;

        public FestivalController(IFestivalService festivalService)
        {
            _festivalService = festivalService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanies(long id)
        {
            return Ok(await ApiExecution.RunAsync(_festivalService.GetFestival(id)));
        }

    }
}

