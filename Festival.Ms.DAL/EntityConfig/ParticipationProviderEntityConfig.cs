using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public static class ParticipationProviderEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ParticipationProviderEntity> entityBuilder)
        {
            entityBuilder.ToTable("participation_provider");

            entityBuilder.HasKey(x => x.Id)
                .HasName("participation_pk");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.IdProvider)
                .HasColumnName("id_provider")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.IdFestival)
                .HasColumnName("id_festival")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz");
        }
    }
}

