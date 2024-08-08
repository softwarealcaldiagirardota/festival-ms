using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IFestivalContext _answerContext;


        public AnswerRepository(IFestivalContext AnswerContext)
        {
            _answerContext = AnswerContext;
        }


        public async Task<AnswerEntity?> GetAnswer(long id)
        {
        return await _answerContext.Answer.FirstOrDefaultAsync(
            x => x.Id.Equals(id));
        }

    }
}
