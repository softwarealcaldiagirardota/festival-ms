using System;
namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Type { get; set; }
        public decimal Value { get; set; }



        public ProductEntity()
        {
            Description = string.Empty;
        }
    }
}

