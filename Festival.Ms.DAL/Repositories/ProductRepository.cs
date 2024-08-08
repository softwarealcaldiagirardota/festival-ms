using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IFestivalContext _produtContext;


        public ProductRepository(IFestivalContext ProductContext)
        {
            _produtContext = ProductContext;
        }


        public async Task<ProductEntity?> GetProduct(long id)
        {
            return await _produtContext.Product.FirstOrDefaultAsync(
                x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _produtContext.Product.ToListAsync();
        }

    }
}
