using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public static class ParticipationCompanyEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ParticipationCompanyEntity> entityBuilder)
        {
            entityBuilder.ToTable("ParticipationCompany");

            entityBuilder.HasKey(x => x.Id)
                .HasName("participation_company_pk");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.IdCompany)
                .HasColumnName("IdCompany")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.IdFestival)
                .HasColumnName("IdFestival")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("timestamptz");

            entityBuilder.HasIndex(p => new { p.IdCompany, p.IdFestival })
                .IsUnique()
                .HasDatabaseName("unique_company_festival");

            entityBuilder.HasIndex(p => new { p.IdCompany, p.IdFestival, p.Id }).HasDatabaseName("IX_company_participation");
        }
    }
}

