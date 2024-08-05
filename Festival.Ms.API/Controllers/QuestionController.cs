
using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.Application.Services;
using Festival.Ms.DTO.Generic;
using Microsoft.AspNetCore.Mvc;



namespace Festival.Ms.API.Controllers
{


    [ApiController]
    [Route("api/Question")]
    public class QuestionController  : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionByID(long id)
        {
            return Ok(await ApiExecution.RunAsync(_questionService.GetQuestion(id)));
        }

    }
}
