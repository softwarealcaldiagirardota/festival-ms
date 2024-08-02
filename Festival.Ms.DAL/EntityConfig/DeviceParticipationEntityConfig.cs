using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public static class DeviceParticipationEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<DeviceParticipationEntity> entityBuilder)
        {
            entityBuilder.ToTable("device_participation");

            entityBuilder.HasKey(x => x.Id)
                .HasName("device_participation_pk");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.Hash)
                .HasColumnName("hash")
                .IsRequired()
                .HasColumnType("varchar");

            entityBuilder.Property(p => p.IdParticipation)
                .HasColumnName("id_participation")
                .HasColumnType("bigint")
                .IsRequired();

            entityBuilder.HasIndex(p => new { p.Hash, p.IdParticipation })
                .IsUnique()
                .HasDatabaseName("unique_device_hash");
        }
    }
}

