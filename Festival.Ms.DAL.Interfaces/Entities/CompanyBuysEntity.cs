using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class CompanyBuysEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Cant { get; set; }
        public long IdProduct { get; set; }
        public long IdParticipation { get; set; }

        public CompanyBuysEntity()
        {
        }
    }
}

