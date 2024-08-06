using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Mappers;
using Festival.Ms.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;


        public ProductService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<DTO.Models.Product> GetProduct(long id)
        {
            return ProductMapper.Map(await _ProductRepository.GetProduct(id));
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var productEntities = await _ProductRepository.GetAllAsync();
            return ProductMapper.Map(productEntities);
        }
    }
}
