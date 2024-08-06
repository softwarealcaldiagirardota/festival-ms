using System;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Mappers
{
    public class ParticipationCompanyMapper
    {
        public static DTO.Models.ParticipationCompany Map(ParticipationCompanyEntity? entity)
        {
            if (entity == null)
            {
                return new DTO.Models.ParticipationCompany();
            }

            return new DTO.Models.ParticipationCompany
            {
                Id = entity.Id,
                IdCompany = entity.IdCompany,
                IdFestival = entity.IdFestival,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}

