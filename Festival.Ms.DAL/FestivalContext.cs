using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Xml.Serialization;
using Festival.Ms.DAL.Interfaces;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Festival.Ms.DAL.EntityConfig;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Festival.Ms.DAL
{
    public class FestivalContext : DbContext, IFestivalContext
    {
        private readonly DatabaseFacade _database;

        public FestivalContext()
        {
            _database = base.Database;
        }

        public FestivalContext(DbContextOptions<FestivalContext> options) : base(options)
        {
            Database.SetCommandTimeout(0);
            _database = base.Database;
        }

        public virtual DbSet<FestivalEntity> Festival { get; set; }
        public virtual DbSet<CompanyEntity> Company { get; set; }
        public virtual DbSet<AnswerEntity> Answer { get; set; }
        public virtual DbSet<CompanyBuysEntity> CompanyBusy { get; set; }
        public virtual DbSet<CompanySalesEntity> CompanySale { get; set; }
        public virtual DbSet<DeviceParticipationEntity> DeviceParticipation { get; set; }
        public virtual DbSet<ParticipationCompanyEntity> ParticipationCompany { get; set; }
        public virtual DbSet<ProductEntity> Product { get; set; }
        public virtual DbSet<QuestionEntity> Question { get; set; }
        public virtual DbSet<VoteEntity> Vote { get; set; }
        public virtual DbSet<JuryEntity> Jury { get; set; }

        public DatabaseFacade DataBase => _database;


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=festivals;Username=postgres;Password=postgres;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FestivalEntityConfig.SetEntityBuilder(modelBuilder.Entity<FestivalEntity>());
            CompanyEntityConfig.SetEntityBuilder(modelBuilder.Entity<CompanyEntity>());
            VoteEntityConfig.SetEntityBuilder(modelBuilder.Entity<VoteEntity>());
            DeviceParticipationEntityConfig.SetEntityBuilder(modelBuilder.Entity<DeviceParticipationEntity>());
            ParticipationCompanyEntityConfig.SetEntityBuilder(modelBuilder.Entity<ParticipationCompanyEntity>());


            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(
                 t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade
             );

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}