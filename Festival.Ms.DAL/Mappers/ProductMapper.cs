using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Mappers
{
    public class ProductMapper
    {
        public static DTO.Models.Product Map(ProductEntity? productEntity)
        {
            return new DTO.Models.Product()
            {
                Id = productEntity?.Id ?? 0,
                Description = productEntity?.Description ?? string.Empty,
                CreatedAt = productEntity?.CreatedAt ?? DateTime.MinValue,
                Type = productEntity?.Type ?? 0,
                Value = (long)(productEntity?.Value ?? 0) 
            };
        }

        public static IEnumerable<DTO.Models.Product> Map(IEnumerable<ProductEntity> productEntities)
        {
            return productEntities.Select(Map).ToList();
        }
    }
}
