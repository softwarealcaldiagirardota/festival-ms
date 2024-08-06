using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DTO.Models;

namespace Festival.Ms.DAL.Mappers
{
    public class VoteMapper
    {
        public static Vote Map(VoteEntity? voteEntity)
        {
            return new Vote()
            {
                Id = voteEntity?.Id ?? 0,
                CreatedAt = voteEntity?.CreatedAt ?? DateTime.MinValue,
                IdQuestion = voteEntity?.IdQuestion ?? 0,
                IdAnswer = voteEntity?.IdAnswer ?? 0,
                IdParticipationCompany = voteEntity?.IdParticipationCompany ?? 0
            };
        }

        public static VoteEntity Map(Vote vote, long IdParticipationCompany)
        {
            if (vote == null)
            {
                throw new ArgumentNullException(nameof(vote));
            }

            return new VoteEntity
            {
                CreatedAt = DateTime.UtcNow,
                IdQuestion = vote.IdQuestion,
                IdAnswer = vote.IdAnswer,
                IdParticipationCompany = IdParticipationCompany
            };
        }

        public static List<VoteEntity> Map(List<Vote> votes, long IdDeviceParticipation)
        {
            if (votes == null)
            {
                throw new ArgumentNullException(nameof(votes));
            }

            return votes.Select(vote => Map(vote, IdDeviceParticipation)).ToList();
        }
    }
}