using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Repositories
{
    public class JuryRepository : IJuryRepository
    {
        private readonly IFestivalContext _JuryContext;

        public JuryRepository(IFestivalContext juryContext)
        {
            _JuryContext = juryContext;
        }

        public async Task<JuryEntity?> GetJury(long id)
        {
             return await _JuryContext.Jury.FirstOrDefaultAsync(
                 x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<JuryEntity>> GetAllAsync()
        {
            return await _JuryContext.Jury.ToListAsync();
        }

    }
}
