using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class CompanySalesEntity
    {
        public int Id { get; set; }
        public long IdParticipation { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Cant { get; set; }
        public long IdProduct { get; set; }

        public CompanySalesEntity()
        {

        }
    }
}

