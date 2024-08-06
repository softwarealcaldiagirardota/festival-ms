using System;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface IParticipationCompanyRepository
    {
        Task<int> CreateAsync(ParticipationCompanyEntity entity);
        Task<ParticipationCompanyEntity> GetByIdAsync(int id);
        Task<IEnumerable<ParticipationCompanyEntity>> GetAllAsync();
        Task UpdateAsync(ParticipationCompanyEntity entity);
        Task DeleteAsync(int id);
        Task<int> GetIdByCompanyAndFestivalAsync(
            int IdCompany, int IdFestival);
    }
}

