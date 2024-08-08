using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Mappers
{
    public class JuryMapper
    {
        public static DTO.Models.Jury Map(JuryEntity? juryEntity)
        {
            return new DTO.Models.Jury()
            {
                Id = juryEntity?.Id ?? 0,
                Description = juryEntity?.Description ?? string.Empty,
                CreatedAt = juryEntity?.CreatedAt ?? DateTime.MinValue,
                IdUserAuth = juryEntity?.IdUserAuth ?? 0
            };
        }

        public static IEnumerable<DTO.Models.Jury> Map(IEnumerable<JuryEntity> juryEntities)
        {
            return juryEntities.Select(Map).ToList();
        }
    }
}
