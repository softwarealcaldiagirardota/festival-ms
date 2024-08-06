using System;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Festival.Ms.DAL.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly IFestivalContext _festivalContext;

        public VoteRepository(IFestivalContext festivalContext)
        {
            _festivalContext = festivalContext;
        }

        public async Task<int> CreateAsync(VoteEntity entity)
        {
            await _festivalContext.Vote.AddAsync(entity);
            await _festivalContext.SaveChangesAsync();
            var idProperty = typeof(VoteEntity).GetProperty("Id");
            return (int)idProperty.GetValue(entity);
        }

        public async Task<VoteEntity> GetByIdAsync(int id)
        {
            return await _festivalContext.Vote.FindAsync(id);
        }

        public async Task<IEnumerable<VoteEntity>> GetAllAsync()
        {
            return await _festivalContext.Vote.ToListAsync();
        }

        public async Task UpdateAsync(VoteEntity entity)
        {
            _festivalContext.Vote.Attach(entity);
            _festivalContext.Update(entity).State = EntityState.Modified;
            await _festivalContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _festivalContext.Vote.FindAsync(id);
            if (entity != null)
            {
                _festivalContext.Vote.Remove(entity);
                await _festivalContext.SaveChangesAsync();
            }
        }
    }
}

