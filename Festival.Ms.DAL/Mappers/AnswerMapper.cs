using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DTO.Models; 



namespace Festival.Ms.DAL.Mappers
{
    public static class AnswerMapper
    {
        public static DTO.Models.Answer Map(AnswerEntity? AnswerEntity)
        {
            return new DTO.Models.Answer()
            {
                id = AnswerEntity?.Id ?? 0,
                Description = AnswerEntity?.Description ?? string.Empty,
                Value = (long)(AnswerEntity?.Value ?? 0) // Conversión explícita de decimal a long
            };
        }

    }
}
