using System;
namespace Festival.Ms.DAL.EntityConfig
{
    public class AnswerEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public AnswerEntity()
        {
            Description = string.Empty;
        }
    }
}

