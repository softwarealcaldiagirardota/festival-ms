using System;
using Festival.Ms.DTO.Models;

namespace Festival.Ms.Application.Interfaces.Services
{
    public interface IVoteService
    {
        Task<bool> RegistryVote(List<Vote> entity, string code, int IdFestival);
        Task<int> CreateAsync(Vote entity);
        Task<Vote> GetByIdAsync(int id);
        Task<IEnumerable<Vote>> GetAllAsync();
        Task UpdateAsync(Vote entity);
        Task DeleteAsync(int id);
    }
}

