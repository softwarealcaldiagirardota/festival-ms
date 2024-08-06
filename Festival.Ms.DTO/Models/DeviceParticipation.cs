using System;
namespace Festival.Ms.DTO.Models
{
    public class DeviceParticipation
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public long IdParticipation { get; set; }

        public DeviceParticipation()
        {
            Hash = string.Empty;
            IdParticipation = 0;
        }
    }
}

