using System;
using System.Collections.Generic;
using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.Application.Services;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




namespace Festival.Ms.API.Controllers
{
    [ApiController]
    [Route("api/Answer")]
    public class AnswerController : ControllerBase
    {

        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerByID(long id)
        {
            return Ok(await ApiExecution.RunAsync(_answerService.GetAnswer(id)));
        }

    }
}
