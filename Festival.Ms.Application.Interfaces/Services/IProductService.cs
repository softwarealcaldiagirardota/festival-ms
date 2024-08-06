using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<DTO.Models.Product> GetProduct(long id);
        Task<IEnumerable<DTO.Models.Product>> GetAllAsync();
    }
}
