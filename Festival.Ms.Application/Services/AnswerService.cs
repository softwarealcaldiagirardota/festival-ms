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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;


        public AnswerService(IAnswerRepository answerRepository) {
            _answerRepository = answerRepository;
        }

        public async Task<DTO.Models.Answer> GetAnswer(long id)
        {
            return AnswerMapper.Map(await _answerRepository.GetAnswer(id));
        }
    }
}
