using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public long IdUserAuth { get; set; }

        public CompanyEntity()
        {
            Description = string.Empty;
        }
    }
}

