using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;


namespace Festival.Ms.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IFestivalContext _questionContext;
        
        public QuestionRepository(IFestivalContext QuestionContext)
        {
            _questionContext = QuestionContext;
        }

        public async Task<QuestionEntity?> GetQuestion(long id)
        {
            return await _questionContext.Question.FirstOrDefaultAsync(
                x => x.Id.Equals(id));
        }

    }
}
