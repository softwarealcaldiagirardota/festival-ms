using System;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Festival.Ms.DAL.Repositories
{
    public class DeviceParticipationRepository : IDeviceParticipationRepository
    {
        private readonly IFestivalContext _festivalContext;

        public DeviceParticipationRepository(IFestivalContext festivalContext)
        {
            _festivalContext = festivalContext;
        }

        public async Task<int?> CreateAsync(DeviceParticipationEntity entity)
        {
            try
            {
                await _festivalContext.DeviceParticipation.AddAsync(entity);
                await _festivalContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException postgresException && postgresException.SqlState == "23505")
                {
                    // Handle duplicate key violation
                    return null;
                }

                // Re-throw the exception if it's not a duplicate key violation
                throw;
            }
        }

        public async Task<DeviceParticipationEntity?> GetByIdAsync(int id)
        {
            return await _festivalContext.DeviceParticipation.FindAsync(id);
        }

        public async Task<IEnumerable<DeviceParticipationEntity>> GetAllAsync()
        {
            return await _festivalContext.DeviceParticipation.ToListAsync();
        }

        public async Task UpdateAsync(DeviceParticipationEntity entity)
        {
            _festivalContext.DeviceParticipation.Attach(entity);
            _festivalContext.Update(entity).State = EntityState.Modified;
            await _festivalContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _festivalContext.DeviceParticipation.FindAsync(id);
            if (entity != null)
            {
                _festivalContext.DeviceParticipation.Remove(entity);
                await _festivalContext.SaveChangesAsync();
            }
        }
    }
}

