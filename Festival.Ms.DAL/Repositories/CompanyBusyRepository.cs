using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Repositories
{
    public class CompanyBusyRepository : ICompanyBusyRepository
    {
        private readonly IFestivalContext _companyBusyContext;

        public CompanyBusyRepository(IFestivalContext CompanyBusyContext)
        {
            _companyBusyContext = CompanyBusyContext;
        }

        public async Task<CompanyBuysEntity?> GetCompanyBusy(long id)
        {
            return await _companyBusyContext.CompanyBusy.FirstOrDefaultAsync(
                x => x.Id.Equals(id));
        }
    }
}
