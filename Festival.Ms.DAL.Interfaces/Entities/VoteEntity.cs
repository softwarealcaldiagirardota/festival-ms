using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class VoteEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public long IdQuestion { get; set; }
        public long IdAnswer { get; set; }
        public long IdParticipationCompany { get; set; }

        public VoteEntity()
        {
        }
    }
}

