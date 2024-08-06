using System;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Mappers
{
    public class VoteMapper
    {
        public static DTO.Models.Vote Map(VoteEntity? voteEntity)
        {
            return new DTO.Models.Vote()
            {
                Id = voteEntity?.Id ?? 0,
                CreatedAt = voteEntity?.CreatedAt ?? DateTime.MinValue,
                IdQuestion = voteEntity?.IdQuestion ?? 0,
                IdAnswer = voteEntity?.IdAnswer ?? 0,
                IdParticipationCompany = voteEntity?.IdParticipationCompany ?? 0
            };
        }
    }
}

