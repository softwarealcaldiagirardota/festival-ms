using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Festival.Ms.DAL.Interfaces.Repositories;

namespace Festival.Ms.DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IFestivalContext _companyContext;


        public CompanyRepository(IFestivalContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<CompanyEntity?> GetCompany(long id)
        {
            return await _companyContext.Company.FirstOrDefaultAsync(
                x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<CompanyEntity>> GetAllAsync()
        {
            return await _companyContext.Company.ToListAsync();
        }

    }
}
