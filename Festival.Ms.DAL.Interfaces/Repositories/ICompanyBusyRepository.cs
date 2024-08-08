using Festival.Ms.DAL.Interfaces.Entities;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface ICompanyBusyRepository
    {
        Task<CompanyBuysEntity?> GetCompanyBusy(long id);
    }
}
