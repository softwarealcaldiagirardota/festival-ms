using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public static class CompanyEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CompanyEntity> entityBuilder)
        {
            entityBuilder.ToTable("company");
            entityBuilder.HasKey(x => x.Id).HasName("companies_pk");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("varchar");

            entityBuilder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz");

            entityBuilder.Property(p => p.IdUserAuth)
                .HasColumnName("id_user_auth")
                .HasColumnType("bigint");
        }
    }
}

