using System;
namespace Festival.Ms.DTO.Models
{
    public class ParticipationCompany
    {
        public int Id { get; set; }
        public long IdCompany { get; set; }
        public long IdFestival { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

