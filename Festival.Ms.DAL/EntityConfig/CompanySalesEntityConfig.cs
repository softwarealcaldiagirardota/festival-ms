using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public class CompanySalesEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CompanySalesEntity> entityBuilder)
        {
            entityBuilder.ToTable("company_sales");
            entityBuilder.HasKey(x => x.Id).HasName("company_sales_pk");
            entityBuilder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(p => p.IdParticipation).HasColumnName("id_participation");
            entityBuilder.Property(p => p.CreatedAt).HasColumnName("created_at");
            entityBuilder.Property(p => p.Cant).HasColumnName("cant");
            entityBuilder.Property(p => p.IdProduct).HasColumnName("id_product");
            entityBuilder.HasIndex(p => p.IdParticipation).HasDatabaseName("IX_CompanySIdParticipation");
        }
    }
}

