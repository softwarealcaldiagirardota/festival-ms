using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public QuestionEntity()
        {
            Description = string.Empty;
        }
    }
}

