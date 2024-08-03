using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class ParticipationCompanyEntity
    {
        public int Id { get; set; }
        public long IdCompany { get; set; }
        public long IdFestival { get; set; }
        public DateTime CreatedAt { get; set; }

        public ParticipationCompanyEntity()
        {
        }
    }
}

