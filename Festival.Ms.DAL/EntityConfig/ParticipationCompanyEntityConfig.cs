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
            entityBuilder.ToTable("participation_company");

            entityBuilder.HasKey(x => x.Id)
                .HasName("participation_company_pk");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.IdCompany)
                .HasColumnName("id_company")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.IdFestival)
                .HasColumnName("id_festival")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz");

            entityBuilder.HasIndex(p => new { p.IdCompany, p.IdFestival })
                .IsUnique()
                .HasDatabaseName("unique_company_festival");
        }
    }
}

