using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<DTO.Models.Company> GetCompany(long id);
        Task<IEnumerable<DTO.Models.Company>> GetAllAsync();
    }
}
 
