using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<QuestionEntity?> GetQuestion(long id);
    }
}
