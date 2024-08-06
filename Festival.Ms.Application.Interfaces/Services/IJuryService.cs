using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Interfaces.Services
{
    public interface IJuryService
    {
        Task<DTO.Models.Jury> GetJury(long id);
        Task<IEnumerable<DTO.Models.Jury>> GetAllAsync();
    }
}
