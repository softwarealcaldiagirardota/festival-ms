using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity?> GetProduct(long id);
        Task<IEnumerable<ProductEntity>> GetAllAsync();
    }
}
