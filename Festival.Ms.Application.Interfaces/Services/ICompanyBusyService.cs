using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Interfaces.Services
{
    public interface ICompanyBusyService
    {
        Task<DTO.Models.CompanyBusy> GetCompanyBusy(long id);
    }
}
