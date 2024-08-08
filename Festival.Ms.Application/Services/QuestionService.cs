using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Mappers;
using Festival.Ms.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<DTO.Models.Question> GetQuestion(long id)
        {
            return QuestionMapper.Map(await _questionRepository.GetQuestion(id));
        }
    }
}
