using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Festival.Ms.DAL.Interfaces
{
    public interface IFestivalContext
    {
        DbSet<FestivalEntity> Festival { get; set; }
        DbSet<AnswerEntity> Answer { get; set; }
        DbSet<QuestionEntity> Question { get; set; }
        DbSet<CompanyEntity> Company { get; set; }
        DbSet<ProductEntity> Product { get; set; }
        DbSet<CompanySalesEntity> CompanySale { get; set; }
        DbSet<CompanyBuysEntity> CompanyBusy { get; set; }
        DbSet<JuryEntity> Jury { get; set; }
        DbSet<VoteEntity> Vote { get; set; }
        DbSet<DeviceParticipationEntity> DeviceParticipation { get; set; }
        DbSet<ParticipationCompanyEntity> ParticipationCompany { get; set; }


        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade DataBase { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        EntityEntry Update(object entity);
    }
}

