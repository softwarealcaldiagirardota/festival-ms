using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Interfaces.Services
{
    public interface ICompanySaleService
    {
        Task<DTO.Models.CompanySale> GetCompanySale(long id);
    }
}
