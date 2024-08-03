using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class DeviceParticipationEntity
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public long IdParticipation { get; set; }

        public DeviceParticipationEntity()
        {
            Hash = string.Empty;
        }
    }
}

