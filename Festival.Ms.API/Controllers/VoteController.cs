using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.Application.Services;
using Festival.Ms.DTO.Generic;
using Festival.Ms.DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Festival.Ms.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost()]
        public async Task<IActionResult> RegistryVote(List<Vote> votes)
        {
            int IdFestivalHeader = 0;
            if (Request.Headers.TryGetValue("id-festival", out var headerValues))
            {
                IdFestivalHeader = Convert.ToInt32(headerValues.ToString());
            }

            string code = string.Empty;
            if (Request.Headers.TryGetValue("code", out var headerValuesOne))
            {
                code = headerValuesOne.ToString();
            }

            return Ok(await ApiExecution.RunAsync(_voteService.RegistryVote(votes, code, IdFestivalHeader)));
        }
    }
}

