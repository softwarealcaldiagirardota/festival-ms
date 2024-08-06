using System;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Mappers
{
    public class DeviceParticipationMapper
    {
        public static DTO.Models.DeviceParticipation Map(DeviceParticipationEntity? entity)
        {
            return new DTO.Models.DeviceParticipation
            {
                Id = entity?.Id ?? 0,
                Hash = entity?.Hash ?? string.Empty,
                IdParticipation = entity?.IdParticipation ?? 0
            };
        }
    }
}

