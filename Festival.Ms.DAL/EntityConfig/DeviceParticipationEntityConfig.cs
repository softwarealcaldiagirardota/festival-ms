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
            entityBuilder.ToTable("DeviceParticipation");

            entityBuilder.HasKey(x => x.Id)
                .HasName("PK_DeviceParticipation");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.Hash)
                .HasColumnName("Hash")
                .IsRequired()
                .HasColumnType("varchar");

            entityBuilder.Property(p => p.IdParticipation)
                .HasColumnName("IdParticipation")
                .HasColumnType("bigint")
                .IsRequired();

            entityBuilder.HasIndex(p => new { p.Hash, p.IdParticipation })
                .IsUnique()
                .HasDatabaseName("unique_device_hash");
        }
    }
}

