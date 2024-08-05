using Festival.Ms.DAL.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        Task<AnswerEntity?> GetAnswer(long id);
    }
}
