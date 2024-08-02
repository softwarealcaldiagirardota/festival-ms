using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public class CompanyBuysEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CompanyBuysEntity> entityBuilder)
        {
            entityBuilder.ToTable("company_buys");
            entityBuilder.HasKey(x => x.Id).HasName("company_buys_pk");
            entityBuilder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(p => p.CreatedAt).HasColumnName("created_at");
            entityBuilder.Property(p => p.Cant).HasColumnName("cant");
            entityBuilder.Property(p => p.IdProduct).HasColumnName("id_product");
            entityBuilder.Property(p => p.IdParticipation).HasColumnName("id_participation");
            entityBuilder.HasIndex(p => p.IdParticipation).HasDatabaseName("IX_IdParticipation");
        }
    }
}

