using System;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface IDeviceParticipationRepository
    {
        Task<int?> CreateAsync(DeviceParticipationEntity entity);
        Task<DeviceParticipationEntity?> GetByIdAsync(int id);
        Task<IEnumerable<DeviceParticipationEntity>> GetAllAsync();
        Task UpdateAsync(DeviceParticipationEntity entity);
        Task DeleteAsync(int id);
    }
}

