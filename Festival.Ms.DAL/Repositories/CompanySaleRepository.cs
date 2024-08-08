using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Repositories
{
    public class CompanySaleRepository : ICompanySaleRepository
    {
        private readonly IFestivalContext _CompanySaleContext;

        public CompanySaleRepository(IFestivalContext CompanySaleContext)
        {
            _CompanySaleContext = CompanySaleContext;
        }

        public async Task<CompanySalesEntity?> GetCompanySale(long id)
        {
            return await _CompanySaleContext.CompanySale.FirstOrDefaultAsync(
                x => x.Id.Equals(id));
        }
    }
}
  