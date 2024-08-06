using System;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Migrations;
using Festival.Ms.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace Festival.Ms.DAL.Repositories
{
    public class ParticipationCompanyRepository : IParticipationCompanyRepository
    {
        private readonly IFestivalContext _festivalContext;

        public ParticipationCompanyRepository(IFestivalContext festivalContext)
        {
            _festivalContext = festivalContext;
        }

        public async Task<int> CreateAsync(ParticipationCompanyEntity entity)
        {
            await _festivalContext.ParticipationCompany.AddAsync(entity);
            await _festivalContext.SaveChangesAsync();
            var idProperty = typeof(ParticipationCompanyEntity).GetProperty("Id");
            return (int)idProperty.GetValue(entity);
        }

        public async Task<ParticipationCompanyEntity?> GetByIdAsync(int id)
        {
            return await _festivalContext.ParticipationCompany.FindAsync(id);
        }

        public async Task<IEnumerable<ParticipationCompanyEntity>> GetAllAsync()
        {
            return await _festivalContext.ParticipationCompany.ToListAsync();
        }

        public async Task UpdateAsync(ParticipationCompanyEntity entity)
        {
            _festivalContext.ParticipationCompany.Attach(entity);
            _festivalContext.Update(entity).State = EntityState.Modified;
            await _festivalContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _festivalContext.ParticipationCompany.FindAsync(id);
            if (entity != null)
            {
                _festivalContext.ParticipationCompany.Remove(entity);
                await _festivalContext.SaveChangesAsync();
            }
        }

        public async Task<int?> GetIdByCompanyAndFestivalAsync(
        int IdCompany, int IdFestival)
        {
            return await _festivalContext.ParticipationCompany.Where(p => p.IdCompany == IdCompany && p.IdFestival == IdFestival).Select(p => (int?)p.Id).FirstOrDefaultAsync();
        }
    }
}

