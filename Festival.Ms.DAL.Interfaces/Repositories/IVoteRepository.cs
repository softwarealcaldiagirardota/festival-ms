using System;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface IVoteRepository
    {
        Task<int> CreateAsync(VoteEntity entity);
        Task<VoteEntity> GetByIdAsync(int id);
        Task<IEnumerable<VoteEntity>> GetAllAsync();
        Task UpdateAsync(VoteEntity entity);
        Task DeleteAsync(int id);
        Task<bool> SaveEntitiesWithTransaction(List<VoteEntity> entities);
    }
}

