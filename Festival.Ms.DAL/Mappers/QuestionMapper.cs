using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Mappers
{
    public class QuestionMapper
    {
        public static DTO.Models.Question Map(QuestionEntity? QuestionEntity)
        {
            return new DTO.Models.Question()
            {
                id = QuestionEntity?.Id ?? 0,
                Description = QuestionEntity?.Description ?? string.Empty,
                Value = (long)(QuestionEntity?.Value ?? 0) // Conversión explícita de decimal a long
            };
        }
    }
}
