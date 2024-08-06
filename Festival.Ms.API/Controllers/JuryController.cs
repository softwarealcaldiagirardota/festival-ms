using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Ms.API.Controllers
{

    [ApiController]
    [Route("api/Jury")]
    public class JuryController : ControllerBase
    {
        private readonly IJuryService _juryService;

        public JuryController(IJuryService juryService)
        {
            _juryService = juryService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetJuryByID(long id)
        {
            return Ok(await ApiExecution.RunAsync(_juryService.GetJury(id)));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllJuriesAsync()
        {
            var juries = await _juryService.GetAllAsync();
            return Ok(juries);
        }

    }
}
